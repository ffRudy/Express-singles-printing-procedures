namespace Express.UI.New
{
    partial class FormOrderSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrderSearch));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txt_LogisticCode = new System.Windows.Forms.TextBox();
            this.cbox_ShipperCode = new System.Windows.Forms.ComboBox();
            this.txt_AcceptTime = new System.Windows.Forms.TextBox();
            this.txt_AcceptStation = new System.Windows.Forms.TextBox();
            this.txt_EBusinessID = new System.Windows.Forms.TextBox();
            this.txt_State = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(367, 82);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 29);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txt_LogisticCode
            // 
            this.txt_LogisticCode.Location = new System.Drawing.Point(177, 81);
            this.txt_LogisticCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_LogisticCode.Name = "txt_LogisticCode";
            this.txt_LogisticCode.Size = new System.Drawing.Size(180, 25);
            this.txt_LogisticCode.TabIndex = 1;
            // 
            // cbox_ShipperCode
            // 
            this.cbox_ShipperCode.FormattingEnabled = true;
            this.cbox_ShipperCode.Items.AddRange(new object[] {
            "ZTO",
            "YTO",
            "STO"});
            this.cbox_ShipperCode.Location = new System.Drawing.Point(16, 81);
            this.cbox_ShipperCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbox_ShipperCode.Name = "cbox_ShipperCode";
            this.cbox_ShipperCode.Size = new System.Drawing.Size(152, 23);
            this.cbox_ShipperCode.TabIndex = 2;
            this.cbox_ShipperCode.Text = "请选择快递公司";
            // 
            // txt_AcceptTime
            // 
            this.txt_AcceptTime.Location = new System.Drawing.Point(16, 160);
            this.txt_AcceptTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_AcceptTime.Name = "txt_AcceptTime";
            this.txt_AcceptTime.Size = new System.Drawing.Size(409, 25);
            this.txt_AcceptTime.TabIndex = 4;
            // 
            // txt_AcceptStation
            // 
            this.txt_AcceptStation.Location = new System.Drawing.Point(16, 194);
            this.txt_AcceptStation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_AcceptStation.Multiline = true;
            this.txt_AcceptStation.Name = "txt_AcceptStation";
            this.txt_AcceptStation.Size = new System.Drawing.Size(409, 87);
            this.txt_AcceptStation.TabIndex = 5;
            // 
            // txt_EBusinessID
            // 
            this.txt_EBusinessID.Location = new System.Drawing.Point(177, 126);
            this.txt_EBusinessID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_EBusinessID.Multiline = true;
            this.txt_EBusinessID.Name = "txt_EBusinessID";
            this.txt_EBusinessID.Size = new System.Drawing.Size(248, 25);
            this.txt_EBusinessID.TabIndex = 6;
            // 
            // txt_State
            // 
            this.txt_State.Location = new System.Drawing.Point(16, 126);
            this.txt_State.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_State.Name = "txt_State";
            this.txt_State.Size = new System.Drawing.Size(152, 25);
            this.txt_State.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 289);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "详细信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormOrderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(739, 331);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_State);
            this.Controls.Add(this.txt_EBusinessID);
            this.Controls.Add(this.txt_AcceptStation);
            this.Controls.Add(this.txt_AcceptTime);
            this.Controls.Add(this.cbox_ShipperCode);
            this.Controls.Add(this.txt_LogisticCode);
            this.Controls.Add(this.btnSearch);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOrderSearch";
            this.Text = "即时查询";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txt_LogisticCode;
        private System.Windows.Forms.ComboBox cbox_ShipperCode;
        private System.Windows.Forms.TextBox txt_AcceptTime;
        private System.Windows.Forms.TextBox txt_AcceptStation;
        private System.Windows.Forms.TextBox txt_EBusinessID;
        private System.Windows.Forms.TextBox txt_State;
        private System.Windows.Forms.Button button1;
    }
}