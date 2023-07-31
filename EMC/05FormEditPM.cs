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
    public partial class FormEditPM : Form
    {
        DataGridView nameMDK;
        public FormEditPM(ref DataGridView mdk)
        {
            InitializeComponent();
            nameMDK = mdk;
        }

        private void FormEditPM_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(nameMDK.Count.ToString());
            //MessageBox.Show(nameMDK[0].ToString());
            //for (int i = 0; i < nameMDK.RowCount; i++)
            //{
            //    dgvEditPM.Rows[i].Cells[0].Value = nameMDK.Rows[i].Cells[0].Value;
            //    dgvEditPM.Rows[i].Cells[1].Value = nameMDK.Rows[i].Cells[1].Value;
            //    dgvEditPM.Rows.Add();
            //}
        }

        private void FormEditPM_FormClosing(object sender, FormClosingEventArgs e)
        {
            //nameMDK.Rows.Clear();
            //for (int i = 0; i < dgvEditPM.Rows.Count - 1; i++)
            //{
            //    nameMDK.Rows[i].Cells[0].Value = dgvEditPM.Rows[i].Cells[0].Value;
            //    nameMDK.Rows[i].Cells[1].Value = dgvEditPM.Rows[i].Cells[1].Value;
            //    nameMDK.Rows.Add();
            //}
            //CallBackMy.callbackEventHandler(nameMDK);
        }
    }
}
