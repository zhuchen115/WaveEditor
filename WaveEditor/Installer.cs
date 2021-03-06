﻿using System;
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
        /// <param name="stateSaver">An IDictionary used to save information needed to perform a commit, rollback, or uninstall operation.</param>
        /// <see cref="Installer.Install(IDictionary)"/>
        public override void Install(IDictionary stateSaver)
        {
            //System.Diagnostics.Debugger.Launch();
            string fname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WaveEditor", "ioconfig.bcfg");
            FileInfo fi = new FileInfo(fname);
            DirectoryInfo appdirinfo = fi.Directory;
            if (!appdirinfo.Exists)
                appdirinfo.Create();
            PluginsConfig.Save();
            base.Install(stateSaver);
        }

        /// <summary>
        /// Execute when completes the install transaction.
        /// </summary>
        /// <param name="savedState">An IDictionary that contains the state of the computer after all the installers in the collection have run.</param>
        /// <see cref="Installer.Commit(IDictionary)"/>
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }

        /// <summary>
        /// Executed when removes an installation.
        /// </summary>
        /// <param name="savedState">An IDictionary that contains the state of the computer after the installation was complete.</param>
        /// <see cref="Installer.Uninstall(IDictionary)"/>
        public override void Uninstall(IDictionary savedState)
        {
            string fname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WaveEditor", "ioconfig.bcfg");
            FileInfo fi = new FileInfo(fname);
            DirectoryInfo appdirinfo = fi.Directory;
            appdirinfo.Delete(true);
        }
    }
}
