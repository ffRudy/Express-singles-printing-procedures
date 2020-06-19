using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express
{
    public partial class FormCreateOrder : Form
    {
        public FormCreateOrder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("顺丰速运");
            comboBox1.Items.Add("百世快递");
            comboBox1.Items.Add("中通快递");
            comboBox1.Items.Add("申通快递");
            comboBox1.Items.Add("圆通速递");
            comboBox1.Items.Add("韵达速递");
            comboBox1.Items.Add("邮政快递包裹");
            comboBox2.Items.Add("文件包裹（小件）");
            comboBox2.Items.Add("大件");
            comboBox2.Items.Add("特殊物品");
            comboBox2.Items.Add("国际物品");
            comboBox2.Items.Add("日用品");
            comboBox3.Items.Add("到付");
            comboBox3.Items.Add("支付宝");
            comboBox3.Items.Add("信用卡");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a;
                string b;
                a = textBox4.Text;
                b = textBox6.Text;
                double num1;
                double num2;
                num1 = Convert.ToInt32(a);
                num2 = Convert.ToInt32(b);
                if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("您有项目没有选择");
                    if (double.TryParse(a, out num1) && double.TryParse(b, out num2))
                    { }
                }
                else
                {
                    MessageBox.Show("预约成功");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入正确的电话号码");
            }
        }
    }
}

