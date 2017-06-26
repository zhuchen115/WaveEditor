#pragma once
#pragma warning( disable: 4484)
#include <cmath>
#include <vector>
#include "Stdafx.h"
#include "spline2.h"
#pragma warning( default: 4484)

using namespace System;
using namespace TimeSeriesShared;

namespace InterpolationBasic {

	/// <summary> Spline Interpolation Class</summary>
	/// <typeparam name="NumType"> A Numeric Type</typeparam>  
	/// <remarks>This class using native code for interpolation</remarks>
	/// <seealso>https://docs.microsoft.com/en-us/cpp/dotnet/mixed-native-and-managed-assemblies </seealso>
	generic <typename NumType>
		where NumType: IConvertible, IComparable, IEquatable<NumType>
	public ref class SplineInterpolate : IInterpolate<NumType>
	{
		public:
			
			///<summary> The name of the Interpolation Method </summary>
			///<value> Always "spline"</value>
			virtual property System::String ^ Name { System::String^ get() { return "Spline"; }};

			///<summary> The Spline MultiPoints are disabled </summary>
			///<value> Always -1</value>
			virtual property int MultiPoint { int get() { return -1; }};
			
			///<summary>
			///Calculate the Interpolation Continuously
			///</summary>
			///<param name="start">The starting time</param>
			///<param name="stop">The ending time</param>
			///<param name="point">The control points</param>
			///<returns>Return the interpolated time series</returns>
			virtual array<NumType, 1> ^ Calculate(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^point)
			{
				//Begin Time Check
				if (start >= stop)
					throw gcnew ArgumentException("Start Time must smaller than stop time");
				// Std Vector 
				std::vector<double> x, y;
				for (int i = 0; i < point->Length; i++)
				{
					x.push_back((double)(point[i]->time));
					y.push_back(point[i]->Value->ToDouble(nullptr));
				}
				spline s;
				s.set_points(x, y);
				System::Collections::Generic::List<NumType>^ rslt = gcnew System::Collections::Generic::List<NumType>();
				for (unsigned int i = start; i < stop; i++)
				{
					double r =s(i);
					NumType tval;
					if (NumType::typeid == UInt32::typeid)
					{
						tval =(NumType)((Object^)Convert::ToUInt32(r));
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
					rslt->Add(tval);
				}
				return rslt->ToArray();
				
			}

			
			
			///<summary>Generate the Display Points</summary>
			///<param name="start">the begin time of display</param>
			///<param name="stop">the end time of display</param>
			///<param name="points">The control points in range</param>
			///<param name="num"> The number of points to be displayed</param>
			///<returns>The double array for display</returns>
			virtual array<double, 1> ^ CalculateDisp(unsigned int start, unsigned int stop, array<TimeSeriesShared::SamplePoint<NumType> ^, 1> ^points, int num)
			{
				if (start >= stop)
					throw gcnew ArgumentException("Start Time must smaller than stop time");
				if (points->Length < 3)
					throw gcnew ArgumentException("The spline need at least 3 points");
				std::vector<double> x, y;
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
					rslt->Add(std::round(s(i*step+start)));
				}
				return rslt->ToArray();
			}

		};

};