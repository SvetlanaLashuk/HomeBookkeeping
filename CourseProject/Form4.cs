using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CourseProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        // method that returns an object DataTable
        protected internal DataTable GetIncome()
        {
            DataTable dt = new DataTable();
            MySqlConnection connection;
            // Connection string to the database
            string connectionString = "server=127.0.0.1;user=root;database=cwdb;password=root;";
            // Create an object to connect to the database
            connection = new MySqlConnection(connectionString);
            // establish a connection to the database
            connection.Open();
            Form1 main = this.Owner as Form1;
            // SQL-query
            string sql = "";
            string IntDateGr = " HAVING incomeDate BETWEEN '" + main.dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + main.dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "'";
            string IntDate = " AND incomeDate BETWEEN '" + main.dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + main.dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "'";
            if ((main.comboBoxIncReport.SelectedIndex != -1) && (main.comboBoxFMReport.SelectedIndex != -1))  // Income Sourse, Family Member - selected
            {
                sql = "SELECT DATE_FORMAT(incomeDate,'%d.%m.%Y') AS Date, SUM(IncomeSum) AS Sum FROM income WHERE idSource=" + main.comboBoxIncReport.SelectedValue + " AND idUser=" + main.comboBoxFMReport.SelectedValue + " GROUP BY incomeDate " + IntDateGr + " ORDER BY incomeDate";
            }
            else
            {
                if (main.comboBoxIncReport.SelectedIndex != -1)  // Income Sourse - selected, Family Member - all
                {
                    if (main.checkBoxByFM.Checked)   // Group by Family Member
                    {
                        sql = "SELECT userName AS Family_Member, SUM(IncomeSum) AS Sum FROM income,user WHERE income.idSource=" + main.comboBoxIncReport.SelectedValue + " AND user.idUser=income.idUser " + IntDate + " GROUP BY userName ORDER BY userName";
                    }
                    else
                    {
                        sql = "SELECT DATE_FORMAT(incomeDate,'%d.%m.%Y') AS Date, userName AS Family_Member, SUM(IncomeSum) AS Sum FROM income, user WHERE income.idSource=" + main.comboBoxIncReport.SelectedValue + " AND user.idUser=income.idUser GROUP BY incomeDate, userName " + IntDateGr + " ORDER BY incomeDate, userName";
                    }
                }
                else
                {
                    if (main.comboBoxFMReport.SelectedIndex != -1)  // Income Sourse - all, Family Member - selected
                    {
                        if (main.checkBoxByIS.Checked)   // Group by Income Sourse
                        {
                            sql = "SELECT sourceName AS Income_Sourse, SUM(IncomeSum) AS Sum FROM income, incomesources WHERE income.idUser=" + main.comboBoxFMReport.SelectedValue + " AND income.idSource=incomesources.idSource " + IntDate + " GROUP BY sourceName ORDER BY sourceName";
                        }
                        else
                        {
                            sql = "SELECT DATE_FORMAT(incomeDate,'%d.%m.%Y') AS Date, sourceName AS Income_Sourse, SUM(IncomeSum) AS Sum FROM income, incomesources WHERE income.idUser=" + main.comboBoxFMReport.SelectedValue + " AND income.idSource=incomesources.idSource GROUP BY incomeDate, sourceName " + IntDateGr + " ORDER BY incomeDate, sourceName";
                        }
                    }
                    else   // Income Sourse - all, Family Member - all
                    {
                        if ((main.checkBoxByIS.Checked) && (main.checkBoxByFM.Checked))
                        {
                            sql = "SELECT sourceName AS Income_Sourse, userName AS Family_Member, SUM(IncomeSum) AS Sum FROM incomesources, income, user WHERE incomesources.idSource=income.idSource AND user.idUser=income.idUser " + IntDate + " GROUP BY sourceName, userName ORDER BY sourceName";
                        }
                        else
                        {
                            if (main.checkBoxByIS.Checked)
                            {
                                sql = "SELECT sourceName AS Income_Sourse, SUM(IncomeSum) AS Sum FROM income, incomesources, user WHERE income.idUser=user.idUser AND income.idSource=incomesources.idSource " + IntDate + " GROUP BY sourceName ORDER BY sourceName";
                            }
                            else
                            {
                                if (main.checkBoxByFM.Checked)
                                {
                                    sql = "SELECT userName AS Family_Member, SUM(IncomeSum) AS Sum FROM income, incomesources, user WHERE income.idUser=user.idUser AND income.idSource=incomesources.idSource " + IntDate + " GROUP BY userName ORDER BY userName";
                                }
                                else
                                {
                                    sql = "SELECT DATE_FORMAT(incomeDate,'%d.%m.%Y') AS Date, sourceName AS Income_Sourse, userName AS Family_Member, SUM(IncomeSum) AS Sum FROM income, incomesources, user WHERE incomesources.idSource=income.idSource AND user.idUser=income.idUser GROUP BY incomeDate, sourceName, userName " + IntDateGr + " ORDER BY incomeDate, sourceName, userName";
                                }
                            }
                        }
                    }
                }
            }
            // object for performing SQL-query
            MySqlCommand cm = new MySqlCommand(sql, connection);
            // Object for reading server response
            MySqlDataReader reader = cm.ExecuteReader();
            if (reader.HasRows) dt.Load(reader);
            // Close reader
            reader.Close();
            // close the connection with the database
            connection.Clone();
            return dt;
        }

        protected internal DataTable GetOutlay()
        {
            DataTable dt = new DataTable();
            MySqlConnection connection;
            string connectionString = "server=127.0.0.1;user=root;database=cwdb;password=root;";
            connection = connection = new MySqlConnection(connectionString);
            connection.Open();
            Form1 main = this.Owner as Form1;
            string sql = "";
            string IntDateGr = " HAVING outlayDate BETWEEN '" + main.dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + main.dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "'";
            string IntDate = " AND outlayDate BETWEEN '" + main.dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" + main.dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "'";
            if ((main.comboBoxOutReport.SelectedIndex != -1) && (main.comboBoxFMReport.SelectedIndex != -1))  // Outlay Item, Family Member - selected
            {
                sql = "SELECT DATE_FORMAT(outlayDate,'%d.%m.%Y') AS Date, SUM(outlaySum) AS Sum FROM outlay WHERE Itemid=" + main.comboBoxOutReport.SelectedValue + " AND Userid=" + main.comboBoxFMReport.SelectedValue + " GROUP BY outlayDate " + IntDateGr + " ORDER BY outlayDate";
            }
            else
            {
                if (main.comboBoxOutReport.SelectedIndex != -1)  // Outlay Item - selected, Family Member - all
                {
                    if (main.checkBoxByFM.Checked)   // Group by Family Member
                    {
                        sql = "SELECT userName AS Family_Member, SUM(outlaySum) AS Sum FROM outlay, user WHERE outlay.Itemid=" + main.comboBoxOutReport.SelectedValue + " AND user.idUser=outlay.Userid " + IntDate + " GROUP BY userName ORDER BY userName";
                    }
                    else
                    {
                        sql = "SELECT DATE_FORMAT(outlayDate,'%d.%m.%Y') AS Date, userName AS Family_Member, SUM(outlaySum) AS Sum FROM outlay, user WHERE outlay.Itemid=" + main.comboBoxOutReport.SelectedValue + " AND user.idUser=outlay.Userid GROUP BY outlayDate, userName " + IntDateGr + " ORDER BY outlayDate, userName";
                    }
                }
                else
                {
                    if (main.comboBoxFMReport.SelectedIndex != -1)  // Outlay Item - all, Family Member - selected
                    {
                        if (main.checkBoxByOI.Checked)   // Group by Outlay Item
                        {
                            sql = "SELECT itemName AS Outlay_Item, SUM(outlaySum) AS Sum FROM outlay, outlayitems WHERE outlay.Userid=" + main.comboBoxFMReport.SelectedValue + " AND outlayitems.idItem=outlay.Itemid " + IntDate + " GROUP BY itemName ORDER BY itemName";
                        }
                        else
                        {
                            sql = "SELECT DATE_FORMAT(outlayDate,'%d.%m.%Y') AS Date, itemName AS Outlay_Item, SUM(outlaySum) AS Sum FROM outlay, outlayitems WHERE outlay.Userid=" + main.comboBoxFMReport.SelectedValue + " AND outlayitems.idItem=outlay.Itemid GROUP BY outlayDate, itemName " + IntDateGr + " ORDER BY outlayDate, itemName";
                        }
                    }
                    else   // Outlay Item - all, Family Member - all
                    {
                        if ((main.checkBoxByOI.Checked) && (main.checkBoxByFM.Checked))
                        {
                               sql = "SELECT itemName AS Outlay_Item, userName AS Family_Member, SUM(outlaySum) AS Sum FROM outlayitems, outlay, user WHERE outlayitems.idItem=outlay.Itemid AND user.idUser=outlay.Userid " + IntDate + " GROUP BY itemName, userName ORDER BY itemName";
                        }
                        else
                        {
                            if (main.checkBoxByOI.Checked)
                            {
                                 sql = "SELECT itemName AS Outlay_Item, SUM(outlaySum) AS Sum FROM outlay, outlayitems, user WHERE outlay.Userid=user.idUser AND outlayitems.idItem=outlay.Itemid " + IntDate + " GROUP BY itemName ORDER BY itemName";
                            }
                            else
                            {
                                if (main.checkBoxByFM.Checked)
                                {
                                    sql = "SELECT userName AS Family_Member, SUM(outlaySum) AS Sum FROM outlay, outlayitems, user WHERE outlay.Userid=user.idUser AND outlayitems.idItem=outlay.Itemid " + IntDate + " GROUP BY userName ORDER BY userName";
                                }
                                else
                                {
                                    sql = "SELECT DATE_FORMAT(outlayDate,'%d.%m.%Y') AS Date, itemName AS Outlay_Item, userName AS Family_Member, SUM(outlaySum) AS Sum FROM outlay, outlayitems, user WHERE outlayitems.idItem=outlay.Itemid AND user.idUser=outlay.Userid GROUP BY outlayDate, itemName, userName " + IntDateGr + " ORDER BY outlayDate, itemName, userName";
                                }
                            }
                        }
                    }
                }
             }
            MySqlCommand cm = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cm.ExecuteReader();
            if (reader.HasRows) dt.Load(reader);
            reader.Close();
            connection.Clone();
            return dt;
        }
        
        private void Form4_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            label1.Text = "Report for the period from  " + main.dateTimePickerFrom.Value.ToString("dd.MM.yyyy") + "  to  " + main.dateTimePickerTo.Value.ToString("dd.MM.yyyy");
            labelIncomes.Visible = false;
            labelOutlays.Visible = false;
            labelIS.Text = main.comboBoxIncReport.Text;
            labelFMInc.Text = main.comboBoxFMReport.Text;
            labelOI.Text = main.comboBoxOutReport.Text;
            labelFMOut.Text = main.comboBoxFMReport.Text;

            if (main.checkBoxIncomes.Checked)
            {
                labelIncomes.Visible = true;
                // call the method that returns an object DataTable and puts the data in the DataGridView
                dgvReportInc.DataSource = GetIncome();
            }
            if (main.checkBoxOutlays.Checked)
            {
                labelOutlays.Visible = true;
                dgvReportOut.DataSource = GetOutlay();
            }
        }
    }
}
