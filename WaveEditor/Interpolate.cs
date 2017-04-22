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
            //Add internal interpolate
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

        /// <summary>
        /// Get an instance of the Interpolator
        /// </summary>
        /// <typeparam name="T">The type of number</typeparam>
        /// <param name="id">The id of Interpolator</param>
        /// <returns>An instance of interpolator</returns>
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

        /// <summary>
        /// Find the id of Interpolator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inst"></param>
        /// <returns></returns>
        public static int GetIdByInstance<T>(IInterpolate<T> inst)
            where T : IComparable, IEquatable<T>, IConvertible
        {
            Type tpBase = inst.GetType().GetGenericTypeDefinition();
            int i = 0;
            foreach(IInterpolate<uint> jw in dwInterpolate)
            {
                if (jw.GetType().GetGenericTypeDefinition() == tpBase)
                    break;
                i++;
            }
            if (i == dwInterpolate.Count())
                return -1;
            else
                return i;
        }
    }
}
