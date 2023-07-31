namespace EMC
{
    partial class FormGroups
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
            this.gbPractice = new System.Windows.Forms.GroupBox();
            this.btnDeletGroup = new System.Windows.Forms.Button();
            this.btnDeletPractice = new System.Windows.Forms.Button();
            this.cbPractice = new System.Windows.Forms.ComboBox();
            this.btnAddPractice = new System.Windows.Forms.Button();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.dtpPracticeFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPracticeSince = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.Monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGroup = new System.Windows.Forms.Button();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpSemesterFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpSemesterSince = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.gbPractice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPractice
            // 
            this.gbPractice.Controls.Add(this.btnDeletGroup);
            this.gbPractice.Controls.Add(this.btnDeletPractice);
            this.gbPractice.Controls.Add(this.cbPractice);
            this.gbPractice.Controls.Add(this.btnAddPractice);
            this.gbPractice.Controls.Add(this.cbGroup);
            this.gbPractice.Controls.Add(this.dtpPracticeFrom);
            this.gbPractice.Controls.Add(this.label2);
            this.gbPractice.Controls.Add(this.dtpPracticeSince);
            this.gbPractice.Controls.Add(this.label1);
            this.gbPractice.Location = new System.Drawing.Point(6, 50);
            this.gbPractice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPractice.Name = "gbPractice";
            this.gbPractice.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPractice.Size = new System.Drawing.Size(459, 131);
            this.gbPractice.TabIndex = 4;
            this.gbPractice.TabStop = false;
            this.gbPractice.Text = "Настройка группы";
            // 
            // btnDeletGroup
            // 
            this.btnDeletGroup.Location = new System.Drawing.Point(312, 24);
            this.btnDeletGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeletGroup.Name = "btnDeletGroup";
            this.btnDeletGroup.Size = new System.Drawing.Size(141, 24);
            this.btnDeletGroup.TabIndex = 12;
            this.btnDeletGroup.Text = "Удалить группу";
            this.btnDeletGroup.UseVisualStyleBackColor = true;
            this.btnDeletGroup.Click += new System.EventHandler(this.btnDeletGroup_Click);
            // 
            // btnDeletPractice
            // 
            this.btnDeletPractice.Location = new System.Drawing.Point(312, 101);
            this.btnDeletPractice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeletPractice.Name = "btnDeletPractice";
            this.btnDeletPractice.Size = new System.Drawing.Size(141, 24);
            this.btnDeletPractice.TabIndex = 10;
            this.btnDeletPractice.Text = "Удалить период";
            this.btnDeletPractice.UseVisualStyleBackColor = true;
            this.btnDeletPractice.Click += new System.EventHandler(this.btnDeletPractice_Click);
            // 
            // cbPractice
            // 
            this.cbPractice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPractice.FormattingEnabled = true;
            this.cbPractice.Location = new System.Drawing.Point(5, 101);
            this.cbPractice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPractice.Name = "cbPractice";
            this.cbPractice.Size = new System.Drawing.Size(299, 24);
            this.cbPractice.TabIndex = 9;
            // 
            // btnAddPractice
            // 
            this.btnAddPractice.Location = new System.Drawing.Point(312, 68);
            this.btnAddPractice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddPractice.Name = "btnAddPractice";
            this.btnAddPractice.Size = new System.Drawing.Size(141, 23);
            this.btnAddPractice.TabIndex = 8;
            this.btnAddPractice.Text = "Добавить период";
            this.btnAddPractice.UseVisualStyleBackColor = true;
            this.btnAddPractice.Click += new System.EventHandler(this.btnAddPractice_Click);
            // 
            // cbGroup
            // 
            this.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(6, 25);
            this.cbGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(298, 24);
            this.cbGroup.TabIndex = 7;
            this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.cbGroup_SelectedIndexChanged_1);
            // 
            // dtpPracticeFrom
            // 
            this.dtpPracticeFrom.Location = new System.Drawing.Point(162, 68);
            this.dtpPracticeFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpPracticeFrom.Name = "dtpPracticeFrom";
            this.dtpPracticeFrom.Size = new System.Drawing.Size(142, 23);
            this.dtpPracticeFrom.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Конец практики:";
            // 
            // dtpPracticeSince
            // 
            this.dtpPracticeSince.Location = new System.Drawing.Point(6, 68);
            this.dtpPracticeSince.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpPracticeSince.Name = "dtpPracticeSince";
            this.dtpPracticeSince.Size = new System.Drawing.Size(142, 23);
            this.dtpPracticeSince.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начало практики:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnGroup);
            this.groupBox1.Controls.Add(this.tbGroup);
            this.groupBox1.Controls.Add(this.gbPractice);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(473, 358);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSchedule);
            this.groupBox4.Location = new System.Drawing.Point(12, 189);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(447, 161);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "График";
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Friday,
            this.Saturday});
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.Location = new System.Drawing.Point(3, 20);
            this.dgvSchedule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.Size = new System.Drawing.Size(441, 137);
            this.dgvSchedule.TabIndex = 0;
            this.dgvSchedule.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellValueChanged);
            this.dgvSchedule.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSchedule_EditingControlShowing);
            // 
            // Monday
            // 
            this.Monday.HeaderText = "Пн.";
            this.Monday.Name = "Monday";
            this.Monday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Monday.ToolTipText = "Количество пар в день";
            // 
            // Tuesday
            // 
            this.Tuesday.HeaderText = "Вт.";
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Wednesday
            // 
            this.Wednesday.HeaderText = "Ср.";
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Thursday
            // 
            this.Thursday.HeaderText = "Чт.";
            this.Thursday.Name = "Thursday";
            this.Thursday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Friday
            // 
            this.Friday.HeaderText = "Пт.";
            this.Friday.Name = "Friday";
            this.Friday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Saturday
            // 
            this.Saturday.HeaderText = "Сб.";
            this.Saturday.Name = "Saturday";
            this.Saturday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Группа";
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(318, 19);
            this.btnGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(135, 25);
            this.btnGroup.TabIndex = 3;
            this.btnGroup.Text = "Добавить группу";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // tbGroup
            // 
            this.tbGroup.Location = new System.Drawing.Point(70, 19);
            this.tbGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(242, 23);
            this.tbGroup.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtpSemesterFrom);
            this.groupBox5.Controls.Add(this.dtpSemesterSince);
            this.groupBox5.Location = new System.Drawing.Point(12, 13);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(391, 48);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Начало и конец семестра";
            // 
            // dtpSemesterFrom
            // 
            this.dtpSemesterFrom.Location = new System.Drawing.Point(206, 17);
            this.dtpSemesterFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpSemesterFrom.Name = "dtpSemesterFrom";
            this.dtpSemesterFrom.Size = new System.Drawing.Size(176, 23);
            this.dtpSemesterFrom.TabIndex = 8;
            // 
            // dtpSemesterSince
            // 
            this.dtpSemesterSince.Location = new System.Drawing.Point(6, 17);
            this.dtpSemesterSince.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpSemesterSince.Name = "dtpSemesterSince";
            this.dtpSemesterSince.Size = new System.Drawing.Size(176, 23);
            this.dtpSemesterSince.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Пн.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Количество пар в день";
            this.dataGridViewTextBoxColumn1.Width = 66;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Вт.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.Width = 67;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Ср.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.Width = 66;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Чт.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 66;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Пт.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.Width = 67;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Сб.";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.Width = 66;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNote);
            this.groupBox2.Location = new System.Drawing.Point(12, 434);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 130);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Примечание";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(9, 19);
            this.lblNote.MinimumSize = new System.Drawing.Size(323, 96);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(323, 96);
            this.lblNote.TabIndex = 0;
            this.lblNote.Text = "Через знак \"/\" указывается наличие занятия:\r\n\"+\" - есть занятие\r\n\"-\" - нет заняти" +
    "я\r\n\"Л\" - Лабораторная работа\r\nчислитель - первая неделя\r\nзнаменатель - вторая не" +
    "деля";
            // 
            // FormGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 576);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка параметров групп";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGroups_FormClosing);
            this.Load += new System.EventHandler(this.FormGroups_Load);
            this.gbPractice.ResumeLayout(false);
            this.gbPractice.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPractice;
        private System.Windows.Forms.Button btnDeletGroup;
        private System.Windows.Forms.Button btnDeletPractice;
        private System.Windows.Forms.ComboBox cbPractice;
        private System.Windows.Forms.Button btnAddPractice;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.DateTimePicker dtpPracticeFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPracticeSince;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dtpSemesterFrom;
        private System.Windows.Forms.DateTimePicker dtpSemesterSince;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblNote;
    }
}