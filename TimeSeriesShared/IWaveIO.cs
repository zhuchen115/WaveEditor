using System;
using System.ComponentModel;

namespace TimeSeriesShared
{
    /// <summary>
    /// Interface for Signal Input and Output
    /// </summary>
    public interface IWaveIO :IDisposable
    {
        /// <summary>
        /// Initialize the IO port
        /// </summary>
        /// <param name="config">The IO Configuration</param>
        void Init(WaveIOConfig config);

        /// <summary>
        /// Get the initial configuration.
        /// </summary>
        /// <returns>The configure hash table</returns>
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
        /// <param name="worker">BackgroundWorker with callback</param>
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

        /// <summary>
        /// The IO should have a name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get the type of a form contains configuration
        /// </summary>
        Type GetConfigForm { get; }
    }
}