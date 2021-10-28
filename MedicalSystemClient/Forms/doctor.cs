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
        private List<string> doc_fio;

        public doctor(List<string> fio, Form parent, Socket socket, string name, string passw)
        {
            InitializeComponent();
            this.doc_fio = fio;
            this.parent = parent;
            this.socket = socket;
            this.client_name = name;
            this.passw = passw;
        }
    }
}
