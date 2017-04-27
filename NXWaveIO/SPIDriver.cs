using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TimeSeriesShared;

namespace NXWaveIO
{
    public class SPIDriver : IWaveIO
    {
        public WaveIOConfig GetConfigs()
        {
            throw new NotImplementedException();
        }

        public void Init(WaveIOConfig config)
        {
            throw new NotImplementedException();
        }

        public void Read(ref byte[] data, int length)
        {
            throw new NotImplementedException();
        }

        public void ReadAsync(int length, ref BackgroundWorker worker)
        {
            throw new NotImplementedException();
        }

        public void ReadWrite(int length, byte[] datain, ref byte[] dataout)
        {
            throw new NotImplementedException();
        }

        public void ReadWriteAsync(int length, byte[] data, ref BackgroundWorker worker)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] wdata, int length)
        {
            throw new NotImplementedException();
        }

        public void WriteAsync(byte[] data, int length, ref BackgroundWorker worker)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return "FTDI SPI driver"; }
        }

        public Type GetConfigForm
        {
            get
            {
                return typeof(FrmSPIConfig);
            }
        }
    }
}
