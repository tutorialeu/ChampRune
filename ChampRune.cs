using CefSharp;
using CefSharp.WinForms;
using HtmlAgilityPack;
using PoniLCU;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace ChampRune
{
    public partial class frmMain : Form
    {
        #region declarations
        private string workingDirectory = Application.ExecutablePath;
        //private string[] names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        private Dictionary<string, Champion> champions;
        private List<string> cpChamps;
        private List<string> cpLains;
        PictureBox backbroundPictureBox;
        LeagueClient leagueClient;
        private int champWidth = 60;
        private int champHeight = 60;
        private int STACKS = 10;
        private string selectedPatch = "";
        private int selectedType = 0;
        private int selectedRank = 5;
        private string backgroundLink = "";
        private string region = "";
        private int DEFAULT_BUTTON_LOCATION = 64;
        private int DEFAULT_WIDTH = 960;
        private int DEFAULT_HEIGHT = 1020;
        private Graphics g;
        private List<string> regions = new List<string> { "na1", "euw1", "eun1", "kr", "br1", "jp1", "ru", "oc1", "tr1", "la1", "la2" };
        private string[] lains = { "TOP", "MID", "ADC", "JUN", "SUP" };
        private string[] defaultRuneNames = { "Precision", "Domination", "Sorcery", "Resolve", "Inspiration" };
        private string[] defaultShards = { "Adaptive Force", "Attack Speed", "Ability Haste", "Armor", "Magic Resist", "Health", "Scalling" };
        public ChromiumWebBrowser chromeBrowser;
        ToolStripMenuItem checkedTsmi;
        bool loading = false;
        bool updatig = false;
        bool uploadChampions = false;
        int nrFrames = 0;
        bool firstRun = true;
        private bool init = false;
        string selectedName;
        ThemeSelector themeSelector;
        RuneImporter runeImporter;
        bool runeIsOppened = false;
        #endregion
        //todo auto populate this!
        #region appLainWinrate
        private Dictionary<string, float> topListNames = new Dictionary<string, float>()
        {
{"Yorick", 52.46f},
{"Lillia", 52.44f},
{"Nasus", 52.36f},
{"Singed", 51.97f},
{"Urgot", 51.81f},
{"DrMundo", 51.79f},
{"Garen", 51.50f},
{"Kayle", 51.49f},
{"TahmKench", 51.45f},
{"Graves", 51.44f},
{"Shen", 51.32f},
{"Kled", 51.28f},
{"Quinn", 51.24f},
{"Ornn", 51.21f},
{"Sett", 51.12f},
{"Akshan", 51.09f},
{"Mordekaiser", 51.01f},
{"Maokai", 50.85f},
{"Illaoi", 50.84f},
{"Teemo", 50.78f},
{"Vayne", 50.76f},
{"Heimerdinger", 50.73f},
{"Wukong", 50.72f},
{"Fiora", 50.64f},
{"Malphite", 50.59f},
{"ChoGath", 50.54f},
{"Irelia", 50.38f},
{"Jax", 50.26f},
{"Warwick", 50.19f},
{"Poppy", 50.16f},
{"Camille", 50.14f},
{"Trundle", 50.10f},
{"Riven", 50.02f},
{"Sion", 49.72f},
{"Rengar", 49.65f},
{"Yasuo", 49.64f},
{"Aatrox", 49.60f},
{"Yone", 49.50f},
{"Rumble", 49.21f},
{"Tryndamere", 49.03f},
{"Gnar", 48.96f},
{"Pantheon", 48.87f},
{"Kennen", 48.85f},
{"Volibear", 48.67f},
{"Darius", 48.22f},
{"Sylas", 48.08f},
{"Akali", 47.91f},
{"Vex", 47.25f},
{"Vladimir", 46.95f},
{"Gangplank", 46.16f},
{"Jayce", 46.02f},
{"Renekton", 45.69f},
{"Ryze", 45.58f},
{"Gwen", 45.54f}
        };

        private Dictionary<string, float> midListNames = new Dictionary<string, float>()
        {
{"Mordekaiser",54.45f},
{"Sett",53.18f},
{"Kayle",53.13f},
{"Garen",52.94f},
{"Pyke",52.83f},
{"Swain",52.37f},
{"Corki",52.14f},
{"Malzahar",51.90f},
{"Graves",51.79f},
{"Anivia",51.74f},
{"Heimerdinger",51.74f},
{"Akshan",51.66f},
{"Brand",51.65f},
{"Annie",51.62f},
{"Fizz",51.61f},
{"VelKoz",51.60f},
{"Irelia",51.48f},
{"Teemo",51.47f},
{"Ziggs",51.40f},
{"Viktor",51.35f},
{"Yasuo",51.24f},
{"Yone",51.19f},
{"Diana",50.90f},
{"Malphite",50.88f},
{"Tryndamere",50.86f},
{"AurelionSol",50.86f},
{"Lissandra",50.82f},
{"Lux",50.64f},
{"Xerath",50.63f},
{"Pantheon",50.59f},
{"Veigar",50.54f},
{"Ahri",50.46f},
{"Tristana",50.35f},
{"Morgana",50.34f},
{"Ekko",50.24f},
{"Galio",50.20f},
{"Neeko",50.10f},
{"Darius",50.07f},
{"Talon",49.99f},
{"Cassiopeia",49.90f},
{"Vladimir",49.85f},
{"Katarina",49.70f},
{"Kassadin",49.68f},
{"Vex",49.45f},
{"LeBlanc",48.85f},
{"Renekton",48.84f},
{"Sylas",48.73f},
{"Zed",48.72f},
{"Viego",47.88f},
{"Jayce",47.83f},
{"Akali",47.81f},
{"Orianna",47.65f},
{"Gangplank",47.64f},
{"TwistedFate",47.56f},
{"Syndra",47.26f},
{"Zoe",47.15f},
{"Qiyana",46.87f},
{"Azir",45.70f},
{"Lucian",45.46f},
{"Ryze",44.33f}
        };

        private Dictionary<string, float> adcListNames = new Dictionary<string, float>()
        {
{"MissFortune",52.07f},
{"Vayne",51.94f},
{"Veigar",51.94f},
{"Ziggs",51.82f},
{"KogMaw",51.59f},
{"Jhin",51.44f},
{"Ashe",51.27f},
{"Yasuo",51.19f},
{"Sivir",50.76f},
{"Twitch",50.66f},
{"Draven",50.48f},
{"Senna",50.42f},
{"Jinx",49.71f},
{"Tristana",49.60f},
{"Akshan",49.57f},
{"Samira",49.29f},
{"Caitlyn",49.28f},
{"KaiSa",48.86f},
{"Xayah",48.61f},
{"Lucian",48.42f},
{"Ezreal",48.28f},
{"Vex",47.80f},
{"Aphelios",47.36f},
{"Kalista",46.64f},
{"Varus",46.56f},
{"Zeri",46.46f}
        };

        private Dictionary<string, float> junListNames = new Dictionary<string, float>()
        {
{"Amumu",54.02f},
{"Trundle",52.56f},
{"Mordekaiser",51.95f},
{"JarvanIV",51.89f},
{"Nocturne",51.88f},
{"MasterYi",51.88f},
{"Shyvana",51.56f},
{"Zac",51.38f},
{"Vi",51.30f},
{"Lillia",51.20f},
{"Skarner",51.17f},
{"Rammus",51.13f},
{"Fiddlesticks",50.91f},
{"XinZhao",50.83f},
{"Nunu",50.74f},
{"Poppy",50.73f},
{"Warwick",50.70f},
{"Ekko",50.69f},
{"KhaZix",50.53f},
{"DrMundo",50.45f},
{"Taliyah",50.38f},
{"Sejuani",50.36f},
{"Wukong",50.32f},
{"Graves",50.28f},
{"Evelynn",50.22f},
{"Jax",50.10f},
{"RekSai",50.10f},
{"Volibear",50.05f},
{"Talon",50.01f},
{"Nasus",50.00f},
{"Shaco",49.95f},
{"Kayn",49.94f},
{"Kindred",49.63f},
{"Elise",49.50f},
{"Karthus",49.47f},
{"Ivern",49.06f},
{"Diana",49.03f},
{"Hecarim",48.94f},
{"Udyr",48.85f},
{"Olaf",48.21f}
        };

        private Dictionary<string, float> supListNames = new Dictionary<string, float>()
        {
{"Amumu",53.74f},
{"Sona",52.22f},
{"Soraka",52.20f},
{"Zyra",52.11f},
{"Maokai",52.04f},
{"Nami",51.94f},
{"Brand",51.84f},
{"Blitzcrank",51.76f},
{"Zilean",51.60f},
{"Swain",51.18f},
{"Shaco",51.18f},
{"Xerath",51.14f},
{"Taric",50.90f},
{"Morgana",50.63f},
{"Janna",50.61f},
{"VelKoz",50.46f},
{"Braum",50.28f},
{"Rell",50.14f},
{"Bard",50.12f},
{"Leona",50.07f},
{"Lux",49.83f},
{"Shen",49.71f},
{"Yuumi",49.67f},
{"Nautilus",49.63f},
{"Alistar",49.61f},
{"Seraphine",49.53f},
{"Lulu",49.36f},
{"Pyke",49.19f},
{"Galio",49.14f},
{"Rakan",49.01f},
{"Veigar",48.98f},
{"Neeko",48.87f},
{"Senna",48.65f},
{"Anivia",48.38f},
{"Karma",48.28f},
{"Teemo",47.91f},
{"Thresh",47.82f},
{"Malphite",47.75f},
{"Ashe",46.96f},
{"Pantheon",46.85f},
{"MissFortune",46.26f},
{"Sett",45.38f},
{"Vex",45.31f}
        };
        #endregion
        public frmMain()
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();
            DisableAllConstrols();
            init = true;
            try
            {
                SavedItems si = XMLSaveData.DeserializeToObject<SavedItems>(Path.GetDirectoryName(workingDirectory) + @"\\save.data");
                champWidth = si.size;
                nudStack.Value = decimal.Parse(si.stack.ToString());
                selectedPatch = si.patch;
                selectedType = si.type;
                selectedRank = si.rank;
                backgroundLink = si.background;
                region = si.region;
                if (regions.Contains(region))
                {
                    cbRegion.SelectedIndex = regions.IndexOf(region);
                }
                btnClearCache.SendToBack();
                btnUpdate.SendToBack();
                btnTheme.SendToBack();
                nudPatch1.Value = decimal.Parse(si.patch.Split('_')[0]);
                nudPatch2.Value = decimal.Parse(si.patch.Split('_')[1]);
                if (selectedType == 0 || selectedType == 2)
                {
                    checkedTsmi = tsmiType.DropDownItems[si.type] as ToolStripMenuItem;
                    checkedTsmi = checkedTsmi.DropDownItems[selectedRank] as ToolStripMenuItem;
                    checkedTsmi.PerformClick();
                }
                else
                {
                    checkedTsmi = tsmiType.DropDownItems[si.type] as ToolStripMenuItem;
                    checkedTsmi.PerformClick();
                }
                this.Location = new Point(si.x, si.y);
                this.Size = new Size(si.width, si.height);
            }
            catch
            {
                SavedItems si = new SavedItems();
                si.size = 60;
                si.stack = STACKS;
                si.patch = "12_12";
                si.type = 0;
                si.rank = 5;
                checkedTsmi = tsmiType.DropDownItems[si.type] as ToolStripMenuItem;
                checkedTsmi = checkedTsmi.DropDownItems[selectedRank] as ToolStripMenuItem;
                checkedTsmi.PerformClick();
                si.x = 0; si.y = 0;
                si.width = DEFAULT_WIDTH;
                si.height = DEFAULT_HEIGHT;
                si.region = regions[2];
                tbSize.Text = "60";
                nudStack.Value = si.stack;
                selectedPatch = si.patch;
                selectedType = si.type;
                nudPatch1.Value = 12;
                nudPatch2.Value = 12;
                tsmiType.Tag = 0;
                tsmiType.DropDownItems[0].Select();
                region = si.region;
                if (regions.Contains(region))
                {
                    cbRegion.SelectedIndex = regions.IndexOf(region);
                }
                this.Location = new Point(si.x, si.y);
                this.Size = new Size(si.width, si.height);
                XMLSaveData.SerializeToXml(si, Path.GetDirectoryName(workingDirectory) + @"\\save.data");
            }
            champions = new Dictionary<string, Champion>();
            init = false;
            LoadBackground();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            btnAll.Enabled = false;
            tbSearch.Focus();
            FirstSendToBackElements();
            tbSize.Text = champWidth.ToString();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            CefSettings settings = new CefSettings();
            var cachePath = Path.GetDirectoryName(workingDirectory) + @"\cache";
            var cacheExist = Directory.Exists(cachePath);
            if (settings.CefCommandLineArgs.ContainsKey("disable-features"))
            {
                settings.CefCommandLineArgs["disable-features"] += ",SameSiteByDefaultCookies";
            }
            else
            {
                settings.CefCommandLineArgs.Add("disable-features", "SameSiteByDefaultCookies");
            }
            settings.CachePath = cachePath;
            settings.LogSeverity = LogSeverity.Fatal;
            Cef.Initialize(settings);
            chromeBrowser = new ChromiumWebBrowser("https://u.gg/lol/champions");
            pnWeb.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.SizeChanged += ChromeBrowser_SizeChanged;
            chromeBrowser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;
            chromeBrowser.FrameLoadStart += ChromeBrowser_FrameLoadStart;
            chromeBrowser.FrameLoadEnd += ChromeBrowser_FrameLoadEnd;
            chromeBrowser.IsBrowserInitializedChanged += ChromeBrowser_IsBrowserInitializedChanged;
            chromeBrowser.LoadError += ChromeBrowser_LoadError;
            chromeBrowser.HandleCreated += ChromeBrowser_HandleCreated;
            Cursor.Current = Cursors.Default;
            pnWeb.AutoScroll = false;
            if (!cacheExist)
            {
                pnWeb.Visible = false;
                new FormMessage("Thanks for using Champ Rune <3", "First time running ChampRune ^^? \n" +
                    "Please select a champion then press Accept button for the first time!\n" +
                    "Also don't forget to select the current last patch!\n" +
                    "Don't worry! Closing the app will save everything!\n" +
                    "Have fun using ChampRun!", this.Right - this.Width / 2, this.Bottom - this.Height / 2).ShowDialog();
            }
            else
            {
                pnWeb.Visible = false;
            }
            pnWeb.BringToFront();
            leagueClient = new LeagueClient(LeagueClient.credentials.lockfile);
            if (!leagueClient.IsConnected)
            {
                lblPhase.Text = "Phase: Client Offline";
            }
            else
            {
                leagueClient.OnConnected += LeagueClient_OnConnected;
                leagueClient.OnDisconnected += LeagueClient_OnDisconnected;
                leagueClient.OnWebsocketEvent += LeagueClient_OnWebsocketEvent;
                leagueClient.Subscribe("/lol-gameflow/v1/gameflow-phase", GameFlowPhase);
                leagueClient.Subscribe("/lol-champ-select/v1/session", ChampSelectEvent);
            }
            _ = SyncChampionsWithRiot();
        }
        void FirstSendToBackElements()
        {

            lblText.SendToBack();
            lblPhase.SendToBack();
            btnClearCache.SendToBack();
            btnUpdate.SendToBack();
            btnTheme.SendToBack();
            btnAbout.SendToBack();
        }
        private void LeagueClient_OnDisconnected()
        {
            //Console.WriteLine("Client disconnected!");
            this.Invoke((MethodInvoker)delegate
            { // runs on UI thread,
                lblPhase.Text = "Phase: Offline";
                new FormMessage("", "League Of Legends is Offline now!" +
                    "\nRestart ChampRune After Client is opened again!", this.Right - this.Width / 2, this.Bottom - this.Height / 2).ShowDialog();
            });

        }
        bool clientOnline = false;
        private void LeagueClient_OnWebsocketEvent(OnWebsocketEventArgs obj)
        {

            if (!clientOnline)
            {
                this.Invoke((MethodInvoker)delegate
                { // runs on UI thread,
                    lblPhase.Text = "Phase: Online";
                });
                clientOnline = true;
            }
        }

        private void LeagueClient_OnConnected()
        {
            this.Invoke((MethodInvoker)delegate
            { // runs on UI thread,
                lblPhase.Text = "Phase: Online";
            });
            //Console.WriteLine("Client connected!");
        }

        string phase = "";
        private void GameFlowPhase(OnWebsocketEventArgs obj)
        {
            phase = obj.Data;
            this.Invoke((MethodInvoker)delegate
            { // runs on UI thread,
                lblPhase.Text = "Phase: " + phase;
            });
            //Debug.WriteLine("ChampRune Phase changed: " + phase);
        }
        private void ChromeBrowser_HandleCreated(object sender, EventArgs e)
        {
            //Debug.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<WEBSITE Handle Created");
        }
        void UpdateChampions()
        {
            var t = chromeBrowser.GetMainFrame().GetSourceAsync().ContinueWith(taskHtml =>
           {
               var html = taskHtml.Result;
               using (var stream = GenerateStreamFromString(html))
               {

                   HtmlNodeNavigator navigator = new HtmlNodeNavigator(stream);
                   var championNames = navigator.Select((".//div [@class='champion-name']"));
                   List<string> keys = new List<string>();
                   keys = GetChampionsNames(championNames);
                   List<string> images = new List<string>();
                   var championImages = navigator.Select((".//div [@class='image-wrapper']"));
                   images = GetChampionsImages(championImages);
                   int locX = 0, locY = DEFAULT_BUTTON_LOCATION;
                   champWidth = champHeight = int.Parse(tbSize.Text);
                   STACKS = int.Parse(nudStack.Value.ToString());
                   for (var i = 0; i < keys.Count(); i++)
                   {
                       PictureBox b = new PictureBox();
                       b.WaitOnLoad = false;
                       b.SizeMode = PictureBoxSizeMode.StretchImage;
                       b.BackgroundImageLayout = ImageLayout.Stretch;
                       b.Size = new Size(champWidth, champHeight);
                       b.Location = new Point(locX, locY);
                       b.Name = keys[i];
                       b.MouseHover += Btn_MouseHover;
                       b.MouseClick += Btn_Champion_Click_Event;
                       b.MouseEnter += B_MouseEnter;
                       //Debug.Write("\"" + b.Name + "\", ");
                       if (locX + b.Width < champWidth * STACKS)
                       {
                           locX += b.Width;
                       }
                       else
                       {
                           locX = 0;
                           locY += b.Height;
                       }
                       if (!champions.ContainsKey(keys[i]))
                       {
                           champions.Add(keys[i], new Champion
                           {
                               name = keys[i],
                               image = b,
                               imagePath = images[i]
                           });
                       }
                   }
                   this.Invoke((MethodInvoker)delegate
                   { // runs on UI thread,
                       UpdateWithImagesFromUGG();
                       this.Cursor = Cursors.Default;
                   });
               }

           });
        }


        private void B_MouseEnter(object sender, EventArgs e)
        {
            PictureBox crtButton = sender as PictureBox;

            champions.Where(x => x.Value.image.BorderStyle == BorderStyle.Fixed3D).ToList().ForEach(x => x.Value.image.BorderStyle = BorderStyle.None);
            crtButton.BorderStyle = BorderStyle.Fixed3D;
            DrawMessage(crtButton.Name);

        }

        void OpenLink(string link, bool visible = true)
        {
            chromeBrowser.Load(link);
            if (visible)
            {
                pnWeb.Visible = true;
                pnWeb.BringToFront();
            }
            else
            {
                pnWeb.Visible = false;
            }
        }
        void EnableAndBringWebToFront()
        {
            pnWeb.Visible = true;
            pnWeb.BringToFront();
        }
        private void Btn_Champion_Click_Event(object sender, MouseEventArgs e)
        {
            PictureBox btn = sender as PictureBox;
            if (e.Button == MouseButtons.Left)
            {
                selectedName = btn.Name.Trim().ToLower();
                if (selectedName.ToLower().StartsWith("renata"))
                {
                    selectedName = "renata";
                }
                LoadNextChamp(selectedName);
            }
            else
            {
                DrawMessage(btn.Name);
            }
        }
        string GetSelectedRankByID(int selectedRank)
        {
            string rank = "overall";
            switch (selectedRank)
            {
                case 0:
                    rank = "platinum_plus";
                    break;
                case 1:
                    rank = "diamond_plus";
                    break;
                case 2:
                    rank = "diamond_2_plus";
                    break;
                case 3:
                    rank = "master_plus";
                    break; // splitter
                case 5:
                    rank = "overall";
                    break; // splitter
                case 7:
                    rank = "challenger";
                    break;
                case 8:
                    rank = "grandmaster";
                    break;
                case 9:
                    rank = "master";
                    break;
                case 10:
                    rank = "diamond";
                    break;
                case 11:
                    rank = "platinum";
                    break;
                case 12:
                    rank = "gold";
                    break;
                case 13:
                    rank = "silver";
                    break;
                case 14:
                    rank = "bronze";
                    break;
                case 15:
                    rank = "iron";
                    break;
            }
            return rank;
        }
        void LoadNextChamp(string selectedName)
        {
            if (tsmiType.Tag.ToString() == "0")
            {
                OpenLink(@"https://u.gg/lol/champions/" + selectedName + "/build?patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString() + @"&rank=" + GetSelectedRankByID(selectedRank));
            }
            else if (tsmiType.Tag.ToString() == "1")
            {
                OpenLink(@"https://u.gg/lol/champions/aram/" + selectedName + @"-aram?patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString());
            }
            else if (tsmiType.Tag.ToString() == "2")
            {
                OpenLink(@"https://u.gg/lol/champions/" + selectedName + @"/build?patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString() + @"&queueType=ranked_flex_sr&rank=" + GetSelectedRankByID(selectedRank));
            }
            else if (tsmiType.Tag.ToString() == "3")
            {
                OpenLink(@"https://u.gg/lol/champions/" + selectedName + @"/build?patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString() + @"&queueType=normal_blind_5x5");
            }
            else if (tsmiType.Tag.ToString() == "4")
            {
                OpenLink(@"https://u.gg/lol/champions/" + selectedName + @"/build?patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString() + @"&queueType=normal_draft_5x5");
            }
        }

        private void DrawMessage(string message)
        {
            lblText.Text = message;
            lblText.Location = new Point(this.Width - lblText.Width - 10, 60);
        }
        private void Btn_MouseHover(object sender, EventArgs e)
        {
            DrawMessage((sender as PictureBox).Name);
        }

        private void ChromeBrowser_LoadError(object sender, LoadErrorEventArgs e)
        {
            //Debug.WriteLine("<<<<ChromeBrowser_LoadError Stopping the browser...");
            //chromeBrowser.Stop();
        }

        private void ChromeBrowser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var cb = sender as ChromiumWebBrowser;
            //Debug.WriteLine("<<<<<ChromeBrowser_IsBrowserInitializedChanged"); //+ cb?.CanGoForward);
            if (cb.IsBrowserInitialized)
            {
                //Debug.WriteLine("<<<<<ChromeBrowser_IsInitializedRightNOW!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
        }
        private void ChromeBrowser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            nrFrames = 1; string frLink = e.Frame.Url;
            if (frLink.StartsWith("https://u.gg/lol/champion"))
            {
                if (firstRun)
                {
                    uploadChampions = true;
                }
            }
            if (frLink == "about:blank")
            {
                return;
            }
        }
        List<string> GetCPChampionLains(XPathNodeIterator keystone)
        {
            List<string> champs = new List<string>();
            for (int i = 0; i < keystone.Count; i++)
            {
                keystone.MoveNext();
                var rezK = keystone.Current.InnerXml.Split('"').Where(x => !string.IsNullOrEmpty(x.Trim()) && x.Trim().EndsWith(".png"));
                var finalString = rezK.First().Split('-').Last().Split('.').First();
                champs.Add(finalString/*string.Join(",", rezK)*/);
            }
            return champs;
        }
        List<string> GetCPChampionNames(XPathNodeIterator keystone)
        {
            List<string> champs = new List<string>();
            for (int i = 0; i < keystone.Count; i++)
            {
                keystone.MoveNext();
                string rezK = Regex.Split(keystone.Current.OuterXml.Split('"')[1], "/").Last();
                champs.Add(rezK);
            }
            return champs;
        }
        void UpdateCounterPickChamps()
        {
            var t = chromeBrowser.GetMainFrame().GetSourceAsync().ContinueWith(taskHtml =>
            {
                var html = taskHtml.Result;
                using (var stream = GenerateStreamFromString(html))
                {
                    if (cpChamps == null)
                    {
                        HtmlNodeNavigator navigator = new HtmlNodeNavigator(stream);
                        var championNames = navigator.Select((".//a [@class='champion-row']")); //  ".//a [@class='ChampionPanel_panel__2I0Mx']"
                        cpChamps = GetCPChampionNames(championNames);
                        var lainsPick = navigator.Select((".//span [@class='lanes']")); //  ".//a [@class='ChampionPanel_panel__2I0Mx']"
                        cpLains = GetCPChampionLains(lainsPick);

                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        var counterPick = new CounterPick(cpChamps, cpLains, this.chromeBrowser, this.Right - this.Width / 2, this.Bottom - this.Height / 2);
                        counterPick.BackgroundImage = this.backbroundPictureBox.Image;
                        counterPick.ShowDialog(this);
                    });

                }
            });
        }

        List<string> GetLoyalityChampionNames(XPathNodeIterator keystone)
        {
            List<string> champs = new List<string>();
            for (int i = 0; i < keystone.Count; i++)
            {
                keystone.MoveNext();
                string rezK = Regex.Split(keystone.Current.OuterXml.Split('"')[3], "/")[2];
                champs.Add(rezK);
            }
            return champs;
        }

        private void ChromeBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            //Debug.WriteLine("<<< ChromeBrowser_FrameLoadEnd_FrameLoadEnd:Identifer: " + e.Frame.Identifier + " Is Main: " + e.Frame.IsMain);
            string url = e.Url;
            if (url.StartsWith("https://u.gg/lol/champions/"))
            {
                return;
            }
            if (url == "https://www.counterstats.net/") //"https://pros.lol/champions/"
            {
                UpdateCounterPickChamps();
                chromeBrowser.StopFinding(false);
            }

            if (url.StartsWith("https://ads"))
            {
                e.Browser.StopFinding(true);
            }
            if (url == "https://u.gg/lol/champions")
            {
                if (firstRun)
                {
                    uploadChampions = true;
                    firstRun = false;
                }
            }
            if (e.Frame.Name.StartsWith("__privateStripeMetricsController"))
            {
                e.Browser.StopLoad();
                Point crtScrol = new Point(chromeBrowser.AutoScrollOffset.X, chromeBrowser.AutoScrollOffset.Y);
                chromeBrowser.SendMouseWheelEvent(crtScrol.X, crtScrol.Y, 0, -35, CefEventFlags.None);
                chromeBrowser.StopFinding(false);
                loading = false;
            }
            if (e.Frame.Name.StartsWith("goog_"))
            {
                e.Browser.StopLoad();
            }
            if (e.Frame.Name.StartsWith(@"<!--dynamicFrame"))
            {
                this.Invoke((MethodInvoker)delegate
                { // runs on UI thread,
                    try
                    {
                        this.Cursor = Cursors.Default;
                    }
                    catch { }
                });
                if (uploadChampions)
                {
                    // UpdateChampions(); // Disabled in favor of SyncChampionsWithRiot
                    uploadChampions = false;
                }
            }

            if (!e.Browser.HasDocument)
            {
                //Debug.WriteLine("<<< ChromeBrowser_FrameLoadEnd_Browser has document Status Code: " + e.HttpStatusCode);
                if (e.HttpStatusCode == 0)
                {
                    Point crtScrol = new Point(chromeBrowser.AutoScrollOffset.X, chromeBrowser.AutoScrollOffset.Y);
                    chromeBrowser.SendMouseWheelEvent(crtScrol.X, crtScrol.Y, 0, -35, CefEventFlags.None);
                    chromeBrowser.StopFinding(false);
                    loading = false;
                }
            }
        }


        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        List<string> GetFinal1Runes(XPathNodeIterator keystone)
        {
            List<string> runesKeystone = new List<string>();
            for (int i = 0; i < keystone.Count; i++)
            {
                string rezK = keystone.Current.InnerXml;
                if (rezK.Contains("src"))
                {
                    var runeName = rezK?.Split('"').FirstOrDefault(x => x.Trim().EndsWith(".png"));
                    if (string.IsNullOrEmpty(runeName))
                    {
                        runeName = rezK?.Split('"').FirstOrDefault(x => x.Trim().EndsWith(".webp"));
                    }
                    var BeforeRuneName = runeName.Split('/');
                    var finalRuneName = BeforeRuneName[BeforeRuneName.Count() - 2];
                    if (finalRuneName.ToLower() == "precision")
                    {
                        finalRuneName = BeforeRuneName[BeforeRuneName.Count() - 1].Split('.')[0];
                    }
                    if (!runesKeystone.Contains(finalRuneName))
                    {
                        runesKeystone.Add(finalRuneName);
                    }
                }
                keystone.MoveNext();
            }
            return runesKeystone;
        }
        List<string> GetFinalRunes(XPathNodeIterator keystone)
        {
            List<string> runesKeystone = new List<string>();
            for (int i = 0; i < keystone.Count; i++)
            {
                string rezK = keystone.Current.InnerXml;
                if (rezK.Contains("src"))
                {
                    var runeName = rezK?.Split('"').FirstOrDefault(x => x.Trim().EndsWith(".png"));
                    if (string.IsNullOrEmpty(runeName))
                    {
                        runeName = rezK?.Split('"').FirstOrDefault(x => x.Trim().EndsWith(".webp"));
                    }
                    if (!string.IsNullOrEmpty(runeName))
                    {
                        var finalRoneName = runeName.Split('/').Last().Split('.')[0];
                        if (!runesKeystone.Contains(finalRoneName))
                        {
                            runesKeystone.Add(finalRoneName);
                        }
                    }
                }
                keystone.MoveNext();
            }
            return runesKeystone;
        }
        List<string> GetDefaultRunesValues(XPathNodeIterator keystone)
        {
            List<string> runesKeystone = new List<string>();
            for (int i = 0; i < keystone.Count; i++)
            {
                string rezK = keystone.Current.Value;
                if (defaultRuneNames.Contains(rezK))
                {
                    if (!runesKeystone.Contains(rezK))
                    {
                        runesKeystone.Add(rezK.Trim());
                    }
                }
                keystone.MoveNext();
            }
            return runesKeystone;
        }
        List<string> GetChampionsImages(XPathNodeIterator keystone)
        {
            List<string> runesKeystone = new List<string>();
            int index = -1;
            for (int i = 0; i < keystone.Count; i++)
            {
                keystone.MoveNext();
                string rezK = keystone.Current.InnerXml;
                if (index == -1)
                {
                    var mesages = rezK.Split('"');
                    for (int ind = 0; ind < mesages.Count(); ind++)
                    {
                        if (mesages[ind].Contains("src="))
                        {
                            index = ind + 1;
                            break;
                        }
                    }
                }
                if (rezK.Contains("img"))
                {
                    var firstSplit = rezK.Split('"')[index];
                    if (!runesKeystone.Contains(firstSplit))
                    {
                        runesKeystone.Add(firstSplit.Trim());
                    }
                }
            }
            return runesKeystone;
        }
        List<string> GetChampionsNames(XPathNodeIterator keystone)
        {
            List<string> runesKeystone = new List<string>();
            for (int i = 0; i < keystone.Count; i++)
            {
                keystone.MoveNext();
                string rezK = keystone.Current.Value;
                if (rezK.Length > 0)
                {
                    rezK = rezK.Replace(" ", "").Replace(".", "").Replace("'", "");
                    if (rezK.StartsWith("Nunu"))
                    {
                        rezK = "Nunu";
                    }
                    if (!runesKeystone.Contains(rezK))
                    {
                        runesKeystone.Add(rezK);
                    }
                }
            }
            return runesKeystone;
        }
        List<string> GetShardsNames(XPathNodeIterator keystone)
        {
            List<string> runesKeystone = new List<string>();
            for (int i = 0; i < keystone.Count; i++)
            {
                keystone.MoveNext();
                string rezK = keystone.Current.InnerXml;
                if (rezK.Contains("alt"))
                {
                    var runeName = rezK?.Split('=');
                    var finalShardName = runeName.Last().Split('"');
                    var finalShardName2 = finalShardName[finalShardName.Length - 2];
                    if (finalShardName2.EndsWith("CDR Shard"))
                    {
                        runesKeystone.Add(defaultShards[2]);
                        continue;
                    }
                    var founderShard = defaultShards?.First(x => finalShardName2.Contains(x));
                    if (founderShard?.Length > 0)
                    {
                        if (runesKeystone.Count() < 3)
                        {/*
                            if (founderShard == "CDRScalling")
                            {
                                runesKeystone.Add(defaultShards[2]);
                                continue;
                            }*/
                            runesKeystone.Add(founderShard);
                        }
                    }
                }

            }
            return runesKeystone;
        }
        List<string> GetRunesNames(XPathNodeIterator keystone)
        {
            List<string> runesKeystone = new List<string>();
            for (int i = 0; i < keystone.Count; i++)
            {
                keystone.MoveNext();
                string rezK = keystone.Current.OuterXml;
                if (rezK.Contains("alt"))
                {
                    var spellName = rezK?.Split('=');
                    var finalShardName = spellName.Last().Split('"')[1];
                    if (finalShardName.StartsWith("Summoner Spell "))
                    {
                        runesKeystone.Add(finalShardName.Substring("Summoner Spell ".Length));
                        continue;
                    }
                }

            }
            return runesKeystone;
        }
        private void UpdateWithImagesFromUGG()
        {
            if (champions?.Keys.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (var key in champions.Keys)
                {
                    champions[key].image.WaitOnLoad = true;
                    try
                    {
                        if (champions[key].imagePath.ToLower().EndsWith(".webp"))
                        {
                            champions[key].imagePath = champions[key].imagePath.Substring(0, champions[key].imagePath.Count() - 4) + "png";
                        }
                        champions[key].image.LoadAsync(champions[key].imagePath);
                    }
                    catch { }
                    this.Controls.Add(champions[key].image);
                }

                g = this.CreateGraphics();
                SwitchToAllChamps();
                UpdatePicSize();
                EnableAllConstrols();
                this.Cursor = Cursors.Default;
            }
        }

        private async Task SyncChampionsWithRiot()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // 1. Aflăm ultima versiune de patch
                    var versions = await client.GetStringAsync("https://ddragon.leagueoflegends.com/api/versions.json");
                    string latest = Newtonsoft.Json.Linq.JArray.Parse(versions)[0].ToString();

                    // 2. Descărcăm datele campionilor
                    var json = await client.GetStringAsync($"https://ddragon.leagueoflegends.com/cdn/{latest}/data/en_US/champion.json");
                    var data = Newtonsoft.Json.Linq.JObject.Parse(json)["data"];

                    champions = new Dictionary<string, Champion>();
                    int locX = 0, locY = DEFAULT_BUTTON_LOCATION;
                    champWidth = champHeight = int.Parse(tbSize.Text);
                    STACKS = int.Parse(nudStack.Value.ToString());

                    foreach (var champ in (JObject)data)
                    {
                        string name = champ.Key.ToString();
                        string keyId = champ.Value["key"].ToString();

                        PictureBox b = new PictureBox();
                        b.WaitOnLoad = false;
                        b.SizeMode = PictureBoxSizeMode.StretchImage;
                        b.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Size = new Size(champWidth, champHeight);
                        b.Location = new Point(locX, locY);
                        b.Name = name;
                        b.MouseHover += Btn_MouseHover;
                        b.MouseClick += Btn_Champion_Click_Event;
                        b.MouseEnter += B_MouseEnter;

                        if (locX + b.Width < champWidth * STACKS)
                        {
                            locX += b.Width;
                        }
                        else
                        {
                            locX = 0;
                            locY += b.Height;
                        }

                        champions.Add(name, new Champion
                        {
                            name = name,
                            id = keyId,
                            image = b,
                            imagePath = $"https://ddragon.leagueoflegends.com/cdn/{latest}/img/champion/{name}.png"
                        });
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateWithImagesFromUGG();
                        this.Cursor = Cursors.Default;
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error syncing champions: " + ex.Message);
            }
        }

        private async Task<List<int>> GetRunesFromUgg(string champName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                    string url = $"https://u.gg/lol/champions/{champName.ToLower()}/build";
                    string html = await client.GetStringAsync(url);

                    string pattern = @"(?<=""selectedPerks"":\[).*?(?=\])";
                    var match = Regex.Match(html, pattern);

                    if (match.Success)
                    {
                        return match.Value.Split(',')
                                          .Select(id => int.Parse(id.Trim()))
                                          .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error fetching runes: " + ex.Message);
            }
            return null;
        }

        private async void AutoApplyRunes(string name)
        {
            var runes = await GetRunesFromUgg(name);
            if (runes != null)
            {
                Debug.WriteLine($"Found runes for {name}: {string.Join(", ", runes)}");
                // Application logic via LCU could be added here
            }
        }

        private void ChampSelectEvent(OnWebsocketEventArgs e)
        {
            try
            {
                var data = JObject.Parse(e.Data);
                var myCellId = data["localPlayerCellId"]?.ToString();
                var actions = data["actions"];

                if (myCellId == null || actions == null) return;

                foreach (var actionGroup in actions)
                {
                    foreach (var action in actionGroup)
                    {
                        if (action["actorCellId"]?.ToString() == myCellId && (bool)action["completed"])
                        {
                            string champId = action["championId"]?.ToString();
                            var champ = champions.Values.FirstOrDefault(c => c.id == champId);
                            if (champ != null)
                            {
                                Task.Run(() => AutoApplyRunes(champ.name));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in ChampSelectEvent: " + ex.Message);
            }
        }
        private void BtnUpdateRune_Click(object sender, System.EventArgs e)
        {

        }

        private void DownloadBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            ChromiumWebBrowser BrowserSender = (ChromiumWebBrowser)sender;
            Cursor.Current = Cursors.WaitCursor;
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => { WebBrowserFrameLoadEnded(BrowserSender, e); }));
            }
            else
            {
                WebBrowserFrameLoadEnded(BrowserSender, e);
            }
        }
        async void WebBrowserFrameLoadEnded(ChromiumWebBrowser sender, FrameLoadEndEventArgs e)
        {
            string html1 = null;
            Task<String> taskString1;

            if (e.Frame.IsMain)
            {
                ChromiumWebBrowser browserSender = (ChromiumWebBrowser)sender;
                string html = await browserSender.GetMainFrame().GetSourceAsync();
                //Debug.WriteLine(html);
                if (updatig)
                {
                    Cursor.Current = Cursors.Default;
                    if (html.Contains(@"Oops! That page can’t be found."))
                    {
                        new FormMessage("", "You have the last version!: " + Text + " \nWe don't have a new restarting...", this.Right - this.Width / 2, this.Bottom - this.Height / 2).ShowDialog();
                        Application.Restart();
                    }
                    else
                    {
                        new FormMessage("", "I found an update!", this.Right - this.Width / 2, this.Bottom - this.Height / 2).ShowDialog();
                    }
                    updatig = false;
                }
            }
        }
        private void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                if (loading)
                {
                    loading = false;
                }
            }
            else
            {
                if (!loading)
                {
                    //Console.WriteLine("Is loading:" + e.IsLoading);
                    loading = true;
                }
            }
            if (chromeBrowser.IsBrowserInitialized)
            {
                if (loading)
                {
                    loading = false;
                }
            }
        }

        private void ChromeBrowser_SizeChanged(object sender, EventArgs e)
        {

        }

        void UpdateSavedFile()
        {
            try
            {
                SavedItems si = new SavedItems();
                si.size = int.Parse(tbSize.Text);
                si.stack = int.Parse(nudStack.Value.ToString());
                si.patch = nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString();
                si.type = int.Parse(tsmiType.Tag.ToString());
                si.rank = (si.type == 0 || si.type == 2) ? int.Parse(checkedTsmi.Tag.ToString()) : si.rank = 5;
                si.x = this.Location.X;
                si.y = this.Location.Y;
                si.width = this.Width;
                si.height = this.Height;
                si.background = this.backgroundLink;
                si.region = regions[cbRegion.SelectedIndex];
                XMLSaveData.SerializeToXml(si, Path.GetDirectoryName(workingDirectory) + @"\\save.data");
            }
            catch
            {
                SavedItems si = new SavedItems();
                si.size = 60;
                si.stack = 20;
                si.patch = "12_12";
                si.type = 1;
                si.rank = 5;
                si.x = 0;
                si.y = 0;
                si.width = DEFAULT_WIDTH;
                si.height = DEFAULT_HEIGHT;
                si.region = regions[2];
                XMLSaveData.SerializeToXml(si, Path.GetDirectoryName(workingDirectory) + @"\\save.data");
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!cbSearch.Checked)
            {
                pnWeb.Visible = false;
                pnWeb.SendToBack();

                btnAll.Enabled = false;
                btnTop.Enabled = true;
                btnMid.Enabled = true;
                btnAdc.Enabled = true;
                btnJun.Enabled = true;
                btnSup.Enabled = true;
                if (tbSearch.Text == "")
                {
                    SwitchToAllChamps();
                    btnItems.Enabled = true;
                    return;
                }
                int locX = 0, locY = DEFAULT_BUTTON_LOCATION;
                foreach (var key in champions.Keys)
                {
                    if (champions[key].name.ToLower().StartsWith(tbSearch.Text.ToLower()))
                    {
                        if (champions[key].image.Location != new Point(locX, locY))
                        {
                            champions[key].image.Location = new Point(locX, locY);
                        }
                        if (champions[key].image.Visible == false)
                        {
                            champions[key].image.Visible = true;
                        }
                        champions[key].image.BringToFront();
                        if (locX + champions[key].image.Width < champWidth * STACKS)
                        {
                            locX += champions[key].image.Width;
                        }
                        else
                        {
                            locX = 0;
                            locY += champions[key].image.Height;
                        }
                    }
                    else
                    {
                        if (champions[key].image.Location != new Point(this.Width - DEFAULT_BUTTON_LOCATION, this.Height - DEFAULT_BUTTON_LOCATION))
                        {
                            champions[key].image.Location = new Point(this.Width - DEFAULT_BUTTON_LOCATION, this.Height - DEFAULT_BUTTON_LOCATION);
                        }
                        if (champions[key].image.Visible == true)
                        {
                            champions[key].image.Visible = false;
                        }
                        champions[key].image.SendToBack();
                    }
                }
                this.Invalidate();
                this.Refresh();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        void SwitchToListNames(Dictionary<string, float> names, string lain)
        {
            int locX = 0, locY = DEFAULT_BUTTON_LOCATION;
            foreach (string key in champions.Keys)
            {
                champions[key].image.Visible = false;
                champions[key].image.Refresh();
            }
            foreach (var key in names.Keys)
            {
                champions[key].image.Visible = true;
                champions[key].image.Location = new Point(locX, locY);
                champions[key].image.Refresh();
                if (locX + champions[key].image.Width < champWidth * STACKS)
                {
                    locX += champions[key].image.Width;
                }
                else
                {
                    locX = 0;
                    locY += champions[key].image.Height;
                }
            }
            this.Refresh();
        }


        void DisableButton(int nr)
        {

            btnAll.Enabled = true;
            btnTop.Enabled = true;
            btnMid.Enabled = true;
            btnAdc.Enabled = true;
            btnJun.Enabled = true;
            btnSup.Enabled = true;
            switch (nr)
            {
                case 0: btnTop.Enabled = false; break;
                case 1: btnMid.Enabled = false; break;
                case 2: btnAdc.Enabled = false; break;
                case 3: btnJun.Enabled = false; break;
                case 4: btnSup.Enabled = false; break;
                default: btnAll.Enabled = false; break;
            }
        }
        int GetDisabldeButton()
        {
            if (btnAll.Enabled == false)
            {
                return -1;
            }
            else if (btnTop.Enabled == false)
            {
                return 0;
            }
            else if (btnMid.Enabled == false)
            {
                return 1;
            }
            else if (btnAdc.Enabled == false)
            {
                return 2;
            }
            else if (btnJun.Enabled == false)
            {
                return 3;
            }
            else if (btnSup.Enabled == false)
            {
                return 4;
            }
            return -2;
        }
        void TopWinRateLain(Dictionary<string, float> names, string lain)
        {
            pnWeb.Visible = false;
            pnWeb.Refresh();
            SwitchToListNames(names, lain);
            tbSearch.Focus();
            btnItems.Enabled = true;
        }
        private void btnTop_Click(object sender, EventArgs e)
        {
            DisableButton(0);
            if (cbTopWin.Checked)
            {
                OpenLink(@"https://u.gg/lol/top-lane-tier-list?rank=" + GetSelectedRankByID(selectedRank) + "&patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString());
            }
            else
            {
                TopWinRateLain(topListNames, lains[1].Trim().ToLower());
            }
            this.Refresh();

        }

        private void btnMid_Click(object sender, EventArgs e)
        {
            DisableButton(1);
            if (cbTopWin.Checked)
            {
                OpenLink(@"https://u.gg/lol/mid-lane-tier-list?rank=" + GetSelectedRankByID(selectedRank) + "&patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString());
            }
            else
            {
                TopWinRateLain(midListNames, lains[1].Trim().ToLower());
            }
            this.Refresh();
        }

        private void btnAdc_Click(object sender, EventArgs e)
        {
            DisableButton(2);
            if (cbTopWin.Checked)
            {
                OpenLink(@"https://u.gg/lol/adc-tier-list?rank=" + GetSelectedRankByID(selectedRank) + "&patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString());
            }
            else
            {
                TopWinRateLain(adcListNames, lains[2].Trim().ToLower());
            }
            this.Refresh();
        }
        private void btnJun_Click(object sender, EventArgs e)
        {
            DisableButton(3);
            if (cbTopWin.Checked)
            {
                OpenLink(@"https://u.gg/lol/jungle-tier-list?rank=" + GetSelectedRankByID(selectedRank) + "&patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString());
            }
            else
            {
                TopWinRateLain(junListNames, lains[3].Trim().ToLower());
            }
            this.Refresh();
        }
        private void btnSup_Click(object sender, EventArgs e)
        {
            DisableButton(4);
            if (cbTopWin.Checked)
            {
                OpenLink(@"https://u.gg/lol/support-tier-list?rank=" + GetSelectedRankByID(selectedRank) + "&patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString());
            }
            else
            {
                TopWinRateLain(supListNames, lains[4].Trim().ToLower());
            }
            this.Refresh();
        }

        void SwitchToAllChamps()
        {
            DisableButton(-1);
            if (cbTopWin.Checked)
            {
                OpenLink(@"https://u.gg/lol/tier-list?rank=overall&patch=" + nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString());
            }
            else
            {
                tbSearch.Focus();
                int locX = 0, locY = DEFAULT_BUTTON_LOCATION;
                if (champions == null) { return; }
                foreach (var key in champions?.Keys)
                {
                    champions[key].image.Visible = true;
                    if (champions[key].image.Location != new Point(locX, locY))
                    {
                        champions[key].image.Location = new Point(locX, locY);
                    }
                    champions[key].image.Refresh();
                    if (locX + champions[key].image.Width < champWidth * STACKS)
                    {
                        locX += champions[key].image.Width;
                    }
                    else
                    {
                        locX = 0;
                        locY += champions[key].image.Height;
                    }
                }
                pnWeb.Visible = false;
                btnItems.Enabled = true;
            }
            this.Refresh();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            SwitchToAllChamps();
            btnItems.Enabled = true;
        }

        private void btnTop_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("TOP lain");
        }

        private void btnMid_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("MID lain");
        }

        private void btnAdc_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("ADC or BOT lain");
        }

        private void btnJun_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("JUNGLE lain");
        }

        private void btnSup_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("SUPPORT lain");
        }

        private void btnAll_MouseHover(object sender, EventArgs e)
        {
            DrawMessage("ALL lains");
        }

        private void nudStack_ValueChanged(object sender, EventArgs e)
        {
            if (!init)
            {
                cbTopWin.Checked = false;
                STACKS = int.Parse(nudStack.Value.ToString());
                SwitchToAllChamps();
                UpdateSavedFile();
            }
        }
        private void tbSize_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                cbTopWin.Checked = false;
                SwitchToAllChamps();
                ValidateInputSize();

            }
        }

        void ValidateInputSize()
        {
            int val;
            try
            {
                val = int.Parse(tbSize.Text);

            }
            catch (Exception ex)
            {
                new FormMessage("", "You haven't entered a valid size: " + ex.Message, this.Right - this.Width / 2, this.Bottom - this.Height / 2).ShowDialog();
                tbSize.Text = "60";
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
                new FormMessage("", "Try a value between 60 and 100", this.Right - this.Width / 2, this.Bottom - this.Height / 2).ShowDialog();
                tbSize.Text = "60";
            }
        }

        void UpdatePicSize()
        {
            champWidth = int.Parse(tbSize.Text);
            champHeight = int.Parse(tbSize.Text);
            if (champions == null)
            {
                return;
            }
            foreach (var key in champions?.Keys)
            {
                champions[key].image.Size = new Size(champWidth, champHeight);
            }
        }
        private void tbSize_MouseHover(object sender, EventArgs e)
        {
            t1.Show("   Press enter to update the size!", sender as TextBox);
        }

        private void llLinks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidateInputSize();
            UpdateSavedFile();
        }

        private void tbSize_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Rune
            if (pnWeb.Visible)
            {
                if (!btnItems.Enabled)
                {
                    Point crtScrol = new Point(chromeBrowser.AutoScrollOffset.X, chromeBrowser.AutoScrollOffset.Y);
                    if (!cbTopWin.Enabled)
                    {
                        chromeBrowser.SendMouseWheelEvent(crtScrol.X, crtScrol.Y, 0, +640, CefEventFlags.None);
                        btnItems.Enabled = true;
                    }

                }
                else
                {
                    Point crtScrol = new Point(chromeBrowser.AutoScrollOffset.X, chromeBrowser.AutoScrollOffset.Y);
                    chromeBrowser.SendMouseWheelEvent(crtScrol.X, crtScrol.Y, 0, +1240, CefEventFlags.None);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Items
            if (pnWeb.Visible)
            {
                if (btnItems.Enabled)
                {
                    Point crtScrol = new Point(chromeBrowser.AutoScrollOffset.X, chromeBrowser.AutoScrollOffset.Y);
                    if (!cbTopWin.Enabled)
                    {
                        chromeBrowser.SendMouseWheelEvent(crtScrol.X, crtScrol.Y, 0, -1200, CefEventFlags.None);
                        btnItems.Enabled = false;
                    }
                    else
                    {
                        chromeBrowser.SendMouseWheelEvent(crtScrol.X, crtScrol.Y, 0, -1240, CefEventFlags.None);
                    }

                }
            }
        }

        private void frmMain_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void pnWeb_Paint_1(object sender, PaintEventArgs e)
        {
            if (updatig)
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {

            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            var dr = new FormMessage("Clear space from app?!", "Exit app then remove: \\cache folder!" +
                "\nYou can also remove debug.log file to clear some space! \n Do you want to open app folder?",
                MessageBoxButtons.YesNo,
                this.Right - this.Width / 2, this.Bottom - this.Height / 2);
            dr.ShowDialog();
            if (dr.DialogResult == DialogResult.Yes)
            {
                string finalCache = Path.GetDirectoryName(workingDirectory);
                Process.Start("explorer.exe", finalCache);
            }
        }
        void EnableAllButtons()
        {
            DisableButton(-1);
            btnAll.Enabled = true;
        }
        bool OneIsDisabled()
        {
            foreach (Control cont in this.Controls)
            {
                if (cont.GetType() == typeof(Button) && cont.Enabled == false)
                {
                    return true;
                }
            }
            return false;
        }
        private void PerformClick(int nr)
        {
            switch (nr)
            {
                case 0: btnTop.PerformClick(); break;
                case 1: btnMid.PerformClick(); break;
                case 2: btnAdc.PerformClick(); break;
                case 3: btnJun.PerformClick(); break;
                case 4: btnSup.PerformClick(); break;
                default: btnAll.PerformClick(); break;
            }
        }
        private void cbTopWin_CheckedChanged(object sender, EventArgs e)
        {
            if (!pnWeb.Visible)
            {
                if (cbTopWin.Checked)
                {
                    int nr = GetDisabldeButton();
                    EnableAllButtons();
                    PerformClick(nr);
                }
                else
                {
                    EnableAllButtons();
                    btnAll.PerformClick();
                }
            }
            else
            {
                if (OneIsDisabled())
                {
                    int nr = GetDisabldeButton();
                    EnableAllButtons();
                    PerformClick(nr);
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var dr = new FormMessage(
               "Initiating the update process...",
                "Are you sure you want to check for a new update and start the update process?" +
               "\nThis process will disable buttons and close/restart the application!" +
               "\nPlease don't close the application during update process!" +
               "\nDo you want to start the update now?!",
               MessageBoxButtons.YesNo,
               this.Right - this.Width / 2,
               this.Bottom - this.Height / 2).ShowDialog();
            if (dr != DialogResult.Yes)
            {
                return;
            }
            DisableAllConstrols();
            Cursor.Current = Cursors.WaitCursor;
            updatig = true;
            int vers = int.Parse(Application.ProductVersion.Split('.')[2]);
            vers++;
            DownloadHandler downloadHandler = new DownloadHandler();
            ChromiumWebBrowser downloadBrowser = new ChromiumWebBrowser();
            downloadBrowser.FrameLoadStart += DownloadBrowser_FrameLoadStart;
            downloadBrowser.LoadingStateChanged += DownloadBrowser_LoadingStateChanged;
            downloadBrowser.Paint += DownloadBrowser_Paint;
            downloadBrowser.Cursor = Cursors.WaitCursor;
            pnWeb.Controls.Add(downloadBrowser);
            pnWeb.Visible = true;
            pnWeb.BringToFront();
            downloadBrowser.DownloadHandler = downloadHandler;
            downloadBrowser.Load(@"https://tutorialeu.com/wp-content/uploads/2022/02/ChampRuneV" + vers + ".7z");
        }
        private void DownloadBrowser_Paint(object sender, PaintEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void DownloadBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void DownloadBrowser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }
        void DisableAllConstrols()
        {
            btnAll.Enabled = false;
            btnTop.Enabled = false;
            btnMid.Enabled = false;
            btnAdc.Enabled = false;
            btnJun.Enabled = false;
            btnSup.Enabled = false;
            btnRune.Enabled = false;
            btnItems.Enabled = false;
            tbSearch.Enabled = false;
            nudPatch1.Enabled = false;
            nudPatch2.Enabled = false;
            cbTopWin.Enabled = false;
            nudStack.Enabled = false;
            tbSize.Enabled = false;
            btnUpdate.Enabled = false;
            btnClearCache.Enabled = false;
            btnUpdateRune.Enabled = false;
            tsmiType.Enabled = false;
            btnTheme.Enabled = false;
            btnAbout.Enabled = false;
            btnCounter.Enabled = false;
            cbSearch.Enabled = false;
            cbTopWin.Enabled = false;
            cbRegion.Enabled = false;
        }
        void EnableAllConstrols()
        {
            btnAll.Enabled = true;
            btnTop.Enabled = true;
            btnMid.Enabled = true;
            btnAdc.Enabled = true;
            btnJun.Enabled = true;
            btnSup.Enabled = true;
            btnRune.Enabled = true;
            btnItems.Enabled = true;
            tbSearch.Enabled = true;
            nudPatch1.Enabled = true;
            nudPatch2.Enabled = true;
            cbTopWin.Enabled = true;
            nudStack.Enabled = true;
            tbSize.Enabled = true;
            btnUpdate.Enabled = true;
            btnClearCache.Enabled = true;
            btnUpdateRune.Enabled = true;
            tsmiType.Enabled = true;
            btnTheme.Enabled = true;
            btnAbout.Enabled = true;
            btnCounter.Enabled = true;
            cbSearch.Enabled = true;
            cbTopWin.Enabled = true;
            cbRegion.Enabled = true;
        }

        private void btnUpdateRune_Click_1(object sender, EventArgs e)
        {
            if (runeIsOppened)
            {
                return;
            }
            chromeBrowser.GetMainFrame().GetSourceAsync().ContinueWith(taskHtml =>
            {
                var html = taskHtml.Result;
                var aram = tsmiAram.Checked;
                using (var stream = GenerateStreamFromString(html))
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.runeIsOppened = true;
                    });
                    RuneImporter localRuneImporter = null;
                    try
                    {

                        HtmlNodeNavigator navigator = new HtmlNodeNavigator(stream);
                        var keyStones = navigator.Select((".//div[@class='perk-style-title']"));
                        List<string> keyStoneRunes = GetDefaultRunesValues(keyStones);

                        var selectedPerks1 = navigator.Select((".//div[@class='perk keystone perk-active']"));
                        List<string> runes = GetFinalRunes(selectedPerks1);

                        var selectedPerks2 = navigator.Select((".//div[@class='perk perk-active']"));
                        List<string> runes2 = GetFinal1Runes(selectedPerks2);
                        runes.AddRange(runes2);
                        var selectedShards = navigator.Select((".//div[@class='shard shard-active']"));
                        List<string> shards = GetShardsNames(selectedShards);

                        var selectedSpells = navigator.Select((".//div[@class='content-section_content summoner-spells']//img"));
                        List<string> spells = GetRunesNames(selectedSpells);


                        Point loc = (e as MouseEventArgs).Location;
                        if (keyStoneRunes.Count == 0 || runes.Count == 0 || keyStoneRunes.Count == 0 || shards.Count == 0)
                        {
                            new FormMessage("Runes not found!", "Try to select a champion first! Nr rune found: " +
                                keyStoneRunes.Count + runes.Count + keyStoneRunes.Count + shards.Count, loc.X - 500, loc.Y + 110).ShowDialog();
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.runeIsOppened = false;
                            });
                            return;
                        }

                        var champNameS = navigator.Select((".//span[@class='champion-name']"));
                        champNameS.MoveNext();
                        var champName = champNameS.Current.Value;
                        var imageNameS = navigator.Select((".//img[@class='champion-image']"));
                        imageNameS.MoveNext();
                        var imageName = imageNameS.Current.OuterXml.Split('"')[3];


                        localRuneImporter = new RuneImporter(keyStoneRunes[0], runes[0], runes[1], runes[2], runes[3],
                        keyStoneRunes[1], runes[4], runes[5], shards[0], shards[1], shards[2], spells[0], spells[1], aram,
                        champName, imageName, phase, new Point(this.Location.X + loc.X, this.Location.Y + loc.Y));
                    }
                    catch (Exception ex)
                    {
                        var FormMessage = new FormMessage("", "Exception on opening the importer: \n" + ex.Message + " \nSend this message to: support@tutorialeu.com", 0, 0).ShowDialog();
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.runeIsOppened = false;
                        });
                        return;
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        runeImporter = localRuneImporter;
                        runeImporter.BackgroundImage = backbroundPictureBox.Image;
                        try
                        {
                            runeImporter.ShowDialog(this);
                        }
                        catch (Exception ex)
                        {
                            new FormMessage("", ex.Message, this.Right - this.Width / 2, this.Bottom - this.Height / 2);
                        }
                        runeIsOppened = false;
                    });


                }

            });
        }

        #region Minimise Maximise Handler

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        void MoveFormRelease(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
            if (e.Button == MouseButtons.Left && e.Clicks >= 2)
            {
                pnTitle_MouseDoubleClick(sender, e);
                return;
            }

            if (e.Button != MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            MoveFormRelease(sender, e);
        }
        private void pnTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                    btnMaximize.Text = @"🗗";
                }
                else if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    btnMaximize.Text = @"🗖";
                }
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {

                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Text = @"🗗";
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Text = @"🗖";
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            Button crtButton = sender as Button;
            crtButton.BackColor = Color.Red;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            Button crtButton = sender as Button;
            crtButton.BackColor = Color.Black;
        }
        private void LoadBackground()
        {
            if (!string.IsNullOrEmpty(backgroundLink))
            {
                backbroundPictureBox = new PictureBox();
                backbroundPictureBox.WaitOnLoad = true;
                backbroundPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                backbroundPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                backbroundPictureBox.LoadAsync(backgroundLink);
                this.BackgroundImage = backbroundPictureBox.Image;
                if (this.themeSelector != null)
                {
                    this.themeSelector.BackgroundImage = backbroundPictureBox.Image;
                }
                if (this.runeImporter != null)
                {
                    this.runeImporter.BackgroundImage = backbroundPictureBox.Image;
                }
            }
            else
            {
                backbroundPictureBox = new PictureBox();
                backbroundPictureBox.Image = this.BackgroundImage;
            }
        }
        private void btnTheme_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (champions.Keys.Count == 0)
            {
                new FormMessage("", "Champion names are not loaded!", this.Right - this.Width / 2, this.Bottom - this.Height / 2).ShowDialog();
                return;
            }
            themeSelector = new ThemeSelector(champions.Keys.ToList(), 0, this.Right - this.Width / 2, this.Bottom - this.Height / 2);
            themeSelector.BackgroundImage = backbroundPictureBox.Image;
            Cursor.Current = Cursors.Default;
            var result = themeSelector.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(themeSelector.selectedLink))
                {
                    backgroundLink = themeSelector.selectedLink;
                    LoadBackground();
                }
                else
                {
                    btnTheme_Click(sender, e);
                }
            }
        }
        #endregion
        #region Game Type Selection
        private void tsmiRankedSolo_Click(object sender, EventArgs e)
        {
            checkedTsmi.Checked = false;
            checkedTsmi = sender as ToolStripMenuItem;
            tsmiType.Text = checkedTsmi.Text;
            tsmiType.Tag = checkedTsmi.Tag;
            tsmiType.Image = checkedTsmi.Image;
            checkedTsmi.Checked = true;
            var defaultRank = checkedTsmi.DropDownItems[5] as ToolStripMenuItem;
            defaultRank.Checked = true;
            defaultRank.PerformClick();

        }
        // Aram
        private void aRAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedTsmi.Checked = false;
            checkedTsmi = sender as ToolStripMenuItem;
            tsmiType.Text = checkedTsmi.Text;
            tsmiType.Tag = checkedTsmi.Tag;
            tsmiType.Image = checkedTsmi.Image;
            checkedTsmi.Checked = true;
            tsmiRankedFlex.Checked = false;
            tsmiRankedSolo.Checked = false;
            tsmiNormalBlind.Checked = false;
            tsmiNormalDraft.Checked = false;
        }
        // Ranked Flex
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            checkedTsmi.Checked = false;
            checkedTsmi = sender as ToolStripMenuItem;
            tsmiType.Text = checkedTsmi.Text;
            tsmiType.Tag = checkedTsmi.Tag;
            tsmiType.Image = checkedTsmi.Image;
            checkedTsmi.Checked = true;
            var defaultRank = checkedTsmi.DropDownItems[5] as ToolStripMenuItem;
            defaultRank.Checked = true;
            defaultRank.PerformClick();
        }

        private void normalBlindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedTsmi.Checked = false;
            checkedTsmi = sender as ToolStripMenuItem;
            tsmiType.Text = checkedTsmi.Text;
            tsmiType.Tag = checkedTsmi.Tag;
            tsmiType.Image = checkedTsmi.Image;
            checkedTsmi.Checked = true;
            tsmiAram.Checked = false;
            tsmiRankedFlex.Checked = false;
            tsmiRankedSolo.Checked = false;
            tsmiNormalDraft.Checked = false;
        }

        private void normalDraftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedTsmi.Checked = false;
            checkedTsmi = sender as ToolStripMenuItem;
            tsmiType.Text = checkedTsmi.Text;
            tsmiType.Tag = checkedTsmi.Tag;
            tsmiType.Image = checkedTsmi.Image;
            checkedTsmi.Checked = true;
            tsmiAram.Checked = false;
            tsmiRankedFlex.Checked = false;
            tsmiRankedSolo.Checked = false;
            tsmiNormalBlind.Checked = false;
        }
        #endregion

        private void RankedChangeSelected(object sender, ToolStripMenuItem rankedTSMI, string shortName)
        {
            checkedTsmi.Checked = false;
            checkedTsmi = sender as ToolStripMenuItem;
            tsmiType.Text = rankedTSMI.Text + " " + shortName;
            tsmiType.Tag = rankedTSMI.Tag;
            selectedRank = int.Parse(checkedTsmi.Tag.ToString());
            tsmiType.ToolTipText = tsmiRankedSolo.Text + " " + checkedTsmi.Text;
            tsmiType.Image = checkedTsmi.Image;
            checkedTsmi.Checked = true;
        }
        #region Ranked Solo Ranked Selection
        private void tsmiPlatinumPlusS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "P+");
        }

        private void tsmiDiamondPlusS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "D+");
        }

        private void tsmiDiamond2PlusS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "D2+");
        }

        private void tsmiMasterPlusS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "M+");
        }

        private void tsmiAllRanksS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "AR");
        }

        private void tsmiChallengerS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "Ch");
        }

        private void tsmiGrandmasterS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "Gm");
        }
        private void tsmiMasterS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "Ma");
        }

        private void tsmiDiamondS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "Di");
        }

        private void tsmiPlatinumS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "Pl");
        }

        private void tsmiGoldS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "Go");
        }

        private void tsmiSilverS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "Si");
        }

        private void tsmiBronzeS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "Br");
        }

        private void tsmiIronS_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedSolo, "Ir");
        }
        #endregion
        #region Ranked Flex Ranked Selection
        private void tsmiPlatinumPlusF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "P+");
        }
        private void tsmiDiamondPlusF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "D+");
        }
        private void tsmiDiamond2PlusF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "D2+");
        }

        private void tsmiMasterPlusF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "M+");
        }

        private void tsmiAllRanksF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "AR");
        }

        private void tsmiChallengerF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "Ch");
        }
        private void tsmiGrandmasterF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "Gr");
        }
        private void tsmiMasterF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "Ma");
        }

        private void tsmiDiamondF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "Di");
        }

        private void tsmiPlatinumF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "Pl");
        }

        private void tsmiGoldF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "Go");
        }

        private void tsmiSilverF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "Si");
        }

        private void tsmiBronzeF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "Br");
        }

        private void tsmiIronF_Click(object sender, EventArgs e)
        {
            RankedChangeSelected(sender, tsmiRankedFlex, "Ir");
        }
        #endregion


        private void tsmiType_DropDownClosed(object sender, EventArgs e)
        {
            if (selectedName != null && selectedName != "")
            {
                LoadNextChamp(selectedName);
            }
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            var champSearch = sender as TextBox;
            champSearch.SelectAll();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new FormMessage("Champ Rune: v" + Application.ProductVersion,
                "© Created by TutorialEu" +
                "\nAll rights reserved!" +
                "\nFor any bug and problems contact:" +
                "\nsupport@tutorialeu.com",
                this.Right - this.Width / 2, this.Bottom - this.Height / 2).ShowDialog();
        }

        private void nudPatch1_ValueChanged(object sender, EventArgs e)
        {
            if (nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString() != selectedPatch)
            {
                //UpdateWithImagesFromUGG();
            }
        }

        private void nudPatch2_ValueChanged(object sender, EventArgs e)
        {
            if (nudPatch1.Value.ToString() + "_" + nudPatch2.Value.ToString() != selectedPatch)
            {
                //UpdateWithImagesFromUGG();
            }
        }

        private void lblSearch_MouseDown(object sender, MouseEventArgs e)
        {
            MoveFormRelease(sender, e);
        }

        private void lblSize_MouseDown(object sender, MouseEventArgs e)
        {
            MoveFormRelease(sender, e);
        }

        private void lblPatck_MouseDown(object sender, MouseEventArgs e)
        {
            MoveFormRelease(sender, e);
        }

        private void lblPhase_MouseDown(object sender, MouseEventArgs e)
        {
            MoveFormRelease(sender, e);
        }
        ToolTip t1 = new ToolTip();
        private void button1_MouseHover(object sender, EventArgs e)
        {
            t1.Show("   Counter Pick", sender as Button);
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            OpenLink("https://www.counterstats.net/", false); //"https://pros.lol/champions/"
            //CounterPick cp = new CounterPick(cpChamps);
        }

        private void checkBox1_MouseHover(object sender, EventArgs e)
        {
            t1.Show("   Check for player search\n    then press enter!", sender as CheckBox);
        }

        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void cbTopWin_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void lblSearch_MouseDown_1(object sender, MouseEventArgs e)
        {
            MoveFormRelease(sender, e);
        }

        private void lblTopWin_MouseDown(object sender, MouseEventArgs e)
        {
            MoveFormRelease(sender, e);
        }

        private void cbTopWin_MouseHover(object sender, EventArgs e)
        {
            t1.Show("   Check then select a lane to see the top win list", sender as CheckBox);
        }

        private void tbSearch_Validated(object sender, EventArgs e)
        {

        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbSearch.Checked)
                {
                    if (!string.IsNullOrEmpty(tbSearch.Text))
                    {
                        var composedLink = "u.gg/lol/profile/" + regions[cbRegion.SelectedIndex] + "/" + tbSearch.Text.Trim() + "/overview";
                        OpenLink(composedLink, true);
                    }
                }
                else
                {
                    selectedName = champions?.FirstOrDefault(x => x.Value.image.Visible == true).Value.image.Name.Trim().ToLower();
                    if (!string.IsNullOrEmpty(selectedName))
                    {
                        LoadNextChamp(selectedName);
                    }
                }
            }
        }

        private void cbSearch_CheckedChanged(object sender, EventArgs e)
        {
            var crtCheckbox = sender as CheckBox;
            if (!crtCheckbox.Checked)
            {
                pnWeb.Visible = false;
                pnWeb.SendToBack();
            }

        }

        private void tbSearch_MouseHover(object sender, EventArgs e)
        {
            t1.Show("   Press enter to search!", sender as TextBox);
        }

        private void btnTop_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
