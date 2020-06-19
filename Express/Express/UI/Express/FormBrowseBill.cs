using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Express.Common;
using Express.DAL;
using Express.CusControl;

namespace Express.UI.Express
{
    public partial class FormBrowseBill : Form
    {
        public FormBrowseBill()
        {
            InitializeComponent();
        }

        private CTextBox ctxt = null;//创建自定义组件对象
        private DataOperate dataOper = new DataOperate();//创建DataOperate类的对象，以便调用其中的方法
        private CommClass cc = new CommClass();//创建CommClass类的对象，以便调用其中的方法
        private DataTable dtBillType = null;//快递单信息的DataTable数据源
        FormExpressBill formExpressBill = null;//创建快递单查询窗体对象
        CTextBox ctxtExpressBillCode = null;  //表示快递单号的CTextBox
        string strBillTypeCode = null;//记录单据类型编号
        string strExpressBillCode = null;//记录快递单编号
        float fDpiX;//记录水平分辨率
        float fDpiY;//记录垂直分辨率

        public void InitTemplate(string strBillTypeCode)
        {
            //定义根据编号获取模板的SQL语句
            string strSql = "Select * From tb_BillTemplate Where BillTypeCode = '" + strBillTypeCode + "'";
            try
            {
                //获取模板信息
                DataTable dt = dataOper.GetDataTable(strSql, "tb_BillTemplate");
                foreach (DataRow dr in dt.Rows)//遍历获取到的所有行
                {
                    ctxt = new CTextBox();//实例化自定义控件对象
                    ctxt.ContextMenuStrip = null;//设置快捷菜单为空
                    ctxt.IsFlag = dr["IsFlag"].ToString();//是否为对应控件
                    ctxt.ControlId = Convert.ToInt32(dr["ControlId"]);//设置控件ID
                                                                      //设置控件位置
                    ctxt.Location = new Point(Convert.ToInt32(dr["X"]), Convert.ToInt32(dr["Y"]));
                    //设置控件大小
                    ctxt.Size = new Size(Convert.ToInt32(dr["Width"]),
        Convert.ToInt32(dr["Height"]));
                    ctxt.ControlName = dr["ControlName"].ToString();//设置控件默认名称
                    if (ctxt.IsFlag == "1")  //若是单据号码对应的控件
                    {
                        ctxtExpressBillCode = ctxt;  //得到表示快递单号的CTextBox
                                                     //设置控件的字体
                        ctxt.Font = new Font(new FontFamily("宋体"), 9, FontStyle.Bold);
                        //设置控件的最大长度
                        ctxt.MaxLength = Convert.ToInt32(dtBillType.Rows[0]["BillCodeLength"]);
                    }
                    this.panelBillPicture.Controls.Add(this.ctxt);//将控件添加到Panel容器中
                }
                //将图片添加到Panel容器中
                this.panelBillPicture.Controls.Add(this.pbxBillPicture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
            }
        }

        public List<CTextBox> GetCTextBoxes(Control control)//获取所有CTextBox组件集合
        {
            List<CTextBox> ctxts = new List<CTextBox>();//创建CTextBox集合对象
            foreach (Control con in control.Controls)//遍历指定容器中的所有控件
            {
                if (con.GetType() == typeof(CTextBox))//如果类型是CTextBox
                {
                    ctxts.Add((CTextBox)con);//将其添加到List集合中
                }
                if (con.GetType() == typeof(GroupBox))//如果类型是GroupBox
                {
                    this.GetCTextBoxes(con);//递归执行当前方法
                }
                if (con.GetType() == typeof(SplitContainer))//如果类型是SplitContainer
                {
                    this.GetCTextBoxes(con);//递归执行当前方法
                }
                if (con.GetType() == typeof(SplitterPanel))//如果类型是SplitterPanel
                {
                    this.GetCTextBoxes(con);//递归执行当前方法
                }
            }
            return ctxts;//返回得到的CTextBox集合
        }

        public void InitText(string strBillTypeCode, string strExpressBillCode)//初始化文本框组件
        {
            //定义根据单据类型编号获取快递单历史信息的SQL语句
            string strSql = "Select * From tb_BillText Where BillTypeCode = '" + strBillTypeCode + "' and ExpressBillCode = '" + strExpressBillCode + "'";
            try
            {
                //将获取的快递单信息存储到DataTable中
                DataTable dt = dataOper.GetDataTable(strSql, "tb_BillText");
                //获取容器中的所有CTextBox组件
                List<CTextBox> ctxts = GetCTextBoxes(this.panelBillPicture);
                foreach (DataRow dr in dt.Rows)//遍历所有行
                {
                    //根据编号获取CTextBox
                    CTextBox ctxtTemp = ctxts.Find(number => number.ControlId ==
       Convert.ToInt32(dr["ControlId"]));
                    ctxtTemp.Text = dr["ControlText"].ToString();//设置CTextBox的Text值
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
            }
        }

        private void FormBrowseBill_Load(object sender, EventArgs e)
        {
            formExpressBill = (FormExpressBill)this.Owner;//获取拥有当前窗体的窗体
            strBillTypeCode = formExpressBill.BillTypeCode;//获取单据种类代码
            strExpressBillCode = formExpressBill.ExpressBillCode;//获取单据号
            fDpiX = this.CreateGraphics().DpiX;//获取水平分辨率
            fDpiY = this.CreateGraphics().DpiY;//获取垂直分辨率
                                               //获取单据种类信息
            dtBillType = dataOper.GetDataTable("Select * From tb_BillType Where BillTypeCode = '" + strBillTypeCode + "'", "tb_BillType");
            InitTemplate(strBillTypeCode);//根据模板信息生成若干文本输入框
            if (this.Tag.ToString() == "Query")//若窗体处于查询操作状态
            {
                toolSave.Visible = false;//保存按钮不可见
                toolPrint.Visible = false;//打印按钮不可见
                this.Text = "查询条件输入";
            }
            else//若窗体处于打印操作状态
            {
                toolQuery.Visible = false;//查询按钮不可见
                InitText(strBillTypeCode, strExpressBillCode);//设置所有文本框的Text属性
                this.Text = "单据打印";
            }
        }
        private float MillimetersToPixel(float fValue, float fDPI)
        {
            return (fValue / 25.4f) * fDPI;//将毫米值转换为像素值
        }
        public void FormAutoResize(Size size)
        {
            //获取原始Size
            int intOldWidth = this.Width;
            int intOldHeight = this.Height;
            //设置新的Size
            this.Width = size.Width + 50;
            this.Height = size.Height + 70;
            //设置新的Location
            this.Location = new Point(this.Location.X - (this.Width - intOldWidth) / 2, this.Location.Y - (this.Height - intOldHeight) / 2);
        }

        public void DrawImage(Graphics g)
        {
            //引入图片
            Image img = cc.GetImageByBytes(dtBillType.Rows[0]["BillPicture"] as byte[]);
            Point point = new Point(0, 0); //左上角顶点
                                           //新的大小
            SizeF newSize = new SizeF(MillimetersToPixel(Convert.ToInt32(dtBillType.Rows[0]["BillWidth"]), fDpiX), MillimetersToPixel(Convert.ToInt32(dtBillType.Rows[0]["BillHeight"]), fDpiY));
            RectangleF NewRect = new RectangleF(point, newSize); //新的矩形
            SizeF oldSize = new SizeF(img.Width, img.Height); //原始图形的参数
            RectangleF OldRect = new RectangleF(point, oldSize); //原始图形的大小
            g.DrawImage(img, NewRect, OldRect, System.Drawing.GraphicsUnit.Pixel); //缩放图形处理
                                                                                   //若新图形的宽度或高度大于窗体的宽度或高度，窗体会自行调整
            if (newSize.Width > this.Width || newSize.Height > this.Height)
            {
                Size size = new Size(Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dtBillType.Rows[0]["BillWidth"]), fDpiX)), Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dtBillType.Rows[0]["BillHeight"]), fDpiY)));
                FormAutoResize(size);
            }
        }

        private void pbxBillPicture_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);//调用DrawImage方法重绘快递单
        }

        private void toolQuery_Click(object sender, EventArgs e)
        {
            string strSql = String.Empty;//声明表示SQL语句的字符串
                                         //创建SqlParameter对象，并赋值
            SqlParameter param = new SqlParameter("@BillTypeCode", SqlDbType.VarChar);
            param.Value = strBillTypeCode;//给参数对象Value的属性值
                                          //实例化List<SqlParameter>
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);//向参数列表中添加元素
                                  //把泛型中的元素复制到数组中
            SqlParameter[] inputParameters = parameters.ToArray();
            //获取符合该查询条件的单据记录
            DataTable dt = dataOper.GetDataTable("QueryExpressBill", inputParameters);
            List<CTextBox> ctxts = GetCTextBoxes(this.panelBillPicture);//获取窗体中的所有文本输入框
            foreach (CTextBox ctxtTemp in ctxts)//遍历所有的文本输入框
            {
                if (!(String.IsNullOrEmpty(ctxtTemp.Text.Trim())))//若当前文本框的Text属性不为空
                {
                    //首先求得该种快递单的单据号集合
                    if (String.IsNullOrEmpty(strSql))
                    {
                        //设置表示查询的SQL语句
                        strSql = "[" + ctxtTemp.ControlId.ToString() + "] like '%" + ctxtTemp.Text.Trim() + "%'";
                    }
                    else
                    {
                        strSql += " and [" + ctxtTemp.ControlId.ToString() + "] like '%" + ctxtTemp.Text.Trim() + "%'";
                    }
                }
            }
            dt.DefaultView.RowFilter = strSql;//设置过滤条件
                                              //设置DataGridView控件的数据源
            formExpressBill.dgvExpressBill.DataSource = dt.DefaultView;
            this.Close();//关闭当前窗体
        }

    }
}