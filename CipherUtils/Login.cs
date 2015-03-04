using IBS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CipherUtils
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.uky");
            if (!File.Exists(dbPath))
            {
                using (KeyLoadForm klf = new KeyLoadForm())
                {
                    if (klf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        SQLiteDataHelper.SetSQLiteConnection(dbPath);
                    }
                    else
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
            else
                SQLiteDataHelper.SetSQLiteConnection(dbPath);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public UserInfo User;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tUserName.Text) || string.IsNullOrEmpty(tPassword.Text))
            {
                MessageBox.Show("用户名或者密码为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string msg = null;
            this.User = UserInfo.Login(tUserName.Text, tPassword.Text, out msg);
            if (this.User == null)
            {
                MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
