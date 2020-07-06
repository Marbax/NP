namespace WFView
{
    partial class Form1
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
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.tbAdress = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnFormat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnEstSyncTcpConn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbOutput.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(964, 582);
            this.rtbOutput.TabIndex = 0;
            this.rtbOutput.Text = "";
            // 
            // tbAdress
            // 
            this.tbAdress.Location = new System.Drawing.Point(10, 44);
            this.tbAdress.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbAdress.Name = "tbAdress";
            this.tbAdress.Size = new System.Drawing.Size(552, 31);
            this.tbAdress.TabIndex = 1;
            this.tbAdress.Text = "google.com";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(32, 98);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(131, 34);
            this.btnParse.TabIndex = 2;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(190, 98);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(122, 34);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "URL";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(339, 98);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(131, 34);
            this.btnScan.TabIndex = 6;
            this.btnScan.Text = "Scan ports";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(32, 156);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(131, 34);
            this.btnGet.TabIndex = 7;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(190, 156);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(131, 34);
            this.btnFormat.TabIndex = 8;
            this.btnFormat.Text = "Format it";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnEstSyncTcpConn);
            this.panel1.Controls.Add(this.btnScan);
            this.panel1.Controls.Add(this.btnFormat);
            this.panel1.Controls.Add(this.tbAdress);
            this.panel1.Controls.Add(this.btnGet);
            this.panel1.Controls.Add(this.btnParse);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 582);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbOutput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(568, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 582);
            this.panel2.TabIndex = 10;
            // 
            // BtnEstSyncTcpConn
            // 
            this.BtnEstSyncTcpConn.Location = new System.Drawing.Point(12, 536);
            this.BtnEstSyncTcpConn.Name = "BtnEstSyncTcpConn";
            this.BtnEstSyncTcpConn.Size = new System.Drawing.Size(191, 34);
            this.BtnEstSyncTcpConn.TabIndex = 9;
            this.BtnEstSyncTcpConn.Text = "Est sync tcp conn";
            this.BtnEstSyncTcpConn.UseVisualStyleBackColor = true;
            this.BtnEstSyncTcpConn.Click += new System.EventHandler(this.BtnEstSyncTcpConn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 582);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.TextBox tbAdress;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnEstSyncTcpConn;
    }
}

