using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Express
{
    public partial class FormOrderDetail : Form
    {
        public FormOrderDetail(string a)
        {
            InitializeComponent();
            this.webBrowser1.Navigate("C:\\Users\\Rudy\\Desktop\\1.html");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
