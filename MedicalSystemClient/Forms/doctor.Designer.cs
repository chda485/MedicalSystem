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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.schedularBt = new System.Windows.Forms.Button();
            this.visitsBt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitBt
            // 
            this.exitBt.Location = new System.Drawing.Point(739, 379);
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
            // doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.schedularBt);
            this.Controls.Add(this.visitsBt);
            this.Controls.Add(this.textBox1);
            this.Name = "doctor";
            this.Text = "doctor";
            this.Controls.SetChildIndex(this.exitBt, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.visitsBt, 0);
            this.Controls.SetChildIndex(this.schedularBt, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.User_view, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button schedularBt;
        private System.Windows.Forms.Button visitsBt;
        private System.Windows.Forms.Button button1;
    }
}