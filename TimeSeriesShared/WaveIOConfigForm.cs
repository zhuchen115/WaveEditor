using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSeriesShared
{
    public partial class WaveIOConfigForm : Form
    {
        public WaveIOConfig Config { get; set; }
        public WaveIOConfigForm()
        {
            InitializeComponent();
        }
    }
}
