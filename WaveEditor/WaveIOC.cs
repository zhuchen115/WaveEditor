using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using TimeSeriesShared;
using NXWaveIO;

namespace WaveEditor
{
    /// <summary>
    /// The Class to load and manage the IO interface
    /// </summary>
    public static class WaveIOC
    {
        static List<IWaveIO> dwWaveIO = new List<IWaveIO>();

        static WaveIOC()
        {
            //dwWaveIO.Add(new SPIDriver());
            /*if (Properties.Settings.Default.InterpolateDll != null)
            {
                string[] clsname = new string[Properties.Settings.Default.IOClass.Count];
                Properties.Settings.Default.IOClass.CopyTo(clsname, 0);
                foreach (string dllname in Properties.Settings.Default.IODll)
                {
                    List<string> ns = clsname.ToList().FindAll((x) => { return x.StartsWith(dllname); });
                    List<string> clstoload = new List<string>();
                    foreach (string cls in ns)
                    {
                        string[] d = cls.Split(',');
                        clstoload.Add(d[1]);
                    }
                    LoadFromDll(dllname, clstoload.ToArray());
                }
            }*/
            if(PluginsConfig.IoPlug.Count>0)
            {
                Dictionary<string, string[]>.KeyCollection dllnames = PluginsConfig.IoPlug.Keys;
                foreach (string dllname in dllnames)
                {
                    LoadFromDll(dllname, PluginsConfig.IoPlug[dllname]);
                }
            }

        }

        /// <summary>
        /// Get All the names of WaveIO Components
        /// </summary>
        /// <returns>the name array</returns>
        public static string[] GetNames()
        {
            List<string> names = new List<string>();
            foreach (IWaveIO jw in dwWaveIO)
            {
                names.Add(jw.Name);
            }
            return names.ToArray();
        }

        /// <summary>
        /// Get the instance of WaveIO components
        /// </summary>
        /// <param name="id">the index</param>
        /// <returns>Instance of components</returns>
        public static IWaveIO GetInstanceById(int id)
        {
            if(id>dwWaveIO.Count()||id<0)
            {
                throw new ArgumentOutOfRangeException("id out of range");
            }
            return dwWaveIO[id];
        }

        /// <summary>
        /// Find the instance in the storage
        /// </summary>
        /// <param name="inst">instance</param>
        /// <returns>the id</returns>
        public static int GetIdByInstance(IWaveIO inst)
        {
            int i = 0;
            foreach (IWaveIO jw in dwWaveIO)
            {
                if (jw.GetType() == inst.GetType())
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        /// <summary>
        /// Load WaveIO Components from a dll
        /// </summary>
        /// <remarks>The dll must be managed</remarks>
        /// <param name="dllName">dll file name</param>
        /// <param name="classname">the class name</param>
        public static void LoadFromDll(string dllName,string[] classname)
        {
            Assembly ass = Assembly.LoadFrom(dllName);
            foreach (string name in classname)
            {
                Type tp = ass.GetType(name);
                if (!typeof(IWaveIO).IsAssignableFrom(tp))
                {
                    throw new InvalidProgramException("The class is not implement IWaveIO");
                }
                IWaveIO ioobj = (IWaveIO)Activator.CreateInstance(tp);
                dwWaveIO.Add(ioobj);
            } 
        }

        /// <summary>
        /// Save the dll configuration
        /// </summary>
        /// <param name="dllName"></param>
        /// <param name="classname"></param>
        public static void SaveLoadDll(string dllName, string[] classname)
        {
            Assembly ass = Assembly.LoadFile(dllName);

            List<string> clsname = new List<string>();
            foreach (string name in classname)
            {
                Type tp = ass.GetType(name);

                if (!tp.IsAssignableFrom(typeof(IWaveIO)))
                {
                    throw new InvalidProgramException("The class is not implement IWaveIO");
                }
                clsname.Add(name);
            }

            if(PluginsConfig.IoPlug.ContainsKey(dllName))
            {
                string[] orig = PluginsConfig.IoPlug[dllName];
                PluginsConfig.IoPlug[dllName]=orig.Union(clsname).ToArray();
            }else
            {
                PluginsConfig.IoPlug.Add(dllName, clsname.ToArray());
            }

            PluginsConfig.Save();

            /*List<string> clsname = new List<string>();
            foreach (string name in classname)
            {
                Type tp = ass.GetType(name);
                
                if (!tp.IsAssignableFrom(typeof(IWaveIO)))
                {
                    throw new InvalidProgramException("The class is not implement IWaveIO");
                }
                clsname.Add(dllName + "," + name);
            }
            if (Properties.Settings.Default.IODll == null)
                Properties.Settings.Default.IODll = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.IODll.Add(dllName);
            if (Properties.Settings.Default.IOClass == null)
                Properties.Settings.Default.IOClass = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.IOClass.AddRange(clsname.ToArray());
            Properties.Settings.Default.Save();*/

        }

    }
}
