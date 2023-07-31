namespace EMC
{
    partial class FormCelebrations
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
            this.tbCelebrations = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbCelebrations
            // 
            this.tbCelebrations.Location = new System.Drawing.Point(12, 12);
            this.tbCelebrations.Multiline = true;
            this.tbCelebrations.Name = "tbCelebrations";
            this.tbCelebrations.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbCelebrations.Size = new System.Drawing.Size(324, 371);
            this.tbCelebrations.TabIndex = 0;
            // 
            // FormCelebrations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 395);
            this.Controls.Add(this.tbCelebrations);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(364, 434);
            this.MinimumSize = new System.Drawing.Size(364, 434);
            this.Name = "FormCelebrations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Праздники и нерабочие дни";
            this.Load += new System.EventHandler(this.FormCelebrations_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCelebrations_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCelebrations;
    }
}