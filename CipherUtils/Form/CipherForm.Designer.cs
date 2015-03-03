namespace CipherUtils
{
    partial class CipherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CipherForm));
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.textBoxSrc = new System.Windows.Forms.TextBox();
            this.textBoxDest = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "加密",
            "解密"});
            this.comboBoxType.Location = new System.Drawing.Point(5, 4);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(70, 20);
            this.comboBoxType.TabIndex = 0;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(5, 27);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.textBoxSrc);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.textBoxDest);
            this.splitContainerMain.Size = new System.Drawing.Size(377, 144);
            this.splitContainerMain.SplitterDistance = 55;
            this.splitContainerMain.TabIndex = 1;
            // 
            // textBoxSrc
            // 
            this.textBoxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSrc.Location = new System.Drawing.Point(0, 0);
            this.textBoxSrc.Multiline = true;
            this.textBoxSrc.Name = "textBoxSrc";
            this.textBoxSrc.Size = new System.Drawing.Size(377, 55);
            this.textBoxSrc.TabIndex = 0;
            // 
            // textBoxDest
            // 
            this.textBoxDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDest.Location = new System.Drawing.Point(0, 0);
            this.textBoxDest.Multiline = true;
            this.textBoxDest.Name = "textBoxDest";
            this.textBoxDest.Size = new System.Drawing.Size(377, 85);
            this.textBoxDest.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(81, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "执行";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CipherForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 175);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.comboBoxType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CipherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文本加密解密";
            this.Load += new System.EventHandler(this.CipherForm_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TextBox textBoxSrc;
        private System.Windows.Forms.TextBox textBoxDest;
        private System.Windows.Forms.Button btnOK;
    }
}