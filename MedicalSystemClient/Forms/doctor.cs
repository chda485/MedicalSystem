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
        public doctor(List<string> fio, Socket socket, string name, string passw)
        {
            InitializeComponent();
            this.label1.Text = "Раздел врача";
            SetElements(new int[] { 524, 522, 354, 165 }, new int[] { 283, 15, 48, 30 });
            this.Size = new Size(632, 377);
            this.user_fio = fio;
            this.socket = socket;
            this.client_name = name;
            this.passw = passw;
            this.timer1.Start();
            this.User_view.Text = "Пользователь:\t" + '\t' + user_fio[0] + ' ' + user_fio[1] + ' ' + user_fio[2];
        }
    }
}
