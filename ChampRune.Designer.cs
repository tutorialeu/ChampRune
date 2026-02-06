
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSup = new System.Windows.Forms.Button();
            this.btnJun = new System.Windows.Forms.Button();
            this.btnAdc = new System.Windows.Forms.Button();
            this.btnMid = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.lblPatck = new System.Windows.Forms.Label();
            this.nudStack = new System.Windows.Forms.NumericUpDown();
            this.lblSize = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.pnWeb = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnRune = new System.Windows.Forms.Button();
            this.cbTopWin = new System.Windows.Forms.CheckBox();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpdateRune = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTheme = new System.Windows.Forms.Button();
            this.msGameMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRankedSolo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlatinumPlusS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiamondPlusS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiamond2PlusS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMasterPlusS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAllRanksS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiChallengerS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGrandmasterS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMasterS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiamondS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlatinumS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGoldS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSilverS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBronzeS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIronS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAram = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRankedFlex = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlatinumPlusF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiamondPlusF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiamond2PlusF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMasterPlusF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAllRanksF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiChallengerF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGrandmasterF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMasterF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiamondF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlatinumF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGoldF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSilverF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBronzeF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIronF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNormalBlind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNormalDraft = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPhase = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.nudPatch1 = new System.Windows.Forms.NumericUpDown();
            this.nudPatch2 = new System.Windows.Forms.NumericUpDown();
            this.btnCounter = new System.Windows.Forms.Button();
            this.ttCounterPick = new System.Windows.Forms.ToolTip(this.components);
            this.cbSearch = new System.Windows.Forms.CheckBox();
            this.lblTopWin = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudStack)).BeginInit();
            this.msGameMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPatch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPatch2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.tbSearch.Location = new System.Drawing.Point(238, 2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(132, 28);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Click += new System.EventHandler(this.tbSearch_Click);
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            this.tbSearch.MouseHover += new System.EventHandler(this.tbSearch_MouseHover);
            this.tbSearch.Validated += new System.EventHandler(this.tbSearch_Validated);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAll.BackgroundImage = global::ChampRune.Properties.Resources.all_full_trans;
            this.btnAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAll.Location = new System.Drawing.Point(2, 2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(60, 60);
            this.btnAll.TabIndex = 8;
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            this.btnAll.MouseEnter += new System.EventHandler(this.btnAll_MouseHover);
            // 
            // btnSup
            // 
            this.btnSup.BackgroundImage = global::ChampRune.Properties.Resources.sup;
            this.btnSup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSup.Location = new System.Drawing.Point(64, 32);
            this.btnSup.Name = "btnSup";
            this.btnSup.Size = new System.Drawing.Size(30, 30);
            this.btnSup.TabIndex = 7;
            this.btnSup.UseVisualStyleBackColor = true;
            this.btnSup.Click += new System.EventHandler(this.btnSup_Click);
            this.btnSup.MouseEnter += new System.EventHandler(this.btnSup_MouseHover);
            // 
            // btnJun
            // 
            this.btnJun.BackgroundImage = global::ChampRune.Properties.Resources.jun;
            this.btnJun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJun.Location = new System.Drawing.Point(124, 2);
            this.btnJun.Name = "btnJun";
            this.btnJun.Size = new System.Drawing.Size(30, 30);
            this.btnJun.TabIndex = 6;
            this.btnJun.UseVisualStyleBackColor = true;
            this.btnJun.Click += new System.EventHandler(this.btnJun_Click);
            this.btnJun.MouseEnter += new System.EventHandler(this.btnJun_MouseHover);
            // 
            // btnAdc
            // 
            this.btnAdc.BackgroundImage = global::ChampRune.Properties.Resources.bot;
            this.btnAdc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdc.Location = new System.Drawing.Point(124, 32);
            this.btnAdc.Name = "btnAdc";
            this.btnAdc.Size = new System.Drawing.Size(30, 30);
            this.btnAdc.TabIndex = 5;
            this.btnAdc.UseVisualStyleBackColor = true;
            this.btnAdc.Click += new System.EventHandler(this.btnAdc_Click);
            this.btnAdc.MouseEnter += new System.EventHandler(this.btnAdc_MouseHover);
            // 
            // btnMid
            // 
            this.btnMid.BackgroundImage = global::ChampRune.Properties.Resources.mid;
            this.btnMid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMid.Location = new System.Drawing.Point(94, 15);
            this.btnMid.Name = "btnMid";
            this.btnMid.Size = new System.Drawing.Size(30, 30);
            this.btnMid.TabIndex = 4;
            this.btnMid.UseVisualStyleBackColor = true;
            this.btnMid.Click += new System.EventHandler(this.btnMid_Click);
            this.btnMid.MouseEnter += new System.EventHandler(this.btnMid_MouseHover);
            // 
            // btnTop
            // 
            this.btnTop.BackgroundImage = global::ChampRune.Properties.Resources.top;
            this.btnTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTop.Location = new System.Drawing.Point(64, 2);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(30, 30);
            this.btnTop.TabIndex = 3;
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.btnTop_Click);
            this.btnTop.MouseEnter += new System.EventHandler(this.btnTop_MouseHover);
            // 
            // lblPatck
            // 
            this.lblPatck.AutoSize = true;
            this.lblPatck.BackColor = System.Drawing.Color.Transparent;
            this.lblPatck.Font = new System.Drawing.Font("Reem Kufi", 12F);
            this.lblPatck.Location = new System.Drawing.Point(398, 32);
            this.lblPatck.Name = "lblPatck";
            this.lblPatck.Size = new System.Drawing.Size(57, 30);
            this.lblPatck.TabIndex = 120;
            this.lblPatck.Text = "Patch:";
            this.lblPatck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPatck_MouseDown);
            // 
            // nudStack
            // 
            this.nudStack.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.nudStack.Location = new System.Drawing.Point(447, 1);
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
            this.nudStack.Size = new System.Drawing.Size(34, 28);
            this.nudStack.TabIndex = 30;
            this.nudStack.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudStack.ValueChanged += new System.EventHandler(this.nudStack_ValueChanged);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSize.Font = new System.Drawing.Font("Reem Kufi", 12F);
            this.lblSize.Location = new System.Drawing.Point(370, -1);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(45, 30);
            this.lblSize.TabIndex = 31;
            this.lblSize.Text = "Size:";
            this.lblSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblSize_MouseDown);
            // 
            // tbSize
            // 
            this.tbSize.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.tbSize.Location = new System.Drawing.Point(412, 1);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(30, 28);
            this.tbSize.TabIndex = 31;
            this.tbSize.TextChanged += new System.EventHandler(this.tbSize_TextChanged);
            this.tbSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSize_KeyDown);
            this.tbSize.MouseHover += new System.EventHandler(this.tbSize_MouseHover);
            // 
            // pnWeb
            // 
            this.pnWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnWeb.AutoSize = true;
            this.pnWeb.BackColor = System.Drawing.Color.Transparent;
            this.pnWeb.Location = new System.Drawing.Point(0, 63);
            this.pnWeb.Name = "pnWeb";
            this.pnWeb.Size = new System.Drawing.Size(960, 289);
            this.pnWeb.TabIndex = 18;
            this.pnWeb.Paint += new System.Windows.Forms.PaintEventHandler(this.pnWeb_Paint_1);
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Reem Kufi", 12F);
            this.lblText.Location = new System.Drawing.Point(779, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(0, 30);
            this.lblText.TabIndex = 0;
            // 
            // btnItems
            // 
            this.btnItems.Location = new System.Drawing.Point(520, 32);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(59, 30);
            this.btnItems.TabIndex = 19;
            this.btnItems.Text = "ITEMS🠋";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRune
            // 
            this.btnRune.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.btnRune.Location = new System.Drawing.Point(520, 2);
            this.btnRune.Name = "btnRune";
            this.btnRune.Size = new System.Drawing.Size(59, 30);
            this.btnRune.TabIndex = 20;
            this.btnRune.Text = "RUNE🠉";
            this.btnRune.UseVisualStyleBackColor = true;
            this.btnRune.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbTopWin
            // 
            this.cbTopWin.AutoSize = true;
            this.cbTopWin.BackColor = System.Drawing.Color.Transparent;
            this.cbTopWin.Font = new System.Drawing.Font("Reem Kufi", 9.749999F);
            this.cbTopWin.Location = new System.Drawing.Point(158, 40);
            this.cbTopWin.Name = "cbTopWin";
            this.cbTopWin.Size = new System.Drawing.Size(15, 14);
            this.cbTopWin.TabIndex = 21;
            this.cbTopWin.UseVisualStyleBackColor = false;
            this.cbTopWin.CheckedChanged += new System.EventHandler(this.cbTopWin_CheckedChanged);
            this.cbTopWin.MouseHover += new System.EventHandler(this.cbTopWin_MouseHover);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCache.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.btnClearCache.Location = new System.Drawing.Point(687, 34);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(80, 27);
            this.btnClearCache.TabIndex = 10;
            this.btnClearCache.Text = "ClearCache";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.btnUpdate.Location = new System.Drawing.Point(767, 34);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 27);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "UpdateApp";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUpdateRune
            // 
            this.btnUpdateRune.Font = new System.Drawing.Font("Reem Kufi", 8.999999F);
            this.btnUpdateRune.Location = new System.Drawing.Point(580, 5);
            this.btnUpdateRune.Name = "btnUpdateRune";
            this.btnUpdateRune.Size = new System.Drawing.Size(99, 54);
            this.btnUpdateRune.TabIndex = 110;
            this.btnUpdateRune.Text = "Auto Import Runes / Spells";
            this.btnUpdateRune.UseVisualStyleBackColor = true;
            this.btnUpdateRune.Click += new System.EventHandler(this.btnUpdateRune_Click_1);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Black;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Location = new System.Drawing.Point(860, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(31, 31);
            this.btnMinimize.TabIndex = 128;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Text = "🗕";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.Black;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.ForeColor = System.Drawing.Color.Transparent;
            this.btnMaximize.Location = new System.Drawing.Point(893, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(31, 31);
            this.btnMaximize.TabIndex = 127;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Text = "🗖";
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Transparent;
            this.btnExit.Location = new System.Drawing.Point(926, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(31, 31);
            this.btnExit.TabIndex = 129;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "🗙";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // btnTheme
            // 
            this.btnTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTheme.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.btnTheme.Location = new System.Drawing.Point(846, 34);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(54, 27);
            this.btnTheme.TabIndex = 12;
            this.btnTheme.Text = "Theme";
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // msGameMenu
            // 
            this.msGameMenu.AutoSize = false;
            this.msGameMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.msGameMenu.GripMargin = new System.Windows.Forms.Padding(1);
            this.msGameMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiType});
            this.msGameMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.msGameMenu.Location = new System.Drawing.Point(238, 33);
            this.msGameMenu.Name = "msGameMenu";
            this.msGameMenu.Padding = new System.Windows.Forms.Padding(1);
            this.msGameMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msGameMenu.Size = new System.Drawing.Size(162, 27);
            this.msGameMenu.TabIndex = 133;
            // 
            // tsmiType
            // 
            this.tsmiType.BackColor = System.Drawing.Color.Transparent;
            this.tsmiType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmiType.CheckOnClick = true;
            this.tsmiType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRankedSolo,
            this.tsmiAram,
            this.tsmiRankedFlex,
            this.tsmiNormalBlind,
            this.tsmiNormalDraft});
            this.tsmiType.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.tsmiType.ForeColor = System.Drawing.Color.Black;
            this.tsmiType.Image = global::ChampRune.Properties.Resources.Normal_Draft;
            this.tsmiType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiType.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.tsmiType.Name = "tsmiType";
            this.tsmiType.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiType.Size = new System.Drawing.Size(159, 25);
            this.tsmiType.Text = "Ranked Solo";
            this.tsmiType.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsmiType.DropDownClosed += new System.EventHandler(this.tsmiType_DropDownClosed);
            // 
            // tsmiRankedSolo
            // 
            this.tsmiRankedSolo.CheckOnClick = true;
            this.tsmiRankedSolo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPlatinumPlusS,
            this.tsmiDiamondPlusS,
            this.tsmiDiamond2PlusS,
            this.tsmiMasterPlusS,
            this.toolStripSeparator1,
            this.tsmiAllRanksS,
            this.toolStripSeparator8,
            this.tsmiChallengerS,
            this.tsmiGrandmasterS,
            this.tsmiMasterS,
            this.tsmiDiamondS,
            this.tsmiPlatinumS,
            this.tsmiGoldS,
            this.tsmiSilverS,
            this.tsmiBronzeS,
            this.tsmiIronS});
            this.tsmiRankedSolo.Image = global::ChampRune.Properties.Resources.Normal_Draft;
            this.tsmiRankedSolo.Name = "tsmiRankedSolo";
            this.tsmiRankedSolo.Size = new System.Drawing.Size(146, 26);
            this.tsmiRankedSolo.Tag = "0";
            this.tsmiRankedSolo.Text = "Ranked Solo";
            this.tsmiRankedSolo.Click += new System.EventHandler(this.tsmiRankedSolo_Click);
            // 
            // tsmiPlatinumPlusS
            // 
            this.tsmiPlatinumPlusS.Image = global::ChampRune.Properties.Resources.Emblem_Platinum_Plus;
            this.tsmiPlatinumPlusS.Name = "tsmiPlatinumPlusS";
            this.tsmiPlatinumPlusS.Size = new System.Drawing.Size(147, 26);
            this.tsmiPlatinumPlusS.Tag = "0";
            this.tsmiPlatinumPlusS.Text = "Platinum +";
            this.tsmiPlatinumPlusS.Click += new System.EventHandler(this.tsmiPlatinumPlusS_Click);
            // 
            // tsmiDiamondPlusS
            // 
            this.tsmiDiamondPlusS.Image = global::ChampRune.Properties.Resources.Emblem_Diamond_Plus;
            this.tsmiDiamondPlusS.Name = "tsmiDiamondPlusS";
            this.tsmiDiamondPlusS.Size = new System.Drawing.Size(147, 26);
            this.tsmiDiamondPlusS.Tag = "1";
            this.tsmiDiamondPlusS.Text = "Diamond +";
            this.tsmiDiamondPlusS.Click += new System.EventHandler(this.tsmiDiamondPlusS_Click);
            // 
            // tsmiDiamond2PlusS
            // 
            this.tsmiDiamond2PlusS.Image = global::ChampRune.Properties.Resources.Emblem_Diamond_2_Plus;
            this.tsmiDiamond2PlusS.Name = "tsmiDiamond2PlusS";
            this.tsmiDiamond2PlusS.Size = new System.Drawing.Size(147, 26);
            this.tsmiDiamond2PlusS.Tag = "2";
            this.tsmiDiamond2PlusS.Text = "Diamond 2+";
            this.tsmiDiamond2PlusS.Click += new System.EventHandler(this.tsmiDiamond2PlusS_Click);
            // 
            // tsmiMasterPlusS
            // 
            this.tsmiMasterPlusS.Image = global::ChampRune.Properties.Resources.Emblem_Master_Plus;
            this.tsmiMasterPlusS.Name = "tsmiMasterPlusS";
            this.tsmiMasterPlusS.Size = new System.Drawing.Size(147, 26);
            this.tsmiMasterPlusS.Tag = "3";
            this.tsmiMasterPlusS.Text = "Master +";
            this.tsmiMasterPlusS.Click += new System.EventHandler(this.tsmiMasterPlusS_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // tsmiAllRanksS
            // 
            this.tsmiAllRanksS.Image = global::ChampRune.Properties.Resources.All_Ranks;
            this.tsmiAllRanksS.Name = "tsmiAllRanksS";
            this.tsmiAllRanksS.Size = new System.Drawing.Size(147, 26);
            this.tsmiAllRanksS.Tag = "5";
            this.tsmiAllRanksS.Text = "All Ranks";
            this.tsmiAllRanksS.Click += new System.EventHandler(this.tsmiAllRanksS_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(144, 6);
            // 
            // tsmiChallengerS
            // 
            this.tsmiChallengerS.Image = global::ChampRune.Properties.Resources.Emblem_Challenger;
            this.tsmiChallengerS.Name = "tsmiChallengerS";
            this.tsmiChallengerS.Size = new System.Drawing.Size(147, 26);
            this.tsmiChallengerS.Tag = "7";
            this.tsmiChallengerS.Text = "Challenger";
            this.tsmiChallengerS.Click += new System.EventHandler(this.tsmiChallengerS_Click);
            // 
            // tsmiGrandmasterS
            // 
            this.tsmiGrandmasterS.Image = global::ChampRune.Properties.Resources.Emblem_Grandmaster;
            this.tsmiGrandmasterS.Name = "tsmiGrandmasterS";
            this.tsmiGrandmasterS.Size = new System.Drawing.Size(147, 26);
            this.tsmiGrandmasterS.Tag = "8";
            this.tsmiGrandmasterS.Text = "Grandmaster";
            this.tsmiGrandmasterS.Click += new System.EventHandler(this.tsmiGrandmasterS_Click);
            // 
            // tsmiMasterS
            // 
            this.tsmiMasterS.Image = global::ChampRune.Properties.Resources.Emblem_Master;
            this.tsmiMasterS.Name = "tsmiMasterS";
            this.tsmiMasterS.Size = new System.Drawing.Size(147, 26);
            this.tsmiMasterS.Tag = "9";
            this.tsmiMasterS.Text = "Master";
            this.tsmiMasterS.Click += new System.EventHandler(this.tsmiMasterS_Click);
            // 
            // tsmiDiamondS
            // 
            this.tsmiDiamondS.Image = global::ChampRune.Properties.Resources.Emblem_Diamond;
            this.tsmiDiamondS.Name = "tsmiDiamondS";
            this.tsmiDiamondS.Size = new System.Drawing.Size(147, 26);
            this.tsmiDiamondS.Tag = "10";
            this.tsmiDiamondS.Text = "Diamond";
            this.tsmiDiamondS.Click += new System.EventHandler(this.tsmiDiamondS_Click);
            // 
            // tsmiPlatinumS
            // 
            this.tsmiPlatinumS.Image = global::ChampRune.Properties.Resources.Emblem_Platinum;
            this.tsmiPlatinumS.Name = "tsmiPlatinumS";
            this.tsmiPlatinumS.Size = new System.Drawing.Size(147, 26);
            this.tsmiPlatinumS.Tag = "11";
            this.tsmiPlatinumS.Text = "Platinum";
            this.tsmiPlatinumS.Click += new System.EventHandler(this.tsmiPlatinumS_Click);
            // 
            // tsmiGoldS
            // 
            this.tsmiGoldS.Image = global::ChampRune.Properties.Resources.Emblem_Gold;
            this.tsmiGoldS.Name = "tsmiGoldS";
            this.tsmiGoldS.Size = new System.Drawing.Size(147, 26);
            this.tsmiGoldS.Tag = "12";
            this.tsmiGoldS.Text = "Gold";
            this.tsmiGoldS.Click += new System.EventHandler(this.tsmiGoldS_Click);
            // 
            // tsmiSilverS
            // 
            this.tsmiSilverS.Image = global::ChampRune.Properties.Resources.Emblem_Silver;
            this.tsmiSilverS.Name = "tsmiSilverS";
            this.tsmiSilverS.Size = new System.Drawing.Size(147, 26);
            this.tsmiSilverS.Tag = "13";
            this.tsmiSilverS.Text = "Silver";
            this.tsmiSilverS.Click += new System.EventHandler(this.tsmiSilverS_Click);
            // 
            // tsmiBronzeS
            // 
            this.tsmiBronzeS.Image = global::ChampRune.Properties.Resources.Emblem_Bronze;
            this.tsmiBronzeS.Name = "tsmiBronzeS";
            this.tsmiBronzeS.Size = new System.Drawing.Size(147, 26);
            this.tsmiBronzeS.Tag = "14";
            this.tsmiBronzeS.Text = "Bronze";
            this.tsmiBronzeS.Click += new System.EventHandler(this.tsmiBronzeS_Click);
            // 
            // tsmiIronS
            // 
            this.tsmiIronS.Image = global::ChampRune.Properties.Resources.Emblem_Iron;
            this.tsmiIronS.Name = "tsmiIronS";
            this.tsmiIronS.Size = new System.Drawing.Size(147, 26);
            this.tsmiIronS.Tag = "15";
            this.tsmiIronS.Text = "Iron";
            this.tsmiIronS.Click += new System.EventHandler(this.tsmiIronS_Click);
            // 
            // tsmiAram
            // 
            this.tsmiAram.CheckOnClick = true;
            this.tsmiAram.Image = global::ChampRune.Properties.Resources.ARAM;
            this.tsmiAram.Name = "tsmiAram";
            this.tsmiAram.Size = new System.Drawing.Size(146, 26);
            this.tsmiAram.Tag = "1";
            this.tsmiAram.Text = "ARAM";
            this.tsmiAram.Click += new System.EventHandler(this.aRAMToolStripMenuItem_Click);
            // 
            // tsmiRankedFlex
            // 
            this.tsmiRankedFlex.CheckOnClick = true;
            this.tsmiRankedFlex.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPlatinumPlusF,
            this.tsmiDiamondPlusF,
            this.tsmiDiamond2PlusF,
            this.tsmiMasterPlusF,
            this.toolStripSeparator2,
            this.tsmiAllRanksF,
            this.toolStripSeparator9,
            this.tsmiChallengerF,
            this.tsmiGrandmasterF,
            this.tsmiMasterF,
            this.tsmiDiamondF,
            this.tsmiPlatinumF,
            this.tsmiGoldF,
            this.tsmiSilverF,
            this.tsmiBronzeF,
            this.tsmiIronF});
            this.tsmiRankedFlex.Image = global::ChampRune.Properties.Resources.Ranked_Solo;
            this.tsmiRankedFlex.Name = "tsmiRankedFlex";
            this.tsmiRankedFlex.Size = new System.Drawing.Size(146, 26);
            this.tsmiRankedFlex.Tag = "2";
            this.tsmiRankedFlex.Text = "Ranked Flex";
            this.tsmiRankedFlex.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsmiPlatinumPlusF
            // 
            this.tsmiPlatinumPlusF.Image = global::ChampRune.Properties.Resources.Emblem_Platinum_Plus;
            this.tsmiPlatinumPlusF.Name = "tsmiPlatinumPlusF";
            this.tsmiPlatinumPlusF.Size = new System.Drawing.Size(147, 26);
            this.tsmiPlatinumPlusF.Tag = "0";
            this.tsmiPlatinumPlusF.Text = "Platinum +";
            this.tsmiPlatinumPlusF.Click += new System.EventHandler(this.tsmiPlatinumPlusF_Click);
            // 
            // tsmiDiamondPlusF
            // 
            this.tsmiDiamondPlusF.Image = global::ChampRune.Properties.Resources.Emblem_Diamond_Plus;
            this.tsmiDiamondPlusF.Name = "tsmiDiamondPlusF";
            this.tsmiDiamondPlusF.Size = new System.Drawing.Size(147, 26);
            this.tsmiDiamondPlusF.Tag = "1";
            this.tsmiDiamondPlusF.Text = "Diamond +";
            this.tsmiDiamondPlusF.Click += new System.EventHandler(this.tsmiDiamondPlusF_Click);
            // 
            // tsmiDiamond2PlusF
            // 
            this.tsmiDiamond2PlusF.Image = global::ChampRune.Properties.Resources.Emblem_Diamond_2_Plus;
            this.tsmiDiamond2PlusF.Name = "tsmiDiamond2PlusF";
            this.tsmiDiamond2PlusF.Size = new System.Drawing.Size(147, 26);
            this.tsmiDiamond2PlusF.Tag = "2";
            this.tsmiDiamond2PlusF.Text = "Diamond 2+";
            this.tsmiDiamond2PlusF.Click += new System.EventHandler(this.tsmiDiamond2PlusF_Click);
            // 
            // tsmiMasterPlusF
            // 
            this.tsmiMasterPlusF.Image = global::ChampRune.Properties.Resources.Emblem_Master_Plus;
            this.tsmiMasterPlusF.Name = "tsmiMasterPlusF";
            this.tsmiMasterPlusF.Size = new System.Drawing.Size(147, 26);
            this.tsmiMasterPlusF.Tag = "3";
            this.tsmiMasterPlusF.Text = "Master +";
            this.tsmiMasterPlusF.Click += new System.EventHandler(this.tsmiMasterPlusF_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(144, 6);
            // 
            // tsmiAllRanksF
            // 
            this.tsmiAllRanksF.Image = global::ChampRune.Properties.Resources.All_Ranks;
            this.tsmiAllRanksF.Name = "tsmiAllRanksF";
            this.tsmiAllRanksF.Size = new System.Drawing.Size(147, 26);
            this.tsmiAllRanksF.Tag = "5";
            this.tsmiAllRanksF.Text = "All Ranks";
            this.tsmiAllRanksF.Click += new System.EventHandler(this.tsmiAllRanksF_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(144, 6);
            // 
            // tsmiChallengerF
            // 
            this.tsmiChallengerF.Image = global::ChampRune.Properties.Resources.Emblem_Challenger;
            this.tsmiChallengerF.Name = "tsmiChallengerF";
            this.tsmiChallengerF.Size = new System.Drawing.Size(147, 26);
            this.tsmiChallengerF.Tag = "7";
            this.tsmiChallengerF.Text = "Challenger";
            this.tsmiChallengerF.Click += new System.EventHandler(this.tsmiChallengerF_Click);
            // 
            // tsmiGrandmasterF
            // 
            this.tsmiGrandmasterF.Image = global::ChampRune.Properties.Resources.Emblem_Grandmaster;
            this.tsmiGrandmasterF.Name = "tsmiGrandmasterF";
            this.tsmiGrandmasterF.Size = new System.Drawing.Size(147, 26);
            this.tsmiGrandmasterF.Tag = "8";
            this.tsmiGrandmasterF.Text = "Grandmaster";
            this.tsmiGrandmasterF.Click += new System.EventHandler(this.tsmiGrandmasterF_Click);
            // 
            // tsmiMasterF
            // 
            this.tsmiMasterF.Image = global::ChampRune.Properties.Resources.Emblem_Master;
            this.tsmiMasterF.Name = "tsmiMasterF";
            this.tsmiMasterF.Size = new System.Drawing.Size(147, 26);
            this.tsmiMasterF.Tag = "9";
            this.tsmiMasterF.Text = "Master";
            this.tsmiMasterF.Click += new System.EventHandler(this.tsmiMasterF_Click);
            // 
            // tsmiDiamondF
            // 
            this.tsmiDiamondF.Image = global::ChampRune.Properties.Resources.Emblem_Diamond;
            this.tsmiDiamondF.Name = "tsmiDiamondF";
            this.tsmiDiamondF.Size = new System.Drawing.Size(147, 26);
            this.tsmiDiamondF.Tag = "10";
            this.tsmiDiamondF.Text = "Diamond";
            this.tsmiDiamondF.Click += new System.EventHandler(this.tsmiDiamondF_Click);
            // 
            // tsmiPlatinumF
            // 
            this.tsmiPlatinumF.Image = global::ChampRune.Properties.Resources.Emblem_Platinum;
            this.tsmiPlatinumF.Name = "tsmiPlatinumF";
            this.tsmiPlatinumF.Size = new System.Drawing.Size(147, 26);
            this.tsmiPlatinumF.Tag = "11";
            this.tsmiPlatinumF.Text = "Platinum";
            this.tsmiPlatinumF.Click += new System.EventHandler(this.tsmiPlatinumF_Click);
            // 
            // tsmiGoldF
            // 
            this.tsmiGoldF.Image = global::ChampRune.Properties.Resources.Emblem_Gold;
            this.tsmiGoldF.Name = "tsmiGoldF";
            this.tsmiGoldF.Size = new System.Drawing.Size(147, 26);
            this.tsmiGoldF.Tag = "12";
            this.tsmiGoldF.Text = "Gold";
            this.tsmiGoldF.Click += new System.EventHandler(this.tsmiGoldF_Click);
            // 
            // tsmiSilverF
            // 
            this.tsmiSilverF.Image = global::ChampRune.Properties.Resources.Emblem_Silver;
            this.tsmiSilverF.Name = "tsmiSilverF";
            this.tsmiSilverF.Size = new System.Drawing.Size(147, 26);
            this.tsmiSilverF.Tag = "13";
            this.tsmiSilverF.Text = "Silver";
            this.tsmiSilverF.Click += new System.EventHandler(this.tsmiSilverF_Click);
            // 
            // tsmiBronzeF
            // 
            this.tsmiBronzeF.Image = global::ChampRune.Properties.Resources.Emblem_Bronze;
            this.tsmiBronzeF.Name = "tsmiBronzeF";
            this.tsmiBronzeF.Size = new System.Drawing.Size(147, 26);
            this.tsmiBronzeF.Tag = "14";
            this.tsmiBronzeF.Text = "Bronze";
            this.tsmiBronzeF.Click += new System.EventHandler(this.tsmiBronzeF_Click);
            // 
            // tsmiIronF
            // 
            this.tsmiIronF.Image = global::ChampRune.Properties.Resources.Emblem_Iron;
            this.tsmiIronF.Name = "tsmiIronF";
            this.tsmiIronF.Size = new System.Drawing.Size(147, 26);
            this.tsmiIronF.Tag = "15";
            this.tsmiIronF.Text = "Iron";
            this.tsmiIronF.Click += new System.EventHandler(this.tsmiIronF_Click);
            // 
            // tsmiNormalBlind
            // 
            this.tsmiNormalBlind.CheckOnClick = true;
            this.tsmiNormalBlind.Image = global::ChampRune.Properties.Resources.Normal_Blind;
            this.tsmiNormalBlind.Name = "tsmiNormalBlind";
            this.tsmiNormalBlind.Size = new System.Drawing.Size(146, 26);
            this.tsmiNormalBlind.Tag = "3";
            this.tsmiNormalBlind.Text = "Normal Blind";
            this.tsmiNormalBlind.Click += new System.EventHandler(this.normalBlindToolStripMenuItem_Click);
            // 
            // tsmiNormalDraft
            // 
            this.tsmiNormalDraft.CheckOnClick = true;
            this.tsmiNormalDraft.Image = global::ChampRune.Properties.Resources.Ranked_Solo;
            this.tsmiNormalDraft.Name = "tsmiNormalDraft";
            this.tsmiNormalDraft.Size = new System.Drawing.Size(146, 26);
            this.tsmiNormalDraft.Tag = "4";
            this.tsmiNormalDraft.Text = "Normal Draft";
            this.tsmiNormalDraft.Click += new System.EventHandler(this.normalDraftToolStripMenuItem_Click);
            // 
            // lblPhase
            // 
            this.lblPhase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhase.AutoSize = true;
            this.lblPhase.BackColor = System.Drawing.Color.Transparent;
            this.lblPhase.Font = new System.Drawing.Font("Reem Kufi", 9.749999F);
            this.lblPhase.Location = new System.Drawing.Point(682, 6);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(91, 25);
            this.lblPhase.TabIndex = 132;
            this.lblPhase.Text = "Phase: Offline";
            this.lblPhase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPhase_MouseDown);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.btnAbout.Location = new System.Drawing.Point(900, 34);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(54, 27);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // nudPatch1
            // 
            this.nudPatch1.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.nudPatch1.Location = new System.Drawing.Point(451, 33);
            this.nudPatch1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPatch1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPatch1.Name = "nudPatch1";
            this.nudPatch1.ReadOnly = true;
            this.nudPatch1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudPatch1.Size = new System.Drawing.Size(34, 28);
            this.nudPatch1.TabIndex = 134;
            this.nudPatch1.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudPatch1.ValueChanged += new System.EventHandler(this.nudPatch1_ValueChanged);
            // 
            // nudPatch2
            // 
            this.nudPatch2.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.nudPatch2.Location = new System.Drawing.Point(484, 33);
            this.nudPatch2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPatch2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPatch2.Name = "nudPatch2";
            this.nudPatch2.ReadOnly = true;
            this.nudPatch2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudPatch2.Size = new System.Drawing.Size(34, 28);
            this.nudPatch2.TabIndex = 135;
            this.nudPatch2.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudPatch2.ValueChanged += new System.EventHandler(this.nudPatch2_ValueChanged);
            // 
            // btnCounter
            // 
            this.btnCounter.Location = new System.Drawing.Point(482, 3);
            this.btnCounter.Name = "btnCounter";
            this.btnCounter.Size = new System.Drawing.Size(37, 29);
            this.btnCounter.TabIndex = 136;
            this.btnCounter.Text = "CP";
            this.btnCounter.UseVisualStyleBackColor = true;
            this.btnCounter.Click += new System.EventHandler(this.btnCounter_Click);
            this.btnCounter.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // cbSearch
            // 
            this.cbSearch.AutoSize = true;
            this.cbSearch.BackColor = System.Drawing.Color.Transparent;
            this.cbSearch.Font = new System.Drawing.Font("Reem Kufi", 11.25F);
            this.cbSearch.Location = new System.Drawing.Point(222, 10);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(15, 14);
            this.cbSearch.TabIndex = 137;
            this.cbSearch.UseVisualStyleBackColor = false;
            this.cbSearch.CheckedChanged += new System.EventHandler(this.cbSearch_CheckedChanged);
            this.cbSearch.MouseHover += new System.EventHandler(this.checkBox1_MouseHover);
            // 
            // lblTopWin
            // 
            this.lblTopWin.AutoSize = true;
            this.lblTopWin.BackColor = System.Drawing.Color.Transparent;
            this.lblTopWin.Font = new System.Drawing.Font("Reem Kufi", 9F);
            this.lblTopWin.Location = new System.Drawing.Point(168, 35);
            this.lblTopWin.Name = "lblTopWin";
            this.lblTopWin.Size = new System.Drawing.Size(71, 23);
            this.lblTopWin.TabIndex = 138;
            this.lblTopWin.Text = "TopWinList";
            this.lblTopWin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTopWin_MouseDown);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Reem Kufi", 11.25F);
            this.lblSearch.Location = new System.Drawing.Point(163, 2);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(62, 28);
            this.lblSearch.TabIndex = 139;
            this.lblSearch.Text = "Search:";
            this.lblSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblSearch_MouseDown_1);
            // 
            // cbRegion
            // 
            this.cbRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRegion.DisplayMember = "EUN";
            this.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Items.AddRange(new object[] {
            "NA",
            "EUW",
            "EUN",
            "KR",
            "BR",
            "JP",
            "RU",
            "OCE",
            "TR",
            "LAN",
            "LAS"});
            this.cbRegion.Location = new System.Drawing.Point(807, 1);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(50, 29);
            this.cbRegion.TabIndex = 140;
            this.cbRegion.SelectedIndexChanged += new System.EventHandler(this.cbRegion_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::ChampRune.Properties.Resources.yasuo_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(957, 354);
            this.ControlBox = false;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.cbRegion);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.cbTopWin);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.msGameMenu);
            this.Controls.Add(this.lblTopWin);
            this.Controls.Add(this.btnCounter);
            this.Controls.Add(this.nudPatch2);
            this.Controls.Add(this.nudPatch1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lblPhase);
            this.Controls.Add(this.btnTheme);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnMaximize);
            this.Controls.Add(this.btnUpdateRune);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClearCache);
            this.Controls.Add(this.btnRune);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.pnWeb);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.nudStack);
            this.Controls.Add(this.lblPatck);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnSup);
            this.Controls.Add(this.btnJun);
            this.Controls.Add(this.btnAdc);
            this.Controls.Add(this.btnMid);
            this.Controls.Add(this.btnTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Reem Kufi", 8.25F);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MainMenuStrip = this.msGameMenu;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.frmMain_Scroll);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.nudStack)).EndInit();
            this.msGameMenu.ResumeLayout(false);
            this.msGameMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPatch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPatch2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnMid;
        private System.Windows.Forms.Button btnAdc;
        private System.Windows.Forms.Button btnJun;
        private System.Windows.Forms.Button btnSup;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Label lblPatck;
        private System.Windows.Forms.NumericUpDown nudStack;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Panel pnWeb;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Button btnRune;
        private System.Windows.Forms.CheckBox cbTopWin;
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnUpdateRune;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.MenuStrip msGameMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiType;
        private System.Windows.Forms.ToolStripMenuItem tsmiAram;
        private System.Windows.Forms.ToolStripMenuItem tsmiNormalBlind;
        private System.Windows.Forms.ToolStripMenuItem tsmiNormalDraft;
        private System.Windows.Forms.ToolStripMenuItem tsmiRankedFlex;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlatinumPlusF;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiamondPlusF;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiamond2PlusF;
        private System.Windows.Forms.ToolStripMenuItem tsmiMasterPlusF;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllRanksF;
        private System.Windows.Forms.ToolStripMenuItem tsmiChallengerF;
        private System.Windows.Forms.ToolStripMenuItem tsmiMasterF;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiamondF;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlatinumF;
        private System.Windows.Forms.ToolStripMenuItem tsmiGoldF;
        private System.Windows.Forms.ToolStripMenuItem tsmiSilverF;
        private System.Windows.Forms.ToolStripMenuItem tsmiBronzeF;
        private System.Windows.Forms.ToolStripMenuItem tsmiIronF;
        private System.Windows.Forms.ToolStripMenuItem tsmiRankedSolo;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlatinumPlusS;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiamondPlusS;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiamond2PlusS;
        private System.Windows.Forms.ToolStripMenuItem tsmiMasterPlusS;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllRanksS;
        private System.Windows.Forms.ToolStripMenuItem tsmiChallengerS;
        private System.Windows.Forms.ToolStripMenuItem tsmiMasterS;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiamondS;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlatinumS;
        private System.Windows.Forms.ToolStripMenuItem tsmiGoldS;
        private System.Windows.Forms.ToolStripMenuItem tsmiSilverS;
        private System.Windows.Forms.ToolStripMenuItem tsmiBronzeS;
        private System.Windows.Forms.ToolStripMenuItem tsmiIronS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem tsmiGrandmasterS;
        private System.Windows.Forms.ToolStripMenuItem tsmiGrandmasterF;
        private System.Windows.Forms.Label lblPhase;
        private System.Windows.Forms.Button btnAbout;
        public System.Windows.Forms.NumericUpDown nudPatch1;
        public System.Windows.Forms.NumericUpDown nudPatch2;
        private System.Windows.Forms.Button btnCounter;
        private System.Windows.Forms.ToolTip ttCounterPick;
        public System.Windows.Forms.CheckBox cbSearch;
        private System.Windows.Forms.Label lblTopWin;
        private System.Windows.Forms.Label lblSearch;
        public System.Windows.Forms.ComboBox cbRegion;
        public System.Windows.Forms.Label lblText;
    }
}

