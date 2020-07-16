namespace mailDemo
{
    partial class MainForm
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
            this.tbPass = new System.Windows.Forms.TextBox();
            this.lPass = new System.Windows.Forms.Label();
            this.tbMailFrom = new System.Windows.Forms.TextBox();
            this.lMailFrom = new System.Windows.Forms.Label();
            this.rtbMailBody = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbToMail = new System.Windows.Forms.TextBox();
            this.tbTheme = new System.Windows.Forms.TextBox();
            this.lTheme = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.lServer = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSSL = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(81, 54);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(100, 20);
            this.tbPass.TabIndex = 1;
            // 
            // lPass
            // 
            this.lPass.AutoSize = true;
            this.lPass.Location = new System.Drawing.Point(11, 57);
            this.lPass.Name = "lPass";
            this.lPass.Size = new System.Drawing.Size(53, 13);
            this.lPass.TabIndex = 3;
            this.lPass.Text = "Password";
            // 
            // tbMailFrom
            // 
            this.tbMailFrom.Location = new System.Drawing.Point(11, 28);
            this.tbMailFrom.Name = "tbMailFrom";
            this.tbMailFrom.Size = new System.Drawing.Size(170, 20);
            this.tbMailFrom.TabIndex = 4;
            this.tbMailFrom.Text = "marbax@ukr.net";
            // 
            // lMailFrom
            // 
            this.lMailFrom.AutoSize = true;
            this.lMailFrom.Location = new System.Drawing.Point(61, 12);
            this.lMailFrom.Name = "lMailFrom";
            this.lMailFrom.Size = new System.Drawing.Size(52, 13);
            this.lMailFrom.TabIndex = 5;
            this.lMailFrom.Text = "From Mail";
            // 
            // rtbMailBody
            // 
            this.rtbMailBody.Location = new System.Drawing.Point(63, 207);
            this.rtbMailBody.Name = "rtbMailBody";
            this.rtbMailBody.Size = new System.Drawing.Size(415, 231);
            this.rtbMailBody.TabIndex = 6;
            this.rtbMailBody.Text = "test";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "To Mail";
            // 
            // tbToMail
            // 
            this.tbToMail.Location = new System.Drawing.Point(63, 135);
            this.tbToMail.Name = "tbToMail";
            this.tbToMail.Size = new System.Drawing.Size(170, 20);
            this.tbToMail.TabIndex = 7;
            this.tbToMail.Text = "marbax@ukr.net";
            // 
            // tbTheme
            // 
            this.tbTheme.Location = new System.Drawing.Point(64, 171);
            this.tbTheme.Name = "tbTheme";
            this.tbTheme.Size = new System.Drawing.Size(170, 20);
            this.tbTheme.TabIndex = 9;
            this.tbTheme.Text = "test";
            // 
            // lTheme
            // 
            this.lTheme.AutoSize = true;
            this.lTheme.Location = new System.Drawing.Point(13, 174);
            this.lTheme.Name = "lTheme";
            this.lTheme.Size = new System.Drawing.Size(40, 13);
            this.lTheme.TabIndex = 10;
            this.lTheme.Text = "Theme";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(342, 169);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(135, 23);
            this.btnSend.TabIndex = 11;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(220, 29);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(170, 20);
            this.tbServer.TabIndex = 12;
            this.tbServer.Text = "smtp.ukr.net";
            // 
            // lServer
            // 
            this.lServer.AutoSize = true;
            this.lServer.Location = new System.Drawing.Point(279, 9);
            this.lServer.Name = "lServer";
            this.lServer.Size = new System.Drawing.Size(38, 13);
            this.lServer.TabIndex = 13;
            this.lServer.Text = "Server";
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(410, 29);
            this.nudPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(67, 20);
            this.nudPort.TabIndex = 14;
            this.nudPort.Value = new decimal(new int[] {
            465,
            0,
            0,
            0});
            this.nudPort.ValueChanged += new System.EventHandler(this.nudPort_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Port";
            // 
            // cbSSL
            // 
            this.cbSSL.AutoSize = true;
            this.cbSSL.Checked = true;
            this.cbSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSSL.Location = new System.Drawing.Point(423, 57);
            this.cbSSL.Name = "cbSSL";
            this.cbSSL.Size = new System.Drawing.Size(46, 17);
            this.cbSSL.TabIndex = 16;
            this.cbSSL.Text = "SSL";
            this.cbSSL.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Body";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSSL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.lServer);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lTheme);
            this.Controls.Add(this.tbTheme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbToMail);
            this.Controls.Add(this.rtbMailBody);
            this.Controls.Add(this.lMailFrom);
            this.Controls.Add(this.tbMailFrom);
            this.Controls.Add(this.lPass);
            this.Controls.Add(this.tbPass);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label lPass;
        private System.Windows.Forms.TextBox tbMailFrom;
        private System.Windows.Forms.Label lMailFrom;
        private System.Windows.Forms.RichTextBox rtbMailBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbToMail;
        private System.Windows.Forms.TextBox tbTheme;
        private System.Windows.Forms.Label lTheme;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label lServer;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbSSL;
        private System.Windows.Forms.Label label3;
    }
}

