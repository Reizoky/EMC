namespace EMC
{
    partial class FormCTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCTP));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbLoadThemes = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveCTP = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCelebrations = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbUp = new System.Windows.Forms.ToolStripButton();
            this.tsbDown = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsplSave = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbSave = new System.Windows.Forms.ToolStripProgressBar();
            this.dsCTP = new EMC.ds();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlan = new System.Windows.Forms.DataGridView();
            this.TitleTheme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelfStudy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisualAids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tasks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsCTP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadThemes,
            this.tsbSaveCTP});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1092, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbLoadThemes
            // 
            this.tsbLoadThemes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLoadThemes.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsbLoadThemes.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadThemes.Image")));
            this.tsbLoadThemes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadThemes.Name = "tsbLoadThemes";
            this.tsbLoadThemes.Size = new System.Drawing.Size(131, 22);
            this.tsbLoadThemes.Text = "Загрузить темы";
            this.tsbLoadThemes.Click += new System.EventHandler(this.tsbLoadThemes_Click);
            // 
            // tsbSaveCTP
            // 
            this.tsbSaveCTP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSaveCTP.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsbSaveCTP.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveCTP.Image")));
            this.tsbSaveCTP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveCTP.Name = "tsbSaveCTP";
            this.tsbSaveCTP.Size = new System.Drawing.Size(129, 22);
            this.tsbSaveCTP.Text = "Сохранить КТП";
            this.tsbSaveCTP.Click += new System.EventHandler(this.tsbSaveCTP_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddGroup,
            this.toolStripSeparator1,
            this.tsbCelebrations});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1092, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddGroup
            // 
            this.tsbAddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddGroup.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsbAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddGroup.Image")));
            this.tsbAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddGroup.Name = "tsbAddGroup";
            this.tsbAddGroup.Size = new System.Drawing.Size(136, 22);
            this.tsbAddGroup.Text = "Настройка группы";
            this.tsbAddGroup.Click += new System.EventHandler(this.tsbAddGroup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCelebrations
            // 
            this.tsbCelebrations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCelebrations.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsbCelebrations.Image = ((System.Drawing.Image)(resources.GetObject("tsbCelebrations.Image")));
            this.tsbCelebrations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCelebrations.Name = "tsbCelebrations";
            this.tsbCelebrations.Size = new System.Drawing.Size(84, 22);
            this.tsbCelebrations.Text = "Праздники";
            this.tsbCelebrations.Click += new System.EventHandler(this.tsbCelebrations_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUp,
            this.tsbDown});
            this.toolStrip3.Location = new System.Drawing.Point(0, 50);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(24, 538);
            this.toolStrip3.TabIndex = 3;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsbUp
            // 
            this.tsbUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUp.Image = global::EMC.Properties.Resources.up;
            this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUp.Name = "tsbUp";
            this.tsbUp.Size = new System.Drawing.Size(21, 20);
            this.tsbUp.Text = "toolStripButton1";
            this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
            // 
            // tsbDown
            // 
            this.tsbDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDown.Image = global::EMC.Properties.Resources.down;
            this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDown.Name = "tsbDown";
            this.tsbDown.Size = new System.Drawing.Size(21, 20);
            this.tsbDown.Text = "toolStripButton2";
            this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsplSave,
            this.tspbSave});
            this.statusStrip1.Location = new System.Drawing.Point(24, 566);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1068, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsplSave
            // 
            this.tsplSave.Name = "tsplSave";
            this.tsplSave.Size = new System.Drawing.Size(0, 17);
            // 
            // tspbSave
            // 
            this.tspbSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tspbSave.Maximum = 0;
            this.tspbSave.Name = "tspbSave";
            this.tspbSave.Size = new System.Drawing.Size(150, 16);
            this.tspbSave.Visible = false;
            // 
            // dsCTP
            // 
            this.dsCTP.DataSetName = "ds";
            this.dsCTP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.FillWeight = 657.868F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Наименование разделов и тем";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 108;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 500;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.FillWeight = 20.30457F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Количество аудиторных часов";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 72;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.FillWeight = 20.30457F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Количество часов самостоятельно";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 95;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.FillWeight = 20.30457F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Наглядные пособия";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 91;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.FillWeight = 20.30457F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Задания для студентов";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 91;
            // 
            // dgvPlan
            // 
            this.dgvPlan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlan.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleTheme,
            this.NumberOfHours,
            this.SelfStudy,
            this.VisualAids,
            this.Tasks});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlan.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlan.GridColor = System.Drawing.SystemColors.Control;
            this.dgvPlan.Location = new System.Drawing.Point(24, 50);
            this.dgvPlan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPlan.Name = "dgvPlan";
            this.dgvPlan.Size = new System.Drawing.Size(1068, 516);
            this.dgvPlan.TabIndex = 7;
            this.dgvPlan.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlan_CellMouseEnter);
            this.dgvPlan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlan_CellValueChanged);
            this.dgvPlan.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPlan_RowsRemoved);
            // 
            // TitleTheme
            // 
            this.TitleTheme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.TitleTheme.DefaultCellStyle = dataGridViewCellStyle1;
            this.TitleTheme.FillWeight = 657.868F;
            this.TitleTheme.HeaderText = "Наименование разделов и тем";
            this.TitleTheme.MinimumWidth = 108;
            this.TitleTheme.Name = "TitleTheme";
            this.TitleTheme.Width = 500;
            // 
            // NumberOfHours
            // 
            this.NumberOfHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.NumberOfHours.DefaultCellStyle = dataGridViewCellStyle2;
            this.NumberOfHours.FillWeight = 20.30457F;
            this.NumberOfHours.HeaderText = "Количество аудиторных часов";
            this.NumberOfHours.Name = "NumberOfHours";
            this.NumberOfHours.Width = 72;
            // 
            // SelfStudy
            // 
            this.SelfStudy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.SelfStudy.DefaultCellStyle = dataGridViewCellStyle3;
            this.SelfStudy.FillWeight = 20.30457F;
            this.SelfStudy.HeaderText = "Количество часов самостоятельно";
            this.SelfStudy.Name = "SelfStudy";
            this.SelfStudy.Width = 95;
            // 
            // VisualAids
            // 
            this.VisualAids.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.VisualAids.DefaultCellStyle = dataGridViewCellStyle4;
            this.VisualAids.FillWeight = 20.30457F;
            this.VisualAids.HeaderText = "Наглядные пособия";
            this.VisualAids.Name = "VisualAids";
            this.VisualAids.Width = 91;
            // 
            // Tasks
            // 
            this.Tasks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Tasks.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tasks.FillWeight = 20.30457F;
            this.Tasks.HeaderText = "Задания для студентов";
            this.Tasks.Name = "Tasks";
            this.Tasks.Width = 91;
            // 
            // FormCTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 588);
            this.Controls.Add(this.dgvPlan);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(564, 538);
            this.Name = "FormCTP";
            this.Text = "Календарно-тематический план";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCTP_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsCTP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbLoadThemes;
        private System.Windows.Forms.ToolStripButton tsbSaveCTP;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbCelebrations;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbUp;
        private System.Windows.Forms.ToolStripButton tsbDown;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tspbSave;
        private System.Windows.Forms.ToolStripStatusLabel tsplSave;
        private ds dsCTP;
        private System.Windows.Forms.DataGridView dgvPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleTheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelfStudy;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisualAids;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tasks;
    }
}

