using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace WaveEditor
{
    internal static class PluginsConfig
    {
        public static Dictionary<string, string[]> ioPlug;
        public static Dictionary<string, string[]> interpolatePlug;
        static string cfgPath;
        static PluginsConfig()
        {
            cfgPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Wave Editor","ioconfig.bcfg");
            
            if (File.Exists(cfgPath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream fs = new FileStream(cfgPath,FileMode.Open,FileAccess.Read,FileShare.Read);
                ioPlug = (Dictionary<string, string[]>)formatter.Deserialize(fs);
                fs.Close();
            }
            else
            {
                ioPlug = new Dictionary<string, string[]>();
            }
            cfgPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Wave Editor", "intconfig.bcfg");
            if (File.Exists(cfgPath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream fs = new FileStream(cfgPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                interpolatePlug = (Dictionary<string, string[]>)formatter.Deserialize(fs);
                fs.Close();
            }
            else
            {
                interpolatePlug = new Dictionary<string, string[]>();
            }
        }

        public static void Save()
        {
            cfgPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Wave Editor", "ioconfig.bcfg");
            BinaryFormatter formatter = new BinaryFormatter();
            Stream fs = new FileStream(cfgPath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(fs, ioPlug);
            fs.Close();
            cfgPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Wave Editor", "intconfig.bcfg");
            fs = new FileStream(cfgPath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(fs, interpolatePlug);
            fs.Close();
        }
    }
    
}
