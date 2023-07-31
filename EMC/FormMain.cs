using System;
using System.Drawing;
using System.Windows.Forms;

namespace EMC
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void tsmiOpenOneFgos_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.InitialDirectory = @"\specialties";
                fd.Filter = "Документ Word 2007 (*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    OpenForm(new FormFGOS(true, fd.FileName));

                    btnSaveFGOS.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string nameOpenedFileFGOS = "";
        private void tsmiOpenAviFgos_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "XML|*.xml";

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    nameOpenedFileFGOS = fd.SafeFileName;
                    OpenForm(new FormFGOS(false, fd.FileName));

                    btnSaveFGOS.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenForm(Form frm)
        {

            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Name == frm.Name)
                {
                    if (childForm.Name == "FormFGOS")
                        childForm.Close();
                    else if (childForm.Name == "FormThemes")
                        childForm.Close();
                    else if (childForm.Name == "FormProgram")
                        childForm.Close();
                    else if (childForm.Name == "FormCTP")
                        childForm.Close();
                    else
                    {
                        childForm.Activate();
                        childForm.WindowState = FormWindowState.Maximized;
                        return;
                    }
                }
            }

            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmiSaveFgos_Click(object sender, EventArgs e)
        {
            if (UpdateEvent.save != null)
                UpdateEvent.save();
        }

        private void tsmiThemes_Click(object sender, EventArgs e)
        {
            OpenForm(new FormThemes());
        }

        private void tsmiProgram_Click(object sender, EventArgs e)
        {
            OpenForm(new FormProgram());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI;

            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    //Устанавливаем цвет дочерней формы таким же, как и у главной:
                    ctlMDI.BackColor = Color.White;
                }
                catch
                {
                    //Обработка ошибок.
                }
            }
           // this.BackColor = Color.White;
        }

        private void tsmiCTP_Click(object sender, EventArgs e)
        {
            OpenForm(new FormCTP());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frmNew = new frmSettings();
            frmNew.ShowDialog();
        }

        private void btnSaveRP_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                if (frm.Name == "FormThemes")
                {
                    ((FormThemes)(frm)).SaveThemes();
                    break;
                }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            frmInfo frmNew = new frmInfo();
            frmNew.ShowDialog();
        }
    }
}