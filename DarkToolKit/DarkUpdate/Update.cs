using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;
using System.Diagnostics;
namespace DarkUpdate
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
           bool updateSuccesful = true;
            try
            {
                foreach (var process in Process.GetProcessesByName("DarkToolKit"))
                {
                    richTextBox1.AppendText("Killing DarkToolKit Processes...");
                    process.Kill();
                }
                using (ZipArchive archive = ZipFile.OpenRead(System.IO.Path.GetFileName(DarkUpdate.Program.DarkUnzipMe)))
                {
                    //Loops through each file in the zip file
                    foreach (ZipArchiveEntry file in archive.Entries)
                    {
                        //Outputs relevant file information to the console
                        richTextBox1.AppendText("--------------------------------");
                        richTextBox1.AppendText("File Name: " + file.Name);
                        richTextBox1.AppendText("File Size: " + file.Length + " bytes");
                        richTextBox1.AppendText("Compression Ratio: " + ((double)file.CompressedLength / file.Length).ToString("0.0%"));

                        if (file.FullName == "DarkUpdate.exe")
                        {
                            continue;
                        }
                        if (file.FullName.EndsWith("/"))
                        {
                            Directory.CreateDirectory(file.FullName);
                        }

                        if (file.Length != 0)
                        {
                            Compression.ImprovedExtractToFile(file, System.Environment.CurrentDirectory, Compression.Overwrite.Always);
                        }
                    }
                }
                updateSuccesful = true;
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(ex.Message);
             }


            if (updateSuccesful)
            {
                try
                {
                    Process newToolkit = new Process();
                    newToolkit.StartInfo.UseShellExecute = true;
                    // You can start any process, HelloWorld is a do-nothing example.
                    newToolkit.StartInfo.FileName = System.Environment.CurrentDirectory + @"\DarkToolKit.exe";
                    //  newToolkit.StartInfo.CreateNoWindow = true;
                    newToolkit.Start();
                    // This code assumes the process you are starting will terminate itself.  
                    // Given that is is started without a window so you cannot terminate it  
                    // on the desktop, it must terminate itself or you can do it programmatically 
                    // from this application using the Kill method.

                }
                catch (Exception ex)
                {
                    richTextBox1.AppendText(ex.Message);
                }
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
