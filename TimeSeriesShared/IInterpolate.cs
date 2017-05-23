using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesShared
{
    /// <summary>
    /// Interpolation class that can accept any numeric type
    /// </summary>
    /// <typeparam name="T">The type of number</typeparam>
    public interface IInterpolate<T>
        where T : IComparable, IEquatable<T>, IConvertible
    {
        /// <summary>
        /// Name of the Class
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Whether the method support multi-point interpolation
        /// </summary>
        /// <remarks>
        /// If the method only need 2 points, set it to 2.
        /// If the method need more than two set it to how much it need (maximum).
        /// If the method can accept unlimited control point, set it to -1
        /// </remarks>
        int MultiPoint { get; }

        /// <summary>
        /// Calculate the Interpolation Continuously
        /// </summary>
        /// <param name="start">The starting time</param>
        /// <param name="stop">The ending time</param>
        /// <param name="point">The control points</param>
        /// <returns>Return the interpolated time series</returns>
        /// <remarks> The function should return include the first point without final point</remarks>
        T[] Calculate(uint start, uint stop, SamplePoint<T>[] point);

        /// <summary>
        /// Generate the Display Points
        /// </summary>
        /// <param name="start">the begin time of display</param>
        /// <param name="stop">the end time of display</param>
        /// <param name="points">The control points in range</param>
        /// <param name="num">number of points</param>
        /// <returns>The double array for display</returns>
        double[] CalculateDisp(uint start, uint stop, SamplePoint<T>[] points, int num);
    }

    /// <summary>
    /// Defines the interpolation on 32bit numeric
    /// </summary>
    public interface IInterpolate : IInterpolate<uint> { };

    /// <summary>
    /// Defines the interpolation on real numeric
    /// </summary>
    public interface IInterpolateDouble : IInterpolate<double> { };
    
    /// <summary>
    /// Defines the interpolation for 16bit numeric
    /// </summary>
    public interface IInterpolate16 : IInterpolate<ushort> { };

}
