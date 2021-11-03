namespace MedicalSystemClient
{
    partial class registratura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timeLb = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.User_view = new System.Windows.Forms.TextBox();
            this.findBt = new System.Windows.Forms.Button();
            this.prevBt = new System.Windows.Forms.Button();
            this.nextBt = new System.Windows.Forms.Button();
            this.clearBt = new System.Windows.Forms.Button();
            this.exitBt = new System.Windows.Forms.Button();
            this.visitsBt = new System.Windows.Forms.Button();
            this.schedularBt = new System.Windows.Forms.Button();
            this.changeBt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.family = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.borning_date = new System.Windows.Forms.TextBox();
            this.snils = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.Ser_passport = new System.Windows.Forms.TextBox();
            this.Num_passport = new System.Windows.Forms.TextBox();
            this.otchestvo = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Area = new System.Windows.Forms.TextBox();
            this.Work = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Num_polis = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.writeBt = new System.Windows.Forms.Button();
            this.seeWritesBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(283, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистратура";
            // 
            // timeLb
            // 
            this.timeLb.AutoSize = true;
            this.timeLb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timeLb.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLb.Location = new System.Drawing.Point(687, 15);
            this.timeLb.Name = "timeLb";
            this.timeLb.Size = new System.Drawing.Size(90, 25);
            this.timeLb.TabIndex = 2;
            this.timeLb.Text = "##:##:##";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Location = new System.Drawing.Point(12, 116);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(765, 2);
            this.textBox1.TabIndex = 4;
            // 
            // User_view
            // 
            this.User_view.BackColor = System.Drawing.SystemColors.Control;
            this.User_view.Enabled = false;
            this.User_view.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.User_view.Location = new System.Drawing.Point(541, 48);
            this.User_view.Multiline = true;
            this.User_view.Name = "User_view";
            this.User_view.Size = new System.Drawing.Size(247, 51);
            this.User_view.TabIndex = 5;
            // 
            // findBt
            // 
            this.findBt.Location = new System.Drawing.Point(35, 64);
            this.findBt.Name = "findBt";
            this.findBt.Size = new System.Drawing.Size(35, 35);
            this.findBt.TabIndex = 6;
            this.findBt.Text = "F";
            this.findBt.UseVisualStyleBackColor = true;
            this.findBt.Click += new System.EventHandler(this.findBt_click);
            // 
            // prevBt
            // 
            this.prevBt.Location = new System.Drawing.Point(94, 64);
            this.prevBt.Name = "prevBt";
            this.prevBt.Size = new System.Drawing.Size(35, 35);
            this.prevBt.TabIndex = 7;
            this.prevBt.Text = "P";
            this.prevBt.UseVisualStyleBackColor = true;
            this.prevBt.Click += new System.EventHandler(this.prevBt_click);
            // 
            // nextBt
            // 
            this.nextBt.Location = new System.Drawing.Point(154, 64);
            this.nextBt.Name = "nextBt";
            this.nextBt.Size = new System.Drawing.Size(37, 35);
            this.nextBt.TabIndex = 8;
            this.nextBt.Text = "N";
            this.nextBt.UseVisualStyleBackColor = true;
            this.nextBt.Click += new System.EventHandler(this.nextBt_click);
            // 
            // clearBt
            // 
            this.clearBt.Location = new System.Drawing.Point(212, 64);
            this.clearBt.Name = "clearBt";
            this.clearBt.Size = new System.Drawing.Size(34, 35);
            this.clearBt.TabIndex = 9;
            this.clearBt.Text = "C";
            this.clearBt.UseVisualStyleBackColor = true;
            this.clearBt.Click += new System.EventHandler(this.clearBt_click);
            // 
            // exitBt
            // 
            this.exitBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitBt.Location = new System.Drawing.Point(702, 528);
            this.exitBt.Name = "exitBt";
            this.exitBt.Size = new System.Drawing.Size(75, 33);
            this.exitBt.TabIndex = 10;
            this.exitBt.Text = "Выход";
            this.exitBt.UseVisualStyleBackColor = true;
            this.exitBt.Click += new System.EventHandler(this.ExitBt_Click);
            // 
            // visitsBt
            // 
            this.visitsBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.visitsBt.Location = new System.Drawing.Point(527, 330);
            this.visitsBt.Name = "visitsBt";
            this.visitsBt.Size = new System.Drawing.Size(125, 58);
            this.visitsBt.TabIndex = 12;
            this.visitsBt.Text = "Посмотреть посещения";
            this.visitsBt.UseVisualStyleBackColor = true;
            // 
            // schedularBt
            // 
            this.schedularBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.schedularBt.Location = new System.Drawing.Point(527, 422);
            this.schedularBt.Name = "schedularBt";
            this.schedularBt.Size = new System.Drawing.Size(123, 53);
            this.schedularBt.TabIndex = 13;
            this.schedularBt.Text = "Расписание врачей";
            this.schedularBt.UseVisualStyleBackColor = true;
            // 
            // changeBt
            // 
            this.changeBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeBt.Location = new System.Drawing.Point(527, 498);
            this.changeBt.Name = "changeBt";
            this.changeBt.Size = new System.Drawing.Size(123, 56);
            this.changeBt.TabIndex = 14;
            this.changeBt.Text = "Изменить данные";
            this.changeBt.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(28, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(28, 470);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Телефон";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(28, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 21);
            this.label6.TabIndex = 18;
            this.label6.Text = "СНИЛС";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(28, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Паспорт серия";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(28, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 21);
            this.label8.TabIndex = 20;
            this.label8.Text = "Отчество";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(28, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 21);
            this.label9.TabIndex = 21;
            this.label9.Text = "Имя";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(28, 435);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 21);
            this.label10.TabIndex = 22;
            this.label10.Text = "Дата рождения";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(28, 332);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 21);
            this.label11.TabIndex = 23;
            this.label11.Text = "Адрес";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(28, 257);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 21);
            this.label12.TabIndex = 24;
            this.label12.Text = "Паспорт №";
            // 
            // family
            // 
            this.family.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.family.Location = new System.Drawing.Point(167, 138);
            this.family.Name = "family";
            this.family.Size = new System.Drawing.Size(166, 29);
            this.family.TabIndex = 1;
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone.Location = new System.Drawing.Point(167, 467);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(166, 29);
            this.phone.TabIndex = 9;
            // 
            // borning_date
            // 
            this.borning_date.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.borning_date.Location = new System.Drawing.Point(167, 432);
            this.borning_date.Name = "borning_date";
            this.borning_date.Size = new System.Drawing.Size(166, 29);
            this.borning_date.TabIndex = 8;
            // 
            // snils
            // 
            this.snils.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.snils.Location = new System.Drawing.Point(167, 364);
            this.snils.Name = "snils";
            this.snils.Size = new System.Drawing.Size(166, 29);
            this.snils.TabIndex = 7;
            // 
            // address
            // 
            this.address.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.address.Location = new System.Drawing.Point(167, 329);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(166, 29);
            this.address.TabIndex = 6;
            // 
            // Ser_passport
            // 
            this.Ser_passport.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ser_passport.Location = new System.Drawing.Point(167, 294);
            this.Ser_passport.Name = "Ser_passport";
            this.Ser_passport.Size = new System.Drawing.Size(166, 29);
            this.Ser_passport.TabIndex = 5;
            // 
            // Num_passport
            // 
            this.Num_passport.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Num_passport.Location = new System.Drawing.Point(167, 254);
            this.Num_passport.Name = "Num_passport";
            this.Num_passport.Size = new System.Drawing.Size(166, 29);
            this.Num_passport.TabIndex = 4;
            // 
            // otchestvo
            // 
            this.otchestvo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otchestvo.Location = new System.Drawing.Point(167, 216);
            this.otchestvo.Name = "otchestvo";
            this.otchestvo.Size = new System.Drawing.Size(166, 29);
            this.otchestvo.TabIndex = 3;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name.Location = new System.Drawing.Point(167, 176);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(166, 29);
            this.name.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(28, 505);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "№ округа";
            // 
            // Area
            // 
            this.Area.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Area.Location = new System.Drawing.Point(167, 502);
            this.Area.Name = "Area";
            this.Area.Size = new System.Drawing.Size(166, 29);
            this.Area.TabIndex = 10;
            // 
            // Work
            // 
            this.Work.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Work.Location = new System.Drawing.Point(167, 537);
            this.Work.Name = "Work";
            this.Work.Size = new System.Drawing.Size(166, 29);
            this.Work.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(28, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Занятость";
            // 
            // Num_polis
            // 
            this.Num_polis.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Num_polis.Location = new System.Drawing.Point(167, 400);
            this.Num_polis.Name = "Num_polis";
            this.Num_polis.Size = new System.Drawing.Size(166, 29);
            this.Num_polis.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(28, 403);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 21);
            this.label13.TabIndex = 37;
            this.label13.Text = "Полис";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // writeBt
            // 
            this.writeBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.writeBt.Location = new System.Drawing.Point(527, 151);
            this.writeBt.Name = "writeBt";
            this.writeBt.Size = new System.Drawing.Size(123, 54);
            this.writeBt.TabIndex = 11;
            this.writeBt.Text = "Записать на прием";
            this.writeBt.UseVisualStyleBackColor = true;
            // 
            // seeWritesBt
            // 
            this.seeWritesBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seeWritesBt.Location = new System.Drawing.Point(527, 240);
            this.seeWritesBt.Name = "seeWritesBt";
            this.seeWritesBt.Size = new System.Drawing.Size(123, 54);
            this.seeWritesBt.TabIndex = 38;
            this.seeWritesBt.Text = "Посмотреть записи";
            this.seeWritesBt.UseVisualStyleBackColor = true;
            // 
            // registratura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.seeWritesBt);
            this.Controls.Add(this.Num_polis);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Work);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name);
            this.Controls.Add(this.otchestvo);
            this.Controls.Add(this.Num_passport);
            this.Controls.Add(this.Ser_passport);
            this.Controls.Add(this.address);
            this.Controls.Add(this.snils);
            this.Controls.Add(this.borning_date);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.Area);
            this.Controls.Add(this.family);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.changeBt);
            this.Controls.Add(this.schedularBt);
            this.Controls.Add(this.visitsBt);
            this.Controls.Add(this.writeBt);
            this.Controls.Add(this.exitBt);
            this.Controls.Add(this.clearBt);
            this.Controls.Add(this.nextBt);
            this.Controls.Add(this.prevBt);
            this.Controls.Add(this.findBt);
            this.Controls.Add(this.User_view);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.timeLb);
            this.Controls.Add(this.label1);
            this.Name = "registratura";
            this.Text = "Окно регистратуры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeLb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox User_view;
        private System.Windows.Forms.Button findBt;
        private System.Windows.Forms.Button prevBt;
        private System.Windows.Forms.Button nextBt;
        private System.Windows.Forms.Button clearBt;
        private System.Windows.Forms.Button exitBt;
        private System.Windows.Forms.Button visitsBt;
        private System.Windows.Forms.Button schedularBt;
        private System.Windows.Forms.Button changeBt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox family;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox borning_date;
        private System.Windows.Forms.TextBox snils;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.TextBox Ser_passport;
        private System.Windows.Forms.TextBox Num_passport;
        private System.Windows.Forms.TextBox otchestvo;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Area;
        private System.Windows.Forms.TextBox Work;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Num_polis;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button writeBt;
        private System.Windows.Forms.Button seeWritesBt;
    }
}