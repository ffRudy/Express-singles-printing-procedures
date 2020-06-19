using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Express.Common;
namespace Express.UI.BaseSet
{
    public partial class FormBillType : Form
    {
        public FormBillType()
        {
            InitializeComponent();
        }
        CommClass cc = new CommClass();

        private void FormBillType_Load(object sender, EventArgs e)
        {
            bsBillType.DataSource = cc.GetDataTable("tb_BillType", "");//获取快递单信息
            dgvBillType.DataSource = bsBillType;//将快递单信息绑定到dgvBillType控件中
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            cc.ShowDialogForm(typeof(FormBillTypeInput), "Add", this);//打开快递单基本信息窗体
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            if (dgvBillType.SelectedRows.Count > 0) //如果选中了记录
            {
                cc.ShowDialogForm(typeof(FormBillTypeInput), "Edit", this); //打开快递单修改窗体
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (dgvBillType.SelectedRows.Count == 0)//判断是否选中要删除的行
            {
                return;
            }
            if (MessageBox.Show("确定要删除吗？", "软件提示", MessageBoxButtons.YesNo,
        MessageBoxIcon.Exclamation) == DialogResult.Yes) //弹出确认删除对话框
            {
                //判断是否存在要删除的记录
                if (cc.IsExistConstraint("tb_BillType", dgvBillType.CurrentRow.Cells["BillTypeCode"].Value.ToString()))
                {
                    if (MessageBox.Show("此种快递单已生成模板，若删除将级联删除对应的模板和快递单记录，是否继续？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return;
                    }
                }
                DataGridViewRow dgvr = dgvBillType.CurrentRow;//获取当前选中行
                dgvBillType.Rows.Remove(dgvr);//从数据表格中移出选中行
                if (cc.Commit(dgvBillType, bsBillType))//将删除操作提交数据库执行
                {
                    MessageBox.Show("删除成功！", "软件提示");
                }
                else
                {
                    MessageBox.Show("删除失败！", "软件提示");
                }
            }
        }
        private void toolSetting_Click(object sender, EventArgs e)
        {
            if (dgvBillType.RowCount > 0)//判断是否选中行
            {
                cc.ShowDialogForm(typeof(FormSetTemplate), "", this);//打开设计模板窗体
            }
        }
    }
}
