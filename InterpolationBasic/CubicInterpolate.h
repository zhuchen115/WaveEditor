#pragma once
#include <cmath>
#include <cliext\vector>


using namespace System;

namespace InterpolationBasic {
	generic <typename NumType>
		where NumType: IConvertible, IComparable, IEquatable<NumType>
		public ref class CubicInterpolate :TimeSeriesShared::IInterpolate<NumType>
		{
		public:

			// ͨ�� IInterpolate �̳�
			virtual property System::String ^ Name { System::String^ get() { return "Spline"; }};

			virtual property int MultiPoint { int get() { return -1; }};

			virtual array<NumType, 1> ^ Calculate(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^point)
			{
				throw gcnew System::NotImplementedException();
				// TODO: �ڴ˴����� return ���
			}

			virtual array<double, 1> ^ CalculateDisp(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^points, int num, array<double, 1> ^range)
			{
				throw gcnew System::NotImplementedException();
				// TODO: �ڴ˴����� return ���
			}

		};

};