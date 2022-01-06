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
        protected Socket socket;
        protected string client_name; //локальное имя данной клиентской машины
        protected string passw; //локальный пароль данной клиентской машины
        protected byte[] data; //буфер данных для чтения и отправки
        protected List<string> user_fio = new List<string>(); //список ФИО пользователя
        protected StringBuilder builder = new StringBuilder(); //конструктор строк сообщений
        protected List<string> results = new List<string>(); //список результатов запроса к БД

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

        protected string DoTransfer(string message)
        {
            data = Encoding.Unicode.GetBytes(message);
            //отправляем сообщение серверу
            socket.Send(data);

            data = new byte[256];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            //пока есть данные, читаем их
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            //преобразуем все ответы в строковый вид
            string answer = builder.ToString();
            return answer;
        }

        protected List<string> CheckServerAnswer(string mes, bool writes=false)
        {
            //если сообщение имеет неправильный формат
            if (!mes.StartsWith("@") && !mes.EndsWith("//@"))
            {
                MessageBox.Show("Ошибка связи с сервером. Неверный формат сообщения");
                return new List<string>();
            }
            results = mes.Split(';').ToList();
            //если сервер прислал не тому клиенту
            if (!results[1].Equals(this.client_name))
            {
                MessageBox.Show("Ошибка связи с сервером");
                return new List<string>();
            }
            if (results[2] == "в БД отсутствуют данные по вашему запросу")
            {
                if (writes == true)
                    return new List<string>();
                else
                {
                    MessageBox.Show("В БД отсутствуют данные по вашему запросу");
                    return new List<string>();
                }
            }
            return results;
        }
    }
}
