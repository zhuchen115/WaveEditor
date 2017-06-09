using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace TimeSeriesShared
{
    /// <summary>
    /// The class to store the sample point
    /// </summary>
    /// <remarks>
    /// Define the Type of data when initialize
    /// </remarks>
    [Serializable]
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

        /// <summary>
        /// MiniValue of Series
        /// </summary>
        public double MinValue { get; set; }
        /// <summary>
        /// Maximum Value of Series
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Bits of data
        /// </summary>
        public ushort SampleBits {
            get { return _sample_bits; }
            set {
                int maxbits;
                if (typeof(T) == typeof(uint))
                {
                    maxbits = 32;
                }
                else if (typeof(T) == typeof(ushort))
                {
                    maxbits = 16;
                }
                else if (typeof(T) == typeof(ulong))
                {
                    maxbits = 64;
                }
                else if (typeof(T) == typeof(byte))
                {
                    maxbits = 8;
                }
                else
                {
                    throw new ArgumentException("Type not support for sample bits");
                }
                if (value > maxbits)
                    throw new ArgumentOutOfRangeException("Bits overflow");
                else
                    _sample_bits = value;
            }
        }

        private ushort _sample_bits;

        /// <summary>
        /// Get the value of point
        /// </summary>
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
                    throw new ArgumentException("Type not supported");
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
                    throw new ArgumentException("Type not supported");
                }
            }
        }

        /// <summary>
        /// Get the Value in Real
        /// </summary>
        public double RealValue
        {
            get
            {
                if (typeof(T) == typeof(double) || typeof(T) == typeof(float))
                {
                    return Value.ToDouble(null);
                }
                ulong TVal = Value.ToUInt64(null);
                if (TVal >= ((ulong)1 << SampleBits))
                {
                    throw new ArgumentOutOfRangeException("value", "Out of Storage Range");
                }
                return ((double)TVal) * (MaxValue - MinValue) / ((1 << SampleBits) - 1);
            }
            set
            {
                if (typeof(T) == typeof(double))
                {
                    data = BitConverter.GetBytes(value);
                }
                else if (typeof(T) == typeof(float))
                {
                    data = BitConverter.GetBytes((float)value);
                }
                else
                {
                    if (value > MaxValue || value < MinValue)
                        throw new ArgumentOutOfRangeException("Arguments Out of Range");
                    ulong Tval = (ulong)( value * ((1 << SampleBits) - 1) / (MaxValue - MinValue));
                    this.Value = (T)((Object)Tval);
                }
            }
        }

        /// <summary>
        /// Whether it is in group with previous one
        /// </summary>
        public bool Group { get; set; }

        /// <summary>
        /// Initialize the Sample Point
        /// </summary>
        /// <param name="time">time of the point</param>
        /// <param name="data">data of sample point</param>
        /// <param name="group">whether it should be grouped</param>
        /// <param name="Min">Minimum value of sample</param>
        /// <param name="Max"></param>
        /// <param name="len"></param>
        public SamplePoint(uint time, T data,bool group = false,double Min=0,double Max=5,ushort len=1)
        {
            MinValue = Min;
            MaxValue = Max;
            SampleBits = len;
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
            if (obj is SamplePoint<T> point)
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

        /// <summary>
        /// Only for compare
        /// </summary>
        /// <returns>Hash Code</returns>
        public override int GetHashCode()
        {
            return time.GetHashCode();
        }

        /// <summary>
        /// Serialization Function
        /// </summary>
        /// <remarks>Do not call this function directly </remarks>
        /// <param name="context"></param>
        [OnSerializing]
        private void OnserializeMethod(StreamingContext context)
        {
            if(Tag is IInterpolate<T>)
            {
                Tag = ((IInterpolate<T>)Tag).Name;
            }else
            {
                Tag = null;
            }
        }

    }


    /// <summary>
    /// The time sample series
    /// </summary>
    /// <typeparam name="T">
    /// THe type represent the time series. The type can only be Scalar Number, except decimal
    /// </typeparam>
    /// <remarks>
    /// If the type is unsigned integer, the value can represent the linear value from min to max.
    /// If the type is signed integer, the value can only be fixed point.
    /// If the type is a real number (float, double) Min Max is the range of data.
    /// </remarks>
    [Serializable]
    public class SampleSeries<T>
        where T: IComparable,IEquatable<T>,IConvertible,IFormattable,new()
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
        /// Get the type of generic
        /// </summary>
        public Type GenType
        {
            get
            {
                return typeof(T);
            }
        }

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
                    throw new ArgumentOutOfRangeException("SampleBits", "The Sample bits cannot over 32bits");
                _sample_bits = value;
            }
        }

        /// <summary>
        /// The maximum value of the sample series
        /// </summary>
        public double MaxValue
        { get; set; }

        /// <summary>
        /// The minimum value of the sample series
        /// </summary>
        public double MinValue
        { get; set; }

        List<SamplePoint<T>> ctrldata = new List<SamplePoint<T>>();

        /// <summary>
        /// Initial a Sample Series
        /// </summary>
        /// <param name="samplerate">The Sample Rate, default 250kSPS</param>
        /// <param name="datalength">Default 10 bit data, the data length cannot more than 32</param>
        /// <param name="min">The minimum value of data, default: 0 </param>
        /// <param name="max">The maximum value of data, default: 5</param>
        public SampleSeries(uint samplerate = 250000, UInt16 datalength = 10,double min = 0,double max = 5)
        {
            SampleRate = samplerate;
            if (datalength > 32)
                throw new ArgumentOutOfRangeException("data length", "The data cannot over 32 bits length");
            _sample_bits = datalength;
            MaxValue= max;
            MinValue = min;
            ctrldata.Clear();
        }

        /// <summary>
        /// Put a control Point
        /// </summary>
        /// <param name="time">time of control point</param>
        /// <param name="value">value of control point</param>
        /// <param name="group">Whether it should be grouped for interpolation</param>
        /// <param name="interp">The instance of interpolation class</param>
        public void AddCtrlPoint(uint time, T value,bool group = false,IInterpolate<T> interp = null)
        {
            //Check the value can be expressed
            if (value.ToDouble(null) > MaxValue)
                throw new ArgumentOutOfRangeException("value", "Value is out of the sample bits");
            //if (time == 0)
              //  throw new ArgumentOutOfRangeException("time", "Time cannot be zero");
            SamplePoint<T> sp = new SamplePoint<T>(time, value, group, MinValue, MaxValue, SampleBits)
            {
                Tag = interp
            };
            ctrldata.Add(sp);
            // Make sure the data is in time order.
            ctrldata.Sort();
            // Make sure the data has no distinct.
            ctrldata = ctrldata.Distinct().ToList();
            
        }

        /// <summary>
        /// The number of control point
        /// </summary>
        public int Size
        {
            get { return ctrldata.Count(); }
        }

        /// <summary>
        /// Put a control Point in real value
        /// </summary>
        /// <param name="time">time of control point</param>
        /// <param name="value">value of control point</param>
        /// <param name="group">Whether it should be grouped for interpolation</param>
        /// <param name="interp">The instance of interpolation class</param>
        public void AddCtrlPointD(uint time, double value, bool group = false, IInterpolate<T> interp = null)
        {
            //Check the value can be expressed
            if (value > MaxValue)
                throw new ArgumentOutOfRangeException("value", "Value is out of the sample bits");
            if (time == 0)
                throw new ArgumentOutOfRangeException("time", "Time cannot be zero");
            
            var obv = (value * ((double)(1 << SampleBits) - 1) / (MaxValue - MinValue));
            object obj;
            if (typeof(T) == typeof(uint))
            {
                obj = Convert.ToUInt32(obv);
            }
            else if (typeof(T) == typeof(ushort))
            {
                obj = Convert.ToUInt16(obv);
            }
            else if (typeof(T) == typeof(ulong))
            {
                obj = Convert.ToUInt64(obv);
            }
            else if (typeof(T) == typeof(byte))
            {
                obj = Convert.ToByte(obv);
            }
            else if (typeof(T) == typeof(double))
            {
                obj = obv;
            }
            else if (typeof(T) == typeof(float))
            {
                obj = (float)obv;
            }
            else
            {
                throw new ArgumentException("Type not available for Sample Point");
            }
            SamplePoint<T> sp = new SamplePoint<T>(time, (T)obj, group, MinValue, MaxValue, SampleBits)
            {
                Tag = interp
            };
            ctrldata.Add(sp);
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
                throw new ArgumentOutOfRangeException("value", "Value is out of the sample bits");
            if (time == 0)
                throw new ArgumentOutOfRangeException("time", "Time cannot be zero");
            int loc = ctrldata.FindIndex((SamplePoint<T> point) => { return point.time == time; });

            if (loc >= 0)
                ctrldata[loc] = new SamplePoint<T>(time, value,group, MinValue, MaxValue, SampleBits);
            else
                ctrldata.Add(new SamplePoint<T>(time, value,group, MinValue, MaxValue, SampleBits));
            
        }

        /// <summary>
        /// Change a control point in real value
        /// </summary>
        /// <param name="time">the time(k)</param>
        /// <param name="value">The value to be changed to</param>
        /// <param name="group">Whether the value should grouped</param>
        /// <param name="interp">Interpolation method</param>
        public void EditCtrlPointD(uint time, double value, bool group = false,IInterpolate < T > interp = null)
        {
            //if (time == 0)
              //  throw new ArgumentOutOfRangeException("time", "Time cannot be zero");
            
            int loc = ctrldata.FindIndex((SamplePoint<T> point) => { return point.time == time; });
            var obv = (value * ((double)(1 << SampleBits) - 1) / (MaxValue - MinValue));
            object obj;
            if (typeof(T) == typeof(uint))
            {
                obj = Convert.ToUInt32(obv);
            }
            else if (typeof(T) == typeof(ushort))
            {
                obj = Convert.ToUInt16(obv);
            }
            else if (typeof(T) == typeof(ulong))
            {
                obj = Convert.ToUInt64(obv);
            }
            else if (typeof(T) == typeof(byte))
            {
                obj = Convert.ToByte(obv);
            }
            else if (typeof(T) == typeof(double))
            {
                obj = obv;
            }
            else if (typeof(T) == typeof(float))
            {
                obj = (float)obv;
            }
            else
            {
                throw new ArgumentException("Type not available for Sample Point");
            }
            if (loc >= 0)
                ctrldata[loc] = new SamplePoint<T>(time, (T)obj, group, MinValue, MaxValue, SampleBits) { Tag = interp};
            else
                ctrldata.Add(new SamplePoint<T>(time, (T)obj, group, MinValue, MaxValue, SampleBits) { Tag = interp});

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

        [NonSerialized]
        BackgroundWorker worker0 = null;

        /// <summary>
        /// Interpolate the time series
        /// </summary>
        /// <param name="endtime">The end time of time series</param>
        /// <param name="worker">A background worker can be used to report time</param>
        public void GenerateSeries(uint endtime, BackgroundWorker worker)
        {
            
            //DoWorkEventArgs es = new DoWorkEventArgs(endtime);
            worker0 = worker;
            worker0.DoWork += _genseries_background;
            worker0.WorkerSupportsCancellation = true;
            worker0.WorkerReportsProgress = true;
            worker0.RunWorkerAsync(endtime);

        }

        T[] result_array;

        /// <summary>
        /// The background task for signal generation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _genseries_background(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //File.Create("~datacache.tmp");
            ctrldata = ctrldata.Distinct().ToList();
            ctrldata.Add(new SamplePoint<T>((uint)e.Argument, ctrldata.Last().Value, false, ctrldata.Last().MinValue, ctrldata.Last().MaxValue, ctrldata.Last().SampleBits) { Tag = new ZeroOrderHolder<T>() });
            ctrldata.Sort();
            List<SamplePoint<T>> ctldata = new List<SamplePoint<T>>();
            List<T> result = new List<T>();
            int i = 0;bool end =false;
            while (i<ctrldata.Count())
            {
                worker.ReportProgress((int)(i /(double) ctrldata.Count()*100),"Generate Series");
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                ctldata.Add(ctrldata[i]);
                if(ctldata.Count()==1)
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
                            throw new ArgumentException(String.Format("Group member exceed maximum value in {0}", i));
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
            result_array = result.ToArray();
        }

        /// <summary>
        /// Get the byte array of interpolated signal
        /// </summary>
        /// <param name="littleendian">The character order</param>
        /// <returns>The interpolated data byte array</returns>
        public byte[] ResultToByte(bool littleendian)
        {
            List<byte> btarry = new List<byte>();
            foreach (object d0 in result_array)
            {
                if (typeof(T) == typeof(byte))
                    btarry.Add((byte)d0);
                else if (typeof(T)== typeof(ushort))
                {
                    byte[] atrr = BitConverter.GetBytes((ushort)d0);
                    if (!(littleendian && BitConverter.IsLittleEndian))
                        Array.Reverse(atrr);
                    btarry.AddRange(atrr);
                }
                else if(typeof(T)==typeof(uint))
                {
                    byte[] atrr = BitConverter.GetBytes((uint)d0);
                    if (!(littleendian && BitConverter.IsLittleEndian))
                        Array.Reverse(atrr);
                    btarry.AddRange(atrr);
                }
                else if (typeof(T) == typeof(ulong))
                {
                    byte[] atrr = BitConverter.GetBytes((ulong)d0);
                    if (!(littleendian && BitConverter.IsLittleEndian))
                        Array.Reverse(atrr);
                    btarry.AddRange(atrr);
                }
                else if (typeof(T) == typeof(double))
                {
                    byte[] atrr = BitConverter.GetBytes((double)d0);
                    if (!(littleendian && BitConverter.IsLittleEndian))
                        Array.Reverse(atrr);
                    btarry.AddRange(atrr);
                }
                else
                {
                    throw new ArgumentException("Type not support");
                }
            }

            return btarry.ToArray();
        }

        /// <summary>
        /// Generate the series for display
        /// </summary>
        /// <param name="start">The beginning time</param>
        /// <param name="stop">The ending time</param>
        /// <param name="DispNum">No. of points to be displayed</param>
        /// <returns>The double array</returns>
        public double[] GenerateDispSeries(uint start, uint stop,int DispNum=1000)
        {
            if (ctrldata.Count < 2)
                return new double[0];
            double[] disp = new double[DispNum];
            if (stop <= start)
                throw new InvalidOperationException("Time Start must smaller than Time Stop");
            // find out the control point within range
            List<SamplePoint<T>> ctldata = new List<SamplePoint<T>>();
            List<double> result = new List<double>();
            if (start > ctrldata.Last().time)
            {
                // Zero order holder
                disp[0] =  ctrldata.Last().RealValue;
                ArrayList.Repeat(disp[0], disp.Length).CopyTo(disp);
                return disp;
            }
            // Find all the control point
            var dispctrl_e = from disppoint in ctrldata
                             where disppoint.time >= start && disppoint.time <= stop
                             orderby disppoint.time
                             select disppoint;
            List<SamplePoint<T>> dispctrl = dispctrl_e.ToList();
            if (dispctrl.Count() >= 1)
            {
                if (dispctrl.First().time > start)
                {
                    // Find out the previous point 
                    int idx = ctrldata.FindIndex((SamplePoint<T> point) => { return point.time == dispctrl.First().time; });
                    if (idx < 1) //This can never happen,except the series is not initialized correctly.
                        throw new Exception();
                    dispctrl.Insert(0, ctrldata[idx - 1]);
                }

                if (dispctrl.Last().time < stop)
                {
                    // Find out the next point
                    int idx = ctrldata.FindIndex((SamplePoint<T> point) => { return point.time == dispctrl.Last().time; });
                        
                    if (idx == ctrldata.Count() - 1) //The last point
                    {
                        dispctrl.Add(new SamplePoint<T>(stop, dispctrl.Last().Value, false, MinValue, MaxValue, SampleBits) { Tag = new ZeroOrderHolder<T>()});
                    }
                    else
                    {
                        dispctrl.Add(ctrldata[idx + 1]);
                    }
                }
            }
            else //The Start time and stop time is between two control point
            {
                dispctrl_e = from disppoint in ctrldata
                             where disppoint.time < start
                             orderby disppoint.time descending
                             select disppoint;
                if (dispctrl_e.Count() < 1)
                    throw new ArgumentException("Time Start is not found");
                int idx = ctrldata.FindIndex((SamplePoint<T> point) => { return point.time == dispctrl.First().time; });
                dispctrl.Clear();
                dispctrl.Add(ctrldata[idx]);
                if (idx == ctrldata.Count() - 1)
                    dispctrl.Add(new SamplePoint<T>(stop, ctrldata[idx].Value,false,MinValue,MaxValue,SampleBits));
                else
                    dispctrl.Add(ctrldata[idx + 1]);
            }
            // Now start interpolate
            dispctrl.Sort();
            int i = 0;
            bool end = false;
            double ts = (stop - start) / DispNum;
            int j=0;
            while (i < dispctrl.Count())
            {
                ctldata.Add(dispctrl[i]);
                if (ctldata.Count() ==1)
                {
                    end = false;
                    i++;
                }
                else
                {
                    if (dispctrl[i].Group)
                    {
                        end = false;
                        i++;
                    }
                    else
                        end = true;
                }
                if (end)
                {
                    if (dispctrl[i].Tag is IInterpolate<T> sr)
                    {
                        if (sr.MultiPoint > 0 && sr.MultiPoint < ctldata.Count())
                        {
                            throw new ArgumentException(String.Format("Group member exceed maximum value in {0}", i));
                        }
                        else
                        {
                            int num = 0;
                            //Calculate No of points in this region
                            while(j<DispNum)
                            {
                                if (start + ts * j >= ctldata.Last().time)
                                    break;
                                else
                                {
                                    num++;
                                    j++;
                                }   
                            }
                            if (num > 0)
                            {
                                double[] res = sr.CalculateDisp(ctldata.First().time, ctldata.Last().time, ctldata.ToArray(), num);
                                result.AddRange(res);
                            }
                            ctldata.Clear();
                        }
                    }
                    else
                    {
                        //The interpolation not initialized.
                        throw new InvalidOperationException();
                    }
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Create a function pointer to restore the interpolation
        /// </summary>
        /// <typeparam name="Ty">Same as T</typeparam>
        /// <param name="name">The name from SamplePoint</param>
        /// <returns>Interpolation Class</returns>
        public delegate IInterpolate<T> RestoreInterpolate<Ty>(string name);

        /// <summary>
        /// Rebuild Interpolation
        /// </summary>
        public RestoreInterpolate<T> InterpolationRebuilder { get; set; }

        /// <summary>
        /// Rebuild Interpolation
        /// </summary>
        public void RebuildInterpolation()
        {
            foreach(SamplePoint<T> sp in ctrldata)
            {
                if(sp.Tag is string)
                    sp.Tag = InterpolationRebuilder((string)sp.Tag);
            }
        }
        

    }
}
