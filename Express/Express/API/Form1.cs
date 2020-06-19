using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Corder search = new Corder();
            string result = search.orderTracesSubByJson();
            JObject list = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            label8.Text = result;
        }
    }
}
