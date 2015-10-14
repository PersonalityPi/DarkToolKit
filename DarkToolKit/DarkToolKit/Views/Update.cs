using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using Helpers;
namespace DarkToolKit.Views
{
    public partial class Update : DevExpress.XtraEditors.XtraForm
    {
        public Update()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsoleLog.WriteLine("Update canceled. Please make sure you update soon to get the latest features!");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressPanel1.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            startDownload();
        }
        private void startDownload()
        {
            Thread thread = new Thread(() =>
            {
              
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(ProgramGlobals.update_url), System.IO.Path.GetFileName(ProgramGlobals.update_url));
            });
            thread.Start();
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                label1.Text = "Downloaded " + e.BytesReceived + " bytes of " + e.TotalBytesToReceive;
                progDownload.EditValue = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                ConsoleLog.WriteLine("Completed update download...!");
                label1.Text = "Completed!";

                try
                {
                    using (ZipArchive archive = ZipFile.OpenRead(System.IO.Path.GetFileName(System.IO.Path.GetFileName(ProgramGlobals.update_url))))
                    {
                        //Loops through each file in the zip file
                        foreach (ZipArchiveEntry file in archive.Entries)
                        {
                            //Outputs relevant file information to the console

                            //Lets make sure we have the latest DarkUpdate.exe from the download
                            //Before we run DarkUpdate! We might have fixed something in the updater.
                            if (file.FullName == "DarkUpdate.exe")
                            {
                                ConsoleLog.WriteLine("--------------------------------");
                                ConsoleLog.WriteLine("File Name: " + file.Name);
                                ConsoleLog.WriteLine("File Size: " + file.Length + " bytes");
                                ConsoleLog.WriteLine("Compression Ratio: " + ((double)file.CompressedLength / file.Length).ToString("0.0%"));

                                Compression.ImprovedExtractToFile(file, System.Environment.CurrentDirectory, Compression.Overwrite.Always);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ConsoleLog.WriteLine(ex.Message);
                }

                Process.Start("DarkUpdate.exe", System.IO.Path.GetFileName(ProgramGlobals.update_url));
                Process.GetCurrentProcess().Kill();
            });
        }

        private void Update_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://halowiki.llf.to/toolkit/changelog.html?v="+ProgramGlobals.Build);
        }
    }
}
