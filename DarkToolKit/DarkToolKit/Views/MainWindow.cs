using DarkPluginLib;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraRichEdit.API.Native;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkToolKit
{

    public partial class MainWindow : DevExpress.XtraEditors.XtraForm
    {
        public static MainWindow _mainWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            _mainWindow = this;
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            DarkPluginLib.DarkSettings.HaloOnlineFolder = Properties.Settings.Default.HaloOnlineFolder;


            Thread isHaloRunning = new Thread(IsHaloRunning);
            isHaloRunning.Start();
            Thread pluginLog = new Thread(ConsoleLog.PluginLogReader);
            pluginLog.Start();
            Thread loadStartWindows = new Thread(LoadStartWindows);
            loadStartWindows.Start();

            Thread checkUpdates = new Thread(CheckForUpdates);
            checkUpdates.Start();
        }
        public void IsHaloRunning()
        {
            while (DarkPluginLib.DarkSettings.DarkIsRunning)
            {
                Process[] pname = Process.GetProcessesByName("eldorado");
                switch (pname.Length)
                {
                    case 0:
                        lblHaloOnlineRunning.Caption = "Halo Online is NOT running!";
                        DarkPluginLib.DarkSettings.HaloIsRunning = false;
                        break;
                    case 1:
                        lblHaloOnlineRunning.Caption = "Halo Online is running!";
                        DarkPluginLib.DarkSettings.HaloIsRunning = true;
                        break;
                    default:
                        DarkPluginLib.DarkSettings.HaloIsRunning = true;
                        lblHaloOnlineRunning.Caption = "WARNING: MORE THAN ONE COPY OF HALO ONLINE RUNNING! PLUGINS MAY MISBEHAVE";
                        break;

                }
                Thread.Sleep(100);
            }
        }
        public void LoadStartWindows()
        {
            ConsoleLog.WriteLine("Welcome to DarkToolKit!");
            ConsoleLog.WriteLine("--------------------------------");
            LoadToolWindow();
            ConsoleLog.WriteLine("--------------------------------");

        }

        public class UpdateCheck
        {
            public string version { get; set; }
            public string build_date { get; set; }
            public string update_url { get; set; }
        }
        public void SilentUpdates()
        {
            while (DarkPluginLib.DarkSettings.DarkIsRunning)
            {
                //Every 5 minutes we will check for a new update..
                //This will ensure everyone is running the latest most
                //Greatest releases of everything
                Thread.Sleep(300000);

                Assembly assem = Assembly.GetExecutingAssembly();
                Version vers = assem.GetName().Version;

                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        string json;
                        if (Properties.Settings.Default.BetaOptIn)
                        {
                            json = wc.DownloadString("https://halowiki.llf.to/toolkit/updates-beta.json");
                        }
                        else
                        {
                            json = wc.DownloadString("https://halowiki.llf.to/toolkit/updates.json");
                        }
                        UpdateCheck update = JsonConvert.DeserializeObject<UpdateCheck>(json);
                        Version updateVersion = null;
                        if (Version.TryParse(update.version, out updateVersion))
                        {
                            if (vers < updateVersion)
                            {
                                ConsoleLog.WriteLine("Update " + updateVersion + " required!");
                                ProgramGlobals.update_url = update.update_url;

                                _mainWindow.Invoke((MethodInvoker)delegate()
                                {
                                    ProgramGlobals.UpdateWindow = new DarkToolKit.Views.Update();
                                    ProgramGlobals.UpdateWindow.MdiParent = _mainWindow;
                                    ProgramGlobals.UpdateWindow.Show();
                                    ProgramGlobals.UpdateWindowShowing = true;
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

            }
        }

        public void CheckForUpdates()
        {
            ConsoleLog.WriteLine("Checking for updates...");
            Assembly assem = Assembly.GetExecutingAssembly();
            Version vers = assem.GetName().Version;
            string strpath = assem.Location;
            System.IO.FileInfo fi = new System.IO.FileInfo(strpath);

            ConsoleLog.WriteLine("Current Build = " + vers.ToString() + " (" + fi.LastWriteTime + ")");
            if (_mainWindow.InvokeRequired)
            {
                _mainWindow.Invoke(new MethodInvoker(delegate
                {
                    lblBuild.Caption = "Build " + vers.ToString() + " (" + fi.LastWriteTime + ")";
                }));
            }
            using (WebClient wc = new WebClient())
            {
                try
                {
                    string json;
                    if (Properties.Settings.Default.BetaOptIn)
                    {
                        json = wc.DownloadString("https://halowiki.llf.to/toolkit/updates-beta.json");
                    }
                    else
                    {
                        json = wc.DownloadString("https://halowiki.llf.to/toolkit/updates.json");
                    }
                    UpdateCheck update = JsonConvert.DeserializeObject<UpdateCheck>(json);
                    ConsoleLog.WriteLine("Latest Build = " + update.version + " (" + update.build_date + ")");
                    Version updateVersion = null;
                    if (Version.TryParse(update.version, out updateVersion))
                    {
                        if (vers < updateVersion)
                        {
                            ConsoleLog.WriteLine("Update " + updateVersion + " required!");
                            ProgramGlobals.update_url = update.update_url;

                            _mainWindow.Invoke((MethodInvoker)delegate()
                            {
                                ProgramGlobals.UpdateWindow = new DarkToolKit.Views.Update();
                                ProgramGlobals.UpdateWindow.MdiParent = _mainWindow;
                                ProgramGlobals.UpdateWindow.Show();
                                ProgramGlobals.UpdateWindowShowing = true;
                            });
                        }
                        else
                        {
                            ConsoleLog.WriteLine("You're running the latest release!");
                        }
                    }
                    else
                    {
                        ConsoleLog.WriteError("Unable to determain update version. Please visit https://halowiki.llf.to/ for the latest version");
                    }
                }
                catch (Exception e)
                {
                    ConsoleLog.WriteError("--------------------------------");
                    ConsoleLog.WriteError("Error Checking for Updates!");
                    ConsoleLog.WriteError(e.Message);
                    ConsoleLog.WriteError("--------------------------------");
                }
            }
        }
        public void LoadToolWindow()
        {
            if (_mainWindow.InvokeRequired)
            {
                _mainWindow.Invoke(new MethodInvoker(delegate
                {
                    LoadPlugins();
                    foreach (var darkPlugin in ProgramGlobals._Plugins)
                    {
                        DevExpress.XtraBars.BarButtonItem foo = new DevExpress.XtraBars.BarButtonItem(this.barManager1, darkPlugin.Value.Title);

                        foo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(b_ClickMenuStrip);
                        MainWindow._mainWindow.tsPlugins.AddItem(foo);


                        ToolStripMenuItem iconPluginlist = new ToolStripMenuItem(darkPlugin.Value.Title);
                        //iconPluginlist.Click += new EventHandler(Views.Tools.b_ClickMenuStrip);
                        contextMenuStrip1.Items.Add(iconPluginlist);

                        // DevExpress.XtraTreeList.FilterItem blah = new DevExpress.XtraTreeList.FilterItem("testing", "hi");

                    }


                    gridControl1.DataSource = ProgramGlobals._Plugins.Values.ToList();
                }));
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread checkUpdates = new Thread(CheckForUpdates);
            checkUpdates.Start();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DarkPluginLib.DarkSettings.DarkIsRunning = false;
            ProgramGlobals.Closing = true;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DarkPluginLib.DarkSettings.DarkIsRunning = false;
            ProgramGlobals.Closing = true;
            Application.Exit();
        }

        private void startHaloOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartHaloOnline();
        }

        private void contextMenuStrip1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            DarkTrayIcon.Visible = false;
        }


        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                DarkTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                DarkTrayIcon.BalloonTipTitle = "Hey! I'm down here!";
                DarkTrayIcon.BalloonTipText = "DarkToolKit is now running in the background. You can bring it back at any time by double clicking the icon.\nRight click for a menu full of goodies!";
                DarkTrayIcon.Visible = true;
                DarkTrayIcon.ShowBalloonTip(5000);
                this.ShowInTaskbar = false;
            }
        }

        private void launchHaloOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartHaloOnline();
        }

       // private IntPtr hWndOriginalParent;
       // private IntPtr hWndDocked;

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public void StartHaloOnline()
        {
            if (DarkPluginLib.DarkSettings.HaloOnlineFolder == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("You need to setup your Halo Online directory in File->Settings");
                return;
            }
            /*
            if (hWndDocked != IntPtr.Zero) //don't do anything if there's already a window docked.
                return;
             */
            ProcessStartInfo _processStartInfo = new ProcessStartInfo();
            _processStartInfo.WorkingDirectory = DarkPluginLib.DarkSettings.HaloOnlineFolder;
            _processStartInfo.FileName = @"eldorado.exe";
            _processStartInfo.Arguments = Properties.Settings.Default.HaloLaunchArguments;
            // _processStartInfo.CreateNoWindow = true;
            Process myProcess = Process.Start(_processStartInfo);
           /*
            while (hWndDocked == IntPtr.Zero)
            {
                myProcess.WaitForInputIdle(2000); //wait for the window to be ready for input;
                myProcess.Refresh();              //update process info
                if (myProcess.HasExited)
                {
                    return; //abort if the process finished before we got a handle.
                }
                hWndDocked = myProcess.MainWindowHandle;  //cache the window handle
            }

            hWndOriginalParent = SetParent(hWndDocked, panelControl1.Handle);
            MoveWindow(hWndDocked, 0, 0, panelControl1.Width, panelControl1.Height, true);
            panelControl1.SizeChanged += new EventHandler(GameWindowSmartResize);
            //Perform an initial call to set the size.
            GameWindowSmartResize(new Object(), new EventArgs());
            */
            ConsoleLog.WriteLine("Started Halo Online!");
            ConsoleLog.WriteLine("Arguments: " + Properties.Settings.Default.HaloLaunchArguments);
           // hWndDocked = IntPtr.Zero;
        }

        private void GameWindowSmartResize(object sender, EventArgs e)
        {
           // MoveWindow(hWndDocked, 0, 0, panelControl1.Width, panelControl1.Height, true);
        }
        private void settingsToolStripMenuItem_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ProgramGlobals.SettingsWindowShowing)
            {
                ProgramGlobals.SettingsWindow = new DarkToolKit.Views.Settings();
                ProgramGlobals.SettingsWindow.MdiParent = this;
                ProgramGlobals.SettingsWindow.Show();
                ProgramGlobals.SettingsWindowShowing = true;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ProgramGlobals.AboutWindowShowing)
            {
                ProgramGlobals.AboutWindow = new DarkToolKit.Views.About();
                ProgramGlobals.AboutWindow.MdiParent = this;
                ProgramGlobals.AboutWindow.Show();
                ProgramGlobals.AboutWindowShowing = true;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://halowiki.llf.to/?fromAboutMenu", "");
        }


        private void DarkTrayIcon_Click(object sender, EventArgs e)
        {
            popupMenu1.ShowPopup(MousePosition);
        }

        public static void ConsoleLogit(string Message)
        {
            if (_mainWindow.RichConsoleLog.InvokeRequired)
            {
                _mainWindow.RichConsoleLog.Invoke(new MethodInvoker(delegate
                {

                    _mainWindow.RichConsoleLog.Document.AppendText(Message);

                    _mainWindow.RichConsoleLog.Document.CaretPosition = _mainWindow.RichConsoleLog.Document.Range.End;
                    _mainWindow.RichConsoleLog.ScrollToCaret();
                }));
            }
            else
            {
                _mainWindow.RichConsoleLog.Document.AppendText(Message);
                _mainWindow.RichConsoleLog.Document.CaretPosition = _mainWindow.RichConsoleLog.Document.Range.End;
                _mainWindow.RichConsoleLog.ScrollToCaret();
            }
        }
        public static void ConsoleLogError(string Message)
        {
            if (_mainWindow.RichConsoleLog.InvokeRequired)
            {
                _mainWindow.RichConsoleLog.Invoke(new MethodInvoker(delegate
                {
                    DocumentRange range = _mainWindow.RichConsoleLog.Document.AppendText(Message + Environment.NewLine);
                    CharacterProperties cp = _mainWindow.RichConsoleLog.Document.BeginUpdateCharacters(range);
                    cp.ForeColor = Color.DarkRed;
                    _mainWindow.RichConsoleLog.Document.EndUpdateCharacters(cp);
                    _mainWindow.RichConsoleLog.Document.CaretPosition = _mainWindow.RichConsoleLog.Document.Range.End;
                    _mainWindow.RichConsoleLog.ScrollToCaret();
                }));
            }
            else
            {
                DocumentRange range = _mainWindow.RichConsoleLog.Document.AppendText(Message + Environment.NewLine);
                CharacterProperties cp = _mainWindow.RichConsoleLog.Document.BeginUpdateCharacters(range);
                cp.ForeColor = Color.Red;
                _mainWindow.RichConsoleLog.Document.EndUpdateCharacters(cp);
                _mainWindow.RichConsoleLog.Document.CaretPosition = _mainWindow.RichConsoleLog.Document.Range.End;
                _mainWindow.RichConsoleLog.ScrollToCaret();
            }
        }
        public static void ConsoleLogNL(string Message)
        {
            if (_mainWindow.RichConsoleLog.InvokeRequired)
            {
                _mainWindow.RichConsoleLog.Invoke(new MethodInvoker(delegate
                {
                    _mainWindow.RichConsoleLog.Document.AppendText(Message + Environment.NewLine);
                    _mainWindow.RichConsoleLog.Document.CaretPosition = _mainWindow.RichConsoleLog.Document.Range.End;
                    _mainWindow.RichConsoleLog.ScrollToCaret();
                }));
            }
            else
            {
                _mainWindow.RichConsoleLog.Document.AppendText(Message + Environment.NewLine);

                _mainWindow.RichConsoleLog.Document.CaretPosition = _mainWindow.RichConsoleLog.Document.Range.End;
                _mainWindow.RichConsoleLog.ScrollToCaret();
            }
        }

        private void layoutView1_FieldValueClick(object sender, DevExpress.XtraGrid.Views.Layout.Events.FieldValueClickEventArgs e)
        {
            if (e.Column.ToString() == "Plugin")
            {
                if (Properties.Settings.Default.HaloOnlineFolder != "")
                {
                    if (e.Column.ToString() != null)
                    {
                        string key = e.FieldValue.ToString();
                        if (ProgramGlobals._Plugins.ContainsKey(key))
                        {
                            DarkPlugin plugin = ProgramGlobals._Plugins[key];
                            RunDarkPlugin(plugin);
                        }
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please first setup your Halo Online folder in `File -> Settings`.");
                    ConsoleLog.WriteLine("Please first setup your Halo Online folder in `File -> Settings`.");
                }
            }
            else if (e.Column.ToString() == "URL")
            {
                Process.Start(e.FieldValue.ToString(), "");
            }
        }

        public void LoadPlugins()
        {

            ProgramGlobals._Plugins = new Dictionary<string, DarkPlugin>();
            ICollection<DarkPlugin> plugins = PluginLoader.LoadPlugins("Plugins");
            int pluginCount = 0;
            foreach (var item in plugins)
            {

                ProgramGlobals._Plugins.Add(item.Title, item);
                // _Plugins.Add(item.Description, item);
                // _Plugins.Add(item.Author, item);
                // _Plugins.Add(item.Url, item);
                // _Plugins.Add(item.Version.ToString(), item);
                // _Plugins.Add(item.Built, item);

                string[] pluginInfo = { 
                                          item.Description, 
                                          item.Author, 
                                          item.Version + " ("+item.Built+")"
                                      };
                /*
                listPlugins.Items.Add(item.Title).SubItems.AddRange(pluginInfo);

                //MainWindow._mainWindow.tsPlugins.DropDownItems.Add(ToolStripItem);
                //ToolStripItem.DropDownItems.Add(item2);
                //menustrip1.Items.Add(item);

                //Add to Tools window.
                DevExpress.XtraEditors.SimpleButton b = new DevExpress.XtraEditors.SimpleButton();
                b.Text = item.Title;
                b.BackColor = SystemColors.Control;
                b.Font = this.Font;
                b.Click += new EventHandler(b_Click);
                // Put it in the first column of the fourth row
                listPlugins.AddEmbeddedControl(b, 0, pluginCount);
                 */
                ConsoleLog.WriteLine("Loaded Plugin: " + item.Title + " (" + item.Version.ToString() + ")");
                pluginCount++;
            }

        }
        public static void b_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.HaloOnlineFolder != "")
            {
                Button b = sender as Button;
                if (sender != null)
                {
                    string key = b.Text;
                    if (ProgramGlobals._Plugins.ContainsKey(key))
                    {
                        DarkPlugin plugin = ProgramGlobals._Plugins[key];
                        RunDarkPlugin(plugin);
                    }
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please first setup your Halo Online folder in `File -> Settings`.");
                ConsoleLog.WriteLine("Please first setup your Halo Online folder in `File -> Settings`.");
            }
        }
        public static void b_ClickMenuStrip(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Properties.Settings.Default.HaloOnlineFolder != "")
            {
                if (e.Item.Caption != null)
                {
                    string key = e.Item.Caption;
                    if (ProgramGlobals._Plugins.ContainsKey(key))
                    {
                        DarkPlugin plugin = ProgramGlobals._Plugins[key];
                        RunDarkPlugin(plugin);
                    }
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please first setup your Halo Online folder in `File -> Settings`.");
                ConsoleLog.WriteLine("Please first setup your Halo Online folder in `File -> Settings`.");
            }
        }
        public static Thread RunDarkPlugin(DarkPlugin plugin)
        {
            var t = new Thread(() => RealStartPlugin(plugin));
            t.Start();
            return t;
        }
        private static void RealStartPlugin(DarkPlugin plugin)
        {
            if (_mainWindow.InvokeRequired)
            {
                _mainWindow.Invoke(new MethodInvoker(delegate
                {
                    //Lets check if the plugin author wants to handle exceptions.
                    //ConsoleLog.WriteLine("loaded plugin with " + plugin.DebugMode.ToString());
                    if (plugin.DebugMode)
                    {
                        plugin.DarkPluginMain();
                        //plugin.MainForm.MdiParent = MainWindow._mainWindow;
                    }
                    else
                    {
                        try
                        {
                            plugin.DarkPluginMain();
                            //plugin.MainForm.MdiParent = MainWindow._mainWindow;
                        }
                        catch (Exception e)
                        {
                            ConsoleLog.WriteError("A DarkPlugin has encountered an error!");
                            ConsoleLog.WriteError("Message: " + e.Message);
                            ConsoleLog.WriteError("StackTrace: " + e.StackTrace);
                            ConsoleLog.WriteError("Attributes: " + e.TargetSite.Attributes.ToString());
                        }
                    }
                }));
            }

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ProgramGlobals.SettingsWindowShowing)
            {
                ProgramGlobals.SettingsWindow = new DarkToolKit.Views.Settings();
                ProgramGlobals.SettingsWindow.MdiParent = this;
                ProgramGlobals.SettingsWindow.Show();
                ProgramGlobals.SettingsWindowShowing = true;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckForUpdates();
        }
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StartHaloOnline();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckForUpdates();
        }

        private void btnLaunchHaloOnline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StartHaloOnline();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DarkPluginLib.DarkSettings.DarkIsRunning = false;
            ProgramGlobals.Closing = true;
            Application.Exit();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("http://irc.lc/gamesurge/halowiki", "");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DarkPluginLib.DarkSettings.DarkIsRunning = false;
            ProgramGlobals.Closing = true;
            Application.Exit();
        }

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        private const uint SW_RESTORE = 0x09;


        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowWindow(this.Handle, SW_RESTORE);
            }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("https://halo.click/", "");
        }
    }
}