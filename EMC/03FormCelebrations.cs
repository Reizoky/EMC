using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EMC
{
    public partial class FormCelebrations : Form
    {
        string[] file = File.ReadAllLines("Celebrations.txt");

        public FormCelebrations()
        {
            InitializeComponent();
        }

        private void FormCelebrations_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < file.Count(); i++)
            {
                tbCelebrations.Text += file[i] + Environment.NewLine;
            }
        }

        private void FormCelebrations_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("Celebrations.txt", tbCelebrations.Text);
        }
    }
}
