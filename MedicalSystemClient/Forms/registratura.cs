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
        private Socket socket;
        private string client_name = "localclient"; //локальное имя данной клиентской машины
        private string passw = "12345"; //локальный пароль данной клиентской машины
        private byte[] data; //буфер данных для чтения и отправки
        public registratura(List<string> fio, Form parent, Socket socket)
        {
            InitializeComponent();
            List<string> reg_fio = fio;
            this.parent = parent;
            this.socket = socket;
			this.User_view.Text = "Пользователь:\n" + reg_fio[0] + ' ' + reg_fio[1] + ' ' + reg_fio[2];
        }
		
		private void findBt_click(object sender, EventArgs e)
		{
			
		}

        private void ExitBt_Click(object sender, EventArgs e)
        {
            string mes = String.Format("@disconnect;{0};{1};{2};disconnect//@",
                                                this.client_name, this.passw, DateTime.Now.ToShortTimeString());
            data = new byte[256];
            data = Encoding.Unicode.GetBytes(mes);
            this.socket.Send(data);
            this.socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            this.parent.Close();
            this.Close();
        }
    }
}
