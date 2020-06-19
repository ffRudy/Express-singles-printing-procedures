﻿namespace Express.UI.Express
{
    partial class FormBrowseBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBrowseBill));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolQuery = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.panelBillPicture = new System.Windows.Forms.Panel();
            this.pbxBillPicture = new System.Windows.Forms.PictureBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pd = new System.Drawing.Printing.PrintDocument();
            this.toolStrip1.SuspendLayout();
            this.panelBillPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBillPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolQuery,
            this.toolSave,
            this.toolPrint,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(885, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolQuery
            // 
            this.toolQuery.Image = ((System.Drawing.Image)(resources.GetObject("toolQuery.Image")));
            this.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolQuery.Name = "toolQuery";
            this.toolQuery.Size = new System.Drawing.Size(52, 22);
            this.toolQuery.Text = "查询";
            this.toolQuery.Click += new System.EventHandler(this.toolQuery_Click);
            // 
            // toolSave
            // 
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(52, 22);
            this.toolSave.Text = "保存";
            // 
            // toolPrint
            // 
            this.toolPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolPrint.Image")));
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(52, 22);
            this.toolPrint.Text = "打印";
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(52, 22);
            this.toolExit.Text = "退出";
            // 
            // panelBillPicture
            // 
            this.panelBillPicture.Controls.Add(this.pbxBillPicture);
            this.panelBillPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBillPicture.Location = new System.Drawing.Point(0, 25);
            this.panelBillPicture.Name = "panelBillPicture";
            this.panelBillPicture.Size = new System.Drawing.Size(885, 494);
            this.panelBillPicture.TabIndex = 1;
            // 
            // pbxBillPicture
            // 
            this.pbxBillPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxBillPicture.Location = new System.Drawing.Point(0, 0);
            this.pbxBillPicture.Name = "pbxBillPicture";
            this.pbxBillPicture.Size = new System.Drawing.Size(885, 494);
            this.pbxBillPicture.TabIndex = 0;
            this.pbxBillPicture.TabStop = false;
            this.pbxBillPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxBillPicture_Paint);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // FormBrowseBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 519);
            this.Controls.Add(this.panelBillPicture);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBrowseBill";
            this.ShowInTaskbar = false;
            this.Text = "快递单据";
            this.Load += new System.EventHandler(this.FormBrowseBill_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBillPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBillPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolQuery;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.Panel panelBillPicture;
        private System.Windows.Forms.PictureBox pbxBillPicture;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument pd;
    }
}