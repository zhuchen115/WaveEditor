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
    /// <summary>
    /// The form to edit a point
    /// </summary>
    public partial class FrmPoint : Form
    {
        /// <summary>
        /// Form Operation Mode
        /// </summary>
        public enum OpMode
        {
            /// <summary>
            /// Add Point
            /// </summary>
            Add,
            /// <summary>
            /// Change Point
            /// </summary>
            Change,
            /// <summary>
            /// Delete Point
            /// </summary>
            Delete
        }

        /// <summary>
        /// Create instance of form editing
        /// </summary>
        /// <param name="mode">Indicate the action</param>
        /// <param name="time">The time of a point, work on edit and delete</param>
        /// <param name="value">The original value</param>
        /// <param name="SampleRate">The sample rate of time series</param>
        public FrmPoint(OpMode mode= OpMode.Add,uint time=0,double value = 0,uint SampleRate = 1000000)
        {
            InitializeComponent();
            this.mode = mode;
            this.Time = time;
            this.Value = value;
            _SampleRate = SampleRate;
        }

        OpMode mode;

        /// <summary>
        /// The time of Sample point
        /// </summary>
        public uint Time { get; set; }
        /// <summary>
        /// The value of sample point
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Whether it should be grouped
        /// </summary>
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

        /// <summary>
        /// The interpolation index
        /// </summary>
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
            
            switch(Math.Log10(_SampleRate))
            {
                case 0:
                    lbTUnit.Text = "s";
                    break;
                case 1:
                    lbTUnit.Text = "x100ms";
                    break;
                case 2:
                    lbTUnit.Text = "x10ms";
                    break;
                case 3:
                    lbTUnit.Text = "ms";
                    break;
                case 4:
                    lbTUnit.Text = "x100us";
                    break;
                case 5:
                    lbTUnit.Text = "x10us";
                    break;
                case 6:
                    lbTUnit.Text = "us";
                    break;
                case 7:
                    lbTUnit.Text = "x100ns";
                    break;
                case 8:
                    lbTUnit.Text = "x10ns";
                    break;
                case 9:
                    lbTUnit.Text = "ns";
                    break;
                case 10:
                    lbTUnit.Text = "x100ps";
                    break;
                case 11:
                    lbTUnit.Text = "x10ps";
                    break;
                case 12:
                    lbTUnit.Text = "ps";
                    break;
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
