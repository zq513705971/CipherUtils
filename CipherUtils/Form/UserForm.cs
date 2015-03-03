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
    public partial class UserForm : Form
    {
        private UserInfo User;
        public UserForm(UserInfo user)
        {
            InitializeComponent();
            this.User = user;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            DataTable data = dataGridViewMain.DataSource as DataTable;
            if (data != null)
                data.Rows.Clear();
            dataGridViewMain.DataSource = UserInfo.GetAllUsers();
        }

        private void dataGridViewMain_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = dataGridViewMain.CurrentRow.Cells;
            UserInfo user = new UserInfo() { UserName = cells[0].Value.ToString(), Password = cells[1].Value.ToString(), IsAdmin = Convert.ToInt32(cells[2].Value) == 1, Encrypt = Convert.ToInt32(cells[3].Value) == 1, EncryptDate = Convert.ToDateTime(cells[4].Value), Decrypt = Convert.ToInt32(cells[5].Value) == 1, DecryptDate = Convert.ToDateTime(cells[6].Value) };
            using (UserEditForm uef = new UserEditForm(true, user))
            {
                if (uef.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadUsers();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (UserEditForm uef = new UserEditForm(false, null))
            {
                if (uef.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadUsers();
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选中任何行数据...", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewCellCollection cells = dataGridViewMain.CurrentRow.Cells;
            UserInfo user = new UserInfo() { UserName = cells[0].Value.ToString(), Password = cells[1].Value.ToString(), IsAdmin = Convert.ToInt32(cells[2].Value) == 1, Encrypt = Convert.ToInt32(cells[3].Value) == 1, EncryptDate = Convert.ToDateTime(cells[4].Value), Decrypt = Convert.ToInt32(cells[5].Value) == 1, DecryptDate = Convert.ToDateTime(cells[6].Value) };
            if (!user.UserName.Equals("administrator"))
            {
                if (MessageBox.Show(string.Format("确认删除\"{0}\"用户？", user.UserName), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!UserInfo.Delete(cells[0].Value.ToString()))
                        MessageBox.Show(string.Format("删除\"{0}\"用户异常！", user.UserName), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        LoadUsers();
                        MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("不允许删除\"administrator\"用户！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnOutputKey_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { ShowNewFolderButton = true, Description = "请选择保存密钥的路径", RootFolder = Environment.SpecialFolder.Desktop })
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = fbd.SelectedPath;
                    try
                    {
#if RSA
                        RsaKeyInfo key = RsaKeyInfo.GetInstance();
                        if (this.User.UserName.Equals("ruiyuan"))
                        {
                            using (StreamWriter writer = new StreamWriter(Path.Combine(path, "PrivateKey.key")))
                            {
                                writer.WriteLine(DESCode.DESEncrypt(key.PrivateKey, RsaCode.Prefix));
                            }
                        }
                        using (StreamWriter writer = new StreamWriter(Path.Combine(path, "PublicKey.key")))
                        {
                            writer.WriteLine(DESCode.DESEncrypt(key.PublicKey, RsaCode.Prefix));
                        }
                        MessageBox.Show("导出密钥成功！", "提示");
#else
                        KeyInfo deskey = KeyInfo.GetInstance();
                        using (StreamWriter writer = new StreamWriter(Path.Combine(path, "Key.key")))//使用“ibs.tech”加密DES密钥
                        {
                            writer.WriteLine(DESCode.DESEncrypt(deskey.Key, RsaCode.Prefix));
                        }
                        MessageBox.Show("导出密钥成功！\nKey.key：提供给项目上使用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //TODO:Loader使用固定密码“ibs.tech”对“Key.key”内容解密得出DES加密、解密密钥；
#endif
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("导出密钥异常！\n{0}", ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
