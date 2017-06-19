using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Threading.Tasks;

namespace WaveEditor
{
    /// <summary>
    /// This Class is used during install
    /// </summary>
    /// <remarks>The class is called by msiexec not in the program!</remarks>
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        /// <summary>
        /// Create the install
        /// </summary>
        public Installer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This will enable the SPI Driver
        /// </summary>
        /// <param name="stateSaver"></param>
        public override void Install(IDictionary stateSaver)
        {
            //System.Diagnostics.Debugger.Launch();
            string fname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WaveEditor", "ioconfig.bcfg");
            FileInfo fi = new FileInfo(fname);
            DirectoryInfo appdirinfo = fi.Directory;
            if (!appdirinfo.Exists)
                appdirinfo.Create();
            string[] cls = new string[1];
            cls[0] = "NXWaveIO.SPIDriver";
            
            PluginsConfig.IoPlug.Add("NXWaveIO.dll", cls);
            PluginsConfig.Save();
            base.Install(stateSaver);
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }

        public override void Uninstall(IDictionary savedState)
        {
            string fname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WaveEditor", "ioconfig.bcfg");
            FileInfo fi = new FileInfo(fname);
            DirectoryInfo appdirinfo = fi.Directory;
            appdirinfo.Delete(true);
        }
    }
}
