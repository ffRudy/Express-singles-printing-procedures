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
    public partial class FormBillTypeInput : Form
    {
        public FormBillTypeInput()
        {
            InitializeComponent();
        }
        CommClass cc = new CommClass();
        FormBillType formBillType = null;

        private void FormBillTypeInput_Load(object sender, EventArgs e)
        {
            formBillType = (FormBillType)this.Owner;//将FormBillType窗体设置当前窗体的拥有者
            if (this.Tag.ToString() == "Add")//判断是否为添加操作
            {
                //自动生成单据编号
                txtBillTypeCode.Text = cc.BuildCode("tb_BillType", "", "BillTypeCode", "", 2);
            }
            else
            {
                //显示单据编号
                txtBillTypeCode.Text = formBillType.dgvBillType.CurrentRow.Cells["BillTypeCode"].Value.ToString();
                //显示单据名称
                txtBillTypeName.Text = formBillType.dgvBillType.CurrentRow.Cells["BillTypeName"].Value.ToString();
                //显示单据宽度
                txtBillWidth.Text = formBillType.dgvBillType.CurrentRow.Cells["BillWidth"].Value.ToString();
                //显示单据高度
                txtBillHeight.Text = formBillType.dgvBillType.CurrentRow.Cells["BillHeight"].Value.ToString();
                //显示单号位数
                txtBillCodeLength.Text = formBillType.dgvBillType.CurrentRow.Cells["BillCodeLength"].Value.ToString();
                txtRemark.Text = formBillType.dgvBillType.CurrentRow.Cells["Remark"].Value.ToString();//显示备注
                                                                                                      //获取单据图片
                pbxBillPicture.Image = cc.GetImageByBytes(formBillType.dgvBillType.CurrentRow.Cells["BillPicture"].Value as Byte[]);
                if (formBillType.dgvBillType.CurrentRow.Cells["IsEnabled"].Value.ToString() == "1")//判断单据是否启用的值
                {
                    rbIsEnabled1.Checked = true;//单据启用
                }
                else
                {
                    rbIsEnabled0.Checked = true;//单据未启用
                }
            }
        }
        private void btnChoice_Click(object sender, EventArgs e)
        {
            if (dlgPicture.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                //将选择的图片显示在图片控件中
                pbxBillPicture.Image = Image.FromFile(dlgPicture.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBillTypeName.Text.Trim()))//判断单据名称是否为空
            {
                MessageBox.Show("单据名称不许为空！", "软件提示");
                txtBillTypeName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtBillWidth.Text.Trim()))//判断单据宽度是否为空
            {
                MessageBox.Show("单据宽度不许为空！", "软件提示");
                txtBillWidth.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtBillHeight.Text.Trim()))//判断单据高度是否为空
            {
                MessageBox.Show("单据高度不许为空！", "软件提示");
                txtBillHeight.Focus();
                return;
            }
            if (pbxBillPicture.Image == null)//判断单据图片是否为空
            {
                MessageBox.Show("请选择单据图片！", "软件提示");
                return;
            }
            if (this.Tag.ToString() == "Add")//添加操作
            {
                //在DataGridView控件中添加新行
                DataGridViewRow dgvr = cc.AddDataGridViewRow(formBillType.dgvBillType, formBillType.bsBillType);
                dgvr.Cells["BillTypeCode"].Value = txtBillTypeCode.Text;//设置单据编号
                dgvr.Cells["BillTypeName"].Value = txtBillTypeName.Text.Trim();//设置单据名称
                dgvr.Cells["BillWidth"].Value = Convert.ToInt32(txtBillWidth.Text);//设置单据宽度
                dgvr.Cells["BillHeight"].Value = Convert.ToInt32(txtBillHeight.Text);//设置单据高度
                                                                                     //设置单号位数
                dgvr.Cells["BillCodeLength"].Value = Convert.ToInt32(txtBillCodeLength.Text);
                dgvr.Cells["Remark"].Value = txtRemark.Text.Trim();//设置备注
                                                                   //设置单据图片（二进制）
                dgvr.Cells["BillPicture"].Value = cc.GetBytesByImage(pbxBillPicture.Image);
                if (rbIsEnabled1.Checked)//判断是否启用
                {
                    dgvr.Cells["IsEnabled"].Value = "1";//1表示启用
                }
                else
                {
                    dgvr.Cells["IsEnabled"].Value = "0";//0表示未启用
                }
                //将添加操作提交数据库
                if (cc.Commit(formBillType.dgvBillType, formBillType.bsBillType))
                {
                    //弹出是否继续添加提示
                    if (MessageBox.Show("保存成功，是否继续添加？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        txtBillTypeCode.Text = cc.BuildCode("tb_BillType", "", "BillTypeCode", "", 2);//自动生成单据编号
                        txtBillTypeName.Text = "";//清空单据名称
                        txtBillWidth.Text = "";//清空单据宽度
                        txtBillHeight.Text = "";//清空单据高度
                        txtRemark.Text = "";//清空备注
                        pbxBillPicture.Image = null;//清空单据图片
                    }
                    else
                    {
                        this.Close();//关闭当前窗体
                    }
                }
                else
                {
                    MessageBox.Show("保存失败", "软件提示");
                }
            }
            if (this.Tag.ToString() == "Edit")//修改操作
            {
                //获取快递单设置窗体中选中的快递单
                DataGridViewRow dgvr = formBillType.dgvBillType.CurrentRow;
                dgvr.Cells["BillTypeName"].Value = txtBillTypeName.Text.Trim();//设置单据名称
                dgvr.Cells["BillWidth"].Value = Convert.ToInt32(txtBillWidth.Text);//设置单据宽度
                dgvr.Cells["BillHeight"].Value = Convert.ToInt32(txtBillHeight.Text);//设置单据高度
                                                                                     //设置单号位数
                dgvr.Cells["BillCodeLength"].Value = Convert.ToInt32(txtBillCodeLength.Text);
                dgvr.Cells["Remark"].Value = txtRemark.Text.Trim();//设置备注
                                                                   //设置单据图片（二进制）
                dgvr.Cells["BillPicture"].Value = cc.GetBytesByImage(pbxBillPicture.Image);
                if (rbIsEnabled1.Checked)//判断是否启用
                {
                    dgvr.Cells["IsEnabled"].Value = "1";//1表示启用
                }
                else
                {
                    dgvr.Cells["IsEnabled"].Value = "0";//0表示未启用
                }
                //将修改操作提交数据库
                if (cc.Commit(formBillType.dgvBillType, formBillType.bsBillType))
                {
                    MessageBox.Show("保存成功！", "软件提示");
                    this.Close();//关闭当前窗体
                }
                else
                {
                    MessageBox.Show("保存失败！", "软件提示");
                }
            }
        }

    }
}