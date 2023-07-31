namespace EMC
{
    partial class FormCyclicCommissions
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
            this.dgvCyclicCommissions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chairperson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCyclicCommissions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCyclicCommissions
            // 
            this.dgvCyclicCommissions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCyclicCommissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCyclicCommissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCommission,
            this.Chairperson});
            this.dgvCyclicCommissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCyclicCommissions.Location = new System.Drawing.Point(0, 0);
            this.dgvCyclicCommissions.Name = "dgvCyclicCommissions";
            this.dgvCyclicCommissions.Size = new System.Drawing.Size(900, 361);
            this.dgvCyclicCommissions.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Ниаменование цикловой комиссии";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Председатель комиссии";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // NameCommission
            // 
            this.NameCommission.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NameCommission.HeaderText = "Наименование цикловой комиссии";
            this.NameCommission.Name = "NameCommission";
            this.NameCommission.Width = 224;
            // 
            // Chairperson
            // 
            this.Chairperson.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Chairperson.HeaderText = "Председатель комиссии";
            this.Chairperson.Name = "Chairperson";
            this.Chairperson.Width = 213;
            // 
            // FormCyclicCommissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 361);
            this.Controls.Add(this.dgvCyclicCommissions);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormCyclicCommissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Цикловые комиссии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCyclicCommissions_FormClosing);
            this.Load += new System.EventHandler(this.FormCyclicCommissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCyclicCommissions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCyclicCommissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chairperson;
    }
}