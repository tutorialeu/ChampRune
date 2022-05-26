
namespace ChampRune
{
    partial class CounterPick
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
            this.cbChamp2 = new System.Windows.Forms.ComboBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.cbChamp1 = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbLain = new System.Windows.Forms.ComboBox();
            this.cbFirst = new System.Windows.Forms.CheckBox();
            this.cbSecond = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkMoreStats = new System.Windows.Forms.LinkLabel();
            this.pbChamp1 = new System.Windows.Forms.PictureBox();
            this.pbChamp2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbChamp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChamp2)).BeginInit();
            this.SuspendLayout();
            // 
            // cbChamp2
            // 
            this.cbChamp2.BackColor = System.Drawing.Color.Black;
            this.cbChamp2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbChamp2.Font = new System.Drawing.Font("Reem Kufi", 9.749999F);
            this.cbChamp2.ForeColor = System.Drawing.Color.White;
            this.cbChamp2.FormattingEnabled = true;
            this.cbChamp2.Location = new System.Drawing.Point(381, 280);
            this.cbChamp2.Name = "cbChamp2";
            this.cbChamp2.Size = new System.Drawing.Size(222, 33);
            this.cbChamp2.TabIndex = 0;
            this.cbChamp2.SelectedIndexChanged += new System.EventHandler(this.cbChamps_SelectedIndexChanged);
            this.cbChamp2.TextChanged += new System.EventHandler(this.cbChamp2_TextChanged);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCheck.Location = new System.Drawing.Point(539, 327);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(112, 33);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbChamp1
            // 
            this.cbChamp1.BackColor = System.Drawing.Color.Black;
            this.cbChamp1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbChamp1.Font = new System.Drawing.Font("Reem Kufi", 9.749999F);
            this.cbChamp1.ForeColor = System.Drawing.Color.White;
            this.cbChamp1.FormattingEnabled = true;
            this.cbChamp1.Location = new System.Drawing.Point(71, 280);
            this.cbChamp1.Name = "cbChamp1";
            this.cbChamp1.Size = new System.Drawing.Size(222, 33);
            this.cbChamp1.TabIndex = 127;
            this.cbChamp1.SelectedIndexChanged += new System.EventHandler(this.cbChamp1_SelectedIndexChanged);
            this.cbChamp1.TextChanged += new System.EventHandler(this.cbChamp1_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(9, 9);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 39);
            this.btnExit.TabIndex = 126;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbLain
            // 
            this.cbLain.BackColor = System.Drawing.Color.Black;
            this.cbLain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbLain.Font = new System.Drawing.Font("Reem Kufi", 9.749999F);
            this.cbLain.ForeColor = System.Drawing.Color.White;
            this.cbLain.FormattingEnabled = true;
            this.cbLain.Items.AddRange(new object[] {
            "top",
            "middle",
            "bottom",
            "jungle",
            "support"});
            this.cbLain.Location = new System.Drawing.Point(299, 280);
            this.cbLain.Name = "cbLain";
            this.cbLain.Size = new System.Drawing.Size(76, 33);
            this.cbLain.TabIndex = 129;
            this.cbLain.SelectedIndexChanged += new System.EventHandler(this.cbLain_SelectedIndexChanged);
            this.cbLain.TextChanged += new System.EventHandler(this.cbLain_TextChanged);
            // 
            // cbFirst
            // 
            this.cbFirst.AutoSize = true;
            this.cbFirst.BackColor = System.Drawing.SystemColors.Control;
            this.cbFirst.Enabled = false;
            this.cbFirst.Font = new System.Drawing.Font("Reem Kufi", 14.25F);
            this.cbFirst.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbFirst.Location = new System.Drawing.Point(108, 78);
            this.cbFirst.Name = "cbFirst";
            this.cbFirst.Size = new System.Drawing.Size(97, 40);
            this.cbFirst.TabIndex = 130;
            this.cbFirst.Text = "Winner";
            this.cbFirst.UseVisualStyleBackColor = false;
            // 
            // cbSecond
            // 
            this.cbSecond.AutoSize = true;
            this.cbSecond.Enabled = false;
            this.cbSecond.Font = new System.Drawing.Font("Reem Kufi", 14.25F);
            this.cbSecond.Location = new System.Drawing.Point(411, 78);
            this.cbSecond.Name = "cbSecond";
            this.cbSecond.Size = new System.Drawing.Size(97, 40);
            this.cbSecond.TabIndex = 131;
            this.cbSecond.Text = "Winner";
            this.cbSecond.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Reem Kufi", 18F);
            this.label1.Location = new System.Drawing.Point(313, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 46);
            this.label1.TabIndex = 132;
            this.label1.Text = "VS";
            // 
            // linkMoreStats
            // 
            this.linkMoreStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkMoreStats.AutoSize = true;
            this.linkMoreStats.BackColor = System.Drawing.Color.White;
            this.linkMoreStats.Font = new System.Drawing.Font("Reem Kufi", 9.749999F);
            this.linkMoreStats.Location = new System.Drawing.Point(12, 335);
            this.linkMoreStats.Name = "linkMoreStats";
            this.linkMoreStats.Size = new System.Drawing.Size(250, 25);
            this.linkMoreStats.TabIndex = 133;
            this.linkMoreStats.TabStop = true;
            this.linkMoreStats.Text = "click here to see more stats in your browser";
            this.linkMoreStats.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMoreStats_LinkClicked);
            // 
            // pbChamp1
            // 
            this.pbChamp1.BackColor = System.Drawing.Color.Black;
            this.pbChamp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbChamp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbChamp1.ErrorImage = null;
            this.pbChamp1.Location = new System.Drawing.Point(108, 124);
            this.pbChamp1.Name = "pbChamp1";
            this.pbChamp1.Size = new System.Drawing.Size(150, 150);
            this.pbChamp1.TabIndex = 204;
            this.pbChamp1.TabStop = false;
            this.pbChamp1.WaitOnLoad = true;
            this.pbChamp1.Paint += new System.Windows.Forms.PaintEventHandler(this.pbChamp1_Paint);
            // 
            // pbChamp2
            // 
            this.pbChamp2.BackColor = System.Drawing.Color.Black;
            this.pbChamp2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbChamp2.ErrorImage = null;
            this.pbChamp2.Location = new System.Drawing.Point(411, 124);
            this.pbChamp2.Name = "pbChamp2";
            this.pbChamp2.Size = new System.Drawing.Size(150, 150);
            this.pbChamp2.TabIndex = 205;
            this.pbChamp2.TabStop = false;
            this.pbChamp2.WaitOnLoad = true;
            this.pbChamp2.Paint += new System.Windows.Forms.PaintEventHandler(this.pbChamp2_Paint);
            // 
            // CounterPick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChampRune.Properties.Resources.yasuo_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(663, 372);
            this.ControlBox = false;
            this.Controls.Add(this.pbChamp2);
            this.Controls.Add(this.pbChamp1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSecond);
            this.Controls.Add(this.cbFirst);
            this.Controls.Add(this.cbLain);
            this.Controls.Add(this.cbChamp2);
            this.Controls.Add(this.cbChamp1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.linkMoreStats);
            this.KeyPreview = true;
            this.Name = "CounterPick";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.ThemeSelector_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ThemeSelector_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbChamp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChamp2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCheck;
        public System.Windows.Forms.ComboBox cbChamp2;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.ComboBox cbChamp1;
        public System.Windows.Forms.ComboBox cbLain;
        public System.Windows.Forms.CheckBox cbFirst;
        public System.Windows.Forms.CheckBox cbSecond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkMoreStats;
        private System.Windows.Forms.PictureBox pbChamp1;
        private System.Windows.Forms.PictureBox pbChamp2;
    }
}