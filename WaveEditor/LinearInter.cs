using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace WaveEditor
{
    class LinearInter : IInterpolation
    {
        List<SamplePoint> ctrl_point;
        
        public uint[] GenerateSeriesFull(List<SamplePoint> control, uint endtime)
        {
            throw new NotImplementedException();
        }

        public void GenerateSeriesBackground(List<SamplePoint> control, uint endtime, object sender)
        {
            if (!(sender is BackgroundWorker))
                throw new ArgumentException("The type is not correct", "sender");
            ctrl_point = control;
            
            BackgroundWorker worker = sender as BackgroundWorker;
            
            worker.DoWork += this._gen_linear_background;
            worker.RunWorkerAsync(endtime);
        }

        public void GenerateDisp(List<SamplePoint> ctrl_point, ref uint[] target, uint start, uint stop)
        {
            int len = target.Length;
            int pos = 0; // The position of control point;
            double coef;
            double ts = ((double)(stop - start) / len);
            if (ts < 0)
                throw new ArgumentException("Invalid Interpolation Argument");
            if (ts < 1) // The sample rate is over system sample rate
            {
                Array.Resize(ref target, (int)(stop - start + 1));
                len = target.Length;
            }
            int i = 0;
            while (i < len)
            {
                coef = (ctrl_point[pos + 1].data - ctrl_point[pos].data) / (double)(ctrl_point[pos + 1].time - ctrl_point[pos].time);
                while (((i * ts + start) <= ctrl_point[pos + 1].time) && i < len)
                {
                    target[i] = ctrl_point[pos].data + (uint)(coef * ((i * ts + start - i)));
                    i++;
                }
                pos++;
            }
        }

        private void _gen_linear_background(object sender,DoWorkEventArgs e)
        {
            List<uint> data = new List<uint>();
            BackgroundWorker worker = sender as BackgroundWorker;
            int k = 0, ctlen = ctrl_point.Count - 1;
            uint nextvalue = ctrl_point[0].data, nexttime = ctrl_point[0].time, prevval = 0, prevtime = 0;
            double coef = 0;
            for (uint i = 0; i < (uint)e.Argument; i++)
            {
                // Check the worker state   
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                // Goto new control point
                if (i == nexttime)
                {
                    data.Add(ctrl_point[k].data);
                    if (k <= ctlen)
                    {
                        k++;
                        prevtime = nexttime;
                        prevval = nextvalue;
                        nextvalue = ctrl_point[k].data;
                        nexttime = ctrl_point[k].time;
                        //Calculate the coefficient dy/dt
                        coef = (nextvalue - prevval) / ((double)(nexttime - prevtime));

                    }
                    else //The final point
                    {
                        // Make the time to infinity
                        nexttime = UInt32.MaxValue;
                    }
                }
                else
                {
                    //k must >0 when entering here
                    data.Add((uint)Math.Round(prevval + (i - prevtime) * coef));
                    // Write to disk when the data has over 1GB
                    if (data.Count >= Properties.Settings.Default.CacheNum)
                    {
                        if(WriteDiskCache(data)>0)
                            data.Clear();
                        else
                        {
                            e.Result = "Error";
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                worker.ReportProgress((int)(i / (double)((uint)e.Argument) * 100));
            }
        }

        private int WriteDiskCache(List<uint> data)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("~datcache.tmp", FileMode.Append, FileAccess.Write);
                byte[] databs;
                foreach (uint d in data)
                {
                    databs = BitConverter.GetBytes(d);
                    fs.Write(databs, 0, databs.Length);
                    fs.Position = fs.Length;
                }
                data.Clear();
            }
            catch(IOException ex)
            {
                return ex.HResult;
            }
            finally
            {
                fs.Close();
            }
            return 0;
        }
    }
}
