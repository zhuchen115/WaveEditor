#pragma once
#pragma warning( disable: 4484)
#include <cmath>
#include <cliext\vector>
#include "Stdafx.h"
#include "spline.h"
#pragma warning( default: 4484)

using namespace System;
using namespace TimeSeriesShared;

namespace InterpolationBasic {

	generic <typename NumType>
		where NumType: IConvertible, IComparable, IEquatable<NumType>
	public ref class SplineInterpolate : IInterpolate<NumType>
	{
		public:

			virtual property System::String ^ Name { System::String^ get() { return "Spline"; }};

			virtual property int MultiPoint { int get() { return -1; }};

			virtual array<NumType, 1> ^ Calculate(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^point)
			{
				
				if (start >= stop)
					throw gcnew ArgumentException("Start Time must smaller than stop time");
				
				cliext::vector<double> x, y;
				for (int i = 0; i < point->Length; i++)
				{
					x.push_back((double)(point[i]->time));
					y.push_back((double)(point[i]->Value));
				}
				spline s;
				s.set_points(x, y);
				System::Collections::Generic::List<NumType>^ rslt = gcnew System::Collections::Generic::List<NumType>();
				for (unsigned int i = start; i < stop; i++)
				{
					rslt->Add((NumType)((System::Object^)s[i]));
				}
				return rslt->ToArray();
				
			}

			virtual array<double, 1> ^ CalculateDisp(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^points, int num)
			{
				if (start >= stop)
					throw gcnew ArgumentException("Start Time must smaller than stop time");
				cliext::vector<double> x, y;
				for (int i = 0; i < points->Length; i++)
				{
					x.push_back((double)(points[i]->time));
					y.push_back((double)(points[i]->RealValue));
				}
				spline s;
				s.set_points(x, y);
				System::Collections::Generic::List<double>^ rslt = gcnew System::Collections::Generic::List<double>();
				double step = ((double)stop - start) / num;
				for (int i = 0; i < num; i++)
				{
					rslt->Add(std::round(s[i*step+start]));
				}
				return rslt->ToArray();
			}

		};

};