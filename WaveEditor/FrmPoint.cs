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
            this.Time = time;
            this.Value = value;
            _SampleRate = SampleRate;
        }

        OpMode mode;
        public uint Time { get; set; }
        public double Value { get; set; }
        public bool Group {
            get
            {
                return chkGroup.Checked;
            }
            set
            {
                chkGroup.Checked = value;
            }
        }
        private int interpolate_init = -1;
        public int Interpolate
        {
            get
            {
                return cmbInterpo.SelectedIndex;
            }
            set
            {
                interpolate_init = value;
            }
        }
        uint _SampleRate;

        private void FrmPoint_Load(object sender, EventArgs e)
        {
            cmbInterpo.Items.AddRange(InterpolateC.GetNames());
            if (mode == OpMode.Change)
            {
                txtTime.ReadOnly = true;
                txtTime.Text = Time.ToString();
                txtValue.Text = Value.ToString();
                this.Text = "Change Point";
                cmbInterpo.SelectedIndex = interpolate_init;
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
                txtTime.Text = Time.ToString();
                txtValue.Text = Value.ToString();
                this.Text = "Delete Point";
                btnSave.Text = "Delete";
            }
            
        }
        private void chkRealTime_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkRealTime.Checked)
                {
                    txtTime.Text = String.Format("{0}", ((double)UInt32.Parse(txtTime.Text) / _SampleRate));
                }
                else
                {
                    txtTime.Text = String.Format("{0}", ((UInt32)Double.Parse(txtTime.Text) * _SampleRate));
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error in formatting Value! {ex.Message}", "Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkRealTime.Checked)
                    Time = ((UInt32)Double.Parse(txtTime.Text) * _SampleRate);
                else
                    Time = UInt32.Parse(txtTime.Text);
                this.Value = Double.Parse(txtValue.Text);
            }catch(FormatException ex)
            {
                MessageBox.Show($"Error in formatting Value! {ex.Message}", "Value Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtDoubleVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != '.')
                e.Handled = true;
        }
    }
}
