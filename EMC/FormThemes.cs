using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Dia = System.Diagnostics;

namespace EMC
{
    public partial class FormThemes : Form
    {
        DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn();
        ComboBox cbDisc = new ComboBox();
        ComboBox cbPkTreb_Disc = new ComboBox();
        ComboBox cbRazdelTest = new ComboBox();
        ComboBox cbThemaTest = new ComboBox();
        const int autoSaveSec = 60;

        public FormThemes()
        {
            InitializeComponent();
            timerAutoSave.Interval = 1000 * autoSaveSec * Properties.Settings.Default.timeAutoSave;
        }

        private void FormThemes_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            ds.vid.AddvidRow(1, "урок");
            ds.vid.AddvidRow(2, "лаб");
            ds.vid.AddvidRow(3, "практ");
            ds.vid.AddvidRow(4, "КП/КР");
            ds.vid.AddvidRow(5, "контр");

            c.Name = "cbVid";
            c.HeaderText = "Вид";
            c.DataPropertyName = "idV";
            c.DataSource = ds.Tables["vid"];
            c.ValueMember = "idV";
            c.DisplayMember = "text";
            c.SortMode = DataGridViewColumnSortMode.Automatic;

            dgvMain.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;

            dgvMain.RowsDefaultCellStyle.WrapMode =
                DataGridViewTriState.True;
            dgvTheme.RowsDefaultCellStyle.WrapMode =
               DataGridViewTriState.True;
            dgvSod.RowsDefaultCellStyle.WrapMode =
               DataGridViewTriState.True;

            razdelBindingSource.Sort = "idR";
            temaBindingSource.Sort = "idR, idT";
            sodBindingSource.Sort = "idR, idT, idV, idS";

            //добавление комбо бокса "Задания и требования" на вкладку требования и "ПК и требования"
            cbDisc.Size = new System.Drawing.Size(250, cbDisc.Height);
            cbDisc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDisc.SelectedIndexChanged += CbDisc_SelectedIndexChanged;
            ToolStripControlHost newControl = new ToolStripControlHost(
                cbDisc);
            toolStripTreb.Items.Insert(2, newControl);

            cbPkTreb_Disc.Size = new System.Drawing.Size(400, cbPkTreb_Disc.Height);
            cbPkTreb_Disc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPkTreb_Disc.SelectedIndexChanged += CbPkTreb_Disc_SelectedIndexChanged;
            ToolStripControlHost newControlPkTreb = new ToolStripControlHost(
                cbPkTreb_Disc);
            toolStripPkTreb.Items.Insert(2, newControlPkTreb);

            cbRazdelTest.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRazdelTest.Width = 50;
            cbRazdelTest.SelectedIndexChanged += CbRazdelTest_SelectedIndexChanged;
            ToolStripControlHost newControlCbRaxdel = new ToolStripControlHost(
                cbRazdelTest);
            cbRazdelTest.DataSource = ds;
            cbRazdelTest.DisplayMember = "razdel.idR";
            cbRazdelTest.ValueMember = "razdel.idR";
            bindingNavigatorLitToReadSod.Items.Insert(12, newControlCbRaxdel);

            cbThemaTest.DropDownStyle = ComboBoxStyle.DropDownList;
            cbThemaTest.Width = 50;
            cbThemaTest.SelectedIndexChanged += CbThemaTest_SelectedIndexChanged;
            ToolStripControlHost newControlCbThema = new ToolStripControlHost(
                cbThemaTest);
            cbThemaTest.DataSource = ds;
            cbThemaTest.DisplayMember = "razdel.FK_razdel_tema.idT";
            cbThemaTest.ValueMember = "razdel.FK_razdel_tema.idT";
            bindingNavigatorLitToReadSod.Items.Insert(14, newControlCbThema);

            //обработчик на добавление требований
            bsTreb.AddingNew += BsTreb_AddingNew;

            //сортировка литературы
            bsLit.Sort = "dopolnitelnaia ASC, name ASC";
        }

        private void CbThemaTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            litToReadFilteridR = Convert.ToInt32(cbRazdelTest.SelectedValue);
            litToReadFilteridT = Convert.ToInt32(cbThemaTest.SelectedValue);
            litToReadSetFilter();
        }

        private void CbRazdelTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            litToReadFilteridR = Convert.ToInt32(cbRazdelTest.SelectedValue);
            litToReadFilteridT = Convert.ToInt32(cbThemaTest.SelectedValue);
            changeRazdel = true;
            litToReadSetFilter();
            changeRazdel = false;
        }

        private void CbDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadFGOS)
            {
                CbDiscNewFIlter();
            }
        }

        private void CbDiscNewFIlter()
        {
            string filter = "idDisc = '" + cbDisc.SelectedValue.ToString() + "'";
            bsTrebAll.Filter = filter;
        }

        private void CbPkTreb_Disc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadFGOS)
            {
                CbPkTrebNewFilter();
            }
        }

        private void CbPkTrebNewFilter()
        {
            string pm = cbPkTreb_Disc.SelectedValue.ToString();

            string filter = "idDisc = '" + pm + "'";
            bsTrebAllForPkTreb.Filter = filter;

            bsPkAll.Filter = "idPk Like 'ПК " + pm[pm.Length - 1] + "%'";
        }

        string pathFileSave = "";
        /// <summary>
        /// Сохранение данных в файл формата *.xml 
        /// </summary>
        public void SaveThemes()
        {
            try
            {
                // завершение редактирования источника данных
                bsMain.EndEdit();
                bsTheme.EndEdit();
                bsSod.EndEdit();

                //приведение текста "Требований" к стандарту
                foreach (DataGridViewRow dr in dgvTreb.Rows)
                {
                    if (dr.Cells[4].Value != null)
                        dr.Cells[4].Value = dr.Cells[4].Value.ToString().Replace(" ", "").ToUpper();
                }

                //проверка ошибки добавления литературы
                for (int i = ds.sod_literatura.Rows.Count - 1; i >= 0; i--)
                {
                    if (ds.sod_literatura.Rows[i]["idR"].ToString() == "")
                        ds.sod_literatura.Rows[i].Delete();
                }


                if (pathFileSave != "")
                    ds.WriteXml(pathFileSave);
                else
                {
                    // открытие окна выбора файла при сохранении
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "XML|*.xml";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // сохранение в *.xml-файл
                        ds.WriteXml(sfd.FileName);
                    }
                }

                MessageBox.Show("Сохранение прошло успешно");
            }
            // перехват ошибок записи файла
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        BindingSource bsVid = new BindingSource();
        bool loadListThemes = false;
        private void btnLoadThemes_Click(object sender, EventArgs e)
        {
            loadListThemes = true;
            tabPageLitObor.Show();
            LoadThemes();
            loadListThemes = false;
            litToReadSetFilter();
        }

        /// <summary>
        /// Чтения данных из файла формата *.xml
        /// </summary>
        DataSet dsMain = new DataSet();
        DataSet dsTheme = new DataSet();
        DataSet dsSod = new DataSet();
        BindingSource bsMain = new BindingSource();
        BindingSource bsTheme = new BindingSource();
        BindingSource bsSod = new BindingSource();
        BindingSource bsVidSod = new BindingSource();
        string selectedRazdel = "-1";
        string selectedTema = "-1";
        bool loadDGV = false;
        string pathSave = "";
        static Thread th;
        /// <summary>
        /// Загрузка файла с темами
        /// </summary>
        private void LoadThemes()
        {
            try
            {
                // открытие окна выбоа файла при чтении
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "XML|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //очистка данных
                    ds.Clear();
                    //чтение из *.xml-файла
                    pathFileSave = ofd.SafeFileName;
                    ds.ReadXml(ofd.FileName);
                    bsMain.DataSource = ds;
                    bsMain.DataMember = "razdel";
                    razdelbindingNavigator.BindingSource = bsMain;
                    dgvMain.DataSource = bsMain;

                    //заполнение таблиц
                    FillDGV(true);

                    //включение фильтров литературы
                    litToReadEnableFilter();

                    //автосохранение
                    pathSave = ofd.FileName;
                    timerAutoSave.Stop();
                    timerAutoSave.Start();

                    //включение кнопки объединения
                    btnMerge.Enabled = true;

                    //активация кнопки сохранения
                    ((ToolStripMenuItem)(((MenuStrip)(this.MdiParent.Controls[0])).Items[5])).
                        DropDownItems[1].Enabled = true;
                }
            }
            // перехват ошибок чтения файла
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        bool autoAddR = false;
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (pathSave == "" && !timerAutoSave.Enabled)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML|*.xml";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    pathSave = sfd.FileName;
                    timerAutoSave.Start();
                    pathFileSave = sfd.FileName;
                    //активация кнопки сохранения
                    ((ToolStripMenuItem)(((MenuStrip)(this.MdiParent.Controls[0])).Items[5])).DropDownItems[1].Enabled = true;
                }
            }

            if (dgvMain.Rows.Count == 1)
            {
                autoAddR = true;
            }
        }

        private void FillDGV(bool value)
        {
            loadDGV = true;
            if (value)
            {
                bsTheme.DataSource = null;
                bsTheme.DataMember = "tema";
                //bsTheme.DataSource = dsMain;
                bsTheme.DataSource = ds;
                dgvTheme.DataSource = bsTheme;
                if (selectedRazdel != "")
                {
                    bsTheme.RemoveFilter();
                    bsTheme.Filter = "idR = " + selectedRazdel;
                }

                bsVidSod.DataSource = ds;
                bsVidSod.DataMember = "vid";
            }

            bsSod.DataSource = null;
            bsSod.DataMember = "sod";
            //bsSod.DataSource = dsMain;
            bsSod.DataSource = ds;
            dgvSod.DataSource = bsSod;
            bsSod.RemoveFilter();
            if (selectedRazdel != "")
                bsSod.Filter = "idR = " + selectedRazdel + " AND idT = " + selectedTema;

            loadDGV = false;
        }


        private Object thisLock = new Object();
        bool filterNewR = false;
        private void razdelDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            filterNewR = true;
            int index = e.RowIndex;

            selectedRazdel = dgvMain.Rows[index].Cells[0].Value.ToString();
            //if (!loadListThemes && selectedRazdel != "")
            if (!loadListThemes && selectedRazdel != "")
            {
                lock (thisLock)
                {
                    //Dia.Debug.WriteLine("Создание потока в разделе");
                    //th = new Thread(new ThreadStart(ShowWaitingStatus));
                    //Dia.Debug.WriteLine("Открытие потока в разделе");
                    //if (th.ThreadState == ThreadState.Unstarted)
                    //    th.Start();
                    //Dia.Debug.WriteLine("Заполнение дгв в разделе");
                    FillDGV(true);
                    //Dia.Debug.WriteLine("Закрытие потока в разделе");
                    //if (th.ThreadState == ThreadState.Running)
                    //    th.Abort();
                }
            }

            filterNewR = false;
        }

        bool filterNewT = false;
        private void temaDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            filterNewT = true;
            int index = e.RowIndex;

            if (dgvTheme.Rows[index].Cells[1].Value != null)
            {
                selectedTema = dgvTheme.Rows[index].Cells[1].Value.ToString();
                if (!loadListThemes && !filterNewR)
                {
                    lock (thisLock)
                    {
                        //Dia.Debug.WriteLine("Создание потока в теме");
                        //th = new Thread(new ThreadStart(ShowWaitingStatus));
                        //Dia.Debug.WriteLine("Открытие потока в теме");
                        //if (th.ThreadState == ThreadState.Unstarted)
                        //    th.Start();
                        //Dia.Debug.WriteLine("Заполнение дгв в теме");
                        FillDGV(false);
                        //Dia.Debug.WriteLine("Закрытие потока в теме");
                        //if (th.ThreadState == ThreadState.Running)
                        //    th.Abort();
                    }
                }
            }
            filterNewT = false;
        }

        private void dgvTheme_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvSod_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            sortliteratura();
        }

        private void sortliteratura()
        {
            int maxInt = Int32.MaxValue;
            try
            {
                for (int i = 0; i < dgvLit.RowCount - 1; i++)
                    dgvLit.Rows[i].Cells[0].Value = (maxInt--);
                bsLit.EndEdit();

                for (int i = 0; i < dgvLit.RowCount - 1; i++)
                {
                    dgvLit.Rows[i].Cells[0].Value = (i + 1);
                    bsLit.EndEdit();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        BindingSource bsToFIlter = new BindingSource();
        private void litToReadEnableFilter()
        {
            bsToFIlter.DataSource = ds;
            bsToFIlter.DataMember = "sod";
        }

        bool enterTabPageSodLit = false;
        private void btnMerge_Click(object sender, EventArgs e)
        {
            Merge();
        }

        private void Merge()
        {
            //выбор набора доп файлов
            MessageBox.Show("Выберите файлы для добавления в текущий.");
            OpenFileDialog ofdFIles = new OpenFileDialog();
            ofdFIles.Filter = "XML|*.xml";
            ofdFIles.Multiselect = true;
            ds dsDop = new ds();
            if (ofdFIles.ShowDialog() == DialogResult.OK)
                foreach (string file in ofdFIles.FileNames)
                {
                    dsDop.Clear();
                    dsDop.ReadXml(file);
                    dsMain.Merge(dsDop, true);//дулирование ключей ломает процесс
                }
        }

        int litToReadFilteridR = 0;
        int litToReadFilteridT = 0;
        bool loadFilter = true;
        bool changeRazdel = false;
        private void litToReadSetFilter()
        {
            bsLitToReadSod.RemoveFilter();
            string filter = " idR = " + litToReadFilteridR +
                " AND idT = " + litToReadFilteridT;
            bsLitToReadSod.Filter = filter;

            //фильтр на ПР и ЛР
            filterBsLitToReadAddPrLt();
        }

        private void tabPageSodLit_Enter(object sender, EventArgs e)
        {
            enterTabPageSodLit = true;

            dgvLitToRead.Columns[0].Visible = false; //при загрузке файла становится видимым первый столбец [заплатка]
        }

        private void tabPageSodLit_Leave(object sender, EventArgs e)
        {
            enterTabPageSodLit = false;
        }

        private void dgvLit_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!loadDGV && dgvLit.RowCount > 1)
                dgvLit.Rows[dgvLit.RowCount - 2].Cells[0].Value = dgvLit.RowCount - 1;
        }

        private void dgvLit_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        int dgvLitToReadSodRowSelect = -1;
        private void dgvLitToReadSod_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLitToReadSod.Rows.Count > 0)
            {
                //bsLitToRead.RemoveFilter();
                dgvLitToReadSodRowSelect = e.RowIndex;
                string filter = "idR = " + dgvLitToReadSod[0, dgvLitToReadSodRowSelect].Value.ToString() +
                    " AND idT = " + dgvLitToReadSod[1, dgvLitToReadSodRowSelect].Value.ToString() +
                    " AND idS = " + dgvLitToReadSod[2, dgvLitToReadSodRowSelect].Value.ToString() +
                    " AND idV = " + dgvLitToReadSod[3, dgvLitToReadSodRowSelect].Value.ToString();

                bsLitToRead.Filter = filter;
                bsTreb.Filter = filter;
            }
        }

        private void dgvLitToRead_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLitToRead.RowCount > 1)
                {
                    dgvLitToRead.Rows[e.RowIndex].Cells[0].Value = dgvLitToReadSod.Rows[dgvLitToReadSodRowSelect].Cells[0].Value;
                    dgvLitToRead.Rows[e.RowIndex].Cells[1].Value = dgvLitToReadSod.Rows[dgvLitToReadSodRowSelect].Cells[1].Value;
                    dgvLitToRead.Rows[e.RowIndex].Cells[2].Value = dgvLitToReadSod.Rows[dgvLitToReadSodRowSelect].Cells[2].Value;
                    dgvLitToRead.Rows[e.RowIndex].Cells[3].Value = dgvLitToReadSod.Rows[dgvLitToReadSodRowSelect].Cells[3].Value;
                }
                bsLitToRead.EndEdit();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message); //Обработано в dgvLitToRead_DataError
            }
        }

        private void dgvLitToRead_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Дублирование литературы в списке");
        }

        private void btnFilterPrLr_CheckedChanged(object sender, EventArgs e)
        {
            filterBsLitToReadAddPrLt();
        }

        private void filterBsLitToReadAddPrLt()
        {
            if (btnFilterPrLr.Checked)
            {
                if (bsLitToReadSod.Filter != "")
                    bsLitToReadSod.Filter += " AND (idV = 2 OR idV = 3)";
            }
            else
            {
                bsLitToReadSod.Filter = bsLitToReadSod.Filter.Replace(" AND (idV = 2 OR idV = 3)", "");
            }
        }

        private void tabPageTreb_Enter(object sender, EventArgs e)
        {
            dgvTreb.Columns[0].Visible = false; //при загрузке файла становится видимым первый столбец [заплатка]
            dgvTreb.Columns[1].Visible = false; //при загрузке файла становится видимым первый столбец [заплатка]
            dgvTreb.Columns[2].Visible = false; //при загрузке файла становится видимым первый столбец [заплатка]
            dgvTreb.Columns[3].Visible = false; //при загрузке файла становится видимым первый столбец [заплатка]

            if (cbDisc.Items.Count > 0)
                CbDiscNewFIlter();
        }

        bool loadFGOS = true;
        bool loadedFGOS = false;
        bool startTabPagePkTreb = true;
        private void btnLoadFGOS_Click(object sender, EventArgs e)
        {
            if (((ToolStripButton)(sender)).Tag == null)
                startTabPagePkTreb = false;
            LoadFGOS();
            startTabPagePkTreb = true;
        }

        private void LoadFGOS()
        {
            try
            {
                if (loadedFGOS)
                {
                    if (MessageBox.Show("ФГОС уже загружен.\n\nВыбрать новый файл?") != DialogResult.OK)
                        return;
                }

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "XML|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (!startTabPagePkTreb)
                    {
                        tabPagePkTreb.Show();
                        tabPageLitTreb.Show();
                    }

                    loadedFGOS = false;
                    loadFGOS = true;
                    btnAddTreb.Enabled = true;
                    btnFindNotUseTreb.Enabled = true;

                    dsFGOS.Clear();
                    dsFGOS.ReadXml(ofd.FileName);

                    bs = new BindingSource();
                    bs.DataSource = dsFGOS;
                    bs.DataMember = "disc";
                    bsPkTreb = new BindingSource();
                    bsPkTreb.DataSource = dsFGOS;
                    bsPkTreb.DataMember = "disc";


                    loadFGOS = false;
                    cbDisc.DataSource = bs;
                    bs.Sort = "name";
                    cbDisc.ValueMember = "idDisc";
                    cbDisc.DisplayMember = "name";

                    cbPkTreb_Disc.DataSource = bsPkTreb;
                    bsPkTreb.Sort = "name";
                    cbPkTreb_Disc.ValueMember = "idDisc";
                    cbPkTreb_Disc.DisplayMember = "name";

                    bsPkTreb.Filter = "idDisc like 'ПМ%'";
                    loadedFGOS = true;

                    CbPkTrebNewFilter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool addFromButton = false;
        private void btnAddTrebToSod_Click(object sender, EventArgs e)
        {
            try
            {
                bool findRow = false;
                addFromButton = true;
                foreach (DataGridViewRow dr in dgvTrebAll.SelectedRows)
                {
                    findRow = false;
                    foreach (DataRow drTreb in ds.trebovania.Rows)
                        if (drTreb[0].ToString() == dgvLitToReadSod[0, dgvLitToReadSodRowSelect].Value.ToString() &&
                            drTreb[1].ToString() == dgvLitToReadSod[1, dgvLitToReadSodRowSelect].Value.ToString() &&
                            drTreb[2].ToString() == dgvLitToReadSod[2, dgvLitToReadSodRowSelect].Value.ToString() &&
                            drTreb[3].ToString() == dgvLitToReadSod[3, dgvLitToReadSodRowSelect].Value.ToString() &&
                            drTreb[4].ToString() == dr.Cells[0].Value.ToString())
                        {
                            findRow = true;
                            break;
                        }
                    if (!findRow)
                    {
                        ds.trebovania.Rows.Add(dgvLitToReadSod[0, dgvLitToReadSodRowSelect].Value,
                            dgvLitToReadSod[1, dgvLitToReadSodRowSelect].Value,
                            dgvLitToReadSod[2, dgvLitToReadSodRowSelect].Value,
                            dgvLitToReadSod[3, dgvLitToReadSodRowSelect].Value,
                            dr.Cells[0].Value);

                        bsTreb.EndEdit();
                    }
                }
                addFromButton = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFindNotUser_Click(object sender, EventArgs e)
        {
            FindNotUseTreb();
        }

        private void FindNotUseTreb()
        {
            var itemsTreb = (from x in dsFGOS.treb
                             where x.idDisc == cbDisc.SelectedValue.ToString()
                             select x.idTreb).Distinct();

            var itemsTrebAdded = (from x in ds.trebovania
                                  select x.idTreb).Distinct();

            var items = itemsTreb.Except(itemsTrebAdded);//поиск всех неиспользованных требований

            string message = "";
            foreach (string item in items)
                message += " - " + item + Environment.NewLine;

            if (message == "")
                MessageBox.Show("Все требования используются");
            else
                MessageBox.Show("Список неиспользованных требований\n\n" + message);
        }

        #region Treb
        bool addRow = false;
        private void dgvTreb_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (addRow)
            {
                dgvTreb[0, e.RowIndex].Value = dgvLitToReadSod[0, dgvLitToReadSodRowSelect].Value;
                dgvTreb[1, e.RowIndex].Value = dgvLitToReadSod[1, dgvLitToReadSodRowSelect].Value;
                dgvTreb[2, e.RowIndex].Value = dgvLitToReadSod[2, dgvLitToReadSodRowSelect].Value;
                dgvTreb[3, e.RowIndex].Value = dgvLitToReadSod[3, dgvLitToReadSodRowSelect].Value;
                addRow = false;
            }
        }

        private void BsTreb_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            addRow = true;
        }

        private void timerAutoSave_Tick(object sender, EventArgs e)
        {
            ds.WriteXml(pathSave);
        }
        #endregion

        #region PkTreb
        private void btnAddPkTreb_Click(object sender, EventArgs e)
        {
            PkTrebAdd();
        }

        private void PkTrebAdd()
        {
            bool findTreb = false;
            foreach (DataGridViewRow dr in dgvPkTreb_TrebAll.SelectedRows)
            {
                findTreb = false;
                foreach (DataRow drTreb in ds.Tables["pk_trebovania"].Rows)
                {
                    if (drTreb[0].ToString() == cbPkTreb_Disc.SelectedValue.ToString() &&
                        drTreb[1].ToString() == dgvPkTreb_PkAll.SelectedRows[0].Cells[0].Value.ToString() &&
                        drTreb[2].ToString() == dr.Cells[0].Value.ToString())
                    {
                        findTreb = true;
                        break;
                    }
                }
                if (!findTreb)
                {
                    ds.Tables["pk_trebovania"].Rows.Add(cbPkTreb_Disc.SelectedValue,
                        dgvPkTreb_PkAll.SelectedRows[0].Cells[0].Value, dr.Cells[0].Value);
                    bsPkTreb.EndEdit();
                }
            }
        }

        private void btdDeletePkTreb_Click(object sender, EventArgs e)
        {
            for (int i = dgvPkTreb_PkTreb.SelectedRows.Count; i > 0; i--)
            {
                dgvPkTreb_PkTreb.Rows.RemoveAt(dgvPkTreb_PkTreb.SelectedRows[i - 1].Index);
            }
        }

        private void FormThemes_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ToolStripMenuItem)(((MenuStrip)(this.MdiParent.Controls[0])).Items[5])).DropDownItems[1].Enabled = false;
        }
        #endregion

        private void dgvTheme_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!loadListThemes && !filterNewR && e.RowIndex > 0)
            {
                dgvTheme.Rows[e.RowIndex - 1].Cells[0].Value = selectedRazdel;
            }
        }

        private void dgvSod_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!loadListThemes && !filterNewR && !filterNewT && e.RowIndex > 0)
            {
                dgvSod.Rows[e.RowIndex - 1].Cells[0].Value = selectedRazdel;
                dgvSod.Rows[e.RowIndex - 1].Cells[1].Value = selectedTema;
                dgvSod.Rows[e.RowIndex - 1].Cells[3].Value = 1;
            }

        }

        private void dgvMain_Leave(object sender, EventArgs e)
        {
            if (!loadListThemes && !filterNewR && !filterNewT)
            {
                razdelBindingSource.EndEdit();
                if (selectedRazdel == "")
                    selectedRazdel = dgvMain.Rows[razdelBindingSource.Position].Cells[0].Value.ToString();
            }
        }

        private void dgvTheme_Leave(object sender, EventArgs e)
        {
            if (!loadListThemes && !filterNewR && !filterNewT)
            {
                temaBindingSource.EndEdit();
                if (selectedTema == "")
                    selectedTema = dgvMain.Rows[temaBindingSource.Position].Cells[1].Value.ToString();
            }
        }

        private void btnFilterPrLr_Click(object sender, EventArgs e)
        {
            filterBsLitToReadAddPrLt();
        }

        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.Rows.Count == 1)
            {
                if (dgvMain.Rows[0].Cells[0].Value.ToString() != "" && dgvMain.Rows[0].Cells[1].Value.ToString() != "")
                {
                    dgvMain.DataSource = null;
                    dgvMain.DataSource = razdelBindingSource;
                }
            }
        }

        private static void ShowWaitingStatus()
        {
            WaitingStatus frmWait = new WaitingStatus();
            frmWait.ShowDialog();
        }

    }
}