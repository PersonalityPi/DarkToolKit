using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DarkToolKit
{
    public class ConsoleLog
    {
        public static void Write(string Message)
        {
            MainWindow.ConsoleLogit(Message);
        }
        public static void WriteLine(string Message)
        {
            MainWindow.ConsoleLogNL(Message);
        }
        public static void WriteError(string Message)
        {
            MainWindow.ConsoleLogError(Message);
        }
        static long length = 0;
        public static void PluginLogReader()
        {
            while (!File.Exists("PluginOutput.log") && !ProgramGlobals.Closing)
            {
                Thread.Sleep(100);

            }
            while (File.Exists("PluginOutput.log") && !ProgramGlobals.Closing)
            {
                ReadTail("PluginOutput.log");
                Thread.Sleep(100);
            }
        }
        static void ReadTail(string filename)
        {
            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                if (length == 0)
                {
                    length = fs.Length;
                }
                if (length != fs.Length)
                {

                    // Seek 1024 bytes from the end of the file
                    fs.Seek(length, SeekOrigin.Current);

                    // read 1024 bytes
                    byte[] bytes = new byte[1024];
                    fs.Read(bytes, 0, 1024);
                    // Convert bytes to string
                    string s = Encoding.Default.GetString(bytes);
                    // and output
                    ConsoleLog.Write(s);
                    length = fs.Length;
                }
            }
        }
    }
}
