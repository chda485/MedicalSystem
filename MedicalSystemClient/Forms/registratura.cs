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

        //список текстовых полей используемых для поиска
        private Control textBoxes = Controls.Where(c => c is TextBox);

        public registratura(List<string> fio, Form parent, Socket socket, string name, string passw)
        {
            InitializeComponent();
            this.reg_fio = fio;
            this.parent = parent;
            this.socket = socket;
            this.client_name = name;
            this.passw = passw;
            this.User_view.Text = "Пользователь:\n" + reg_fio[0] + ' ' + reg_fio[1] + ' ' + reg_fio[2];
        }

        private void findBt_click(object sender, EventArgs e)
        {
            //список текстовых полей используемых для поиска
            List<TextBox> fields = new List<TextBox>() {
                this.family, this.phone, this.age,
                this.snils, this.address, this.passportSer, this.passportNum,
                this.otchestvo, this.name,
                this.areaNum, this.job
            };

            Control d = this.Controls["name"];
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
        }

        private void clearBt_click(object sender, EventArgs e)
        {
            //список текстовых полей используемых для поиска
            List<TextBox> fields = new List<TextBox>() {
                this.family, this.phone, this.age,
                this.snils, this.address, this.passportSer, this.passportNum,
                this.otchestvo, this.name,
                this.areaNum, this.job
            };
            foreach (var item in fields)
                item.Clear();
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
            //список текстовых полей используемых для поиска
            List<TextBox> fields = new List<TextBox>() {
                this.family, this.phone, this.age,
                this.snils, this.address, this.passportSer, this.passportNum,
                this.otchestvo, this.name,
                this.areaNum, this.job
            };
            string first_field = "";
            //ищем первое заполненное поле
            foreach (var item in fields) 
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
    }
}
