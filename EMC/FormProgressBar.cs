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
    public partial class FormProgressBar : Form
    {
        string nameProc;   

        public FormProgressBar(string proc)
        {
            InitializeComponent();
            nameProc = proc;
        }

        private void FormProgressBar_Load(object sender, EventArgs e)
        {
            lblNameProcess.Text = nameProc;

            //pbProcess.MarqueeAnimationSpeed = 100;
            timerMain.Start();
        }

        int timer = 1;
        private void timerMain_Tick(object sender, EventArgs e)
        {
            string time = NewTime();
            lblNameProcess.Text = nameProc + Environment.NewLine+"Прошло "+ time;
            timer++;
        }

        private string NewTime()
        { 
            return string.Format("{0}:{1:00}", timer / 60, timer % 60);
        }
    }
}
