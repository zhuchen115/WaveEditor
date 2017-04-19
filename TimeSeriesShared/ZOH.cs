using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSeriesShared
{
    public class ZeroOrderHolder<T> : IInterpolate<T>
        where T : IComparable, IEquatable<T>, IConvertible
    {
        public string Name{get{ return "Zero Order Holder";} }

        public int MultiPoint { get { return 2; } }

        public T[] Calculate(uint start, uint stop, SamplePoint<T>[] point)
        {
            if (start > stop)
                throw new ArgumentException("Start Time larger than stop time");
            T[] result= new T[stop - start + 1];
            ArrayList.Repeat(point[0].Value, (int)(stop - start + 1)).CopyTo(result);
            return result;
        }

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
