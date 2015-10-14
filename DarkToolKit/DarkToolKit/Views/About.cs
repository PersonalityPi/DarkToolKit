using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkToolKit.Views
{
    public partial class About : DevExpress.XtraEditors.XtraForm
    {
        public About()
        {
            InitializeComponent();
        }


        private void About_FormClosing(object sender, EventArgs e)
        {

            ProgramGlobals.AboutWindowShowing = false;
        }
        private void About_Load(object sender, EventArgs e)
        {

            label1.Text = "DarkToolkit Built " + ProgramGlobals.Build + " (" + ProgramGlobals.BuildDate + ")";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start("https://darkcode.llf.to/halo/online?_fromDarkToolKit");
        }
    }
}
