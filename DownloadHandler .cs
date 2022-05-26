using CefSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ChampRune
{
    public class DownloadHandler : IDownloadHandler
    {
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

        public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem,
            IBeforeDownloadCallback callback)
        {
            Cursor.Current = Cursors.WaitCursor;
            OnBeforeDownloadFired?.Invoke(this, downloadItem);
            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
        }

        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem,
            IDownloadItemCallback callback)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (downloadItem.IsComplete)
            {
                Cursor.Current = Cursors.Default;
                var dr = MessageBox.Show("All you have to do is to: \r\n1.Close the app and then \r\n2.Unzip the dowloaded file!\r\nGo to file in: " + downloadItem.FullPath,
                    "New Update Saved?!",
                 MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string finalCache = Path.GetDirectoryName(downloadItem.FullPath);
                    Process.Start("explorer.exe", finalCache);
                }
            }
            OnDownloadUpdatedFired?.Invoke(this, downloadItem);
        }
    }
}
