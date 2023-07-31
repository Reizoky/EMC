namespace EMC
{
    partial class FormProgressBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.lblNameProcess = new System.Windows.Forms.Label();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pbProcess
            // 
            this.pbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProcess.Location = new System.Drawing.Point(-3, 46);
            this.pbProcess.MarqueeAnimationSpeed = 35;
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(416, 23);
            this.pbProcess.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbProcess.TabIndex = 0;
            // 
            // lblNameProcess
            // 
            this.lblNameProcess.AutoSize = true;
            this.lblNameProcess.Location = new System.Drawing.Point(25, 9);
            this.lblNameProcess.Name = "lblNameProcess";
            this.lblNameProcess.Size = new System.Drawing.Size(142, 16);
            this.lblNameProcess.TabIndex = 1;
            this.lblNameProcess.Text = "Название процесса";
            this.lblNameProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerMain
            // 
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // FormProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 77);
            this.ControlBox = false;
            this.Controls.Add(this.lblNameProcess);
            this.Controls.Add(this.pbProcess);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учебно-методический комплекс";
            this.Load += new System.EventHandler(this.FormProgressBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProcess;
        private System.Windows.Forms.Label lblNameProcess;
        private System.Windows.Forms.Timer timerMain;
    }
}