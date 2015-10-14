using DarkPluginLib;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace PluginExample
{
        public class HelloToolkit : DarkPlugin
        {
            #region DarkPlugin Members

            public string Title
            {
                get
                {
                    return "Hello Plugins";
                }
            }
            public string Description
            {
                get
                {
                    return "This is an example plugin for DarkToolKit";
                }
            }
            public string Author
            {
                get
                {
                    return "darkc0de";
                }
            }
            public string Url
            {
                get
                {
                    return "https://halowiki.llf.to/index.php?title=DarkToolkit#Plugins";
                }
            }
            public string Version
            {
                get
                {
                    //DO NOT TOUCH CHANGE THIS IN YOUR PLUGIN PROPERTIES!!
                    return Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    //DO NOT TOUCH CHANGE THIS IN YOUR PLUGIN PROPERTIES!!
                }
            }
            public string Built
            {
                get
                {
                    //DO NOT TOUCH
                    System.IO.FileInfo fi = new System.IO.FileInfo("Plugins/"+Assembly.GetExecutingAssembly().GetName().Name + ".dll");
                    return fi.LastWriteTime.ToString();
                    //DO NOT TOUCH
                }
            }
            public Form MainForm
            {
                get
                {
                    return helloForm;
                }
            }
       
            //This defaults to false and will print exceptions to the DarkLog.
            //If you want Visual Studio to handle exceptions for debugging,
            //set this to true. SET THIS TO FALSE BEFORE PUBLISHING!
            public static bool IsDebugMode = false;
            public bool DebugMode
            {
                get
                {
                    return IsDebugMode;
                }
            }


            //Change `HelloForm` this to your main form.
            public HelloForm helloForm;

            //Please make sure that you change runningForm to true and false
            //Add HelloToolkit.runningForm = false; to you main form_closing events.
            //Add HelloToolkit.runningForm = true; when your first form loads.
            public static bool runningForm = false;

            //This is the main function that gets called to load your plugin
            public void DarkPluginMain()
            {
                DarkLog.WriteLine("DarkPluginMain() has been hit in HelloToolkit Plugin Example.");
                DarkLog.WriteLine("Halo Online Folder: " + DarkSettings.HaloOnlineFolder);
                DarkLog.WriteLine("DebugMode: " + DebugMode.ToString());
                if (!runningForm)
                {
                    //Change `HelloForm` to the name of your main form
                    //Please check the comment for `runningForm` above.
                    helloForm = new HelloForm();
                    helloForm.Show();
                }
                else
                {
                    //If you checked the comment for `runningForm` then this should
                    //be smart enough to just show and hide your plugin instead of killing
                    //it completely, or realoading it and breaking everything...
                    DarkLog.WriteLine("Plugin already running!");
                    helloForm.Show();
                }
            }

            #endregion
        }

}