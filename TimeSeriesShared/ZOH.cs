using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesShared
{
    /// <summary>
    /// Give a zero order holder for interpolation
    /// </summary>
    /// <typeparam name="T">numeric value</typeparam>
    public class ZeroOrderHolder<T> : IInterpolate<T>
        where T : IComparable, IEquatable<T>, IConvertible
    {
        /// <summary>
        /// The Name
        /// </summary>
        public string Name{get{ return "Zero Order Holder";} }

        /// <summary>
        /// The ZOH only needs two points
        /// </summary>
        public int MultiPoint { get { return 2; } }

        /// <summary>
        /// Implement IInterpolate <see cref="IInterpolate{T}"/>
        /// </summary>
        /// <param name="start">begin time</param>
        /// <param name="stop">End time</param>
        /// <param name="point">Control Points</param>
        /// <returns>interpolated signal</returns>
        public T[] Calculate(uint start, uint stop, SamplePoint<T>[] point)
        {
            if (start > stop)
                throw new ArgumentException("Start Time larger than stop time");
            T[] result= new T[stop - start + 1];
            ArrayList.Repeat(point[0].Value, (int)(stop - start + 1)).CopyTo(result);
            return result;
        }

        /// <summary>
        /// Calculate the display signal
        /// </summary>
        /// <param name="start">begin time</param>
        /// <param name="stop">End time</param>
        /// <param name="points">Control Points</param>
        /// <param name="num">number of display point</param>
        /// <returns>double array</returns>
        public double[] CalculateDisp(uint start, uint stop, SamplePoint<T>[] points, int num)
        {
            if (start > stop)
                throw new ArgumentException("Start Time larger than stop time");
            double[] result = new double[num];
            ArrayList.Repeat(points[0].RealValue, num).CopyTo(result);
            return result;
        }
    }
}
