namespace Express.UI.Express
{
    partial class FormExpressBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExpressBill));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolcbxBillTypeCode = new System.Windows.Forms.ToolStripComboBox();
            this.toolQuery = new System.Windows.Forms.ToolStripButton();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.dgvExpressBill = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpressBill)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolcbxBillTypeCode,
            this.toolQuery,
            this.toolPrint,
            this.toolDelete,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(883, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(99, 25);
            this.toolStripLabel1.Text = "选择快递公司";
            // 
            // toolcbxBillTypeCode
            // 
            this.toolcbxBillTypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolcbxBillTypeCode.Name = "toolcbxBillTypeCode";
            this.toolcbxBillTypeCode.Size = new System.Drawing.Size(160, 28);
            this.toolcbxBillTypeCode.SelectedIndexChanged += new System.EventHandler(this.toolcbxBillTypeCode_SelectedIndexChanged);
            this.toolcbxBillTypeCode.Click += new System.EventHandler(this.toolcbxBillTypeCode_Click);
            // 
            // toolQuery
            // 
            this.toolQuery.Image = ((System.Drawing.Image)(resources.GetObject("toolQuery.Image")));
            this.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolQuery.Name = "toolQuery";
            this.toolQuery.Size = new System.Drawing.Size(63, 25);
            this.toolQuery.Text = "查询";
            this.toolQuery.Click += new System.EventHandler(this.toolQuery_Click);
            // 
            // toolPrint
            // 
            this.toolPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolPrint.Image")));
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(63, 25);
            this.toolPrint.Text = "打印";
            // 
            // toolDelete
            // 
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(63, 25);
            this.toolDelete.Text = "删除";
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(63, 25);
            this.toolExit.Text = "退出";
            // 
            // dgvExpressBill
            // 
            this.dgvExpressBill.AllowUserToAddRows = false;
            this.dgvExpressBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpressBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpressBill.Location = new System.Drawing.Point(0, 28);
            this.dgvExpressBill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvExpressBill.Name = "dgvExpressBill";
            this.dgvExpressBill.RowHeadersVisible = false;
            this.dgvExpressBill.RowTemplate.Height = 23;
            this.dgvExpressBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpressBill.Size = new System.Drawing.Size(883, 467);
            this.dgvExpressBill.TabIndex = 1;
            // 
            // FormExpressBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 495);
            this.Controls.Add(this.dgvExpressBill);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExpressBill";
            this.ShowInTaskbar = false;
            this.Text = "快递单查询";
            this.Load += new System.EventHandler(this.FormExpressBill_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpressBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolcbxBillTypeCode;
        private System.Windows.Forms.ToolStripButton toolQuery;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripButton toolExit;
        public System.Windows.Forms.DataGridView dgvExpressBill;
    }
}