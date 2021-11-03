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
    public partial class doctor : Form
    {
    	private Form parent;
        private Socket socket;
        private string client_name; //локальное имя данной клиентской машины
        private string passw; //локальный пароль данной клиентской машины
        private byte[] data; //буфер данных для чтения и отправки
        private List<string> doc_fio = new List<string>();

        public doctor(List<string> fio, Form parent, Socket socket, string name, string passw)
        {
            InitializeComponent();
            this.doc_fio = fio;
            this.parent = parent;
            this.socket = socket;
            this.client_name = name;
            this.passw = passw;
            this.timer1.Start();
            this.User_view.Text = "Пользователь:\t" + '\t' + doc_fio[0] + ' ' + doc_fio[1] + ' ' + doc_fio[2];
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            this.timeLb.Text = time;
        }
    }
}
