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
    public partial class BaseWin : Form
    {
        public BaseWin()
        {
            InitializeComponent();
        }

        private void ExitBt_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToLongTimeString();
            this.timeLb.Text = time;
        }

        protected void SetElements(int[] X, int[] Y)
        {
            Point BtP = new Point(X[0], Y[0]);
            Point BtTime = new Point(X[1], Y[1]);
            Point BtUser = new Point(X[2], Y[2]);
            Point BtLabel = new Point(X[3], Y[3]);
            this.exitBt.Location = BtP;
            this.timeLb.Location = BtTime;
            this.User_view.Location = BtUser;
            this.label1.Location = BtLabel;
        }
    }
}
