using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EMC
{
    public partial class FormGroups : Form
    {
        Dictionary<string, string> practiceGroup = new Dictionary<string, string>();
        Dictionary<string, string> scheduleGroup = new Dictionary<string, string>();
        
        public FormGroups()
        {
            InitializeComponent();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            AddGroup();
        }

        /// <summary>
        /// Добавление группы
        /// </summary>
        private void AddGroup()
        {            
            if (tbGroup.Text.Replace(" ", "") == "")
                return;
            // удаление пробелов в названии группы
            tbGroup.Text = tbGroup.Text.Trim();
            bool YestGryppa = false;
            // запись периода семестра
            Groups.dateStartSemester = dtpSemesterSince.Value;
            Groups.dateEndSemester = dtpSemesterFrom.Value;
            for (int i = 0; i < cbGroup.Items.Count; i++)
            {
                // проверка существования группы
                if (cbGroup.Items[i].ToString() == tbGroup.Text)
                {
                    YestGryppa = true;
                    break;
                }
            }
            // заполнения периода практики и графика, если группы нет
            if (!YestGryppa)
            {
                cbGroup.Items.Add(tbGroup.Text);
                Groups.practiceGroup.Add(tbGroup.Text, "");
                Groups.scheduleGroup.Add(tbGroup.Text,
                    "-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-;-/-");
                Groups.namesOfGroups.Add(tbGroup.Text);
            }
            tbGroup.Text = "";
        }

        private void btnDeletGroup_Click(object sender, EventArgs e)
        {
            DeleteGroup();
        }

        /// <summary>
        /// Удаление группы
        /// </summary>
        private void DeleteGroup()
        {
            if (cbGroup.SelectedIndex != -1)
            {
                // очистка периодов практики выбранной группы
                Groups.practiceGroup.Remove(cbGroup.SelectedItem.ToString());
                cbPractice.Items.Clear();
                // очистка графика группы
                Groups.scheduleGroup.Remove(cbGroup.SelectedItem.ToString());
                // удаление наименования группы из списка
                Groups.namesOfGroups.Remove(cbGroup.SelectedItem.ToString());
                cbGroup.Items.RemoveAt(cbGroup.SelectedIndex);
                // очистка таблицы графика
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < dgvSchedule.ColumnCount; j++)
                        dgvSchedule.Rows[i].Cells[j].Value = "-/-";
                }
            }
        }

        private void btnAddPractice_Click(object sender, EventArgs e)
        {
            AddPractice();
        }

        /// <summary>
        /// Добавление периода практики
        /// </summary>
        private void AddPractice()
        {
            if (cbGroup.SelectedItem != null)
            {
                // проверка корректности сроков практики
                if (dtpPracticeSince.Value >= dtpPracticeFrom.Value)
                {
                    MessageBox.Show("Проверьте корректность календарных сроков практики.", 
                        "Ошибка");
                    return;
                }
                // добавление периода практики в выпадающий список
                cbPractice.Items.Add(string.Format("{0}-{1}", 
                    dtpPracticeSince.Value.ToShortDateString(),
                    dtpPracticeFrom.Value.ToShortDateString()));

                if (Groups.practiceGroup[cbGroup.SelectedItem.ToString()] == "")
                    Groups.practiceGroup[cbGroup.SelectedItem.ToString()] =
                        cbPractice.Items[cbPractice.Items.Count - 1].ToString();
                else
                    Groups.practiceGroup[cbGroup.SelectedItem.ToString()] = string.Format("{0};{1}"
                        , Groups.practiceGroup[cbGroup.SelectedItem.ToString()]
                        , cbPractice.Items[cbPractice.Items.Count - 1].ToString());
            }
        }

        private void btnDeletPractice_Click(object sender, EventArgs e)
        {
            DeletePractice();
        }
        
        /// <summary>
        /// Удаление периода практики
        /// </summary>
        private void DeletePractice()
        {
            if (cbPractice.SelectedIndex != -1)
            {
                // удаление практики из выпадающего списка
                cbPractice.Items.RemoveAt(cbPractice.SelectedIndex);
                // обнуление значения практики выбранной группы
                Groups.practiceGroup[cbGroup.SelectedItem.ToString()] = "";
                for (int i = 0; i < cbPractice.Items.Count; i++)
                {
                    if (Groups.practiceGroup[cbGroup.SelectedItem.ToString()] == "")
                        // запись практики группы
                        Groups.practiceGroup[cbGroup.SelectedItem.ToString()] = 
                            cbPractice.Items[i].ToString();
                    else
                        Groups.practiceGroup[cbGroup.SelectedItem.ToString()] = string.Format("{0};{1}"
                            , Groups.practiceGroup[cbGroup.SelectedItem.ToString()]
                            , cbPractice.Items[i].ToString());
                }
                if (cbPractice.Items.Count != 0)
                    cbPractice.SelectedIndex = 0;
            }
        }

        private void cbGroup_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbGroup.Items.Count != 0)
            {
                cbPractice.Items.Clear();
                if (Groups.practiceGroup[cbGroup.SelectedItem.ToString()] != "")
                {
                    string[] practicesOfGroup = Groups.practiceGroup[cbGroup.SelectedItem.ToString()].Split(';');
                    for (int i = 0; i < practicesOfGroup.Count(); i++)
                    {
                        cbPractice.Items.Add(practicesOfGroup[i]);
                    }
                }

                int z = 0;
                string[] scheduleOfGroup = Groups.scheduleGroup[cbGroup.SelectedItem.ToString()].Split(';');
                //MessageBox.Show(Groups.scheduleGroup[cbGroup.SelectedItem.ToString()].ToString());
                //MessageBox.Show(scheduleOfGroup.Count().ToString());
                for (int i = 0; i < dgvSchedule.Columns.Count; i++)
                    for (int j = 0; j < dgvSchedule.Rows.Count; j++)
                    {
                        //MessageBox.Show(scheduleOfGroup[z].ToString());
                        dgvSchedule.Rows[j].Cells[i].Value = scheduleOfGroup[z];
                        z++;
                    }
            }
        }

        private void FormGroups_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbGroup.Items.Count != 0)
            {
                if ((dtpSemesterSince.Value >= dtpSemesterFrom.Value) || (dtpSemesterSince.Value.DayOfWeek == 0))
                {
                    MessageBox.Show("Проверьте корректность сроков семестра.", "Ошибка");
                    e.Cancel = true;
                    return;
                }
                Groups.dateStartSemester = dtpSemesterSince.Value;
                Groups.dateEndSemester = dtpSemesterFrom.Value;
            }
           // Groups.SavingFile();
        }

        private void dgvSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cbGroup.Items.Count != 0 && cbGroup.SelectedIndex != -1)
            {

                Groups.scheduleGroup[cbGroup.SelectedItem.ToString()] = "";

                for (int i = 0; i < dgvSchedule.Columns.Count; i++)
                    for (int j = 0; j < dgvSchedule.Rows.Count; j++)
                        Groups.scheduleGroup[cbGroup.SelectedItem.ToString()] = string.Format("{0}{1};"
                            , Groups.scheduleGroup[cbGroup.SelectedItem.ToString()]
                            , dgvSchedule.Rows[j].Cells[i].Value);
            }
        }

        private void dgvSchedule_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar).ToString() == "л")
                (e.KeyChar) = 'Л';

            if (e.KeyChar == 43 || e.KeyChar == 45 || (e.KeyChar).ToString() == "Л")
            {
                if (((TextBox)sender).Text.Length == 1)
                {
                    ((TextBox)sender).Text = ((TextBox)sender).Text[0].ToString() + "/" + (e.KeyChar).ToString();
                    e.Handled = true;
                }
                else if (((TextBox)sender).Text.Length == 3)
                    ((TextBox)sender).SelectAll();
            }
            else
                e.Handled = true;
        }

        private void FormGroups_Load(object sender, EventArgs e)
        {
           // Groups.ReadingFile();
            if (Groups.namesOfGroups.Count != 0)
            {
                for (int i = 0; i < Groups.namesOfGroups.Count; i++)
                    cbGroup.Items.Add(Groups.namesOfGroups[i]);

                dtpSemesterSince.Value = Groups.dateStartSemester;
                dtpSemesterFrom.Value = Groups.dateEndSemester;
           }

            for (int i = 0; i < 4; i++)
            {
                dgvSchedule.Rows.Add();
                dgvSchedule.Rows[i].HeaderCell.Value = string.Format("{0} пара", i + 1);
                dgvSchedule.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                for (int j = 0; j < dgvSchedule.ColumnCount; j++)
                    dgvSchedule.Rows[i].Cells[j].Value = "-/-";
            }

            
        }
    }
}