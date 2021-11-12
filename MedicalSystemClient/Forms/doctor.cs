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
    public partial class doctor : BaseWin
    {
        private Socket socket;
        private string client_name; //локальное имя данной клиентской машины
        private string passw; //локальный пароль данной клиентской машины
        private byte[] data; //буфер данных для чтения и отправки
        private List<string> doc_fio = new List<string>();

        public doctor(List<string> fio, Socket socket, string name, string passw)
        {
            InitializeComponent();
            this.label1.Text = "Раздел врача";
            SetElements(new int[] { 263, 457, 529, 165 }, new int[] { 287, 15, 48, 30 });
            this.doc_fio = fio;
            this.socket = socket;
            this.client_name = name;
            this.passw = passw;
            this.timer1.Start();
            this.User_view.Text = "Пользователь:\t" + '\t' + doc_fio[0] + ' ' + doc_fio[1] + ' ' + doc_fio[2];
        }
    }
}
