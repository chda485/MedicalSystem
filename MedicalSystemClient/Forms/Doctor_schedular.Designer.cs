namespace MedicalSystemClient
{
    partial class Doctor_schedular
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
            this.schedule = new System.Windows.Forms.TableLayoutPanel();
            this.find_doctor = new System.Windows.Forms.Button();
            this.month_list = new System.Windows.Forms.ComboBox();
            this.doctor_fio = new System.Windows.Forms.TextBox();
            this.clear_Bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitBt
            // 
            this.exitBt.Location = new System.Drawing.Point(713, 557);
            // 
            // schedule
            // 
            this.schedule.AutoScroll = true;
            this.schedule.BackColor = System.Drawing.Color.White;
            this.schedule.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.schedule.ColumnCount = 1;
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.schedule.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.schedule.Location = new System.Drawing.Point(38, 156);
            this.schedule.Name = "schedule";
            this.schedule.RowCount = 2;
            this.schedule.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.schedule.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.schedule.Size = new System.Drawing.Size(750, 395);
            this.schedule.TabIndex = 0;
            // 
            // find_doctor
            // 
            this.find_doctor.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.find_doctor.Location = new System.Drawing.Point(38, 96);
            this.find_doctor.Name = "find_doctor";
            this.find_doctor.Size = new System.Drawing.Size(147, 32);
            this.find_doctor.TabIndex = 20;
            this.find_doctor.Text = "Найти по врачу";
            this.find_doctor.UseVisualStyleBackColor = true;
            this.find_doctor.Click += new System.EventHandler(this.Find_doctor_Click);
            // 
            // month_list
            // 
            this.month_list.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.month_list.FormattingEnabled = true;
            this.month_list.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.month_list.Location = new System.Drawing.Point(649, 115);
            this.month_list.Name = "month_list";
            this.month_list.Size = new System.Drawing.Size(139, 29);
            this.month_list.TabIndex = 21;
            this.month_list.SelectedIndexChanged += new System.EventHandler(this.Month_list_SelectedIndexChanged);
            // 
            // doctor_fio
            // 
            this.doctor_fio.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.doctor_fio.Location = new System.Drawing.Point(204, 96);
            this.doctor_fio.Name = "doctor_fio";
            this.doctor_fio.Size = new System.Drawing.Size(229, 29);
            this.doctor_fio.TabIndex = 22;
            // 
            // clear_Bt
            // 
            this.clear_Bt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clear_Bt.Location = new System.Drawing.Point(439, 96);
            this.clear_Bt.Name = "clear_Bt";
            this.clear_Bt.Size = new System.Drawing.Size(42, 32);
            this.clear_Bt.TabIndex = 23;
            this.clear_Bt.Text = "C";
            this.clear_Bt.UseVisualStyleBackColor = true;
            this.clear_Bt.Click += new System.EventHandler(this.clear_Bt_Click);
            // 
            // Doctor_schedular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 602);
            this.Controls.Add(this.clear_Bt);
            this.Controls.Add(this.doctor_fio);
            this.Controls.Add(this.month_list);
            this.Controls.Add(this.find_doctor);
            this.Controls.Add(this.schedule);
            this.Name = "Doctor_schedular";
            this.Text = "Doctor_schedular";
            this.Controls.SetChildIndex(this.timeLb, 0);
            this.Controls.SetChildIndex(this.schedule, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.User_view, 0);
            this.Controls.SetChildIndex(this.exitBt, 0);
            this.Controls.SetChildIndex(this.find_doctor, 0);
            this.Controls.SetChildIndex(this.month_list, 0);
            this.Controls.SetChildIndex(this.doctor_fio, 0);
            this.Controls.SetChildIndex(this.clear_Bt, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel schedule;
        private System.Windows.Forms.Button find_doctor;
        private System.Windows.Forms.ComboBox month_list;
        private System.Windows.Forms.TextBox doctor_fio;
        private System.Windows.Forms.Button clear_Bt;
    }
}