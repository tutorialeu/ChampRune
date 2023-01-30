using PoniLCU;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChampRune
{
    public partial class RuneImporter : Form
    {
        //string ExportBuildString = "";
        //Button[,] skillOrderArray = new Button[4, 18];
        //int[,] skillorder = new int[4, 18];
        int selected = -1;
        int SLEEP_ONE = 200;
        int SLEEP_TWO = 400;
        int SLEEP_THREE = 1000;
        bool stop_actions = false;
        Point formLocation;
        IntPtr lolWindow;


        string[] keyStones = { "Precision", "Domination", "Sorcery", "Resolve", "Inspiration" };
        LeagueClient leagueClient;
        string imagePath;
        bool aram = false;

        [DllImport("kernel32.dll")]
        static extern int GetProcessId(IntPtr handle);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;


        void ChangeTextColorByRune(string keyStone, Label crtLabel)
        {
            if (keyStones[0] == keyStone)
            {
                crtLabel.ForeColor = Color.Yellow;
            }
            if (keyStones[1] == keyStone)
            {
                crtLabel.ForeColor = Color.Red;
            }
            if (keyStones[2] == keyStone)
            {
                crtLabel.ForeColor = Color.Pink;
            }
            if (keyStones[3] == keyStone)
            {
                crtLabel.ForeColor = Color.Green;
            }
            if (keyStones[4] == keyStone)
            {
                crtLabel.ForeColor = Color.AliceBlue;
            }
        }
        string phase = "";
        string oldPhase = "";
        public RuneImporter(string keyStoneTitle,
            string keyStone1,
            string keyStone2,
            string keyStone3,
            string keyStone4,
            string secondaryStoneTitle,
            string secondaryStone1,
            string secondaryStone2,
            string extra1,
            string extra2,
            string extra3,
            string spell1,
            string spell2,
            bool aram,
            string champName,
            string imagePath,
            string phase,
            Point formLocation
            )
        {
            InitializeComponent();
            leagueClient = new LeagueClient();
            RuneTitle.Text = keyStoneTitle;
            ChangeTextColorByRune(keyStoneTitle, RuneTitle);
            Rune1.Text = keyStone1;
            Rune2.Text = keyStone2;
            Rune3.Text = keyStone3;
            Rune4.Text = keyStone4;
            SecondaryPathTitle.Text = secondaryStoneTitle;
            ChangeTextColorByRune(secondaryStoneTitle, SecondaryPathTitle);
            SecondaryPath1.Text = secondaryStone1;
            SecondaryPath2.Text = secondaryStone2;
            extrarune1.Text = extra1;
            extrarune2.Text = extra2;
            extrarune3.Text = extra3;

            lblSpell1.Text = spell1;
            lblSpell2.Text = spell2;

            this.aram = aram;

            this.phase = phase;
            this.champName.Text = champName + " : " + phase;
            UpdateNameAndPhase();
            this.pbChampion.SizeMode = PictureBoxSizeMode.StretchImage;
            this.imagePath = imagePath;
            /*
            if (!leagueClient.IsConnected)
            {
                var clientNotDetected = new FormMessage("", "League of legends client is not detected!", formLocation.X + this.Width - 200, formLocation.Y + 100);
                clientNotDetected.ShowDialog();
            }
            */
            leagueClient.Subscribe("/lol-gameflow/v1/gameflow-phase", GameFlowPhase);
            this.formLocation = new Point(formLocation.X + 80, formLocation.Y);
            this.Location = this.formLocation;
        }
        private void GameFlowPhase(OnWebsocketEventArgs obj)
        {
            phase = obj.Data;
            //Debug.WriteLine("RuneImported Phase changed: " + phase);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
        private bool getpixelColor(int x, int y, int R, int G, int B, int spacex = 50, int spacey = 50)
        {
            //Console.WriteLine("start-----------------------------------------");
            Bitmap bmpScreenshot = new Bitmap(spacex, spacey);
            Graphics g = Graphics.FromImage(bmpScreenshot);
            RECT rct = new RECT();
            GetWindowRect(GetForegroundWindow(), ref rct);
            int centerX = x * (rct.Right - rct.Left) / 1600 + rct.Left;
            int centerY = y * (rct.Bottom - rct.Top) / 900 + rct.Top;
            g.CopyFromScreen(centerX - 25, centerY - 25, 0, 0, new Size(spacex, spacey));
            for (int x1 = 0; x1 < spacex; x1++)
            {
                for (int y1 = 0; y1 < spacey; y1++)
                {
                    //Console.Write(" color:");
                    //Console.Write(bmpScreenshot.GetPixel(x1, y1).R + ", ");
                    //Console.Write(bmpScreenshot.GetPixel(x1, y1).G + ", ");
                    //Console.Write(bmpScreenshot.GetPixel(x1, y1).B + ", ");
                    if (bmpScreenshot.GetPixel(x1, y1).R == R && bmpScreenshot.GetPixel(x1, y1).G == G && bmpScreenshot.GetPixel(x1, y1).B == B)
                    {

                        //Console.WriteLine("stop_True-----------------------------------------");
                        return true;
                    }
                }
            }
            //Console.WriteLine("stop_False-----------------------------------------");
            return false;
        }
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        const int MYACTION_HOTKEY_ID = 1;
        private void click(int x, int y)
        {
            SetForegroundWindow(lolWindow);
            RECT rct = new RECT();
            GetWindowRect(GetForegroundWindow(), ref rct);
            //Gives me position of window
            //1600x900 is the window size that I have created this in.
            //I need to scale the given points by the current window size
            //Ratio of 1600:current?
            Point pt = new Point(x * (rct.Right - rct.Left) / 1580 + rct.Left, y * (rct.Bottom - rct.Top) / 900 + rct.Top);
            Cursor.Position = pt;
            System.Threading.Thread.Sleep(SLEEP_ONE);
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            System.Threading.Thread.Sleep(SLEEP_ONE);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                stop_actions = true;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void SelectSpell(string name)
        {
            if (aram)
            {
                if (name.ToLower().Trim() == "clariy")
                {
                    name = "Smite";
                }
                else if (name.ToLower().Trim() == "mark")
                {
                    name = "Barrier";
                }
                else if (name.ToLower().Trim() == "barrier")
                {
                    name = "Ignite";
                }
                else if (name.ToLower().Trim() == "ignite")
                {
                    name = "Teleport";
                }
            }
            switch (name.ToLower().Trim())
            {
                case "cleanse":
                    click(783, 585);
                    break;
                case "exhaust":
                    click(853, 585);
                    break;
                case "flash":
                    click(923, 585);
                    break;
                case "ghost":
                    click(993, 585);
                    break;
                case "heal":
                    click(783, 665);
                    break;
                case "smite":
                    click(853, 665);
                    break;
                case "teleport":
                    click(923, 665);
                    break;
                case "ignite":
                    click(993, 665);
                    break;
                case "barrier":
                    click(783, 745);
                    break;
                default: break;

            }
            System.Threading.Thread.Sleep(SLEEP_ONE);
        }
        private void Import_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            Process[] processlist = Process.GetProcesses();
            lolWindow = IntPtr.Zero;
            bool ClientOppened = false;
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    //Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                    if (process.ProcessName == "LeagueClientUx")
                    {
                        lolWindow = process.MainWindowHandle;
                        ClientOppened = true;
                        break;
                    }
                }
            }
            if (!ClientOppened)
            {
                //Namespace, class, function stuffs
                //New thread BEFORE create message box - safety measure
                var result = new FormMessage("Do you wish to continue with the auto clicks?",
                    "League of legends client is not detected!",
                    MessageBoxButtons.YesNo,
                    this.Right - 300,
                    this.Bottom - 160).ShowDialog();
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            if (phase != "ChampSelect")
            {
                var result = new FormMessage("Do you wish to continue with the auto clicks?",
                    "You can't auto set runes while you're not on champ select!",
                    MessageBoxButtons.YesNo,
                    this.Right - 300,
                    this.Bottom - 160).ShowDialog();
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            InterceptKeys.OnKeyDown += new KeyEventHandler(externalKeyDown);
            InterceptKeys.Start();
            //IntPtr h = FindWindow(null, "LeagueClientUx");
            //Console.WriteLine("Hi: " + h.ToString());
            SetForegroundWindow(lolWindow);
            System.Threading.Thread.Sleep(SLEEP_ONE);
            bool runePageSelected = false;
            //Precision
            if (getpixelColor(283, 237, 174, 167, 137))
            {
                runePageSelected = true;
            }
            //Domination
            if (getpixelColor(290, 236, 212, 66, 66))
            {
                runePageSelected = true;
            }
            //Sorcery
            if (getpixelColor(287, 238, 157, 168, 248))
            {
                runePageSelected = true;
            }
            //Resolve
            if (getpixelColor(284, 237, 161, 213, 134))
            {
                runePageSelected = true;
            }
            //Inspiration
            if (getpixelColor(294, 239, 73, 170, 185))
            {
                runePageSelected = true;
            }
            if (cbAutoImportSpells.Checked)
            {
                // spell 1 auto select
                click(874, 853);
                System.Threading.Thread.Sleep(SLEEP_ONE);

                SelectSpell(lblSpell1.Text);
                // spell 2 auto select
                click(933, 853);
                System.Threading.Thread.Sleep(SLEEP_ONE);
                SelectSpell(lblSpell2.Text);
            }
            if (!runePageSelected)
            {
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                System.Threading.Thread.Sleep(SLEEP_ONE);
                click(564, 853);
                System.Threading.Thread.Sleep(SLEEP_THREE);
            }
            //fixRuneSelectionBug();
            if (stop_actions)
            {
                stop_actions = false;
                return;
            }
            //click(211, 264);

            if (selected != -1)
            {
                if (keyStones[selected] != RuneTitle.Text)
                {
                    for (int i = 0; i < keyStones.Length; i++)
                    {
                        if (RuneTitle.Text == keyStones[i])
                        {
                            if (stop_actions)
                            {
                                stop_actions = false;
                                return;
                            }
                            click(300 + (i * 50), 264);
                            keyStones[i] = "";
                        }
                    }
                }
                else
                {
                    keyStones[selected] = "";
                }
            }
            else
            {
                for (int i = 0; i < keyStones.Length; i++)
                {
                    if (RuneTitle.Text == keyStones[i])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(300 + (i * 50), 264);
                        keyStones[i] = "";
                    }
                }
            }

            string[,] rune1_3 = {
                                { "SummonAery", "GraspOfTheUndying", "GlacialAugment" },
                                { "ArcaneComet", "Aftershock", "UnsealedSpellbook" },
                                { "PhaseRush", "Guardian", "PrototypeOmnistone" } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Rune1.Text == rune1_3[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(300 + (i * 100), 412);
                    }
                }
            }
            string[,] rune1_4 = {
                                { "PressTheAttack", "Electrocute" },
                                { "LethalTempoTemp", "Predator" },
                                { "FleetFootwork", "DarkHarvest" },
                                { "Conqueror", "HailOfBlades" } };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (Rune1.Text == rune1_4[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(300 + (i * 70), 412);
                    }
                }
            }
            string[,] rune2_5 = {
                                {"Overheal","CheapShot","NullifyingOrb","Demolish","HextechFlashtraption"},
                                { "Triumph", "TasteOfBlood", "ManaflowBand", "FontOfLife", "MagicalFootwear"},
                                { "PresenceOfMind", "SuddenImpact", "NimbusCloak", "MirrorShell", "PerfectTiming" }
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Rune2.Text == rune2_5[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(318 + (i * 75), 536);
                    }
                }
            }
            string[,] rune3_5 = {
                                {"LegendAlacrity","ZombieWard","Transcendence","Conditioning","FuturesMarket"},
                                {"LegendTenacity","GhostPoro","Celerity","SecondWind","MinionDematerializer"},
                                {"LegendBloodline","EyeballCollection","AbsoluteFocus","BonePlating","BiscuitDelivery"}
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Rune3.Text == rune3_5[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(318 + (i * 75), 645);
                    }
                }
            }
            string[,] rune4_4 = {
                            {"CoupDeGrace","Scorch","Overgrowth","CosmicInsight"},
                            {"CutDown","Waterwalking","Revitalize","ApproachVelocity"},
                            {"LastStand","GatheringStorm","Unflinching","TimeWarpTonic"}
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Rune4.Text == rune4_4[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(318 + (i * 75), 753);
                    }
                }
            }
            string[,] rune4_1 =
            {
                            {"TreasureHunter"},{"IngeniousHunter"},{"RelentlessHunter"},{"UltimateHunter"}
            };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (Rune4.Text == rune4_1[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(307 + (i * 65), 753);
                    }
                }
            }

            System.Threading.Thread.Sleep(SLEEP_ONE);
            //secondary Name
            bool sub = false;
            for (int i = 0; i < keyStones.Length; i++)
            {
                if (SecondaryPathTitle.Text == keyStones[i])
                {
                    if (sub)
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(714 + ((i - 1) * 55), 264);
                    }
                    else
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(714 + (i * 55), 264);
                    }
                }
                if (keyStones[i] == "")
                {
                    sub = true;
                }
            }
            //System.Threading.Thread.Sleep(200);
            //click(623, 270);
            //rune1 secondary
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (SecondaryPath1.Text == rune2_5[i, j] || SecondaryPath2.Text == rune2_5[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(726 + (i * 75), 371);
                    }
                }
            }
            //rune2 secondary
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (SecondaryPath1.Text == rune3_5[i, j] || SecondaryPath2.Text == rune3_5[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(726 + (i * 75), 469);
                    }
                }
            }
            //rune3 secondary
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (SecondaryPath1.Text == rune4_4[i, j] || SecondaryPath2.Text == rune4_4[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(726 + (i * 75), 568);
                    }
                }
            }
            //rune3 secondary
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (SecondaryPath1.Text == rune4_1[i, j] || SecondaryPath2.Text == rune4_1[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(714 + (i * 65), 568);
                    }
                }
            }
            System.Threading.Thread.Sleep(SLEEP_ONE);
            if (stop_actions)
            {
                stop_actions = false;
                return;
            }
            //click(616, 643);
            string[,] extrarune3_1 =
            {
                {"Adaptive Force"},{"Attack Speed"},{"Ability Haste"}
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (extrarune1.Text == extrarune3_1[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(725 + (i * 82), 643);
                    }
                }
            }
            if (stop_actions)
            {
                stop_actions = false;
                return;
            }
            //click(616, 700);
            string[,] extrarune23_1 =
            {
                {"Adaptive Force"},{"Armor"},{"Magic Resist"}
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (extrarune2.Text == extrarune23_1[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(725 + (i * 82), 700);
                    }
                }
            }
            if (stop_actions)
            {
                stop_actions = true;
                return;
            }
            //click(616, 756);
            string[,] extrarune33_1 =
            {
                {"Health"},{"Armor"},{"Magic Resist"}
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (extrarune3.Text == extrarune33_1[i, j])
                    {
                        if (stop_actions)
                        {
                            stop_actions = false;
                            return;
                        }
                        click(725 + (i * 82), 756);
                    }
                }
            }
            if (cbAutoCloseRunePage.Checked)
            {
                System.Threading.Thread.Sleep(SLEEP_TWO);
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(890, 157);
                System.Threading.Thread.Sleep(SLEEP_TWO);
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(1457, 94);
            }
            if (cbAutoCloseAfterImport.Checked)
            {
                this.Close();
            }
        }
        private void fixRuneSelectionBug()
        {

            /*String[] keyStones = { "Precision", "Domination", "Sorcery", "Resolve", "Inspiration" };
            for (int i = 0; i < keyStones.Length; i++)
            {
                if (RuneTitle.Text == keyStones[i])
                {
                    click(300 + (i * 50), 264);
                    keyStones[i] = "";
                }
            }*/
            //Precision
            if (getpixelColor(689, 236, 174, 167, 137))
            {
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(211, 264);
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(300, 264);
                selected = 0;
            }
            //Domination
            if (getpixelColor(708, 236, 212, 66, 66))
            {
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(211, 264);
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(350, 264);
                selected = 1;
            }
            //Sorcery
            if (getpixelColor(705, 237, 159, 170, 252))
            {
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(211, 264);
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(400, 264);
                selected = 2;
            }
            //Resolve
            if (getpixelColor(689, 234, 161, 213, 134))
            {
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(211, 264);
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(450, 264);
                selected = 3;
            }
            //Inspiration
            if (getpixelColor(701, 238, 73, 170, 185))
            {
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(211, 264);
                if (stop_actions)
                {
                    stop_actions = false;
                    return;
                }
                click(500, 264);
                selected = 4;
            }
            //int centerX2 = 621 + rct.Left;
            //int centerY2 = 257 + rct.Top; sorc and resolve
            //Domination: 616 256
            //Inspiration: 615 267
            //Precision: 623 265
        }

        private void UpdateNameAndPhase()
        {
            this.champName.Text = champName.Text.Split(':')[0] + ": " + (string.IsNullOrEmpty(phase) ? "Unknown" : phase);
            this.champName.Location = new Point(this.pbChampion.Right - this.champName.Width, this.champName.Location.Y);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            RECT rct = new RECT();
            GetWindowRect(GetForegroundWindow(), ref rct);
            Position.Text = "X: " + (Cursor.Position.X - rct.Left) + " Y:" + (Cursor.Position.Y - rct.Top);

            if (phase != oldPhase)
            {
                UpdateNameAndPhase();
            }

            if (oldPhase != phase)
            {
                oldPhase = phase;
            }

        }
        void externalKeyDown(object sender, KeyEventArgs e)
        {
            // Some code for closing you form
            // or any thing you need after press Esc
            // with e.KeyCode
            if (e.KeyCode == Keys.Escape)
            {
                stop_actions = true;
            }
        }

        private void RuneImporter_Load(object sender, EventArgs e)
        {
            try
            {
                if (imagePath.Split('.').Last().ToLower() == "webp")
                {
                    //imagePath = imagePath.Replace("/", "_");
                    //imagePath = imagePath.Split('.')[0].Split('_').Last();
                    imagePath = imagePath.Remove(imagePath.Count() - 4) + "png";
                }
                this.pbChampion.LoadAsync(imagePath);
                timer1.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.Name + " can't import image. Error message: " + ex.Message);
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void RuneImporter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            else
            {
                stop_actions = true;
            }
        }

        private void RuneImporter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                this.Close();
            }
        }

        private void cbSwitchSpells_CheckedChanged(object sender, EventArgs e)
        {
            var aux = lblSpell1.Text;
            lblSpell1.Text = lblSpell2.Text;
            lblSpell2.Text = aux;
        }
    }
}
