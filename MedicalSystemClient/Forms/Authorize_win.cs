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
    public partial class Authorize_win : Form
    {
        static int port = 8005; //порт для подключения
        static string address = "127.0.0.1"; //Ip-адрес для подключения
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port); //точка подключения
        Socket socket; //сокет для обмена данными с сервером
        private string name = "localclient"; //локальное имя данной клиентской машины
        private string passw = "12345"; //локальный пароль данной клиентской машины
        private byte[] data; //буфер данных для чтения и отправки
        private List<string> mes = null; //список строк сообщения
        private List<string> fio; //ФИО подключаемого сотрудника

        public Authorize_win()
        {
            InitializeComponent();
        }

        private void enterBt_Click(object sender, EventArgs e)
        {
            try
            {
                //создаём сокет для подключения
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);

                //формируем запрос на авторизацию к БД
                string Queary = String.Format("SELECT Id_user, Dopusk FROM Users WHERE Name = '{0}' AND Password = '{1}'",
                                              user_name.Text, password.Text);
                //формируем сообщение с запросом для отправки серверу
                string message = String.Format("@select_user;{0};{1};{2};{3}//@",
                                                this.name, this.passw, DateTime.Now.ToShortTimeString(), Queary);
                data = Encoding.Unicode.GetBytes(message);
                //отправляем сообщение серверу
                socket.Send(data);

                data = new byte[256];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                //пока есть данные, читаем их
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                //преобразуем все ответы в строковый вид
                string answer = builder.ToString();
                //проверяем, корректный ли ответ от сервера
                bool isGoodAnswer = CheckAnswer(answer, 0);
                //если это корректный ответ
                if (isGoodAnswer == true)
                {
                    //читаем id и код допуска
                    int dopusk = Convert.ToInt32(mes[2].Split('|')[1]);
                    string id = mes[2].Split('|')[0];
                    //формируем запрос на ФИО работника
                    string data_queary = String.Format("SELECT Family, Name, Otchestvo, Category FROM Personal WHERE Id = '{0}'", id);
                    message = String.Format("@select;{0};{1};{2};{3}//@",
                                                    this.name, this.passw, DateTime.Now.ToShortTimeString(), data_queary);
                    //отправляем этот запрос
                    data = new byte[256];
                    data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);

                    //очищаем объект чтения строк
                    builder.Clear();
                    data = new byte[256];
                    //пока есть данные, читаем их
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);
                    //проверяем, корректное ли пришло ФИО
                    bool goodFIO = CheckAnswer(builder.ToString(), 1);
                    if (goodFIO == true)
                    {
                    	//если это врач
                    	if (dopusk == 1)
                    	{
                    		doctor doctor_win = new doctor(fio, socket, this.name, this.passw);
                    		doctor_win.Show();
                    		this.Hide();
                    	}
                    	//если это работник регистратуры
                    	else if (dopusk == 2)
                    	{
                    		registratura registr_win = new registratura(fio, socket, this.name, this.passw);
                            this.Hide();
                    		registr_win.Show();
                    	}
                    }
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + '1');
            }
        }

        private bool CheckAnswer(string answer, int type_check)
        {
            //очищаем список предыдущих сообщений
            if (mes != null)
                mes.Clear();
            //если сообщение имеет неправильный формат
            if (!answer.StartsWith("@") && !answer.EndsWith("//@"))
            {
            	MessageBox.Show("Ошибка связи с сервером");
                return false;
            }
            //парсим сообщение в список
            mes = answer.Split(';').ToList();
            //удаляем конечные символы //@
            mes[2] = mes[2].Substring(0, mes[2].Length - 3);
            //если сервер прислал не тому клиенту
            if (mes[1] != name)
            {
            	MessageBox.Show("Ошибка связи с сервером");
                return false;
            }
            //если это сообщение-ответ на запрос авторизации
        	if (type_check == 0)
        	{	            
	            if (mes[2] == "такой пользователь отсутствует в системе")
	            {
	                MessageBox.Show("Введены неверные данные");
	                return false;
	            }
	            else if (mes[2] == "Attempt to burglar")
	            {
	                MessageBox.Show("Ошибка связи с сервером");
	                return false;
	            }
        	}
        	//если это сообщение-ответ с ФИО
        	else if (type_check == 1)
        	{
        		fio = mes[2].Split('|').ToList();
        		foreach(string part in fio)
        		{
        			foreach(char letter in part)
        			{
        				if (Char.IsLetter(letter) )
							continue;
						else
						{
							MessageBox.Show("Ошибка. В БД находятся неверные данные по Вашему запросу. Свяжитсь с администратором");
							return false;
						}
        			}
        		}
        	}
            return true;
        }

        private void CloseBt_Click(object sender, EventArgs e)
        {         
            this.Close();
        }

        private void Authorize_win_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.socket != null)
            {
                //создаем сообщение серверу об отсоединении
                string mes = String.Format("@disconnect;{0};{1};{2};disconnect//@",
                                                    this.name, this.passw, DateTime.Now.ToShortTimeString());
                //отправляем сообщение
                data = new byte[256];
                data = Encoding.Unicode.GetBytes(mes);
                this.socket.Send(data);
                //закрываем сокет, текущее окно и спрятанное родительское (авторизации)
                this.socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }
    }
}
