using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace WaveEditor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Checking Configuration..");
            IntPtr handle = GetConsoleWindow();
            if(PluginsConfig.IoPlug.Count>0)
                foreach (string dll in PluginsConfig.IoPlug.Keys)
                {
                    string dllname;
                    if (!Path.IsPathRooted(dll))
                        dllname = Path.Combine(Application.StartupPath, dll);
                    else
                        dllname = dll;
                    Console.Write("Searching for IO Library: {0}\t",dllname);
                    if (!File.Exists(dllname))
                    {
                        Console.WriteLine("Not Found");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cannot Found IO Module {0}", dll);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Do you want to remove this module and continue? [y/n]");
                        if(Console.ReadLine().Trim().ToLower()=="y")
                        {
                            PluginsConfig.IoPlug.Remove(dll);
                            PluginsConfig.Save();
                        }
                        else
                        {
                            Console.WriteLine("Load Failure, Exiting...");
                            System.Threading.Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("OK");
                    }
                }
            try
            {
                Console.WriteLine("Checking Image..");
                string [] names =WaveIOC.GetNames();
                Console.WriteLine("{0}", String.Join("\n", names));
                Console.WriteLine("Done");
            }catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in instance WaveIO Class");
                Console.WriteLine(ex.StackTrace);
                System.Threading.Thread.Sleep(2000);
                return;
            }

            if(PluginsConfig.InterpolatePlug.Count>0)
            {
                foreach (string dll in PluginsConfig.InterpolatePlug.Keys)
                {
                    string dllname;
                    if (!Path.IsPathRooted(dll))
                        dllname = Path.Combine(Application.StartupPath, dll);
                    else
                        dllname = dll;
                    Console.Write("Searching for Interpolate Library: {0}\t", dllname);
                    if (!File.Exists(dllname))
                    {
                        Console.WriteLine("Not Found");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cannot Found Interpolate Module {0}", dll);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Do you want to remove this module and continue? [y/n]");
                        if (Console.ReadLine().Trim().ToLower() == "y")
                        {
                            PluginsConfig.InterpolatePlug.Remove(dll);
                            PluginsConfig.Save();
                        }
                        else
                        {
                            Console.WriteLine("Load Failure, Exiting...");
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("OK");
                    }
                }
            }
            try
            {
                Console.WriteLine("Checking Image..");
                string[] names = InterpolateC.GetNames();
                Console.WriteLine("{0}", String.Join("\n", names));
                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in instance Interpolate Class");
                Console.WriteLine(ex.StackTrace);
                System.Threading.Thread.Sleep(2000);
                return;
            }
            ShowWindow(handle, SW_HIDE);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmEditor(handle));
        }

        [DllImport("kernel32.dll",CallingConvention=CallingConvention.Winapi)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern bool ShowWindow(IntPtr hwnd, int cmdshow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
    }
}
