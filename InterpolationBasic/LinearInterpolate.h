// InterpolationBasic.h

#pragma once
#include <cmath>

using namespace System;
using namespace TimeSeriesShared;


namespace InterpolationBasic {
	
	generic <typename NumType>
		where NumType: IConvertible,IComparable,IEquatable<NumType>
	
	public ref class LinearInterpolate :IInterpolate<NumType>
	{
	public:
			// Í¨¹ý IInterpolate ¼Ì³Ð
		virtual property System::String ^ Name { System::String^ get() { return "Linear"; }}
		virtual property int MultiPoint { int get() { return 2; }}
		virtual array<NumType, 1> ^ Calculate(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^point) 
		{
			if (point->Length != 2)
				throw gcnew ArgumentException("The point is smaller  or larger than 2", "point");
			if (start >= stop)
				throw gcnew ArgumentException("Start Time must smaller than stop time");
			
			// dy/dx
			double coef = (point[1]->Value->ToDouble(nullptr)-point[0]->Value->ToDouble(nullptr))/(point[1]->time-point[0]->time);
			double y0 = (double)point[0]->Value;
			unsigned int x0 = point[0]->time;
			array<NumType, 1> ^result = gcnew array<NumType, 1>(stop-start+1);
			for (unsigned int i = start; i < stop; i++)
			{
				double r = y0 + coef*(i - x0);
				result[i - start] = (NumType)((System::Object^)r);
			}
			return result;
		}
		virtual array<double, 1> ^ CalculateDisp(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^points, int num)
		{
			if (points->Length != 2)
				throw gcnew ArgumentException("The point is smaller  or larger than 2", "point");
			if (start >= stop)
				throw gcnew ArgumentException("Start Time must smaller than stop time");
			double coef = (points[1]->RealValue - points[0]->RealValue) / (points[1]->time - points[0]->time);
			double y0 = points[0]->RealValue;
			unsigned int x0 = points[0]->time;
			double step = ((double)(stop - start)) / num;
			array<double, 1> ^result = gcnew array<double, 1>(num);
			for (int i = 0;i < num; i++)
			{
				double res = y0 + coef*(step*i); // Real
				result[i] = res;
			}
			return result;
		}
	};
};
