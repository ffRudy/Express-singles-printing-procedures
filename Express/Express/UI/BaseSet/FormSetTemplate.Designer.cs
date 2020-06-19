namespace Express.UI.BaseSet
{
    partial class FormSetTemplate
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuSetting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolAddCTextBox = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuSetting
            // 
            this.contextMenuSetting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddCTextBox,
            this.toolSave,
            this.toolExit});
            this.contextMenuSetting.Name = "contextMenuSetting";
            this.contextMenuSetting.Size = new System.Drawing.Size(137, 70);
            // 
            // toolAddCTextBox
            // 
            this.toolAddCTextBox.Name = "toolAddCTextBox";
            this.toolAddCTextBox.Size = new System.Drawing.Size(136, 22);
            this.toolAddCTextBox.Text = "添加输入框";
            this.toolAddCTextBox.Click += new System.EventHandler(this.toolAddCTextBox_Click);
            // 
            // toolSave
            // 
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(136, 22);
            this.toolSave.Text = "保存模板";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolExit
            // 
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(136, 22);
            this.toolExit.Text = "退出窗口";
            // 
            // FormSetTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 516);
            this.ContextMenuStrip = this.contextMenuSetting;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetTemplate";
            this.ShowInTaskbar = false;
            this.Text = "设计模板";
            this.Load += new System.EventHandler(this.FormSetTemplate_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSetTemplate_Paint);
            this.contextMenuSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuSetting;
        private System.Windows.Forms.ToolStripMenuItem toolAddCTextBox;
        private System.Windows.Forms.ToolStripMenuItem toolSave;
        private System.Windows.Forms.ToolStripMenuItem toolExit;
    }
}