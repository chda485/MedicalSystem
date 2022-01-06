using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace MedicalSystemServer
{
    public class ThreadServer
    {
        private Socket socket;
        private string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\prog\c#\projects\МедСистема\MedicalSystemServer\Patients.mdf;Integrated Security=True";
        private string connection2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\prog\c#\projects\МедСистема\MedicalSystemServer\ServiceDB.mdf;Integrated Security=True";
        //список для хранения результатов запроса
        private List <string> results = new List<string>();
        //список составных элементов запроса
        private List <string> message_list = new List<string>();
        //словарь типов сообщений серверу и соответсвующих кодов
        private Dictionary<string, int> typeDict = new Dictionary<string, int>() {
            {"select_user", 0 }, {"select", 1}, {"insert", 2}, {"disconnect", 3}
        };
        //отсылаемые клиенту данные
        private string answer = "@";
        private string help_string, error;
        //список внутренних паролей
        private List<string> password_list = new List<string>()
        {
            "12345", "54321"
        };
		
        public ThreadServer(Socket ClientSocket)
        {
            socket = ClientSocket;
        }

        public void doConnect()
        {
            try
            {				
                byte[] data = new byte[1024];
                StringBuilder builder = new StringBuilder();
                int bytes = 0, x = 0;
                while (true)
                {
                    //очищаем следы предыдущих запросов
                    builder.Clear();
                    this.help_string = "";
                    //если нет данных от клиента, ничего не делаем
                    if (socket.Available == 0)
                        continue;
                    //пока есть данные, читаем сообщение
                    do
                    {
                        bytes = socket.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);

                    string Queary = builder.ToString();
                    Console.WriteLine(Queary);
                    //обнуляем предыдущие ответы клиенту
                    this.answer = "@";
                    //проверяем тип сообщения
                    int type = MessageParser(Queary);
                    //выводим объем полученных данных
                    data = Encoding.Unicode.GetBytes(Queary);
                    Console.WriteLine(@DateTime.Now.ToShortTimeString() + " : FromUser " + message_list[1] +
                                     " received " + Convert.ToString(data.Length) + " bytes");
                    //записываем в журнальную БД кто подключился и что прислал
                    try
                    {
                        //проверяем счётчик, чтобы записать один раз при подключении
                        if (x == 0)
                        {
                            this.Make_Log("user", 0);
                            x++;
                        }
                        this.Make_Log("connect_message", data.Length);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
					
                    //если неверное сообщение
                    if (type == -1)
                    {                     
                        this.answer += DateTime.Now.ToShortTimeString() + ';' + message_list[1] + ";" + this.error + "//@";
						//записываем в журнальную БД сообщение об ошибке
						try
						{
							this.Make_Log("error", data.Length);
						}
						catch(Exception ex)
						{
							Console.WriteLine(ex.Message);
						}					
					}
                    else if(type == 3)
                    {
                        break;
                    }
                    //если запрос для авторизации в системе
                    else if(type == 0)
                    {
                        //проверяем, есть ли такой пользователь
                        bool check_user = this.CheckIsTrueUser(this.message_list[4]);
                        //если есть
                        if (check_user)
                        {
                            this.help_string = "User exist";
                            answer += DateTime.Now.ToShortTimeString() + ';' + message_list[1].ToString() + ';' + results[0] + "//@";
                        }
                        else
                        {
                            results.Add("такой пользователь отсутствует в системе");
                            answer += DateTime.Now.ToShortTimeString() + ';' + message_list[1].ToString() + ";такой пользователь отсутствует в системе//@";
                        }
                    }
                    //если запрос на выборку данных
                    else if (type == 1)
                    {
                        this.ConnectToDb(message_list[4], message_list[0]);
                        if (results.Count != 0)
                        {
                            string temp_str = "";
                            //перебираем все строки ответа и соединяем в одну большую для передачи клиенту
                            foreach (string str in results)
                            { 
                            	temp_str += str;
                            	temp_str += "$";
                            }
                            temp_str = temp_str.Substring(0, temp_str.Length - 1);
                            answer += DateTime.Now.ToShortTimeString() + ';' + message_list[1].ToString() + ';' + temp_str + "//@";
                        }
                        else
                        {
                            answer += DateTime.Now.ToShortTimeString() + ';' + message_list[1].ToString() + "; в БД отсутствуют данные по вашему запросу//@";
                        }
                    }
                    //если запрос на добавление данных
                    else if (type == 2)
                    {
                        this.ConnectToDb(message_list[4], message_list[0]);
                        if (results[0] == "success insert")
                            answer += DateTime.Now.ToShortTimeString() + ';' + message_list[1].ToString() + "; данные успешно добавлены//@";
                        else if ((results[0] == "unsuccess insert") || (results[0] == "error"))
                            answer += DateTime.Now.ToShortTimeString() + ';' + message_list[1].ToString() + "; не удалось добавить данные//@";
                        else
                            answer += DateTime.Now.ToShortTimeString() + ';' + message_list[1].ToString() + "; данные уже имеются в БД//@";
                    }
                    data = Encoding.Unicode.GetBytes(answer);
                    //выводим объем переданных данных 
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + " : ToUser " + message_list[1] +
                    					" sended " + Convert.ToString(data.Length) + " bytes");
                    //записываем, что ответили клиенту
                    try
                    {
                        this.Make_Log("response", data.Length);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    socket.Send(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            socket.Shutdown(SocketShutdown.Both);
            Console.WriteLine("Check2");
			//записываем время отключения
			try
			{
				this.Make_Log("user", 1);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
            socket.Close();
        }
        private void ConnectToDb(string queary, string queary_type)
        {
            //очищаем результаты предыдущих запросов
            results.Clear();
            //соединяемся с БД
            using (SqlConnection connect = new SqlConnection(this.connection))
            {
                connect.Open();
                //если поступил запрос на выборку
                if ((queary_type == "select_user") || (queary_type == "select"))
                {
                    SqlCommand command = new SqlCommand(queary, connect);
                    SqlDataReader reader = command.ExecuteReader();
                    //если есть данные в БД
                    if (reader.HasRows)
                    {
                        //читаем построчно данные
                        while(reader.Read())
                        {
                            string str = "";
                            //получаем число столбцов в результате запроса
                            int fields = reader.FieldCount;
                            for (int i = 0; i < fields; i++)
                            {
                                //читаем по столбцу и преобразуем единую строку значения
                                //из одной строки таблицы
                                str += Convert.ToString(reader.GetValue(i));
                                str += '|'; 
                            }
						    str = str.Substring(0, str.Length - 1);
                            results.Add(str);
                        }
                    }
                }
                //если запрос на добавление данных
                else if (queary_type == "insert")
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(queary, connect);
                        int number = command.ExecuteNonQuery();
                        //если данные успешно добавлены
                        if (number != 0)
                        {
                            results.Add("success insert");
                        }
                        else
                            results.Add("unsuccess insert");
                    }
                    catch(SqlException ex)
                    {
                        if (ex.Number == 2627)
                            results.Add("date already existed");
                        else
                            results.Add("error");
                    }
                }
                connect.Close();
            }
        }

        private bool CheckIsTrueUser(string userMessage)
        {
            //выполняем запрос
            this.ConnectToDb(userMessage, "select_user");
            //проверяем, есть ли результаты (есть ли такой пользователь)
            if (results.Count == 0)
            {
                return false;
            }
            return true;
        }

        private int MessageParser(string message)
        {
            //проверяем, что сообщение имеет верный формат
            if (!message.StartsWith("@") && !message.EndsWith("//@"))
            {
                Console.WriteLine(DateTime.Now.ToShortTimeString() + " : неверный формат сообшения");
                this.error = "Uncorrect format";
                return -1;
            }
            string[] list = message.Split(';');
            this.message_list = list.ToList();
            //проверяем, действительно ли это клиент приложения
            if (!password_list.Contains(this.message_list[2]))
            {
                Console.WriteLine(DateTime.Now.ToShortTimeString() + " : попытка несанкционированного доступа");
                this.error = "Attempt to burglar";
                return -1;   
            }
            string type = this.message_list[0];
            //убираем первый символ формата сообщения
            this.message_list[0] = type.Substring(1);
            string queary = this.message_list[4];
            //убираем символы в конце
            this.message_list[4] = queary.Substring(0, queary.Length - 3);
            return typeDict[this.message_list[0]];
        }
	
	    private void Make_Log(string type, int volume)
	    {
		    using (SqlConnection connect = new SqlConnection(this.connection2))
            {
                connect.Open();
				string user = this.message_list[1];
				string con_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				string q_type = this.message_list[0];
                string server_reply = "", queary = "";
                if (type == "connect_message")
                {
                    queary = String.Format(@"INSERT INTO Connections (User_name, Connection_time, Queary_type, Message_volume)
										    VALUES ('{0}', '{1}', '{2}', '{3}')", user, con_time, q_type, volume);
                }
                else if (type == "response")
                {
                    if (results.Count == 0)
                    {
                        server_reply = "DB doen't have the needed data";
                        //добавляем пустышку для корректной работы swicth снизу
                        results.Add("0");
                    }
                    else if (this.help_string == "User exist")
                        server_reply = "Data about user is sended";
                    else if (results.Count > 0 && results[0] != "0")
                        server_reply = "Data is sended to the client";

                    switch (results[0])
                    {
                        case "такой пользователь отсутствует в системе": server_reply = "Message the unexisting user"; break;
                        case "success insert": server_reply = "Data is inserted"; break;
                        case "unsuccess insert":
                        case "error": server_reply = "Error while inserting the data"; break;
                        case "date already existed": server_reply = "Attempt to insert existing data"; break;
                    }
                    queary = String.Format(@"INSERT INTO Responses (User_name, Response_time, Response, Response_volume)
										        VALUES ('{0}', '{1}', '{2}', '{3}')", user, con_time, server_reply, volume);
                }
                else if (type == "error")
                {
                    queary = String.Format(@"INSERT INTO Errors (User_name, Time_error, Error)
                                            VALUES ('{0}', '{1}', '{2}')", user, con_time, this.error);
                }
                else if (type == "user")
                {
                    if (volume == 0)
                    {
                        queary = String.Format(@"INSERT INTO Users (User_name, Time_con)
												VALUES ('{0}', '{1}')", user, con_time);
                    }
                    else if (volume == 1)
                    {
                        string discon_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        queary = String.Format(@"UPDATE Users SET Time_discon='{0}'
												WHERE User_name = '{1}' AND Id = (
                                                SELECT MAX(Id) FROM Users WHERE User_name = '{2}')", discon_time, user, user);
                    }
                }
                SqlCommand command = new SqlCommand(queary, connect);
                int num = command.ExecuteNonQuery();
                if (num == 0)
                    Console.WriteLine("Error insert to Service DB");
            }
	    }	
   }
}
