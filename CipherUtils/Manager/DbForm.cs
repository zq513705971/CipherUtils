using IBS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CipherUtils
{
    public partial class DbForm : Form
    {
        public DbForm()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSQLInput.Text))
            {
                MessageBox.Show("请输入SQL语句！", "警告");
                return;
            }
            try
            {
                string _sqlStr = textBoxSQLInput.Text.Trim();
                if (_sqlStr.ToUpper().StartsWith("SELECT"))
                {
                    DataTable result = SQLiteDataHelper.GetDataTableBySql(_sqlStr);
                    dataGridViewMain.DataSource = result;
                }
                else
                    SQLiteDataHelper.ExecuteNonQuery(_sqlStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告");
            }
        }

        private void DbForm_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void LoadTables()
        {
            string sqlStr = "select name from sqlite_master where type='table' and name<>'sqlite_sequence'";
            DataTable result = SQLiteDataHelper.GetDataTableBySql(sqlStr);
            foreach (DataRow dr in result.Rows)
            {
                listBoxTables.Items.Add(dr["name"]);
            }
        }

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxTables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable result = SQLiteDataHelper.GetDataTableBySql(string.Format("select * from {0}", listBoxTables.SelectedItem.ToString()));
            dataGridViewMain.DataSource = result;
        }
    }
}
