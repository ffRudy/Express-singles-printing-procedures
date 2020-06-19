using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Express.CusControl;
using Express.DAL;
using Express.Common;

namespace Express.UI.BaseSet
{
    public partial class FormSetTemplate : Form
    {
        public FormSetTemplate()
        {
            InitializeComponent();
        }
        private FormBillType formBillType = null;//创建FormBillType窗体对象
        private CTextBox ctxt = null;//创建自定义组件对象
        private DataGridViewRow dgvrBillType = null;//创建表格行对象
        private Point offset;//记录控件坐标
        private DataOperate dataOper = new DataOperate();//创建DataOperate类的对象，以便调用其中的方法
        private CommClass cc = new CommClass();//创建CommClass类的对象，以便调用其中的方法
        float fDpiX;//记录水平分辨率
        float fDpiY;//记录垂直分辨率

        public void InitTemplate(string strBillTypeCode)//动态创建文本输入框
        {
            //定义获取指定单据编号信息的SQL语句
            string strSql = "Select * From tb_BillTemplate Where BillTypeCode = '" + strBillTypeCode + "'";
            try
            {
                //将获取到的信息存储到DataTable中
                DataTable dt = dataOper.GetDataTable(strSql, "tb_BillTemplate");
                foreach (DataRow dr in dt.Rows)//遍历所有行
                {
                    ctxt = new CTextBox();//实例化自定义控件对象
                    ctxt.IsFlag = dr["IsFlag"].ToString();//是否为对应控件
                    ctxt.Text = dr["ControlName"].ToString();//设置控件名称
                    ctxt.ControlId = Convert.ToInt32(dr["ControlId"]);//设置控件ID
                    ctxt.FormParent = this;//设置控件所属窗体
                    ctxt.DefaultValue = dr["DefaultValue"].ToString();//设置控件默认值
                    ctxt.ControlName = dr["ControlName"].ToString();//设置控件默认名称
                    ctxt.TurnControlName = dr["TurnControlName"].ToString();//设置控件转换后的名称
                                                                            //设置控件位置
                    ctxt.Location = new Point(Convert.ToInt32(dr["X"]), Convert.ToInt32(dr["Y"]));
                    ctxt.Size = new Size(Convert.ToInt32(dr["Width"]),
        Convert.ToInt32(dr["Height"]));//设置控件大小
                    ctxt.ReadOnly = true;//设置控件只读
                    this.Controls.Add(ctxt);//将控件添加到当前窗体中
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
            }
        }

        /// <summary>
        /// 窗体自动调整大小并居中
        /// </summary>
        /// <param name="size">窗体新的size</param>
        public void FormAutoResize(Size size)
        {
            //获取窗体原始Size
            int intOldWidth = this.Width;
            int intOldHeight = this.Height;
            //设置窗体新的Size
            this.Width = size.Width + 50;
            this.Height = size.Height + 70;
            //设置新的位置(Location)居中
            this.Location = new Point(this.Location.X - (this.Width - intOldWidth) / 2, this.Location.Y - (this.Height - intOldHeight) / 2);
        }

        private float MillimetersToPixel(float fValue, float fDPI)
        {
            return (fValue / 25.4f) * fDPI;//将毫米值转换为像素值
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
            }
            return ctxts;//返回得到的CTextBox集合
        }

        public void DisposeAllCTextBoxes(Control ctrl)
        {
            Control.ControlCollection ctrls = ctrl.Controls;//获取指定容器中的所有控件集合
            int intCount = ctrls.Count;//获取控件数量
            for (int i = 0; i < intCount; i++)//遍历所有控件
            {
                if (ctrls[i].GetType() == typeof(CTextBox))//如果类型是CTextBox
                {
                    ctrls[i].Dispose();//释放资源
                    i -= 1;//循环变量减一
                    intCount -= 1;//将CTextBox组件数量减一
                }
                if (i >= 0)//如果遍历索引大于0
                {
                    if (ctrls[i].GetType() == typeof(GroupBox))//如果类型是GroupBox
                    {
                        this.DisposeAllCTextBoxes(ctrls[i]);//递归执行当前方法
                    }
                }
            }
        }

        private void FormSetTemplate_Load(object sender, EventArgs e)
        {
            //获取分辨率
            fDpiX = this.CreateGraphics().DpiX;//获取水平分辨率
            fDpiY = this.CreateGraphics().DpiY;//获取垂直分辨率
            formBillType = (FormBillType)this.Owner;//获取拥有当前窗体的窗体
            dgvrBillType = formBillType.dgvBillType.CurrentRow;//获取当前的快递单记录行
            InitTemplate(dgvrBillType.Cells["BillTypeCode"].Value.ToString());//动态创建文本输入框
        }

        private void FormSetTemplate_Paint(object sender, PaintEventArgs e)
        {
            //光标相对的原点是屏幕的左上角顶点；而控件相对的原点是所在窗体的左上角顶点
            offset = new Point(this.Location.X, this.Location.Y);
            //引入图片
            Image img = cc.GetImageByBytes(dgvrBillType.Cells["BillPicture"].Value as byte[]);
            //左上角顶点
            Point point = new Point(0, 0);
            //新的大小
            SizeF newSize = new
        SizeF(MillimetersToPixel(Convert.ToInt32(dgvrBillType.Cells["BillWidth"].Value), fDpiX),
        MillimetersToPixel(Convert.ToInt32(dgvrBillType.Cells["BillHeight"].Value), fDpiY));
            //新的矩形
            RectangleF NewRect = new RectangleF(point, newSize);
            //原始图形的参数
            SizeF oldSize = new SizeF(img.Width, img.Height);
            //原始图形的大小
            RectangleF OldRect = new RectangleF(point, oldSize);
            //缩放图形处理
            e.Graphics.DrawImage(img, NewRect, OldRect, System.Drawing.GraphicsUnit.Pixel);
            //若新图形的宽度或高度大于窗体的宽度或高度，窗体会自行调整
            if (newSize.Width > this.Width || newSize.Height > this.Height)
            {
                Size size = new
        Size(Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dgvrBillType.Cells["BillWidth"].Value), fDpiX)),
        Convert.ToInt32(MillimetersToPixel(Convert.ToInt32(dgvrBillType.Cells["BillHeight"].Value)
        , fDpiY)));
                FormAutoResize(size);//根据新图形的大小自动调整窗体大小
            }
        }

        private void toolAddCTextBox_Click(object sender, EventArgs e)
        {
            ctxt = new CTextBox();//实例化CTextBox对象
            ctxt.IsFlag = "0";  //系统默认不为单据编号对应的输入框
            ctxt.ControlId = 0; //系统默认的控件编号为零
            ctxt.FormParent = this;//设置父窗体
                                   //设置文本输入框的位置
            ctxt.Location = new Point(MousePosition.X - offset.X, MousePosition.Y - offset.Y);
            ctxt.ReadOnly = true;//设置文本输入框为只读
            ctxt.BackColor = Color.Red;//设置文本输入框的背景颜色为红色
            this.Controls.Add(ctxt);//向窗体中添加新的文本输入框
            ctxt.Focus();//设置新的文本输入框获取光标
            ctxt.SelectAll();//设置新的文本输入框选择全部文本
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            //判断是否设置快递单号输入框的逻辑标记
            bool boolIsFlag = false;
            string strSql = null;
            //表示单据类型代码的字符串
            string strBillTypeCode = dgvrBillType.Cells["BillTypeCode"].Value.ToString();
            //List<T>泛型
            List<string> strSqls = new List<string>();
            List<CTextBox> ctxts = this.GetCTextBoxes(this);
            foreach (CTextBox ctxt in ctxts)
            {
                //查找被设置为快递单号的控件
                if (ctxt.IsFlag == "1")
                {
                    boolIsFlag = true;
                }
                //判断控件的新旧
                if (ctxt.ControlId == 0)  //若该控件为新添加的
                {
                    strSql = "INSERT INTO tb_BillTemplate(BillTypeCode, X, Y, Width, Height, IsFlag, ControlName, DefaultValue, TurnControlName) VALUES('" + strBillTypeCode + "', '" + ctxt.Location.X + "', '" + ctxt.Location.Y + "', '" + ctxt.Width + "','" + ctxt.Height + "','" + ctxt.IsFlag + "','" + ctxt.ControlName + "','" + ctxt.DefaultValue + "','" + ctxt.TurnControlName + "')";
                }
                else  //若该控件为旧的控件
                {
                    strSql = "Update tb_BillTemplate Set BillTypeCode = '" + strBillTypeCode + "',X = '" + ctxt.Location.X + "',Y = '" + ctxt.Location.Y + "',Width = '" + ctxt.Width + "',Height ='" + ctxt.Height + "',IsFlag = '" + ctxt.IsFlag + "',ControlName = '" + ctxt.ControlName + "',DefaultValue = '" + ctxt.DefaultValue + "',TurnControlName = '" + ctxt.TurnControlName + "' Where ControlId = '" + ctxt.ControlId + "'";
                }
                strSqls.Add(strSql);
            }
            //判断快递单号输入框
            if (!boolIsFlag)
            {
                if (e.GetType() == typeof(FormClosingEventArgs))//若是关闭操作调用的保存处理
                {
                    ((FormClosingEventArgs)e).Cancel = true;//禁止关闭
                }
                MessageBox.Show("请设置快递单号输入框，否则程序无法保存！", "软件提示");
                return;
            }
            //判断快递单号输入框
            if (strSqls.Count > 0)
            {
                if (MessageBox.Show("确定要保存吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (dataOper.ExecDataBySqls(strSqls))
                    {
                        DisposeAllCTextBoxes(this);  //清除现有的控件布局
                        InitTemplate(strBillTypeCode);  //重新加载窗体上面的控件布局
                        MessageBox.Show("保存模板成功！", "软件提示");
                    }
                    else
                    {
                        MessageBox.Show("保存模板失败！", "软件提示");
                    }
                }
            }
            else
            {
                MessageBox.Show("未添加输入框，无需保存！", "软件提示");
            }
        }

    }
}