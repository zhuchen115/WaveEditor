// InterpolationBasic.h

#pragma once
#include <cmath>

using namespace System;
using namespace TimeSeriesShared;


namespace InterpolationBasic {
	
	/// <summary> The linear interpolation class</summary>
	/// <typeparam name="NumType"> A Numeric Type</typeparam>
	/// <remarks> This class can be convert to pure CLI Class</remarks>
	generic <typename NumType>
		where NumType: IConvertible,IComparable,IEquatable<NumType>
	public ref class LinearInterpolate :IInterpolate<NumType>
	{
	public:

		///<summary> The name of Interpolation</summary>
		///<value> Always be "Linear"</value>
		virtual property System::String ^ Name { System::String^ get() { return "Linear"; }}
		
		///<summary> The linear only have 2 points</summary>
		///<value> Always be 2</value>
		virtual property int MultiPoint { int get() { return 2; }}
		
		///<summary>
		///Calculate the Interpolation Continuously
		///</summary>
		///<param name="start">The starting time</param>
		///<param name="stop">The ending time</param>
		///<param name="point">The control points</param>
		///<returns>Return the interpolated time series</returns>
		virtual array<NumType, 1> ^ Calculate(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^point) 
		{
			if (point->Length != 2)
				throw gcnew ArgumentException("The point is smaller  or larger than 2", "point");
			if (start >= stop)
				throw gcnew ArgumentException("Start Time must smaller than stop time");
			
			// dy/dx
			double coef = (point[1]->Value->ToDouble(nullptr)-point[0]->Value->ToDouble(nullptr))/(point[1]->time-point[0]->time);
			double y0 = point[0]->Value->ToDouble(nullptr);
			unsigned int x0 = point[0]->time;
			array<NumType, 1> ^result = gcnew array<NumType, 1>(stop-start);
			for (unsigned int i = start; i < stop; i++)
			{
				double r = y0 + coef*(i - x0);
				NumType tval;
				if (NumType::typeid == UInt32::typeid)
				{
					tval = (NumType)((Object^)Convert::ToUInt32(r));
				}
				else if (NumType::typeid == UInt16::typeid)
				{
					tval = (NumType)((Object^)Convert::ToUInt16(r));
				}
				else if (NumType::typeid == UInt64::typeid)
				{
					tval = (NumType)((Object^)Convert::ToUInt64(r));
				}
				else if (NumType::typeid == Byte::typeid)
				{
					tval = (NumType)((Object^)Convert::ToByte(r));
				}
				else if (NumType::typeid == Double::typeid)
				{
					tval = (NumType)((Object^)Convert::ToDouble(r));
				}
				else
				{
					throw gcnew ArgumentException("Type not supported");
				}
				result[i - start] = tval;
			}
			return result;
		}

		///<summary>Generate the Display Points</summary>
		///<param name="start">the begin time of display</param>
		///<param name="stop">the end time of display</param>
		///<param name="points">The control points in range</param>
		///<param name="num"> The number of points to be displayed</param>
		///<returns>The double array for display</returns>
		virtual array<double, 1> ^ CalculateDisp(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^points, int num)
		{
			if (points->Length != 2)
				throw gcnew ArgumentException("The point is smaller  or larger than 2", "point");
			if (start >= stop)
				throw gcnew ArgumentException("Start Time must smaller than stop time");
			double coef = (points[1]->RealValue - points[0]->RealValue) / (points[1]->time - points[0]->time);
			double y0 = points[0]->RealValue;
			unsigned int x0 = points[0]->time;
			if (num < 1)
			{
				return gcnew array<double, 1>(0);
			}
			array<double, 1> ^result = gcnew array<double, 1>(num);
			double step = ((double)(stop - start)) / num;
			for (int i = 0;i < num; i++)
			{
				double res = y0 + coef*(step*i); // Real
				result[i] = res;
			}
			return result;
		}
	};
};
