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
                Console.WriteLine(DateTime.Now.DayOfWeek.ToString());
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
