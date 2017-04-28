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
    public partial class FrmSPIConfig : Form,IWaveIOConfigForm
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
            double freq = 60 / (((double)numClkDiv.Value + 1) * 2);
            if(freq>1)
                lbSPIFreq.Text = String.Format("{0}MHz", freq);
            else
                lbSPIFreq.Text = String.Format("{0}KHz", freq*1000);

        }

        private void btnDevRefresh_Click(object sender, EventArgs e)
        {
            nodes = drv.GetDeviceList();
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
            _config = drv.GetConfigs();
            if(cmbDevices.SelectedIndex>=0)
            {
                _config.Config["devid"] = cmbDevices.SelectedIndex;
            }
            _config.Config["clkdiv"] = (ushort)numClkDiv.Value;
            _config.Config["lendian"] = chkSPILittleEnd.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _config.Config["clkdiv"] = (ushort)numClkDiv.Value;
            _config.Config["lendian"] = chkSPILittleEnd.Checked;
            _config.Config["devid"] = cmbDevices.SelectedIndex;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        FTDeviceListInfoNode[] nodes = null;


        private void FrmSPIConfig_Load(object sender, EventArgs e)
        {
            tabOutput.Parent = null;
            try
            {
                nodes = drv.GetDeviceList();
            }catch(Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "FT Driver failure", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                switch(result)
                {
                    case DialogResult.Abort:
                        DialogResult = DialogResult.Cancel;
                        Close();
                        return;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Retry:
                        try
                        {
                            nodes = drv.GetDeviceList();
                        }
                        catch
                        {
                            MessageBox.Show("Failure");
                            return;
                        }
                        break;
                }
            }
            if (nodes == null)
            {
                cmbDevices.Items.Clear();
                return;
            }
            foreach (FTDeviceListInfoNode node in nodes)
            {
                cmbDevices.Items.Add(node.Description);
            }
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedIndex < 0 || cmbDevices.SelectedIndex > nodes.Count() - 1)
            {

                return;
            }
            FTDeviceListInfoNode node = nodes[cmbDevices.SelectedIndex];
            lbGeOpened.Text = (node.Flags > 0).ToString();
            lbGeID.Text = (node.ID).ToString();
            lbGeLocID.Text = node.LocId.ToString();
            lbGeSN.Text = node.SerialNumber;
            lbGeDesc.Text = node.Description;
        }

        private void FrmSPIConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control&&e.Shift&&e.KeyCode==Keys.D)
            {
                if(MessageBox.Show("Entering Debug Mode, the part was not tested.","Debug Mode",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    tabOutput.Parent = tabConfig;
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            FTStatus status = FTStatus.OK;
            if(drv.ConnectTest(cmbDevices.SelectedIndex,ref status))
            {
                MessageBox.Show("OK", "Test Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(String.Format("Failure\n Library Returned: {0}"));
            }
        }

        private void chkSPILittleEnd_CheckedChanged(object sender, EventArgs e)
        {
            _config.Config["lendian"] = chkSPILittleEnd.Checked;
        }
    }
}
