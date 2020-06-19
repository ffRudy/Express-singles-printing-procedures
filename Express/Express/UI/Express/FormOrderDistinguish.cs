using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Express.NewFolder1;
using Express.Properties;
using API.OrderDistinguish;

namespace Express
{
    public partial class FormOrderDistinguish : Form
    {
        public FormOrderDistinguish()
        {
            InitializeComponent();
        }

        private void btnDistinguish_Click(object sender, EventArgs e)
        {
            OrderDistinguish kd = new OrderDistinguish();
            RootObject root = JsonConvert.DeserializeObject<RootObject>
                (kd.orderTracesSubByJson(textBox1.Text));
            if (root.Shippers != null)
            {
                if (root.Shippers.Count > 0)
                {
                    this.txt_ShipperName.Text = root.Shippers[0].ShipperName;
                    this.txt_ShipperCode.Text = root.Shippers[0].ShipperCode;
                }
                this.txt_EBusinessID.Text = root.EBusinessID;

                this.pboxState.Image = Resources.Image2;
            }
            else
            {
                this.pboxState.Image = Resources.Image1;
                MessageBox.Show("不存在该订单");
            }
        }
    }
}