using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChampRune
{
    public partial class ThemeSelector : Form
    {
        string startLink = "http://ddragon.leagueoflegends.com/cdn/img/champion/splash/";
        string extension = ".jpg";
        const int DEFAULT_BUTTON_LOCATION = 200;
        const int OFFSET = 10;
        public string selectedLink = "";
        public ThemeSelector(List<string> champs, int index, int centerX, int centerY)
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();
            foreach (var champ in champs)
            {
                cbChamps.Items.Add(champ);
            }
            cbChamps.SelectedIndex = index;
            this.Location = new Point(centerX - this.Width / 2, centerY - this.Height / 2);
            this.Cursor = Cursors.Default;

        }

        private void ThemeSelector_Load(object sender, EventArgs e)
        {

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

        private void btnLoad_Click(object sender, EventArgs e)
        {


        }
        private void DeselectOther()
        {
            foreach (var image in pnImages.Controls)
            {
                if ((image as PictureBox).BorderStyle != BorderStyle.None)
                {
                    (image as PictureBox).BorderStyle = BorderStyle.None;
                }
            }
        }
        private void Pb_Click(object sender, EventArgs e)
        {
            DeselectOther();
            var pb = sender as PictureBox;
            pb.BorderStyle = BorderStyle.Fixed3D;
            selectedLink = pb.Name;
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedLink))
            {
                MessageBox.Show(this, "Select a theme first!");
            }
            else
            {
                this.Close();
            }
        }

        private void cbChamps_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pnImages.Controls.Clear();
            var crtName = cbChamps.Items[cbChamps.SelectedIndex].ToString();
            if (crtName == "ChoGath" || crtName == "VelKoz" || crtName == "LeBlanc") { crtName = crtName.Substring(0, 1) + crtName.Substring(1).ToLower(); }
            if (crtName == "Wukong") { crtName = "MonkeyKing"; }
            int i = 0;

            int locX = 0, locY = OFFSET;
            this.Cursor = Cursors.WaitCursor;

            while (true)
            {

                var finalLink = startLink + crtName + "_" + i + extension;
                if (!isValidURL(finalLink) || i == 50)
                {
                    break;
                }
                PictureBox pb = new PictureBox();
                pb.WaitOnLoad = true;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Size = new Size(DEFAULT_BUTTON_LOCATION, DEFAULT_BUTTON_LOCATION);
                pb.Location = new Point(locX, locY);
                pb.LoadAsync(finalLink);
                if (locX + pb.Width < this.pnImages.Width)
                {
                    locX += pb.Width + OFFSET;
                }
                else
                {
                    locX = 0;
                    locY += pb.Height + OFFSET;
                }
                this.pnImages.Controls.Add(pb);
                pb.LoadAsync(finalLink);
                pb.Visible = true;
                pb.Refresh();
                pb.Click += Pb_Click;
                pb.Name = finalLink;
                this.pnImages.Refresh();
                i++;
            }

            this.Cursor = Cursors.Default;
        }

        private void cbChamps_TextChanged(object sender, EventArgs e)
        {
            var crtCombo = sender as ComboBox;
            if (!string.IsNullOrEmpty(crtCombo.Text))
            {
                int items = 0;
                int index = 0;
                for (int i = 0; i < cbChamps.Items.Count; i++)
                {
                    if (cbChamps.Items[i].ToString().ToLower().StartsWith(crtCombo.Text.ToLower()))
                    {
                        items++;
                        index = i;
                    }
                }
                if (items == 1)
                {
                    cbChamps.SelectedIndex = index;
                    btnApply.Select();
                }
            }
        }

        private void cbChamps_Enter(object sender, EventArgs e)
        {
            cbChamps.SelectAll();
        }
    }
}