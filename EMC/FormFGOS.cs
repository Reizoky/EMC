using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;

namespace EMC
{
    public partial class FormFGOS : Form
    {
        bool flag;
        object fileName;
        bool findLastPM = false;

        public FormFGOS(bool flag, string fileName)
        {
            UpdateEvent.save = new UpdateEvent.UpdateEventHandler(this.Save);
            //CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.Reload);
            InitializeComponent();
            this.flag = flag;
            this.fileName = fileName;
        }

        private void FormFGOS_Shown(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;

                if (flag)
                {
                    object missing = System.Reflection.Missing.Value;

                    Word.Application app = new Word.Application();
                    Word.Document doc = app.Documents.Open(ref fileName);
                    Word.Range wr = doc.Paragraphs[4].Range;

                    string txt = "специальности";
                    string _spec = wr.Text;

                    _spec = _spec.Remove(0, _spec.IndexOf(txt));
                    dsFGOS.spec.AddspecRow(_spec.Substring(txt.Length, _spec.IndexOf("\"") - txt.Length).Trim());

                    Object start = 0;
                    Object end = doc.Characters.Count;
                    wr = doc.Range(ref start, ref end);

                    //rtb.Text = string.Empty;
                    string res = string.Empty;

                    //чтение всех ОК и ПК
                    LoadAllCompetences(doc);

                    try
                    {
                        string cikl = string.Empty;
                        string ciklFull = string.Empty;

                        int rowPM = doc.Tables[4].Rows.Count;
                        int rowStart = 3;

                        prb.Style = ProgressBarStyle.Continuous;
                        prb.Maximum = doc.Tables[4].Rows.Count;

                        for (int row = rowStart; !findLastPM && row < doc.Tables[4].Rows.Count; row++)
                        {
                            prb.Value = row + 1;

                            // дисциплина (по неск.ячеек на ПМ)
                            try
                            {
                                bool isPM = row > rowPM;////////////////////////

                                string disc;
                                string idDisc, nameDisc;
                                // дисциплина или цикл
                                disc = doc.Tables[4].Cell(row, 5).Range.Text.Replace('\r', ' ').Replace('\a', ' ');
                                disc = disc.Trim();// disc.Remove(disc.IndexOf('\0'));

                                if (disc.Length == 0 && !isPM) // цикл
                                {
                                    if (ReadCikl(doc, out cikl, out ciklFull, row))
                                    {
                                        lbl.Text = string.Empty;
                                        break;
                                    }

                                    if (cikl.Equals("ОП.00"))
                                        continue;
                                    else if (cikl.Contains("ПМ.00"))
                                    {
                                        rowPM = row;
                                        isPM = row > rowPM;
                                    }
                                    if (!isPM)
                                        dsFGOS.cikl.AddciklRow(cikl, ciklFull);
                                }
                                else
                                {
                                    // mdk detected
                                    if (isPM)
                                    {
                                        try
                                        {
                                            ReadCikl(doc, out cikl, out ciklFull, row);
                                            if (!findLastPM)
                                                dsFGOS.disc.AdddiscRow(cikl, dsFGOS.cikl.Last(), isPM, ciklFull);
                                            findLastPM = disc == string.Empty;
                                        }
                                        catch { }
                                        finally
                                        {
                                            if (!findLastPM)
                                            {
                                                idDisc = disc.Remove(disc.IndexOf(". "));
                                                nameDisc = disc.Substring(disc.IndexOf(". ") + 2);
                                                dsFGOS.mdk.AddmdkRow(idDisc, dsFGOS.disc.Last(), nameDisc);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        idDisc = disc.Remove(disc.IndexOf(". "));
                                        nameDisc = disc.Substring(disc.IndexOf(". ") + 2);
                                        dsFGOS.disc.AdddiscRow(idDisc, dsFGOS.cikl.Last(), isPM, nameDisc);
                                    }
                                }

                                lbl.Text = cikl + ": " + disc;

                                // знать уметь
                                if (disc != string.Empty)
                                    ReadTrebov(doc, row);

                                // ок и пк
                                ReadOkPk(doc, row);
                            }
                            catch
                            {
                            }
                        }
                        prb.Value = prb.Maximum;
                        lbl.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        doc.Close();
                        app.Quit();
                    }
                    CreateTreeView();
                }
                else
                {
                    dsFGOS.ReadXml(fileName.ToString());
                    CreateTreeView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Чтение всех компетенций
        /// </summary>
        /// <param name="doc"></param>
        private void LoadAllCompetences(Word.Document doc)
        {
            Word.Range rng = doc.Content;
            rng.Find.Forward = true;
            rng.Find.Text = "V. ТРЕБОВАНИЯ";
            object charUnit = Word.WdUnits.wdSection;
            object move = 1;  // move left 1
            rng.Find.Execute();

            rng.MoveEnd(ref charUnit, 1);
            rng.Select();
            string[] arr = rng.Text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string _ok = @"^(?<ok_i>ОК \d{1,2}). (?<ok_full>.+)$"; // паттерн поиска ОК
            string _pk = @"^(?<pk_i>ПК \d{1,2}.\d{1,2}). (?<pk_full>.+)$"; // паттерн поиска ПК

            string _end = @"^5.3.+";

            foreach (string input in arr)
            {
                if (Regex.IsMatch(input, _end, RegexOptions.IgnoreCase))
                    break;
                // считывание найденных ОК в dsFGOS
                foreach (Match match in Regex.Matches(input, _ok, RegexOptions.IgnoreCase))
                    dsFGOS.ok.AddokRow(match.Groups["ok_i"].Value.ToString(), match.Groups["ok_full"].Value.ToString());
                // считывание найденных ПК в dsFGOS
                foreach (Match match in Regex.Matches(input, _pk, RegexOptions.IgnoreCase))
                    dsFGOS.pk.AddpkRow(match.Groups["pk_i"].Value.ToString(), match.Groups["pk_full"].Value.ToString());
            }
        }

        /// <summary>
        /// Чтение индексов и наименований учебных циклов, модулей
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="cikl"></param>
        /// <param name="ciklFull"></param>
        /// <param name="row"></param>
        private bool ReadCikl(Word.Document doc, out string cikl, out string ciklFull, int row)
        {
            cikl = doc.Tables[4].Cell(row, 1).Range.Text.Replace('\r', '\0').Replace('\a', '\0');
            cikl = cikl.Remove(cikl.IndexOf('\0'));
            ciklFull = doc.Tables[4].Cell(row, 2).Range.Text.Replace('\r', '\0').Replace('\a', '\0');
            ciklFull = ciklFull.Replace("учебный ", string.Empty);
            ciklFull = ciklFull.Remove(ciklFull.IndexOf('\0'));
            findLastPM = ciklFull.Contains("Вариативная часть");
            return ciklFull.Contains("Вариативная часть");
        }

        /// <summary>
        /// Чтение требований к знаниям, умениям, практическому опыту
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="row"></param>
        /// <param name="d"></param>
        /// <param name="disc"></param>
        /// <returns></returns>
        private void ReadTrebov(Word.Document doc, int row)
        {
            string trebov = doc.Tables[4].Cell(row, 2).Range.Text.Replace('\a', '\0');
            if (trebov.Contains("В результате изучения"))
                trebov = trebov.Remove(0, trebov.IndexOf(':') + 2);
            string[] trebovList = trebov.Split(new char[] { '\r', '\0' }, StringSplitOptions.RemoveEmptyEntries);

            string kod = string.Empty;
            int i = 0;

            string s = "";
            foreach (string a in trebovList)
            {
                if (a.Contains("знать:"))
                { kod = "З"; i = 1; }
                else if (a.Contains("уметь:"))
                { kod = "У"; i = 1; }
                else if (a.Contains("иметь практический опыт:"))
                { kod = "ПО"; i = 1; }
                else
                {
                    dsFGOS.Tables["treb"].Rows.Add(kod + "." + i.ToString(), dsFGOS.disc.Last().idDisc, a);
                    i++;
                }
            }
        }

        /// <summary>
        /// Создание узлов (вывод циклов и дисциплин) элемента TreeView
        /// </summary>
        private void CreateTreeView()
        {
            TreeNode OkPk = new TreeNode("Компетенции");
            tv.Nodes.Add(OkPk);

            TreeNode AllCikls = new TreeNode("Циклы");
            foreach (var c in dsFGOS.cikl)
            {
                TreeNode cikl = new TreeNode(c.idCikl + " " + c.name);
                AllCikls.Nodes.Add(cikl);


                var discCikl = dsFGOS.disc.Where(res => res.idCikl == c.idCikl);
                foreach (var d in discCikl)
                {
                    TreeNode disc = new TreeNode(d.idDisc + " " + d.name);
                    cikl.Nodes.Add(disc);
                    if (d.pm)
                    {
                        var mdk = dsFGOS.mdk.Where(res => res.idDisc == d.idDisc);
                        foreach (var m in mdk)
                            disc.Nodes.Add(m.idMdk+ " " + m.name);
                    }
                }
            }
            tv.Nodes.Add(AllCikls);
        }

        /// <summary>
        /// Вывод компетенций, соответствующих дисциплине
        /// </summary>
        /// <param name="d"></param>
        /// <param name="ok_all"></param>
        /// <param name="pk_all"></param>
        private string DrawUpCompetences(string disc)
        {
            string s = "";

            var qOk = from okdisc in dsFGOS.okDisc
                      join ok in dsFGOS.ok on okdisc.idOk equals ok.idOk
                      where okdisc.idDisc == disc
                      select ok;
            var qPk = from pkdisc in dsFGOS.pkDisc
                      join pk in dsFGOS.pk on pkdisc.idPk equals pk.idPk
                      where pkdisc.idDisc == disc
                      select pk;
            var qTr = from treb in dsFGOS.treb
                      where treb.idDisc == disc
                      select treb;

            foreach (var o in qOk)
                s += o.idOk + " " + o.text + Environment.NewLine;

            foreach (var p in qPk)
                s += p.idPk + " " + p.text + Environment.NewLine;

            foreach (var t in qTr)
                s += t.idTreb + " " + t.text + Environment.NewLine;

            return s;
        }

        /// <summary>
        /// Чтение кодов формируемых компетенций по дисциплинам
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="row"></param>
        private void ReadOkPk(Word.Document doc, int row)
        {
            string ok_pk = doc.Tables[4].Cell(row, 6).Range.Text.Replace('\a', '\0');
            ok_pk = ok_pk.Replace(" ", string.Empty);
            ok_pk = ok_pk.Replace("\n", " ");//.Replace(",", " ");
            string OkPk = @"((?<ok>^ОК.+)(?<pk>ПК.+$))|(?<ok>^ОК.+$)";
            Match m = Regex.Match(ok_pk, OkPk, RegexOptions.IgnoreCase);
            string ok_pattern = @"(?<ok_di>(?<ok_di_a>\d{1,2})-(?<ok_di_b>\d{1,2}))|(?<ok_i>\d{1,2})";
            string pk_pattern = @"(?<pk_di>(?<pk_n>\d{1,2}).(?<pk_di_a>\d{1,2})-\d{1,2}.(?<pk_di_b>\d{1,2}))|(?<pk_i>\d{1,2}.\d{1,2})";

            List<string> ok_all = new List<string>();
            foreach (Match match in Regex.Matches(m.Groups["ok"].Value, ok_pattern, RegexOptions.IgnoreCase))
            {
                if (match.Groups["ok_di"].Value != string.Empty)
                {
                    int a = Convert.ToInt32(match.Groups["ok_di_a"].Value);
                    int b = Convert.ToInt32(match.Groups["ok_di_b"].Value);

                    for (int i = 0; a <= b; i++, a++)
                        dsFGOS.Tables["okDisc"].Rows.Add(string.Format("ОК {0}", a), dsFGOS.disc.Last().idDisc);
                }
                if (match.Groups["ok_i"].Value != string.Empty)
                    dsFGOS.Tables["okDisc"].Rows.Add(string.Format("ОК {0}", match.Groups["ok_i"].Value),
                        dsFGOS.disc.Last().idDisc);
            }

            List<string> pk_all = new List<string>();
            foreach (Match match in Regex.Matches(m.Groups["pk"].Value, pk_pattern, RegexOptions.IgnoreCase))
            {
                if (match.Groups["pk_di"].Value != string.Empty)
                {
                    int a = Convert.ToInt32(match.Groups["pk_di_a"].Value);
                    int b = Convert.ToInt32(match.Groups["pk_di_b"].Value);

                    for (int i = 0; a <= b; i++, a++)
                        dsFGOS.Tables["pkDisc"].Rows.Add(string.Format("ПК {0}.{1}", match.Groups["pk_n"].Value, a),
                            dsFGOS.disc.Last().idDisc);
                }
                if (match.Groups["pk_i"].Value != string.Empty)
                    dsFGOS.Tables["pkDisc"].Rows.Add(string.Format("ПК {0}", match.Groups["pk_i"].Value),
                        dsFGOS.disc.Last().idDisc);
            }
        }

        string idDiscForInsert = "";
        string idCiklForInsert = "";
        bool loadNode = true;
        /// <summary>
        /// Метод возвращает выбранный узел, требования и компетенции узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            loadNode = true;
            idDiscForInsert = "";
            //e.Node.ContextMenuStrip = docMenu;
            if (e.Node.Text == "Компетенции")
            {
                panelOkPk.Visible = true;
                panelOkPk.Dock = DockStyle.Fill;
                panelDisc.Visible = false;
                panelTreb.Visible = false;

                okDataGridView.RowsDefaultCellStyle.WrapMode =
                    DataGridViewTriState.True;
                okDataGridView.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.AllCells;

                pkDataGridView.RowsDefaultCellStyle.WrapMode =
                    DataGridViewTriState.True;
                pkDataGridView.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.AllCells;
            }
            else if (e.Node.Level == 1)
            {
                discBindingSource.RemoveFilter();
                panelDisc.Visible = true;
                panelDisc.Dock = DockStyle.Fill;
                panelOkPk.Visible = false;
                panelTreb.Visible = false;

                string idCikl = e.Node.Text.Remove(e.Node.Text.IndexOf(' '));
                discBindingSource.Filter = string.Format("idCikl='{0}'", idCikl);
                idCiklForInsert = idCikl;
                if (e.Node.Text.Contains("ПМ.00"))
                    mdkDataGridView.Visible = true;
                else
                    mdkDataGridView.Visible = false;
            }
            else if (e.Node.Level == 2)
            {
                string _about = string.Empty;

                string _d = string.Empty;

                panelTreb.Visible = true;
                panelTreb.Dock = DockStyle.Fill;
                panelOkPk.Visible = false;
                panelDisc.Visible = false;

                //e.Node.ContextMenuStrip = docMenu;
                string idDisc = e.Node.Text.Substring(0, e.Node.Text.IndexOf(' '));
                var q = from d in dsFGOS.disc
                        where d.idDisc == idDisc
                        select d;
                if (q.Count() > 0)
                    _d = q.First().idDisc;

                idDiscForInsert = idDisc;
                okDiscBindingSource.RemoveFilter();
                okDiscBindingSource.Filter = string.Format("idDisc='{0}'", idDisc);
                pkDiscBindingSource.RemoveFilter();
                pkDiscBindingSource.Filter = string.Format("idDisc='{0}'", idDisc);
                trebBindingSource.RemoveFilter();
                trebBindingSource.Filter = string.Format("idDisc='{0}'", idDisc);

                _about = DrawUpCompetences(_d);
            }
            else
            {
                panelOkPk.Visible = false;
                panelDisc.Visible = false;
                panelTreb.Visible = false;
            }
            loadNode = false;
        }

        private void Save()
        {
            try
            {
                specBindingSource.EndEdit();
                ciklBindingSource.EndEdit();
                discBindingSource.EndEdit();
                mdkBindingSource.EndEdit();
                okDiscBindingSource.EndEdit();
                pkDiscBindingSource.EndEdit();
                trebBindingSource.EndEdit();
                okBindingSource.EndEdit();
                pkBindingSource.EndEdit();

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dsFGOS.WriteXml(sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEditMDK_Click(object sender, EventArgs e)
        {
            //FormEditPM fEdit = new FormEditPM(ref mdkDataGridView);
            //CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.Reload);
            //fEdit.ShowDialog();
            //tv.SelectedNode.Nodes.Clear();
            //foreach (string d in mdkDataGridView.Rows)
            //    tv.SelectedNode.Nodes.Add(d);
        }

        private void FormFGOS_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((ToolStripMenuItem)(((MenuStrip)(this.MdiParent.Controls[0])).Items[4])).DropDownItems[3].Enabled = false;
        }

        private void trebDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!loadNode && trebDataGridView.Rows.Count > 1)
            { 
                trebDataGridView.Rows[trebDataGridView.Rows.Count - 2].Cells[1].Value = idDiscForInsert;
            }
        }

        private void pkDiscDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!loadNode && pkDiscDataGridView.Rows.Count > 1)
            { 
                pkDiscDataGridView.Rows[pkDiscDataGridView.Rows.Count - 2].Cells[1].Value = idDiscForInsert;
            }
        }

        private void okDiscDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!loadNode && okDiscDataGridView.Rows.Count > 1)
            {
                okDiscDataGridView.Rows[okDiscDataGridView.Rows.Count - 2].Cells[1].Value = idDiscForInsert;
            }
        }

        private void discDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!loadNode && discDataGridView.Rows.Count > 1)
            {
                discDataGridView.Rows[discDataGridView.Rows.Count - 1].Cells[2].Value = idCiklForInsert;
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTv();
        }

        /// <summary>
        /// обновление tv
        /// </summary>
        private void RefreshTv()
        {
            //очиста текущих узлов
            tv.Nodes.Clear();
            //построение нового списка дисциплин
            CreateTreeView();
        }

        //void Reload(DataGridView dgv)
        //{
        //    for (int i = 0; i < dgv.RowCount; i++)
        //    {
        //        mdkDataGridView.Rows.Add(dgv.Rows[i].Cells[0].Value);
        //    }
        //}
    }
}
