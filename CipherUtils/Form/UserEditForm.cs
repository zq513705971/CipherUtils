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
    public partial class UserEditForm : Form
    {
        private bool edit = false;
        private UserInfo user;
        public UserEditForm(bool edit, UserInfo user)
        {
            InitializeComponent();
            this.Text = edit ? "用户编辑" : "添加用户";
            this.edit = edit;
            this.user = user;
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            tUserName.Enabled = !this.edit;
            if (this.user != null)
            {
                tUserName.Text = this.user.UserName;
                tPassword.Text = this.user.Password;
                dateTimePickerEncrypt.Value = this.user.EncryptDate;
                dateTimePickerDecrypt.Value = this.user.DecryptDate;
                checkBoxAdmin.Checked = this.user.IsAdmin;
                checkBoxEncrypt.Checked = this.user.Encrypt;
                checkBoxDecrypt.Checked = this.user.Decrypt;
            }
            else
            {
                checkBoxAdmin.Checked = false;
                checkBoxEncrypt.Checked = false;
                checkBoxDecrypt.Checked = false;
                dateTimePickerEncrypt.Value = DateTime.Now.AddMonths(1);
                dateTimePickerDecrypt.Value = DateTime.Now.AddMonths(1);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.user != null)
            {
                this.user.IsAdmin = checkBoxAdmin.Checked;
                this.user.Password = (tPassword.Text + RsaCode.Prefix).Substring(0, 8);
                this.user.Encrypt = checkBoxEncrypt.Checked;
                this.user.EncryptDate = dateTimePickerEncrypt.Value;
                this.user.Decrypt = checkBoxDecrypt.Checked;
                this.user.DecryptDate = dateTimePickerDecrypt.Value;
                if (this.user.IsValid)
                {
                    if (UserInfo.Update(this.user))
                    {
                        MessageBox.Show("保存成功！", "提示");
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("请为该用户分配至少一个有效权限！", "提示");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(tUserName.Text) || string.IsNullOrEmpty(tPassword.Text))
                {
                    MessageBox.Show("请输入用户名或密码...", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.user = new UserInfo() { UserName = tUserName.Text, Password = (tPassword.Text + RsaCode.Prefix).Substring(0, 8), IsAdmin = checkBoxAdmin.Checked, Encrypt = checkBoxEncrypt.Checked, EncryptDate = dateTimePickerEncrypt.Value, Decrypt = checkBoxDecrypt.Checked, DecryptDate = dateTimePickerDecrypt.Value };
                if (this.user.IsValid)
                {
                    if (!UserInfo.HasUser(this.user.UserName))
                    {
                        if (UserInfo.Add(this.user))
                        {
                            MessageBox.Show("添加用户成功！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        else
                            MessageBox.Show("添加用户异常！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("已存在该用户名！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("请为该用户分配至少一个有效权限！", "提示");
                }
            }
        }

        private void checkBoxEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerEncrypt.Visible = checkBoxEncrypt.Checked;
        }

        private void checkBoxDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerDecrypt.Visible = checkBoxDecrypt.Checked;
        }
    }
}
