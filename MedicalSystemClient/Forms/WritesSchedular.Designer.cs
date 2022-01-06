namespace MedicalSystemClient
{
    partial class WritesSchedular
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
            this.find_doctor = new System.Windows.Forms.Button();
            this.schedule = new System.Windows.Forms.TableLayoutPanel();
            this.find_patient = new System.Windows.Forms.Button();
            this.days = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // exitBt
            // 
            this.exitBt.Location = new System.Drawing.Point(713, 550);
            // 
            // find_doctor
            // 
            this.find_doctor.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.find_doctor.Location = new System.Drawing.Point(25, 111);
            this.find_doctor.Name = "find_doctor";
            this.find_doctor.Size = new System.Drawing.Size(147, 32);
            this.find_doctor.TabIndex = 23;
            this.find_doctor.Text = "Найти по врачу";
            this.find_doctor.UseVisualStyleBackColor = true;
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
            this.schedule.Location = new System.Drawing.Point(25, 149);
            this.schedule.Name = "schedule";
            this.schedule.RowCount = 2;
            this.schedule.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.schedule.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.schedule.Size = new System.Drawing.Size(750, 395);
            this.schedule.TabIndex = 22;
            // 
            // find_patient
            // 
            this.find_patient.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.find_patient.Location = new System.Drawing.Point(209, 111);
            this.find_patient.Name = "find_patient";
            this.find_patient.Size = new System.Drawing.Size(177, 32);
            this.find_patient.TabIndex = 25;
            this.find_patient.Text = "Найти по пациенту";
            this.find_patient.UseVisualStyleBackColor = true;
            // 
            // days
            // 
            this.days.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.days.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.days.Location = new System.Drawing.Point(539, 117);
            this.days.Name = "days";
            this.days.Size = new System.Drawing.Size(200, 26);
            this.days.TabIndex = 26;
            this.days.ValueChanged += new System.EventHandler(this.Month_list_ValueChanged);
            // 
            // WritesSchedular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 595);
            this.Controls.Add(this.days);
            this.Controls.Add(this.find_patient);
            this.Controls.Add(this.find_doctor);
            this.Controls.Add(this.schedule);
            this.Name = "WritesSchedular";
            this.Text = "WritesSchedular";
            this.Controls.SetChildIndex(this.timeLb, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.User_view, 0);
            this.Controls.SetChildIndex(this.exitBt, 0);
            this.Controls.SetChildIndex(this.schedule, 0);
            this.Controls.SetChildIndex(this.find_doctor, 0);
            this.Controls.SetChildIndex(this.find_patient, 0);
            this.Controls.SetChildIndex(this.days, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button find_doctor;
        private System.Windows.Forms.TableLayoutPanel schedule;
        private System.Windows.Forms.Button find_patient;
        private System.Windows.Forms.DateTimePicker days;
    }
}