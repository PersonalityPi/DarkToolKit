using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
namespace DarkToolKit.Views
{
    public partial class Settings : DevExpress.XtraEditors.XtraForm
    {
        public Settings()
        {
            InitializeComponent();
        }
        public static string PathAddBackslash(string path)
        {
            // They're always one character but EndsWith is shorter than
            // array style access to last path character. Change this
            // if performance are a (measured) issue.
            string separator1 = Path.DirectorySeparatorChar.ToString();
            string separator2 = Path.AltDirectorySeparatorChar.ToString();

            // White spaces are always ignored (both heading and trailing)
            path = path.Trim();

            // Argument is always a directory name then if there is one
            // of allowed separators then I have nothing to do.
            if (path.EndsWith(separator1) || path.EndsWith(separator2))
                return path;

            // If there is the "alt" separator then I add a trailing one.
            if (path.Contains(separator2))
                return path + separator2;

            // If there is not an "alt" separator I add a "normal" one.
            // It means path may be with normal one or it has not any separator
            // (for example if it's just a directory name). In this case I
            // default to normal as users expect.
            return path + separator1;
        }
        private bool checkInstallDir(string dir)
        {
            if (File.Exists(dir + "maps/tags.dat"))
            {
                txtHaloOnlineDir.ErrorText = "";
                return true;
            }
            else
            {
                txtHaloOnlineDir.ErrorText = "Unable to find /maps/tags.dat.\nAre you sure this is your Halo Online directory?";
                ConsoleLog.WriteLine("Can't find tags.dat. Are you sure you chose a Halo Online directory?");
                
                DevExpress.XtraEditors.XtraMessageBox.Show("Please try again, Invalid Install Directory.");
                return false;
            }

        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdHaloOnline.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                txtHaloOnlineDir.Text = PathAddBackslash(fbdHaloOnline.SelectedPath);
                if (!checkInstallDir(txtHaloOnlineDir.Text))
                {
                    txtHaloOnlineDir.Text = "";
                }
            }
        }
        public class SettingsObject
        {
            public string Account { get; set; }
            public string SignInCode { get; set; }
            public bool FullScreen { get; set; }
            public bool Windowed { get; set; }
            public bool vSync { get; set; }
            public bool NoLauncher { get; set; }
            public bool ShowFps { get; set; }
            public bool D3d9 { get; set; }
            public bool NoD3d9 { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Adapter { get; set; }
            public int Environment { get; set; }
            public string LaunchString { get; set; }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtHaloOnlineDir.Text = PathAddBackslash(txtHaloOnlineDir.Text);
            if (checkInstallDir(txtHaloOnlineDir.Text))
            {
                SettingsObject settingsSave = new SettingsObject
                {
                    Account = txtAccount.Text,
                    SignInCode = txtSignInCode.Text,
                    FullScreen = chkFullscreen.Checked,
                    Windowed = chkWindowed.Checked,
                    vSync = chkVsync.Checked,
                    NoLauncher = chkNoLauncher.Checked,
                    ShowFps = chkShowFps.Checked,
                    D3d9 = chkD3d9.Checked,
                    NoD3d9 = chkNod3d9.Checked,
                    Adapter = Convert.ToInt32(spinAdapter.Value),
                };
                if (!String.IsNullOrEmpty(txtWidth.Text))
                {
                    settingsSave.Width = Convert.ToInt32(txtWidth.Text);
                }
                if (!String.IsNullOrEmpty(txtHeight.Text))
                {
                    settingsSave.Height = Convert.ToInt32(txtHeight.Text);
                }
                if (cbEnvironment.SelectedIndex >= 0)
                {
                    settingsSave.Environment = cbEnvironment.SelectedIndex;
                }
                string jsonSaveSettings = JsonConvert.SerializeObject(settingsSave, Formatting.Indented);

                Properties.Settings.Default.BetaOptIn = chkBranch.Checked;
                Properties.Settings.Default.HaloLaunchArguments = launchString;
                Properties.Settings.Default.SettingsJSON = jsonSaveSettings;
                Properties.Settings.Default.HaloOnlineFolder = txtHaloOnlineDir.Text;
                Properties.Settings.Default.Save();

                DarkPluginLib.DarkSettings.HaloOnlineFolder = Properties.Settings.Default.HaloOnlineFolder;
                ConsoleLog.WriteLine("Saved Settings.");
                DevExpress.XtraEditors.XtraMessageBox.Show("Settings Saved!");
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            chkBranch.Checked = Properties.Settings.Default.BetaOptIn;

            LoadSettingsFromJson();
            txtHaloOnlineDir.Text = Properties.Settings.Default.HaloOnlineFolder;
            ProcessLaunchArguments(sender, e);
        }

        private void SettingsWindowClosing(object sender, FormClosingEventArgs e)
        {
            ProgramGlobals.SettingsWindowShowing = false;
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtWidth.Text, "[^0-9]"))
            {
                ConsoleLog.WriteLine("Width in settings can only be a number!");
                DevExpress.XtraEditors.XtraMessageBox.Show("Width can only be a number");
                txtWidth.Text = "";
            }
            ProcessLaunchArguments(sender, e);
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtHeight.Text, "[^0-9]"))
            {
                ConsoleLog.WriteLine("Height in settings can only be a number!");
                DevExpress.XtraEditors.XtraMessageBox.Show("Height can only be a number");
                txtHeight.Text = "";
            }
            ProcessLaunchArguments(sender, e);
        }


        string launchString = "";
        private void ProcessLaunchArguments(object sender, EventArgs e)
        {
            launchString = "";
            if (txtAccount.Text != "")
            {
                launchString = launchString + "--account " + txtAccount.Text;
            }
            if (txtSignInCode.Text != "")
            {
                launchString = launchString + " --sign-in-code " + txtSignInCode.Text;
            }
            if (chkFullscreen.Checked)
            {
                launchString = launchString + " -fullscreen";
            }
            if (chkNoLauncher.Checked)
            {
                launchString = launchString + " -launcher";
            }
            if (chkWindowed.Checked)
            {
                launchString = launchString + " -window";
            }
            if (chkVsync.Checked)
            {
                launchString = launchString + " -no_vsync";
            }
            if (chkShowFps.Checked)
            {
                launchString = launchString + " -show_fps";
            }
            if (chkD3d9.Checked)
            {
                launchString = launchString + " -d3d9ex";
            }
            if (chkNod3d9.Checked)
            {
                launchString = launchString + " -nod3d9ex";
            }
            if (txtWidth.Text != "")
            {
                launchString = launchString + " -width " + txtWidth.Text;
            }
            if (txtHeight.Text != "")
            {
                launchString = launchString + " -height " + txtHeight.Text;
            }
            if (spinAdapter.Value > 0)
            {
                launchString = launchString + " -adapter " + spinAdapter.Value.ToString();
            }
            if (cbEnvironment.Text != "")
            {
                launchString = launchString + " --environment " + cbEnvironment.Text;
            }
            txtLaunchArguments.Text = launchString;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSettingsFromJson();
        }
        public void LoadSettingsFromJson()
        {
            if (Properties.Settings.Default.SettingsJSON != "")
            {
                SettingsObject settingsLoaded = JsonConvert.DeserializeObject<SettingsObject>(Properties.Settings.Default.SettingsJSON);

                txtAccount.Text = settingsLoaded.Account;
                txtSignInCode.Text = settingsLoaded.SignInCode;
                chkFullscreen.Checked = settingsLoaded.FullScreen;
                chkWindowed.Checked = settingsLoaded.Windowed;
                chkVsync.Checked = settingsLoaded.vSync;
                chkNoLauncher.Checked = settingsLoaded.NoLauncher;
                chkShowFps.Checked = settingsLoaded.ShowFps;
                chkD3d9.Checked = settingsLoaded.D3d9;
                chkNod3d9.Checked = settingsLoaded.NoD3d9;
                if (settingsLoaded.Width != 0)
                {
                    txtWidth.Text = settingsLoaded.Width.ToString();
                }
                if (settingsLoaded.Height != 0)
                {
                    txtHeight.Text = settingsLoaded.Height.ToString();
                }
                spinAdapter.Value = settingsLoaded.Adapter;
                cbEnvironment.SelectedIndex = settingsLoaded.Environment;
            }
        }

        private void btnLaunchHalo_Click(object sender, EventArgs e)
        {
            MainWindow._mainWindow.StartHaloOnline();
        }

        private void chkBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBranch.Checked)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Beta updates can be VERY unstable and may update often!\nThanks for testing DarkToolKit!");
            }
        }

        private void spinAdapter_ValueChanged(object sender, EventArgs e)
        {
            ProcessLaunchArguments(sender, e);
        }
    }
}
