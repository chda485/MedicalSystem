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
    public partial class Base : Form
    {
        
        public Base()
        {
            InitializeComponent();
        }

        public void SetBaseSetts(Socket socket, string name, string passw)
        {
            this.socket = socket;
            this.client_name = name;
            this.passw = passw;
        }

        private void ExitBt_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
