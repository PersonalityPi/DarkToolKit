using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DarkPluginLib;
namespace PluginExample
{
    public partial class HelloForm : DevExpress.XtraEditors.XtraForm
    {
        public HelloForm()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DarkLog.WriteLine(txtMessage.Text);
        }

        private void HelloForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HelloToolkit.runningForm = false;
        }

        private void HelloForm_Load(object sender, EventArgs e)
        {
            HelloToolkit.runningForm = true;
            lblDebugMode.Text = "Debug Mode: " + HelloToolkit.IsDebugMode.ToString();
            lblHaloOnlineFolder.Text = "Halo Online Folder: " + DarkSettings.HaloOnlineFolder;
        }
    }
}
