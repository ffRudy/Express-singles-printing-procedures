using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Express.Common;
using Express.UI.BaseSet;
using Express.UI.Express;
using Express.UI.New;

namespace Express
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
        }
        CommClass cc = new CommClass();
        private void AppForm_Load(object sender, EventArgs e)
        {

        }

        private void menuItemSetBill_Click(object sender, EventArgs e)
        {
            cc.ShowFormByMdiParent(typeof(FormBillType), this);//打开快递单设置窗体
        }

        private void menuItemBillPrint_Click(object sender, EventArgs e)
        {
            cc.ShowFormByMdiParent(typeof(FormBillPrint), this); //打开快递单打印窗体
        }

        private void menuItemBillQuery_Click(object sender, EventArgs e)
        {
            cc.ShowFormByMdiParent(typeof(FormExpressBill), this); //打开快递单查询窗体
        }

        private void toolBillPrint_Click(object sender, EventArgs e)
        {
            cc.ShowFormByMdiParent(typeof(FormExpressOrder), this); //打开电子面单窗体
        }

        private void toolBillQuery_Click(object sender, EventArgs e)
        {
            cc.ShowFormByMdiParent(typeof(FormOrderDistinguish), this); //打开单号查询窗体
        }

        private void toolSetBill_Click(object sender, EventArgs e)
        {
            cc.ShowFormByMdiParent(typeof(FormCreateOrder), this); //打开单号查询窗体
        }

        private void toolSetOperator_Click(object sender, EventArgs e)
        {
            cc.ShowFormByMdiParent(typeof(FormOrderSearch), this); //打开单号查询窗体
        }
    }
}
