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
using API.TrackOrder;
using Express.UI.Express;

namespace Express.UI.New
{
    public partial class FormOrderSearch : Form
    {
        public FormOrderSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TrackOrder kd = new TrackOrder();    
            RootObject root = JsonConvert.DeserializeObject<RootObject>
                (kd.getOrderTracesByJson(cbox_ShipperCode.Text,txt_LogisticCode.Text));
            if (root.State == "0")
            {
                this.txt_State.Text = "暂无轨迹信息";
            }
            else if (root.State =="1")
            {
                this.txt_State.Text = "已揽收";
            }
            else if (root.State == "2")
            {
                this.txt_State.Text = "在途中";
            }
            else if (root.State == "3")
            {
                this.txt_State.Text = "签收";
            }
            else if (root.State == "4")
            {
                this.txt_State.Text = "问题件";
            }
            if (root.Traces != null)
            {               
                this.txt_AcceptTime.Text = root.Traces[0].AcceptTime;
                this.txt_AcceptStation.Text = root.Traces[0].AcceptStation;
                this.txt_EBusinessID.Text = root.EBusinessID;
            }
            else
            {
                MessageBox.Show("不存在该订单");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOrderDetail frm = new FormOrderDetail(txt_LogisticCode.Text);
            frm.Show();
        }
    }
}
