using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveEditor
{
    public partial class FrmEditor : Form
    {
        public FrmEditor()
        {
            InitializeComponent();
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {

        }

        private void txtDoubleVal_TextChanged(object sender, EventArgs e)
        {
            TextBox txtDbVal = sender as TextBox;
            if (txtDbVal == null)
                throw new ArgumentException("Error Text Changed Event Sender");
            if (txtDbVal.Text == "")
                txtDbVal.Text = "0";
        }

        private void txtDoubleVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != '.')
                e.Handled = true;
        }

        private void numSampleR_ValueChanged(object sender, EventArgs e)
        {
            lbSampleTimeVal.Text = String.Format("{0:0.#####E-00000}", (1 / (double)numSampleR.Value));
        }
    }
}
