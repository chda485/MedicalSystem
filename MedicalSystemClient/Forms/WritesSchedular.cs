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
    public partial class WritesSchedular : BaseWin
    {
        private List<string> times = new List<string>
        {
            "08:00 - 09:00", "09:00 - 10:00", "10:00 - 11:00",
            "11:00 - 12:00", "12:00 - 13:00", "13:00 - 14:00",
            "14:00 - 15:00", "15:00 - 16:00", "16:00 - 17:00",
            "17:00 - 18:00", "18:00 - 19:00", "19:00 - 20:00"
        };
        public WritesSchedular(List<string> fio, Socket socket, string name, string passw)
        {
            InitializeComponent();
            this.socket = socket;
            this.user_fio = fio;
            this.client_name = name;
            this.passw = passw;
            this.label1.Text = "Расписание записей";
            PrepareTable();
            this.days.Value = DateTime.Now;
            this.User_view.Text = "Пользователь:\t" + '\t' + user_fio[0] + ' ' + user_fio[1] + ' ' + user_fio[2];
            this.timer1.Start();
        }
		
		private void Month_list_ValueChanged(object sender, EventArgs e)
        {
            string new_date = days.Value.ToString("yyyy-MM-dd");
            string queary1 = String.Format(@"SELECT Pe.Family, Pe.Name, Pe.Otchestvo,
                                            Pa.Family, Pa.Name, Pa.Otchestvo, W.Time
                                            FROM Personal Pe, Patients Pa, Writes W
                                            WHERE W.Day = '{0}'
                                            AND Pe.Id = W.Id_doctor
                                            AND Pa.Id = W.Id_patient", new_date);
            string message1 = String.Format("@select;{0};{1};{2};{3}//@",
                                            this.client_name, this.passw,
                                            DateTime.Now.ToShortTimeString(), queary1);
            string answer = DoTransfer(message1);
            InsertDoctorsFIO(new_date);
            MessageBox.Show(answer);
            //InsertValues(answer);
        }
        private void PrepareTable()
        {
            this.schedule.ColumnCount = 13;
            this.schedule.RowCount = 11;
            for (int row = 0; row < this.schedule.RowCount; row++)
            {
                for (int column = 0; column < this.schedule.ColumnCount; column++)
                {
                    Label cell = new Label();
                    if (column == 0)
                        cell.Size = new Size(125, 75);
                    this.schedule.Controls.Add(cell, column, row);
                }
            }
            
            //прописываем время в верхней строке
            for (int i = 1; i < 13; i++)
            {
                Control time_cell = this.schedule.GetControlFromPosition(i, 0);
                time_cell.Text = times[i-1];
            }
        }

        private void InsertDoctorsFIO(string new_date)
        {
            string queary2 = String.Format(@"SELECT Family, Personal.Name, Otchestvo FROM Personal
                                                WHERE Work_with <= '{0}'
                                                AND Category <> 'Registratura'
                                                ORDER BY Family, Personal.Name", new_date);
            string message2 = String.Format("@select;{0};{1};{2};{3}//@",
                                        this.client_name, this.passw, DateTime.Now.ToShortTimeString(),
                                        queary2);
            string answer = DoTransfer(message2);
            //очищаем предыдущие рузультаты
            this.results.Clear();
            //проверяем на пустой список
            this.results = CheckServerAnswer(answer);
            if (this.results.Count == 0)
            {
                MessageBox.Show("Ошибка! На данную дату не найденого ни одного работающего доктора!");
                return;
            }
            //удаляем последние служебные символы собщения
            string temp = results[2].Substring(0, results[2].Length - 3);
            //разбираем на строки "один день - один врач" 
            List<string> FIO = temp.Split('$').ToList();
            for(int i = 1; i < this.schedule.RowCount; i++ )
            {
                Control cell = this.schedule.GetControlFromPosition(0, i);
                cell.Text = FIO[i - 1].Replace('|', '\n');
            }
        }

        private void InsertValues(string answer)
        {
            //очищаем предыдущие рузультаты
            this.results.Clear();
            //проверяем на пустой список
            this.results = CheckServerAnswer(answer, true);
            //если пусто, на эту дату нет записей
            if (this.results.Count == 0)
            {
                return;
            }
            //удаляем последние служебные символы собщения
            string temp = results[2].Substring(0, results[2].Length - 3);
            List<string> writes = temp.Split('$').ToList();
            //перебираем по всем врачам из расписания
            for(int i = 1; i < this.schedule.RowCount; i++)
            {
                Control cell = this.schedule.GetControlFromPosition(0, i);
                string FIO = cell.Text.Replace('\n', ' ');
                //перебираем полученные на дату записи
                foreach(string write in writes)
                {
                    //имя доктора из записи
                    string Doctor = write.Split('|')[0] + ' ' +
                        write.Split('|')[1] + ' ' + write.Split('|')[2];
                    //если не совпадают ФИО доктора списка и записи
                    if (FIO != Doctor)
                        continue;
                    //если совпадают
                    string Patient = write.Split('|')[3] + '\n' +
                        write.Split('|')[4] + '\n' + write.Split('|')[5];
                    string Time = write.Split('|')[6];
                    //берём индекс столбца времени записи (+1 так как 0 столбец ФИО)
                    int column = times.IndexOf(Time) + 1;
                    Control c = this.schedule.GetControlFromPosition(column, i);
                    c.Text = Patient;
                }
            }
        }
    }
}
