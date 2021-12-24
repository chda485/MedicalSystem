namespace MedicalSystemClient
{
    partial class BaseWin
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
            this.exitBt = new System.Windows.Forms.Button();
            this.User_view = new System.Windows.Forms.TextBox();
            this.timeLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // exitBt
            // 
            this.exitBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitBt.Location = new System.Drawing.Point(710, 499);
            this.exitBt.Name = "exitBt";
            this.exitBt.Size = new System.Drawing.Size(75, 33);
            this.exitBt.TabIndex = 19;
            this.exitBt.Text = "Выход";
            this.exitBt.UseVisualStyleBackColor = true;
            this.exitBt.Click += new System.EventHandler(this.ExitBt_Click);
            // 
            // User_view
            // 
            this.User_view.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.User_view.BackColor = System.Drawing.SystemColors.Control;
            this.User_view.Enabled = false;
            this.User_view.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.User_view.Location = new System.Drawing.Point(539, 47);
            this.User_view.Multiline = true;
            this.User_view.Name = "User_view";
            this.User_view.Size = new System.Drawing.Size(247, 51);
            this.User_view.TabIndex = 18;
            // 
            // timeLb
            // 
            this.timeLb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLb.AutoSize = true;
            this.timeLb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timeLb.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLb.Location = new System.Drawing.Point(695, 9);
            this.timeLb.Name = "timeLb";
            this.timeLb.Size = new System.Drawing.Size(90, 25);
            this.timeLb.TabIndex = 17;
            this.timeLb.Text = "##:##:##";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(256, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "<Текст заголовка>";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // BaseWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 544);
            this.Controls.Add(this.exitBt);
            this.Controls.Add(this.User_view);
            this.Controls.Add(this.timeLb);
            this.Controls.Add(this.label1);
            this.Name = "BaseWin";
            this.Text = "BaseWin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.TextBox User_view;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Timer timer1;
        protected System.Windows.Forms.Button exitBt;
        protected System.Windows.Forms.Label timeLb;
    }
}