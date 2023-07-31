namespace EMC
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFgos = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveFGOS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiThemes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveRP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCTP = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFgos,
            this.tsmiRP,
            this.tsmiCTP,
            this.btnInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(978, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFgos
            // 
            this.tsmiFgos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.импортДанныхToolStripMenuItem,
            this.toolStripSeparator3,
            this.btnSaveFGOS});
            this.tsmiFgos.Name = "tsmiFgos";
            this.tsmiFgos.Size = new System.Drawing.Size(65, 22);
            this.tsmiFgos.Text = "ФГОС";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.открытьToolStripMenuItem.Text = "Открыть ФГОС";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.tsmiOpenAviFgos_Click);
            // 
            // импортДанныхToolStripMenuItem
            // 
            this.импортДанныхToolStripMenuItem.Name = "импортДанныхToolStripMenuItem";
            this.импортДанныхToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.импортДанныхToolStripMenuItem.Text = "Импорт данных";
            this.импортДанныхToolStripMenuItem.Click += new System.EventHandler(this.tsmiOpenOneFgos_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(205, 6);
            // 
            // btnSaveFGOS
            // 
            this.btnSaveFGOS.Enabled = false;
            this.btnSaveFGOS.Name = "btnSaveFGOS";
            this.btnSaveFGOS.Size = new System.Drawing.Size(208, 22);
            this.btnSaveFGOS.Text = "Сохранить ФГОС";
            this.btnSaveFGOS.Click += new System.EventHandler(this.tsmiSaveFgos_Click);
            // 
            // tsmiRP
            // 
            this.tsmiRP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiThemes,
            this.btnSaveRP,
            this.toolStripSeparator1,
            this.tsmiProgram,
            this.toolStripSeparator2,
            this.btnSettings});
            this.tsmiRP.Name = "tsmiRP";
            this.tsmiRP.Size = new System.Drawing.Size(131, 22);
            this.tsmiRP.Text = "Документация";
            // 
            // tsmiThemes
            // 
            this.tsmiThemes.Name = "tsmiThemes";
            this.tsmiThemes.Size = new System.Drawing.Size(253, 22);
            this.tsmiThemes.Text = "Заполнить РП";
            this.tsmiThemes.Click += new System.EventHandler(this.tsmiThemes_Click);
            // 
            // btnSaveRP
            // 
            this.btnSaveRP.Enabled = false;
            this.btnSaveRP.Name = "btnSaveRP";
            this.btnSaveRP.Size = new System.Drawing.Size(253, 22);
            this.btnSaveRP.Text = "Сохранить РП";
            this.btnSaveRP.Click += new System.EventHandler(this.btnSaveRP_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // tsmiProgram
            // 
            this.tsmiProgram.Name = "tsmiProgram";
            this.tsmiProgram.Size = new System.Drawing.Size(253, 22);
            this.tsmiProgram.Text = "Экспорт документации";
            this.tsmiProgram.Click += new System.EventHandler(this.tsmiProgram_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(250, 6);
            // 
            // btnSettings
            // 
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(253, 22);
            this.btnSettings.Text = "Настройки";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // tsmiCTP
            // 
            this.tsmiCTP.Name = "tsmiCTP";
            this.tsmiCTP.Size = new System.Drawing.Size(50, 22);
            this.tsmiCTP.Text = "КТП";
            this.tsmiCTP.Click += new System.EventHandler(this.tsmiCTP_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.btnInfo.Size = new System.Drawing.Size(85, 22);
            this.btnInfo.Text = "Справка";
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::EMC.Properties.Resources._1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 517);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Учебно-методический комплекс";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem tsmiThemes;
        private System.Windows.Forms.ToolStripMenuItem tsmiProgram;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSaveRP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected System.Windows.Forms.MenuStrip menuStrip1;
        protected System.Windows.Forms.ToolStripMenuItem tsmiFgos;
        protected System.Windows.Forms.ToolStripMenuItem btnSaveFGOS;
        protected System.Windows.Forms.ToolStripMenuItem tsmiRP;
        protected System.Windows.Forms.ToolStripMenuItem tsmiCTP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnInfo;
    }
}

