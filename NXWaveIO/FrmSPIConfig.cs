using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NXWaveIO
{
    public partial class FrmSPIConfig : Form
    {
        public FrmSPIConfig()
        {
            InitializeComponent();
        }

        private void numClkDiv_ValueChanged(object sender, EventArgs e)
        {
            lbSPIFreq.Text = String.Format("{0}MHz", (60 / (numClkDiv.Value + 1)));
        }
    }
}
