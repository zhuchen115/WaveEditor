using  System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TimeSeriesShared
{
    public interface IWaveIO
    {
        /// <summary>
        /// Initialize the IO port
        /// </summary>
        /// <param name="config">The IO Configuration</param>
        void Init(WaveIOConfig config);

        /// <summary>
        /// Get the initial configuration.
        /// </summary>
        /// <returns>The configure hashtable</returns>
        WaveIOConfig GetConfigs();

        /// <summary>
        /// Write data to IO port
        /// </summary>
        /// <param name="wdata">data to be write</param>
        /// <param name="length">length of data</param>
        [Obsolete("Foreground function can cause GUI crash")]
        void Write(byte[] wdata, int length);

        /// <summary>
        /// Write data to IO port at background
        /// </summary>
        /// <param name="data">The data to be send out</param>
        /// <param name="length">The bytes of data to be write</param>
        /// <param name="worker">BackgroundWorker woth callback</param>
        void WriteAsync(byte[] data, int length, ref BackgroundWorker worker);

        /// <summary>
        /// Ready from IO port
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        [Obsolete("The Foreground function may make the UI crash")]
        void Read(ref byte[] data, int length);

        /// <summary>
        /// Read From IO port in background
        /// </summary>
        /// <param name="length">The length of byte to read</param>
        /// <param name="worker">The result will be in the worker result</param>
        void ReadAsync(int length, ref BackgroundWorker worker);

        /// <summary>
        /// Read and Write Duplex on IO in background
        /// </summary>
        /// <param name="length">bytes of data</param>
        /// <param name="data">the data in</param>
        /// <param name="worker">The read data will in result</param>
        void ReadWriteAsync(int length, byte[] data, ref BackgroundWorker worker);

        /// <summary>
        /// Read and Write Duplex on IO
        /// </summary>
        /// <param name="length">bytes of data to be send and read</param>
        /// <param name="datain">the data sent out</param>
        /// <param name="dataout">the data read</param>
        [Obsolete("The Foreground function may make the UI crash")]
        void ReadWrite(int length, byte[] datain, ref byte[] dataout);
    }

    public enum ConfigType
    {
        NUMERIC,
        ENUM,
        STRING
    }

    /// <summary>
    /// The configuration class for the IWaveIO
    /// </summary>
    public class WaveIOConfig
    {
        private Dictionary<string, object> _config = new Dictionary<string, object>();
        private Dictionary<string, ConfigType> _types = new Dictionary<string, ConfigType>();
        public Dictionary<string, object> Config
        {
            get { return _config; }
        }

        public object this[string idx]
        {
            get
            {
                return _config[idx];
            }
            set
            {
                _config[idx] = value;
            }
        }




    }
}