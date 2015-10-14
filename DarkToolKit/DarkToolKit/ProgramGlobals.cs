using DarkPluginLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkToolKit
{
    public class ProgramGlobals
    {
        public static bool ConsoleWindowShowing = false;
        public static bool ToolWindowShowing = false;
        public static bool AboutWindowShowing = false;
        public static bool SettingsWindowShowing = false;
        public static bool UpdateWindowShowing = false;
        public static bool Closing = false;
        public static Form ToolWindow;
        public static Form ConsoleWindow;
        public static Form AboutWindow;
        public static Form SettingsWindow;
        public static Form UpdateWindow;
        public static string update_url;
        public static string Build;
        public static string BuildDate;
        public static Dictionary<string, DarkPlugin> _Plugins;

        public class WindowLocations
        {
            public Rectangle Location { get; set; }
            public FormWindowState State { get; set;}
            public bool Maximised { get; set; }
            public bool Minimised { get; set; }
        }
    }
}
