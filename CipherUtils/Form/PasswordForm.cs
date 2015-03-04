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
    public partial class PasswordForm : Form
    {
        private UserInfo user;
        public PasswordForm(UserInfo user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tOldPassword.Text) || string.IsNullOrEmpty(tNewPassword.Text) || string.IsNullOrEmpty(tNewPassword2.Text) || !tNewPassword.Text.Equals(tNewPassword2.Text) || !tOldPassword.Text.Equals(this.user.Password))
                MessageBox.Show("密码不正确或者为空！", "警告");
            else
            {
                this.user.Password = tNewPassword.Text;
                if (UserInfo.Update(this.user))
                {
                    MessageBox.Show("修改成功！", "警告");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    MessageBox.Show("修改异常！", "警告");
            }
        }
    }
}
