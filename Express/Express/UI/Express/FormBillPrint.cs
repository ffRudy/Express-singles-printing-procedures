using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Express.CusControl;
using Express.DAL;
using Express.Common;

namespace Express.UI.Express
{
    public partial class FormBillPrint : Form
    {
        public FormBillPrint()
        {
            InitializeComponent();
        }

        private CTextBox ctxt = null; //创建自定义组件对象
        private DataOperate dataOper = new DataOperate();//创建DataOperate类的对象，以便调用其中的方法
        private CommClass cc = new CommClass();//创建CommClass类的对象，以便调用其中的方法
        private DataTable dtBillType = null; //快递单信息的DataTable数据源
        private DataTable dtBillTemplate = null; //快递单模板的DataTable数据源
        CTextBox ctxtExpressBillCode = null;  //表示快递单号的CTextBox
        float fDpiX; //记录水平分辨率
        float fDpiY; //记录垂直分辨率

        public void BuildImageData(string strBillTypeCode)
        {
            dtBillType = dataOper.GetDataTable("Select * From tb_BillType Where BillTypeCode = '" + strBillTypeCode + "'", "tb_BillType");//获取快递单信息
            dtBillTemplate = dataOper.GetDataTable("Select * From tb_BillTemplate Where BillTypeCode= '" + strBillTypeCode + "'", "tb_BillTemplate");//获取快递单模板信息
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

        public void DisposeAllCTextBoxes(Control control)
        {
            Control.ControlCollection controls = control.Controls;//获取指定容器中的所有控件集合
            int intCount = controls.Count;//获取控件数量
            for (int i = 0; i < intCount; i++)//遍历所有控件
            {
                if (controls[i].GetType() == typeof(GroupBox))//如果类型是GroupBox
                {
                    this.DisposeAllCTextBoxes(controls[i]);//递归执行当前方法
                }
                if (controls[i].GetType() == typeof(SplitContainer))//如果类型是SplitContainer
                {
                    this.DisposeAllCTextBoxes(controls[i]);//递归执行当前方法
                }
                if (controls[i].GetType() == typeof(SplitterPanel))//如果类型是SplitterPanel
                {
                    this.DisposeAllCTextBoxes(controls[i]);//递归执行当前方法
                }
                if (controls[i].GetType() == typeof(CTextBox))//如果类型是CTextBox
                {
                    controls[i].Dispose();//释放资源
                    i -= 1;//循环变量减一
                    intCount -= 1;//将CTextBox组件数量减一
                }
            }
        }

        public void InitTemplate(DataTable dt)
        {
            List<CTextBox> ctxts = new List<CTextBox>();//创建CTextBox组件集合
            DisposeAllCTextBoxes(this);//移除当前窗体中的所有CTextBox
            foreach (DataRow dr in dt.Rows)//遍历数据源中的所有行
            {
                ctxt = new CTextBox();//实例化自定义控件对象
                ctxt.ContextMenuStrip = null;//设置快捷菜单为空
                ctxt.ControlId = Convert.ToInt32(dr["ControlId"]);//设置控件ID
                ctxt.IsFlag = dr["IsFlag"].ToString();//是否为对应控件
                                                      //设置控件位置
                ctxt.Location = new Point(Convert.ToInt32(dr["X"]), Convert.ToInt32(dr["Y"]));
                //设置控件大小
                ctxt.Size = new Size(Convert.ToInt32(dr["Width"]), Convert.ToInt32(dr["Height"]));
                ctxt.ControlName = dr["ControlName"].ToString();//设置控件默认名称
                ctxt.DefaultValue = dr["DefaultValue"].ToString();//设置控件默认值
                ctxt.Text = ctxt.DefaultValue;//设置快递单标题
                ctxt.TurnControlName = dr["TurnControlName"].ToString();//设置控件转换后的名称
                if (ctxt.IsFlag == "1")  //若是单据号码对应的控件
                {
                    ctxtExpressBillCode = ctxt;  //得到表示快递单号的CTextBox
                    ctxt.Font = new Font(new FontFamily("宋体"), 9, FontStyle.Bold);//设置控件的字体
                                                                                  //设置控件的最大长度
                    ctxt.MaxLength = Convert.ToInt32(dtBillType.Rows[0]["BillCodeLength"]);
                    //设置控件中的数据
                    ctxt.Text = cc.BuildCode("tb_BillText", "Where ControlId = '" + ctxt.ControlId + "'", "ExpressBillCode", "", ctxt.MaxLength);
                }
                //为控件添加KeyDown事件
                this.ctxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ctxt_KeyDown);
                //将控件添加到splitContainer1容器中
                this.splitContainer1.Panel1.Controls.Add(this.ctxt);
                ctxts.Add(ctxt);//将控件添加到集合中
            }
            //将图片添加到splitContainer1容器中
            this.splitContainer1.Panel1.Controls.Add(this.pbxBillPicture);
            //判断控件集合中的是否有可用控件
            if (ctxts.Where<CTextBox>(itm => itm.IsFlag == "1").Count<CTextBox>() == 0)
            {
                toolPrint.Enabled = false;//设置打印按钮不可用
                MessageBox.Show("当前模板未设置快递单号输入框，所以无法打印", "信息提示");
            }
            else
            {
                toolPrint.Enabled = true;//设置打印按钮可用
            }
        }

        private void ctxt_KeyDown(object sender, KeyEventArgs e)//CTextBox的KeyDown事件
        {
            if (e.KeyCode == Keys.Enter)//判断是否按下回车键
            {
                CTextBox ctxtTurnCtrl = null;//创建转换后的CTextBox对象
                CTextBox ctxtCurCtrl = null;//创建当前编辑的CTextBox对象
                                            //获取splitContainer1.Panel1中的所有CTextBox对象
                List<CTextBox> ctxts = GetCTextBoxes(this.splitContainer1.Panel1);
                foreach (CTextBox ctxt in ctxts)//遍历CTextBox集合
                {
                    if (ctxt.Focused)//如果CTextBox有鼠标焦点
                    {
                        ctxtCurCtrl = ctxt;//为当前编辑的CTextBox对象赋值
                        break;
                    }
                }
                //为确定的CTextBox对象赋值
                ctxtTurnCtrl = ctxts.Find(number => number.ControlName == ctxtCurCtrl.TurnControlName);
                if (ctxtTurnCtrl != null)//判断转换后确定的CTextBox对象是否为空
                {
                    ctxtTurnCtrl.Focus();//为其设置焦点
                }
            }
        }
        private float MillimetersToPixel(float fValue, float fDPI)
        {
            return (fValue / 25.4f) * fDPI;//将毫米值转换为像素值
        }

        private void FormBillPrint_Load(object sender, EventArgs e)
        {
            //获取系统的分辨率
            fDpiX = this.CreateGraphics().DpiX;//获取水平分辨率
            fDpiY = this.CreateGraphics().DpiY;//获取垂直分辨率
                                               //ListBox控件绑定数据源
            cc.ListBoxBindDataSource(lbxBillTypeCode, "BillTypeCode", "BillTypeName", "Select * From tb_BillType Where IsEnabled = '1'", "tb_BillType");
            if (lbxBillTypeCode.Items.Count > 0)//若存在快递单
            {
                BuildImageData(lbxBillTypeCode.SelectedValue.ToString());//获取单据信息和模板信息
                InitTemplate(dtBillTemplate);//生成文本输入框
            }
            else//若无快递单
            {
                toolPrint.Enabled = false;//禁用“打印”按钮
            }
        }

        private void pbxBillPicture_Paint(object sender, PaintEventArgs e)
        {
            if (lbxBillTypeCode.Items.Count > 0)//若存在快递单
            {
                //把二进制图像信息转换为Image图像
                Image img = cc.GetImageByBytes(dtBillType.Rows[0]["BillPicture"] as byte[]);
                //左上角顶点
                Point point = new Point(0, 0);
                //新图像的大小
                SizeF newSize = new
        SizeF(MillimetersToPixel(Convert.ToInt32(dtBillType.Rows[0]["BillWidth"]), fDpiX),
        MillimetersToPixel(Convert.ToInt32(dtBillType.Rows[0]["BillHeight"]), fDpiY));
                //新图像的区域
                RectangleF NewRect = new RectangleF(point, newSize);
                //原始图形的参数
                SizeF oldSize = new SizeF(img.Width, img.Height);
                //原始图形的大小
                RectangleF OldRect = new RectangleF(point, oldSize);
                //重新绘制原图像，从而达到图像缩放的效果
                e.Graphics.DrawImage(img, NewRect, OldRect, System.Drawing.GraphicsUnit.Pixel);
            }
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            string strSql = null;//声明表示SQL语句的字符串
            List<string> strSqls = new List<string>();//创建字符串列表
                                                      //实例化List<CTextBox>
            List<CTextBox> ctxts = GetCTextBoxes(this.splitContainer1.Panel1);
            foreach (CTextBox ctxt in ctxts)//循环所有的文本输入框
            {
                if (ctxt.IsFlag == "1")//若是单据号控件
                {
                    if (String.IsNullOrEmpty(ctxt.Text.Trim()))//若单据号为空
                    {
                        MessageBox.Show("单据号不许为空！", "软件提示");
                        ctxt.Focus();//单据号控件获得焦点
                        return;
                    }
                    else
                    {
                        if (ctxt.Text.Trim().Length != ctxt.MaxLength)//若单据号位数不正确
                        {
                            MessageBox.Show("单据号位数不正确！", "软件提示");
                            ctxt.Focus();
                            return;
                        }
                    }
                    //若数据库中已存在当前的单据号码
                    if (cc.IsExistExpressBillCode(ctxt.Text.Trim(), lbxBillTypeCode.SelectedValue.ToString()))
                    {
                        MessageBox.Show("该单据号已经存在！", "软件提示");
                        ctxt.Focus();
                        return;
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(ctxt.Text.Trim()))//若当前控件的Text属性值为空
                    {
                        if (MessageBox.Show(ctxt.ControlName + "为空，是否继续", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        {
                            ctxt.Focus();
                            return;
                        }
                    }
                }
                //表示插入新快递单的某项信息
                strSql = "INSERT INTO tb_BillText(BillTypeCode,ControlId,ExpressBillCode,ControlText)VALUES('" + lbxBillTypeCode.SelectedValue.ToString() + "', '" + ctxt.ControlId + "', '" + ctxtExpressBillCode.Text.Trim() + "','" + ctxt.Text.Trim() + "')";
                strSqls.Add(strSql);//向strSqls中添加SQL字符串
            }
            if (strSqls.Count > 0)
            {
                if (dataOper.ExecDataBySqls(strSqls))//若保存快递单数据成功
                {
                    //设置<打印文档>的边距
                    Margins margin = new Margins(0, 0, 0, 0);
                    pd.DefaultPageSettings.Margins = margin;
                    //设置<打印文档>的纸张大小
                    PaperSize pageSize = new PaperSize("快递单打印",
                        Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dtBillType.Rows[0]["BillWidth"]), fDpiX)),
        Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dtBillType.Rows[0]["BillHeight"]), fDpiY)));
                    pd.DefaultPageSettings.PaperSize = pageSize;//设置打印文档的纸张大小
                    printDialog1.Document = pd;//开始打印快递单
                    printDialog1.ShowDialog();//显示打印对话框，以便进行批量打印
                }
                else
                {
                    MessageBox.Show("保存失败，无法打印", "软件提示");
                    return;
                }
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;//获取绘制页的图像
            Font font = new Font("宋体", 12, GraphicsUnit.Pixel);//定义字体
            Brush brush = new SolidBrush(Color.Black);//定义黑色画刷
                                                      //获取文本输入框
            List<CTextBox> ctxts = GetCTextBoxes(this.splitContainer1.Panel1);
            foreach (CTextBox ctxt in ctxts)//遍历所有文本输入框
            {
                if (ctxt.IsFlag != "1")//若不是单据号文本框
                {
                    //在图像中绘制字符串
                    g.DrawString(ctxt.Text, font, brush, ctxt.Location.X, ctxt.Location.Y);
                }
            }
            foreach (CTextBox ctxt in ctxts)//遍历所有文本输入框
            {
                if (ctxt.IsFlag == "1")//若是单号文本输入框
                {
                    //自动生成新快递单号
                    ctxt.Text = cc.BuildCode("tb_BillText", "Where ControlId = '" + ctxt.ControlId + "'", "ExpressBillCode", "", ctxt.MaxLength);
                }
                else
                {
                    //判断当前控件的默认值属性是否为空！
                    if (String.IsNullOrEmpty(ctxt.DefaultValue))
                    {
                        ctxt.Text = "";//设Text属性为空字符
                    }
                    else//若当前文本输入框有默认值
                    {
                        ctxt.Text = ctxt.DefaultValue;//设Text属性为默认值
                    }
                }
            }
        }

    }
}