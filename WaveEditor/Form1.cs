using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSeriesShared;
using System.Windows.Forms.DataVisualization.Charting;

namespace WaveEditor
{
    public partial class FrmEditor : Form
    {
        dynamic _sample_series_object = null;
        
        public FrmEditor()
        {
            InitializeComponent();
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {

        }

        private void txtDoubleVal_TextChanged(object sender, EventArgs e)
        {
            TextBox txtDbVal = sender as TextBox;
            if (txtDbVal == null)
                throw new ArgumentException("Error Text Changed Event Sender");
            if (txtDbVal.Text == "")
                txtDbVal.Text = "0";
        }

        private void txtDoubleVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != '.')
                e.Handled = true;
        }

        private void numSampleR_ValueChanged(object sender, EventArgs e)
        {
            lbSampleTimeVal.Text = String.Format("{0:0.#####E-00000}", (1 / (double)numSampleR.Value));
        }

        private void btnSigInit_Click(object sender, EventArgs e)
        {
            if(!Double.TryParse(txtSMaxVal.Text, out double maxval))
            {
                MessageBox.Show("Cannot Prase Maxinum Value!");
                return;
            }
            if(!Double.TryParse(txtSMinVal.Text, out double minval))
            {
                MessageBox.Show("Cannot Prase Mininum Value!");
                return;
            }
            if(_sample_series_object!=null)
            {
                if(MessageBox.Show("Sure to reinitialize the time series? This will delete all data","Initialization Comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            //Init the sample series
            switch(cmbDataType.SelectedIndex)
            {
                case 0:
                    _sample_series_object = new SampleSeries<byte>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    break;
                case 1:
                    _sample_series_object = new SampleSeries<ushort>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    break;
                case 2:
                    _sample_series_object = new SampleSeries<uint>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    break;
                case 3:
                    _sample_series_object = new SampleSeries<ulong>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    break;
                default:
                    _sample_series_object = new SampleSeries<double>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    break;
            }
            _sample_series_object.AddCtrlPoint(0, 0, false);
            btnAddPoint.Enabled = true;
            btnClrPoint.Enabled = true;
            btnDelPoint.Enabled = true;
            btnEditPoint.Enabled = true;
            btnGenSeries.Enabled = true;
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {

        }

        private void chartSignal_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if(e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint dp = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                if (chkSigRealT.Checked)
                {
                    e.Text = String.Format("Time:{0}\nValue:{1}", dp.XValue, dp.YValues[0]);
                }else
                {
                    e.Text = String.Format("Time:{0}\nValue:{1}", _sample_series_object.RealTime(dp.XValue), dp.YValues[0]);
                }
            }
        }
    }
}
