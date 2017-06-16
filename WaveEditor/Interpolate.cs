using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using InterpolationBasic;
using TimeSeriesShared;

namespace WaveEditor
{
    static class InterpolateC
    {
        static List<IInterpolate<uint>> dwInterpolate = new List<IInterpolate<uint>>();

        static InterpolateC()
        {
            //Add internal interpolate
            dwInterpolate.Add(new LinearInterpolate<uint>());
            dwInterpolate.Add(new SplineInterpolate<uint>());
            dwInterpolate.Add(new SinInterpolate<uint>());
            /*if(Properties.Settings.Default.InterpolateDll!=null)
            {
                string[] clsname = new string[Properties.Settings.Default.InterpolateClass.Count];
                Properties.Settings.Default.InterpolateClass.CopyTo(clsname, 0);
                foreach (string dllname in Properties.Settings.Default.InterpolateDll)
                {
                    List<string> ns =clsname.ToList().FindAll((x) => { return x.StartsWith(dllname); });
                    List<string> clstoload = new List<string>();
                    foreach (string cls in ns)
                    {
                        string[] d = cls.Split(',');
                        clstoload.Add(d[1]);
                    }
                    LoadFromDll(dllname, clstoload.ToArray());

                }
            }*/
            if(PluginsConfig.InterpolatePlug.Count>0)
            {
                Dictionary<string, string[]>.KeyCollection dllnames = PluginsConfig.InterpolatePlug.Keys;
                foreach (string dllname in dllnames)
                {
                    LoadFromDll(dllname, PluginsConfig.IoPlug[dllname]);
                }
            }
        }

        /// <summary>
        /// Get the names of Interpolation Method
        /// </summary>
        /// <returns></returns>
        public static string[] GetNames()
        {
            List<string> names = new List<string>();
            foreach (IInterpolate<uint> jw in dwInterpolate)
            {
                names.Add(jw.Name);
            }
            return names.ToArray();
        }

        /// <summary>
        /// Find the id of Interpolation by name
        /// </summary>
        /// <param name="name">The name of Interpolation</param>
        /// <returns>The registered ID</returns>
        public static int GetIdByName(string name)
        {
           return dwInterpolate.FindIndex((x)=>{ return x.Name == name; });
        }

        /// <summary>
        /// Get an instance of the Interpolator
        /// </summary>
        /// <typeparam name="T">The type of number</typeparam>
        /// <param name="id">The id of Interpolator</param>
        /// <returns>An instance of interpolator</returns>
        public static IInterpolate<T> GetInstanceById<T>(int id)
            where T : IComparable, IEquatable<T>, IConvertible
        {
            if (id > (dwInterpolate.Count() - 1))
                throw new ArgumentException("id out of range, type not found");
            Type tpBase = dwInterpolate[id].GetType().GetGenericTypeDefinition();
            Type[] tpArg = { typeof(T) };
            Type construct = tpBase.MakeGenericType(tpArg);
            return (IInterpolate<T>)Activator.CreateInstance(construct);
        }

        /// <summary>
        /// Create a instance by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IInterpolate<T> GetInstanceByName<T>(string name)
            where T : IComparable, IEquatable<T>, IConvertible
        {
            int id = GetIdByName(name);
            if (id < 0)
                throw new ArgumentException("name not found");
            Type tpBase = dwInterpolate[id].GetType().GetGenericTypeDefinition();
            Type[] tpArg = { typeof(T) };
            Type construct = tpBase.MakeGenericType(tpArg);
            return (IInterpolate<T>)Activator.CreateInstance(construct);
        }

        /// <summary>
        /// Find the id of Interpolator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inst"></param>
        /// <returns></returns>
        public static int GetIdByInstance<T>(IInterpolate<T> inst)
            where T : IComparable, IEquatable<T>, IConvertible
        {
            Type tpBase = inst.GetType().GetGenericTypeDefinition();
            int i = 0;
            foreach(IInterpolate<uint> jw in dwInterpolate)
            {
                if (jw.GetType().GetGenericTypeDefinition() == tpBase)
                    break;
                i++;
            }
            if (i == dwInterpolate.Count())
                return -1;
            else
                return i;
        }
        public static void LoadFromDll(string dllName,string[] classname)
        {
            Assembly ass = Assembly.LoadFrom(dllName);
            foreach (string name in classname)
            {
                Type tpbase = ass.GetType(name);
                Type[] gtype = { typeof(uint) };
                Type tp = tpbase.MakeGenericType(gtype);
                if (!typeof(IInterpolate<uint>).IsAssignableFrom(tp))
                {
                    throw new InvalidProgramException("The class is not implement IInterpolate");
                }
                IInterpolate<uint> iterobj = (IInterpolate<uint>)Activator.CreateInstance(tp);
                dwInterpolate.Add(iterobj);
            }
        }

        

        public static void SaveLoadDll(string dllName,string[] classname)
        {
            Assembly ass = Assembly.LoadFile(dllName);
            List<string> clsname = new List<string>();
            foreach (string name in classname)
            {
                Type tpbase = ass.GetType(name);
                Type[] gtype = { typeof(uint) };
                Type tp = tpbase.MakeGenericType(gtype);
                if (!tp.IsAssignableFrom(typeof(IInterpolate<uint>)))
                {
                    throw new InvalidProgramException("The class is not implement IInterpolate");
                }
                clsname.Add(dllName + "," + name);
            }
            if (Properties.Settings.Default.InterpolateDll == null)
                Properties.Settings.Default.InterpolateDll = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.InterpolateDll.Add(dllName);
            if (Properties.Settings.Default.InterpolateClass == null)
                Properties.Settings.Default.InterpolateClass = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.InterpolateClass.AddRange(clsname.ToArray());
            Properties.Settings.Default.Save();
        }
    }
}
