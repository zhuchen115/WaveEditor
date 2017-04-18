using System;
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
    public partial class FrmPoint : Form
    {
        public enum OpMode
        {
            Add,
            Change,
            Delete
        }
        public FrmPoint(OpMode mode= OpMode.Add,uint time=0,double value = 0,uint SampleRate = 1000000)
        {
            InitializeComponent();
            this.mode = mode;
            this.time = time;
            this.Value = value;
            _SampleRate = SampleRate;
        }

        OpMode mode;
        uint time;
        public double Value { get; set; }
        uint _SampleRate;

        private void FrmPoint_Load(object sender, EventArgs e)
        {
            if (mode == OpMode.Change)
            {
                txtTime.ReadOnly = true;
                txtTime.Text = time.ToString();
                txtValue.Text = Value.ToString();
                this.Text = "Change Point";
            }
            else if(mode == OpMode.Add)
            {
                txtTime.ReadOnly = false;
                this.Text = "Add Point";
            }
            else
            {
                txtTime.ReadOnly = false;
                txtValue.Enabled = false;
                txtTime.Text = time.ToString();
                txtValue.Text = Value.ToString();
                this.Text = "Delete Point";
                btnSave.Text = "Delete";
            }

        }
        private void chkRealTime_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRealTime.Checked)
            {
                txtTime.Text = String.Format("{0}",((double)UInt32.Parse(txtTime.Text) / _SampleRate));
            }
            else
            {
                txtTime.Text = String.Format("{0}",((UInt32)Double.Parse(txtTime.Text)*_SampleRate));
            }
        }
    }
}
