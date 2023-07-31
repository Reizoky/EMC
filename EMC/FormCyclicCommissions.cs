using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EMC
{
    public partial class FormCyclicCommissions : Form
    {
        //string file1 = EMC.Properties.Resources.CyclicCommissions;
        string[] file = File.ReadAllLines("Data//CyclicCommissions.csv", Encoding.UTF8);
        public FormCyclicCommissions()
        {
            InitializeComponent();
        }

        private void FormCyclicCommissions_Load(object sender, EventArgs e)
        {
            string[] commission;
            for (int i = 0; i < file.Count(); i++)
            {
                commission = file[i].Split(';');

                dgvCyclicCommissions.Rows.Add();
                dgvCyclicCommissions.Rows[i].Cells[0].Value = commission[0];
                dgvCyclicCommissions.Rows[i].Cells[1].Value = commission[1];
            }
        }

        private void FormCyclicCommissions_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = new FileStream("Data//CyclicCommissions.csv", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);
            try
            {
                for (int i = 0; i < dgvCyclicCommissions.Rows.Count - 1; i++)
                {
                    streamWriter.Write(string.Format("{0};{1}", dgvCyclicCommissions.Rows[i].Cells[0].Value,
                dgvCyclicCommissions.Rows[i].Cells[1].Value));
                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении файла!");
            }
        }
    }
}
