namespace WinFormMarvel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.flpCharacters = new System.Windows.Forms.FlowLayoutPanel();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.nudLimit = new System.Windows.Forms.NumericUpDown();
            this.lOffset = new System.Windows.Forms.Label();
            this.lLimit = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lLimit);
            this.panel1.Controls.Add(this.lOffset);
            this.panel1.Controls.Add(this.nudLimit);
            this.panel1.Controls.Add(this.nudOffset);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoad.Location = new System.Drawing.Point(0, 0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(110, 32);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // flpCharacters
            // 
            this.flpCharacters.AutoScroll = true;
            this.flpCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCharacters.Location = new System.Drawing.Point(0, 32);
            this.flpCharacters.Name = "flpCharacters";
            this.flpCharacters.Size = new System.Drawing.Size(800, 418);
            this.flpCharacters.TabIndex = 2;
            // 
            // nudOffset
            // 
            this.nudOffset.Location = new System.Drawing.Point(155, 6);
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.Size = new System.Drawing.Size(94, 20);
            this.nudOffset.TabIndex = 1;
            // 
            // nudLimit
            // 
            this.nudLimit.Location = new System.Drawing.Point(296, 6);
            this.nudLimit.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLimit.Name = "nudLimit";
            this.nudLimit.Size = new System.Drawing.Size(62, 20);
            this.nudLimit.TabIndex = 2;
            this.nudLimit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lOffset
            // 
            this.lOffset.AutoSize = true;
            this.lOffset.Location = new System.Drawing.Point(116, 9);
            this.lOffset.Name = "lOffset";
            this.lOffset.Size = new System.Drawing.Size(35, 13);
            this.lOffset.TabIndex = 3;
            this.lOffset.Text = "Offset";
            // 
            // lLimit
            // 
            this.lLimit.AutoSize = true;
            this.lLimit.Location = new System.Drawing.Point(263, 10);
            this.lLimit.Name = "lLimit";
            this.lLimit.Size = new System.Drawing.Size(28, 13);
            this.lLimit.TabIndex = 4;
            this.lLimit.Text = "Limit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpCharacters);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Marvel Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.FlowLayoutPanel flpCharacters;
        private System.Windows.Forms.Label lLimit;
        private System.Windows.Forms.Label lOffset;
        private System.Windows.Forms.NumericUpDown nudLimit;
        private System.Windows.Forms.NumericUpDown nudOffset;
    }
}

