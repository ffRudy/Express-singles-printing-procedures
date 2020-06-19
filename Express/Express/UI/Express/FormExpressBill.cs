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
using Express.DAL;

namespace Express.UI.Express
{
    public partial class FormExpressBill : Form
    {
        public FormExpressBill()
        {
            InitializeComponent();
        }

        //实例化IDictionary泛型，用来存储“快递单类别编号”信息
        IDictionary<int, object> dicKeyValue = new Dictionary<int, object>();
        DataOperate dataOper = new DataOperate();//创建DataOperate类的对象，以便调用其中的方法
        CommClass cc = new CommClass();//创建CommClass类的对象，以便调用其中的方法
        string strExpressBillCodeColumn = null;//存储快递单号码列

        private string m_BillTypeCode;//定义快递单类别编号
        public string BillTypeCode//定义快递单类别编号属性
        {
            get//设置为只读属性
            {
                return m_BillTypeCode;
            }
        }
        private string m_ExpressBillCode;//定义快递单编号
        public string ExpressBillCode//定义快递单编号属性
        {
            get//设置为只读属性
            {
                return m_ExpressBillCode;
            }
        }

        private void FormExpressBill_Load(object sender, EventArgs e)
        {
            try
            {
                //获取单据类型数据源
                DataTable dt = dataOper.GetDataTable("Select BillTypeCode,BillTypeName From tb_BillType", "tb_BillType");
                for (int i = 0; i < dt.Rows.Count; i++)//循环读取数据源
                {
                    //向下拉列表中添加项
                    toolcbxBillTypeCode.Items.Insert(i, dt.Rows[i]["BillTypeName"]);
                    //使用IDictionary泛型封装“快递单类别编号”信息
                    dicKeyValue.Add(i, dt.Rows[i]["BillTypeCode"]);
                }
                if (toolcbxBillTypeCode.Items.Count > 0)//若存在单据种类记录
                {
                    toolcbxBillTypeCode.SelectedIndex = 0;//设置当前项索引为0
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void toolcbxBillTypeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolcbxBillTypeCode.Items.Count > 0)
            {
                dgvExpressBill.DataSource = null;//清除数据源
                dgvExpressBill.Columns.Clear();//清除现有列
                                               //根据选择的列表项索引，从泛型字典中取出快递单种类代码
                m_BillTypeCode = dicKeyValue[toolcbxBillTypeCode.SelectedIndex].ToString();
                DataTable dt = dataOper.GetDataTable("Select * From tb_BillTemplate Where BillTypeCode  = '" + m_BillTypeCode + "'", "tb_BillTemplate");//获取快递单模板信息
                if (dt.Rows.Count > 0)
                {
                    //获取单号控件的信息
                    DataRow drBillCode = dt.AsEnumerable().FirstOrDefault(itm => itm.Field<string>("IsFlag") == "1");
                    if (drBillCode != null)
                    {
                        //获取控件的唯一编号
                        strExpressBillCodeColumn = drBillCode["ControlId"].ToString();
                        dgvExpressBill.Columns.Add(strExpressBillCodeColumn, drBillCode["ControlName"].ToString());//向DataGridView控件中添加单据号列
                        dgvExpressBill.Columns[strExpressBillCodeColumn].DataPropertyName = strExpressBillCodeColumn; //设置单据号列绑定的数据库列
                                                                                                                      //设置单号列只读
                        dgvExpressBill.Columns[strExpressBillCodeColumn].ReadOnly = true;
                        foreach (DataRow dr in dt.Rows)//循环所有数据行
                        {
                            //添加代码列
                            if (dr["IsFlag"].ToString() == "0")//若不是单号控件
                            {
                                string strColumnName = dr["ControlId"].ToString();//获取控件编号
                                dgvExpressBill.Columns.Add(strColumnName, dr["ControlName"].ToString());//向DataGridView中添加列
                                dgvExpressBill.Columns[strColumnName].DataPropertyName = strColumnName;//设置当前列绑定的数据库列
                                                                                                       //设置当前列为只读
                                dgvExpressBill.Columns[strColumnName].ReadOnly = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("无法查询！", "信息提示");
                    }
                }
            }
        }

        private void toolQuery_Click(object sender, EventArgs e)
        {
            if (dgvExpressBill.Columns.Count > 0)//判断是否选择了单据类型
            {
                cc.ShowDialogForm(typeof(FormBrowseBill), "Query", this);//打开FormBrowseBill窗体
            }
        }

        private void toolcbxBillTypeCode_Click(object sender, EventArgs e)
        {

        }
    }
}