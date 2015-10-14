using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DarkToolKit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DarkPluginLib.DarkSettings.DarkIsRunning = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (Properties.Settings.Default.UpdateSettings)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.UpdateSettings = false;
                    Properties.Settings.Default.Save();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Updated settings from older release.. You may need to restart DTK");
                }
            }
            catch (Exception e)
            {
                var path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                File.Delete(path);
                DevExpress.XtraEditors.XtraMessageBox.Show("Something bad happened... Your settings had to be reset. Sorry about that.");
            }

            if (Properties.Settings.Default.HaloOnlineFolder != "")
            {
                Properties.Settings.Default.HaloOnlineFolder = Views.Settings.PathAddBackslash(Properties.Settings.Default.HaloOnlineFolder);
                Properties.Settings.Default.Save();
            }
            
            Assembly assem = Assembly.GetExecutingAssembly();
            Version vers = assem.GetName().Version;
            System.IO.FileInfo fi = new System.IO.FileInfo(assem.Location);

            ProgramGlobals.Build = vers.ToString();
            ProgramGlobals.BuildDate = fi.LastWriteTime.ToString();

            Application.Run(new MainWindow());
        }
    }
}
