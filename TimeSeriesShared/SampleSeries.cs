using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesShared
{
    /// <summary>
    /// The class to store the sample point
    /// </summary>
    /// <remarks>
    /// Define the Type of data when initialize
    /// </remarks>
    public class SamplePoint<T> : IComparable, IEquatable<SamplePoint<T>>
        where T: IComparable,IEquatable<T>,IConvertible
    {
        /// <summary>
        /// Sample time (k) 
        /// </summary>
        public uint time;
        /// <summary>
        /// The data 
        /// </summary>
        public byte[] data;
        /// <summary>
        /// The data property.
        /// </summary>
        public object Tag;

        public T Value
        {
            get
            {
                if (typeof(T) == typeof(uint))
                {
                    object t = BitConverter.ToUInt32(data, 0);
                    return (T)t;
                }
                else if (typeof(T) == typeof(ushort))
                {
                    object t = BitConverter.ToUInt16(data, 0);
                    return (T)t;
                }
                else if (typeof(T) == typeof(byte))
                {
                    object t = data[0];
                    return (T)t;
                }else if(typeof(T) == typeof(ulong))
                {
                    object t = BitConverter.ToUInt64(data, 0);
                    return (T)t;
                }else
                {
                    throw new ArgumentException("Typr not supported");
                }
            }
            set
            {
                if (typeof(T) == typeof(uint))
                {
                    data = BitConverter.GetBytes(value.ToUInt32(null));
                }
                else if (typeof(T) == typeof(ushort))
                {
                    data = BitConverter.GetBytes(value.ToUInt16(null));
                }
                else if (typeof(T) == typeof(byte))
                {
                    data[0] = value.ToByte(null);
                }
                else if (typeof(T) == typeof(ulong))
                {
                    data = BitConverter.GetBytes(value.ToUInt64(null));
                }
                else
                {
                    throw new ArgumentException("Typr not supported");
                }
            }
        }

        /// <summary>
        /// Whether it is in group with previous one
        /// </summary>
        public bool Group { get; set; }

        public SamplePoint(uint time, T data,bool group = false)
        {
            if (typeof(T) == typeof(uint))
            {
                this.data = new byte[4];
                uint val = data.ToUInt32(null);
                this.data = BitConverter.GetBytes(val);
            }
            /*else if (typeof(T) == typeof(int))
            {
                this.data = new byte[4];
                int val = data.ToInt32(null);
                this.data = BitConverter.GetBytes(val);
            }
            else if (typeof(T) == typeof(short))
            {
                this.data = new byte[2];
                short val = data.ToInt16(null);
                this.data = BitConverter.GetBytes(val);
            }*/
            else if (typeof(T) == typeof(ushort))
            {
                this.data = new byte[2];
                ushort val = data.ToUInt16(null);
                this.data = BitConverter.GetBytes(val);
            }
            /*else if (typeof(T) == typeof(long))
            {
                this.data = new byte[8];
                long val = data.ToInt64(null);
                this.data = BitConverter.GetBytes(val);
            }*/
            else if (typeof(T) == typeof(ulong))
            {
                this.data = new byte[8];
                ulong val = data.ToUInt64(null);
                this.data = BitConverter.GetBytes(val);
            }
            else if (typeof(T) == typeof(byte))
            {
                this.data = new byte[1];
                byte val = data.ToByte(null);
                this.data = BitConverter.GetBytes(val);
            }
            /*else if (typeof(T) == typeof(sbyte))
            {
                this.data = new byte[1];
                sbyte val = data.ToSByte(null);
                this.data = BitConverter.GetBytes(val);
            }*/
            else if (typeof(T) == typeof(double))
            {
                this.data = new byte[8];
                double val = data.ToDouble(null);
                this.data = BitConverter.GetBytes(val);
            }
            else if (typeof(T) == typeof(float))
            {
                this.data = new byte[4];
                float val = data.ToSingle(null);
                this.data = BitConverter.GetBytes(val);
            }else
            {
                throw new ArgumentException("Type not available for Sample Point");
            }
            this.time = time;
            this.Group = group;
        }

        /// <summary>
        /// Implement IComparable, The time is compared
        /// <see cref="IComparable{UInt32}"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            SamplePoint<T> point = obj as SamplePoint<T>;
            if (point != null)
                return this.time.CompareTo(point.time);
            else
                throw new ArgumentException("Object Type Error");
        }

        /// <summary>
        /// Implement the IEquatable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SamplePoint<T> other)
        {
            return this.time == other.time;
        }

        public override int GetHashCode()
        {
            return time.GetHashCode();
        }


    }


    /// <summary>
    /// The time sample seroes
    /// </summary>
    /// <typeparam name="T">
    /// THe type represent the time series. The type can only be Scalar Number, except decimal
    /// </typeparam>
    /// <remarks>
    /// If the type is unsigned interger, the value can represent the linear value from min to max.
    /// If the type is signed interger, the value can only be fixed point.
    /// If the type is a real number (float, double) Min Max is the range of data.
    /// </remarks>
    public class SampleSeries<T>
        where T: IComparable,IEquatable<T>,IConvertible
    {
        /// <summary>
        /// The Sample Rate of Signal, unit SPS
        /// </summary>
        public uint SampleRate
        { get; set; }

        /// <summary>
        /// Sample Rate of Time Series
        /// </summary>
        public double Ts
        {
            get { return 1 / (double)SampleRate; }
            set { SampleRate = (uint)(1 / value); }
        }

        UInt16 _sample_bits;

        /// <summary>
        /// The bits / accuracy of Sample
        /// </summary>
        /// <remarks>
        /// THe SampleBits is used when the data type is Unsigned
        /// </remarks>
        public UInt16 SampleBits
        {
            get { return _sample_bits; }
            set
            {
                if (value > 64)
                    throw new ArgumentOutOfRangeException("SampleBits", "The Samplebits cannot over 32bits");
                _sample_bits = value;
            }
        }

        /// <summary>
        /// The maxinum value of the sample series
        /// </summary>
        public double MaxValue
        { get; set; }

        /// <summary>
        /// The mninimum value of the sample series
        /// </summary>
        public double MinValue
        { get; set; }

        List<SamplePoint<T>> ctrldata = new List<SamplePoint<T>>();

        /// <summary>
        /// Initial a Sample Series
        /// </summary>
        /// <param name="samplerate">The Sample Rate, default 250kSPS</param>
        /// <param name="datalength">Default 10 bit data, the datalength cannot more than 32</param>
        /// <param name="min">The mininum value of data, default: 0 </param>
        /// <param name="max">The maxinum value of data, default: 5</param>
        public SampleSeries(uint samplerate = 250000, UInt16 datalength = 10,double min = 0,double max = 5)
        {
            SampleRate = samplerate;
            if (datalength > 32)
                throw new ArgumentOutOfRangeException("datalength", "The data cannot over 32 bits length");
            _sample_bits = datalength;
            MaxValue= max;
            MinValue = min;
            ctrldata.Clear();
        }

        /// <summary>
        /// Put a control Point (linear sample)
        /// </summary>
        /// <param name="time"></param>
        /// <param name="value"></param>
        public void AddCtrlPoint(uint time, T value,bool group = false)
        {
            //Check the value can be expressed
            if (value.ToDouble(null) >= MaxValue)
                throw new ArgumentOutOfRangeException("value", "Value is outof the sample bits");
            if (time == 0)
                throw new ArgumentOutOfRangeException("time", "Time cannot be zero");
            ctrldata.Add(new SamplePoint<T>(time, value,group));
            // Make sure the data is in time order.
            ctrldata.Sort();
            // Make sure the data has no distinct.
            ctrldata = ctrldata.Distinct().ToList();
            
        }

        /// <summary>
        /// Get the Real value from slope value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Double value</returns>
        public double RealValue(T value)
        {
            // Originally Real Value
            if(typeof(T)== typeof(double)||typeof(T)==typeof(float))
            {
                return value.ToDouble(null);
            }
            ulong TVal = value.ToUInt64(null);
            if(TVal>= ((ulong)1 << SampleBits))
            {
                throw new ArgumentOutOfRangeException("value", "Out of Storage Range");
            }
            return ((double)TVal) * (MaxValue - MinValue) / ((1 << SampleBits) - 1);
        }

        /// <summary>
        /// Edit a control point
        /// </summary>
        /// <param name="time">the time(k)</param>
        /// <param name="value">The value to be changed to</param>
        /// <param name="group">Whether the value should grouped</param>
        public void EditCtrlPoint(uint time, T value,bool group = false)
        {
            if (value.ToUInt64(null) >= ((ulong)1 << _sample_bits))
                throw new ArgumentOutOfRangeException("value", "Value is outof the sample bits");
            if (time == 0)
                throw new ArgumentOutOfRangeException("time", "Time cannot be zero");
            int loc = ctrldata.FindIndex((SamplePoint<T> point) => { return point.time == time; });
            if (loc >= 0)
                ctrldata[loc] = new SamplePoint<T>(time, value,group);
            else
                ctrldata.Add(new SamplePoint<T>(time, value,group));
            
        }

        /// <summary>
        /// Delete the control point at time
        /// </summary>
        /// <param name="time">the time</param>
        public void DelCtrlPoint(uint time)
        {
            int loc = ctrldata.FindIndex((SamplePoint<T> point) => { return point.time == time; });
            if (loc < 0)
                throw new ArgumentException("Point not Found");
            else
                ctrldata.RemoveAt(loc);
        }

        /// <summary>
        /// Transfer the time (k) to time (s)
        /// </summary>
        /// <param name="time">sample number</param>
        /// <returns>The real time</returns>
        public double RealTime(uint time)
        {
            return ((double)time / SampleRate);
        }

        BackgroundWorker worker = null;

        /// <summary>
        /// Interpolate the time series
        /// </summary>
        /// <param name="endtime">the end time</param>
        /// <param name="process">The process to be reported</param>
        /// <param name="done">When the event is done, the result will be passed through result</param>
        public void GenerateSeries(uint endtime, ProgressChangedEventHandler process = null, RunWorkerCompletedEventHandler done = null)
        {
            
            DoWorkEventArgs es = new DoWorkEventArgs(endtime);
            worker = new BackgroundWorker();
            worker.DoWork += _genseries_background;
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            if (process != null)
                worker.ProgressChanged += process;
            if (done != null)
                worker.RunWorkerCompleted += done;

        }



        private void _genseries_background(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            File.Create("~datacache.tmp");
            ctrldata = ctrldata.Distinct().ToList();
            ctrldata.Sort();
            List<SamplePoint<T>> ctldata = new List<SamplePoint<T>>();
            List<T> result = new List<T>();
            int i = 0;bool end =false;
            while (i<ctrldata.Count())
            {
                if(worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                ctldata.Add(ctrldata[i]);
                if(ctrldata.Count()==0)
                {
                    end = false;
                    i++;
                }
                else
                {
                    if (ctrldata[i].Group)
                    {
                        end = false;
                        i++;
                    }   
                    else
                        end = true;
                }
                if(end)
                {
                    if (ctrldata[i].Tag is IInterpolate<T> sr)
                    {
                        if (sr.MultiPoint > 0 && sr.MultiPoint < ctldata.Count())
                        {
                            throw new ArgumentException(String.Format("Group member exceed maxinum value in {0}", i));
                        }
                        else
                        {
                            T[] res =sr.Calculate(ctldata.First().time, ctldata.Last().time, ctldata.ToArray());
                            result.AddRange(res);
                            ctldata.Clear();
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            e.Result = result;
        }
    }
}
