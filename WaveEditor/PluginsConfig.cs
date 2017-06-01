using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace WaveEditor
{
    internal static class PluginsConfig
    {
        public static Dictionary<string, string[]> ioPlug;
        public static Dictionary<string, string[]> interpolatePlug;
        static string cfgPath;
        static PluginsConfig()
        {
            cfgPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "config.bin");
        }
    }
}
