using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;

namespace EMC
{
    public partial class FormProgram : Form
    {
        DataTable dt;
        BindingSource bs = new BindingSource();
        public string path = string.Empty;
        //static object fname;
        List<string> countsRows = new List<string>();

        public FormProgram()
        {
            InitializeComponent();
        }

        private void FormProgram_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            dt = new DataTable();
            dt.Columns.Add("ck");
            dt.Columns.Add("preds");

            cbNameCommission.DataSource = dt;
            cbNameCommission.ValueMember = "ck";

            tbChairperson.DataBindings.Add("Text", dt, "preds");

            FillCK();

            lblAllTreb.Text = "";

            ChangeFilterMDK();

            lblR_MDK.Text = "МДК";
            lblR_MDKName.Text = "";
            nudRazdel.Enabled = false;
        }

        private void btnUpdateCommissions_Click(object sender, EventArgs e)
        {
            FormCyclicCommissions formCommissions = new FormCyclicCommissions();
            formCommissions.ShowDialog();

            FillCK();
        }

        private void FillCK()
        {
            try
            {
                //проверка нахождения файла CyclicCommissions.csv
                if (!File.Exists("Data//CyclicCommissions.csv"))
                {
                    MessageBox.Show("Файл \"Data//CyclicCommissions.csv\" не найден. Будет создан новый экземпляр.");
                    using (FileStream fs = File.Create("Data//CyclicCommissions.csv")) ;
                }

                string[] file = File.ReadAllLines("Data//CyclicCommissions.csv", Encoding.UTF8);
                string[] commission;

                dt.Clear();

                for (int i = 0; i < file.Count(); i++)
                {
                    commission = file[i].Split(';');
                    dt.Rows.Add(commission);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FormProgram.FillCK" + Environment.NewLine + ex.Message);
            }
        }

        private void StartFormProgress()
        {
            Application.Run(new FormProgressBar("Заполнение рабочей программы..."));
        }

        private void StartKOSPM()
        {
            Application.Run(new FormProgressBar("Заполнение КОС ПМ..."));
        }

        Word.Application app = null;
        Word.Document doc = null;
        bool workWithFile = false;
        private void btnDrawUpProgram_Click(object sender, EventArgs e)
        {
            CleanPerem();
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = "Документ Word(*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";
            //Word.Application app = new Word.Application();
            //Word.Document doc = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string pathFile = "";
                    if (rbPM.Checked)//доавленный функионал
                    {
                        pathFile = "Shablon//Pm.docx";
                        //проверка нахождения файла Pm
                        if (!File.Exists("Shablon//Pm.docx"))
                        {
                            MessageBox.Show("Файл \"Pm\" не найден. Укажите местонахождение файла");
                            OpenFileDialog ofd1 = new OpenFileDialog();
                            ofd1.Filter = "Документ Word(*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";
                            if (ofd1.ShowDialog() == DialogResult.OK)
                            {
                                pathFile = ofd1.FileName;
                            }
                            else
                                return;
                        }
                    }
                    else
                    {
                        pathFile = "Shablon//Discipline.docx";
                        //проверка нахождения файла Discipline
                        if (!File.Exists("Shablon//Discipline.docx"))
                        {
                            MessageBox.Show("Файл \"Discipline\" не найден. Укажите местонахождение файла");
                            OpenFileDialog ofd1 = new OpenFileDialog();
                            ofd1.Filter = "Документ Word(*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";
                            if (ofd1.ShowDialog() == DialogResult.OK)
                            {
                                pathFile = ofd1.FileName;
                            }
                            else
                                return;
                        }
                    }
                    Thread th = new Thread(new ThreadStart(StartFormProgress));
                    th.Start();
                    this.Enabled = false;

                    File.Copy(pathFile, ofd.FileName, true);
                    app = new Word.Application();
                    doc = app.Documents.Open(ofd.FileName);
                    workWithFile = true;
                    Word.Range wordRg = doc.Range();

                    object newfileName = ofd.FileName;

                    object missing = System.Reflection.Missing.Value;
                    string disc = string.Format("{0} {1}", cbDiscipline.SelectedValue, cbDiscipline.Text);
                    var d = from dis in dsFGOS.disc
                            join c in dsFGOS.cikl on dis.idCikl equals c.idCikl
                            select new
                            {
                                idCicl = c.idCikl,
                                name = c.name,
                                idD = dis.idDisc
                            };
                    string cikl = "";
                    foreach (var cicl in d)
                    {
                        if (cbDiscipline.SelectedValue.ToString() == cicl.idD)
                            cikl = cicl.name.ToLower();
                    }

                    var tr = from t in dsFGOS.treb
                             join dis in dsFGOS.disc on t.idDisc equals dis.idDisc
                             select new
                             {
                                 idD = dis.idDisc,
                                 idTr = t.idTreb,
                                 treb = t.text
                             };

                    string authors = "";
                    for (int row = 0; row < dgvAuthors.Rows.Count - 1; row++)
                        authors += string.Format("{0}, {1}{2}", dgvAuthors.Rows[row].Cells[0].Value,
                            dgvAuthors.Rows[row].Cells[1].Value, '\r', Environment.NewLine);

                    string experts = "";
                    for (int row = 0; row < dgvExperts.Rows.Count - 1; row++)
                        experts += string.Format("{0}, {1}{2}", dgvExperts.Rows[row].Cells[0].Value,
                            dgvExperts.Rows[row].Cells[1].Value, '\r');

                    if (rbDeveloped.Checked)
                    {
                        FindReplace(app, "%Compiled%", "разработана");
                        FindReplace(app, "%Compilers%", "Авторы:");
                    }
                    else
                    {
                        //сотавленена
                        FindReplace(app, "%Compiled%", "составлена");
                        //составители
                        FindReplace(app, "%Compilers%", "Составители:");
                    }

                    if (chbExampleProg.Checked)
                        FindReplace(app, "%ExampleProg%", "примерной программы учебной дисциплины");
                    else
                        FindReplace(app, ", %ExampleProg%", string.Empty);
                    //год
                    FindReplace(app, "%year%", string.Format("{0}", dtpYear.Value.Year));
                    //специальность
                    FindReplace(app, "%specialties%", dsFGOS.spec[0][0].ToString());
                    //дисциплина
                    FindReplace(app, "%discipline%", disc.ToUpper());
                    //цикловая комиссия
                    FindReplace(app, "%CyclicComission%", cbNameCommission.SelectedValue.ToString());
                    //председатель цикловой комиссии
                    FindReplace(app, "%Chairperson%", tbChairperson.Text);

                    FindReplace(app, "%Authors%", authors);
                    FindReplace(app, "%experts%", experts);
                    FindReplace(app, "%acadHours%", Hours(Convert.ToInt32(nudAcademicHours.Value)));
                    FindReplace(app, "%yourself%", Hours(Convert.ToInt32(nudYourselfHours.Value)));
                    FindReplace(app, "%maxHours%", Hours(Convert.ToInt32(lblSumHours.Text)));
                    //список литературы
                    string litAll = "";
                    string litAllDop = "";

                    var litAllItems = from x in ds.literatura
                                      join y in ds.sod_literatura on x.idLit equals y.idLit
                                      select new
                                      {
                                          x.idLit,
                                          lit = x.name,
                                          y.read,
                                          y.idR,
                                          y.idT,
                                          y.idS,
                                          y.idV,
                                          x.dopolnitelnaia
                                      };

                    int litAllIndex = 1;
                    int litAllDopIndex = 1;
                    foreach (var item in litAllItems)
                        if (item.dopolnitelnaia)
                            litAllDop += (litAllDopIndex++) + ". " + item.lit + "\n\r";
                        else
                            litAll += (litAllIndex++) + ". " + item.lit + "\n\r";

                    FindReplace(app, "%literaturaAll%", litAll);
                    FindReplace(app, "%literaturaAllDop%", litAllDop);
                    FindReplace(app, "%disciplineText%", cbDiscipline.Text.ToLower());

                    //оборудование
                    string oborudovanie = "";
                    int countRows = ds.oborudovanie.Rows.Count;
                    for (int i = 0; i < countRows; i++)
                        oborudovanie += "- " + ds.oborudovanie.Rows[i][0].ToString() +
                            ((i == countRows - 1) ? "." : ";") + "\n\r";
                    FindReplace(app, "%oborudovanie%", oborudovanie);

                    FindReplace(app, "%cikl%", cikl);
                    ListOfTrebov(cbDiscipline.SelectedValue.ToString(), app);

                    FindReplace(app, "%discDopusk%", DiscDopuskCreateString());

                    if (rbPM.Checked)
                    {
                        //таблицы 1.1 и 2
                        TableOfPkOk_PkList_OkResult(doc.Tables[2], doc.Tables[3],
                            doc.Tables[doc.Tables.Count]);
                        //таблица 3.1
                        TableOfThemaPlan(doc.Tables[doc.Tables.Count - 3]);
                        //таблица 3.2
                        ListOfThemes(doc.Tables[doc.Tables.Count - 2]);
                        //таблица 5{1}
                        TableOfResult(doc.Tables[doc.Tables.Count - 1]);
                    }
                    else
                    {
                        TableOfCompetences(app, doc, cbDiscipline.SelectedValue.ToString());
                        ListOfThemes(doc.Tables[doc.Tables.Count - 1]);
                        //TableOfTrebov(doc.Tables[doc.Tables.Count], cbDiscipline.SelectedValue.ToString(), app); //переименован в ListOfTrebov
                        TableOfHours(doc.Tables[doc.Tables.Count - 2]);
                        TableOfTrebovania(doc.Tables[doc.Tables.Count]);
                    }

                    //окончание работы с файлом
                    doc.SaveAs(ref newfileName);
                    Thread.Sleep(5000);
                    th.Abort();
                    this.Enabled = true;
                    MessageBox.Show("Рабочая программа успешно заполнена.");
                    Application.OpenForms[0].Activate();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    doc.Close();
                    app.Quit();
                    workWithFile = false;
                }
            }
        }

        /// <summary>
        /// Замена текста шаблона рабочей программы по дисциплине
        /// </summary>
        /// <param name="missing"></param>
        /// <param name="app"></param>
        /// <param name="oldStr"></param>
        /// <param name="newStr"></param>
        private static void FindReplace(Word.Application app, string oldStr, string newStr)
        {
            Word.Find findObject;
            object wrap, replace;
            int n = 255 - oldStr.Length;
            object missing = System.Reflection.Missing.Value;

            while (newStr.Length > 255)
            {
                string newStr2 = newStr.Substring(0, n) + oldStr;
                newStr = newStr.Remove(0, n);

                findObject = app.Selection.Find;
                findObject.Text = oldStr;
                findObject.Replacement.Text = newStr2;
                wrap = Word.WdFindWrap.wdFindContinue;
                replace = Word.WdReplace.wdReplaceAll;
                findObject.Execute(FindText: Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                    MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true, Wrap: wrap, Format: false,
                    ReplaceWith: missing, Replace: replace);
            }
            findObject = app.Selection.Find;
            findObject.Text = oldStr;
            findObject.Replacement.Text = newStr;
            wrap = Word.WdFindWrap.wdFindContinue;
            replace = Word.WdReplace.wdReplaceAll;
            findObject.Execute(FindText: Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true, Wrap: wrap, Format: false,
                ReplaceWith: missing, Replace: replace);

            /*if (insert.Length >255)
                MessageBox.Show(insert);*/
        }

        private void btnThemes_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "XML|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ds.Clear();
                    ds.ReadXml(ofd.FileName);
                    lblTheme.Text = Path.GetFileName(ofd.FileName);
                }

                FindNotUseTreb();
                ChangeEnableButtons();
            }
            catch (Exception ex)
            {
                lblTheme.Text = "-";
                MessageBox.Show(ex.ToString());
            }
        }

        private void nudAcademicHours_ValueChanged(object sender, EventArgs e)
        {
            nudYourselfHours.Maximum = nudAcademicHours.Value;
            lblSumHours.Text = (nudAcademicHours.Value + nudYourselfHours.Value).ToString();
        }

        private string Hours(int hour)
        {
            string hours;
            if (hour == 0)
                hours = "";
            else if (hour % 100 >= 10 && hour % 100 <= 20)
                hours = string.Format("{0} часов", hour);
            else if (hour % 10 == 1)
                hours = string.Format("{0} час", hour);
            else if (hour % 10 >= 5 || hour % 10 == 0)
                hours = string.Format("{0} часов", hour);
            else
                hours = string.Format("{0} часа", hour);
            return hours;
        }

        private void TableOfCompetences(Word.Application app, Word.Document doc, string idDisc)
        {
            //Выборка ОК
            var OkСompet = from comp in dsFGOS.okDisc
                           join dis in dsFGOS.disc on comp.idDisc equals dis.idDisc
                           join ok in dsFGOS.ok on comp.idOk equals ok.idOk
                           where comp.idDisc == idDisc
                           select new
                           {
                               idD = dis.idDisc,
                               idOk = comp.idOk,
                               textOk = ok.text
                           };
            //Выборка ПК
            var PkСompet = from comp in dsFGOS.pkDisc
                           join dis in dsFGOS.disc on comp.idDisc equals dis.idDisc
                           join pk in dsFGOS.pk on comp.idPk equals pk.idPk
                           where comp.idDisc == idDisc
                           select new
                           {
                               idD = dis.idDisc,
                               idPk = comp.idPk,
                               textPk = pk.text
                           };
            try
            {
                object start = 0;
                object end = 0;

                app.Selection.Find.Execute("%ok%");
                Word.Range wordRange = app.Selection.Range;
                Word.Table wordTable = doc.Tables.Add(wordRange, OkСompet.Count(), 2);
                wordTable = doc.Tables[1];
                wordTable.Range.Font.Bold = 0;
                //задаём ширину колонок
                doc.Tables[1].Columns[1].Width = 75;
                doc.Tables[1].Columns[2].Width = 400;
                int row = 0;
                foreach (var o in OkСompet)
                {
                    row++;
                    //Добавляем в таблицу строку.
                    wordTable.Rows[row].Cells[1].Range.Text = o.idOk;
                    wordTable.Rows[row].Cells[2].Range.Text = o.textOk;
                }

                if (PkСompet.Count() > 0)
                {
                    app.Selection.Find.Execute("%pk%");
                    wordRange = app.Selection.Range;
                    //wordRange.InsertParagraphAfter(); 
                    wordRange.InsertAfter("Профессиональные компетенции (ПК):");
                    wordRange.InsertParagraphAfter();
                    wordRange.SetRange(wordRange.End, wordRange.End);
                    wordTable = doc.Tables.Add(wordRange, PkСompet.Count(), 2);
                    wordTable = doc.Tables[2];
                    wordTable.Range.Font.Bold = 0;
                    doc.Tables[2].Columns[1].Width = 75;
                    doc.Tables[2].Columns[2].Width = 400;
                    row = 0;
                    foreach (var p in PkСompet)
                    {
                        row++;
                        //Добавляем в таблицу строку.
                        wordTable.Rows[row].Cells[1].Range.Text = p.idPk;
                        wordTable.Rows[row].Cells[2].Range.Text = p.textPk;
                    }
                    app.Selection.Find.Execute("%pk%");
                    wordRange = app.Selection.Range;
                    wordRange.Delete();
                }
                else
                {
                    Word.Find findObject;
                    object wrap = Word.WdFindWrap.wdFindContinue, replace;
                    object missing = System.Reflection.Missing.Value;
                    findObject = app.Selection.Find;
                    findObject.Text = "%pk%";
                    findObject.Replacement.Text = string.Empty;
                    wrap = Word.WdFindWrap.wdFindContinue;
                    replace = Word.WdReplace.wdReplaceAll;
                    findObject.Execute(FindText: Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                        MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true, Wrap: wrap, Format: false,
                        ReplaceWith: missing, Replace: replace);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            return;
        }

        private void btnFGOS_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "XML|*.xml";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    dsFGOS.Clear();
                    dsFGOS.ReadXml(ofd.FileName);

                    bs = new BindingSource();
                    bs.DataSource = dsFGOS.disc;

                    cbDiscipline.DataSource = bs; //dsFGOS.disc;
                    bs.Sort = "name";
                    cbDiscipline.ValueMember = "idDisc";
                    cbDiscipline.DisplayMember = "name";
                    lblFGOS.Text = Path.GetFileName(ofd.FileName);

                    ChangeEnableButtons();

                    ChangeR_MDKName();
                }
            }
            catch (Exception ex)
            {
                lblFGOS.Text = "-";
                MessageBox.Show(ex.ToString());
            }
        }

        private void ListOfThemes(Word.Table wordTable)
        {
            try
            {
                object m = System.Reflection.Missing.Value;
                List<string[]> allIdR = new List<string[]>();

                int n = 0;

                //объединение содержания и вида
                var a0 = from s in ds.sod
                         join v in ds.vid on s.idV equals v.idV
                         join r in ds.razdel on s.idR equals r.idR
                         orderby s.idR, s.idT, s.idV, s.idS
                         select new
                         {
                             razd = r.idR,
                             tema = s.idT,
                             idR = string.Format("{0} {1}", r.idR, r.text),
                             idT = string.Format("{0}.{1}", s.idR, s.idT),
                             idV = s.idV,
                             vid = v.text,
                             idS = s.idS,
                             sod = s.text,
                             aud = s.aud,
                             sam = s.sam
                         };
                // количество часов по разделам, темам и типам
                var b = from s in ds.sod
                        group s by new
                        {
                            idR = s.idR,
                            idT = s.idT,
                            idV = s.idV
                        } into g
                        orderby g.Key.idR, g.Key.idT, g.Key.idV
                        select new
                        {
                            idR = g.Key.idR,
                            idT = g.Key.idT,
                            idV = g.Key.idV,
                            aud = g.Sum(res => res.aud),
                            sam = g.Sum(res => res.sam)
                        };
                var tm = from t in ds.tema
                         join r in ds.razdel on t.idR equals r.idR
                         orderby t.idR, t.idT
                         select new
                         {
                             idR = r.idR,
                             idT = t.idT,
                             text = t.text,
                             urOsv = t.urOsvoen
                         };

                string razdel = "";
                string tema = "";
                string vid = "";
                double aud = 0, sam = 0, sumSam = 0;

                int a0Count = a0.Count();
                int a0i = 0;
                foreach (var str in a0)
                {
                    Double.TryParse(str.aud.ToString(), out aud);
                    Double.TryParse(str.sam.ToString(), out sam);

                    if (str.idR != razdel)
                    {
                        //wordTable.Cell(3, 4).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray375;
                        double audSum = 0, samSum = 0, sumRazdel = 0;
                        foreach (var chas in b)
                            if (chas.idR == str.razd)
                            {
                                audSum += chas.aud;
                                samSum += chas.sam;
                            }
                        sumRazdel += audSum + samSum;//сумма по разделу, всего аудиторных, всего сам
                        n = wordTable.Rows.Count;
                        razdel = str.idR;
                        wordTable.Cell(n, 1).Range.Bold = 1;
                        wordTable.Rows[n].Cells[1].Range.Text = "Раздел " + str.idR;
                        wordTable.Rows[n].Cells[3].Range.Text = sumRazdel.ToString();
                        wordTable.Rows.Add(ref m);

                        allIdR.Add(new string[] { n.ToString(), str.idR, sumRazdel.ToString() });//добавление номера строки, idR, сумма часов в список
                    }
                    if (str.idT != tema)
                    {
                        string nameT = "";
                        string uroven = "";
                        vid = "";

                        foreach (var t in tm)
                            if (str.tema == t.idT && str.razd == t.idR)
                            {
                                nameT = t.text;
                                uroven = t.urOsv;
                            }
                        n = wordTable.Rows.Count;
                        tema = str.idT;
                        wordTable.Rows[n].Cells[1].Range.Text = string.Format("Тема {0} {1}", str.idT, nameT);
                        wordTable.Cell(n, 4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        wordTable.Rows[n].Cells[4].Range.Text = uroven;
                    }

                    sumSam += sam;

                    if (str.idV.ToString() != vid)
                    {
                        string vidText = string.Empty;
                        string chasVid = "";
                        vid = str.idV.ToString();
                        foreach (var chas in b)
                            if (chas.idV.ToString() == vid && str.idT == string.Format("{0}.{1}", chas.idR, chas.idT))
                            {
                                chasVid = chas.aud.ToString();
                                break;
                            }
                        switch (vid)
                        {
                            case "1":
                                vidText = "Содержание учебного материала";
                                break;
                            case "2":
                                vidText = "Лабораторные занятия";
                                break;
                            case "3":
                                vidText = "Практические занятия";
                                break;
                            case "4":
                                vidText = "Контрольные работы";
                                break;
                            case "5":
                                vidText = "Курсовое проектирование";
                                break;
                        }
                        n = wordTable.Rows.Count;
                        wordTable.Cell(n, 2).Range.Bold = 1;
                        wordTable.Rows[n].Cells[2].Range.Text = vidText;
                        wordTable.Cell(n, 3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        wordTable.Rows[n].Cells[3].Range.Text = chasVid;
                        wordTable.Rows.Add(ref m);
                    }
                    n = wordTable.Rows.Count;
                    wordTable.Cell(n, 2).Range.Bold = 0;
                    wordTable.Rows[n].Cells[2].Range.Text = str.idS + " " + str.sod;
                    wordTable.Rows.Add(ref m);

                    a0i++;
                    if (a0i == a0Count ||
                        (a0i < a0Count && (str.razd != a0.ElementAt(a0i).razd || str.tema != a0.ElementAt(a0i).tema)))
                    {
                        n = wordTable.Rows.Count;
                        wordTable.Cell(n, 2).Range.Bold = 1;
                        wordTable.Rows[n].Cells[2].Range.Text = "Самостоятельная работа обучающихся";
                        wordTable.Rows.Add(ref m);
                        countsRows.Add(string.Format("{2}_{0};{1}", str.tema, FillSam(str.razd, str.tema, wordTable), str.razd));
                    }
                }
                n = wordTable.Rows.Count;
                wordTable.Cell(n, 3).Range.Bold = 1;
                wordTable.Cell(n, 4).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray375;
                wordTable.Rows[n].Cells[1].Range.Text = "Всего:";
                DataTable vsego = ds.Tables["sod"];
                var query = from s in vsego.AsEnumerable()
                            select s;
                double sum = Convert.ToDouble(query.Sum(r => r.Field<Single>("aud") + r.Field<Single>("sam")));
                wordTable.Rows[n].Cells[3].Range.Text = sum.ToString();
                wordTable.Cell(n, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                wordTable.Rows[n].Cells[1].Merge(wordTable.Rows[n].Cells[2]);


                // количество строк по разделам, темам и видам
                var countVid = from s in ds.sod
                               group s by new
                               {
                                   idR = s.idR,
                                   idT = s.idT,
                                   idV = s.idV
                               } into g
                               orderby g.Key.idR, g.Key.idT, g.Key.idV
                               select new
                               {
                                   idR = g.Key.idR,
                                   idT = g.Key.idT,
                                   idV = g.Key.idV,
                                   count = g.Count()
                               };

                int stroka = 3; // текущая строка
                int strokaLekciaEnd = -1;
                int strokaTemaStart = -1;
                int strokaR = -1;
                int strokaT = -1;
                int countSmeshen = 0;

                foreach (var countV in countVid)
                {
                    // смена раздела
                    if (strokaR != countV.idR)
                    {
                        strokaR = countV.idR;
                        stroka++;
                    }

                    int kolvo = countV.count;

                    if (strokaT != countV.idT || strokaR != countV.idR)//&& strokaR == countV.idR)
                    {
                        strokaT = countV.idT;
                        countSmeshen = 0;
                        strokaTemaStart = stroka - 1;

                        for (int i = 0; i < countsRows.Count; i++)
                        {
                            if (countsRows[i].Split(';')[0] == string.Format("{0}_{1}", countV.idR, countV.idT))
                            {
                                stroka += 1 + Convert.ToInt32(countsRows[i].Split(';')[1]);
                                countSmeshen = 1 + Convert.ToInt32(countsRows[i].Split(';')[1]);
                                break;
                            }
                        }
                    }

                    //записать кол-во часов на вид
                    wordTable.Cell(stroka - countSmeshen, 3).Merge(wordTable.Cell(stroka - countSmeshen + kolvo, 3));

                    if (countV.idV == 1)
                    {
                        wordTable.Cell(stroka - countSmeshen, 4).Merge(wordTable.Cell(stroka + kolvo - countSmeshen, 4));

                        if (strokaLekciaEnd > -1)
                        {
                            wordTable.Cell(strokaLekciaEnd, 4).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray375;
                            wordTable.Cell(strokaLekciaEnd, 4).Merge(wordTable.Cell(strokaTemaStart, 4));
                        }
                        strokaLekciaEnd = stroka + kolvo - countSmeshen + 1;
                    }

                    stroka += kolvo + 1;
                }

                if (strokaLekciaEnd > -1)
                {
                    wordTable.Cell(strokaLekciaEnd, 4).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray375;
                    wordTable.Cell(strokaLekciaEnd, 4).Merge(wordTable.Cell(wordTable.Rows.Count - 1, 4));
                }

                int sss = -1;
                int countsss = 0;
                List<string> ssss = new List<string>();
                for (int i = 1; i < wordTable.Rows.Count; i++)
                {
                    if (wordTable.Cell(i, 1).Range.Text.Substring(0, wordTable.Cell(i, 1).Range.Text.Length - 2) == "")
                    {
                        if (countsss == 0)
                            sss = i;

                        countsss++;
                    }
                    else
                    {
                        if (countsss == 0)
                            continue;

                        ssss.Add(string.Format("{0};{1}", sss - 1, countsss));
                        sss = -1;
                        countsss = 0;
                    }
                }

                if (countsss != 0)
                    ssss.Add(string.Format("{0};{1}", sss - 1, countsss));

                for (int i = 0; i < ssss.Count; i++)
                {
                    wordTable.Cell(Convert.ToInt32(ssss[i].Split(';')[0]), 1).Merge(wordTable.Cell(
                    Convert.ToInt32(ssss[i].Split(';')[0]) + Convert.ToInt32(ssss[i].Split(';')[1]), 1));
                }

                wordTable.Cell(3, 4).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray375;

                //вставка у ПМ МДК             
                if (rbPM.Checked)
                {
                    int rowInserted = 0;
                    int row = -1;
                    //список мдк для выбранной дисциплины
                    var mdkItem = (from x in dsFGOS.mdk
                                   where x.idDisc == cbDiscipline.SelectedValue.ToString()
                                   select new
                                   {
                                       x.idMdk,
                                       x.name
                                   }).ToList();
                    //вставка в таблицу МДК для каждого раздела
                    foreach (string[] item in allIdR)
                    {
                        row = Convert.ToInt32(item[0]);
                        wordTable.Cell(row + rowInserted, 1).Select();
                        app.Selection.InsertRowsBelow();
                        rowInserted++;
                        wordTable.Cell(row + rowInserted, 1).Range.Text = mdkItem[rowInserted - 1].idMdk + ". " +
                            mdkItem[rowInserted - 1].name;
                        wordTable.Cell(row + rowInserted, 3).Range.Text = item[2];
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int FillSam(int r, int t, Word.Table wordTable/*, out int countRows*/)
        {
            object m = System.Reflection.Missing.Value;
            var sodF = (ds.sod).Where(res => res.idR == r && res.idT == t);

            var dk = (from s in sodF
                      group s by new
                      {
                          idR = s.idR,
                          idT = s.idT,
                          idV = s.idV
                      } into g
                      orderby g.Key.idR, g.Key.idT, g.Key.idV
                      select new
                      {
                          idR = g.Key.idR,
                          idT = g.Key.idT,
                          idV = g.Key.idV,
                          textSam =
                           (g.Key.idV == 1) ? "Работа с учебной литературой, конспектами лекций" :
                           (g.Key.idV == 2) ? "Подготовка к лабораторным занятиям" :
                           (g.Key.idV == 3) ? "Подготовка к практическим занятиям" : "?",
                          sam = g.Sum(res => res.sam - (res["samDop"] == DBNull.Value ? 0 : res.samDop))
                      }).Where(res => res.sam > 0);

            //возвращение часов по темам на каждое уточнение сам.работы
            var l = (from s in sodF
                     where s["textSam"] != DBNull.Value
                     group s by new
                     {
                         idR = s.idR,
                         idT = s.idT,
                         textSam = s.textSam
                     } into g
                     orderby g.Key.idR, g.Key.idT, g.Key.textSam
                     select new
                     {
                         idR = g.Key.idR,
                         idT = g.Key.idT,
                         idV = 100,
                         textSam = g.Key.textSam,
                         sam = g.Sum(res => res.samDop)
                     }).Where(res => res.sam > 0);

            var dkl = dk.Union(l).OrderBy(res => res.idR).ThenBy(res => res.idT).ThenBy(res => res.idV);
            int row;
            foreach (var sodSam in dkl)
            {
                row = wordTable.Rows.Count;
                wordTable.Cell(row, 2).Range.Bold = 0;
                wordTable.Rows[row].Cells[2].Range.Text = sodSam.textSam;
                wordTable.Rows[row].Cells[3].Range.Text = sodSam.sam.ToString();
                wordTable.Rows.Add(ref m);
            }
            return dkl.Count();
            //BindingSource bbs = new BindingSource();
            //bbs.DataSource = dkl;
        }

        private void ListOfTrebovPM(string idDisc, Word.Application app)
        {
            try
            {
                var tr = from t in dsFGOS.treb
                         join dis in dsFGOS.disc on t.idDisc equals dis.idDisc
                         where t.idDisc == idDisc
                         select new
                         {
                             idD = dis.idDisc,
                             idTr = t.idTreb,
                             idTrTip = t.idTreb.Substring(0, t.idTreb.IndexOf('.')),
                             idTrNumber = Convert.ToInt32(t.idTreb.Substring(t.idTreb.IndexOf('.') + 1)),
                             treb = t.text
                         };

                //объединение содержания и типа
                var a0 = from s in ds.sod
                         join v in ds.vid on s.idV equals v.idV
                         join r in ds.razdel on s.idR equals r.idR
                         orderby s.idR, s.idT, s.idV, s.idS
                         select new
                         {
                             razd = r.idR,
                             tema = s.idT,
                             idR = string.Format("{0} {1}", r.idR, r.text),
                             idT = string.Format("{0}.{1}", s.idR, s.idT),
                             idV = s.idV,
                             vid = v.text,
                             idS = s.idS,
                             sod = s.text,
                             aud = s.aud,
                             sam = s.sam
                         };

                int n = 2;
                int trTip = 0;

                List<string> trDict = new List<string>();
                trDict.Add("ПО");
                trDict.Add("У");
                trDict.Add("З");

                string result = "";

                foreach (string s in trDict)
                {
                    string trebov = "";
                    string must;
                    var trCurr = tr.Where(res => res.idTrTip == s).OrderBy(res => res.idTrNumber);
                    var count = trCurr.Count();

                    if (count > 0)
                    {
                        if (s.Contains("У"))
                        {
                            must = "\rуметь:";

                        }
                        else if (s.Contains("З"))
                        {
                            must = "\rзнать:";
                        }
                        else
                        {
                            must = "\rиметь практический опыт:";
                        }

                        if (!rbPM.Checked)
                            must = string.Format("\rВ результате освоения учебной дисциплины обучающийся должен {0}\r",
                                must);
                        else
                            must += "\r";
                        foreach (var treb in trCurr)
                        {
                            trebov += treb.idTr + ". " + treb.treb + "\r";
                        }

                        result += must + trebov.Remove(trebov.Length - 2) + ".\r";
                    }
                }
                //требования
                FindReplace("%trebov%", result.Remove(result.Length - 1), 1);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            return;
        }

        private void ListOfTrebov(string idDisc, Word.Application app)
        {
            var tr = from t in dsFGOS.treb
                     join dis in dsFGOS.disc on t.idDisc equals dis.idDisc
                     where t.idDisc == idDisc
                     select new
                     {
                         idD = dis.idDisc,
                         idTr = t.idTreb,
                         idTrTip = t.idTreb.Substring(0, t.idTreb.IndexOf('.')),
                         idTrNumber = Convert.ToInt32(t.idTreb.Substring(t.idTreb.IndexOf('.') + 1)),
                         treb = t.text
                     };

            //объединение содержания и типа
            var a0 = from s in ds.sod
                     join v in ds.vid on s.idV equals v.idV
                     join r in ds.razdel on s.idR equals r.idR
                     orderby s.idR, s.idT, s.idV, s.idS
                     select new
                     {
                         razd = r.idR,
                         tema = s.idT,
                         idR = string.Format("{0} {1}", r.idR, r.text),
                         idT = string.Format("{0}.{1}", s.idR, s.idT),
                         idV = s.idV,
                         vid = v.text,
                         idS = s.idS,
                         sod = s.text,
                         aud = s.aud,
                         sam = s.sam
                     };

            int n = 2;
            int trTip = 0;

            List<string> trDict = new List<string>();
            trDict.Add("ПО");
            trDict.Add("У");
            trDict.Add("З");

            string result = "";

            foreach (string s in trDict)
            {
                string trebov = "";
                string must;
                var trCurr = tr.Where(res => res.idTrTip == s).OrderBy(res => res.idTrNumber);
                var count = trCurr.Count();

                if (count > 0)
                {

                    if (s.Contains("У"))
                    {
                        must = "\n\rуметь:";

                    }
                    else if (s.Contains("З"))
                    {
                        must = "\n\rзнать:";
                    }
                    else
                    {
                        must = "\rиметь практический опыт:";
                    }

                    if (!rbPM.Checked)
                        must = string.Format("\rВ результате освоения учебной дисциплины обучающийся должен {0}\r",
                            must);
                    else
                        must += "\n\r";

                    foreach (var treb in trCurr)
                    {
                        trebov += "- " + treb.treb + "\r";
                    }

                    result += must + trebov;
                }
            }
            //требования
            FindReplace("%trebov%", result.Remove(result.Length - 2), 1);
        }

        private void TableOfHours(Word.Table wordTable)
        {
            try
            {
                // количество часов по всем типам
                var d = from s in ds.sod
                        join v in ds.vid on s.idV equals v.idV
                        orderby s.idV
                        select new
                        {
                            idV = s.idV,
                            vid = v.text,
                            aud = s.aud,
                            sam = s.sam,
                            samDop = s["samDop"] == DBNull.Value ? 0 : s.samDop
                        };
                // количество часов по всем типам с группировкой
                var k = from t in d
                        group t by new
                        {
                            idV = t.idV,
                            vid = t.vid
                        } into g
                        orderby g.Key.idV
                        select new
                        {
                            idV = g.Key.idV,
                            vid = g.Key.vid,
                            aud = g.Sum(res => res.aud),
                            sam = g.Sum(res => res.sam - res.samDop)
                        };

                var l = from s in ds.sod
                        where s["textSam"] != DBNull.Value
                        group s by new
                        {
                            textSam = s.textSam
                        } into g
                        orderby g.Key.textSam
                        select new
                        {
                            textSam = g.Key.textSam,
                            sam = g.Sum(res => res.samDop)
                        };

                double max = Convert.ToDouble(k.Sum(r => r.aud + r.sam) + l.Sum(r => r.sam));
                double audSum = Convert.ToDouble(k.Sum(r => r.aud));
                double samSum = Convert.ToDouble(k.Sum(r => r.sam) + l.Sum(r => r.sam));
                wordTable.Cell(2, 2).Range.Text = max.ToString();
                wordTable.Cell(3, 2).Range.Text = audSum.ToString();
                wordTable.Cell(6, 2).Range.Text = samSum.ToString();
                int n = 5;
                string vid = "";
                foreach (var v in k)
                {
                    if (v.idV != 1)
                    {
                        if (v.idV.ToString() != vid)
                        {
                            string vidText = string.Empty;
                            vid = v.idV.ToString();
                            switch (vid)
                            {
                                case "2":
                                    vidText = "лабораторные занятия";
                                    break;
                                case "3":
                                    vidText = "практические занятия";
                                    break;
                                case "4":
                                    vidText = "контрольные работы";
                                    break;
                                case "5":
                                    vidText = "курсовое проектирование";
                                    break;
                            }
                            wordTable.Rows[n].Cells[1].Range.Bold = 0;
                            wordTable.Rows[n].Cells[1].Range.ParagraphFormat.FirstLineIndent = 30;
                            wordTable.Rows[n].Cells[1].Range.Text = vidText;
                            wordTable.Rows[n].Cells[2].Range.Bold = 0;
                            wordTable.Rows[n].Cells[2].Range.Text = v.aud.ToString();
                            if (n + 1 < 4 + k.Count())
                            {
                                n++;
                                object currow = wordTable.Rows[n];
                                wordTable.Rows.Add(ref currow);
                            }
                        }
                    }
                }

                n = wordTable.Rows.Count - 1;
                foreach (var v in k)
                {
                    if (v.idV.ToString() != vid)
                    {
                        string vidText = string.Empty;
                        vid = v.idV.ToString();
                        switch (vid)
                        {
                            case "1":
                                vidText = "работа с учебной литературой, стандартами, конспектами лекций";
                                break;
                            case "2":
                                vidText = "подготовка к лабораторным занятиям";
                                break;
                            case "3":
                                vidText = "подготовка к практическим занятиям";
                                break;
                        }
                        wordTable.Rows[n].Cells[1].Range.Bold = 0;
                        wordTable.Rows[n].Cells[1].Range.ParagraphFormat.FirstLineIndent = 30;
                        wordTable.Rows[n].Cells[1].Range.Text = vidText;
                        wordTable.Rows[n].Cells[2].Range.Bold = 0;
                        wordTable.Rows[n].Cells[2].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        wordTable.Rows[n].Cells[2].Range.Text = v.sam.ToString();
                        n++;
                        object currow = wordTable.Rows[n];
                        wordTable.Rows.Add(ref currow);
                    }
                }

                n = wordTable.Rows.Count - 1;
                int row = wordTable.Rows.Count;
                foreach (var dop in l)
                {
                    wordTable.Rows[n].Cells[1].Range.Bold = 0;
                    wordTable.Rows[n].Cells[1].Range.ParagraphFormat.FirstLineIndent = 30;
                    wordTable.Rows[n].Cells[1].Range.Text = dop.textSam;
                    wordTable.Rows[n].Cells[2].Range.Bold = 0;
                    wordTable.Rows[n].Cells[2].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wordTable.Rows[n].Cells[2].Range.Text = dop.sam.ToString();
                    if (n + 1 < row + l.Count() - 1)
                    {
                        n++;
                        object currow = wordTable.Rows[n];
                        wordTable.Rows.Add(ref currow);
                    }
                }
                wordTable.Cell(wordTable.Rows.Count, 1).Merge(wordTable.Cell(wordTable.Rows.Count, 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PastBaseInfo(Word.Application app)
        {
            string disc = cbDiscipline.Text;

            string authorsFirst = "";
            string authorsSecond = "";
            string authors = "";

            for (int row = 0; row < dgvAuthors.Rows.Count - 1; row++)
            {
                authorsFirst += dgvAuthors.Rows[row].Cells[0].Value.ToString() + Environment.NewLine;
                authorsSecond += dgvAuthors.Rows[row].Cells[0].Value.ToString() + ", ";

                authors += string.Format("{0}, {1}{2}", dgvAuthors.Rows[row].Cells[0].Value,
                           dgvAuthors.Rows[row].Cells[1].Value,
                           (row + 2 == dgvAuthors.Rows.Count) ? "" : Environment.NewLine);
            }

            string experts = "";
            for (int row = 0; row < dgvExperts.Rows.Count - 1; row++)
                experts += string.Format("{0}, {1}", dgvExperts.Rows[row].Cells[0].Value,
                    dgvExperts.Rows[row].Cells[1].Value) + Environment.NewLine;

            //год
            FindReplace(app, "%year%", string.Format("{0}", dtpYear.Value.Year));
            //специальность
            FindReplace(app, "%specialties%", dsFGOS.spec[0][0].ToString());
            //дисциплина
            if (rbPM.Checked)
            {
                string idDisc = cbDiscipline.SelectedValue.ToString();
                var nameMDK = (from x in dsFGOS.mdk
                               orderby x.idMdk
                               where x.idDisc == idDisc
                               select new
                               {
                                   x.idMdk,
                                   x.name
                               }).ToList();

                FindReplace(app, "%idDisc%",
                    nameMDK[Convert.ToInt32(nudRazdel.Value - 1)].idMdk);
                FindReplace(app, "%nameDisc%", 
                    nameMDK[Convert.ToInt32(nudRazdel.Value-1)].name.ToUpper());
                FindReplace(app, "%nameDiscSec%",
                    nameMDK[Convert.ToInt32(nudRazdel.Value - 1)].name);
            }
            else
            {
                FindReplace(app, "%idDisc%", cbDiscipline.SelectedValue.ToString());
                FindReplace(app, "%nameDisc%", disc.ToUpper());
                FindReplace(app, "%nameDiscSec%", cbDiscipline.Text.ToString());
            }
            //цикловая комиссия
            FindReplace(app, "%CyclicComission%", cbNameCommission.SelectedValue.ToString());

            FindReplace(app, "%AuthorsFirst%", authorsFirst);
            FindReplace(app, "%AuthorsSecond%", authorsSecond);
            FindReplace(app, "%Authors%", authors);
            FindReplace(app, "%experts%", experts);
            FindReplace(app, "%Chairperson%", tbChairperson.Text);
        }

        private void lblFGOSandThemes_TextChanged(object sender, EventArgs e)
        {
            btnDrawUpProgram.Enabled = lblTheme.Text != "-" && lblFGOS.Text != "-";
        }

        private void StartFormProcKOSMDK_KIM()
        {
            Application.Run(new FormProgressBar("Заполнение "+
                (rbPM.Checked?"КОС МДК":"КИМ")+"..."));
        }
        
        private void StartFormProcSborn()
        {
            Application.Run(new FormProgressBar("Заполнение " + forThreadText));
        }

        #region Новый_фукционал
        private void btnKIM_Click(object sender, EventArgs e)
        {
            KOSMDK_DiscCreate();
        }

        private void btnKOSMDK_Click(object sender, EventArgs e)
        {
            KOSMDK_DiscCreate();
        }

        private void btnKOS_Click(object sender, EventArgs e)
        {
            KOSPMCreate();
        }

        private void KOSPMCreate()
        {
            CleanPerem();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Документ Word(*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string pathFile = "Shablon//KOSPM.docx";

                    if (!File.Exists("Shablon//KOSPM.docx"))
                    {
                        MessageBox.Show("Файл \"KOSPM\" не найден. Укажите местонахождение файла");
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Filter = "Документ Word(*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            pathFile = ofd.FileName;
                        }
                        else
                            return;
                    }
                    //открытие потока на заполнение
                    Thread th = new Thread(new ThreadStart(StartKOSPM));
                    th.Start();
                    this.Enabled = false;
                    //копирование файла шаблона, подготовка к формированию
                    File.Copy(pathFile, sfd.FileName, true);
                    app = new Word.Application();
                    doc = app.Documents.Open(sfd.FileName);
                    workWithFile = true;
                    Word.Range wordRg = doc.Range();

                    object newFileName = sfd.FileName;

                    object missing = System.Reflection.Missing.Value;
                    //заполнение таблиц
                    //таблица 2
                    TableOfMDK_KOSPM(doc.Tables[2]);
                    //таблица 3
                    TableOfResult_KOSPM(doc.Tables[3]);
                    //таблицы 4
                    TableOfResultOk_KOSPM(doc.Tables[4]);
                    //список требований
                    ListOfTrebovPM(cbDiscipline.SelectedValue.ToString(), app);

                    FindReplace(app, "%idDisc%", lblIdDisc.Text);
                    FindReplace(app, "%nameDisc%",cbDiscipline.Text.ToUpper());
                    FindReplace(app, "%nameDiscSec%", cbDiscipline.Text);
                    //общие параметры



                    PastBaseInfo(app);

                    //окончание работы с файлом
                    doc.SaveAs(ref newFileName);
                    Thread.Sleep(5000);
                    th.Abort();

                    this.Enabled = true;
                    MessageBox.Show("Контрольно-измерительные материалы успешно составлены");
                    Application.OpenForms[0].Activate();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    doc.Close();
                    app.Quit();
                    workWithFile = false;
                }
            }
        }

        private void TableOfMDK_KOSPM(Word.Table wordTableOkResult)
        {
            object missing = System.Reflection.Missing.Value;
            int rowCurent = 3;//начало строки для заполнения
            var itemsMDK = from x in dsFGOS.mdk
                           where x.idDisc == cbDiscipline.SelectedValue.ToString()
                           select x;

            foreach (var item in itemsMDK)
            {
                wordTableOkResult.Cell(rowCurent++,1).Range.Text = item.idMdk + " " + item.name;
                wordTableOkResult.Rows.Add(ref missing);
            }
            wordTableOkResult.Cell(rowCurent, 1).Range.Text = "УП\\ПП";
        }

        private void TableOfResultOk_KOSPM(Word.Table wordTableOkResult)
        {
            string disc = cbDiscipline.SelectedValue.ToString();

            var itemsOK = (from x in dsFGOS.disc
                           join yx in dsFGOS.okDisc on x.idDisc equals yx.idDisc
                           join y in dsFGOS.ok on yx.idOk equals y.idOk
                           where x.idDisc == disc
                           select new
                           {
                               y.idOk,
                               name = y.text
                           }).Distinct();

            object missing = System.Reflection.Missing.Value;
            
            int n_OkReuslt = 1;
            foreach (var item in itemsOK)
            {
                wordTableOkResult.Rows.Add(ref missing);
                n_OkReuslt++;
                wordTableOkResult.Rows[n_OkReuslt].Cells[1].Range.Text = item.idOk + ".\r" + item.name;
                wordTableOkResult.Rows[n_OkReuslt].Cells[3].Range.Text = "Текущий контроль\r"+
                    "Наблюдение\rЭкспертная оценка";
            }

            wordTableOkResult.Rows[wordTableOkResult.Rows.Count].Delete();
            AddEndRowToResultTable_OkResult(wordTableOkResult);
        }

        private void TableOfResult_KOSPM(Word.Table wordTable)
        {
            string disc = cbDiscipline.SelectedValue.ToString();

            var items = (from x in ds.trebovania
                         join y in dsFGOS.treb on x.idTreb equals y.idTreb
                         join z in ds.pk_trebovania on y.idDisc equals z.idDisc
                         join yz in dsFGOS.pk on z.idPk equals yz.idPk
                         where (x.idV == 2 || x.idV == 3) && y.idDisc == disc &&
                            (x.idTreb[0] == 'У' || x.idTreb[0] == 'З')
                         orderby z.idPk, x.idR, y.idTreb, x.idT, x.idV, x.idS
                         select new ItemToResultTable(

                             x.idR,
                             x.idS,
                             x.idV,
                             z.idPk,
                             yz.text
                         )).Distinct().ToList<ItemToResultTable>();
            if (items.Count == 0) // если не установлены ПК
            {
                MessageBox.Show("Не найдены ПК");
                return;
            }
            //заполнение таблицы
            List<int[]> sod = new List<int[]>();
            string idPK = "";
            int idR = -1;

            string endString = "";//перечисление номеров тем №№1,2,4,6
            string namePK = "";//ПК
            //установка первых значений
            idPK = items[0].idPK;
            namePK = items[0].namePK;
            idR = items[0].idR;
            endString = "Раздел " + idR.ToString() + ":" + Environment.NewLine;
            //алгоритм по данному ПК
            foreach (ItemToResultTable item in items)
            {
                if (idPK != item.idPK)
                {
                    idR = item.idR;

                    endString = "Раздел " + idR.ToString() + ":" + Environment.NewLine + Environment.NewLine;
                    AddToStringToTrebTableRow(ref endString, sod);

                    AddRowToResultTable(idPK + ". " + namePK, endString, wordTable);

                    idPK = item.idPK;
                    namePK = item.namePK;

                    sod.Clear();
                }
                else if (idR != item.idR)
                {
                    idR = item.idR;
                    endString += "\n\nРаздел " + idR.ToString() + ":" + Environment.NewLine + Environment.NewLine; ;
                    AddToStringToTrebTableRow(ref endString, sod);
                }

                sod.Add(new int[] { item.idR, item.idS, item.idV });
            }

            AddRowToResultTable(idPK + ". " + namePK, endString, wordTable);
        }

        private void KOSMDK_DiscCreate()
        {
            CleanPerem();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Документ Word(*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Thread th = new Thread(new ThreadStart(StartFormProcKOSMDK_KIM));
                th.Start();
                this.Enabled = false;
                string pathKOS = "";

                if (rbPM.Checked)
                    pathKOS = "Shablon//KOSMDK.docx";
                else
                    pathKOS = "Shablon//KIM.docx";

                if (!File.Exists(pathKOS))
                {
                    MessageBox.Show("Файл \"" + pathKOS + "\" не найден. Укажите местонахождение файла");
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Документ Word(*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        pathKOS = ofd.FileName;
                    }
                    else
                        return;
                }

                app = new Word.Application();
                File.Copy(pathKOS, sfd.FileName, true);
                doc = app.Documents.Open(sfd.FileName);
                Word.Range wordRg = app.Selection.Range;
                object newFileName = sfd.FileName;
                try
                {
                    CreateStructKOS_DISC();
                    object missing = System.Reflection.Missing.Value;
                    PastBaseInfo(app);
                    if (rbPM.Checked)
                        TableOfTrebovania(doc.Tables[doc.Tables.Count],
                            Convert.ToInt32(nudRazdel.Value));
                    else
                    {
                        TableOfTrebovania(doc.Tables[doc.Tables.Count]);
                        //удаление последней строки для сохранения работы метода TableOfTrebovania(WordTable,int);
                        doc.Tables[doc.Tables.Count].Rows[doc.Tables[doc.Tables.Count].Rows.Count].Delete();
                    }

                    doc.SaveAs(ref newFileName);
                    Thread.Sleep(5000);
                    th.Abort();

                    this.Enabled = true;
                    MessageBox.Show((rbPM.Checked) ?
                        "Контрольно-оценочные средства успешно составлены" :
                        "Контрольно-измерительные материалы успешно составлены");
                    Application.OpenForms[0].Activate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    doc.Close();
                    app.Quit();
                }
            }
        }
       
        private void FormProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workWithFile)
            {
                doc.Close();
                app.Quit();
            }
        }

        struct ItemToTreb
        {
            public int idR, idT, idS, idV;
            public string idTreb, nameTreb;

            public ItemToTreb(int _idR, int _idT, int _idS, int _idV, string _idTreb, string _nameTreb)
            {
                idR = _idR;
                idT = _idT;
                idS = _idS;
                idV = _idV;
                idTreb = _idTreb;
                nameTreb = _nameTreb;
            }
        }

        int n = 1;
        private void TableOfTrebovania(Word.Table wordTable)
        {
            n = 1;
            try
            {
                string disc = cbDiscipline.SelectedValue.ToString();
                //умения
                var itemsY = from x in ds.trebovania
                             join y in dsFGOS.treb on x.idTreb equals y.idTreb
                             where (x.idV == 2 || x.idV == 3) && y.idDisc == disc && x.idTreb[0] == 'У'
                             orderby x.idTreb, x.idR, x.idV, x.idS
                             select new ItemToTreb(

                                 x.idR,
                                 x.idT,
                                 x.idS,
                                 x.idV,
                                 x.idTreb,
                                 y.text
                             );
                //знания
                var itemsZ = from x in ds.trebovania
                             join y in dsFGOS.treb on x.idTreb equals y.idTreb
                             where (x.idV == 2 || x.idV == 3) && y.idDisc == disc && x.idTreb[0] == 'З'
                             orderby x.idTreb, x.idR, x.idV, x.idS
                             select new ItemToTreb(

                                 x.idR,
                                 x.idT,
                                 x.idS,
                                 x.idV,
                                 x.idTreb,
                                 y.text
                             );

                //проверка наличия У и З
                if (itemsY.Count() > 0)
                {
                    FillPartTreb("Освоенные умения", itemsY.ToList<ItemToTreb>(), wordTable);
                }
                if (itemsZ.Count() > 0)
                {
                    FillPartTreb("Усвоенные знания", itemsZ.ToList<ItemToTreb>(), wordTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TableOfTrebovania" + Environment.NewLine + ex.Message);
            }
        }

        private void TableOfTrebovania(Word.Table wordTable, int idR)
        {
            n = 1;
            try
            {
                string disc = cbDiscipline.SelectedValue.ToString();
                //умения
                var itemsY = from x in ds.trebovania
                             join y in dsFGOS.treb on x.idTreb equals y.idTreb
                             where (x.idV == 2 || x.idV == 3) && y.idDisc == disc && x.idTreb[0] == 'У' &&
                                x.idR == idR
                             orderby x.idTreb, x.idR, x.idV, x.idS
                             select new ItemToTreb(

                                 x.idR,
                                 x.idT,
                                 x.idS,
                                 x.idV,
                                 x.idTreb,
                                 y.text
                             );
                //знания
                var itemsZ = from x in ds.trebovania
                             join y in dsFGOS.treb on x.idTreb equals y.idTreb
                             where (x.idV == 2 || x.idV == 3) && y.idDisc == disc && x.idTreb[0] == 'З' &&
                                x.idR == idR
                             orderby x.idTreb, x.idR, x.idV, x.idS
                             select new ItemToTreb(

                                 x.idR,
                                 x.idT,
                                 x.idS,
                                 x.idV,
                                 x.idTreb,
                                 y.text
                             );

                //проверка наличия У и З
                if (itemsY.Count() > 0)
                {
                    FillPartTreb("Освоенные умения", itemsY.ToList<ItemToTreb>(), wordTable);
                }
                if (itemsZ.Count() > 0)
                {
                    FillPartTreb("Усвоенные знания", itemsZ.ToList<ItemToTreb>(), wordTable);
                }
                wordTable.Rows[wordTable.Rows.Count].Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("TableOfTrebovania" + Environment.NewLine + ex.Message);
            }
        }

        private void FillPartTreb(string namePart, List<ItemToTreb> items, Word.Table wordTable)
        {
            AddRowToTrebTable(namePart, "", wordTable);//заголовок части

            List<int[]> sod = new List<int[]>();
            string idTreb = "";
            //int idR = -1;

            string endString = "";//перечисление номеров тем №№1,2,4,6
            string nameTreb = "";//требование
            //установка первых значений
            //idR = items[0].idR;
            idTreb = items[0].idTreb;
            nameTreb = items[0].nameTreb;
            //endString = "Раздел " + idR.ToString() + ":" + Environment.NewLine;
            endString = "";
            //алгоритм по данному требования
            foreach (ItemToTreb item in items)
            {
                if (idTreb != item.idTreb)
                {
                    endString = "";
                    AddToStringToTrebTableRow(ref endString, sod);

                    AddRowToTrebTable(nameTreb, endString, wordTable);

                    //idR = item.idR;
                    nameTreb = item.nameTreb;
                    //endString = "Раздел " + idR.ToString() + ":" + Environment.NewLine; ;
                    sod.Clear();

                    idTreb = item.idTreb;
                }
                //else if (idR != item.idR)
                //{
                //    idR = item.idR;
                //    endString += "\n\nРаздел " + idR.ToString() + ":" + Environment.NewLine; ;
                //    AddToStringToTrebTableRow(ref endString, sod);
                //}

                sod.Add(new int[] { item.idR, item.idS, item.idV });
            }

            AddRowToTrebTable(nameTreb, endString, wordTable); ;//добавление последней строки
        }

        private void AddToStringToTrebTableRow(ref string endString, List<int[]> sodList)
        {
            List<int> prItems = new List<int>();
            List<int> lrItems = new List<int>();

            foreach (int[] item in sodList)
                if (item[2] == 2)
                    lrItems.Add(item[1]);
                else
                    prItems.Add(item[1]);

            if (prItems.Count == 1)
                endString += "Практическая работа № " + prItems[0].ToString();
            else if (prItems.Count > 1)
            {
                prItems.Sort();

                endString += "Практические работы №№ ";
                for (int i = 0; i < prItems.Count; i++)
                {
                    endString += prItems[i].ToString() + ((i == prItems.Count - 1) ? "" : ", ");
                }
            }

            if (prItems.Count != 0 && lrItems.Count != 0)
                endString += Environment.NewLine;

            if (lrItems.Count == 1)
                endString += "Лабораторная работа № " + lrItems[0].ToString();
            else if (lrItems.Count > 1)
            {
                lrItems.Sort();

                endString += "Лабораторные работы №№ ";
                for (int i = 0; i < lrItems.Count; i++)
                {
                    endString += lrItems[i].ToString() + ((i == lrItems.Count - 1) ? "" : ", ");
                }
            }
        }

        int indexPartTable = 0;
        private void AddRowToTrebTable(string idTreb, string endString, Word.Table wordTable)
        {
            object missing = System.Reflection.Missing.Value;
            wordTable.Rows.Add(ref missing);
            n++;

            if (endString == "")//если вставка подзаголовка Освоенные умения\знания
            {
                wordTable.Rows[n].Cells[1].Range.Font.Name = "Times New Roman";
                wordTable.Rows[n].Cells[1].Range.Font.Bold = -1;
                wordTable.Rows[n].Cells[1].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                wordTable.Rows[n].Cells[1].Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphLeft;
                wordTable.Rows[n].Cells[1].Range.Text = idTreb;
                indexPartTable++;
            }
            else
            {
                wordTable.Rows[n].Cells[1].Range.Font.Name = "Times New Roman";
                wordTable.Rows[n].Cells[2].Range.Font.Name = "Times New Roman";

                wordTable.Rows[n].Cells[1].Range.Font.Bold = 0;
                wordTable.Rows[n].Cells[2].Range.Font.Bold = 0;

                wordTable.Rows[n].Cells[1].Range.ParagraphFormat.Alignment =
                   Word.WdParagraphAlignment.wdAlignParagraphLeft;
                wordTable.Rows[n].Cells[2].Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphLeft;
                //добавление статичных строк
                endString = "Текущий контроль:" + Environment.NewLine + Environment.NewLine +
                    endString + ((indexPartTable == 1) ?
                    Environment.NewLine + Environment.NewLine + "Наблюдение" + Environment.NewLine + "Анализ" + Environment.NewLine +
                    "Экспертная оценка"
                    : Environment.NewLine + Environment.NewLine + "Устный и письменный опрос");
                wordTable.Rows[n].Cells[1].Range.Text = idTreb;
                wordTable.Rows[n].Cells[2].Range.Text = endString;
            }
        }

        struct ItemToResultTable
        {
            public int idR, idS, idV;
            public string idPK, namePK;

            public ItemToResultTable(int _idR, int _idS,
                int _idV, string _idPK, string _namePK)
            {
                idR = _idR;
                idS = _idS;
                idV = _idV;
                idPK = _idPK;
                namePK = _namePK;
            }
        }

        private void TableOfResult(Word.Table wordTable)
        {
            string disc = cbDiscipline.SelectedValue.ToString();

            var items = (from x in ds.trebovania
                         join y in dsFGOS.treb on x.idTreb equals y.idTreb
                         join z in ds.pk_trebovania on y.idDisc equals z.idDisc
                         join yz in dsFGOS.pk on z.idPk equals yz.idPk
                         where (x.idV == 2 || x.idV == 3) && y.idDisc == disc &&
                            (x.idTreb[0] == 'У' || x.idTreb[0] == 'З')
                         orderby z.idPk, x.idR, y.idTreb, x.idT, x.idV, x.idS
                         select new ItemToResultTable(

                             x.idR,
                             x.idS,
                             x.idV,
                             z.idPk,
                             yz.text
                         )).Distinct().ToList<ItemToResultTable>();
            //заполнение таблицы
            List<int[]> sod = new List<int[]>();
            string idPK = "";
            int idR = -1;

            string endString = "";//перечисление номеров тем №№1,2,4,6
            string namePK = "";//ПК
            //установка первых значений
            idPK = items[0].idPK;
            namePK = items[0].namePK;
            idR = items[0].idR;
            endString = "Раздел " + idR.ToString() + ":" + Environment.NewLine;
            //алгоритм по данному ПК
            foreach (ItemToResultTable item in items)
            {
                if (idPK != item.idPK)
                {
                    idR = item.idR;

                    endString = "Раздел " + idR.ToString() + ":" + Environment.NewLine + Environment.NewLine;
                    AddToStringToTrebTableRow(ref endString, sod);

                    AddRowToResultTable(idPK + ". " + namePK, endString, wordTable);

                    idPK = item.idPK;
                    namePK = item.namePK;

                    sod.Clear();
                }
                else if (idR != item.idR)
                {
                    idR = item.idR;
                    endString += "\n\nРаздел " + idR.ToString() + ":" + Environment.NewLine + Environment.NewLine; ;
                    AddToStringToTrebTableRow(ref endString, sod);
                }

                sod.Add(new int[] { item.idR, item.idS, item.idV });
            }

            AddRowToResultTable(idPK + ". " + namePK, endString, wordTable);

            AddEndRowToResultTable_OkResult(wordTable);
        }

        private void AddRowToResultTable(string idPK, string endString, Word.Table wordTable)
        {
            object missing = System.Reflection.Missing.Value;
            wordTable.Rows.Add(ref missing);
            n++;
            wordTable.Rows[n].Cells[1].Range.Font.Name = "Times New Roman";
            wordTable.Rows[n].Cells[2].Range.Font.Name = "Times New Roman";
            wordTable.Rows[n].Cells[3].Range.Font.Name = "Times New Roman";

            wordTable.Rows[n].Cells[1].Range.Font.Bold = 0;
            wordTable.Rows[n].Cells[2].Range.Font.Bold = 0;
            wordTable.Rows[n].Cells[3].Range.Font.Bold = 0;

            wordTable.Rows[n].Cells[1].Range.ParagraphFormat.Alignment =
               Word.WdParagraphAlignment.wdAlignParagraphLeft;
            wordTable.Rows[n].Cells[2].Range.ParagraphFormat.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphLeft;
            wordTable.Rows[n].Cells[3].Range.ParagraphFormat.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphLeft;
            //добавление статичных строк
            endString = "Текущий контроль:" + Environment.NewLine +
                "Устный и письменный опрос по темам: " + Environment.NewLine + Environment.NewLine +
                endString + Environment.NewLine + Environment.NewLine +
                "Наблюдение" + Environment.NewLine +
                "Анализ" + Environment.NewLine +
                "Экспертная оценка";
            wordTable.Rows[n].Cells[1].Range.Text = idPK;
            wordTable.Rows[n].Cells[3].Range.Text = endString;
        }

        private void cbDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDiscipline.SelectedValue == null)
                return;
            lblIdDisc.Text = cbDiscipline.SelectedValue.ToString();

            var itemsR = (from x in ds.sod
                          select new
                          {
                              x.idR
                          }).Distinct();

            if(itemsR.Count() >0)
                nudRazdel.Maximum = Convert.ToDecimal(itemsR.Count());
            //проверка дисциплины на ПМ
            var pmOrDIsc = (from x in dsFGOS.disc
                            where x.idDisc == cbDiscipline.SelectedValue.ToString()
                            select new
                            {
                                x.pm
                            }).ToList();

            if (pmOrDIsc.Count == 1)
            {
                FindNotUseTreb();
                if (pmOrDIsc[0].pm)
                {
                    //выбор всех МДК выбранной дисциплины
                    var mdkItems = (from x in dsFGOS.mdk
                                    where x.idDisc == cbDiscipline.SelectedValue.ToString()
                                    select new
                                    {
                                        x.name
                                    }).ToList();
                    if (mdkItems.Count > 0)
                        lblR_MDKName.Text = mdkItems[Convert.ToInt32(nudRazdel.Value) - 1].name;
                    else
                        lblR_MDKName.Text = "";
                    rbPM.Checked = true;
                    ChangeR_MDKName();
                }
                else
                {
                    rbDisc.Checked = true;
                }
            }
        }

        private void FindNotUseTreb()
        {
            var itemsTreb = (from x in dsFGOS.treb
                             where x.idDisc == cbDiscipline.SelectedValue.ToString()
                             select x.idTreb).Distinct();

            var itemsTrebAdded = (from x in ds.trebovania
                                  select x.idTreb).Distinct();

            var items = itemsTreb.Except(itemsTrebAdded);//поиск всех неиспользованных требований

            string message = "";
            foreach (string item in items)
                message += " - " + item + Environment.NewLine;

            if (message != "")
            {
                lblAllTreb.Text = "Не все требования сопоставлены с работами";
                lblAllTreb.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblAllTreb.Text = "";
            }
        }

        private void TableOfPkOk_PkList_OkResult(Word.Table wordTablePKList, Word.Table wordTablePK_OK,
            Word.Table wordTableOkResult)
        {
            string disc = cbDiscipline.SelectedValue.ToString();

            var itemsPK = (from x in dsFGOS.disc
                           join yx in dsFGOS.pkDisc on x.idDisc equals yx.idDisc
                           join y in dsFGOS.pk on yx.idPk equals y.idPk
                           where x.idDisc == disc
                           select new
                           {
                               y.idPk,
                               name = y.text
                           }).Distinct();



            var itemsOK = (from x in dsFGOS.disc
                           join yx in dsFGOS.okDisc on x.idDisc equals yx.idDisc
                           join y in dsFGOS.ok on yx.idOk equals y.idOk
                           where x.idDisc == disc
                           select new
                           {
                               y.idOk,
                               name = y.text
                           }).Distinct();

            object missing = System.Reflection.Missing.Value;
            //добавление всех ПК
            int n = 1;//номер текущей строки
            foreach (var item in itemsPK)
            {
                wordTablePKList.Rows[n].Cells[1].Range.Text = item.idPk;
                wordTablePKList.Rows[n].Cells[2].Range.Text = item.name;
                wordTablePKList.Rows.Add(ref missing);

                wordTablePK_OK.Rows.Add(ref missing);
                wordTablePK_OK.Rows[n + 1].Cells[1].Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphLeft;
                wordTablePK_OK.Rows[n + 1].Cells[2].Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphJustify;
                wordTablePK_OK.Rows[n + 1].Cells[1].Range.Text = item.idPk;
                wordTablePK_OK.Rows[n + 1].Cells[2].Range.Text = item.name;

                n++;
            }

            wordTablePKList.Rows[wordTablePKList.Rows.Count].Delete();//удаление последней пустой строки

            n = wordTablePK_OK.Rows.Count;
            int n_OkReuslt = 1;
            foreach (var item in itemsOK)
            {
                wordTablePK_OK.Rows.Add(ref missing);
                n++;
                wordTablePK_OK.Rows[n].Cells[1].Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphLeft;
                wordTablePK_OK.Rows[n].Cells[2].Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphJustify;
                wordTablePK_OK.Rows[n].Cells[1].Range.Text = item.idOk;
                wordTablePK_OK.Rows[n].Cells[2].Range.Text = item.name;

                wordTableOkResult.Rows.Add(ref missing);
                n_OkReuslt++;
                wordTableOkResult.Rows[n_OkReuslt].Cells[1].Range.Text = item.idOk + ".\n\r" + item.name;
            }

            wordTableOkResult.Rows[wordTableOkResult.Rows.Count].Delete();
            AddEndRowToResultTable_OkResult(wordTableOkResult);
        }

        private string DiscDopuskCreateString()
        {
            string endStr = "";
            string selectedDisc = cbDiscipline.SelectedValue.ToString();

            var allPk = from x in dsFGOS.disc
                        join y in dsFGOS.pkDisc on x.idDisc equals y.idDisc
                        where x.idDisc == selectedDisc
                        select y.idPk;

            List<string[]> listItems = new List<string[]>();

            foreach (var item in allPk)
            {
                var itemsDisc = from x in dsFGOS.disc
                                join y in dsFGOS.pkDisc on x.idDisc equals y.idDisc
                                join z in dsFGOS.cikl on x.idCikl equals z.idCikl
                                where y.idPk == item && !x.pm
                                orderby x.idCikl
                                group x by x.idCikl into cicl
                                select new
                                {
                                    cicl
                                };

                foreach (var key in itemsDisc)
                {
                    foreach (var itemsKey in key.cicl)
                        listItems.Add(new string[] { itemsKey.idCikl, itemsKey.ciklRow.name, itemsKey.idDisc, itemsKey.name });
                }
            }

            listItems = (from x in listItems
                         orderby x[0], x[2]
                         select x).Distinct().ToList();

            for (int i = listItems.Count - 1; i > 0; i--)
                if (listItems[i][0] == listItems[i - 1][0] && listItems[i][2] == listItems[i - 1][2])
                    listItems.RemoveAt(i);

            var sortedItems = from x in listItems
                              group x by x[0];

            string ciclName = "";
            string ciclString = "";
            foreach (var item in sortedItems)
            {
                ciclName = "";
                ciclString = "";
                foreach (var itemKey in item)
                {
                    ciclName = itemKey[1].ToLower();
                    ciclString += itemKey[2] + ". " + itemKey[3] + ", ";
                }
                ciclString = "Обязательным условием для проведения занятий по профессиональному модулю" +
                    " является изучение " + ciclName + ": " + ciclString.Remove(ciclString.Length - 2) + ".\r";
                endStr += ciclString;
            }

            return endStr.Remove(endStr.Length - 2);
        }

        private void TableOfThemaPlan(Word.Table wordTable)
        {
            //пк по разделам
            var allPkOnRazdel = (from x in ds.razdel
                                 join y in ds.trebovania on x.idR equals y.idR
                                 join z in ds.pk_trebovania on y.idTreb equals z.idTreb
                                 where z.idDisc == cbDiscipline.SelectedValue.ToString()
                                 //group z by x.idR into xNew
                                 select new
                                 {
                                     x.idR,
                                     nameR = x.text,
                                     z.idPk
                                 }).Distinct().ToList();

            int rowStart = 5; //из-за объединенный строк получаем строка 5 - начало работы с данными, столбцов 10 - всего
            string pkAll = "";//строка с ПК
            int idR = allPkOnRazdel[0].idR;//номер раздела
            string nameR = allPkOnRazdel[0].nameR;//название раздела
            double sumRazdel = 0, audSum = 0, samSum = 0;//для часов
            double sumAllRazdel = 0, sumAllAud = 0, sumAllSum = 0;//подсчет всего времени

            foreach (var razdel in allPkOnRazdel)
            {
                if (idR == razdel.idR)
                {
                    pkAll += razdel.idPk + "\r";
                }
                else
                {
                    //заполнение строки разделом и ПК
                    wordTable.Cell(rowStart, 1).Range.Text = pkAll;
                    wordTable.Cell(rowStart, 2).Range.Text = string.Format("Раздел {0}. {1}", idR, nameR);

                    //заполнение часов
                    SumHoursOnRazdel(ref audSum, ref samSum, idR);
                    sumRazdel = audSum + samSum;
                    sumAllRazdel += sumRazdel;
                    sumAllAud += audSum;
                    sumAllSum += samSum;

                    wordTable.Cell(rowStart, 1).Range.Text = pkAll.Remove(pkAll.Length - 1);
                    wordTable.Cell(rowStart, 2).Range.Text = string.Format("Раздел {0}. {1}", idR, nameR);
                    wordTable.Cell(rowStart, 3).Range.Text = sumRazdel.ToString();
                    wordTable.Cell(rowStart, 4).Range.Text = audSum.ToString();
                    wordTable.Cell(rowStart, 5).Range.Text = (audSum - samSum).ToString();
                    wordTable.Cell(rowStart, 7).Range.Text = samSum.ToString();

                    idR = razdel.idR;
                    nameR = razdel.nameR;
                    pkAll = razdel.idPk + "\r";

                    wordTable.Cell(rowStart, 1).Select();
                    app.Selection.InsertRowsBelow(1);

                    rowStart++;
                }
            }
            //заполнение строки с последним разделом
            SumHoursOnRazdel(ref audSum, ref samSum, idR);
            sumRazdel = audSum + samSum;
            sumAllRazdel += sumRazdel;
            sumAllAud += audSum;
            sumAllSum += samSum;

            wordTable.Cell(rowStart, 1).Range.Text = pkAll.Remove(pkAll.Length - 1);
            wordTable.Cell(rowStart, 2).Range.Text = string.Format("Раздел {0}. {1}", idR, nameR);
            wordTable.Cell(rowStart, 3).Range.Text = sumRazdel.ToString();
            wordTable.Cell(rowStart, 4).Range.Text = audSum.ToString();
            wordTable.Cell(rowStart, 5).Range.Text = (audSum - samSum).ToString();
            wordTable.Cell(rowStart, 7).Range.Text = samSum.ToString();

            //заполнение строки итога
            int rowEnd = rowStart + 2;
            wordTable.Cell(rowEnd, 3).Range.Text = sumAllRazdel.ToString();
            wordTable.Cell(rowEnd, 4).Range.Text = sumAllAud.ToString();
            wordTable.Cell(rowEnd, 5).Range.Text = (sumAllAud - sumAllSum).ToString();
            wordTable.Cell(rowEnd, 7).Range.Text = sumAllSum.ToString();

        }

        private void SumHoursOnRazdel(ref double audSum, ref double samSum, int idR)
        {
            audSum = 0;
            samSum = 0;
            //для счета часов
            var b = from s in ds.sod
                    group s by new
                    {
                        idR = s.idR,
                        idV = s.idV
                    } into g
                    orderby g.Key.idR, g.Key.idV
                    select new
                    {
                        idR = g.Key.idR,
                        idV = g.Key.idV,
                        aud = g.Sum(res => res.aud),
                        sam = g.Sum(res => res.sam)
                    };
            foreach (var chas in b)
                if (chas.idR == idR)
                {
                    audSum += chas.aud;
                    samSum += chas.sam;
                }
        }

        private void AddEndRowToResultTable_OkResult(Word.Table wordTable)
        {
            object missing = System.Reflection.Missing.Value;
            
            wordTable.Rows.Add(ref missing);
            string endMDKString = "";
            var mdkItems = from x in dsFGOS.mdk
                           where x.idDisc == cbDiscipline.SelectedValue.ToString()
                           select x.idMdk;

            foreach (var item in mdkItems)
                endMDKString += item.ToString() + ": дифференцированный зачет,\n";
            endMDKString.Remove(endMDKString.Length - 2);

            int lustRowIndex = wordTable.Rows.Count;

            wordTable.Rows[lustRowIndex].Cells[3].Range.Text = endMDKString.Remove(endMDKString.Length - 2) + ".";
            wordTable.Rows[lustRowIndex].Cells[3].Range.Bold = -1;
            wordTable.Rows[lustRowIndex].Cells[2].Merge(wordTable.Rows[lustRowIndex].Cells[3]);
            wordTable.Rows[lustRowIndex].Cells[2].Range.ParagraphFormat.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphLeft;
        }

        bool znanSumAdd = false;
        bool umenSumAdd = false;
        private void CreateStructKOS_DISC()
        {
            int testTabl = doc.Tables.Count;
            #region CreateObj
            var itemsR = (from x in ds.sod
                          orderby x.idR, x.idT, x.idV, x.idS
                          where x.idV == 2 || x.idV == 3
                          group x by new
                          {
                              x.idR
                          } into raz
                          orderby raz.Key.idR
                          select new
                          {
                              raz.Key,
                              items = raz.GroupBy(idT => idT.idT).ToList()
                          }).ToList();

            Word.Range rngStartR = doc.Range();
            Word.Range rngEndR = doc.Range();

            Word.Range rngStartT = doc.Range();
            Word.Range rngEndT = doc.Range();

            Word.Range rngStartPr = doc.Range();
            Word.Range rngEndPr = doc.Range();

            Word.Range rngStartSam = doc.Range();
            Word.Range rngEndSam = doc.Range();

            Word.Range rngStartTest = doc.Range();
            Word.Range rngEndTest = doc.Range();

            //cброс форматирования из предыдущих операций поиска.
            rngStartR.Find.ClearFormatting();
            rngEndR.Find.ClearFormatting();

            rngStartT.Find.ClearFormatting();
            rngEndT.Find.ClearFormatting();

            rngStartPr.Find.ClearFormatting();
            rngEndPr.Find.ClearFormatting();

            rngStartSam.Find.ClearFormatting();
            rngEndSam.Find.ClearFormatting();

            rngStartTest.Find.ClearFormatting();
            rngEndTest.Find.ClearFormatting();
            #endregion
            int countR = itemsR.Count() - 1;
            int countT = 0, workT = 0;
            int countS = 0, workS = 0;
            int nomberR = 0, nomberR_I = 0;
            string idDisc = cbDiscipline.SelectedValue.ToString();
            string discName = (from x in dsFGOS.disc
                                orderby x.idDisc
                               where x.idDisc == idDisc
                               select x.name).First();
            int idRadelToCreate = Convert.ToInt32(nudRazdel.Value);
            int testIdR = -1, testIdT = -1;
            bool isPm = (from x in dsFGOS.disc
                          where x.idDisc == cbDiscipline.SelectedValue.ToString()
                          select x.pm).First();

            foreach (var itemR in itemsR)
            {
                nomberR++;
                //проверка на ПМ
                if (isPm)
                {
                    //проверка на какой раздел делать КОС
                    if (nomberR != idRadelToCreate)
                    {
                        continue;
                    }
                }
                else if (nomberR < itemsR.Count())
                {
                    rngStartR.Find.ClearFormatting();
                    rngEndR.Find.ClearFormatting();

                    rngStartR.Find.Execute("%startRPart%");
                    rngEndR.Find.Execute("%endRPart%");
                    CopyPart(rngStartR, rngEndR, "%startRPart%", "%endRPart%");
                }
                else
                {
                    FindReplace("%startRPart%", "", 1);
                    FindReplace("%endRPart%", "", 1);
                }

                countT = itemR.items.Count()-1;
                workT = 0;
                foreach (var itemsT in itemR.items)
                {
                    nomberR_I++;
                    if (countT != workT)//последняя тема в разделе
                    {
                        rngStartT.Find.ClearFormatting();
                        rngEndT.Find.ClearFormatting();

                        rngStartT.Find.Execute("%startThemePart%");
                        rngEndT.Find.Execute("%endThemePart%");
                        CopyPart(rngStartT, rngEndT, "%startThemePart%", "%endThemePart%");
                        workT++;
                    }
                    else
                    {
                        FindReplace("%startThemePart%", "", 1);
                        FindReplace("%endThemePart%", "", 1);
                    }
                    FindReplace("%indexR%",
                        !isPm? nomberR.ToString(): "",
                        1);
                    FindReplace("%nomberTheme%", itemsT.Key.ToString(), 1);
                    FindReplace("%nomberR_I%", nomberR_I.ToString(), 1);//номер раздела по счетчику
                    countS = itemsT.Count()-1;
                    workS = 0;
                    string nameTheme = "";
                    int nomberItem = 1;
                    foreach (var item in itemsT)
                    {
                        if (countS != workS)
                        {
                            rngStartPr.Find.ClearFormatting();
                            rngEndPr.Find.ClearFormatting();

                            rngStartPr.Find.Execute("%startPRPart%");
                            rngEndPr.Find.Execute("%endPRPart%");
                            CopyPart(rngStartPr, rngEndPr, "%startPRPart%", "%endPRPart%");

                            workS++;
                        }
                        else
                        {
                            FindReplace("%startPRPart%", "", 1);
                            FindReplace("%endPRPart%", "", 1);
                        }

                        FindReplace("%nomberR_I%", nomberR_I.ToString(), 1);//номер раздела по счетчику
                        FindReplace("%nomberT_I%", (nomberItem++).ToString(), 1);//номер темы по счетчику
                        FindReplace("%nomberPR%", item.idS.ToString(), 2);
                        FindReplace("%namePR%", item.text, 1);
                        FillZnanUmenPr(item.idR, item.idT, item.idS, item.idV, idDisc, true);
                        nameTheme = (from x in ds.tema
                                    where x.idT == item.idT && x.idR == item.idR
                                    select x.text).First();
                        //вид работы
                        FindReplace("%nameVid%",
                            item.idV == 2?"Лабораторная":"Практическая",
                            1);
                        FindReplace("%nameVidSbor%",
                             item.idV == 2 ? "лабораторных" : "практических",
                             1);
                        //название мдк
                        FindReplace("%discName%", discName, 1);
                        //время на подготовку
                        FillHoursKOS(item.idR, item.idT, item.idS, item.idV);
                    }
                    //вставка внеаудиторной самостоятельной работы пр\лр
                    string head = "";
                    string strDopKritSum = "";
                    foreach (var item in itemsT)
                    {
                        znanSumAdd = false;
                        umenSumAdd = false;
                        strDopKritSum = "";
                        if (item.sam != 0.0 && item.sam - item.samDop > 0.0)
                        {
                            rngStartSam.Find.ClearFormatting();
                            rngEndSam.Find.ClearFormatting();

                            rngStartSam.Find.Execute("%startAudSumPart%");
                            rngEndSam.Find.Execute("%endAudSumPart%");
                            CopyPart(rngStartSam, rngEndSam, "%startAudSumPart%", "%endAudSumPart%");

                            head = string.Format("подготовка к {0} работе № {1}, " +
                                "работа с учебной и специальной технической литературой",
                                       item.idV == 2 ? "лабораторной" : "практической",
                                       item.idS);

                            FindReplace("%nomberR_I_Sam%", nomberR_I.ToString(), 1);
                            FindReplace("%nomberT_I_Sam%", (nomberItem++).ToString(), 1);

                            FindReplace("%headSum%", head, 1);
                            FillZnanUmenPr(item.idR, item.idT, item.idS, item.idV, idDisc, false);

                            if (znanSumAdd && !umenSumAdd)
                                strDopKritSum = "усвоенных знаний";
                            else if (umenSumAdd && !znanSumAdd)
                                strDopKritSum = "освоенных умений";
                            else if (umenSumAdd && znanSumAdd)
                                strDopKritSum = "усвоенных знаний и освоенных умений";

                            FindReplace("%dopKritSam%", strDopKritSum, 1);
                            FindReplace("%litSum%",
                                CreateLitList(item.idR, item.idT, item.idS, item.idV)
                                , 1);
                            FillHoursKOS_Sum(item.sam - item.samDop);
                        }

                        znanSumAdd = false;
                        umenSumAdd = false;
                        strDopKritSum = "";
                        if (item.textSam != "" && item.samDop > 0.0)
                        {
                            rngStartSam.Find.ClearFormatting();
                            rngEndSam.Find.ClearFormatting();

                            rngStartSam.Find.Execute("%startAudSumPart%");
                            rngEndSam.Find.Execute("%endAudSumPart%");
                            CopyPart(rngStartSam, rngEndSam, "%startAudSumPart%", "%endAudSumPart%");

                            head = string.Format("подготовка к {0} работе № {1}, " +
                                "работа с учебной и специальной технической литературой",
                                       item.idV == 2 ? "лабораторной" : "практической",
                                       item.idS);

                            FindReplace("%nomberR_I_Sam%", nomberR_I.ToString(), 1);
                            FindReplace("%nomberT_I_Sam%", (nomberItem++).ToString(), 1);

                            FindReplace("%headSum%", head, 1);
                            FillZnanUmenPr(item.idR, item.idT, item.idS, item.idV, idDisc, false);

                            if (znanSumAdd && !umenSumAdd)
                                strDopKritSum = "усвоенных знаний";
                            else if (umenSumAdd && !znanSumAdd)
                                strDopKritSum = "освоенных умений";
                            else if (umenSumAdd && znanSumAdd)
                                strDopKritSum = "усвоенных знаний и освоенных умений";

                            FindReplace("%dopKritSam%", strDopKritSum, 1);
                            FindReplace("%litSum%", 
                                CreateLitList(item.idR, item.idT, item.idS, item.idV)
                                , 1);
                            FillHoursKOS_Sum(item.samDop);
                        }
                    }
                    //внеаудиторная работа по урокам
                        var itemsSamUrok = (from x in ds.sod
                                        orderby x.idR, x.idT, x.idS
                                        where x.idR == nomberR && x.idT == itemsT.Key &&
                                          x.idV == 1 && x.sam > 0.0
                                        select new
                                        {
                                            x.idR,
                                            x.idT,
                                            x.idS,
                                            x.text,
                                            x.sam,
                                            x.textSam,
                                            x.samDop
                                        }).ToList();
                    int countSum = itemsSamUrok.Count() - 1;
                    int workSum = 0;
                    foreach (var itemSam in itemsSamUrok)
                    {
                        znanSumAdd = false;
                        umenSumAdd = false;
                        strDopKritSum = "";
                        if (itemSam.sam > 0.0 && itemSam.sam - itemSam.samDop > 0.0)
                        {
                            rngStartSam.Find.ClearFormatting();
                            rngEndSam.Find.ClearFormatting();

                            rngStartSam.Find.Execute("%startAudSumPart%");
                            rngEndSam.Find.Execute("%endAudSumPart%");
                            CopyPart(rngStartSam, rngEndSam, "%startAudSumPart%", "%endAudSumPart%");
                            workSum++;
                            head = string.Format("подготовка по теме  «{0}», работа с учебной " +
                                    "и специальной технической литературой",
                                       itemSam.text);

                            FindReplace("%nomberR_I_Sam%", nomberR_I.ToString(), 1);
                            FindReplace("%nomberT_I_Sam%", (nomberItem++).ToString(), 1);

                            FindReplace("%headSum%", head, 1);
                            FillZnanUmenPr(itemSam.idR, itemSam.idT, itemSam.idS,
                                1, idDisc, false);

                            if (znanSumAdd && !umenSumAdd)
                                strDopKritSum = "усвоенных знаний";
                            else if (umenSumAdd && !znanSumAdd)
                                strDopKritSum = "освоенных умений";
                            else if (umenSumAdd && znanSumAdd)
                                strDopKritSum = "усвоенных знаний и освоенных умений";

                            FindReplace("%dopKritSam%", strDopKritSum, 1);
                            FindReplace("%litSum%",
                                CreateLitList(itemSam.idR, itemSam.idT, itemSam.idS, 1),
                                1);
                            FillHoursKOS_Sum(itemSam.sam - itemSam.samDop);
                        }

                        znanSumAdd = false;
                        umenSumAdd = false;
                        strDopKritSum = "";
                        if (itemSam.textSam != "" && itemSam.samDop > 0.0)
                        {
                            rngStartSam.Find.ClearFormatting();
                            rngEndSam.Find.ClearFormatting();

                            rngStartSam.Find.Execute("%startAudSumPart%");
                            rngEndSam.Find.Execute("%endAudSumPart%");
                            CopyPart(rngStartSam, rngEndSam, "%startAudSumPart%", "%endAudSumPart%");
                            workSum++;
                            head = string.Format("подготовка по теме  «{0}», {1}",
                                       itemSam.text, itemSam.textSam);

                            FindReplace("%nomberR_I_Sam%", nomberR_I.ToString(), 1);
                            FindReplace("%nomberT_I_Sam%", (nomberItem++).ToString(), 1);

                            FindReplace("%headSum%", head, 1);
                            FillZnanUmenPr(itemSam.idR, itemSam.idT, itemSam.idS,
                                1, idDisc, false);

                            if (znanSumAdd && !umenSumAdd)
                                strDopKritSum = "усвоенных знаний";
                            else if (umenSumAdd && !znanSumAdd)
                                strDopKritSum = "освоенных умений";
                            else if (umenSumAdd && znanSumAdd)
                                strDopKritSum = "усвоенных знаний и освоенных умений";

                            FindReplace("%dopKritSam%", strDopKritSum, 1);
                            FindReplace("%litSum%", 
                                CreateLitList(itemSam.idR, itemSam.idT, itemSam.idS, 1),
                                1);
                            FillHoursKOS_Sum(itemSam.samDop);
                        }
                    }
                    //закрытие последней внеауд. работы
                    rngStartSam.Find.ClearFormatting();
                    rngEndSam.Find.ClearFormatting();

                    rngStartSam.Find.Execute("%startAudSumPart%");
                    rngEndSam.Find.Execute("%endAudSumPart%");
                    Word.Range rngDelLastSum = doc.Range();
                    rngDelLastSum.Start = rngStartSam.Start;
                    rngDelLastSum.End = rngEndSam.End;
                    rngDelLastSum.Text = "";

                    FindReplace("%nameTheme%", nameTheme, 1);//имя темы
                    //тест

                    FindReplace("%nomberR_I_Test%", nomberR_I.ToString(), 1);
                    FindReplace("%nomberT_I_Test%", (nomberItem++).ToString(), 1);
                    FindReplace("%nameTest%", nameTheme, 1);
                    var allZnanUmen = from x in ds.trebovania
                                      join y in dsFGOS.treb on x.idTreb equals y.idTreb
                                      where x.idR == testIdR && x.idT == testIdT && x.idTreb[0] == 'З'
                                      && y.idDisc == idDisc
                                      orderby y.idTreb
                                      select new
                                      {
                                          x.idV,
                                          y.idTreb,
                                          nameTreb = y.text
                                      };
                    string znanTest = "";
                    foreach (var item in allZnanUmen)
                        znanTest += "- " + item.nameTreb + ";\r";
                    znanTest = (znanTest != "")?znanTest.Remove(znanTest.Length - 2) + ".":
                        znanTest = "-";
                    FindReplace("%znanTest%", znanTest, 1);
                }
                if (rbPM.Checked && nomberR == idRadelToCreate)
                {
                    FindReplace("%startRPart%", "", 1);
                    FindReplace("%endRPart%", "", 1);
                    break;
                }
            }
        }

        private void FillZnanUmenPr(int idR, int idT, int idS, int idV, string idDisc, bool pr)
        {
            //получение списка знаний умений
            var allZnanUmen = from x in ds.trebovania
                              join y in dsFGOS.treb on x.idTreb equals y.idTreb
                              where x.idR == idR && x.idT == idT && x.idS == idS 
                                && x.idV == idV && y.idDisc == idDisc
                              orderby y.idTreb
                              select new
                              {
                                  x.idV,
                                  y.idTreb,
                                  nameTreb = y.text
                              };

            string znan = "", umen = "";

            foreach (var item in allZnanUmen)
            {
                if (item.idTreb[0] == 'У')
                    umen += "- " + item.nameTreb + "\r";
                else
                    znan += "- " + item.nameTreb + "\r";
            }

            if (znan != "")
            {
                FindReplace(pr ? "%znanPR%" : "%znanPR_Sam%", znan.Remove(znan.Length - 2) + ".", 1);
                znanSumAdd = true;
            }
            else
            {
                FindReplace(pr ? "%znanPR%" : "%znanPR_Sam%", "abbbbs", 1);
                FindReplace("\rзнания:\rabbbbs", "", 1);
            }

            if (umen != "")
            {
                FindReplace(pr ? "%umenPR%" : "%umenPR_Sam%", umen.Remove(umen.Length - 2) + ".", 1);
                umenSumAdd = true;
            }
            else
            {
                FindReplace(pr ? "%umenPR%" : "%umenPR_Sam%", "abbbbs", 1);
                FindReplace("\rумения:\rabbbbs", "", 1);
            }
        }

        private string CreateLitList(int idR, int idT, int idS, int idV)
        {
            string litList = "";
            var litAll = from x in ds.sod_literatura
                         join y in ds.literatura on x.idLit equals y.idLit
                         where x.idR == idR && x.idT == idT && x.idS == idS && x.idV == idV
                         select y.name;
            foreach (var lit in litAll)
                litList += "- " + lit + ";\r";
            if (litList != "")
                litList = litList.Remove(litList.Length - 2) + ".";
            else
                litList = "-";
            return litList;
        }
        
        private void FillHoursKOS(int idR, int idT, int idS, int idV)
        {
            var hoursSingle = (from x in ds.sod
                        where x.idR == idR && x.idT == idT && x.idS == idS
                          && x.idV == idV
                        select new
                        {
                            x.aud
                        }).First();
            int hoursAll = Convert.ToInt32(hoursSingle.aud.ToString());
            
            int min = (hoursAll * 45) % 60;
            int hour = (hoursAll * 45) / 60;
            int minPrep_Done = 5 * hoursAll / 2;
            string time = "", timePrep_Done = "", timeWork = "";

            time += Hours(hour)+" ";
            time += min.ToString() + " мин.";

            hour = (hoursAll * 45 - minPrep_Done*2) / 60;
            min = (hoursAll * 45 - minPrep_Done*2) % 60;

            timeWork += Hours(hour)+" ";
            timeWork += min.ToString() + " мин.";

            timePrep_Done = minPrep_Done + " мин.";

            FindReplace("%audHoursAll%", time, 1);
            FindReplace("%audHoursPrep_Done%", timePrep_Done, 1);
            FindReplace("%audHoursPrep_Done%", timePrep_Done, 1);
            FindReplace("%audHoursToWork%", timeWork, 1);
        }

        private void FillHoursKOS_Sum(float hoursAll)
        {
            int min = (int)((hoursAll * 45) % 60);
            int hour = (int)((hoursAll * 45) / 60);
            string time = "";

            time += hour == 0 ? "" : Hours(hour) + " ";
            time += min.ToString() + " мин";

            FindReplace("%sumTime%", time, 1);
        }

        private void CopyPart(Word.Range startRange, Word.Range endRange, string fillNull1, string fillNull2)
        {
            int start = -1, end = -1;//для тестирвоания
            Word.Range rngAll = doc.Range();
            rngAll.Find.ClearFormatting();

            rngAll.Start = startRange.Start;
            rngAll.End = endRange.End;
            rngAll.Select();
            start = startRange.Start;
            end = endRange.End;
            rngAll.Copy();

            rngAll.Start = endRange.End;
            rngAll.End = endRange.End;
            rngAll.Select();
            rngAll.Paste();

            FindReplace(fillNull1, "", 1);
            FindReplace(fillNull2, "", 1);
        }
        /// <summary>
        /// Замена исходной строки на новую n-раз
        /// </summary>
        /// <param name="oldStr">Исходная строка</param>
        /// <param name="newStr">Новая строка</param>
        /// <param name="countReplace">Количество замен</param>
        private void FindReplace(string oldStr, string newStr, int countReplace)
        {
            Word.Range rng = doc.Range();
            //цикл с количеством замен
            for (int i = 0; i< countReplace; i++)
            {
                //очищение формата поиска
                rng.Find.ClearFormatting();
                //нахолждение исходной строки
                rng.Find.Execute(oldStr);
                //замена найденно строки
                rng.Text = newStr;
            }
        }

        private void nudRazdel_ValueChanged(object sender, EventArgs e)
        {
            ChangeR_MDKName();
        }

        private void ChangeR_MDKName()
        {
            //если дисциплина является ПМ
            if (rbPM.Checked)
            {
                lblR_MDK.Text = "МДК";
                //выбор всех МДК выбранной дисциплины
                var mdkList = (from x in dsFGOS.mdk
                               where x.idDisc == cbDiscipline.SelectedValue.ToString()
                               orderby x.idMdk
                               select x.name).ToList();
                //выбор заполнения поля в соотвествии с найденным МДК или его отутствием
                if (mdkList.Count > 0)
                    lblR_MDKName.Text = mdkList[Convert.ToInt32(nudRazdel.Value) - 1].ToString();
                else
                    lblR_MDKName.Text = "МДК не найдены";
            }
            else
            {
                lblR_MDKName.Text = "";
            }
        }

        /// <summary>
        /// изменение доступности кнопок
        /// </summary>
        private void ChangeEnableButtons()
        {
            if (lblFGOS.Text != "-" && lblTheme.Text != "-")
            {
                tlpRBItems.Enabled = true;
                cbDiscipline.Enabled = true;
                dtpYear.Enabled = true;
                lblYear.Enabled = true;
                gbRP.Enabled = true;
                tlpButtonsToWork.Enabled = true;
                lblIdDisc.Enabled = true;
                lblR_MDK.Enabled = true;
                lblR_MDKName.Enabled = rbPM.Checked;
                lblR_MDK.Enabled = rbPM.Checked;
                nudRazdel.Enabled = rbPM.Checked;

                btnDrawUpProgram.Enabled = true;
                btnLab.Enabled = true;
                btnPract.Enabled = true;
                btnTests.Enabled = true;
                btnKOS.Enabled = rbPM.Checked;
                btnKOSMDK.Enabled = rbPM.Checked;
                btnKIM.Enabled = !rbPM.Checked;
            }
        }

        private void rbPM_CheckedChanged(object sender, EventArgs e)
        {
            ChangeR_MDKName();
            ChangeDisc();
        }

        private void rbDisc_CheckedChanged(object sender, EventArgs e)
        {
            ChangeDisc();
        }

        private void ChangeDisc()
        {
            ChangeEnableButtons();
            ChangeFilterMDK();

            if (cbDiscipline.Items.Count > 0)
                cbDiscipline.SelectedIndex = 0;

            lblIdDisc.Text = cbDiscipline.SelectedValue.ToString();
        }

        private void btnSborniki_Click(object sender, EventArgs e)
        {
            CreateSborniki(((Button)sender).Tag.ToString());
        }

        private void ChangeFilterMDK()
        {
            bs.RemoveFilter();
            bs.Filter = "pm = " + ((rbPM.Checked) ? "true" : "false");
        }

        string forThreadText = "";
        private void CreateSborniki(string type)
        {
            CleanPerem();
            string pathFile = "";
            if (type == "Lab")
            {
                pathFile = "Shablon//SbornLaboratorn.docx";
                forThreadText = "сборника лабораторных работ. . .";
            }
            else if (type == "Pract")
            {
                pathFile = "Shablon//SbornPractich.docx";
                forThreadText = "сборника практических работ. . .";
            }
            else if (type == "Test")
            {
                pathFile = "Shablon//SbornTest.docx";
                forThreadText = "сборника тестов. . .";
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Документ Word(*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Thread th = new Thread(new ThreadStart(StartFormProcSborn));
                th.Start();
                this.Enabled = false;

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Файл \"" + pathFile + "\" не найден. Укажите местонахождение файла");
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Документ Word(*.docx)|*.docx|Документ Word 2003 (*.doc)|*.doc";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        pathFile = ofd.FileName;
                    }
                    else
                        return;
                }


                app = new Word.Application();
                File.Copy(pathFile, sfd.FileName, true);
                doc = app.Documents.Open(sfd.FileName);
                Word.Range wordRg = app.Selection.Range;
                object newFileName = sfd.FileName;
                try
                {
                    CreateSbornicLabPract(type);

                    PastBaseInfo(app);

                    doc.SaveAs(ref newFileName);
                    Thread.Sleep(5000);
                    th.Abort();

                    this.Enabled = true;
                    MessageBox.Show("Сборник " +
                        ((type == "Lab") ? "лабораторных работ" : ((type == "Pract") ? "практических работ" : "тестов"))
                        + " успешно составлены");
                    Application.OpenForms[0].Activate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    doc.Close();
                    app.Quit();
                }
            }
        }

        private void CreateSbornicLabPract(string type)
        {

            //ds.vid.AddvidRow(1, "урок");
            //ds.vid.AddvidRow(2, "лаб");
            //ds.vid.AddvidRow(3, "практ");
            //ds.vid.AddvidRow(4, "КП/КР");


            var listItems = (from x in ds.sod
                             orderby x.idR, x.idT, x.idS
                             where x.idV == 2
                             select new
                             {
                                 x.idR,
                                 x.idT,
                                 x.idS,
                                 x.idV,
                                 x.text
                             }).Distinct();
            Word.Range rngStartPart = doc.Range(), rngEndPart = doc.Range();
            string typeFullForTable = "", litList = "";

            var timeAllPractLab = from x in ds.sod
                                  orderby x.idR, x.idT, x.idS
                                  where x.idV == 2
                                  select new
                                  {
                                      sum = x.aud
                                  };

            if (type == "Lab")
            {
                typeFullForTable = "Лабораторная работа №";
            }
            else if (type == "Test")
            {
                listItems = (from x in ds.sod
                             orderby x.idR, x.idT, x.idS
                             select new
                             {
                                 x.idR,
                                 x.idT,
                                 x.idS,
                                 x.idV,
                                 x.text
                             }).Distinct();
                typeFullForTable = "Тест №";
            }
            else if (type == "Pract")
            {
                listItems = (from x in ds.sod
                             orderby x.idR, x.idT, x.idS
                             where x.idV == 3
                             select new
                             {
                                 x.idR,
                                 x.idT,
                                 x.idS,
                                 x.idV,
                                 x.text
                             }).Distinct();
                typeFullForTable = "Практическая работа №";

                timeAllPractLab = from x in ds.sod
                                  orderby x.idR, x.idT, x.idS
                                  where x.idV == 3
                                  select new
                                  {
                                      sum = x.aud
                                  };
            }
            int pageIndex = 4;
            int indexForTest = 1;
            //время лабораторных и практических
            if (type != "Test")
            {
                int timeMinut = Convert.ToInt32((timeAllPractLab.Sum(x => x.sum) / 1) * 60 + (timeAllPractLab.Sum(x => x.sum) % 1) * 30);
                string timeStr = Hours(timeMinut / 60) +
                    ((timeMinut % 60 == 0) ? "" : " " + timeMinut % 60 + " мин.");
                FindReplace("%hours%", timeStr, 1);
            }
            foreach (var item in listItems)
            {
                //проверка на ПМ
                if (rbPM.Checked)
                {
                    if (item.idR < Convert.ToInt32(nudRazdel.Value))
                        continue;
                    if (item.idR > Convert.ToInt32(nudRazdel.Value))
                        break;
                }

                rngStartPart.Find.ClearFormatting();
                rngEndPart.Find.ClearFormatting();

                rngStartPart.Find.Execute("%startPart%");
                rngEndPart.Find.Execute("%endPart%");
                CopyPart(rngStartPart, rngEndPart, "%startPart%", "%endPart%");

                if (type != "Test")
                {
                    FindReplace("%number%", item.idS.ToString(), 1);
                    FindReplace("%name%", item.text, 1);

                    //литература
                    var litItems = from xS in ds.sod_literatura
                                   join y in ds.literatura on xS.idLit equals y.idLit
                                   where xS.idR == item.idR && xS.idT == item.idT &&
                                   xS.idS == item.idS && xS.idV == item.idV
                                   select new
                                   {
                                       y.name
                                   };
                    litList = "";
                    foreach (var itemLit in litItems)
                        litList += itemLit.name + ";\r";
                    litList = litList == "" ? "-" : litList.Remove(litList.Length - 2) + ".";
                    FindReplace("%literatura%", litList, 1);

                    AddItemToTableSborn(typeFullForTable + item.idS, (pageIndex).ToString());
                    pageIndex += 2;
                }
                else
                {
                    FindReplace("%number%", indexForTest.ToString(), 1);
                    FindReplace("%indexThemeTest%", item.idR + "." + item.idT, 1);
                    FindReplace("%nameTest%", item.text, 1);

                    AddItemToTableSborn(string.Format("{0}. Тема {1}.{2} {3} (??? вопросов)",
                        typeFullForTable + indexForTest,
                        item.idR, item.idT, item.text),
                        (pageIndex++).ToString());
                    indexForTest++;
                }
            }
            //удаление последних пустных элементов
            rngStartPart.Find.ClearFormatting();
            rngEndPart.Find.ClearFormatting();

            Word.Range rngDelLastSum = doc.Range();

            rngStartPart.Find.Execute("%startPart%");
            rngEndPart.Find.Execute("%endPart%");
            rngDelLastSum.Start = rngStartPart.Start;
            rngDelLastSum.End = rngEndPart.End + 2;
            rngDelLastSum.Text = "";

            if (type == "Test")
                AddItemToTableSborn("Перечень правильных ответов", pageIndex.ToString());
            doc.Tables[1].Rows[doc.Tables[1].Rows.Count].Delete();
        }

        private void AddItemToTableSborn(string firstColumn, string secondColumn)
        {
            Word.Table wordTable = doc.Tables[1];
            int rows = wordTable.Rows.Count;
            wordTable.Cell(rows, 1).Range.Text = firstColumn;
            wordTable.Cell(rows, 2).Range.Text = secondColumn;

            wordTable.Rows.Add();
        }

        /// <summary>
        /// Приводит значение глобальных переменных к начальным состояниям перед началом работы с файлами
        /// </summary>
        private void CleanPerem()
        {
            forThreadText = "";
            znanSumAdd = false;
            umenSumAdd = false;
            n = 1;
        }
        #endregion

    }
}