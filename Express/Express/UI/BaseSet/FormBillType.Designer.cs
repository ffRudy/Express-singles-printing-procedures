namespace Express.UI.BaseSet
{
    partial class FormBillType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBillType));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolAmend = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.dgvBillType = new System.Windows.Forms.DataGridView();
            this.IsEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BillTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillHeigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillCodeLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsBillType = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBillType)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolAmend,
            this.toolDelete,
            this.toolStripSeparator1,
            this.toolSetting,
            this.toolStripSeparator2,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(701, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(52, 22);
            this.toolAdd.Text = "添加";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolAmend
            // 
            this.toolAmend.Image = ((System.Drawing.Image)(resources.GetObject("toolAmend.Image")));
            this.toolAmend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAmend.Name = "toolAmend";
            this.toolAmend.Size = new System.Drawing.Size(52, 22);
            this.toolAmend.Text = "修改";
            this.toolAmend.Click += new System.EventHandler(this.toolAmend_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(52, 22);
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolSetting
            // 
            this.toolSetting.Image = ((System.Drawing.Image)(resources.GetObject("toolSetting.Image")));
            this.toolSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSetting.Name = "toolSetting";
            this.toolSetting.Size = new System.Drawing.Size(76, 22);
            this.toolSetting.Text = "设计模板";
            this.toolSetting.Click += new System.EventHandler(this.toolSetting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(52, 22);
            this.toolExit.Text = "退出";
            // 
            // dgvBillType
            // 
            this.dgvBillType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsEnabled,
            this.BillTypeName,
            this.BillTypeCode,
            this.BillWidth,
            this.BillHeigh,
            this.BillCodeLength,
            this.Remark,
            this.BillPicture});
            this.dgvBillType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBillType.Location = new System.Drawing.Point(0, 25);
            this.dgvBillType.Name = "dgvBillType";
            this.dgvBillType.RowHeadersVisible = false;
            this.dgvBillType.RowTemplate.Height = 23;
            this.dgvBillType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillType.Size = new System.Drawing.Size(701, 416);
            this.dgvBillType.TabIndex = 1;
            // 
            // IsEnabled
            // 
            this.IsEnabled.DataPropertyName = "IsEnabled";
            this.IsEnabled.FalseValue = "0";
            this.IsEnabled.HeaderText = "是否启用";
            this.IsEnabled.Name = "IsEnabled";
            this.IsEnabled.TrueValue = "1";
            // 
            // BillTypeName
            // 
            this.BillTypeName.DataPropertyName = "BillTypeName";
            this.BillTypeName.HeaderText = "快递单名称";
            this.BillTypeName.Name = "BillTypeName";
            // 
            // BillTypeCode
            // 
            this.BillTypeCode.DataPropertyName = "BillTypeCode";
            this.BillTypeCode.HeaderText = "快递单代码";
            this.BillTypeCode.Name = "BillTypeCode";
            // 
            // BillWidth
            // 
            this.BillWidth.DataPropertyName = "BillWidth";
            this.BillWidth.HeaderText = "单据宽度";
            this.BillWidth.Name = "BillWidth";
            // 
            // BillHeigh
            // 
            this.BillHeigh.DataPropertyName = "BillHeigh";
            this.BillHeigh.HeaderText = "单据高度";
            this.BillHeigh.Name = "BillHeigh";
            // 
            // BillCodeLength
            // 
            this.BillCodeLength.DataPropertyName = "BillCodeLength";
            this.BillCodeLength.HeaderText = "单据号码位数";
            this.BillCodeLength.Name = "BillCodeLength";
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            // 
            // BillPicture
            // 
            this.BillPicture.DataPropertyName = "BillPicture";
            this.BillPicture.HeaderText = "快递单图片";
            this.BillPicture.Name = "BillPicture";
            this.BillPicture.Visible = false;
            // 
            // FormBillType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 441);
            this.Controls.Add(this.dgvBillType);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBillType";
            this.ShowInTaskbar = false;
            this.Text = "快递单设置";
            this.Load += new System.EventHandler(this.FormBillType_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBillType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolAmend;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        public System.Windows.Forms.DataGridView dgvBillType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillHeigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillCodeLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillPicture;
        public System.Windows.Forms.BindingSource bsBillType;
    }
}