#pragma once

#include <cliext\algorithm>
#include <cliext\vector>
#include <cassert>
#include <cstdio>

/* The managed (cliextend) spline library */

namespace InterpolationBasic {
	ref class band_matrix
	{
	private:
		cliext::vector< cliext::vector<double> > m_upper;  // upper band
		cliext::vector< cliext::vector<double> > m_lower;  // lower band
	public:
		band_matrix() {};                             // constructor
		band_matrix(int dim, int n_u, int n_l);       // constructor
		~band_matrix() {};                            // destructor
		void resize(int dim, int n_u, int n_l);      // init with dim,n_u,n_l
		int dim();                             // matrix dimension
		int num_upper()
		{
			return m_upper.size() - 1;
		}
		int num_lower()
		{
			return m_lower.size() - 1;
		}
		
		/*double& saved_diag(int i);
		double  saved_diag(int i) const;*/
		property double default[int, int]
		{ 
			double get(int i,int j)
			{
			int k = j - i;       // what band is the entry
			assert((i >= 0) && (i<dim()) && (j >= 0) && (j<dim()));
			assert((-num_lower() <= k) && (k <= num_upper()));
			// k=0 -> diogonal, k<0 lower left part, k>0 upper right part
			
			if (k >= 0) { 
				cliext::vector<double> t = m_upper[k];
				return t[i]; 
			}
			else { 
				cliext::vector<double> t = m_lower[-k];
				return t[i]; 
				}
			}
			void set(int i, int j, double value)
			{
				int k = j - i;       // what band is the entry
				assert((i >= 0) && (i<dim()) && (j >= 0) && (j<dim()));
				assert((-num_lower() <= k) && (k <= num_upper()));
				// k=0 -> diogonal, k<0 lower left part, k>0 upper right part
				if (k >= 0) {
					cliext::vector<double> ^t = %m_upper[k];
					t[i] = value;
				}   
				else 
				{
					cliext::vector<double> ^t = %m_lower[-k];
					t[i] = value;
				}
			} 
		
		}
		property double saved_diag[int]
		{
			double get(int i) {
			assert((i >= 0) && (i<dim()));
			cliext::vector<double> t = m_lower[0];
			return t[i];
			}
			void set(int i, double value) 
			{
				assert((i >= 0) && (i<dim()));
				cliext::vector<double>^ t = %m_lower[0];
				t[i] = value;;
			}
		}
		void lu_decompose();
		cliext::vector<double> r_solve(cliext::vector<double> %b);
		cliext::vector<double> l_solve( cliext::vector<double> %b);
		cliext::vector<double> lu_solve(cliext::vector<double> %b, bool is_lu_decomposed);
		cliext::vector<double> lu_solve(cliext::vector<double> %b) { this->lu_solve(b, false); }
	};


	// spline interpolation
ref class spline
	{
	public:
		enum bd_type {
			first_deriv = 1,
			second_deriv = 2
		};

	private:
		cliext::vector<double> m_x, m_y;            // x,y coordinates of points
												 // interpolation parameters
												 // f(x) = a*(x-x_i)^3 + b*(x-x_i)^2 + c*(x-x_i) + y_i
		cliext::vector<double> m_a, m_b, m_c;        // spline coefficients
		double  m_b0, m_c0;                     // for left extrapol
		bd_type m_left, m_right;
		double  m_left_value, m_right_value;
		bool    m_force_linear_extrapolation;

	public:
		// set default boundary condition to be zero curvature at both ends
		spline() : m_left(second_deriv), m_right(second_deriv),
			m_left_value(0.0), m_right_value(0.0),
			m_force_linear_extrapolation(false)
		{
			;
		}

		// optional, but if called it has to come be before set_points()
		void set_boundary(bd_type left, double left_value,
			bd_type right, double right_value,
			bool force_linear_extrapolation);
		void set_boundary(bd_type left, double left_value,
			bd_type right, double right_value) 
		{
			this->set_boundary(left, left_value, right, right_value, false);
		}
		void set_points(cliext::vector<double>% x, cliext::vector<double>% y, bool cubic_spline);
		void set_points(cliext::vector<double>% x, cliext::vector<double>% y) {
			this->set_points(x, y, true);
		}
		property double default [double]{ 
			double get(double x) {
			size_t n = m_x.size();
			// find the closest point m_x[idx] < x, idx=0 even if x<m_x[0]
			cliext::vector<double>::const_iterator it;
			it = cliext::lower_bound(m_x.begin(),m_x.end(),x);
			int idx = cliext::max(int(it - m_x.begin()) - 1, 0);

			double h = x - m_x[idx];
			double interpol;
			if (x<m_x[0]) {
				// extrapolation to the left
				interpol = (m_b0*h + m_c0)*h + m_y[0];
			}
			else if (x>m_x[n - 1]) {
				// extrapolation to the right
				interpol = (m_b[n - 1] * h + m_c[n - 1])*h + m_y[n - 1];
			}
			else {
				// interpolation
				interpol = ((m_a[idx] * h + m_b[idx])*h + m_c[idx])*h + m_y[idx];
			}
			return interpol;
		} };
		double deriv(int order, double x) ;
	};




};

