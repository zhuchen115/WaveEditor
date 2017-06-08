using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TimeSeriesShared;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WaveEditor
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class FrmEditor : Form
    {
        dynamic _sample_series_object = null;
        int dataType = 4;
        
        /// <summary>
        /// Give instance of Main Form
        /// </summary>
        public FrmEditor()
        {
            InitializeComponent();
            
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            DispRange[0] = 0;
            DispRange[1] = 1000;
            DispRange[2] = 0;
            DispRange[3] = 65;
            cmbDataType.SelectedIndex = 1;
            cmbWaveIO.Items.AddRange(WaveIOC.GetNames());
            chartSignal.ChartAreas[0].AxisY.Title = Properties.Settings.Default.YAxisName;
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
                MessageBox.Show("Cannot Parse Maximum Value!");
                return;
            }
            if(!Double.TryParse(txtSMinVal.Text, out double minval))
            {
                MessageBox.Show("Cannot Parse Minimum Value!");
                return;
            }
            if(minval>maxval)
            {
                MessageBox.Show("Min Value is larger than Max Value", "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(_sample_series_object!=null)
            {
                if(MessageBox.Show("Sure to reinitialize the time series? This will delete all data","Initialization Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            uint szmem = 0;
            switch(cmbDataType.SelectedIndex)
            {
                case 0:
                    szmem = 1;
                    break;
                case 1:
                    szmem = 2;
                    break;
                case 2:
                    szmem = 4;
                    break;
                case 3:
                case 4:
                    szmem = 8;
                    break;
            }
            double memuse = (szmem * (uint)numSampleR.Value * Double.Parse(txtSampleT.Text));
            if(memuse > Properties.Settings.Default.CacheNum)
            {
                if (MessageBox.Show(String.Format("The size of data exceed memory caching size, Do you want to continue?\n memory required {0}MB",memuse/1048576),"Large Memory Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;
            }

            //Initialize the sample series
            switch(cmbDataType.SelectedIndex)
            {
                case 0:
                    _sample_series_object = new SampleSeries<byte>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    dataType = 0;
                    break;
                case 1:
                    _sample_series_object = new SampleSeries<ushort>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    dataType = 1;
                    break;
                case 2:
                    _sample_series_object = new SampleSeries<uint>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    dataType = 2;
                    break;
                case 3:
                    _sample_series_object = new SampleSeries<ulong>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    dataType = 3;
                    break;
                default:
                    _sample_series_object = new SampleSeries<double>((uint)numSampleR.Value, (ushort)numSampleB.Value, minval, maxval);
                    dataType = 4;
                    break;
            }
           
                _sample_series_object.MaxValue = maxval;
                _sample_series_object.MinValue = minval;
                _sample_series_object.SampleRate = (uint)numSampleR.Value;
                _sample_series_object.SampleBits = (ushort)numSampleB.Value;
           
            _sample_series_object.AddCtrlPoint(0, 0, false);
            btnAddPoint.Enabled = true;
            btnClrPoint.Enabled = true;
            //btnDelPoint.Enabled = true;
            //btnEditPoint.Enabled = true;
            btnGenSeries.Enabled = true;
            chkSigRealT.Enabled = true;
            txtXRange.Enabled = true;
            txtYRange.Enabled = true;
            btnSigInit.Enabled = false;
            numSampleB.Enabled = false;
            numSampleR.Enabled = false;
            txtSampleT.Enabled = false;
            txtSMaxVal.Enabled = false;
            txtSMinVal.Enabled = false;
            txtXRange.Enabled = true;
            txtYRange.Enabled = true;
            cmbDataType.Enabled = false;
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            FrmPoint fmp = new FrmPoint(FrmPoint.OpMode.Add, 0, 0, (uint)numSampleR.Value);
            
            if (fmp.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //First Add to the sample series
                    switch (dataType)
                    {
                        case 0:
                            _sample_series_object.AddCtrlPointD(fmp.Time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<byte>(fmp.Interpolate));
                            break;
                        case 1:
                            _sample_series_object.AddCtrlPointD(fmp.Time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<ushort>(fmp.Interpolate));
                            break;
                        case 2:
                            _sample_series_object.AddCtrlPointD(fmp.Time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<uint>(fmp.Interpolate));
                            break;
                        case 3:
                            _sample_series_object.AddCtrlPointD(fmp.Time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<ulong>(fmp.Interpolate));
                            break;
                        default:
                            _sample_series_object.AddCtrlPointD(fmp.Time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<double>(fmp.Interpolate));
                            break;
                    }
                }catch(ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //Then the display series
                DataPoint dp;
                if (chkSigRealT.Checked)
                {
                    dp = new DataPoint(fmp.Time / (double)numSampleR.Value, fmp.Value) { Tag = fmp.Interpolate };
                    chartSignal.Series[0].Points.Add(dp);
                }
                else
                {
                    dp = new DataPoint(fmp.Time, fmp.Value) { Tag = fmp.Interpolate };
                    chartSignal.Series[0].Points.Add(dp);
                }
                    
                if(DispRange[1]<fmp.Time)
                {
                    txtXRange.Text = String.Format("{0},{1}", DispRange[0], fmp.Time * 2);
                    DispRange[1] = fmp.Time * 2;
                }
                if(!fmp.Group)
                    RefreshDisp();
            }
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
                    e.Text = String.Format("Time:{0}\nValue:{1}", _sample_series_object.RealTime((uint)dp.XValue), dp.YValues[0]);
                }
            }
        }

        private void btnEditPoint_Click(object sender, EventArgs e)
        {
            uint time;double value;
            if (point_click == null)
                return;
            if (chkSigRealT.Checked)
            {
                time = (uint)(point_click.XValue * (double)numSampleR.Value);
            }
            else
            {
                time = (uint)point_click.XValue;
            }
            value = point_click.YValues[0];
            //Initialize a form to edit it.
            FrmPoint fmp = new FrmPoint(FrmPoint.OpMode.Change, time, value, (uint)numSampleR.Value)
            {
                Interpolate = (int)point_click.Tag
            };
            if (fmp.ShowDialog() == DialogResult.OK)
            {
                switch (dataType)
                {
                    case 0:
                        _sample_series_object.EditCtrlPointD(time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<byte>(fmp.Interpolate));
                        break;
                    case 1:
                        _sample_series_object.EditCtrlPointD(time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<ushort>(fmp.Interpolate));
                        break;
                    case 2:
                        _sample_series_object.EditCtrlPointD(time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<uint>(fmp.Interpolate));
                        break;
                    case 3:
                        _sample_series_object.EditCtrlPointD(time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<ulong>(fmp.Interpolate));
                        break;
                    default:
                        _sample_series_object.AddCtrlPointD(fmp.Time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<double>(fmp.Interpolate));
                        break;
                }
                
                point_click.YValues[0] = fmp.Value;
                RefreshDisp();
            }
        }

        DataPoint point_click = null;
        private void chartSignal_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult rslt = chartSignal.HitTest(e.X, e.Y);
            if(rslt!=null)
            {
                if (rslt.Series == null)
                    return;
                if (rslt.Series.Name == "TSCtrl")
                {
                    if(point_click!=null)
                        point_click.MarkerSize = 10;
                    point_click = rslt.Series.Points[rslt.PointIndex];
                    btnDelPoint.Enabled = true;
                    btnEditPoint.Enabled = true;
                    rslt.Series.Points[rslt.PointIndex].MarkerSize = 15;
                }
                else
                {
                    if (point_click != null)
                        point_click.MarkerSize = 10;
                    btnDelPoint.Enabled = false;
                    btnEditPoint.Enabled = false;
                }
                
            }
        }

        private void chartSignal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HitTestResult rslt = chartSignal.HitTest(e.X, e.Y);
            if (rslt != null)
            {
                //Check if it is a control point
                if (rslt.Series == null || rslt.Series.Name != "TSCtrl")
                    return;
                uint time; double value;
                //First Convert the time
                if (chkSigRealT.Checked)
                {
                    time = (uint)(rslt.Series.Points[rslt.PointIndex].XValue * (double)numSampleR.Value);
                }
                else
                {
                    time = (uint)rslt.Series.Points[rslt.PointIndex].XValue;
                }
                value = rslt.Series.Points[rslt.PointIndex].YValues[0];
                //Initialize a form to edit it.
                FrmPoint fmp = new FrmPoint(FrmPoint.OpMode.Change, time, value, (uint)numSampleR.Value)
                {
                    Interpolate = (int)rslt.Series.Points[rslt.PointIndex].Tag
                };
                if(fmp.ShowDialog()==DialogResult.OK)
                {
                    switch (dataType)
                    {
                        case 0:
                            _sample_series_object.EditCtrlPointD(time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<byte>(fmp.Interpolate));
                            break;
                        case 1:
                            _sample_series_object.EditCtrlPointD(time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<ushort>(fmp.Interpolate));
                            break;
                        case 2:
                            _sample_series_object.EditCtrlPointD(time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<uint>(fmp.Interpolate));
                            break;
                        case 3:
                            _sample_series_object.EditCtrlPointD(time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<ulong>(fmp.Interpolate));
                            break;
                        default:
                            _sample_series_object.EditCtrlPointD(fmp.Time, fmp.Value, fmp.Group, InterpolateC.GetInstanceById<double>(fmp.Interpolate));
                            break;
                    }
                    rslt.Series.Points[rslt.PointIndex].YValues[0] = fmp.Value;
                    RefreshDisp();
                }
            }
        }

        private void RefreshDisp()
        {
            //First Clean the display
            chartSignal.Series[1].Points.Clear();
            double[] value = null; uint start, stop;int i = 0;
            double step = (DispRange[1]-DispRange[0])/ Properties.Settings.Default.DispNum;
            //Now Define the time range in uint
            if (chkSigRealT.Checked)
            {
                 start = (uint )(DispRange[0] * (double)numSampleR.Value);
                 stop = (uint)(DispRange[1] * (double)numSampleR.Value);
            }else
            {
                start = (uint)DispRange[0];
                stop = (uint)DispRange[1];
            }
            //Generate Series
            try
            {
                value = _sample_series_object.GenerateDispSeries(start, stop, Properties.Settings.Default.DispNum);

            } catch(ArgumentException ex)
            {
                MessageBox.Show("An Error occurred when generating series!\n"+ex.Message+"\n Did you forget grouping the points?","Time Series Generation Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            //Display Value
            foreach (double v in value)
            {
                chartSignal.Series[1].Points.AddXY(DispRange[0]+(i*step),v);
                i++;
            }
            // Set Range
            chartSignal.ChartAreas[0].AxisX.Minimum = DispRange[0];
            chartSignal.ChartAreas[0].AxisX.Maximum = DispRange[1];
            chartSignal.ChartAreas[0].AxisY.Minimum = DispRange[2];
            chartSignal.ChartAreas[0].AxisY.Maximum = DispRange[3];
        }

        private double[] DispRange = new double[4];
        private void txtXRange_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] chm = txtXRange.Text.Split(',');
                if (chm.Count() != 2)
                    throw new FormatException("Expression Error, the number are not 2");
                double min = Double.Parse(chm[0]);
                double max = Double.Parse(chm[1]);
                if (min > max)
                    throw new FormatException("Min > Max");
                DispRange[0] = min;
                DispRange[1] = max;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error Format!");
                txtXRange.Focus();
                return;
            }
            RefreshDisp();
        }

        private void txtYRange_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] chm = txtYRange.Text.Split(',');
                if (chm.Count() != 2)
                    throw new FormatException("Expression Error, the number are not 2");
                double min = Double.Parse(chm[0]);
                double max = Double.Parse(chm[1]);
                if (min > max)
                    throw new FormatException("Min > Max");
                DispRange[2] = min;
                DispRange[3] = max;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error Format!");
                txtYRange.Focus();
                return;
            }
            RefreshDisp();
        }

        private void btnDelPoint_Click(object sender, EventArgs e)
        {
            uint time; double value;
            if (point_click == null)
                return;
            if (chkSigRealT.Checked)
            {
                time = (uint)(point_click.XValue * (double)numSampleR.Value);
            }
            else
            {
                time = (uint)point_click.XValue;
            }
            value = point_click.YValues[0];
            //Initialize a form to edit it.
            FrmPoint fmp = new FrmPoint(FrmPoint.OpMode.Delete, time, value, (uint)numSampleR.Value)
            {
                Interpolate = (int)point_click.Tag
            };
            if (fmp.ShowDialog() == DialogResult.OK)
            {
                _sample_series_object.DelCtrlPoint(time);
                try
                {
                    chartSignal.Series[0].Points.Remove(point_click);
                    point_click = null;
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                RefreshDisp();
            }
        }

        private void txtYRange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtYRange_TextChanged(null, null);
        }

        private void txtXRange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtXRange_TextChanged(null, null);
        }

        private void chkSigRealT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string[] chm = txtXRange.Text.Split(',');
                if (chm.Count() != 2)
                    throw new FormatException("Expression Error, the number are not 2");
                double min = Double.Parse(chm[0]);
                double max = Double.Parse(chm[1]);
                if (min > max)
                    throw new FormatException("Min > Max");
                if (chkSigRealT.Checked)
                {
                    txtXRange.Text = String.Format("{0},{1}", min / (double)numSampleR.Value, max / (double)numSampleR.Value);
                }
                else
                {
                    txtXRange.Text = String.Format("{0},{1}", min * (double)numSampleR.Value, max * (double)numSampleR.Value);
                    
                }
                
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error Format!");
                
                return;
            }
            foreach(DataPoint dp in chartSignal.Series[0].Points)
            {
                if(chkSigRealT.Checked)
                {
                    dp.XValue = dp.XValue / (double)numSampleR.Value;
                    chartSignal.ChartAreas[0].AxisX.Title = "Time (s)";
                }
                else
                {
                    dp.XValue = dp.XValue * (double)numSampleR.Value;
                    chartSignal.ChartAreas[0].AxisX.Title = "Sample (k)";
                }
            }
            foreach (DataPoint dp in chartSignal.Series[1].Points)
            {
                if (chkSigRealT.Checked)
                {
                    dp.XValue = dp.XValue / (double)numSampleR.Value;
                }
                else
                {
                    dp.XValue = dp.XValue * (double)numSampleR.Value;
                }
            }
            //Refresh Axis
            txtXRange_TextChanged(null, null);
            txtYRange_TextChanged(null, null);
            
        }

        private void btnGenSeries_Click(object sender, EventArgs e)
        {
            RefreshDisp();
        }

        private void btnClrPoint_Click(object sender, EventArgs e)
        {
            _sample_series_object = null;
            btnAddPoint.Enabled = false;
            btnClrPoint.Enabled = false;
            btnDelPoint.Enabled = false;
            btnEditPoint.Enabled = false;
            btnGenSeries.Enabled = false;
            btnSigInit.Enabled = true;
            numSampleB.Enabled = true;
            numSampleR.Enabled = true;
            txtSampleT.Enabled = true;
            txtSMaxVal.Enabled = true;
            txtSMinVal.Enabled = true;
            txtXRange.Enabled = false;
            txtYRange.Enabled = false;
            cmbDataType.Enabled = true;
            chartSignal.Series[0].Points.Clear();
            chartSignal.Series[1].Points.Clear();
        }
        IWaveIO iohandle = null;

        private void cmbWaveIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWaveIO.SelectedIndex < 0)
            {
                btnIOSend.Enabled = false;
                btnWaveIOCfg.Enabled = false;
                iohandle = null;
                return;
            }
            
            try
            {
                iohandle = WaveIOC.GetInstanceById(cmbWaveIO.SelectedIndex);
                Type tp = iohandle.GetConfigForm;
                if(typeof(Form).IsAssignableFrom(tp) && typeof(IWaveIOConfigForm).IsAssignableFrom(tp))
                {
                    btnWaveIOCfg.Enabled = true;
                }
                btnIOSend.Enabled = true;
                io_inited = false;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool io_inited = false;
        private void btnWaveIOCfg_Click(object sender, EventArgs e)
        {
            if (cmbWaveIO.SelectedIndex < 0)
                return;
            Type tp = iohandle.GetConfigForm;
            if (!(typeof(Form).IsAssignableFrom(tp) && typeof(IWaveIOConfigForm).IsAssignableFrom(tp)))
            {
                btnWaveIOCfg.Enabled = false;
                MessageBox.Show("Configuration instance not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            object iocfgform = Activator.CreateInstance(tp);
            if(((Form)iocfgform).ShowDialog() == DialogResult.OK)
            {
                try
                {
                    io_cfg = ((IWaveIOConfigForm)iocfgform).Config;
                    if (io_inited)
                        iohandle.Dispose();
                    iohandle.Init(io_cfg);
                    io_inited = true;
                    btnDisCon.Enabled = true;
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        WaveIOConfig io_cfg = null;
        private void btnIOSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!io_inited)
                {
                    io_cfg = iohandle.GetConfigs();
                    iohandle.Init(io_cfg);
                    io_inited = true;
                    btnDisCon.Enabled = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error during Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BackgroundWorker worker = new BackgroundWorker();
            FormStatus status = new FormStatus(worker);
            worker.RunWorkerCompleted += GenSeriesCompleted;
            status.Show();
            _sample_series_object.GenerateSeries(UInt32.Parse(txtSampleT.Text)*(uint)numSampleR.Value, worker);
        }

        private void GenSeriesCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message + "\n" + e.Error.StackTrace, "Interpolation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.Cancelled)
                return;
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += IOSeriesCompleted;
            byte[] data = _sample_series_object.ResultToByte((bool)io_cfg.Config["lendian"]);
            FormStatus status = new FormStatus(worker);
            status.Show();
            iohandle.WriteAsync(data, data.Length, ref worker);
            
        }

        private void IOSeriesCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message + "\n" + e.Error.StackTrace, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (e.Cancelled)
                return;
            MessageBox.Show("Data Sending Completed");
        }

        private void saveSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_sample_series_object==null)
            {
                MessageBox.Show("The Sample Series is not initialized!", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Stream stm;
            SaveFileDialog savediag = new SaveFileDialog()
            {
                Filter = "Binary Format (*.wb)|*.wb",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (savediag.ShowDialog() == DialogResult.OK)
            {
                if((stm = savediag.OpenFile())!=null)
                {
                    BinaryFormatter format = new BinaryFormatter();
                    format.Serialize(stm, _sample_series_object);
                    stm.Close();
                }
            }
        }

        private void openOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Stream stm;
                OpenFileDialog opendiag = new OpenFileDialog() {
                    Filter = "Binary Format (*.wb)|*.wb",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
                if(opendiag.ShowDialog()==DialogResult.OK)
                {
                    if((stm = opendiag.OpenFile())!=null)
                    {
                        BinaryFormatter format = new BinaryFormatter();
                        _sample_series_object =  format.Deserialize(stm);
                        if(_sample_series_object.GenType == typeof(byte))
                        {
                            SampleSeries<byte>.RestoreInterpolate < byte > inst = InterpolateC.GetInstanceByName<byte>;
                            _sample_series_object.InterpolationRebuilder = inst;
                        } else if(_sample_series_object.GenType == typeof(ushort))
                        {
                            SampleSeries<ushort>.RestoreInterpolate<ushort> inst = InterpolateC.GetInstanceByName<ushort>;
                            _sample_series_object.InterpolationRebuilder = inst;
                        }
                        else if (_sample_series_object.GenType == typeof(uint))
                        {
                            SampleSeries<uint>.RestoreInterpolate<uint> inst = InterpolateC.GetInstanceByName<uint>;
                            _sample_series_object.InterpolationRebuilder = inst;
                        }
                        else if (_sample_series_object.GenType == typeof(ulong))
                        {
                            SampleSeries<ulong>.RestoreInterpolate<ulong> inst = InterpolateC.GetInstanceByName<ulong>;
                            _sample_series_object.InterpolationRebuilder = inst;
                        }
                        else if (_sample_series_object.GenType == typeof(double))
                        {
                            SampleSeries<double>.RestoreInterpolate<double> inst = InterpolateC.GetInstanceByName<double>;
                            _sample_series_object.InterpolationRebuilder = inst;
                        }
                        else if (_sample_series_object.GenType == typeof(float))
                        {
                            SampleSeries<float>.RestoreInterpolate<float> inst = InterpolateC.GetInstanceByName<float>;
                            _sample_series_object.InterpolationRebuilder = inst;
                        }
                        else
                        {
                            throw new ArgumentException("Argument Type not supported");
                        }
                        _sample_series_object.RebuildInterpolation();
                        numSampleR.Value = _sample_series_object.SampleRate;
                        numSampleB.Value = _sample_series_object.SampleBits;
                        txtSMaxVal.Text = _sample_series_object.MaxValue.ToString();
                        txtSMinVal.Text = _sample_series_object.MinValue.ToString();
                        btnAddPoint.Enabled = true;
                        btnClrPoint.Enabled = true;
                        btnGenSeries.Enabled = true;
                        chkSigRealT.Enabled = true;
                        txtXRange.Enabled = true;
                        txtYRange.Enabled = true;
                        btnSigInit.Enabled = false;
                        numSampleB.Enabled = false;
                        numSampleR.Enabled = false;
                        txtSampleT.Enabled = false;
                        txtSMaxVal.Enabled = false;
                        txtSMinVal.Enabled = false;
                        txtXRange.Enabled = true;
                        txtYRange.Enabled = true;
                        cmbDataType.Enabled = false;
                        RefreshDisp();
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Load File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSettings setfrm = new FrmSettings();
            setfrm.Show();
        }

        private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox bfrm = new AboutBox();
            bfrm.ShowDialog();
        }

        private void btnDisCon_Click(object sender, EventArgs e)
        {
            if (io_inited)
            {
                iohandle.Dispose();
                MessageBox.Show("Closed");
                btnDisCon.Enabled = false;
            }
                
            io_inited = false;
        }
    }
}
