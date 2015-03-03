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
    public partial class InitForm : Form
    {
        public InitForm()
        {
            InitializeComponent();
            btnOK.Enabled = false;
        }

        private void InitForm_Load(object sender, EventArgs e)
        {
#if RSA
            lbEncrypt.Visible = false;
            tEncrypt.Visible = false;
#else
            lbEncrypt.Visible = true;
            tEncrypt.Visible = true;
#endif
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tPassword.Text))
            {
                if (string.IsNullOrEmpty(tEncrypt.Text))
                {
                    MessageBox.Show("请设置加密密钥，且密码设置后不可修改！", "提示");
                    return;
                }
                try
                {
                    string db = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.uky");
                    SQLiteDataHelper.CreateDataBase(db);
                    SQLiteDataHelper.SetSQLiteConnection(db);
                    UserInfo.Init((tPassword.Text + RsaCode.Prefix).Substring(0, 8));
#if RSA
                    RsaKeyInfo rsakey = RsaKeyInfo.CreateKey();
                    RsaKeyInfo.Init(rsakey);
#else
                    KeyInfo deskey = new KeyInfo(tEncrypt.Text);
                    KeyInfo.Init(deskey);
#endif
                    MessageBox.Show(string.Format("初始登录密码为：\"{0}\"{1}！", tPassword.Text, tPassword.Text.Equals("111111") ? "\n请及时修改该密码" : ""), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示");
                }
            }
            else
                MessageBox.Show("请确认密码不为空！", "提示");
        }

        private void tEncrypt_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = tEncrypt.Text.Length == 8;
        }
    }
}
