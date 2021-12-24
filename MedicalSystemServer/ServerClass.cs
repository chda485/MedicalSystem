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
                /*
                string connection2 = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Patients;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
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
                        6, 7, 8, 9, 10, 11, 12, 13, 14, 15
                    };
                    try
                    {
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
                                    SqlCommand command = new SqlCommand(com, connect);
                                    int lines = command.ExecuteNonQuery();
                                    Console.WriteLine("Insert {0} lines", lines);
                                }
                            }
                            
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                */
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
    }
}
