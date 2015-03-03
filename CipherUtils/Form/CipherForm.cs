using IBS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CipherUtils
{
    public partial class CipherForm : Form
    {
        private bool encrypt = false;
        private DESKeyInfo key;
        private UserInfo user;
        public CipherForm(UserInfo user, bool encrypt)
        {
            InitializeComponent();
            this.encrypt = encrypt;
            this.user = user;
        }

        private void CipherForm_Load(object sender, EventArgs e)
        {
            bool valid = true;
            if (!this.user.Encrypt || this.user.EncryptDate <= DateTime.Now)
                valid = false;
            if (!this.user.Decrypt || this.user.DecryptDate <= DateTime.Now)
                valid = false;
            if (!valid)
                comboBoxType.Enabled = false;
            comboBoxType.SelectedIndex = encrypt ? 0 : 1;
            this.key = DESKeyInfo.GetInstance();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.encrypt = comboBoxType.SelectedIndex == 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string src = textBoxSrc.Text;
                if (string.IsNullOrEmpty(src))
                {
                    MessageBox.Show(string.Format("待{0}密文本为空！", this.encrypt ? "加" : "解"), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (encrypt)
                    textBoxDest.Text = DESCode.DESEncrypt(src, this.key.Key);
                else
                    textBoxDest.Text = DESCode.DESDecrypt(src, this.key.Key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
