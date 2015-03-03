using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CipherUtils
{
    public partial class KeyLoadForm : Form
    {
        public KeyLoadForm()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "配置文件|*.uky", Multiselect = false, InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) })
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.Copy(ofd.FileName, System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.uky"));
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        MessageBox.Show("导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            using (InitForm _if = new InitForm())
            {
                if (_if.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }
    }
}
