using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace WaveEditor
{
    public interface IInterpolation
    {
        /// <summary>
        /// Fore Ground Interpolation Call
        /// </summary>
        /// <param name="control">The control point</param>
        /// <param name="endtime">The ending time</param>
        /// <returns>The interpolated Series</returns>
        uint[] GenerateSeriesFull(List<SamplePoint> control, uint endtime);


        /// <summary>
        /// Generate the signal series at background
        /// </summary>
        /// <param name="control">THe control point</param>
        /// <param name="endtime">The endtime of signal</param>
        /// <param name="sender"> A BackgroundWorker object</param>
        void GenerateSeriesBackground(List<SamplePoint> control, uint endtime, object sender);

        /// <summary>
        /// Generate Display Series
        /// </summary>
        /// <param name="control_point">The Control Point in </param>
        /// <param name="target"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        void GenerateDisp(List<SamplePoint> control_point,ref uint[] target, uint start, uint stop);

       
    }
}
