using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Principal;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MedicalSystemServer
{
    class ServerClass
    {
        static int port = 8005;
        static void Main(string[] args)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(ipPoint);
                listener.Listen(10);
                Console.WriteLine("Server started");
				
				//DbHelper();

                while (true)
                {
                    Socket handler = listener.Accept();
                    ThreadServer client = new ThreadServer(handler);
                    Thread thread = new Thread(new ThreadStart(client.doConnect));
                    thread.Start();
                    if (DateTime.Now.TimeOfDay.ToString().Split('.')[0] == "00:00:00" && 
                        DateTime.Now.DayOfWeek.ToString() == "Monday")
                    {
                        string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ServiceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                        using (SqlConnection connect = new SqlConnection(connection))
                        {
                            connect.Open();
                            SqlCommand command = new SqlCommand("DELETE FROM Users;", connect);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
		
		static void DbHelper()
		{
			string connection2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\prog\c#\projects\МедСистема\MedicalSystemServer\Patients.mdf;Integrated Security=True";			
			using (SqlConnection connect = new SqlConnection(connection2))
			{
				connect.Open();
				Dictionary<int, string> for_insert = new Dictionary<int, string>
				{
					{0, "08:00 - 14:00" }, {1, "14:00 - 20:00"},
					{2, "Sick" }, {3, "Vacation"}
				};
				List<int> personal = new List<int>
				{
					2, 3, 4, 5, 6, 7, 8, 9, 10, 11
				};
				string[,] FIO = new string[11,3]
				{
					{ "Mihaleva", "Aleksandra", "Sergeevna"},
					{ "Petrov", "Petr", "Petrovich" },
					{ "Alekseev", "Aleksei", "Alekseevich" },
					{ "Rodina", "Vera", "Sergeevna" },
					{ "Maheev", "Petr", "Kirilovich" },
					{ "Semenov", "Victor", "Sergeevich" },
					{ "Semina", "Olga", "Mihailovna" },
					{ "Zubarev", "Nikolai", "Victorovich" },
					{ "Minin", "Arseni", "Semenovich" },
					{ "Soshkina", "Victoria", "Igorevna" },
					{ "Kalinin", "Dmitry", "Alekseevich" },
				};
				
				List<string> categories = new List<string>
				{
					"Registratura", "Terapevt", "Terapevt", "Terapevt",
					"Terapevt", "LOR", "LOR", "Okulist", "Okulist", 
					"Hirurg", "Hirurg"
				};

				List<string> times = new List<string>
				{
					"08:00 - 09:00", "09:00 - 10:00", "10:00 - 11:00",
					"11:00 - 12:00", "12:00 - 13:00", "13:00 - 14:00",
					"14:00 - 15:00", "15:00 - 16:00", "16:00 - 17:00",
					"17:00 - 18:00", "18:00 - 19:00", "19:00 - 20:00"
				};

				try
				{
					for (int i = 0; i < 10; i++)
                    {
						Random rand = new Random();
						int month = DateTime.Now.Month;
						int day = DateTime.Now.Day;
						int insert_day = rand.Next(day - 2, day);
						string date = new DateTime(
							DateTime.Now.Year, month, insert_day).ToString("yyyy-MM-dd");
						int doctor = rand.Next(0, 10);
						int doc_id = personal[doctor];
						int time = rand.Next(0, 12);
						int patient = rand.Next(1, 3);
						string t = times[time];
						string com = String.Format(@"INSERT INTO Writes (Id_patient, Id_doctor,
													Day, Time) VALUES ('{0}', '{1}', '{2}', '{3}')",
													patient, doc_id, date, t);
						SqlCommand command = new SqlCommand(com, connect);
						int lines = command.ExecuteNonQuery();
					}
					/*
					for (int i = 1; i < 12; i++)
					{
						Random rand = new Random();
						int exp = rand.Next(3,8);
						int age = rand.Next(28, 35);
						string com = String.Format(@"INSERT INTO Personal (Family, Name, Otchestvo,
													Category, Age, Work_exp, Address) 
													VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
													FIO[i-1, 0],FIO[i-1, 1], FIO[i-1, 2], categories[i-1],
													age, exp, "Oryol");
						SqlCommand command = new SqlCommand(com, connect);
						int lines = command.ExecuteNonQuery();
					}
					
					for (int i = 0; i < 10; i++)
					{
						int user = personal[i];
						Console.WriteLine("Insert user - {0}", user);
						Random rand = new Random();
						for (int month = 1; month < 13; month++)
						{
							Console.WriteLine("Insert month - {0}", month);
							int day_month = DateTime.DaysInMonth(2021, month);
							for (int day = 1; day < day_month + 1; day++)
							{
								string date = new DateTime(2021, month, day).ToString("yyyy-MM-dd");
								int num = rand.Next(0, 4);
								string work = for_insert[num];
								string com = String.Format(@"INSERT INTO Doctor_schedular (Id_user, Day, Work_time) 
												   VALUES('{0}', '{1}', '{2}')", user, date, work);
								Console.WriteLine(com);
								SqlCommand command = new SqlCommand(com, connect);
								int lines = command.ExecuteNonQuery();
								Console.WriteLine("Insert {0} lines", lines);
							}
						}
						
					}
					*/

				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				
			}
		}
    }
}
