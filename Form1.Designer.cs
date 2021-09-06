
namespace ChampRune
{
    partial class frmMain
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSup = new System.Windows.Forms.Button();
            this.btnJun = new System.Windows.Forms.Button();
            this.btnAdc = new System.Windows.Forms.Button();
            this.btnMid = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.tcPages = new System.Windows.Forms.TabControl();
            this.tpChamp = new System.Windows.Forms.TabPage();
            this.tpRune = new System.Windows.Forms.TabPage();
            this.tcRuneLain = new System.Windows.Forms.TabControl();
            this.tpItems = new System.Windows.Forms.TabPage();
            this.tcItems = new System.Windows.Forms.TabControl();
            this.cbPatch = new System.Windows.Forms.ComboBox();
            this.lblPatck = new System.Windows.Forms.Label();
            this.nudStack = new System.Windows.Forms.NumericUpDown();
            this.lblStack = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.llLinks = new System.Windows.Forms.LinkLabel();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.wbSearches = new System.Windows.Forms.WebBrowser();
            this.tcPages.SuspendLayout();
            this.tpRune.SuspendLayout();
            this.tpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(12, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(64, 20);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            this.lblSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(82, 8);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(122, 20);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAll.BackgroundImage = global::ChampRune.Properties.Resources.all_full_trans;
            this.btnAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAll.Location = new System.Drawing.Point(12, 35);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(50, 50);
            this.btnAll.TabIndex = 8;
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            this.btnAll.MouseHover += new System.EventHandler(this.btnAll_MouseHover);
            // 
            // btnSup
            // 
            this.btnSup.BackgroundImage = global::ChampRune.Properties.Resources.sup;
            this.btnSup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSup.Location = new System.Drawing.Point(292, 35);
            this.btnSup.Name = "btnSup";
            this.btnSup.Size = new System.Drawing.Size(50, 50);
            this.btnSup.TabIndex = 7;
            this.btnSup.UseVisualStyleBackColor = true;
            this.btnSup.Click += new System.EventHandler(this.btnSup_Click);
            this.btnSup.MouseHover += new System.EventHandler(this.btnSup_MouseHover);
            // 
            // btnJun
            // 
            this.btnJun.BackgroundImage = global::ChampRune.Properties.Resources.jun;
            this.btnJun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJun.Location = new System.Drawing.Point(236, 35);
            this.btnJun.Name = "btnJun";
            this.btnJun.Size = new System.Drawing.Size(50, 50);
            this.btnJun.TabIndex = 6;
            this.btnJun.UseVisualStyleBackColor = true;
            this.btnJun.Click += new System.EventHandler(this.btnJun_Click);
            this.btnJun.MouseHover += new System.EventHandler(this.btnJun_MouseHover);
            // 
            // btnAdc
            // 
            this.btnAdc.BackgroundImage = global::ChampRune.Properties.Resources.bot;
            this.btnAdc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdc.Location = new System.Drawing.Point(180, 35);
            this.btnAdc.Name = "btnAdc";
            this.btnAdc.Size = new System.Drawing.Size(50, 50);
            this.btnAdc.TabIndex = 5;
            this.btnAdc.UseVisualStyleBackColor = true;
            this.btnAdc.Click += new System.EventHandler(this.btnAdc_Click);
            this.btnAdc.MouseHover += new System.EventHandler(this.btnAdc_MouseHover);
            // 
            // btnMid
            // 
            this.btnMid.BackgroundImage = global::ChampRune.Properties.Resources.mid;
            this.btnMid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMid.Location = new System.Drawing.Point(124, 35);
            this.btnMid.Name = "btnMid";
            this.btnMid.Size = new System.Drawing.Size(50, 50);
            this.btnMid.TabIndex = 4;
            this.btnMid.UseVisualStyleBackColor = true;
            this.btnMid.Click += new System.EventHandler(this.btnMid_Click);
            this.btnMid.MouseHover += new System.EventHandler(this.btnMid_MouseHover);
            // 
            // btnTop
            // 
            this.btnTop.BackgroundImage = global::ChampRune.Properties.Resources.top;
            this.btnTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTop.Location = new System.Drawing.Point(68, 35);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(50, 50);
            this.btnTop.TabIndex = 3;
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            this.btnTop.MouseHover += new System.EventHandler(this.btnTop_MouseHover);
            // 
            // tcPages
            // 
            this.tcPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPages.Controls.Add(this.tpChamp);
            this.tcPages.Controls.Add(this.tpRune);
            this.tcPages.Controls.Add(this.tpItems);
            this.tcPages.Location = new System.Drawing.Point(12, 91);
            this.tcPages.Name = "tcPages";
            this.tcPages.SelectedIndex = 0;
            this.tcPages.Size = new System.Drawing.Size(802, 452);
            this.tcPages.TabIndex = 0;
            // 
            // tpChamp
            // 
            this.tpChamp.Location = new System.Drawing.Point(4, 22);
            this.tpChamp.Name = "tpChamp";
            this.tpChamp.Padding = new System.Windows.Forms.Padding(3);
            this.tpChamp.Size = new System.Drawing.Size(794, 426);
            this.tpChamp.TabIndex = 0;
            this.tpChamp.Text = "Champ";
            this.tpChamp.UseVisualStyleBackColor = true;
            // 
            // tpRune
            // 
            this.tpRune.Controls.Add(this.wbSearches);
            this.tpRune.Controls.Add(this.tcRuneLain);
            this.tpRune.Location = new System.Drawing.Point(4, 22);
            this.tpRune.Name = "tpRune";
            this.tpRune.Padding = new System.Windows.Forms.Padding(3);
            this.tpRune.Size = new System.Drawing.Size(794, 426);
            this.tpRune.TabIndex = 1;
            this.tpRune.Text = "Rune";
            this.tpRune.UseVisualStyleBackColor = true;
            // 
            // tcRuneLain
            // 
            this.tcRuneLain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcRuneLain.Location = new System.Drawing.Point(0, 3);
            this.tcRuneLain.Name = "tcRuneLain";
            this.tcRuneLain.SelectedIndex = 0;
            this.tcRuneLain.Size = new System.Drawing.Size(791, 420);
            this.tcRuneLain.TabIndex = 0;
            // 
            // tpItems
            // 
            this.tpItems.Controls.Add(this.tcItems);
            this.tpItems.Location = new System.Drawing.Point(4, 22);
            this.tpItems.Name = "tpItems";
            this.tpItems.Size = new System.Drawing.Size(794, 426);
            this.tpItems.TabIndex = 2;
            this.tpItems.Text = "Items";
            this.tpItems.UseVisualStyleBackColor = true;
            // 
            // tcItems
            // 
            this.tcItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcItems.Location = new System.Drawing.Point(3, 3);
            this.tcItems.Name = "tcItems";
            this.tcItems.SelectedIndex = 0;
            this.tcItems.Size = new System.Drawing.Size(782, 414);
            this.tcItems.TabIndex = 9;
            // 
            // cbPatch
            // 
            this.cbPatch.AutoCompleteCustomSource.AddRange(new string[] {
            "11.14",
            "11.15",
            "11.16"});
            this.cbPatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatch.FormattingEnabled = true;
            this.cbPatch.Items.AddRange(new object[] {
            "11.15",
            "11.16"});
            this.cbPatch.Location = new System.Drawing.Point(270, 8);
            this.cbPatch.Name = "cbPatch";
            this.cbPatch.Size = new System.Drawing.Size(72, 21);
            this.cbPatch.TabIndex = 9;
            this.cbPatch.SelectedIndexChanged += new System.EventHandler(this.cbPatch_SelectedIndexChanged);
            // 
            // lblPatck
            // 
            this.lblPatck.AutoSize = true;
            this.lblPatck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatck.Location = new System.Drawing.Point(210, 8);
            this.lblPatck.Name = "lblPatck";
            this.lblPatck.Size = new System.Drawing.Size(54, 20);
            this.lblPatck.TabIndex = 10;
            this.lblPatck.Text = "Patch:";
            // 
            // nudStack
            // 
            this.nudStack.Location = new System.Drawing.Point(408, 8);
            this.nudStack.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nudStack.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudStack.Name = "nudStack";
            this.nudStack.ReadOnly = true;
            this.nudStack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudStack.Size = new System.Drawing.Size(48, 20);
            this.nudStack.TabIndex = 11;
            this.nudStack.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudStack.ValueChanged += new System.EventHandler(this.nudStack_ValueChanged);
            // 
            // lblStack
            // 
            this.lblStack.AutoSize = true;
            this.lblStack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStack.Location = new System.Drawing.Point(348, 9);
            this.lblStack.Name = "lblStack";
            this.lblStack.Size = new System.Drawing.Size(54, 20);
            this.lblStack.TabIndex = 12;
            this.lblStack.Text = "Stack:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Size:";
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(398, 34);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(58, 20);
            this.tbSize.TabIndex = 15;
            this.tbSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSize_KeyDown);
            this.tbSize.MouseHover += new System.EventHandler(this.tbSize_MouseHover);
            // 
            // llLinks
            // 
            this.llLinks.AutoSize = true;
            this.llLinks.Location = new System.Drawing.Point(462, 9);
            this.llLinks.Name = "llLinks";
            this.llLinks.Size = new System.Drawing.Size(109, 13);
            this.llLinks.TabIndex = 16;
            this.llLinks.TabStop = true;
            this.llLinks.Text = "https://tutorialeu.com";
            this.llLinks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLinks_LinkClicked);
            // 
            // lblAuthor
            // 
            this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(532, 75);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(278, 13);
            this.lblAuthor.TabIndex = 17;
            this.lblAuthor.Text = "© Created by TutorialEu contact: support@tutorialeu.com";
            // 
            // wbSearches
            // 
            this.wbSearches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbSearches.Location = new System.Drawing.Point(3, 6);
            this.wbSearches.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbSearches.Name = "wbSearches";
            this.wbSearches.Size = new System.Drawing.Size(781, 414);
            this.wbSearches.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(826, 555);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.llLinks);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStack);
            this.Controls.Add(this.nudStack);
            this.Controls.Add(this.lblPatck);
            this.Controls.Add(this.cbPatch);
            this.Controls.Add(this.tcPages);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnSup);
            this.Controls.Add(this.btnJun);
            this.Controls.Add(this.btnAdc);
            this.Controls.Add(this.btnMid);
            this.Controls.Add(this.btnTop);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Champ Rune V005";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tcPages.ResumeLayout(false);
            this.tpRune.ResumeLayout(false);
            this.tpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudStack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnMid;
        private System.Windows.Forms.Button btnAdc;
        private System.Windows.Forms.Button btnJun;
        private System.Windows.Forms.Button btnSup;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.TabControl tcPages;
        private System.Windows.Forms.TabPage tpChamp;
        private System.Windows.Forms.TabPage tpRune;
        private System.Windows.Forms.TabPage tpItems;
        private System.Windows.Forms.TabControl tcRuneLain;
        private System.Windows.Forms.TabControl tcItems;
        private System.Windows.Forms.ComboBox cbPatch;
        private System.Windows.Forms.Label lblPatck;
        private System.Windows.Forms.NumericUpDown nudStack;
        private System.Windows.Forms.Label lblStack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.LinkLabel llLinks;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.WebBrowser wbSearches;
    }
}

