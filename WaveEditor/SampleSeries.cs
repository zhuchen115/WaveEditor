using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WaveEditor
{
    public class SamplePoint :IComparable,IEquatable<SamplePoint>
    {
        public uint time;
        public uint data;
        public object Tag;
        public SamplePoint(uint time, uint data)
        {
            this.time = time;
            this.data = data;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            SamplePoint point = obj as SamplePoint;
            if (point != null)
                return this.time.CompareTo(point.time);
            else
                throw new ArgumentException("Object Type Error");
        }

        public bool Equals(SamplePoint other)
        {
            return this.time == other.time;
        }

        public override int GetHashCode()
        {
            return time.GetHashCode();
        }
    }

    public enum SampleInterpolation
    {
        LINEAR,
        SPLINE,
        CALLBACK
    }
    /// <summary>
    /// Store the Time Series
    /// </summary>
    class SampleSeries
    {
        uint _samplerate;

        /// <summary>
        /// The Sample Rate of the Time Series unit: samples per seconds
        /// </summary>
        public uint SampleRate
        {
            get { return _samplerate; }
            set { _samplerate = value; }
        }

        /// <summary>
        /// Get the Sample Time
        /// </summary>
        public double Ts
        {
            get { return 1 / (double)_samplerate; }
            set { _samplerate = (uint)(1 / value); }
        }

        UInt16 _sample_bits;

        /// <summary>
        /// The bits / accuracy of Sample
        /// </summary>
        public UInt16 SampleBits
        {
            get { return _sample_bits; }
            set
            {
                if (value > 32)
                    throw new ArgumentOutOfRangeException("SampleBits", "The Samplebits cannot over 32bits");
                _sample_bits = value;
            }
        }

        double _maxvalue,_minvalue;

        /// <summary>
        /// The Max value to be presented.
        /// </summary>
        public double MaxValue
        {
            get { return _maxvalue; }
            set { _maxvalue = value; }
        }

        /// <summary>
        /// The Mininum value to be presented.
        /// </summary>
        public double MinValue
        {
            get { return _minvalue; }
            set { _minvalue = value; }
        }

        SampleInterpolation _interpolation = SampleInterpolation.LINEAR;
        public SampleInterpolation Interpolation
        {
            get { return _interpolation; }
            set { _interpolation = value; }
        }

        public delegate double InterpolationFunction(uint time, uint prevtime, uint nextime, uint prevval, uint nextvalue);

        public InterpolationFunction InterpolationCallback = null;
        //Store the data to be process
        List<UInt32> data = new List<uint>();
        // Control Point
        List<SamplePoint> ctrldata = new List<SamplePoint>();

        /// <summary>
        /// Initial a Sample Series
        /// </summary>
        /// <param name="samplerate">The Sample Rate, default 250kSPS</param>
        /// <param name="datalength">Default 10 bit data, the datalength cannot more than 32</param>
        /// <param name="min">The mininum value of data, default: 0 </param>
        /// <param name="max">The maxinum value of data, default: 5</param>
        public SampleSeries(uint samplerate=250000,UInt16 datalength = 10,double min = 0,double max = 5)
        {
            _samplerate = samplerate;
            if (datalength > 32)
                throw new ArgumentOutOfRangeException("datalength", "The data cannot over 32 bits length");
            _sample_bits = datalength;
            _maxvalue = max;
            _minvalue = min;
            ctrldata.Clear();
            ctrldata.Add(new SamplePoint(0, 0));
        }

        /// <summary>
        /// Put a control Point (linear sample)
        /// </summary>
        /// <param name="time"></param>
        /// <param name="value"></param>
        public void AddCtrlPoint(uint time,uint value)
        {
            //Check the value can be expressed
            if (value >= (1 << _sample_bits))
                throw new ArgumentOutOfRangeException("value", "Value is outof the sample bits");
            if (time == 0)
                throw new ArgumentOutOfRangeException("time", "Time cannot be zero");
            ctrldata.Add(new SamplePoint(time,value));
            // Make sure the data is in time order.
            ctrldata.Sort();
            // Make sure the data has no distinct.
            ctrldata = ctrldata.Distinct().ToList();
            //_generated_series = false;
        }

        /// <summary>
        /// Convert a sample value to real value
        /// </summary>
        /// <param name="value">The sampled value</param>
        /// <returns>A float value</returns>
        public double RealValue(uint value)
        {
            if (value >= (1 << _sample_bits))
                throw new ArgumentOutOfRangeException("value", "Value is outof the sample bits");
            return ((double)value) * (_maxvalue - _minvalue) / ((1 << _sample_bits) - 1);
        }
        
        /// <summary>
        /// Edit the control point
        /// </summary>
        /// <param name="time">the time value of the ctrl point</param>
        /// <param name="value">The value to be changed to</param>
        public void EditCtrlPoint(uint time,uint value)
        {
            if (value >= (1 << _sample_bits))
                throw new ArgumentOutOfRangeException("value", "Value is outof the sample bits");
            if (time == 0)
                throw new ArgumentOutOfRangeException("time", "Time cannot be zero");
            int loc = ctrldata.FindIndex((SamplePoint point)=> { return point.time == time; });
            if (loc >= 0)
                ctrldata[loc] = new SamplePoint(time, value);
            else
                ctrldata.Add(new SamplePoint(time, value));
            //_generated_series = false;
        }

        /// <summary>
        /// Remove a control point
        /// </summary>
        /// <param name="time">The time of sample</param>
        public void DelCtrlPoint(uint time)
        {
            int loc = ctrldata.FindIndex((SamplePoint point) => { return point.time == time; });
            if (loc < 0)
                throw new ArgumentException("Point not Found");
            else
                ctrldata.RemoveAt(loc);
            //_generated_series = false;
        }
        /// <summary>
        ///  Sample time to Real time convertion
        /// </summary>
        /// <param name="time">The Sample time</param>
        /// <returns>Real time value</returns>
        public double RealTime(uint time)
        {
            return ((double)time / _samplerate);
        }


        
        BackgroundWorker worker;
        /// <summary>
        /// Generate the Timer Series
        /// </summary>
        /// <remarks>
        /// Configure the method of Generation by using Interpolation property.
        /// If using Callback, the callbacak function mustion be setted
        /// </remarks>
        /// <param name="endtime">The ending time of time series</param>
        /// <param name="process">If need to report proces use this</param>
        public void GenerateSeries(uint endtime,ProgressChangedEventHandler process = null, RunWorkerCompletedEventHandler done = null)
        {
            File.Create("~datacache.tmp");
            ctrldata = ctrldata.Distinct().ToList();
            ctrldata.Sort();
            DoWorkEventArgs es = new DoWorkEventArgs(endtime);
            worker = new BackgroundWorker();
            switch(_interpolation)
            {
                case SampleInterpolation.LINEAR:
                    //worker.DoWork += _background_gen_series_linear;
                    break;
                case SampleInterpolation.SPLINE:
                    throw new NotImplementedException();
                    break;
                case SampleInterpolation.CALLBACK:
                    if (InterpolationCallback == null)
                        throw new InvalidOperationException("Callback Not Setted");
                    break;
            }
            if (process != null)
                worker.ProgressChanged += process;
            worker.RunWorkerCompleted += _background_gen_done;
            if (done != null)
                worker.RunWorkerCompleted += done;
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
        }

        public void StopAsyncGenerate()
        {
            if (worker.IsBusy)
                worker.CancelAsync();
        }

        /// <summary>
        /// When the gneration process done without error or cancel, upgrade the process;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _background_gen_done(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) return;
            if (e.Error != null) return;
        }
        /*
        /// <summary>
        /// Generate the time series using liner interpolation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _background_gen_series_linear(object sender,DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int k = 0, ctlen = ctrldata.Count - 1;
            uint nextvalue = ctrldata[0].data, nexttime = ctrldata[0].time, prevval = 0, prevtime = 0;
            double coef=0;
            for (uint i = 0; i < (uint)e.Argument; i++)
            {
                // Check the worker state   
                if(worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                // Goto new control point
                if (i == nexttime)
                {
                    data.Add(ctrldata[k].data);
                    if (k <= ctlen)
                    {
                        k++;
                        prevtime = nexttime;
                        prevval = nextvalue;
                        nextvalue = ctrldata[k].data;
                        nexttime = ctrldata[k].time;
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
                    if (data.Count>=Properties.Settings.Default.CacheNum)
                    {
                        WriteDiskCache();
                        data.Clear();
                    }
                }
                worker.ReportProgress((int)(i/(double)((uint)e.Argument)*100));
            }
        }

        private void WriteDiskCache()
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
            
            finally
            {
                fs.Close();
            }

        }*/


        public uint[] GetDisplayPoint(uint timestart,uint timestop)
        {
            uint[] disp = new uint[Properties.Settings.Default.DispNum];
            if (timestop <= timestart)
                throw new InvalidOperationException("Time Start must smaller than Time Stop");
            // find out the control point within range
            if (timestart > ctrldata.Last().time)
            {
                // Zero order holder
                disp[0] = ctrldata.Last().data;
                ArrayList.Repeat(disp[0], disp.Length).CopyTo(disp);
                return disp;
            }

            var dispctrl_e = from disppoint in ctrldata
                           where disppoint.time >= timestart && disppoint.time <= timestop
                           orderby disppoint.time
                           select disppoint;
            List<SamplePoint> dispctrl = dispctrl_e.ToList();
            if (dispctrl.Count() >= 1)
            {
                if (dispctrl.First().time > timestart)
                {
                    // Find out the previous point 
                    int idx = ctrldata.FindIndex((SamplePoint point) => { return point.time == dispctrl.First().time; });
                    if (idx < 1) //This can never happen
                        throw new Exception();
                    dispctrl.Insert(0, ctrldata[idx - 1]);
                }

                if(dispctrl.Last().time < timestop)
                {
                    // Find out the next point
                    int idx = ctrldata.FindIndex((SamplePoint point) => { return point.time == dispctrl.Last().time; });
                    if (idx < 1) //This can never happen
                        throw new Exception();
                    if (idx == ctrldata.Count()-1) //The last point
                    {
                        dispctrl.Add(new SamplePoint(timestop, dispctrl.Last().data));
                    }
                }
            }
            else //The Start time and stop time is between two control point
            {
                dispctrl_e = from disppoint in ctrldata
                             where disppoint.time < timestart
                             orderby disppoint.time descending
                             select disppoint;
                if (dispctrl_e.Count() < 1)
                    throw new ArgumentException("Time Start is not found");
                int idx = ctrldata.FindIndex((SamplePoint point) => { return point.time == dispctrl.First().time; });
                dispctrl.Clear();
                dispctrl.Add(ctrldata[idx]);
                if (idx == ctrldata.Count() - 1)
                    dispctrl.Add(new SamplePoint(timestop, ctrldata[idx].data));
                else
                    dispctrl.Add(ctrldata[idx + 1]);
            }
            _interpolation_mid(dispctrl, ref disp, timestart, timestop);
            return disp;
        }
        public void _interpolation_mid(List< SamplePoint> control_points, ref uint[] target, uint start, uint stop)
        {
            control_points.Sort();
            switch (_interpolation)
            {
                case SampleInterpolation.LINEAR:
                    _interpolate_linear(control_points,ref target, start, stop);
                    break;
                case SampleInterpolation.SPLINE:
                    throw new NotImplementedException();
                    break;
                case SampleInterpolation.CALLBACK:
                    break;
            }
        }

        /// <summary>
        /// Linear Interpolation define the start time and end time;
        /// </summary>
        /// <param name="control_point"></param>
        /// <param name="target"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        private void _interpolate_linear(List<SamplePoint> control_point, ref uint[] target, uint start, uint stop)
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
            while(i<len)
            {
                coef = (control_point[pos + 1].data - control_point[pos].data) / (double)(control_point[pos + 1].time - control_point[pos].time);
                while(((i*ts+start)<= control_point[pos + 1].time)&&i<len)
                {
                    target[i] = control_point[pos].data + (uint)(coef * ((i * ts + start - i)));
                    i++;
                }
                pos++;
            }
        }


    }
}
