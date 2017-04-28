﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveEditor
{
    public partial class FormStatus : Form
    {
        BackgroundWorker worker;
        public FormStatus(BackgroundWorker wkr)
        {
            InitializeComponent();
            worker = wkr;
        }

        public void background_process_change(object sender,ProgressChangedEventArgs e)
        {
            procTask.Invoke( (MethodInvoker)delegate(){ procTask.Value = e.ProgressPercentage; });
            lbTaskName.Invoke((MethodInvoker)delegate () { lbTaskName.Text = e.UserState.ToString(); });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (worker != null)
                worker.CancelAsync();
        }

        private void FormStatus_Load(object sender, EventArgs e)
        {
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += background_process_change;
            worker.WorkerSupportsCancellation = true;
        }
    }
}
