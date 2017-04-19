using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterpolationBasic;
using TimeSeriesShared;

namespace WaveEditor
{
    static class InterpolateC
    {
        static List<IInterpolate<uint>> dwInterpolate = new List<IInterpolate<uint>>();

        static InterpolateC()
        {
            dwInterpolate.Add(new LinearInterpolate<uint>());
            dwInterpolate.Add(new SplineInterpolate<uint>());
            dwInterpolate.Add(new SinInterpolate<uint>());
        }

        /// <summary>
        /// Get the names of Interplation Method
        /// </summary>
        /// <returns></returns>
        public static string[] GetNames()
        {
            List<string> names = new List<string>();
            foreach (IInterpolate<uint> jw in dwInterpolate)
            {
                names.Add(jw.Name);
            }
            return names.ToArray();
        }
        public static IInterpolate<T> GetInstanceById<T>(int id)
            where T : IComparable, IEquatable<T>, IConvertible
        {
            if (id > (dwInterpolate.Count() - 1))
                throw new ArgumentException("id out of range, type not found");
            Type tpBase = dwInterpolate[id].GetType().GetGenericTypeDefinition();
            Type[] tpArg = { typeof(T) };
            Type construct = tpBase.MakeGenericType(tpArg);
            return (IInterpolate<T>)Activator.CreateInstance(construct);
        }
    }
}
