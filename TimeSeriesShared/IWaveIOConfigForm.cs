using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesShared
{
    /// <summary>
    /// The Form for configure the WaveIO
    /// </summary>
    public interface IWaveIOConfigForm
    {
        /// <summary>
        /// The form must return configuration
        /// </summary>
        WaveIOConfig Config { get; }
    }
}
