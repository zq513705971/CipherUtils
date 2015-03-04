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
    public partial class MainForm : Form
    {
        private UserInfo user;
#if RSA
        private RsaKeyInfo key;
#else
        private KeyInfo deskey;
#endif
        public MainForm(UserInfo user)
        {
            InitializeComponent();
            this.user = user;
#if RSA
            this.key = RsaKeyInfo.GetInstance();
#else
            this.deskey = KeyInfo.GetInstance();
#endif
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Modifiers)
            {
                case Keys.Control:
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.E:
                                {
                                    if (this.user.Encrypt && this.user.EncryptDate > DateTime.Now)
                                    {
                                        using (CipherForm cf = new CipherForm(this.user, true))
                                        {
                                            cf.ShowDialog();
                                        }
                                    }
                                    else
                                        MessageBox.Show("当前用户无加密权限，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                break;
                            case Keys.D:
                                {
                                    if (this.user.Decrypt && this.user.DecryptDate > DateTime.Now)
                                    {
                                        using (CipherForm cf = new CipherForm(this.user, false))
                                        {
                                            cf.ShowDialog();
                                        }
                                    }
                                    else
                                        MessageBox.Show("当前用户无解密权限，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        private void pictureBoxMain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否注销？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (Login login = new Login())
                {
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        this.user = login.User;
                        reLoad();
                    }
                    else
                        Application.Exit();
                }
            }
        }

        private void reLoad()
        {
            llbDbManager.Visible = this.user.UserName == "ruiyuan";
            llbUserManager.Visible = this.user.IsAdmin;
            pictureBoxMain.Image = Resource._lock;
            UpdateStatusText("", false);
            if (this.user.Encrypt && this.user.EncryptDate > DateTime.Now)
                tabControlMain.SelectedIndex = 0;
            else if (this.user.Decrypt && this.user.DecryptDate > DateTime.Now)
                tabControlMain.SelectedIndex = 1;
            else
            {
                tabControlMain.Enabled = false;
                btnRun.Enabled = false;
                if (MessageBox.Show("无加、解密权限或者权限已经过期，是否重新导入配置文件？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "配置文件|*.uky", Multiselect = false, InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) })
                    {
                        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            try
                            {
                                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.uky");
                                if (File.Exists(dbPath))
                                    File.Delete(dbPath);
                                File.Copy(ofd.FileName, dbPath);
                                SQLiteDataHelper.SetSQLiteConnection(dbPath);
                                btnRun.Enabled = true;
                                this.user = UserInfo.GetUser(this.user.UserName);
                                if (this.user != null)
                                    MessageBox.Show("导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    MessageBox.Show("当前用户已被禁用，请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    Application.Exit();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Application.Exit();
                            }
                        }
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void llbDbManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (DbForm dbf = new DbForm())
            {
                dbf.ShowDialog();
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string ext = Path.GetExtension(path);
            if (!ext.ToUpper().Equals(".CSV"))
            {
                MessageBox.Show("请选择CSV文件...", "警告");
                return;
            }
            if (tabControlMain.SelectedIndex == 0)
                tEncryptPath.Text = path;
            else
                tDecryptPath.Text = path;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void llbUserManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (UserForm uf = new UserForm(this.user))
            {
                uf.ShowDialog();
            }
        }

        private void lbPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (PasswordForm pf = new PasswordForm(this.user))
            {
                pf.ShowDialog();
            }
        }

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            Bitmap image = new Bitmap(100, 45);
            Graphics g = Graphics.FromImage(image);
            try
            {
                bool selected = tabControlMain.SelectedIndex == e.Index;
                string[] tabs = new string[2] { "加密", "解密" };
                Font font = null;
                if (!selected)
                    font = new Font(e.Font.FontFamily, 11, FontStyle.Regular);
                else
                    font = new Font(e.Font.FontFamily, 11, FontStyle.Regular | FontStyle.Underline);

                using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Black, Color.Black, 0, false))
                {
                    g.DrawString(tabs[e.Index], font, brush, 25, 15);
                }
                g.DrawRectangle(new Pen(Color.White), 0, 0, selected ? image.Width : image.Width, selected ? image.Height : image.Height);
            }
            finally
            {
                g.Dispose();
            }
            e.Graphics.DrawImage(image, e.Bounds);
        }

        private void tabControlMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0 && (!this.user.Encrypt || this.user.EncryptDate < DateTime.Now))
            {
                if (!this.user.Encrypt)
                {
                    e.Cancel = true;
                    MessageBox.Show("无加密权限！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.user.EncryptDate < DateTime.Now)
                {
                    e.Cancel = true;
                    MessageBox.Show("加密权限已过，请联系管理员！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.TabPageIndex == 1)
            {
                if (!this.user.Decrypt)
                {
                    e.Cancel = true;
                    MessageBox.Show("无解密权限！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (this.user.DecryptDate < DateTime.Now)
                {
                    e.Cancel = true;
                    MessageBox.Show("解密权限已过，请联系管理员！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (this.executing)
            {
                e.Cancel = true;
                MessageBox.Show("正在执行操作，请在执行结束之后再进行切换！", "警告");
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxMain.Image = tabControlMain.SelectedIndex == 0 ? Resource._lock : Resource.unlock;
        }

        #region Decrypt
        private void decryptSelect()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Csv文件|*.csv|Txt文件|*.txt|所有文件|*.*", Multiselect = false, InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) })
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tDecryptPath.Text = ofd.FileName;
                }
            }
        }

        private void btnDecryptSelect_Click(object sender, EventArgs e)
        {
            decryptSelect();
        }

        private DataTable decryptResult;
        private void btnDecryptImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tDecryptPath.Text))
            {
                MessageBox.Show("请选择需要导入的文件路径...", "警告");
                return;
            }
            try
            {
                UpdateStatusText("开始导入数据...", true);
                decryptResult = Worker.Load(tDecryptPath.Text, 20);
                BindingData(checkedListBoxDecrypt, dataGridViewDecrypt, decryptResult, true);
                UpdateStatusText("导入数据完成.", false);
            }
            catch (Exception ex)
            {
                UpdateStatusText(string.Format("导入数据异常：{0}.", ex.Message), false);
            }
        }

        private void tDecryptPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            decryptSelect();
        }

        private void checkedListBoxDecrypt_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                List<int> columns = new List<int>();
                foreach (object obj in checkedListBoxDecrypt.CheckedItems)
                {
                    CheckBoxColumn column = (CheckBoxColumn)obj;
                    columns.Add(column.Index);
                }
                if (e.NewValue == CheckState.Checked)
                    columns.Add(e.Index);
                else
                    columns.Remove(e.Index);
#if RSA
                DataTable result = Worker.Decrypt(decryptResult, this.key.PrivateKey, columns.ToArray());
#else
                DataTable result = Worker.Decrypt(decryptResult, this.deskey.Key, columns.ToArray());
#endif
                BindingData(checkedListBoxDecrypt, dataGridViewDecrypt, result, false);
            }
            catch
            {
                e.NewValue = e.CurrentValue;
                MessageBox.Show("请确认列表中所选择列下的数据是否为加密后数据！", "提示");
            }
        }
        #endregion

        #region Encrypt
        private void encryptSelect()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Csv文件|*.csv|Txt文件|*.txt|所有文件|*.*", Multiselect = false, InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) })
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tEncryptPath.Text = ofd.FileName;
                }
            }
        }

        private void tEncryptPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            encryptSelect();
        }

        private void btnEncryptSelect_Click(object sender, EventArgs e)
        {
            encryptSelect();
        }

        private DataTable encryptResult;
        private void btnEncryptImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tEncryptPath.Text))
            {
                MessageBox.Show("请选择需要导入的文件路径...", "警告");
                return;
            }
            try
            {
                UpdateStatusText("开始导入数据...", true);
                encryptResult = Worker.Load(tEncryptPath.Text, 20);
                BindingData(checkedListBoxEncrypt, dataGridViewEncrypt, encryptResult, true);
                UpdateStatusText("导入数据完成.", false);
            }
            catch (Exception ex)
            {
                UpdateStatusText(string.Format("导入数据异常：{0}.", ex.Message), false);
            }
        }

        private void checkedListBoxEncrypt_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                List<int> columns = new List<int>();
                foreach (object obj in checkedListBoxEncrypt.CheckedItems)
                {
                    CheckBoxColumn column = (CheckBoxColumn)obj;
                    columns.Add(column.Index);
                }
                if (e.NewValue == CheckState.Checked)
                    columns.Add(e.Index);
                else
                    columns.Remove(e.Index);
#if RSA
                DataTable result = Worker.Encrypt(encryptResult, this.key.PublicKey, columns.ToArray());
#else
                DataTable result = Worker.Encrypt(encryptResult, this.deskey.Key, columns.ToArray());
#endif
                BindingData(checkedListBoxEncrypt, dataGridViewEncrypt, result, false);
            }
            catch
            {
                MessageBox.Show("请确认列表中所选择列下的数据是否为加密后数据！", "提示");
            }
        }
        #endregion

        #region Common
        private void BindingData(CheckedListBox checklistbox, DataGridView view, DataTable dt, bool isNew)
        {
            if (checklistbox.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    BindingDataSource(checklistbox, view, dt, isNew);
                }));
            }
            else
                BindingDataSource(checklistbox, view, dt, isNew);
        }

        private void BindingDataSource(CheckedListBox checklistbox, DataGridView view, DataTable dt, bool isNew)
        {
            view.DataSource = dt;
            if (isNew)
            {
                checklistbox.Items.Clear();
                if (dt != null)
                {
                    CheckBoxColumn[] columns = new CheckBoxColumn[dt.Columns.Count];
                    int index = 0;
                    foreach (DataColumn column in dt.Columns)
                    {
                        columns[index++] = new CheckBoxColumn(column);
                    }
                    checklistbox.Items.AddRange(columns);
                }
            }
        }

        private bool executing = false;
        private void UpdateStatusText(string msg, bool executing)
        {
            this.executing = executing;
            if (btnRun.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    lbStatus.Text = msg;
                    btnRun.Enabled = !this.executing;
                    btnCancel.Enabled = this.executing;
                    btnEncryptSelect.Enabled = !this.executing;
                    btnEncryptImport.Enabled = !this.executing;
                    btnDecryptSelect.Enabled = !this.executing;
                    btnDecryptImport.Enabled = !this.executing;
                    tEncryptPath.Enabled = !this.executing;
                    tDecryptPath.Enabled = !this.executing;
                }));
            }
            else
            {
                lbStatus.Text = msg;
                btnRun.Enabled = !this.executing;
                btnCancel.Enabled = this.executing;
                btnEncryptSelect.Enabled = !this.executing;
                btnEncryptImport.Enabled = !this.executing;
                btnDecryptSelect.Enabled = !this.executing;
                btnDecryptImport.Enabled = !this.executing;
                tEncryptPath.Enabled = !this.executing;
                tDecryptPath.Enabled = !this.executing;
            }
        }

        private bool UpdateStatus(string msg)
        {
            if (lbStatus.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    lbStatus.Text = msg;
                }));
            }
            else
                lbStatus.Text = msg;
            return this.executing;
        }
        #endregion
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UpdateStatusText("取消...", false);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(tEncryptPath.Text))
                {
                    MessageBox.Show("未选择任何数据文件...", "警告");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(tDecryptPath.Text))
                {
                    MessageBox.Show("未选择任何数据文件...", "警告");
                    return;
                }
            }
            runSave(tabControlMain.SelectedIndex == 0);
        }

        private void runSave(bool encrypt)
        {
            List<int> columns = new List<int>();
            foreach (object obj in encrypt ? checkedListBoxEncrypt.CheckedItems : checkedListBoxDecrypt.CheckedItems)
            {
                CheckBoxColumn column = (CheckBoxColumn)obj;
                columns.Add(column.Index);
            }
            if (columns.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Title = string.Format("请选择保存{0}后文件路径", encrypt ? "加密" : "解密"), Filter = "CSV文件|*.csv", InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) })
                {
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string dest = sfd.FileName;
                        UpdateStatusText(string.Format("开始{0}数据...", encrypt ? "加密" : "解密"), true);
                        Utils.RunBackgroundWorker(backgroundWorkerMain, (sender1, ex1) =>
                        {
#if TIMER
                            CodeTimer.Time("running", 1, () =>
                            {
#endif
                                try
                                {
                                    int rowCount = 0;
#if RSA
                                    if (encrypt)
                                        rowCount = RsaCode.RSAEncrypt(this.key.PublicKey, tEncryptPath.Text, dest, columns.ToArray(), UpdateStatus);
                                    else
                                        rowCount = RsaCode.RSADecrypt(this.key.PrivateKey, tDecryptPath.Text, dest, columns.ToArray(), UpdateStatus);
#elif DES
                                    if (encrypt)
                                        rowCount = DESCode.DESEncrypt(this.deskey.Key, tEncryptPath.Text, dest, columns.ToArray(), UpdateStatus);
                                    else
                                        rowCount = DESCode.DESDecrypt(this.deskey.Key, tDecryptPath.Text, dest, columns.ToArray(), UpdateStatus);
#else
                                    if (encrypt)
                                        rowCount = AESCode.AESEncrypt(this.deskey.Key, tEncryptPath.Text, dest, columns.ToArray(), UpdateStatus);
                                    else
                                        rowCount = AESCode.AESDecrypt(this.deskey.Key, tDecryptPath.Text, dest, columns.ToArray(), UpdateStatus);
#endif
                                    ex1.Result = new Msg() { Result = true, Message = string.Format("共处理数据{0}行...", rowCount) };
                                }
                                catch (Exception ex)
                                {
                                    ex1.Result = new Msg() { Result = false, Message = ex.Message };
                                }
#if TIMER
                            });
#endif
                        }, (sender2, ex2) =>
                        {
                            Msg msg = ex2.Result as Msg;
                            if (!msg.Result)
                                UpdateStatusText(msg.Message, false);
                            else
                                UpdateStatusText(string.Format("执行结束，{0}", msg.Message), false);
                        });
                    }
                }
            }
            else
                MessageBox.Show(string.Format("未指定{0}列...", encrypt ? "加密" : "解密"), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        class Msg
        {
            public bool Result { get; set; }
            public string Message { get; set; }
        }
    }
}
