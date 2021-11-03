namespace MedicalSystemClient
{
    partial class doctor
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
            this.User_view = new System.Windows.Forms.TextBox();
            this.timeLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exitBt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.schedularBt = new System.Windows.Forms.Button();
            this.visitsBt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // User_view
            // 
            this.User_view.BackColor = System.Drawing.SystemColors.Control;
            this.User_view.Enabled = false;
            this.User_view.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.User_view.Location = new System.Drawing.Point(352, 48);
            this.User_view.Multiline = true;
            this.User_view.Name = "User_view";
            this.User_view.Size = new System.Drawing.Size(247, 51);
            this.User_view.TabIndex = 8;
            // 
            // timeLb
            // 
            this.timeLb.AutoSize = true;
            this.timeLb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timeLb.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLb.Location = new System.Drawing.Point(498, 15);
            this.timeLb.Name = "timeLb";
            this.timeLb.Size = new System.Drawing.Size(90, 25);
            this.timeLb.TabIndex = 7;
            this.timeLb.Text = "##:##:##";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(171, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Раздел врача";
            // 
            // exitBt
            // 
            this.exitBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitBt.Location = new System.Drawing.Point(508, 312);
            this.exitBt.Name = "exitBt";
            this.exitBt.Size = new System.Drawing.Size(75, 33);
            this.exitBt.TabIndex = 11;
            this.exitBt.Text = "Выход";
            this.exitBt.UseVisualStyleBackColor = true;
            this.exitBt.Click += new System.EventHandler(this.ExitBt_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Location = new System.Drawing.Point(12, 115);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(587, 2);
            this.textBox1.TabIndex = 12;
            // 
            // schedularBt
            // 
            this.schedularBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.schedularBt.Location = new System.Drawing.Point(460, 164);
            this.schedularBt.Name = "schedularBt";
            this.schedularBt.Size = new System.Drawing.Size(123, 71);
            this.schedularBt.TabIndex = 15;
            this.schedularBt.Text = "Моё расписание";
            this.schedularBt.UseVisualStyleBackColor = true;
            // 
            // visitsBt
            // 
            this.visitsBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.visitsBt.Location = new System.Drawing.Point(56, 164);
            this.visitsBt.Name = "visitsBt";
            this.visitsBt.Size = new System.Drawing.Size(125, 71);
            this.visitsBt.TabIndex = 14;
            this.visitsBt.Text = "Записи на прием";
            this.visitsBt.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(267, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 71);
            this.button1.TabIndex = 16;
            this.button1.Text = "Открыть карту пациента";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 359);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.schedularBt);
            this.Controls.Add(this.visitsBt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.exitBt);
            this.Controls.Add(this.User_view);
            this.Controls.Add(this.timeLb);
            this.Controls.Add(this.label1);
            this.Name = "doctor";
            this.Text = "doctor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox User_view;
        private System.Windows.Forms.Label timeLb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitBt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button schedularBt;
        private System.Windows.Forms.Button visitsBt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}