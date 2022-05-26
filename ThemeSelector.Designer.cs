
namespace ChampRune
{
    partial class ThemeSelector
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
            this.cbChamps = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.pnImages = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbChamps
            // 
            this.cbChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbChamps.BackColor = System.Drawing.Color.Black;
            this.cbChamps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbChamps.Font = new System.Drawing.Font("Reem Kufi", 9.749999F);
            this.cbChamps.ForeColor = System.Drawing.Color.White;
            this.cbChamps.FormattingEnabled = true;
            this.cbChamps.Location = new System.Drawing.Point(526, 9);
            this.cbChamps.Name = "cbChamps";
            this.cbChamps.Size = new System.Drawing.Size(222, 33);
            this.cbChamps.TabIndex = 0;
            this.cbChamps.SelectedIndexChanged += new System.EventHandler(this.cbChamps_SelectedIndexChanged);
            this.cbChamps.TextChanged += new System.EventHandler(this.cbChamps_TextChanged);
            this.cbChamps.Enter += new System.EventHandler(this.cbChamps_Enter);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnApply.Location = new System.Drawing.Point(652, 282);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(96, 33);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Set Theme";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pnImages
            // 
            this.pnImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnImages.AutoScroll = true;
            this.pnImages.BackColor = System.Drawing.Color.Transparent;
            this.pnImages.Location = new System.Drawing.Point(9, 54);
            this.pnImages.Name = "pnImages";
            this.pnImages.Size = new System.Drawing.Size(739, 222);
            this.pnImages.TabIndex = 3;
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
            // ThemeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ChampRune.Properties.Resources.yasuo_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(763, 324);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnImages);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbChamps);
            this.KeyPreview = true;
            this.Name = "ThemeSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.ThemeSelector_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ThemeSelector_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnApply;
        public System.Windows.Forms.ComboBox cbChamps;
        private System.Windows.Forms.Panel pnImages;
        private System.Windows.Forms.Button btnExit;
    }
}