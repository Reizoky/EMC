using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMC
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            nudTimeAutosave.Value = Properties.Settings.Default.timeAutoSave;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.timeAutoSave = Convert.ToInt32(nudTimeAutosave.Value);
            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}
