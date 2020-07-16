namespace SWAPI_App
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
            this.mrBtnLoad = new MaterialSkin.Controls.MaterialRaisedButton();
            this.mCBSaveJson = new MaterialSkin.Controls.MaterialCheckBox();
            this.flPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // mrBtnLoad
            // 
            this.mrBtnLoad.Depth = 0;
            this.mrBtnLoad.Location = new System.Drawing.Point(12, 70);
            this.mrBtnLoad.MouseState = MaterialSkin.MouseState.HOVER;
            this.mrBtnLoad.Name = "mrBtnLoad";
            this.mrBtnLoad.Primary = true;
            this.mrBtnLoad.Size = new System.Drawing.Size(163, 40);
            this.mrBtnLoad.TabIndex = 1;
            this.mrBtnLoad.Text = "Load Characters";
            this.mrBtnLoad.UseVisualStyleBackColor = true;
            this.mrBtnLoad.Click += new System.EventHandler(this.mrBtnLoad_Click);
            // 
            // mCBSaveJson
            // 
            this.mCBSaveJson.AutoSize = true;
            this.mCBSaveJson.BackColor = System.Drawing.Color.Black;
            this.mCBSaveJson.Depth = 0;
            this.mCBSaveJson.Font = new System.Drawing.Font("Roboto", 10F);
            this.mCBSaveJson.Location = new System.Drawing.Point(193, 76);
            this.mCBSaveJson.Margin = new System.Windows.Forms.Padding(0);
            this.mCBSaveJson.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mCBSaveJson.MouseState = MaterialSkin.MouseState.HOVER;
            this.mCBSaveJson.Name = "mCBSaveJson";
            this.mCBSaveJson.Ripple = true;
            this.mCBSaveJson.Size = new System.Drawing.Size(123, 30);
            this.mCBSaveJson.TabIndex = 4;
            this.mCBSaveJson.Text = "Save Raw Json";
            this.mCBSaveJson.UseVisualStyleBackColor = false;
            // 
            // flPanel
            // 
            this.flPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flPanel.AutoScroll = true;
            this.flPanel.Location = new System.Drawing.Point(5, 116);
            this.flPanel.Name = "flPanel";
            this.flPanel.Size = new System.Drawing.Size(790, 328);
            this.flPanel.TabIndex = 5;
            // 
            // nudOffset
            // 
            this.nudOffset.Location = new System.Drawing.Point(430, 82);
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.Size = new System.Drawing.Size(47, 20);
            this.nudOffset.TabIndex = 7;
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(550, 82);
            this.nudCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(47, 20);
            this.nudCount.TabIndex = 8;
            this.nudCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(370, 82);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(54, 19);
            this.materialLabel1.TabIndex = 9;
            this.materialLabel1.Text = "Offset:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(483, 83);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(53, 19);
            this.materialLabel2.TabIndex = 10;
            this.materialLabel2.Text = "Count:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.nudOffset);
            this.Controls.Add(this.flPanel);
            this.Controls.Add(this.mCBSaveJson);
            this.Controls.Add(this.mrBtnLoad);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "MainForm";
            this.Text = "Star Wars Seacrha";
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton mrBtnLoad;
        private MaterialSkin.Controls.MaterialCheckBox mCBSaveJson;
        private System.Windows.Forms.FlowLayoutPanel flPanel;
        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.Windows.Forms.NumericUpDown nudCount;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}

