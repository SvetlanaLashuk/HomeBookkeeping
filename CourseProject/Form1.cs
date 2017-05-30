using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class Form1 : Form
    {
        database db;
        public Form1()
        {
            InitializeComponent();
            db = new database();
            // Load the data into the DbContext object and bind to the DataGridView
            db.incomesources.Load();
            dgvIncS.DataSource = db.incomesources.Local.ToBindingList();

            db.outlayitems.Load();
            dgvOutI.DataSource = db.outlayitems.Local.ToBindingList();

            db.users.Load();
            dgvFM.DataSource = db.users.Local.ToBindingList();

            db.incomes.Load();
            dgvInc.DataSource = db.incomes.Local.ToBindingList();

            db.outlays.Load();
            dgvOut.DataSource = db.outlays.Local.ToBindingList();
        }

        // TabPage Income
        private void buttonIncAdd_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            // From the sources of income in the database form the list
            List<incomesource> incsour = db.incomesources.ToList();
            form3.Text = "Add Income";
            form3.label1.Text = "Income Source";
            form3.comboBoxIO.DataSource = incsour;
            form3.comboBoxIO.ValueMember = "idSource";
            form3.comboBoxIO.DisplayMember = "sourceName";

            // From the family members in the database form the list
            List<user> us = db.users.ToList();
            form3.comboBoxFM.DataSource = us;
            form3.comboBoxFM.ValueMember = "idUser";
            form3.comboBoxFM.DisplayMember = "userName";
            
            DialogResult result = form3.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            if ((form3.textBoxSum.Text == String.Empty) ||
                (form3.comboBoxFM.SelectedIndex == -1) ||
                (form3.comboBoxIO.SelectedIndex == -1))
                MessageBox.Show("Not all fields are filled!");
            else
            {
                income income = new income();
                income.incomeDate = form3.dateTimePickerInc.Value.Date;
                income.incomesource = (incomesource)form3.comboBoxIO.SelectedItem;
                income.user = (user)form3.comboBoxFM.SelectedItem;
                income.incomeSum = Convert.ToDouble(form3.textBoxSum.Text);

                db.incomes.Add(income);
                db.SaveChanges();
            }
        }

        private void buttonIncEdit_Click(object sender, EventArgs e)
        {
            if (dgvInc.SelectedRows.Count > 0)
            {
                int index = dgvInc.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvInc[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                income income = db.incomes.Find(id);

                Form3 form3 = new Form3();
                form3.Text = "Edit Income";
                form3.label1.Text = "Income Source";
                form3.dateTimePickerInc.Value = income.incomeDate;
                form3.textBoxSum.Text = income.incomeSum.ToString();

                List<incomesource> incsour = db.incomesources.ToList();
                form3.comboBoxIO.DataSource = incsour;
                form3.comboBoxIO.ValueMember = "idSource";
                form3.comboBoxIO.DisplayMember = "sourceName";

                List<user> us = db.users.ToList();
                form3.comboBoxFM.DataSource = us;
                form3.comboBoxFM.ValueMember = "idUser";
                form3.comboBoxFM.DisplayMember = "userName";

                if (income.incomesource != null)
                    form3.comboBoxIO.SelectedValue = income.incomesource.idSource;
                if (income.user != null)
                    form3.comboBoxFM.SelectedValue = income.user.idUser;

                DialogResult result = form3.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                if ((form3.textBoxSum.Text == String.Empty) ||
                (form3.comboBoxFM.SelectedIndex == -1) ||
                (form3.comboBoxIO.SelectedIndex == -1))
                    MessageBox.Show("Not all fields are filled!");
                else
                {
                    income.incomeDate = form3.dateTimePickerInc.Value.Date;
                    income.incomesource = (incomesource)form3.comboBoxIO.SelectedItem;
                    income.user = (user)form3.comboBoxFM.SelectedItem;
                    income.incomeSum = Convert.ToDouble(form3.textBoxSum.Text);

                    db.Entry(income).State = EntityState.Modified;
                    db.SaveChanges();
                    dgvInc.Refresh();
                }
            }
        }

        private void buttonIncDelete_Click(object sender, EventArgs e)
        {
            if (dgvInc.SelectedRows.Count > 0)
            {
                int index = dgvInc.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvInc[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                income income = db.incomes.Find(id);
                db.incomes.Remove(income);
                db.SaveChanges();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // TabPage Outlay
        private void buttonOutAdd_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            // From the outlays items in the database form the list
            List<outlayitem> outitem = db.outlayitems.ToList();
            form3.Text = "Add Outlay";
            form3.label1.Text = "Outlay Item";
            form3.comboBoxIO.DataSource = outitem;
            form3.comboBoxIO.ValueMember = "idItem";
            form3.comboBoxIO.DisplayMember = "itemName";

            // From the family members in the database form the list
            List<user> us = db.users.ToList();
            form3.comboBoxFM.DataSource = us;
            form3.comboBoxFM.ValueMember = "idUser";
            form3.comboBoxFM.DisplayMember = "userName";
            
            DialogResult result = form3.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            if ((form3.textBoxSum.Text == String.Empty) ||
                (form3.comboBoxFM.SelectedIndex == -1) ||
                (form3.comboBoxIO.SelectedIndex == -1))
                MessageBox.Show("Not all fields are filled!");
            else
            {
                outlay outlay = new outlay();
                outlay.outlayDate = form3.dateTimePickerInc.Value.Date;
                outlay.outlayitem = (outlayitem)form3.comboBoxIO.SelectedItem;
                outlay.user = (user)form3.comboBoxFM.SelectedItem;
                outlay.outlaySum = Convert.ToDouble(form3.textBoxSum.Text);

                db.outlays.Add(outlay);
                db.SaveChanges();
            }
        }

        private void buttonOutEdit_Click(object sender, EventArgs e)
        {
            if (dgvOut.SelectedRows.Count > 0)
            {
                int index = dgvOut.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvOut[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                outlay outlay = db.outlays.Find(id);

                Form3 form3 = new Form3();
                form3.Text = "Edit Outlay";
                form3.label1.Text = "Outlay Item";
                form3.dateTimePickerInc.Value = outlay.outlayDate;
                form3.textBoxSum.Text = outlay.outlaySum.ToString();

                List<outlayitem> outitem = db.outlayitems.ToList();
                form3.comboBoxIO.DataSource = outitem;
                form3.comboBoxIO.ValueMember = "idItem";
                form3.comboBoxIO.DisplayMember = "itemName";

                List<user> us = db.users.ToList();
                form3.comboBoxFM.DataSource = us;
                form3.comboBoxFM.ValueMember = "idUser";
                form3.comboBoxFM.DisplayMember = "userName";

                if (outlay.outlayitem != null)
                    form3.comboBoxIO.SelectedValue = outlay.outlayitem.idItem;
                if (outlay.user != null)
                    form3.comboBoxFM.SelectedValue = outlay.user.idUser;

                DialogResult result = form3.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                if ((form3.textBoxSum.Text == String.Empty) ||
                (form3.comboBoxFM.SelectedIndex == -1) ||
                (form3.comboBoxIO.SelectedIndex == -1))
                    MessageBox.Show("Not all fields are filled!");
                else
                {
                    outlay.outlayDate = form3.dateTimePickerInc.Value.Date;
                    outlay.outlayitem = (outlayitem)form3.comboBoxIO.SelectedItem;
                    outlay.user = (user)form3.comboBoxFM.SelectedItem;
                    outlay.outlaySum = Convert.ToDouble(form3.textBoxSum.Text);

                    db.Entry(outlay).State = EntityState.Modified;
                    db.SaveChanges();
                    dgvOut.Refresh();
                }
            }
        }

        private void buttonOutDelete_Click(object sender, EventArgs e)
        {
            if (dgvOut.SelectedRows.Count > 0)
            {
                int index = dgvOut.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvOut[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                outlay outlay = db.outlays.Find(id);
                db.outlays.Remove(outlay);
                db.SaveChanges();
            }
        }

        // TabPage Income sources
        private void buttonIncSAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Text = "Add Income Source";
            DialogResult result = form2.ShowDialog(this);

            if (result == DialogResult.Cancel) return;

            if (form2.textBoxName.Text == String.Empty)
                MessageBox.Show("Not all fields are filled!");
            else
            {
                incomesource incs = new incomesource();
                incs.sourceName = form2.textBoxName.Text;
                incs.incomeComment = form2.textBoxComment.Text;
                db.incomesources.Add(incs);
                db.SaveChanges();
            }
        }

        private void buttonIncSEdit_Click(object sender, EventArgs e)
        {
            if (dgvIncS.SelectedRows.Count > 0)
            {
                int index = dgvIncS.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvIncS[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                incomesource incs = db.incomesources.Find(id);
                Form2 form2 = new Form2();
                form2.Text = "Edit Income Source";
                form2.textBoxName.Text = incs.sourceName;
                form2.textBoxComment.Text = incs.incomeComment;
                DialogResult result = form2.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
                if (form2.textBoxName.Text == String.Empty)
                    MessageBox.Show("Not all fields are filled!");
                else
                {
                    incs.sourceName = form2.textBoxName.Text;
                    incs.incomeComment = form2.textBoxComment.Text;
                    db.SaveChanges();
                    dgvIncS.Refresh();
                }
            }
        }

        private void buttonIncSDelete_Click(object sender, EventArgs e)
        {
            if (dgvIncS.SelectedRows.Count > 0)
            {
                int index = dgvIncS.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvIncS[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                incomesource incs = db.incomesources.Find(id);
                db.incomesources.Remove(incs);
                db.SaveChanges();
            }
        }

        // TabPage Outlay items
        private void buttonOutIAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Text = "Add Outlay Items";
            DialogResult result = form2.ShowDialog(this);

            if (result == DialogResult.Cancel) return;

            if (form2.textBoxName.Text == String.Empty)
                MessageBox.Show("Not all fields are filled!");
            else
            {
                outlayitem outi = new outlayitem();
                outi.itemName = form2.textBoxName.Text;
                outi.outlayComment = form2.textBoxComment.Text;
                db.outlayitems.Add(outi);
                db.SaveChanges();
            }
        }

        private void buttonOutIEdit_Click(object sender, EventArgs e)
        {
            if (dgvOutI.SelectedRows.Count > 0)
            {
                int index = dgvOutI.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvOutI[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                outlayitem outi = db.outlayitems.Find(id);
                Form2 form2 = new Form2();
                form2.Text = "Edit Outlay Items";
                form2.textBoxName.Text = outi.itemName;
                form2.textBoxComment.Text = outi.outlayComment;
                DialogResult result = form2.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
                if (form2.textBoxName.Text == String.Empty)
                    MessageBox.Show("Not all fields are filled!");
                else
                {
                    outi.itemName = form2.textBoxName.Text;
                    outi.outlayComment = form2.textBoxComment.Text;
                    db.SaveChanges();
                    dgvOutI.Refresh();
                }
            }
        }

        private void buttonOutIDelete_Click(object sender, EventArgs e)
        {
            if (dgvOutI.SelectedRows.Count > 0)
            {
                int index = dgvOutI.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvOutI[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                outlayitem outi = db.outlayitems.Find(id);
                db.outlayitems.Remove(outi);
                db.SaveChanges();
            }
        }

        // TabPage Family members
        private void buttonFMAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Text = "Add Family Members";
            DialogResult result = form2.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;
            if (form2.textBoxName.Text == String.Empty)
                MessageBox.Show("Not all fields are filled!");
            else
            {
                user user = new user();
                user.userName = form2.textBoxName.Text;
                user.status = form2.textBoxComment.Text;
                db.users.Add(user);
                db.SaveChanges();
            }
        }

        private void buttonFMEdit_Click(object sender, EventArgs e)
        {
            if (dgvFM.SelectedRows.Count > 0)
            {
                int index = dgvFM.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvFM[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                user user = db.users.Find(id);
                Form2 form2 = new Form2();
                form2.Text = "Edit Family Members";
                form2.textBoxName.Text = user.userName;
                form2.textBoxComment.Text = user.status;
                DialogResult result = form2.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
                if (form2.textBoxName.Text == String.Empty)
                    MessageBox.Show("Not all fields are filled!");
                else
                {
                    user.userName = form2.textBoxName.Text;
                    user.status = form2.textBoxComment.Text;
                    db.SaveChanges();
                    dgvFM.Refresh();
                }
            }
        }

        private void buttonFMDelete_Click(object sender, EventArgs e)
        {
            if (dgvFM.SelectedRows.Count > 0)
            {
                int index = dgvFM.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dgvFM[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                user user = db.users.Find(id);
                db.users.Remove(user);
                db.SaveChanges();
            }
        }

        // TabPage Reports
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 6)
            {
                labelIncS.Visible = false;
                comboBoxIncReport.Visible = false;
                comboBoxIncReport.SelectedIndex = -1;
                checkBoxByIS.Visible = false;
                checkBoxByIS.Checked = false;
                checkBoxIncomes.Checked = false;
                checkBoxOutlays.Checked = false;
                labelOutI.Visible = false;
                comboBoxOutReport.Visible = false;
                comboBoxOutReport.SelectedIndex = -1;
                checkBoxByOI.Visible = false;
                checkBoxByOI.Checked = false;
                List<user> us = db.users.ToList();
                comboBoxFMReport.DataSource = us;
                comboBoxFMReport.ValueMember = "idUser";
                comboBoxFMReport.DisplayMember = "userName";
                comboBoxFMReport.SelectedIndex = -1;
                checkBoxByFM.Checked = false;
            }
        }

        private void checkBoxIncomes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIncomes.Checked)
            {
                labelIncS.Visible = true;
                comboBoxIncReport.Visible = true;
                checkBoxByIS.Visible = true;
                checkBoxByIS.Checked = false;
                List<incomesource> incsour = db.incomesources.ToList();
                comboBoxIncReport.DataSource = incsour;
                comboBoxIncReport.ValueMember = "idSource";
                comboBoxIncReport.DisplayMember = "sourceName";
                comboBoxIncReport.SelectedIndex = -1;
            }
            else
            {
                comboBoxIncReport.SelectedIndex = -1;
                labelIncS.Visible = false;
                comboBoxIncReport.Visible = false;
                checkBoxByIS.Visible = false;
            }
        }

        private void checkBoxOutlays_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOutlays.Checked)
            {
                labelOutI.Visible = true;
                comboBoxOutReport.Visible = true;
                checkBoxByOI.Visible = true;
                checkBoxByOI.Checked = false;
                List<outlayitem> outitem = db.outlayitems.ToList();
                comboBoxOutReport.DataSource = outitem;
                comboBoxOutReport.ValueMember = "idItem";
                comboBoxOutReport.DisplayMember = "itemName";
                comboBoxOutReport.SelectedIndex = -1;
            }
            else
            {
                comboBoxOutReport.SelectedIndex = -1;
                labelOutI.Visible = false;
                comboBoxOutReport.Visible = false;
                checkBoxByOI.Visible = false;
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Owner = this;
            form4.ShowDialog();
            
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDeselect_Click(object sender, EventArgs e)
        {
            comboBoxFMReport.SelectedIndex = -1;
        }
    }
}
