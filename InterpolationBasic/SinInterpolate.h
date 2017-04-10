#pragma once
#include "Stdafx.h"
#include <cmath>

#define M_PI 3.141592653589793238462643383279

using namespace System;
using namespace TimeSeriesShared;

namespace InterpolationBasic {
	generic <typename NumType>
		where NumType: IConvertible, IComparable, IEquatable<NumType>

			public ref class SinInterpolate : IInterpolate<NumType>
		{
		public:



			// Inherited via IInterpolate
			virtual property System::String ^ Name {
				String ^ get() {
					return "Sinusoidal";
				}
			};

			virtual property int MultiPoint {int get() { return 4; }};

			virtual array<NumType, 1> ^ Calculate(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^point)
			{
				if ((point->Length) < 2 || (point->Length) > 4)
					throw gcnew ArgumentException("The Sin Interoplate point must between 2 and 4");
				double w, a, b, phi;
				if (point->Length == 2 || point->Length == 3)
				{
					w = 2 * M_PI / (point[1]->time - point[0]->time);
					a = point[0]->Value->ToDouble(nullptr) / 2 - point[1]->Value->ToDouble(nullptr);
					b = a + point[1]->Value->ToDouble(nullptr);
					phi = -w*(point[0]->time);
				}
				else //len ==4
				{
					w = 2 * M_PI / (point[2]->time - point[1]->time);
					a = point[1]->Value->ToDouble(nullptr) / 2 - point[2]->Value->ToDouble(nullptr);
					b = a + point[2]->Value->ToDouble(nullptr);
					phi = -w*(point[1]->time);
				}
				array<NumType, 1> ^result = gcnew array<NumType, 1>(stop - start + 1);
				for (unsigned int i = start; i < stop; i++)
				{
					double r = a*cos(w*i + phi) + b;
					result[i - start] = (NumType)((System::Object^)r);
				}
				return result;
			}

			virtual array<double, 1> ^ CalculateDisp(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^points, int num)
			{
				if ((points->Length) < 2 || (points->Length) > 4)
					throw gcnew ArgumentException("The Sin Interoplate point must between 2 and 4");
				double w, a, b, phi;
				if (points->Length == 2 || points->Length == 3)
				{
					w = 2 * M_PI / (points[1]->time - points[0]->time);
					a = points[0]->RealValue / 2 - points[1]->RealValue;
					b = a + points[1]->RealValue;
					phi = -w*(points[0]->time);
				}
				else //len ==4
				{
					w = 2 * M_PI / (points[2]->time - points[1]->time);
					a = points[1]->RealValue / 2 - points[2]->RealValue;
					b = a + points[2]->RealValue;
					phi = -w*(points[1]->time);
				}
				array<double, 1> ^result = gcnew array<double, 1>(stop - start + 1);
				double step = ((double)(stop - start)) / num;
				for (int i = 0; i < num; i++)
				{
					double r = a*cos(w*(i*step + start) + phi) + b;
					result[i - start] = r;
				}
				return result;
			}

		};
};