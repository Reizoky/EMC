using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace EMC
{
    public partial class FormCTP : Form
    {
        DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
        bool res = false;
        ToolTip toolTip = new ToolTip();
        //int count = 0;
        public FormCTP()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавление или удаление столбца 
        /// с календарными сроками изучения тем добавленной группы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAddGroup_Click(object sender, EventArgs e)
        {
            // открытие формы "Настройка параметров групп"
            FormGroups formGroups = new FormGroups();
            formGroups.ShowDialog();
            // вызов метода, добавляющего столбец календарных сроков
            AddCalendarCol();
            // вызов метода, удаляющего столбец календарных сроков
            DeleteCalendarCol();
            // вызов метода, заполняющего столбец календарных сроков
            if (Groups.namesOfGroups.Count != 0)
                FillingCalendarCol();
        }

        private void FillingCalendarCol()
        {
            string[] file = File.ReadAllLines("Data\\Celebrations.txt");
            for (int i = 0; i < file.Count(); i++)
            {
                file[i] = string.Format("{0}.{1}", file[i], DateTime.Now.Year);
            }
            DateTime dt = Groups.dateStartSemester;
            int startDay = Convert.ToInt32(dt.DayOfWeek);
            int selGroup = 2;
            for (int j = 0; j < Groups.namesOfGroups.Count; j++)
            {
                selGroup++;
                dt = Groups.dateStartSemester;
                bool week = true;
                string[] schedule = Groups.scheduleGroup[Groups.namesOfGroups[j]].Split(';');
                int day = startDay;
                for (int i = 0; i < dgvPlan.Rows.Count - 1; i++)
                {
                    if (day != 7)
                    {
                        bool res = false;
                        for (int z = 0; z < file.Count(); z++)
                        {
                            if (dt.ToShortDateString() == file[z])
                            {
                                i--;
                                res = true;
                                break;
                            }
                        }
                        if (!res)
                        {
                            res = false;
                            string[] practicesOfGroup = Groups.practiceGroup[Groups.namesOfGroups[j].ToString()].Split(';');
                            if (practicesOfGroup[0] != "")
                            {
                                for (int k = 0; k < practicesOfGroup.Length; k++)
                                {
                                    DateTime practiceSince = Convert.ToDateTime(practicesOfGroup[k].Split('-')[0]);
                                    DateTime practiceFrom = Convert.ToDateTime(practicesOfGroup[k].Split('-')[1]);
                                    practiceFrom = practiceFrom.AddDays(1);
                                    if (practiceSince <= dt && practiceFrom >= dt)// || (dt.DayOfWeek == DayOfWeek.Sunday))
                                    {
                                        i--;
                                        res = true;
                                        break;
                                    }
                                }
                            }
                            if (!res)
                            {
                                if (week)
                                {
                                    for (int pare = 0; pare < 4; pare++)
                                    {
                                        if (schedule[((day - 1) * 4) + pare][0].ToString() != "-")
                                        {
                                            string s = schedule[((day - 1) * 4) + pare][0].ToString();
                                            if (i != dgvPlan.Rows.Count - 1)
                                            {
                                                if ((s == "Л" && dgvPlan.Rows[i].Cells[dgvPlan.Columns.Count - 3].Value.ToString() != "Лаб. занятие") ||
                                                    (s != "Л" && dgvPlan.Rows[i].Cells[dgvPlan.Columns.Count - 3].Value.ToString() == "Лаб. занятие"))
                                                {
                                                    dgvPlan.Rows[i].Cells[selGroup].Style.ForeColor = Color.Green;
                                                }
                                                dgvPlan.Rows[i].Cells[selGroup].Value = dt.ToShortDateString();
                                                i++;
                                            }
                                        }
                                    }
                                    i--;
                                }
                                else
                                {
                                    for (int pare = 0; pare < 4; pare++)
                                    {
                                        if (schedule[((day - 1) * 4) + pare][2] != '-')
                                        {
                                            string s = schedule[((day - 1) * 4) + pare][2].ToString();
                                            if (i != dgvPlan.Rows.Count - 1)
                                            {
                                                if ((s == "Л" && dgvPlan.Rows[i].Cells[dgvPlan.Columns.Count - 3].Value.ToString() != "Лаб. занятие") ||
                                                    (s != "Л" && dgvPlan.Rows[i].Cells[dgvPlan.Columns.Count - 3].Value.ToString() == "Лаб. занятие"))
                                                {
                                                    dgvPlan.Rows[i].Cells[selGroup].Style.ForeColor = Color.Green;
                                                }
                                                dgvPlan.Rows[i].Cells[selGroup].Value = dt.ToShortDateString();
                                                i++;
                                            }
                                        }
                                    }
                                    i--;
                                }
                            }
                        }
                        day++;
                    }
                    else
                    {
                        day = 1;
                        week = !week;
                        i--;

                    }
                    dt = dt.AddDays(1);

                }
            }

            for (int z = 0; z < dgvPlan.Rows.Count - 1; z++)
                if (Convert.ToDateTime(dgvPlan.Rows[z].Cells[selGroup].Value) > Groups.dateEndSemester)
                    dgvPlan.Rows[z].Cells[selGroup].Style.ForeColor = Color.Red;
        }

        private void DeleteCalendarCol()
        {
            bool res = false;
            for (int j = 3; j < dgvPlan.Columns.Count - 3; j++)
            {
                res = false;

                for (int i = 0; i < Groups.namesOfGroups.Count; i++)
                {
                    if (dgvPlan.Columns[j].Name.Contains(Groups.namesOfGroups[i]))
                    {
                        res = true;
                        break;
                    }
                }
                if (!res)
                    dgvPlan.Columns.Remove(dgvPlan.Columns[j]);
            }
        }

        private void AddCalendarCol()
        {
            for (int i = 0; i < Groups.namesOfGroups.Count; i++)
            {
                if (!dgvPlan.Columns.Contains(string.Format("TheDate_{0}", Groups.namesOfGroups[i])))
                {

                    CalendarColumn calendarCol = new CalendarColumn();
                    calendarCol.Name = string.Format("TheDate_{0}", Groups.namesOfGroups[i]);
                    calendarCol.HeaderText = string.Format("Календарные сроки изучения {0}", Groups.namesOfGroups[i]);
                    calendarCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvPlan.Columns.Insert(3 + i, calendarCol);
                }
            }
        }

        private void tsbLoadThemes_Click(object sender, EventArgs e)
        {
            LoadThemes();
            FillHeaders();
        }

        private void FillHeaders()
        {
            for (int i = 0; i < dgvPlan.Rows.Count - 1; i++)
            {
                dgvPlan.Rows[i].HeaderCell.Value = (i + 1).ToString();
                dgvPlan.Rows[i].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;
            }
        }

        /// <summary>
        /// Выбор и чтение файла со списком тем
        /// </summary>
        private void LoadThemes()
        {
            try
            {
                res = false;
                string str;
               
                // открытие окна выбора файла при чтении
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "Текстовый файл (*.txt)|*.txt|XML-файл (*.xml)|*.xml";
                // CSV (*.csv)|*.csv|Документ Word(*.docx)|*.docx
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    dgvPlan.Rows.Clear();
                    if (fd.FilterIndex == 1)
                    {
                        // чтение выбранного файла
                        StreamReader read = new StreamReader(fd.FileName, System.Text.Encoding.Default);
                        string[] file;
                        file = read.ReadToEnd().Split('\n');
                        for (int i = 0; i < file.Count(); i++)
                        {
                            dgvPlan.Rows.Add();
                            // заполнение столбца разделов и тем
                            dgvPlan.Rows[i].Cells[0].Value = file[i];
                            dgvPlan.Rows[i].Cells[1].Value = "2";
                            dgvPlan.Rows[i].Cells[2].Value = "1";
                            // вызов метода, заполняющего столбцы в соответствии с наименованием темы
                            str = FillingColumns(i);
                        }
                        read.Close();

                    }
                    else if (fd.FilterIndex == 2)
                    {
                        ReadXml(fd);
                    }
                }
            }
            // перехват ошибок чтения файла
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ReadXml(OpenFileDialog ofd)
        {
            dsCTP.Clear();
            dsCTP.ReadXml(ofd.FileName);

            var sod = from s in dsCTP.sod
                      join r in dsCTP.razdel on s.idR equals r.idR
                      join v in dsCTP.vid on s.idV equals v.idV
                      orderby s.idR, s.idT, s.idV, s.idS
                      select new
                      {
                          idR = r.idR,
                          idT = s.idT,
                          razd = string.Format("{0} {1}", r.idR, r.text),
                          tema = string.Format("{0}.{1}", s.idR, s.idT),
                          idV = s.idV,
                          idS = s.idS,
                          sod = s.text,
                          aud = s.aud,
                          sam = s.sam,
                          dop = s["textSam"] == DBNull.Value ? "" : s.textSam
                      };
            int i = 0;
            int countClassroomHours = 0;
            double countSelfStudyHours = 0;
            foreach (var s in sod)
            {
                //для запонления литературы
                var itemsLitTask = from x in dsCTP.sod_literatura
                                   where x.idR == s.idR && x.idT == s.idT && x.idS == s.idS &&
                                    x.idV == s.idV
                                   select new
                                   {
                                       x.idLit,
                                       x.read
                                   };
                string lit = "";
                if (itemsLitTask.Count() > 0)
                    foreach (var itemLit in itemsLitTask)
                        lit += string.Format(", [{0}] {1}",itemLit.idLit, itemLit.read);
                dgvPlan.Rows.Add();
                // заполнение столбца разделов и тем
                //dgvPlan.Rows[i].Cells[0].Value = s.sod;
                // подсчет количества часов аудиторной нагрузки
                countClassroomHours = (int)s.aud + countClassroomHours;
                // подсчет количества часов самостоятельной нагрузки
                countSelfStudyHours = s.sam + countSelfStudyHours;
                dgvPlan.Rows[i].Cells["NumberOfHours"].Value = string.Format("{0}/{1}", s.aud, countClassroomHours);
                dgvPlan.Rows[i].Cells["SelfStudy"].Value = string.Format("{0}/{1:0.0}", s.sam, countSelfStudyHours);
                dgvPlan.Rows[i].Cells["TypeOfEmployment"].Value = column.Items[s.idV-1].ToString();
                dgvPlan.Rows[i].Cells["Tasks"].Value = s.dop + lit;

                if (s.idV  == 2)
                {
                    dgvPlan.Rows[i].Cells[0].Value = string.Format("Лабораторное занятие №{0} {1}",s.idS,s.sod);
                    dgvPlan.Rows[i].Cells["VisualAids"].Value = "ПК";
                    dgvPlan.Rows[i].Cells[0].Style.BackColor = Color.PeachPuff;
                    if (s.dop == "")
                        dgvPlan.Rows[i].Cells["Tasks"].Value = "Отчет";

                }
                else if (s.idV == 3)
                {
                    dgvPlan.Rows[i].Cells[0].Value = string.Format("Практическое занятие №{0} {1}", s.idS, s.sod);
                    dgvPlan.Rows[i].Cells["VisualAids"].Value = "ПК";
                    if (s.dop == "")
                        dgvPlan.Rows[i].Cells["Tasks"].Value = "Отчет";
                    dgvPlan.Rows[i].Cells[0].Style.BackColor = Color.LightGreen;
                }
                else if (s.idV == 4)
                {
                    dgvPlan.Rows[i].Cells[0].Value = string.Format("Курсовое проектирование №{0} {1}", s.idS, s.sod);
                    dgvPlan.Rows[i].Cells["VisualAids"].Value = "ПК";
                    dgvPlan.Rows[i].Cells[0].Style.BackColor = Color.SandyBrown;
                }
                else
                    dgvPlan.Rows[i].Cells[0].Value = s.sod;
                i++;
            }
            res = true;
        }
        private string FillingColumns(int i)
        {
            string str;
            if (dgvPlan.Rows[i].Cells["TitleTheme"].Value != null)
            {               
                str = dgvPlan.Rows[i].Cells[0].Value.ToString();
                // проверка наименования темы 
                TypeOfWork(i, str);
                res = true;
            }
            else
                str = "";
            return str;
        }

        private void TypeOfWork(int i, string str)
        {
            if (str.Contains("Лабораторн"))
            {
                // запись значений, соответсвующих наименованию темы
                dgvPlan.Rows[i].Cells["TypeOfEmployment"].Value =
                    column.Items[1].ToString();
                dgvPlan.Rows[i].Cells["VisualAids"].Value = "ПК";
                dgvPlan.Rows[i].Cells["Tasks"].Value = "Отчет";
                dgvPlan.Rows[i].Cells[0].Style.BackColor = Color.PeachPuff;
            }
            else if (str.Contains("Практическ"))
            {
                dgvPlan.Rows[i].Cells["TypeOfEmployment"].Value = column.Items[2].ToString();
                dgvPlan.Rows[i].Cells["VisualAids"].Value = "ПК";
                dgvPlan.Rows[i].Cells["Tasks"].Value = "Отчет";
                dgvPlan.Rows[i].Cells[0].Style.BackColor = Color.LightGreen;
            }
            else if (str.Contains("Курсов") || str.Contains("КП"))
            {
                dgvPlan.Rows[i].Cells["TypeOfEmployment"].Value = column.Items[3].ToString();
                dgvPlan.Rows[i].Cells["VisualAids"].Value = "ПК";
                dgvPlan.Rows[i].Cells[0].Style.BackColor = Color.SandyBrown;
            }
            else
            {
                dgvPlan.Rows[i].Cells["TypeOfEmployment"].Value = column.Items[0].ToString();
                dgvPlan.Rows[i].Cells["VisualAids"].Value = "";
                dgvPlan.Rows[i].Cells["Tasks"].Value = "";
                dgvPlan.Rows[i].Cells[1].Style.BackColor = Color.White;
            }
        }

        private void dgvPlan_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 1)
            {
                for (int i = 3; i < dgvPlan.Columns.Count - 3; i++)
                {
                    if (dgvPlan.Rows[e.RowIndex].Cells[i].Style.ForeColor == Color.Red)
                        dgvPlan.Rows[e.RowIndex].Cells[i].ToolTipText = "Занятия не укладываются в рамки семестра.";
                    if (dgvPlan.Rows[e.RowIndex].Cells[i].Style.ForeColor == Color.Green)
                        dgvPlan.Rows[e.RowIndex].Cells[i].ToolTipText = "Данный тип занятия не по расписанию.";
                }
            }
        }

        private void tsbCelebrations_Click(object sender, EventArgs e)
        {
            FormCelebrations formCelebrations = new FormCelebrations();
            formCelebrations.ShowDialog();
        }

        private void FormCTP_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            column.Name = "TypeOfEmployment";
            column.HeaderText = "Вид занятия";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            column.Items.Add("Урок");
            column.Items.Add("Лаб. занятие");
            column.Items.Add("Пр. занятие");
            column.Items.Add("Курс. проект-е");
            dgvPlan.Columns.Insert(3, column);
            dgvPlan.TopLeftHeaderCell.Value = "№ темы";
            dgvPlan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlan.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPlan.RowHeadersWidth = 70;

            res = true;
        }

        private void tsbSaveCTP_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "CSV-table (*.csv)|*.csv|Документ Word(*.docx)|*.docx";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tspbSave.Visible = true;
                tspbSave.Value = 0;
                tspbSave.Maximum = dgvPlan.Rows.Count - 1;
                tsplSave.Text = "Сохранение шаблона:";
                FormCTP form = new FormCTP();
                form.Enabled = false;
                if (fd.FilterIndex == 1)
                    ToCsv(fd);
                else
                {
                    ToDocx(fd);
                }
            }
        }

        /// <summary>
        /// Сохранение шаблона КТП в файл *.docx
        /// </summary>
        /// <param name="fd"></param>
        private void ToDocx(SaveFileDialog fd)
        {
            //Создаём новый Word.Application
            Word._Application wordApp = new Word.Application();

            //Загружаем документ
            Word._Document wordDoc;
            Word.Paragraph wordParag;
            Word.Table wordTable;
            object missing = System.Reflection.Missing.Value;
            //создаём новый документ Word и задаём параметры листа
            wordDoc = wordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            wordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            // первый параграф
            wordParag = wordDoc.Paragraphs.Add(ref missing);

            // второй параграф, таблица
            object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;
            object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            wordParag.Range.Tables.Add(wordParag.Range, dgvPlan.Rows.Count, dgvPlan.Columns.Count, ref defaultTableBehavior, ref autoFitBehavior);
            wordTable = wordDoc.Tables[1];
            wordTable.Range.Font.Size = 10;
            wordTable.Range.Font.Name = "Times New Roman";
            wordTable.Range.Font.Bold = 0;

            wordTable.Borders.InsideColorIndex = Word.WdColorIndex.wdBlack;
            wordTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            wordTable.Borders.OutsideColorIndex = Word.WdColorIndex.wdBlack;
            wordTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            object fileName = fd.FileName;
            object trueValue = true;
            ////Указываем таблицу в которую будем помещать данные (таблица должна существовать в шаблоне документа!)
            //Microsoft.Office.Interop.Word.Table tbl = app.ActiveDocument.Tables[1];

            // заполнение таблицы
            for (int i = 0; i < dgvPlan.Columns.Count; i++)
            {
                // заполнение шапки таблицы
                wordTable.Rows[1].Cells[i + 1].Range.Text = dgvPlan.Columns[i].HeaderText;
            }

            int row = 2;
            // заполнение таблицы
            for (int i = 0; i < dgvPlan.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvPlan.Columns.Count; j++)
                {
                    // добавление строки в таблицу
                    if (dgvPlan.Rows[i].Cells[j].Value == null)
                    {
                        //dgvPlan.Rows[i].Cells[j].Value = " ";
                        // запись текста в таблицу
                        wordTable.Rows[row].Cells[j + 1].Range.Text = "";
                           // dgvPlan.Rows[i].Cells[j].Value.ToString().Trim();
                    }
                    else
                        wordTable.Rows[row].Cells[j + 1].Range.Text =
                            dgvPlan.Rows[i].Cells[j].Value.ToString().Trim();
                }
                row++;
                tspbSave.Value++;
            }

            //сохраняем документ, закрываем документ, выходим из Word
            wordDoc.SaveAs(ref fileName);
            wordDoc.Close();
            wordApp.Quit();
            tspbSave.Value = 0;
            tspbSave.Visible = false;
            tsplSave.Text = "Шаблон сохранен";

        }

        /// <summary>
        /// Сохранение шаблона КТП в формат *.csv
        /// </summary>
        /// <param name="fd"></param>
        private void ToCsv(SaveFileDialog fd)
        {
            using (StreamWriter sw = new StreamWriter(fd.FileName, true, Encoding.Default))
            {
                try
                {
                    for (int i = 0; i < dgvPlan.Columns.Count; i++)
                    {
                        // заполнение шапки таблицы
                        sw.Write("{0};", dgvPlan.Columns[i].HeaderText);
                    }
                    for (int i = 0; i < dgvPlan.Rows.Count-1; i++)
                    {
                        sw.WriteLine();
                        foreach (DataGridViewCell dc in dgvPlan.Rows[i].Cells)
                        {
                            if (dc.Value == null) // если ячейка равна null
                                sw.Write(" ;");   // то записать пробел
                            else if (dc.Value != null)
                            {
                                sw.Write("{0};",
                                    (dc.Value is DateTime) ? // если значение ячейки - дата
                                    ((DateTime)dc.Value).ToShortDateString() : // привести дату к маленькому формату
                                    (dc.ColumnIndex == 1 || dc.ColumnIndex == 2) ? // если столбец 1-й или 2-й
                                    string.Format(" {0}", dc.Value) : // поставить пробел перед значением
                                    dc.Value.ToString().Trim());
                            }
                        }
                        tspbSave.Value++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sw.Close();
                tspbSave.Value = 0;
                tsplSave.Text = "Шаблон сохранен";
                tspbSave.Visible = false;
            }
        }

        private void dgvPlan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string str;
            
            DateTime dt = new DateTime();
            if (res)
            {
                if (e.ColumnIndex == 0)
                {
                    str = FillingColumns(e.RowIndex);
                    dgvPlan.Rows[e.RowIndex].Cells[1].Value = "2";
                    dgvPlan.Rows[e.RowIndex].Cells[2].Value = "1";
                    if (Groups.namesOfGroups.Count != 0)
                    {
                        for (int i = 3; i < dgvPlan.Columns.Count - 3; i++)
                        {
                            if (dgvPlan.Rows[e.RowIndex].Cells[i].Value != null)
                            {
                                bool week = true;
                                if (dgvPlan.Rows[e.RowIndex].Cells[i].Value != null)
                                {
                                    dt = Convert.ToDateTime(dgvPlan.Rows[e.RowIndex].Cells[i].Value);
                                    int dtWeek = Convert.ToInt32(dt.DayOfWeek);
                                    if (dt <= Groups.dateEndSemester)
                                    {
                                        while (dt >= Groups.dateStartSemester)
                                        {
                                            week = !week;
                                            dt = dt.AddDays(-7);
                                        }

                                        if (week)
                                        {
                                            string[] schedule = Groups.scheduleGroup[Groups.namesOfGroups[i - 3]].Split(';');
                                            int n = 0;
                                            for (int ii = 0; ii < 4; ii++)
                                            {
                                                if (schedule[((dtWeek - 1) * 4) + ii][0].ToString() != "-")
                                                {
                                                    n++;
                                                }
                                            }

                                            bool result = true;
                                            int zz = 1;
                                            if (e.RowIndex - zz >= 0)
                                                while (result)
                                                {
                                                    if (e.RowIndex - zz < 0)
                                                    {
                                                        result = false;
                                                    }
                                                    else
                                                    {
                                                        if (dgvPlan.Rows[e.RowIndex].Cells[i].Value != null &&
                                                            Convert.ToDateTime(dgvPlan.Rows[e.RowIndex].Cells[i].Value) !=
                                                            Convert.ToDateTime(dgvPlan.Rows[e.RowIndex - zz].Cells[i].Value))
                                                        {
                                                            result = false;
                                                        }
                                                        else
                                                        {
                                                            zz++;
                                                        }
                                                    }
                                                }
                                            zz--;
                                            for (int iii = 0; iii <= zz; iii++)
                                            {
                                                if (schedule[((dtWeek - 1) * 4) + zz][0].ToString() == "-")
                                                {
                                                    zz++;
                                                }
                                            }
                                            string s = schedule[((dtWeek - 1) * 4) + zz][0].ToString();
                                            if ((s == "Л" && dgvPlan.Rows[e.RowIndex].Cells[dgvPlan.Columns.Count - 3].Value.ToString() == "Лаб. занятие") ||
                                                (s != "Л" && dgvPlan.Rows[e.RowIndex].Cells[dgvPlan.Columns.Count - 3].Value.ToString() != "Лаб. занятие"))
                                            {
                                                dgvPlan.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Black;
                                            }
                                            else
                                            {
                                                dgvPlan.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Green;
                                            }
                                        }
                                        else
                                        {
                                            string[] schedule = Groups.scheduleGroup[Groups.namesOfGroups[i - 3]].Split(';');
                                            int n = 0;
                                            for (int ii = 0; ii < 4; ii++)
                                            {
                                                if (schedule[((dtWeek - 1) * 4) + ii][0].ToString() != "-")
                                                {
                                                    n++;
                                                }
                                            }

                                            bool result = true;
                                            int zz = 1;
                                            if (e.RowIndex >= 0)
                                                while (result)
                                                {
                                                    if (e.RowIndex - zz < 0)
                                                    {
                                                        result = false;
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToDateTime(dgvPlan.Rows[e.RowIndex].Cells[i].Value) !=
                                                            Convert.ToDateTime(dgvPlan.Rows[e.RowIndex - zz].Cells[i].Value))
                                                        {
                                                            result = false;
                                                        }
                                                        else
                                                        {
                                                            zz++;
                                                        }
                                                    }
                                                }
                                            zz--;
                                            for (int iii = 0; iii <= zz; iii++)
                                            {
                                                if (schedule[((dtWeek - 1) * 4) + zz][2].ToString() == "-")
                                                {
                                                    zz++;
                                                }
                                            }
                                            string s = schedule[((dtWeek - 1) * 4) + zz][2].ToString();
                                            if ((s == "Л" && dgvPlan.Rows[e.RowIndex].Cells[dgvPlan.Columns.Count - 3].Value.ToString() == "Лаб. занятие") ||
                                                (s != "Л" && dgvPlan.Rows[e.RowIndex].Cells[dgvPlan.Columns.Count - 3].Value.ToString() != "Лаб. занятие"))
                                            {
                                                dgvPlan.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Black;
                                            }
                                            else
                                            {
                                                dgvPlan.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Green;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (e.ColumnIndex == 1)
                {
                    ReCalcAud();
                }

                if (e.ColumnIndex == 2)
                {
                    ReCalcSam();
                }
            }
        }

        private void ReCalcSam()
        {
            double countSelfStudyHours = 0;
            for (int i = 0; i < dgvPlan.Rows.Count - 1; i++)
            {
                if (dgvPlan.Rows[i].Cells[2].Value == null)
                    continue;                
                else
                {
                    string s = (dgvPlan.Rows[i].Cells[2].Value.ToString().Split('/'))[0];
                    double x;
                    double.TryParse(s, out x);
                    countSelfStudyHours += x;
                    if (x > 0)
                        dgvPlan.Rows[i].Cells[2].Value = string.Format("{0}/{1:0.0}", x, countSelfStudyHours);
                    else
                        dgvPlan.Rows[i].Cells[2].Value = null;
                }
            }
        }

        private void ReCalcAud()
        {
            int countClassroomHours = 0;
            for (int i = 0; i < dgvPlan.Rows.Count - 1; i++)
            {
                string s = (dgvPlan.Rows[i].Cells[1].Value.ToString().Split('/'))[0];
                int x;
                int.TryParse(s, out x);
                if (x == 0)
                    x = 2;
                countClassroomHours += x;
                dgvPlan.Rows[i].Cells[1].Value = string.Format("{0}/{1}", x, countClassroomHours);
            }
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            MoveRow(-1);
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            MoveRow(1);
        }

        private void MoveRow(int offset)
        {
            DataGridViewRow row = dgvPlan.CurrentRow;
            if (row.Index == 0 && offset == -1 || ((row.Index == dgvPlan.NewRowIndex - 1) &&
                offset == 1 || row.Index == dgvPlan.NewRowIndex))
                return; // Ничего делать не надо => выходим

            // Получаем текущий индекс строки
            int currentIndex = row.Index;
            // Удаляем ее из коллекции
            dgvPlan.Rows.Remove(row);
            // А теперь добавляем со смещением
            dgvPlan.Rows.Insert(currentIndex + offset, row);
            dgvPlan.CurrentCell = dgvPlan.Rows[currentIndex + offset].Cells[0];
            dgvPlan.Rows[currentIndex + offset].Selected = true;

            FillData();
        }

        private void FillData()
        {
            FillHeaders();
            ReCalcAud();
            ReCalcSam();
        }

        private void dgvPlan_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            FillData();
        }
    }
}