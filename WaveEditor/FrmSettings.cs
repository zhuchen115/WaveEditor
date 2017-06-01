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
    /// <summary>
    /// The setting forms for the Wave Editor
    /// </summary>
    public partial class FrmSettings : Form
    {
        /// <summary>
        /// Initialize the Setting Form
        /// </summary>
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void txtIntVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Properties.Settings.Default.DispNum = Int32.Parse(txtDisp.Text);
            Properties.Settings.Default.CacheNum = Int32.Parse(txtCache.Text);
            Properties.Settings.Default.YAxisName = txtYName.Text;
            Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            txtDisp.Text = Properties.Settings.Default.DispNum.ToString();
            txtCache.Text = Properties.Settings.Default.CacheNum.ToString();
            txtYName.Text = Properties.Settings.Default.YAxisName;
        }
    }
}
