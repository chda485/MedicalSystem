using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystemClient
{
    public partial class registratura : Form
    {
        private Form parent;
        public registratura(List<string> fio, Form parent)
        {
            InitializeComponent();
            List<string> reg_fio = fio;
            this.parent = parent;
			this.User_view.Text = "Пользователь:\n" + reg_fio[0] + ' ' + reg_fio[1] + ' ' + reg_fio[2];
        }
		
		private void findBt_click(object sender, EventArgs e)
		{
			
		}

        private void ExitBt_Click(object sender, EventArgs e)
        {
            this.parent.Close();
            this.Close();
        }
    }
}
