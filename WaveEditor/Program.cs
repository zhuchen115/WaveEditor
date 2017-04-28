using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WaveEditor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Checking Config..");
            if(Properties.Settings.Default.IODll!=null)
                foreach (string dll in Properties.Settings.Default.IODll)
                {
                    Console.Write("Searching for IO Library: {0}\t",dll);
                    if (!File.Exists(dll))
                    {
                        Console.WriteLine("Not Found");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cannot Found IO Module {0}", dll);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Do you want to remove this module and continue? [y/n]");
                        if(Console.ReadLine().Trim().ToLower()=="y")
                        {
                            Properties.Settings.Default.IODll.Remove(dll);
                            Properties.Settings.Default.Save();
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

            if(Properties.Settings.Default.InterpolateDll!=null)
            {
                foreach (string dll in Properties.Settings.Default.InterpolateDll)
                {
                    Console.Write("Searching for Interpolate Library: {0}\t", dll);
                    if (!File.Exists(dll))
                    {
                        Console.WriteLine("Not Found");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cannot Found Interpolate Module {0}", dll);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Do you want to remove this module and continue? [y/n]");
                        if (Console.ReadLine().Trim().ToLower() == "y")
                        {
                            Properties.Settings.Default.InterpolateDll.Remove(dll);
                            Properties.Settings.Default.Save();
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmEditor());
        }
    }
}
