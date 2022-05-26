using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChampRune
{
    public partial class FormMessage : Form
    {
        public FormMessage(string title, string text, int x, int y)
        {
            InitializeComponent();
            this.lblTitle.Text = title;
            this.lblMessage.Text = text;

            this.Size = new Size(this.lblMessage.Width + 50, this.lblMessage.Height + 150);
            this.Location = new Point(x - this.Width / 2, y - this.Height / 2);
            this.BringToFront();
            this.Refresh();
        }
        public FormMessage(string title, string text, MessageBoxButtons type, int x, int y)
        {
            InitializeComponent();
            if (type == MessageBoxButtons.YesNo)
            {
                btnOk.Visible = false;
                btnYes.Visible = true;
                btnNo.Visible = true;
            }
            this.lblTitle.Text = title;
            this.lblMessage.Text = text;
            this.Size = new Size(this.lblMessage.Width + 50, this.lblMessage.Height + 150);
            this.Location = new Point(x - this.Width / 2, y - this.Height / 2);
            this.BringToFront();
            this.Refresh();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void FormMessage_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);

            if (e.Button != MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);

            if (e.Button != MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void llLinks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(llLinks.Text);
        }
        /*
private void btnNo_Click(object sender, EventArgs e)
{
this.Dispose();
this.Close();
}
*/
    }
}
