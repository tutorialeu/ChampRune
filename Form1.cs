using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using ChampRune.Properties;

namespace ChampRune
{
    public partial class frmMain : Form
    {
        private string workingDirectory = Application.ExecutablePath;
        //private string[] names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        private Dictionary<string, Button> champList;
        private Dictionary<string, string> runeList;
        private Dictionary<string, string> runeList2;
        private int champWidth = 60;
        private int champHeight = 60;
        private int STACKS = 20;
        private Graphics g;
        private string[] lains = { "TOP", "MID", "ADC", "JUN", "SUP" };

        private Dictionary<string, float> adcListNames = new Dictionary<string, float>()
        {
            {"Swain", 54.83f},
            {"Ziggs", 53.84f},
            {"Veigar", 53.06f},
            {"KogMaw", 52.02f},
            {"Ashe", 51.84f},
            {"Yasuo", 51.68f},
            {"Vayne", 51.46f},
            {"Sivir", 51.07f},
            {"Jhin", 50.77f},
            {"Draven", 50.58f},
            {"MissFortune", 50.41f},
            {"Tristana", 50.33f},
            {"Twitch", 50.05f},
            {"Samira", 49.94f},
            {"Jinx", 49.92f},
            {"Ezreal", 49.28f},
            {"Caitlyn", 49.24f},
            {"Varus", 48.95f},
            {"Kaisa", 48.85f},
            {"Aphelios", 48.49f},
            {"Xayah", 48.21f},
            {"Kalista", 47.48f},
            {"Lucian", 46.68f},
            {"Akshan", 44.74f}
        };

        private Dictionary<string, float> topListNames = new Dictionary<string, float>()
        {
            {"Lillia", 53.27f},
            {"Yorick", 52.46f},
            {"TahmKench", 52.26f},
            {"DrMundo", 52.17f},
            {"Graves", 51.81f},
            {"Garen", 51.69f},
            {"Kled", 51.67f},
            {"Nasus", 51.66f},
            {"Wukong", 51.59f},
            {"Urgot", 51.50f},
            {"Illaoi", 51.24f},
            {"Camille", 51.19f},
            {"Kayle", 51.13f},
            {"Ornn", 51.11f},
            {"Singed", 51.09f},
            {"Fiora", 51.05f},
            {"Sett", 51.02f},
            {"Malphite", 50.82f},
            {"Shen", 50.80f},
            {"Trundle", 50.71f},
            {"Irelia", 50.68f},
            {"Heimerdinger", 50.66f},
            {"Sion", 50.65f},
            {"Quinn", 50.65f},
            {"Warwick", 50.64f},
            {"Teemo", 50.58f},
            {"Cassiopeia", 50.54f},
            {"Mordekaiser", 50.51f},
            {"Jax", 50.47f},
            {"Kennen", 50.15f},
            {"Chogath", 50.11f},
            {"Riven", 50.00f},
            {"Poppy", 49.75f},
            {"Vayne", 49.74f},
            {"Tryndamere", 49.55f},
            {"Volibear", 49.46f},
            {"Aatrox", 49.23f},
            {"Gnar", 49.08f},
            {"Rengar", 49.08f},
            {"Yasuo", 48.89f},
            {"Pantheon", 48.63f},
            {"Darius", 48.21f},
            {"Rumble", 48.02f},
            {"Yone", 47.95f},
            {"Vladimir", 47.83f},
            {"Nocturne", 47.60f},
            {"Sylas", 47.46f},
            {"Ryze", 47.07f},
            {"Jayce", 47.03f},
            {"Renekton", 46.99f},
            {"Akali", 46.78f},
            {"Viego", 46.71f},
            {"LeeSin", 46.39f},
            {"Lucian", 46.33f},
            {"Gangplank", 46.25f},
            {"Gwen", 45.34f},
            {"Akshan", 44.09f}
        };

        private Dictionary<string, float> midListNames = new Dictionary<string, float>()
        {
            {"Graves", 54.11f},
            {"Kayle", 53.36f},
            {"Mordekaiser", 52.89f},
            {"Garen", 52.82f},
            {"Kennen", 52.79f},
            {"Malzahar", 52.50f},
            {"Sett", 52.32f},
            {"Annie", 52.32f},
            {"Heimerdinger", 52.28f},
            {"Brand", 52.27f},
            {"Pyke", 51.94f},
            {"Anivia", 51.91f},
            {"Velkoz", 51.91f},
            {"Irelia", 51.82f},
            {"Yasuo", 51.53f},
            {"Malphite", 51.45f},
            {"Corki", 51.37f},
            {"Xerath", 51.32f},
            {"Ziggs", 51.30f},
            {"Morgana", 51.24f},
            {"Lux", 51.19f},
            {"Viktor", 51.17f},
            {"Diana", 51.15f},
            {"Ahri", 50.93f},
            {"Veigar", 50.81f},
            {"Tristana", 50.79f},
            {"Ekko", 50.71f},
            {"Pantheon", 50.69f},
            {"Yone", 50.53f},
            {"Fizz", 50.42f},
            {"AurelionSol", 50.39f},
            {"Talon", 50.35f},
            {"Neeko", 50.31f},
            {"Katarina", 50.27f},
            {"Lissandra", 50.23f},
            {"Kassadin", 50.16f},
            {"Galio", 50.10f},
            {"Cassiopeia", 50.02f},
            {"Renekton", 49.96f},
            {"Vladimir", 49.92f},
            {"Zed", 49.70f},
            {"Viego", 49.56f},
            {"Leblanc", 49.25f},
            {"Jayce", 49.04f},
            {"LeeSin", 48.74f},
            {"Sylas", 48.47f},
            {"TwistedFate", 47.76f},
            {"Akshan", 47.58f},
            {"Syndra", 47.50f},
            {"Orianna", 47.44f},
            {"Qiyana", 46.99f},
            {"Akali", 46.97f},
            {"Ryze", 46.82f},
            {"Zoe", 46.75f},
            {"Lucian", 46.23f},
            {"Azir", 46.10f},
            {"Ezreal", 45.02f}
        };

        private Dictionary<string, float> junListNames = new Dictionary<string, float>()
        {
            {"Trundle", 52.56f},
            {"Amumu", 51.93f},
            {"Vi", 51.90f},
            {"Zac", 51.75f},
            {"MasterYi", 51.63f},
            {"XinZhao", 51.57f},
            {"Shyvana", 51.49f},
            {"Nocturne", 51.48f},
            {"Rammus", 51.46f},
            {"Mordekaiser", 51.38f},
            {"Warwick", 51.33f},
            {"Fiddlesticks", 51.17f},
            {"Volibear", 51.00f},
            {"Skarner", 50.94f},
            {"Wukong", 50.64f},
            {"Diana", 50.49f},
            {"Poppy", 50.43f},
            {"Lillia", 50.43f},
            {"Kayn", 50.35f},
            {"Jax", 50.31f},
            {"Viego", 50.18f},
            {"Sejuani", 50.17f},
            {"JarvanIV", 50.17f},
            {"Ekko", 49.96f},
            {"Khazix", 49.94f},
            {"Elise", 49.89f},
            {"Karthus", 49.73f},
            {"Ivern", 49.70f},
            {"DrMundo", 49.65f},
            {"Nunu", 49.61f},
            {"RekSai", 49.56f},
            {"Kindred", 49.54f},
            {"Graves", 49.46f},
            {"Evelynn", 49.40f},
            {"Taliyah", 49.16f},
            {"LeeSin", 49.09f},
            {"Nasus", 49.03f},
            {"Hecarim", 49.01f},
            {"Shaco", 48.88f},
            {"Nidalee", 48.34f},
            {"Udyr", 48.22f},
            {"Olaf", 48.14f},
            {"Gragas", 47.56f},
            {"Tryndamere", 46.86f},
            {"Gwen", 45.84f},
            {"Twitch", 45.47f},
            {"Rumble", 45.39f},
            {"Rengar", 45.38f}
        };

        private Dictionary<string, float> supListNames = new Dictionary<string, float>()
        {
            {"Zyra", 52.78f},
            {"Brand", 52.55f},
            {"Maokai", 52.16f},
            {"Zilean", 52.00f},
            {"Swain", 51.81f},
            {"Blitzcrank", 51.78f},
            {"Xerath", 51.63f},
            {"Sona", 51.15f},
            {"Velkoz", 51.14f},
            {"Taric", 51.13f},
            {"Nami", 51.12f},
            {"Soraka", 51.09f},
            {"Leona", 50.97f},
            {"Janna", 50.72f},
            {"Rell", 50.71f},
            {"Braum", 50.66f},
            {"Morgana", 50.58f},
            {"Lulu", 50.34f},
            {"Shaco", 50.27f},
            {"Lux", 50.18f},
            {"Ziggs", 50.13f},
            {"Alistar", 50.00f},
            {"Nautilus", 49.95f},
            {"Bard", 49.92f},
            {"Veigar", 49.70f},
            {"Seraphine", 49.35f},
            {"Senna", 49.34f},
            {"Pyke", 49.34f},
            {"Shen", 49.15f},
            {"Rakan", 49.03f},
            {"Yuumi", 49.01f},
            {"Thresh", 48.74f},
            {"Neeko", 48.60f},
            {"Galio", 48.52f},
            {"Anivia", 48.13f},
            {"Malphite", 47.88f},
            {"Karma", 47.72f},
            {"Ashe", 47.71f},
            {"Pantheon", 47.62f},
            {"Teemo", 47.40f},
            {"TahmKench", 47.21f},
            {"MissFortune", 45.81f},
            {"Sett", 45.67f}
        };

        private string[] allChampNames =
        {
            "Aatrox", "Ahri", "Akali", "Akshan", "Alistar", "Amumu", "Anivia", "Annie", "Aphelios", "Ashe",
            "AurelionSol", "Azir",
            "Bard", "Blitzcrank", "Brand", "Braum", "Caitlyn", "Camille", "Cassiopeia", "Chogath", "Corki",
            "Darius", "Diana", "Draven", "DrMundo", "Ekko", "Elise", "Evelynn", "Ezreal", "Fiddlesticks", "Fiora",
            "Fizz",
            "Galio", "Gangplank", "Garen", "Gnar", "Gragas", "Graves", "Gwen", "Hecarim", "Heimerdinger", "Illaoi",
            "Irelia", "Ivern", "Janna", "JarvanIV", "Jax", "Jayce", "Jhin", "Jinx", "Kaisa", "Kalista", "Karma",
            "Karthus", "Kassadin", "Katarina", "Kayle", "Kayn",
            "Kennen", "Khazix", "Kindred", "Kled", "KogMaw", "Leblanc", "LeeSin", "Leona", "Lillia", "Lissandra",
            "Lucian", "Lulu", "Lux", "Malphite", "Malzahar",
            "Maokai", "MasterYi", "MissFortune", "Mordekaiser", "Morgana", "Nami", "Nasus", "Nautilus", "Neeko",
            "Nidalee", "Nocturne", "Nunu", "Olaf", "Orianna",
            "Ornn", "Pantheon", "Poppy", "Pyke", "Qiyana", "Quinn", "Rakan", "Rammus", "RekSai", "Rell", "Renekton",
            "Rengar", "Riven", "Rumble", "Ryze", "Samira",
            "Sejuani", "Senna", "Seraphine", "Sett", "Shaco", "Shen", "Shyvana", "Singed", "Sion", "Sivir", "Skarner",
            "Sona", "Soraka", "Swain", "Sylas", "Syndra",
            "TahmKench", "Taliyah", "Talon", "Taric", "Teemo", "Thresh", "Tristana", "Trundle", "Tryndamere",
            "TwistedFate", "Twitch", "Udyr", "Urgot", "Varus", "Vayne",
            "Veigar", "Velkoz", "Vi", "Viego", "Viktor", "Vladimir", "Volibear", "Warwick", "Wukong", "Xayah", "Xerath",
            "XinZhao", "Yasuo", "Yone", "Yorick", "Yuumi", "Zac",
            "Zed", "Ziggs", "Zilean", "Zoe", "Zyra"
        };

        public frmMain()
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();
            DirectoryInfo champDir = new DirectoryInfo(Path.GetDirectoryName(workingDirectory) + @"\Champ\");
            DirectoryInfo runesDir = new DirectoryInfo(Path.GetDirectoryName(workingDirectory) + @"\Runes115\");
            FileInfo[] fChamp = champDir.GetFiles("*.png");
            champList = new Dictionary<string, Button>();
            runeList = new Dictionary<string, string>();
            runeList2 = new Dictionary<string, string>();
            this.AutoScroll = true;
            tpChamp.AutoSize = true;
            tpChamp.AutoScroll = true;
            int locX = 0, locY = 0;
            foreach (var file in fChamp)
            {
                Button b = new Button();
                Image crtImg = Image.FromFile(file.FullName);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                b.Size = new Size(champWidth, champHeight);
                b.BackgroundImage = crtImg;
                b.Location = new Point(locX, locY);
                string ChampName = file.Name.Split('.')[0];
                b.Name = ChampName;
                b.MouseHover += Btn_MouseHover;
                b.Click += Btn_Click;
                Debug.Write("\"" + b.Name + "\", ");
                if (locX + b.Width < champWidth * STACKS)
                {
                    locX += b.Width;
                }
                else
                {
                    locX = 0;
                    locY += b.Height;
                }

                champList.Add(ChampName, b);
            }

            FileInfo[] fRune = runesDir.GetFiles("*.png");
            foreach (var file in fRune)
            {
                if (file.Name.Split('_')[1].EndsWith("2"))
                {
                    runeList2.Add(file.Name.Split('_')[0] + file.Name.Split('_')[1], file.FullName);
                }
                else
                {
                    runeList.Add(file.Name.Split('_')[0] + file.Name.Split('_')[1], file.FullName);
                }
            }

            //this.Size = new Size(tpChamp.Size.Width + DefaultMargin.Horizontal,
            //tpChamp.Size.Height + btnTop.Height + lblSearch.Height + SystemInformation.CaptionHeight);
            foreach (var key in champList.Keys)
            {
                tpChamp.Controls.Add(champList[key]);
            }

            g = this.CreateGraphics();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Button btn = sender as Button;
            tcRuneLain.TabPages.Clear();
            tcItems.TabPages.Clear();
            int index = 0;
            foreach (string lain in lains)
            {
                string page1 = btn.Name + lain;
                string page2 = btn.Name + lain + "2";
                if (runeList.Keys.Contains(page1))
                {
                    if (!tcRuneLain.TabPages.ContainsKey(lain))
                    {
                        TabPage tp = new TabPage();
                        tp.Name = lain;
                        tp.Text = lain;
                        tp.Enabled = true;
                        tp.BackgroundImage = Image.FromFile(runeList[page1]);
                        tp.BackgroundImageLayout = ImageLayout.None;
                        tcRuneLain.TabPages.Insert(tcRuneLain.TabPages.Count, tp);
                        tcRuneLain.SelectedTab = tp;
                    }
                }

                if (runeList2.Keys.Contains(page2))
                {
                    if (!tcItems.TabPages.ContainsKey(lain))
                    {
                        TabPage tp = new TabPage();
                        tp.Name = lain;
                        tp.Text = lain;
                        tp.Enabled = true;
                        tp.BackgroundImage = Image.FromFile(runeList2[page2]);
                        tp.BackgroundImageLayout = ImageLayout.None;
                        tcItems.TabPages.Insert(tcItems.TabPages.Count, tp);
                        tcItems.SelectedTab = tp;
                    }
                }

                index++;
            }

            tcItems.Show();
            tcItems.Refresh();
            tcRuneLain.Show();
            tcRuneLain.Refresh();
            tcPages.SelectedTab = tcPages.TabPages[1];
            if (btnTop.Enabled == false)
            {
                SwitchTabToLain(lains[0]);
            }
            else if (btnMid.Enabled == false)
            {
                SwitchTabToLain(lains[1]);
            }
            else if (btnAdc.Enabled == false)
            {
                SwitchTabToLain(lains[2]);
            }
            else if (btnJun.Enabled == false)
            {
                SwitchTabToLain(lains[3]);
            }
            else if (btnSup.Enabled == false)
            {
                SwitchTabToLain(lains[3]);
            }
            Cursor.Current = Cursors.Default;
        }

        void SwitchTabToLain(string lain)
        {
            if (tcRuneLain.TabPages.ContainsKey(lain))
            {
                foreach (TabPage tp in tcItems.TabPages)
                {
                    if (tp.Name == lain)
                    {
                        tcRuneLain.SelectedIndex = tp.TabIndex;
                        return;
                    }
                }
            }
        }

        private void DrawMessage(string message)
        {
            Brush b = new SolidBrush(Color.Black);
            Font drawFont = new Font("Arial", 16);
            g.Clear(SystemColors.Control);
            g.DrawString(message, drawFont, b, 360, 60);
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btnAll.Enabled == false)
            {
                DrawMessage(btn.Name);
                return;
            }
            if (topListNames.Keys.Contains(btn.Name))
            {
                if (btnTop.Enabled == false)
                {
                    DrawMessage(btn.Name + " | TOP win rate: " + topListNames[btn.Name]);
                }
            }
            if (midListNames.Keys.Contains(btn.Name))
            {
                if (btnMid.Enabled == false)
                {
                    DrawMessage(btn.Name + " | MID win rate: " + midListNames[btn.Name]);
                }
            }
            if (adcListNames.Keys.Contains(btn.Name))
            {
                if (btnAdc.Enabled == false)
                {
                    DrawMessage(btn.Name + " | ADC win rate: " + adcListNames[btn.Name]);
                }
            }
            if (junListNames.Keys.Contains(btn.Name))
            {
                if (btnJun.Enabled == false)
                {
                    DrawMessage(btn.Name + " | JUN win rate: " + junListNames[btn.Name]);
                }
            }
            if (supListNames.Keys.Contains(btn.Name))
            {
                if (btnSup.Enabled == false)
                {
                    DrawMessage(btn.Name + " | SUP win rate: " + supListNames[btn.Name]);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnAll.Enabled = false;
            tbSearch.Focus();
            cbPatch.SelectedIndex = 0;
            tcItems.SelectedIndexChanged += TcItems_SelectedIndexChanged;
            tcRuneLain.SelectedIndexChanged += TcRuneLain_SelectedIndexChanged;
            tbSize.Text = champWidth.ToString();
            this.Cursor = Cursors.Default;
            try
            {
                SavedItems si = XMLSaveData.DeserializeToObject<SavedItems>(Path.GetDirectoryName(workingDirectory) + @"\\save.data");
                tbSize.Text = si.size.ToString();
                nudStack.Value = decimal.Parse(si.stack.ToString());
                UpdatePicSize();
                SwitchToAllChamps();
            }
            catch
            {
                SavedItems si = new SavedItems();
                si.size = 60;
                si.stack = 20;
                tbSize.Text = "60";
                nudStack.Value = 20;
                XMLSaveData.SerializeToXml(si, Path.GetDirectoryName(workingDirectory) + @"\\save.data");
                UpdatePicSize();
                SwitchToAllChamps();
            }
        }

        void UpdateSavedFile()
        {
            try
            {
                SavedItems si = new SavedItems();
                si.size = int.Parse(tbSize.Text);
                si.stack = int.Parse(nudStack.Value.ToString());
                XMLSaveData.SerializeToXml(si, Path.GetDirectoryName(workingDirectory) + @"\\save.data");
            }
            catch
            {
                SavedItems si = new SavedItems();
                si.size = 60;
                si.stack = 20;
                XMLSaveData.SerializeToXml(si, Path.GetDirectoryName(workingDirectory) + @"\\save.data");
            }
        }

        private void TcItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcRuneLain.SelectedIndex != tcItems.SelectedIndex)
            {
                try
                {
                    tcRuneLain.SelectedIndex = tcItems.SelectedIndex;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Excetion in: TcItems_SelectedIndexChanged: " + ex.Message);
                }
            }
        }

        private void TcRuneLain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcItems.SelectedIndex != tcRuneLain.SelectedIndex)
            {
                try
                {
                    tcItems.SelectedIndex = tcRuneLain.SelectedIndex;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Excetion in: TcItems_SelectedIndexChanged: " + ex.Message);
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            btnAll.Enabled = false;
            btnTop.Enabled = true;
            btnMid.Enabled = true;
            btnAdc.Enabled = true;
            btnJun.Enabled = true;
            btnSup.Enabled = true;
            tcPages.SelectedIndex = 0;
            int locX = 0, locY = 0;
            foreach (var key in champList.Keys)
            {
                if (champList[key].Name.ToLower().StartsWith(tbSearch.Text.ToLower()))
                {
                    champList[key].Visible = true;
                    champList[key].Location = new Point(locX, locY);
                    if (locX + champList[key].Width < champWidth * STACKS)
                    {
                        locX += champList[key].Width;
                    }
                    else
                    {
                        locX = 0;
                        locY += champList[key].Height;
                    }
                }
                else
                {
                    champList[key].Visible = false;
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        void SwitchToListNames(string[] names)
        {
            int locX = 0, locY = 0;
            foreach (string key in champList.Keys)
            {
                champList[key].Visible = false;
            }
            foreach (var name in names)
            {
                champList[name].Visible = true;
                champList[name].Location = new Point(locX, locY);
                if (locX + champList[name].Width < champWidth * STACKS)
                {
                    locX += champList[name].Width;
                }
                else
                {
                    locX = 0;
                    locY += champList[name].Height;
                }
            }
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            btnTop.Enabled = false;
            btnAll.Enabled = true;
            btnMid.Enabled = true;
            btnAdc.Enabled = true;
            btnJun.Enabled = true;
            btnSup.Enabled = true;
            llLinks.Text = @"https://tutorialeu.com/lol15/#top";
            tcPages.SelectedTab = tcPages.TabPages[0];
            tbSearch.Focus();
            List<string> elements = new List<string>();
            foreach (KeyValuePair<string, float> vals in topListNames.OrderByDescending(key => key.Value))
            {
                elements.Add(vals.Key);
            }
            SwitchToListNames(elements.ToArray());

        }

        private void btnMid_Click(object sender, EventArgs e)
        {
            btnMid.Enabled = false;
            btnAdc.Enabled = true;
            btnAll.Enabled = true;
            btnTop.Enabled = true;
            btnJun.Enabled = true;
            btnSup.Enabled = true;
            llLinks.Text = @"https://tutorialeu.com/lol15/#mid";
            tcPages.SelectedTab = tcPages.TabPages[0];
            tbSearch.Focus();
            List<string> elements = new List<string>();
            foreach (KeyValuePair<string, float> vals in midListNames.OrderByDescending(key => key.Value))
            {
                elements.Add(vals.Key);
            }
            SwitchToListNames(elements.ToArray());
        }

        private void btnAdc_Click(object sender, EventArgs e)
        {
            btnAdc.Enabled = false;
            btnMid.Enabled = true;
            btnAll.Enabled = true;
            btnTop.Enabled = true;
            btnJun.Enabled = true;
            btnSup.Enabled = true;
            llLinks.Text = @"https://tutorialeu.com/lol15/#adc";
            tcPages.SelectedTab = tcPages.TabPages[0];
            tbSearch.Focus();
            List<string> elements = new List<string>();
            foreach (KeyValuePair<string, float> vals in adcListNames.OrderByDescending(key => key.Value))
            {
                elements.Add(vals.Key);
            }
            SwitchToListNames(elements.ToArray());
        }

        private void btnJun_Click(object sender, EventArgs e)
        {
            btnJun.Enabled = false;
            btnAdc.Enabled = true;
            btnMid.Enabled = true;
            btnAll.Enabled = true;
            btnTop.Enabled = true;
            btnSup.Enabled = true;
            llLinks.Text = @"https://tutorialeu.com/lol15/#jun";
            tcPages.SelectedTab = tcPages.TabPages[0];
            List<string> elements = new List<string>();
            foreach (KeyValuePair<string, float> vals in junListNames.OrderByDescending(key => key.Value))
            {
                elements.Add(vals.Key);
            }
            SwitchToListNames(elements.ToArray());
            tbSearch.Focus();
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            btnSup.Enabled = false;
            btnJun.Enabled = true;
            btnAdc.Enabled = true;
            btnMid.Enabled = true;
            btnAll.Enabled = true;
            btnTop.Enabled = true;
            llLinks.Text = @"https://tutorialeu.com/lol15/#sup";
            tcPages.SelectedTab = tcPages.TabPages[0];
            List<string> elements = new List<string>();
            foreach (KeyValuePair<string, float> vals in supListNames.OrderByDescending(key => key.Value))
            {
                elements.Add(vals.Key);
            }
            SwitchToListNames(elements.ToArray());
            tbSearch.Focus();
        }

        void SwitchToAllChamps()
        {
            btnAll.Enabled = false;
            btnSup.Enabled = true;
            btnJun.Enabled = true;
            btnAdc.Enabled = true;
            btnMid.Enabled = true;
            btnTop.Enabled = true;
            llLinks.Text = @"https://tutorialeu.com";
            tcPages.SelectedTab = tcPages.TabPages[0];
            tbSearch.Focus();
            int locX = 0, locY = 0;
            foreach (var key in champList.Keys)
            {
                champList[key].Visible = true;
                champList[key].Location = new Point(locX, locY);
                if (locX + champList[key].Width < champWidth * STACKS)
                {
                    locX += champList[key].Width;
                }
                else
                {
                    locX = 0;
                    locY += champList[key].Height;
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            SwitchToAllChamps();
        }

        private void btnTop_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("TOP");
        }

        private void btnMid_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("MID");
        }

        private void btnAdc_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("ADC");
        }

        private void btnJun_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("JUN");
        }

        private void btnSup_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("SUP");
        }

        private void btnAll_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("ALL");
        }

        private void cbPatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPatch.SelectedIndex != 0)
            {
                MessageBox.Show(this, "Patch not added yet!");
                cbPatch.SelectedIndex = 0;
            }
        }

        private void nudStack_ValueChanged(object sender, EventArgs e)
        {
            STACKS = int.Parse(nudStack.Value.ToString());
            SwitchToAllChamps();
            UpdateSavedFile();
        }
        private void tbSize_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                int val;
                try
                {
                    val = int.Parse(tbSize.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "You haven't entered a valid size: " + ex.Message);
                    return;
                }

                if (val >= 60 && val <= 100)
                {
                    UpdatePicSize();
                    SwitchToAllChamps();
                    UpdateSavedFile();
                }
                else
                {
                    MessageBox.Show(this, "Try a value between 60 and 100");
                }
            }
        }
        void UpdatePicSize()
        {
            champWidth = int.Parse(tbSize.Text);
            champHeight = int.Parse(tbSize.Text);
            foreach (var key in champList.Keys)
            {
                champList[key].Size = new Size(champWidth, champHeight);
            }
        }
        private void tbSize_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("Press enter to validate!");
        }

        private void llLinks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(llLinks.Text);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateSavedFile();
        }
    }
}
