#include "Stdafx.h"
#include "spline.h"

namespace InterpolationBasic {

	band_matrix::band_matrix(int dim, int n_u, int n_l)
	{
		resize(dim, n_u, n_l);
	}

	void band_matrix::resize(int dim, int n_u, int n_l)
	{
		assert(dim>0);
		assert(n_u >= 0);
		assert(n_l >= 0);
		m_upper.resize(n_u + 1);
		m_lower.resize(n_l + 1);
		for (int i = 0; i<m_upper.size(); i++) {
			m_upper[i].resize(dim);
		}
		for (int i = 0; i<m_lower.size(); i++) {
			m_lower[i].resize(dim);
		}
	}
	int band_matrix::dim()
	{
		if (m_upper.size()>0) {
			return m_upper[0].size();
		}
		else {
			return 0;
		}
	}
	void band_matrix::lu_decompose()
	{
		int  i_max, j_max;
		int  j_min;
		double x;

		// preconditioning
		// normalize column i so that a_ii=1
		for (int i = 0; i<this->dim(); i++) {
			assert((this->default[i, i]) != 0.0);
			this->saved_diag[i] = 1.0 / this->default[i, i];
			j_min = cliext::max(0, i - this->num_lower());
			j_max = cliext::min(this->dim() - 1, i + this->num_upper());
			for (int j = j_min; j <= j_max; j++) {
				this->default[i, j] *= this->saved_diag[i];
			}
			this->default[i, i] = 1.0;          // prevents rounding errors
		}

		// Gauss LR-Decomposition
		for (int k = 0; k<this->dim(); k++) {
			i_max = cliext::min(this->dim() - 1, k + this->num_lower());  // num_lower not a mistake!
			for (int i = k + 1; i <= i_max; i++) {
				assert((this->default[k, k]) != 0.0);
				x = -this->default[i, k] / this->default[k, k];
				this->default[i, k] = -x;                         // assembly part of L
				j_max = cliext::min(this->dim() - 1, k + this->num_upper());
				for (int j = k + 1; j <= j_max; j++) {
					// assembly part of R
					this->default[i, j] = this->default[i, j] + x*this->default[k, j];
				}
			}
		}
	}
	cliext::vector<double> band_matrix::l_solve(cliext::vector<double>% b)
	{
		assert(this->dim() == (int)b.size());
		cliext::vector<double> x(this->dim());
		int j_start;
		double sum;
		for (int i = 0; i<this->dim(); i++) {
			sum = 0;
			j_start = cliext::max(0, i - this->num_lower());
			for (int j = j_start; j<i; j++) sum += this->default[i, j] * x[j];
			x[i] = (b[i] * this->saved_diag[i]) - sum;
		}
		return x;
	}
	// solves Rx=y
	cliext::vector<double> band_matrix::r_solve(cliext::vector<double> %b)
	{
		assert(this->dim() == (int)b.size());
		cliext::vector<double> x(this->dim());
		int j_stop;
		double sum;
		for (int i = this->dim() - 1; i >= 0; i--) {
			sum = 0;
			j_stop = cliext::min(this->dim() - 1, i + this->num_upper());
			for (int j = i + 1; j <= j_stop; j++) sum += this->default[i, j] * x[j];
			x[i] = (b[i] - sum) / this->default[i, i];
		}
		return x;
	}

	cliext::vector<double> band_matrix::lu_solve(cliext::vector<double> %b,
		bool is_lu_decomposed)
	{
		assert(this->dim() == (int)b.size());
		cliext::vector<double>  x, y;
		if (is_lu_decomposed == false) {
			this->lu_decompose();
		}
		y = this->l_solve(b);
		x = this->r_solve(y);
		return x;
	}

	void spline::set_boundary(spline::bd_type left, double left_value,
		spline::bd_type right, double right_value,
		bool force_linear_extrapolation)
	{
		assert(m_x.size() == 0);          // set_points() must not have happened yet
		m_left = left;
		m_right = right;
		m_left_value = left_value;
		m_right_value = right_value;
		m_force_linear_extrapolation = force_linear_extrapolation;
	}

	void spline::set_points(cliext::vector<double>% x, cliext::vector<double>% y, bool cubic_spline)
	{
		assert(x.size() == y.size());
		assert(x.size()>2);
		m_x = x;
		m_y = y;
		int   n = x.size();
		// TODO: maybe sort x and y, rather than returning an error
		for (int i = 0; i<n - 1; i++) {
			assert(m_x[i]<m_x[i + 1]);
		}

		if (cubic_spline == true) { // cubic spline interpolation
									// setting up the matrix and right hand side of the equation system
									// for the parameters b[]
			band_matrix A(n, 1, 1);
			cliext::vector<double>  rhs(n);
			for (int i = 1; i<n - 1; i++) {
				A[i, i - 1] = 1.0 / 3.0*(x[i] - x[i - 1]);
				A[i, i] = 2.0 / 3.0*(x[i + 1] - x[i - 1]);
				A[i, i + 1] = 1.0 / 3.0*(x[i + 1] - x[i]);
				rhs[i] = (y[i + 1] - y[i]) / (x[i + 1] - x[i]) - (y[i] - y[i - 1]) / (x[i] - x[i - 1]);
			}
			// boundary conditions
			if (m_left == spline::bd_type::second_deriv) {
				// 2*b[0] = f''
				A[0, 0] = 2.0;
				A[0, 1] = 0.0;
				rhs[0] = m_left_value;
			}
			else if (m_left == spline::bd_type::first_deriv) {
				// c[0] = f', needs to be re-expressed in terms of b:
				// (2b[0]+b[1])(x[1]-x[0]) = 3 ((y[1]-y[0])/(x[1]-x[0]) - f')
				A[0, 0] = 2.0*(x[1] - x[0]);
				A[0, 1] = 1.0*(x[1] - x[0]);
				rhs[0] = 3.0*((y[1] - y[0]) / (x[1] - x[0]) - m_left_value);
			}
			else {
				assert(false);
			}
			if (m_right == spline::bd_type::second_deriv) {
				// 2*b[n-1] = f''
				A[n - 1, n - 1] = 2.0;
				A[n - 1, n - 2] = 0.0;
				rhs[n - 1] = m_right_value;
			}
			else if (m_right == spline::bd_type::first_deriv) {
				// c[n-1] = f', needs to be re-expressed in terms of b:
				// (b[n-2]+2b[n-1])(x[n-1]-x[n-2])
				// = 3 (f' - (y[n-1]-y[n-2])/(x[n-1]-x[n-2]))
				A[n - 1, n - 1] = 2.0*(x[n - 1] - x[n - 2]);
				A[n - 1, n - 2] = 1.0*(x[n - 1] - x[n - 2]);
				rhs[n - 1] = 3.0*(m_right_value - (y[n - 1] - y[n - 2]) / (x[n - 1] - x[n - 2]));
			}
			else {
				assert(false);
			}

			// solve the equation system to obtain the parameters b[]
			m_b = A.lu_solve(rhs);

			// calculate parameters a[] and c[] based on b[]
			m_a.resize(n);
			m_c.resize(n);
			for (int i = 0; i<n - 1; i++) {
				m_a[i] = 1.0 / 3.0*(m_b[i + 1] - m_b[i]) / (x[i + 1] - x[i]);
				m_c[i] = (y[i + 1] - y[i]) / (x[i + 1] - x[i])
					- 1.0 / 3.0*(2.0*m_b[i] + m_b[i + 1])*(x[i + 1] - x[i]);
			}
		}
		else { // linear interpolation
			m_a.resize(n);
			m_b.resize(n);
			m_c.resize(n);
			for (int i = 0; i<n - 1; i++) {
				m_a[i] = 0.0;
				m_b[i] = 0.0;
				m_c[i] = (m_y[i + 1] - m_y[i]) / (m_x[i + 1] - m_x[i]);
			}
		}

		// for left extrapolation coefficients
		m_b0 = (m_force_linear_extrapolation == false) ? m_b[0] : 0.0;
		m_c0 = m_c[0];

		// for the right extrapolation coefficients
		// f_{n-1}(x) = b*(x-x_{n-1})^2 + c*(x-x_{n-1}) + y_{n-1}
		double h = x[n - 1] - x[n - 2];
		// m_b[n-1] is determined by the boundary condition
		m_a[n - 1] = 0.0;
		m_c[n - 1] = 3.0*m_a[n - 2] * h*h + 2.0*m_b[n - 2] * h + m_c[n - 2];   // = f'_{n-2}(x_{n-1})
		if (m_force_linear_extrapolation == true)
			m_b[n - 1] = 0.0;
	}
	double spline::deriv(int order, double x)
	{
		assert(order>0);

		size_t n = m_x.size();
		// find the closest point m_x[idx] < x, idx=0 even if x<m_x[0]
		cliext::vector<double>::const_iterator it;
		it = cliext::lower_bound(m_x.begin(), m_x.end(), x);
		int idx = cliext::max(int(it - m_x.begin()) - 1, 0);

		double h = x - m_x[idx];
		double interpol;
		if (x<m_x[0]) {
			// extrapolation to the left
			switch (order) {
			case 1:
				interpol = 2.0*m_b0*h + m_c0;
				break;
			case 2:
				interpol = 2.0*m_b0*h;
				break;
			default:
				interpol = 0.0;
				break;
			}
		}
		else if (x>m_x[(int)n - 1]) {
			// extrapolation to the right
			switch (order) {
			case 1:
				interpol = 2.0*m_b[(int)n - 1] * h + m_c[(int)n - 1];
				break;
			case 2:
				interpol = 2.0*m_b[(int)n - 1];
				break;
			default:
				interpol = 0.0;
				break;
			}
		}
		else {
			// interpolation
			switch (order) {
			case 1:
				interpol = (3.0*m_a[idx] * h + 2.0*m_b[idx])*h + m_c[idx];
				break;
			case 2:
				interpol = 6.0*m_a[idx] * h + 2.0*m_b[idx];
				break;
			case 3:
				interpol = 6.0*m_a[idx];
				break;
			default:
				interpol = 0.0;
				break;
			}
		}
		return interpol;
	}

};