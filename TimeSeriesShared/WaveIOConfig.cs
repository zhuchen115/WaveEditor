using System.Collections.Generic;

namespace TimeSeriesShared
{
    /// <summary>
    /// The configuration class for the IWaveIO
    /// </summary>
    public class WaveIOConfig
    {
        protected Dictionary<string, object> _config = new Dictionary<string, object>();

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