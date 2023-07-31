namespace EMC
{
    partial class FormEditPM
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
            this.dgvEditPM = new System.Windows.Forms.DataGridView();
            this.codeMdk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleMdk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditPM)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEditPM
            // 
            this.dgvEditPM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEditPM.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvEditPM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditPM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeMdk,
            this.titleMdk});
            this.dgvEditPM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEditPM.Location = new System.Drawing.Point(0, 0);
            this.dgvEditPM.Name = "dgvEditPM";
            this.dgvEditPM.Size = new System.Drawing.Size(734, 310);
            this.dgvEditPM.TabIndex = 0;
            // 
            // codeMdk
            // 
            this.codeMdk.HeaderText = "Код";
            this.codeMdk.Name = "codeMdk";
            this.codeMdk.Width = 64;
            // 
            // titleMdk
            // 
            this.titleMdk.HeaderText = "Наименование МДК";
            this.titleMdk.Name = "titleMdk";
            this.titleMdk.Width = 180;
            // 
            // FormEditPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 310);
            this.Controls.Add(this.dgvEditPM);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormEditPM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditPM_FormClosing);
            this.Load += new System.EventHandler(this.FormEditPM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditPM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEditPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeMdk;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleMdk;
    }
}