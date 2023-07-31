namespace EMC
{
    partial class FormProgram
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
            this.ds = new EMC.ds();
            this.dsFGOS = new EMC.dsFGOS();
            this.lblAllTreb = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnFGOS = new System.Windows.Forms.Button();
            this.nudRazdel = new System.Windows.Forms.NumericUpDown();
            this.lblFGOS = new System.Windows.Forms.Label();
            this.lblTheme = new System.Windows.Forms.Label();
            this.btnThemes = new System.Windows.Forms.Button();
            this.cbDiscipline = new System.Windows.Forms.ComboBox();
            this.lblIdDisc = new System.Windows.Forms.Label();
            this.tlpButtonsToWork = new System.Windows.Forms.TableLayoutPanel();
            this.btnKOSMDK = new System.Windows.Forms.Button();
            this.btnKOS = new System.Windows.Forms.Button();
            this.btnLab = new System.Windows.Forms.Button();
            this.btnKIM = new System.Windows.Forms.Button();
            this.btnPract = new System.Windows.Forms.Button();
            this.btnTests = new System.Windows.Forms.Button();
            this.btnDrawUpProgram = new System.Windows.Forms.Button();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.lblR_MDKName = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblR_MDK = new System.Windows.Forms.Label();
            this.tlpCiclComission = new System.Windows.Forms.TableLayoutPanel();
            this.lblNameCommission = new System.Windows.Forms.Label();
            this.lblChairperson = new System.Windows.Forms.Label();
            this.btnUpdateCommissions = new System.Windows.Forms.Button();
            this.tbChairperson = new System.Windows.Forms.TextBox();
            this.cbNameCommission = new System.Windows.Forms.ComboBox();
            this.gbRP = new System.Windows.Forms.GroupBox();
            this.tlpRP = new System.Windows.Forms.TableLayoutPanel();
            this.rbCompiled = new System.Windows.Forms.RadioButton();
            this.lblSumHours = new System.Windows.Forms.Label();
            this.lblMaxHours = new System.Windows.Forms.Label();
            this.nudYourselfHours = new System.Windows.Forms.NumericUpDown();
            this.lblAcademicHours = new System.Windows.Forms.Label();
            this.nudAcademicHours = new System.Windows.Forms.NumericUpDown();
            this.lblYourselfHours = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDeveloped = new System.Windows.Forms.RadioButton();
            this.chbExampleProg = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gpAutors = new System.Windows.Forms.GroupBox();
            this.dgvAuthors = new System.Windows.Forms.DataGridView();
            this.Authors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeachingPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbExperts = new System.Windows.Forms.GroupBox();
            this.dgvExperts = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpRBItems = new System.Windows.Forms.TableLayoutPanel();
            this.rbDisc = new System.Windows.Forms.RadioButton();
            this.rbPM = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFGOS)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRazdel)).BeginInit();
            this.tlpButtonsToWork.SuspendLayout();
            this.tlpCiclComission.SuspendLayout();
            this.gbRP.SuspendLayout();
            this.tlpRP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYourselfHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAcademicHours)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpAutors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthors)).BeginInit();
            this.gbExperts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExperts)).BeginInit();
            this.tlpRBItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // ds
            // 
            this.ds.DataSetName = "ds";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsFGOS
            // 
            this.dsFGOS.DataSetName = "dsFGOS";
            this.dsFGOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblAllTreb
            // 
            this.lblAllTreb.Name = "lblAllTreb";
            this.lblAllTreb.Size = new System.Drawing.Size(215, 17);
            this.lblAllTreb.Text = "Все\\Не все требования используются";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAllTreb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 728);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1275, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlpMain
            // 
            this.tlpMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.btnFGOS, 0, 0);
            this.tlpMain.Controls.Add(this.nudRazdel, 1, 3);
            this.tlpMain.Controls.Add(this.lblFGOS, 1, 0);
            this.tlpMain.Controls.Add(this.lblTheme, 1, 1);
            this.tlpMain.Controls.Add(this.btnThemes, 0, 1);
            this.tlpMain.Controls.Add(this.cbDiscipline, 2, 2);
            this.tlpMain.Controls.Add(this.lblIdDisc, 1, 2);
            this.tlpMain.Controls.Add(this.tlpButtonsToWork, 0, 6);
            this.tlpMain.Controls.Add(this.dtpYear, 1, 4);
            this.tlpMain.Controls.Add(this.lblR_MDKName, 2, 3);
            this.tlpMain.Controls.Add(this.lblYear, 0, 4);
            this.tlpMain.Controls.Add(this.lblR_MDK, 0, 3);
            this.tlpMain.Controls.Add(this.tlpCiclComission, 0, 7);
            this.tlpMain.Controls.Add(this.gbRP, 0, 5);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 0, 8);
            this.tlpMain.Controls.Add(this.tlpRBItems, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 9;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1275, 728);
            this.tlpMain.TabIndex = 2;
            // 
            // btnFGOS
            // 
            this.btnFGOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFGOS.Location = new System.Drawing.Point(5, 5);
            this.btnFGOS.Name = "btnFGOS";
            this.btnFGOS.Size = new System.Drawing.Size(174, 34);
            this.btnFGOS.TabIndex = 1;
            this.btnFGOS.Text = "Загрузить ФГОС";
            this.btnFGOS.UseVisualStyleBackColor = true;
            this.btnFGOS.Click += new System.EventHandler(this.btnFGOS_Click);
            // 
            // nudRazdel
            // 
            this.nudRazdel.Enabled = false;
            this.nudRazdel.Location = new System.Drawing.Point(187, 120);
            this.nudRazdel.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRazdel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRazdel.Name = "nudRazdel";
            this.nudRazdel.Size = new System.Drawing.Size(104, 23);
            this.nudRazdel.TabIndex = 6;
            this.nudRazdel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRazdel.ValueChanged += new System.EventHandler(this.nudRazdel_ValueChanged);
            // 
            // lblFGOS
            // 
            this.lblFGOS.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.lblFGOS, 2);
            this.lblFGOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFGOS.Location = new System.Drawing.Point(187, 2);
            this.lblFGOS.Name = "lblFGOS";
            this.lblFGOS.Size = new System.Drawing.Size(1083, 40);
            this.lblFGOS.TabIndex = 19;
            this.lblFGOS.Text = "-";
            this.lblFGOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFGOS.TextChanged += new System.EventHandler(this.lblFGOSandThemes_TextChanged);
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.lblTheme, 2);
            this.lblTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTheme.Location = new System.Drawing.Point(187, 44);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(1083, 40);
            this.lblTheme.TabIndex = 20;
            this.lblTheme.Text = "-";
            this.lblTheme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTheme.TextChanged += new System.EventHandler(this.lblFGOSandThemes_TextChanged);
            // 
            // btnThemes
            // 
            this.btnThemes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThemes.Location = new System.Drawing.Point(5, 47);
            this.btnThemes.Name = "btnThemes";
            this.btnThemes.Size = new System.Drawing.Size(174, 34);
            this.btnThemes.TabIndex = 2;
            this.btnThemes.Text = "Загрузить темы";
            this.btnThemes.UseVisualStyleBackColor = true;
            this.btnThemes.Click += new System.EventHandler(this.btnThemes_Click);
            // 
            // cbDiscipline
            // 
            this.cbDiscipline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDiscipline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiscipline.DropDownWidth = 500;
            this.cbDiscipline.Enabled = false;
            this.cbDiscipline.FormattingEnabled = true;
            this.cbDiscipline.Location = new System.Drawing.Point(299, 89);
            this.cbDiscipline.Name = "cbDiscipline";
            this.cbDiscipline.Size = new System.Drawing.Size(971, 24);
            this.cbDiscipline.TabIndex = 5;
            this.cbDiscipline.SelectedIndexChanged += new System.EventHandler(this.cbDiscipline_SelectedIndexChanged);
            // 
            // lblIdDisc
            // 
            this.lblIdDisc.AutoSize = true;
            this.lblIdDisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdDisc.Enabled = false;
            this.lblIdDisc.Location = new System.Drawing.Point(187, 86);
            this.lblIdDisc.Name = "lblIdDisc";
            this.lblIdDisc.Size = new System.Drawing.Size(104, 29);
            this.lblIdDisc.TabIndex = 16;
            this.lblIdDisc.Text = "Код УД/ПМ";
            this.lblIdDisc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpButtonsToWork
            // 
            this.tlpButtonsToWork.ColumnCount = 7;
            this.tlpMain.SetColumnSpan(this.tlpButtonsToWork, 3);
            this.tlpButtonsToWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpButtonsToWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpButtonsToWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpButtonsToWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpButtonsToWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtonsToWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtonsToWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtonsToWork.Controls.Add(this.btnKOSMDK, 3, 0);
            this.tlpButtonsToWork.Controls.Add(this.btnKOS, 2, 0);
            this.tlpButtonsToWork.Controls.Add(this.btnLab, 4, 0);
            this.tlpButtonsToWork.Controls.Add(this.btnKIM, 1, 0);
            this.tlpButtonsToWork.Controls.Add(this.btnPract, 5, 0);
            this.tlpButtonsToWork.Controls.Add(this.btnTests, 6, 0);
            this.tlpButtonsToWork.Controls.Add(this.btnDrawUpProgram, 0, 0);
            this.tlpButtonsToWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtonsToWork.Enabled = false;
            this.tlpButtonsToWork.Location = new System.Drawing.Point(5, 312);
            this.tlpButtonsToWork.Name = "tlpButtonsToWork";
            this.tlpButtonsToWork.RowCount = 1;
            this.tlpButtonsToWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtonsToWork.Size = new System.Drawing.Size(1265, 64);
            this.tlpButtonsToWork.TabIndex = 26;
            // 
            // btnKOSMDK
            // 
            this.btnKOSMDK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKOSMDK.Enabled = false;
            this.btnKOSMDK.Location = new System.Drawing.Point(381, 3);
            this.btnKOSMDK.Name = "btnKOSMDK";
            this.btnKOSMDK.Size = new System.Drawing.Size(120, 58);
            this.btnKOSMDK.TabIndex = 16;
            this.btnKOSMDK.Text = "КОС МДК";
            this.btnKOSMDK.UseVisualStyleBackColor = true;
            this.btnKOSMDK.Click += new System.EventHandler(this.btnKOSMDK_Click);
            // 
            // btnKOS
            // 
            this.btnKOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKOS.Enabled = false;
            this.btnKOS.Location = new System.Drawing.Point(255, 3);
            this.btnKOS.Name = "btnKOS";
            this.btnKOS.Size = new System.Drawing.Size(120, 58);
            this.btnKOS.TabIndex = 15;
            this.btnKOS.Text = "КОС ПМ";
            this.btnKOS.UseVisualStyleBackColor = true;
            this.btnKOS.Click += new System.EventHandler(this.btnKOS_Click);
            // 
            // btnLab
            // 
            this.btnLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLab.Enabled = false;
            this.btnLab.Location = new System.Drawing.Point(507, 3);
            this.btnLab.Name = "btnLab";
            this.btnLab.Size = new System.Drawing.Size(247, 58);
            this.btnLab.TabIndex = 17;
            this.btnLab.Tag = "Lab";
            this.btnLab.Text = "Сборник описаний\r\nлабораторных работ";
            this.btnLab.UseVisualStyleBackColor = true;
            this.btnLab.Click += new System.EventHandler(this.btnSborniki_Click);
            // 
            // btnKIM
            // 
            this.btnKIM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKIM.Enabled = false;
            this.btnKIM.Location = new System.Drawing.Point(129, 3);
            this.btnKIM.Name = "btnKIM";
            this.btnKIM.Size = new System.Drawing.Size(120, 58);
            this.btnKIM.TabIndex = 14;
            this.btnKIM.Text = "КИМ УД";
            this.btnKIM.UseVisualStyleBackColor = true;
            this.btnKIM.Click += new System.EventHandler(this.btnKIM_Click);
            // 
            // btnPract
            // 
            this.btnPract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPract.Enabled = false;
            this.btnPract.Location = new System.Drawing.Point(760, 3);
            this.btnPract.Name = "btnPract";
            this.btnPract.Size = new System.Drawing.Size(247, 58);
            this.btnPract.TabIndex = 18;
            this.btnPract.Tag = "Pract";
            this.btnPract.Text = "Сборник описаний\r\nпрактических работ";
            this.btnPract.UseVisualStyleBackColor = true;
            this.btnPract.Click += new System.EventHandler(this.btnSborniki_Click);
            // 
            // btnTests
            // 
            this.btnTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTests.Enabled = false;
            this.btnTests.Location = new System.Drawing.Point(1013, 3);
            this.btnTests.Name = "btnTests";
            this.btnTests.Size = new System.Drawing.Size(249, 58);
            this.btnTests.TabIndex = 19;
            this.btnTests.Tag = "Test";
            this.btnTests.Text = "Сборник тестов";
            this.btnTests.UseVisualStyleBackColor = true;
            this.btnTests.Click += new System.EventHandler(this.btnSborniki_Click);
            // 
            // btnDrawUpProgram
            // 
            this.btnDrawUpProgram.AutoSize = true;
            this.btnDrawUpProgram.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDrawUpProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDrawUpProgram.Enabled = false;
            this.btnDrawUpProgram.Location = new System.Drawing.Point(3, 3);
            this.btnDrawUpProgram.Name = "btnDrawUpProgram";
            this.btnDrawUpProgram.Size = new System.Drawing.Size(120, 58);
            this.btnDrawUpProgram.TabIndex = 13;
            this.btnDrawUpProgram.Text = "РП";
            this.btnDrawUpProgram.UseVisualStyleBackColor = true;
            this.btnDrawUpProgram.Click += new System.EventHandler(this.btnDrawUpProgram_Click);
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy г.";
            this.dtpYear.Enabled = false;
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(187, 151);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(104, 23);
            this.dtpYear.TabIndex = 7;
            // 
            // lblR_MDKName
            // 
            this.lblR_MDKName.AutoSize = true;
            this.lblR_MDKName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblR_MDKName.Location = new System.Drawing.Point(299, 117);
            this.lblR_MDKName.Name = "lblR_MDKName";
            this.lblR_MDKName.Size = new System.Drawing.Size(971, 29);
            this.lblR_MDKName.TabIndex = 27;
            this.lblR_MDKName.Text = "Раздел 1";
            this.lblR_MDKName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYear.Enabled = false;
            this.lblYear.Location = new System.Drawing.Point(5, 148);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(174, 29);
            this.lblYear.TabIndex = 28;
            this.lblYear.Text = "Год:";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblR_MDK
            // 
            this.lblR_MDK.AutoSize = true;
            this.lblR_MDK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblR_MDK.Enabled = false;
            this.lblR_MDK.Location = new System.Drawing.Point(5, 117);
            this.lblR_MDK.Name = "lblR_MDK";
            this.lblR_MDK.Size = new System.Drawing.Size(174, 29);
            this.lblR_MDK.TabIndex = 29;
            this.lblR_MDK.Text = "МДК:";
            this.lblR_MDK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpCiclComission
            // 
            this.tlpCiclComission.ColumnCount = 3;
            this.tlpMain.SetColumnSpan(this.tlpCiclComission, 3);
            this.tlpCiclComission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCiclComission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCiclComission.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCiclComission.Controls.Add(this.lblNameCommission, 0, 0);
            this.tlpCiclComission.Controls.Add(this.lblChairperson, 1, 0);
            this.tlpCiclComission.Controls.Add(this.btnUpdateCommissions, 2, 1);
            this.tlpCiclComission.Controls.Add(this.tbChairperson, 1, 1);
            this.tlpCiclComission.Controls.Add(this.cbNameCommission, 0, 1);
            this.tlpCiclComission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCiclComission.Location = new System.Drawing.Point(5, 384);
            this.tlpCiclComission.Name = "tlpCiclComission";
            this.tlpCiclComission.RowCount = 2;
            this.tlpCiclComission.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCiclComission.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCiclComission.Size = new System.Drawing.Size(1265, 49);
            this.tlpCiclComission.TabIndex = 30;
            // 
            // lblNameCommission
            // 
            this.lblNameCommission.AutoSize = true;
            this.lblNameCommission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNameCommission.Location = new System.Drawing.Point(3, 0);
            this.lblNameCommission.Name = "lblNameCommission";
            this.lblNameCommission.Size = new System.Drawing.Size(583, 16);
            this.lblNameCommission.TabIndex = 0;
            this.lblNameCommission.Text = "Наименование ЦК";
            this.lblNameCommission.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChairperson
            // 
            this.lblChairperson.AutoSize = true;
            this.lblChairperson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChairperson.Location = new System.Drawing.Point(592, 0);
            this.lblChairperson.Name = "lblChairperson";
            this.lblChairperson.Size = new System.Drawing.Size(583, 16);
            this.lblChairperson.TabIndex = 2;
            this.lblChairperson.Text = "Председатель";
            this.lblChairperson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdateCommissions
            // 
            this.btnUpdateCommissions.AutoSize = true;
            this.btnUpdateCommissions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateCommissions.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUpdateCommissions.Location = new System.Drawing.Point(1181, 19);
            this.btnUpdateCommissions.Name = "btnUpdateCommissions";
            this.btnUpdateCommissions.Size = new System.Drawing.Size(81, 27);
            this.btnUpdateCommissions.TabIndex = 22;
            this.btnUpdateCommissions.Text = "Изменить";
            this.btnUpdateCommissions.UseVisualStyleBackColor = true;
            this.btnUpdateCommissions.Click += new System.EventHandler(this.btnUpdateCommissions_Click);
            // 
            // tbChairperson
            // 
            this.tbChairperson.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbChairperson.Location = new System.Drawing.Point(592, 19);
            this.tbChairperson.Name = "tbChairperson";
            this.tbChairperson.Size = new System.Drawing.Size(583, 23);
            this.tbChairperson.TabIndex = 21;
            // 
            // cbNameCommission
            // 
            this.cbNameCommission.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbNameCommission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNameCommission.DropDownWidth = 700;
            this.cbNameCommission.FormattingEnabled = true;
            this.cbNameCommission.Location = new System.Drawing.Point(3, 19);
            this.cbNameCommission.Name = "cbNameCommission";
            this.cbNameCommission.Size = new System.Drawing.Size(583, 24);
            this.cbNameCommission.TabIndex = 20;
            // 
            // gbRP
            // 
            this.gbRP.AutoSize = true;
            this.gbRP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.SetColumnSpan(this.gbRP, 3);
            this.gbRP.Controls.Add(this.tlpRP);
            this.gbRP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRP.Enabled = false;
            this.gbRP.Location = new System.Drawing.Point(5, 182);
            this.gbRP.Name = "gbRP";
            this.gbRP.Size = new System.Drawing.Size(1265, 122);
            this.gbRP.TabIndex = 8;
            this.gbRP.TabStop = false;
            this.gbRP.Text = "Рабочая программа";
            // 
            // tlpRP
            // 
            this.tlpRP.AutoSize = true;
            this.tlpRP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpRP.ColumnCount = 3;
            this.tlpRP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRP.Controls.Add(this.rbCompiled, 0, 1);
            this.tlpRP.Controls.Add(this.lblSumHours, 2, 3);
            this.tlpRP.Controls.Add(this.lblMaxHours, 1, 0);
            this.tlpRP.Controls.Add(this.nudYourselfHours, 2, 2);
            this.tlpRP.Controls.Add(this.lblAcademicHours, 1, 1);
            this.tlpRP.Controls.Add(this.nudAcademicHours, 2, 1);
            this.tlpRP.Controls.Add(this.lblYourselfHours, 1, 2);
            this.tlpRP.Controls.Add(this.label1, 1, 3);
            this.tlpRP.Controls.Add(this.rbDeveloped, 0, 2);
            this.tlpRP.Controls.Add(this.chbExampleProg, 0, 0);
            this.tlpRP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRP.Location = new System.Drawing.Point(3, 19);
            this.tlpRP.Name = "tlpRP";
            this.tlpRP.RowCount = 4;
            this.tlpRP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRP.Size = new System.Drawing.Size(1259, 100);
            this.tlpRP.TabIndex = 10;
            // 
            // rbCompiled
            // 
            this.rbCompiled.AutoSize = true;
            this.rbCompiled.Checked = true;
            this.rbCompiled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbCompiled.Location = new System.Drawing.Point(3, 29);
            this.rbCompiled.Name = "rbCompiled";
            this.rbCompiled.Size = new System.Drawing.Size(212, 23);
            this.rbCompiled.TabIndex = 9;
            this.rbCompiled.TabStop = true;
            this.rbCompiled.Text = "составлена";
            this.rbCompiled.UseVisualStyleBackColor = true;
            // 
            // lblSumHours
            // 
            this.lblSumHours.AutoSize = true;
            this.lblSumHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSumHours.Location = new System.Drawing.Point(467, 84);
            this.lblSumHours.Name = "lblSumHours";
            this.lblSumHours.Size = new System.Drawing.Size(789, 16);
            this.lblSumHours.TabIndex = 5;
            this.lblSumHours.Text = "0";
            this.lblSumHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaxHours
            // 
            this.lblMaxHours.AutoSize = true;
            this.lblMaxHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxHours.Location = new System.Drawing.Point(221, 0);
            this.lblMaxHours.Name = "lblMaxHours";
            this.lblMaxHours.Size = new System.Drawing.Size(240, 26);
            this.lblMaxHours.TabIndex = 4;
            this.lblMaxHours.Text = "Максимальная учебная нагрузка:";
            this.lblMaxHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudYourselfHours
            // 
            this.nudYourselfHours.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudYourselfHours.Location = new System.Drawing.Point(467, 58);
            this.nudYourselfHours.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudYourselfHours.Name = "nudYourselfHours";
            this.nudYourselfHours.Size = new System.Drawing.Size(93, 23);
            this.nudYourselfHours.TabIndex = 12;
            this.nudYourselfHours.ValueChanged += new System.EventHandler(this.nudAcademicHours_ValueChanged);
            // 
            // lblAcademicHours
            // 
            this.lblAcademicHours.AutoSize = true;
            this.lblAcademicHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAcademicHours.Location = new System.Drawing.Point(221, 26);
            this.lblAcademicHours.Name = "lblAcademicHours";
            this.lblAcademicHours.Size = new System.Drawing.Size(240, 29);
            this.lblAcademicHours.TabIndex = 0;
            this.lblAcademicHours.Text = "- аудиторная:";
            this.lblAcademicHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudAcademicHours
            // 
            this.nudAcademicHours.Dock = System.Windows.Forms.DockStyle.Left;
            this.nudAcademicHours.Location = new System.Drawing.Point(467, 29);
            this.nudAcademicHours.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudAcademicHours.Name = "nudAcademicHours";
            this.nudAcademicHours.Size = new System.Drawing.Size(93, 23);
            this.nudAcademicHours.TabIndex = 11;
            this.nudAcademicHours.ValueChanged += new System.EventHandler(this.nudAcademicHours_ValueChanged);
            // 
            // lblYourselfHours
            // 
            this.lblYourselfHours.AutoSize = true;
            this.lblYourselfHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYourselfHours.Location = new System.Drawing.Point(221, 55);
            this.lblYourselfHours.Name = "lblYourselfHours";
            this.lblYourselfHours.Size = new System.Drawing.Size(240, 29);
            this.lblYourselfHours.TabIndex = 8;
            this.lblYourselfHours.Text = "- самостоятельная:";
            this.lblYourselfHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(221, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Всего:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbDeveloped
            // 
            this.rbDeveloped.AutoSize = true;
            this.rbDeveloped.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbDeveloped.Location = new System.Drawing.Point(3, 58);
            this.rbDeveloped.Name = "rbDeveloped";
            this.rbDeveloped.Size = new System.Drawing.Size(212, 23);
            this.rbDeveloped.TabIndex = 10;
            this.rbDeveloped.TabStop = true;
            this.rbDeveloped.Text = "разработана";
            this.rbDeveloped.UseVisualStyleBackColor = true;
            // 
            // chbExampleProg
            // 
            this.chbExampleProg.AutoSize = true;
            this.chbExampleProg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbExampleProg.Location = new System.Drawing.Point(3, 3);
            this.chbExampleProg.Name = "chbExampleProg";
            this.chbExampleProg.Size = new System.Drawing.Size(212, 20);
            this.chbExampleProg.TabIndex = 8;
            this.chbExampleProg.Text = "Есть примерная программа";
            this.chbExampleProg.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tlpMain.SetColumnSpan(this.tableLayoutPanel1, 3);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gpAutors, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbExperts, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 441);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 303F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1265, 282);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // gpAutors
            // 
            this.gpAutors.Controls.Add(this.dgvAuthors);
            this.gpAutors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpAutors.Location = new System.Drawing.Point(3, 3);
            this.gpAutors.Name = "gpAutors";
            this.gpAutors.Size = new System.Drawing.Size(616, 276);
            this.gpAutors.TabIndex = 31;
            this.gpAutors.TabStop = false;
            this.gpAutors.Text = "Авторы/Составители";
            // 
            // dgvAuthors
            // 
            this.dgvAuthors.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAuthors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuthors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Authors,
            this.TeachingPosition});
            this.dgvAuthors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuthors.Location = new System.Drawing.Point(3, 19);
            this.dgvAuthors.Name = "dgvAuthors";
            this.dgvAuthors.Size = new System.Drawing.Size(610, 254);
            this.dgvAuthors.TabIndex = 23;
            // 
            // Authors
            // 
            this.Authors.HeaderText = "Фамилия И.О.";
            this.Authors.Name = "Authors";
            this.Authors.Width = 164;
            // 
            // TeachingPosition
            // 
            this.TeachingPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeachingPosition.HeaderText = "Должность";
            this.TeachingPosition.Name = "TeachingPosition";
            // 
            // gbExperts
            // 
            this.gbExperts.Controls.Add(this.dgvExperts);
            this.gbExperts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbExperts.Location = new System.Drawing.Point(645, 3);
            this.gbExperts.Name = "gbExperts";
            this.gbExperts.Size = new System.Drawing.Size(617, 276);
            this.gbExperts.TabIndex = 32;
            this.gbExperts.TabStop = false;
            this.gbExperts.Text = "Эксперты";
            // 
            // dgvExperts
            // 
            this.dgvExperts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvExperts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExperts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvExperts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExperts.Location = new System.Drawing.Point(3, 19);
            this.dgvExperts.Name = "dgvExperts";
            this.dgvExperts.Size = new System.Drawing.Size(611, 254);
            this.dgvExperts.TabIndex = 24;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Фамилия И.О.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 164;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // tlpRBItems
            // 
            this.tlpRBItems.ColumnCount = 2;
            this.tlpRBItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRBItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpRBItems.Controls.Add(this.rbDisc, 0, 0);
            this.tlpRBItems.Controls.Add(this.rbPM, 1, 0);
            this.tlpRBItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpRBItems.Enabled = false;
            this.tlpRBItems.Location = new System.Drawing.Point(5, 89);
            this.tlpRBItems.Name = "tlpRBItems";
            this.tlpRBItems.RowCount = 1;
            this.tlpRBItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRBItems.Size = new System.Drawing.Size(174, 23);
            this.tlpRBItems.TabIndex = 35;
            // 
            // rbDisc
            // 
            this.rbDisc.AutoSize = true;
            this.rbDisc.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbDisc.Location = new System.Drawing.Point(3, 3);
            this.rbDisc.Name = "rbDisc";
            this.rbDisc.Size = new System.Drawing.Size(109, 20);
            this.rbDisc.TabIndex = 3;
            this.rbDisc.Text = "Дисциплина";
            this.rbDisc.UseVisualStyleBackColor = true;
            this.rbDisc.CheckedChanged += new System.EventHandler(this.rbDisc_CheckedChanged);
            // 
            // rbPM
            // 
            this.rbPM.AutoSize = true;
            this.rbPM.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbPM.Location = new System.Drawing.Point(118, 3);
            this.rbPM.Name = "rbPM";
            this.rbPM.Size = new System.Drawing.Size(53, 20);
            this.rbPM.TabIndex = 4;
            this.rbPM.Text = "ПМ";
            this.rbPM.UseVisualStyleBackColor = true;
            this.rbPM.CheckedChanged += new System.EventHandler(this.rbPM_CheckedChanged);
            // 
            // FormProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 750);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormProgram";
            this.Text = "Экспорт документацию";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProgram_FormClosing);
            this.Load += new System.EventHandler(this.FormProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFGOS)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRazdel)).EndInit();
            this.tlpButtonsToWork.ResumeLayout(false);
            this.tlpButtonsToWork.PerformLayout();
            this.tlpCiclComission.ResumeLayout(false);
            this.tlpCiclComission.PerformLayout();
            this.gbRP.ResumeLayout(false);
            this.gbRP.PerformLayout();
            this.tlpRP.ResumeLayout(false);
            this.tlpRP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYourselfHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAcademicHours)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gpAutors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthors)).EndInit();
            this.gbExperts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExperts)).EndInit();
            this.tlpRBItems.ResumeLayout(false);
            this.tlpRBItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ds ds;
        private dsFGOS dsFGOS;
        private System.Windows.Forms.ToolStripStatusLabel lblAllTreb;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnFGOS;
        private System.Windows.Forms.NumericUpDown nudRazdel;
        private System.Windows.Forms.Label lblFGOS;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Button btnThemes;
        private System.Windows.Forms.ComboBox cbDiscipline;
        private System.Windows.Forms.Label lblIdDisc;
        private System.Windows.Forms.TableLayoutPanel tlpButtonsToWork;
        private System.Windows.Forms.Button btnKOSMDK;
        private System.Windows.Forms.Button btnKOS;
        private System.Windows.Forms.Button btnLab;
        private System.Windows.Forms.Button btnKIM;
        private System.Windows.Forms.Button btnPract;
        private System.Windows.Forms.Button btnTests;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label lblR_MDKName;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblR_MDK;
        private System.Windows.Forms.TableLayoutPanel tlpCiclComission;
        private System.Windows.Forms.Label lblNameCommission;
        private System.Windows.Forms.Label lblChairperson;
        private System.Windows.Forms.Button btnUpdateCommissions;
        private System.Windows.Forms.TextBox tbChairperson;
        private System.Windows.Forms.ComboBox cbNameCommission;
        private System.Windows.Forms.GroupBox gbRP;
        private System.Windows.Forms.TableLayoutPanel tlpRP;
        private System.Windows.Forms.CheckBox chbExampleProg;
        private System.Windows.Forms.Label lblSumHours;
        private System.Windows.Forms.Label lblMaxHours;
        private System.Windows.Forms.NumericUpDown nudYourselfHours;
        private System.Windows.Forms.Label lblAcademicHours;
        private System.Windows.Forms.NumericUpDown nudAcademicHours;
        private System.Windows.Forms.Label lblYourselfHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDrawUpProgram;
        private System.Windows.Forms.RadioButton rbCompiled;
        private System.Windows.Forms.RadioButton rbDeveloped;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gpAutors;
        private System.Windows.Forms.DataGridView dgvAuthors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Authors;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeachingPosition;
        private System.Windows.Forms.GroupBox gbExperts;
        private System.Windows.Forms.DataGridView dgvExperts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.RadioButton rbDisc;
        private System.Windows.Forms.RadioButton rbPM;
        private System.Windows.Forms.TableLayoutPanel tlpRBItems;
    }
}