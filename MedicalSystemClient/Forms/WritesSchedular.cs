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
    public partial class WritesSchedular : BaseWin
    {
        public WritesSchedular()
        {
            InitializeComponent();
        }
		
		private void Month_list_ValueChanged(object sender, EventArgs e)
        {
			//берём выбранную дату
            DateTime choice_data = this.dateTimePicker1.Value;
			
			/*
            string queary = String.Format(@"SELECT S.Day, S.Work_time, P.Family, P.Name, P.Otchestvo 
                                                       FROM Doctor_schedular S, Personal P WHERE
                                                       S.Id_user=P.Id AND MONTH(S.Day)='{0}'", num);
			//формируем сообщение серверу
            string message = String.Format("@select;{0};{1};{2};{3}//@",
                                        this.client_name, this.passw, DateTime.Now.ToShortTimeString(),
                                        queary);
            string answer = DoTransfer(message);
            ResultParser(answer);
            */
        }
    }
}
