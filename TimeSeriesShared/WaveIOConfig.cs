using System.Collections.Generic;

namespace TimeSeriesShared
{
    /// <summary>
    /// The configuration class for the IWaveIO
    /// </summary>
    public class WaveIOConfig
    {
        /// <summary>
        /// The stored configuration 
        /// </summary>
        protected Dictionary<string, object> _config = new Dictionary<string, object>();

        /// <summary>
        /// Get the configuration data
        /// </summary>
        public Dictionary<string, object> Config
        {
            get { return _config; }
        }


        /// <summary>
        /// Indexer Make it possible direct operation on dictionary
        /// </summary>
        /// <param name="idx">Index string</param>
        /// <returns>configuration object</returns>
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