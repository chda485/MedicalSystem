using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace MedicalSystemClient
{
    public partial class registratura : Form
    {
        private Form parent;
        private Socket socket; //сокет, используемый для связи с сервером
        private string client_name; //локальное имя данной клиентской машины
        private string passw; //локальный пароль данной клиентской машины
        private byte[] data; //буфер данных для чтения и отправки
        private List<string> reg_fio = new List<string>(); //список ФИО пользователя
        private List<string> results = new List<string>(); //список результатов запроса к БД
		private List<TextBox> fields; //список текстовых полей используемых для поиска
		private StringBuilder builder = new StringBuilder(); //конструктор строк сообщений
		private int num_patients; //число отображаемых пациентов
		private int current_patient = 0; // индекс текущего отображаемого пациента
		private string[] patients; // массив данных по пациентам

        public registratura(List<string> fio, Form parent, Socket socket, string name, string passw)
        {
            InitializeComponent();
            this.reg_fio = fio;
            this.parent = parent;
            this.socket = socket;
            this.client_name = name;
            this.passw = passw;
			this.fields = new List<TextBox>() {  //КОРРЕКТИРОВАТЬ ПО ПОРЯДКУ НА ФОРМЕ
                this.family, this.phone, this.borning_date,
				this.snils, this.address, this.Ser_passport,
				this.Num_passport, this.otchestvo, 
				this.name, this.Area, this.Work,
                this.Num_polis
            };
            this.User_view.Text = "Пользователь:\t" + '\t' + reg_fio[0] + ' ' + reg_fio[1] + ' ' + reg_fio[2];
			this.nextBt.Enabled = false;
			this.prevBt.Enabled = false;
            this.timer1.Start();
        }
		
		private void nextBt_click(object sender, EventArgs e)
		{
			//берём индекс следующего пациента
			this.current_patient += 1;
			//берём данные по следующему пациенту
			string patient = this.patients[current_patient];
			string[] data = patient.Split('|');
			InsertOperation(data);
			this.prevBt.Enabled = true;
			//если не осталось больше данных по пациентам			
			if (current_patient + 1 == num_patients)
			{
				this.nextBt.Enabled = false;
			}
		}
		
		private void prevBt_click(object sender, EventArgs e)
		{
            this.current_patient -= 1;
            string patient = this.patients[current_patient];
            string[] data = patient.Split('|');
            InsertOperation(data);
            this.nextBt.Enabled = true;
            //если не осталось больше данных по пациентам			
            if (current_patient == 0)
            {
                this.prevBt.Enabled = false;
            }
        }
		
        private void findBt_click(object sender, EventArgs e)
        {
			//очищаем результаты предыдущих запросов
			this.builder.Clear();
            //проверяем, введено ли значение хотя бы в одно поле
            bool fields_choice = false;
            foreach (var item in fields) 
            {
                if (item.Text.Length != 0)
                    fields_choice = true;
            }
            //если все поля поиска пусты
            if (fields_choice == false)
            {
                MessageBox.Show("Не заданы данные для поиска");
                return;
            }
			//создаём запрос
			string queary = MakeQueary();
			//создаём сообщение для отправки
			string mes = String.Format("@select;{0};{1};{2};{3}//@",
										this.client_name, this.passw, DateTime.Now.ToShortTimeString(),
										queary);
			data = new byte[256];
			data = Encoding.Unicode.GetBytes(mes);
			this.socket.Send(data);
			
			data = new byte[256];
			int bytes = 0;
			//пока есть данные, читаем их
			do
			{
				bytes = socket.Receive(data, data.Length, 0);
				this.builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
			}
			while (socket.Available > 0);
			//проверяем присланный ответ
			bool check = CheckAnswer(builder.ToString());
			if (check == true)
			{
				InsertData();				
			}
        }

        private void clearBt_click(object sender, EventArgs e)
        {
            foreach (var item in fields) //!!!!!!!!!!!!!!
                item.Clear();
			this.nextBt.Enabled = false;
			this.prevBt.Enabled = false;
        }

        private void ExitBt_Click(object sender, EventArgs e)
        {
            //создаем сообщение серверу об отсоединении
            string mes = String.Format("@disconnect;{0};{1};{2};disconnect//@",
                                                this.client_name, this.passw, DateTime.Now.ToShortTimeString());
            //отправляем сообщение
            data = new byte[256];
            data = Encoding.Unicode.GetBytes(mes);
            this.socket.Send(data);
            //закрываем сокет, текущее окно и спрятанное родительское (авторизации)
            this.socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            this.parent.Close();
            this.Close();
        }

        private string MakeQueary()
        {
            string first_field = "";
            //ищем первое заполненное поле
            foreach (var item in fields) //!!!!!!!!!!!!
        	{
        		//как находим, записываем его имя в переменную
        		if (item.Text.Length != 0)
        		{
        			first_field += item.Name; 
        			break;
        		}
        	}
        	//создаем объект-конструктор строки запроса
        	StringBuilder queary = new StringBuilder("SELECT * FROM Patients WHERE ");
        	//добавляем только значения заполненных полей
        	foreach (var item in fields) 
        	{
        		if (item.Text.Length != 0)
        		{
        			//если это не первое заполненное поле, то добавляем AND
        			if (item.Name == first_field)
        			{
                        string q = String.Format("{0} = '{1}'", item.Name, item.Text);
                        queary.Append(q);
        			}
        			else
        			{
                        string q = String.Format("AND {0} = '{1}'", item.Name, item.Text);
                        queary.Append(q);	
        			}
        		}
        	}
        	return queary.ToString(); 
        }
		
		private bool CheckAnswer(string answer)
		{
            this.results.Clear();
            //если сообщение имеет неправильный формат
            if (!answer.StartsWith("@") && !answer.EndsWith("//@"))
            {
            	MessageBox.Show("Ошибка связи с сервером");
                return false;
            }
            //парсим сообщение в список
            results = answer.Split(';').ToList();
            //удаляем конечные символы //@
            results[2] = results[2].Substring(0, results[2].Length - 3);
            //если сервер прислал не тому клиенту
            if (!results[1].Equals(this.client_name))
            {
            	MessageBox.Show("Ошибка связи с сервером");
                return false;
            }
			if (results[2] == "в БД отсутствуют данные по вашему запросу")
			{
				MessageBox.Show("В БД отсутствуют данные по вашему запросу");
                return false;
			}
			return true;
		}
		
		private void InsertData()
		{
			string[] data;
			//проверяем, несколько ли строк в ответе
			if (results[2].Contains('$')) // ПОМЕНЯТЬ ПО ПОРЯДКУ НА ФОРМЕ
			{
				data = results[2].Split('$')[0].Split('|');
				this.patients = results[2].Split('$');
				num_patients = results[2].Split('$').Length;
				this.nextBt.Enabled = true;
			}
			else
			{
				data = results[2].Split('|');
				this.nextBt.Enabled = false;
			}
			//сама операция вставки данных
			InsertOperation(data);
		}
		
		private void InsertOperation(string[] data)
		{
			this.family.Text = data[1];
            this.name.Text = data[2];
            this.otchestvo.Text = data[3];
            this.borning_date.Text = data[4];
            this.Num_passport.Text = data[5];
            this.Ser_passport.Text = data[6];
            this.address.Text = data[7];
            this.Num_polis.Text = data[8];
            this.snils.Text = data[9];
            this.Area.Text = data[10];
            this.Work.Text = data[11];
            this.phone.Text = data[12];   
		}

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            this.timeLb.Text = time;
        }
    }
}
