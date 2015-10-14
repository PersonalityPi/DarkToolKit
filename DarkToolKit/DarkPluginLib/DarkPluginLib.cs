using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DarkPluginLib
{

    public interface DarkPlugin
    {
        string Title { get; }
        string Description { get; }
        string Author { get; }
        string Url { get; }
        string Version { get; }
        string Built { get; }
        Form MainForm { get; }
        void DarkPluginMain();
        bool DebugMode { get; }
    }
    public class DarkSettings
    {
        /*
        HaloOnlineFolder
        This folder is set by the user and should always be correct.
        We don't allow plugins to start without a folder being valid!
        */
        public static string HaloOnlineFolder;

        /*
        DarkIsRunning
        This will be false if DarkToolKit closes.
        Use this inside your While loops to make sure you don't get
        a weird disposed exception + you dont want your plugin to go on
        forever in the background while DarkToolKit is closed!
        */
        public static bool DarkIsRunning;

        /*
        HaloIsRunning
        You can use this in your app to detect if halo is running
        DarkToolKit checks every 100ms if Eldorado is running and changes
        this bool. 
         
        You can simply check if(DarkSettings.HaloIsRunning)
        */
        public static bool HaloIsRunning;
    }
    public class DarkLog
    {
        public static void WriteLine(String Message)
        {
            using (StreamWriter sw = File.AppendText("PluginOutput.log"))
            {
                sw.WriteLine(Message);
            }
        }
        public static void Write(String Message)
        {
            using (StreamWriter sw = File.AppendText("PluginOutput.log"))
            {
                sw.Write(Message);
            }
        }
    }
}