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
    public partial class WaitingStatus : Form
    {
        public WaitingStatus()
        {
            InitializeComponent();
        }

        private void WaitingStatus_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
