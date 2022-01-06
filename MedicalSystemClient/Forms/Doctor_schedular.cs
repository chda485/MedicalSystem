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
    public partial class Doctor_schedular : BaseWin
    {
        private Dictionary<string, int> month_days = new Dictionary<string, int>
        {
            {"Январь", 32 }, {"Февраль", 29}, {"Март", 32},
            {"Апрель", 31 }, {"Май", 32}, {"Июнь", 31},
            {"Июль", 32 }, {"Август", 32}, {"Сентябрь", 31},
            {"Октябрь", 32 }, {"Ноябрь", 31}, {"Декабрь", 32}
        };
        public Doctor_schedular(List<string> fio, Socket socket, string name, string passw)
        {
            InitializeComponent();
            this.socket = socket;
            this.user_fio = fio;
            this.client_name = name;
            this.passw = passw;
            this.label1.Text = "Расписание врачей";
			PrepareTable();
            this.month_list.SelectedItem = this.month_list.Items[DateTime.Now.Month - 1];
            this.User_view.Text = "Пользователь:\t" + '\t' + user_fio[0] + ' ' + user_fio[1] + ' ' + user_fio[2];
            this.timer1.Start();
        }
        private int? need_row = null;

        private void Month_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = this.month_list.SelectedIndex + 1;
            string queary = String.Format(@"SELECT S.Day, S.Work_time, P.Family, P.Name, P.Otchestvo 
                                            FROM Doctor_schedular S, Personal P WHERE
                                            S.Id_user=P.Id AND MONTH(S.Day)='{0}'", num);
            string message = String.Format("@select;{0};{1};{2};{3}//@",
                                        this.client_name, this.passw, DateTime.Now.ToShortTimeString(),
                                        queary);
            string answer = DoTransfer(message);
            ResultParser(answer);
        }

        private void ResultParser(string mes)
        {
            //очищаем предыдущие рузультаты
            this.results.Clear();
            //проверяем на пустой список
            this.results = CheckServerAnswer(mes);
			if (this.results.Count == 0)
			{
				MessageBox.Show("Отсутствуют данные по расписанию!");
				return;
			}
			//если в таблице данные по нескольким дням/врачам
            if (results[2].Contains('$'))
            {
				//удаляем последние служебные символы собщения
                string temp = results[2].Substring(0, results[2].Length - 3);
				//разбираем на строки "один день - один врач" 
                List<string> Doctors = temp.Split('$').ToList();
				//получаем число дней месяца
                string month = this.month_list.Items[this.month_list.SelectedIndex].ToString();
                int columns = this.month_days[month];
                //скрываем ненужные столбцы. Если уже нужное число столбцов, ничего не делаем
                int between = this.schedule.ColumnCount - columns;
                if (between > 0)
                {
                    HideColumns(between);
                }
				else if (between < 0)
				{
					ShowColumns(between);
				}
                MessageBox.Show(this.schedule.ColumnCount.ToString());
                //инициализируем список ФИО докторов
                List<string> DocsFIO = new List<string>();
				//перебираем записи по дням
                for (int i = 1; i < columns; i++)
                {
					//берём все записи на конкретный день
                    var OnDay = from write in Doctors
                                where (Convert.ToInt32(
                                    write.Split('|')[0].Split(' ')[0].Split('.')[0]) == i)
                                select write;
                    int ind = 1;
					//перебираем записи по докторам
                    foreach (var write in OnDay)
                    {
						//добавляем данные по графику в соответствующую ячейку
                        string[] w = write.Split('|');
                        Control cell = this.schedule.GetControlFromPosition(i, ind);
                        cell.Text = w[1];
                        ind++;
						//собираем ФИО, и если его нет в списке, добавляем
                        string FIO = w[2] + '\n' + w[3] + '\n' + w[4];
                        if (!DocsFIO.Contains(FIO))
                        {
                            DocsFIO.Add(FIO);
                        }                         
                    }
                }
                int index = 1;
                //перебираем ФИО и добавляем в первый столбец
                foreach (string fio in DocsFIO)
                {
                    Control fio_cell = this.schedule.GetControlFromPosition(0, index);
                    fio_cell.Text = fio;
                    index++;
                }								
            }
			//если есть только одна запись в таблице
			else
			{
				MessageBox.Show("В БД нехватает данных для заполнения расписания");
			}
        }

        private void HideColumns(int hide)
        {
			//устанавливаем необходимое число столбцов
            int column = this.schedule.ColumnCount - hide;
			//перебираем по скрываемым столбцам
            for (int i = column; i < this.schedule.ColumnCount; i++)
            {
				for (int row = 0; row < this.schedule.RowCount; row++)
				{
					Control c = this.schedule.GetControlFromPosition(i, row);
					if (c!=null)
					{
						c.Hide();
					}
				}              
            }
			//меняем число столбцов таблицы
            this.schedule.ColumnCount = column;
        }
		
		private void ShowColumns(int show)
		{
			//необходимое число столбцов
			int need_column = this.schedule.ColumnCount + Math.Abs(show);
			int current_column = this.schedule.ColumnCount;
			//меняем число столбцов таблицы
			this.schedule.ColumnCount = need_column;
			//перебираем по скрытым столбцам
			for (int column = current_column; column < need_column; column++)
			{
				for (int row = 0; row < this.schedule.RowCount; row++)
				{
					Control c = this.schedule.GetControlFromPosition(column, row);
					if (c!=null)
					{
						c.Show();
					}
				}
			}
		}

        private void Find_doctor_Click(object sender, EventArgs e)
        {
			//берём фио доктора из поля и перебираем все имеющиеся ФИО
			string find_fio = this.doctor_fio.Text;
			for (int row = 1; row < this.schedule.RowCount; row++)
			{
				Control c = this.schedule.GetControlFromPosition(0, row);
				if (c.Text.Replace('\n', ' ') == find_fio)
					need_row = row;				
			}
			//если доктор найден по ФИО
			if (need_row != null)
			{
				//выделяем строку с найденным врачом красным и переводим на неё фокус
				for (int column = 0; column < this.schedule.ColumnCount; column++)
				{
					Control c2 = this.schedule.GetControlFromPosition(column, Convert.ToInt32(need_row));
					c2.BackColor = System.Drawing.Color.Red;
				}
				Control c = this.schedule.GetControlFromPosition(0, Convert.ToInt32(need_row));
				c.Select();
			}
			else
				MessageBox.Show("Запрашиваемый вами врач не найден");
        }

        private void PrepareTable()
        {
            this.schedule.ColumnCount = 32;
            this.schedule.RowCount = 11;
            for(int row = 0; row < this.schedule.RowCount; row++)
            {
                for (int column = 0; column < this.schedule.ColumnCount; column++)
                {
                    Label cell = new Label();
                    if (column == 0)
                        cell.Size = new Size(125,75);
                    this.schedule.Controls.Add(cell, column, row);
                }
            }
			//прописываем дни в верхней строке
			for (int day = 1; day < 32; day++)
			{
				Control day_cell = this.schedule.GetControlFromPosition(day, 0);
				day_cell.Text = day.ToString();				
			}
        }

        private void clear_Bt_Click(object sender, EventArgs e)
        {
            if (need_row != null)
            {
                //снимаем выделение
                for (int column = 0; column < this.schedule.ColumnCount; column++)
                {
                    Control c = this.schedule.GetControlFromPosition(column, Convert.ToInt32(need_row));
                    c.BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
}
