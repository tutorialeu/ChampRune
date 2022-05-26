using CefSharp;
using CefSharp.WinForms;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.XPath;

namespace ChampRune
{
    public partial class CounterPick : Form
    {
        string startLink = "https://www.counterstats.net/league-of-legends/";
        string firstChamp = "";
        string secondChamp = "";
        public string selectedLink = "";
        public string lain = "mid";
        ChromiumWebBrowser cb;
        //Panel pnWeb;
        List<string> lains;
        Color pb1 = Color.Yellow;
        Color pb2 = Color.Yellow;

        private int GetLainIndex(string founLain)
        {
            switch (founLain)
            {
                case "top": return 0;
                case "mid": return 1;
                case "adc": return 2;
                case "jungle": return 3;
                case "support": return 4;
            }
            return 0;
        }
        public CounterPick(List<string> champs, List<string> lains, ChromiumWebBrowser cb, int centerX, int centerY)
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();
            foreach (var champ in champs)
            {
                cbChamp1.Items.Add(champ);
            }
            foreach (var champ in champs)
            {
                cbChamp2.Items.Add(champ);
            }
            //cbChamp1.SelectedIndex = 0;
            //cbChamp2.SelectedIndex = 0;
            cbLain.SelectedIndex = 0;
            this.cb = cb;
            this.cb.FrameLoadEnd += Cb_FrameLoadEnd;
            this.lains = lains;
            this.Location = new Point(centerX - this.Width / 2, centerY - this.Height / 2);
            this.BringToFront();
            this.Cursor = Cursors.Default;

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
        private void Cb_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            string url = e.Url;
            if (url.StartsWith(startLink))
            {
                var t = this.cb.GetMainFrame().GetSourceAsync().ContinueWith(taskHtml =>
                {
                    var html = taskHtml.Result;
                    using (var stream = GenerateStreamFromString(html))
                    {
                        HtmlNodeNavigator navigator = new HtmlNodeNavigator(stream);
                        var championNames = navigator.Select((".//div [@class='vs-head__circle vs-head__circle--winner']"));
                        string winner = GetWinnerChampName(championNames);
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (string.IsNullOrEmpty(winner))
                            {
                                this.cbFirst.BackColor = Color.Yellow;
                                this.cbFirst.Checked = true;
                                this.cbFirst.Text = "Same";
                                this.cbSecond.BackColor = Color.Yellow;
                                this.cbSecond.Checked = true;
                                this.cbSecond.Text = "Same";
                            }
                            else
                            {
                                if (this.cbChamp1.Text.ToLower().Trim() == winner)
                                {
                                    this.cbFirst.BackColor = Color.ForestGreen;
                                    this.cbFirst.Checked = true;
                                    this.cbFirst.Text = "Win";
                                    this.pb1 = Color.ForestGreen;
                                    this.pbChamp1.Invalidate();
                                    this.cbSecond.BackColor = Color.Red;
                                    this.cbSecond.Checked = false;
                                    this.cbSecond.Text = "Lose";
                                    this.pb2 = Color.Red;
                                    this.pbChamp2.Invalidate();
                                }
                                else
                                {
                                    this.cbFirst.BackColor = Color.Red;
                                    this.cbFirst.Checked = false;
                                    this.cbFirst.Text = "Lose";
                                    this.pb1 = Color.Red;
                                    this.pbChamp1.Invalidate();
                                    this.cbSecond.BackColor = Color.ForestGreen;
                                    this.cbSecond.Checked = true;
                                    this.cbSecond.Text = "Win";
                                    this.pb2 = Color.ForestGreen;
                                    this.pbChamp2.Invalidate();
                                }
                            }
                            this.Cursor = Cursors.Default;
                            linkMoreStats.Enabled = true;
                        });

                    }
                });



                return;
            }
            else
            {
                cb.StopFinding(true);
            }
        }

        private void ThemeSelector_Load(object sender, EventArgs e)
        {
            this.cbFirst.Text = "Unknown";
            this.cbSecond.Text = "Unknown";
        }

        private void RuneImporter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        public static bool isValidURL(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string htmlCode = client.DownloadString(url);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void ThemeSelector_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);

            if (e.Button != MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        string GetWinnerChampName(XPathNodeIterator keystone)
        {
            string champ = "";
            for (int i = 0; i < keystone.Count; i++)
            {
                keystone.MoveNext();
                champ = Regex.Split(keystone.Current.InnerXml.Split('"')[1], "/").Last();
                break;
            }
            return champ;
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (firstChamp == secondChamp)
            {
                return;
            }
            string finalLink = startLink + firstChamp + @"/vs-" + secondChamp + @"/" + lain + "/all";
            cb.Load(finalLink);
            linkMoreStats.Tag = finalLink;
            this.Cursor = Cursors.WaitCursor;
            linkMoreStats.Enabled = false;
        }

        private void cbChamps_SelectedIndexChanged(object sender, EventArgs e)
        {
            secondChamp =
      (sender as ComboBox).Text;
            pb2 = Color.Yellow;
            cbSecond.BackColor = Color.Yellow;
            cbSecond.Text = "Unknown";
            cbSecond.Checked = false;
            pbChamp2.LoadAsync(@"https://www.mobafire.com/images/champion/square/" + secondChamp + ".png");
        }

        private void cbChamp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            firstChamp =
            (sender as ComboBox).Text;
            pb1 = Color.Yellow;
            cbFirst.BackColor = Color.Yellow;
            cbFirst.Text = "Unknown";
            cbFirst.Checked = false;
            pbChamp1.LoadAsync(@"https://www.mobafire.com/images/champion/square/" + firstChamp + ".png");
        }

        private void cbLain_SelectedIndexChanged(object sender, EventArgs e)
        {
            lain = (sender as ComboBox).Text.ToLower();
        }

        private void cbChamp1_TextChanged(object sender, EventArgs e)
        {
            var crtCombo = sender as ComboBox;
            if (!string.IsNullOrEmpty(crtCombo.Text))
            {
                int items = 0;
                int index = 0;
                for (int i = 0; i < cbChamp1.Items.Count; i++)
                {
                    if (cbChamp1.Items[i].ToString().StartsWith(crtCombo.Text))
                    {
                        items++;
                        index = i;
                    }
                }
                if (items == 1)
                {
                    cbChamp1.SelectedIndex = index;
                    cbLain.SelectedIndex = GetLainIndex(lains[index]);
                    cbChamp2.SelectAll();
                    if (!string.IsNullOrEmpty(cbChamp2.Text))
                    {
                        btnCheck.Select();
                    }
                    else
                    {
                        cbChamp2.Select();
                    }
                }
            }
        }

        private void cbChamp2_TextChanged(object sender, EventArgs e)
        {
            var crtCombo = sender as ComboBox;
            if (!string.IsNullOrEmpty(crtCombo.Text))
            {
                int items = 0;
                int index = 0;
                for (int i = 0; i < cbChamp2.Items.Count; i++)
                {
                    if (cbChamp2.Items[i].ToString().StartsWith(crtCombo.Text))
                    {
                        items++;
                        index = i;
                    }
                }
                if (items == 1)
                {
                    cbChamp2.SelectedIndex = index;
                    if (!string.IsNullOrEmpty(cbChamp1.Text))
                    {
                        btnCheck.Select();
                    }
                }
            }
        }

        private void cbLain_TextChanged(object sender, EventArgs e)
        {
            var crtCombo = sender as ComboBox;
            if (!string.IsNullOrEmpty(crtCombo.Text))
            {
                int items = 0;
                int index = 0;
                for (int i = 0; i < cbLain.Items.Count; i++)
                {
                    if (cbLain.Items[i].ToString().StartsWith(crtCombo.Text))
                    {
                        items++;
                        index = i;
                    }
                }
                if (items == 1)
                {
                    cbLain.SelectedIndex = index;
                    cbLain.SelectAll();
                    if (string.IsNullOrEmpty(cbChamp1.Text))
                    {
                        cbChamp1.Select();
                    }
                    else
                    if (string.IsNullOrEmpty(cbChamp2.Text))
                    {
                        cbChamp2.Select();
                    }
                    else
                    {
                        btnCheck.Select();
                    }
                }
            }
        }

        private void linkMoreStats_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkMoreStats.Tag != null)
            {
                Process.Start(linkMoreStats.Tag.ToString());
                //pnWeb.BringToFront();
                //pnWeb.Show();
            }
        }

        private void pbChamp1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pbChamp1.ClientRectangle, pb1, ButtonBorderStyle.Solid);
        }

        private void pbChamp2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pbChamp2.ClientRectangle, pb2, ButtonBorderStyle.Solid);
        }
    }
}
