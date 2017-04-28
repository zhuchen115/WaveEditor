using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeSeriesShared;

namespace NXWaveIO
{
    public partial class FrmSPIConfig : /*TimeSeriesShared.WaveIOConfigForm*/ Form
    {
        SPIDriver drv = new SPIDriver();
        public FrmSPIConfig()
        {
            InitializeComponent();
        }

        WaveIOConfig _config = new WaveIOConfig();

        public WaveIOConfig Config
        {
            get
            {
                return _config;
            }
        }

        private void numClkDiv_ValueChanged(object sender, EventArgs e)
        {

            lbSPIFreq.Text = String.Format("{0}MHz", (60 / (numClkDiv.Value + 1)));
        }

        private void btnDevRefresh_Click(object sender, EventArgs e)
        {
            FTDeviceListInfoNode[] nodes = drv.GetDeviceList();
            if(nodes ==null)
            {
                cmbDevices.Items.Clear();
                return;
            }
            foreach(FTDeviceListInfoNode node in nodes)
            {
                cmbDevices.Items.Add(node.Description);
            }
        }

        private void btnSPIInit_Click(object sender, EventArgs e)
        {
            TimeSeriesShared.WaveIOConfig cfg = drv.GetConfigs();
            if(cmbDevices.SelectedIndex>=0)
            {
                cfg.Config["devid"] = cmbDevices.SelectedIndex;
            }
            cfg.Config["clkdiv"] = (ushort)numClkDiv.Value;
        }
    }
}
