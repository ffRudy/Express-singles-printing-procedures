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
using Express.UI.BaseSet;
using Express.UI.Express;
using API.Corder;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using IflySdk;
using IflySdk.Model.Common;
using IflySdk.Enum;
using System.Diagnostics;
using Baidu.Aip.Speech;

namespace Express.UI.Express
{
    public partial class FormExpressOrder : Form
    {
        public FormExpressOrder()
        {
            InitializeComponent();
        }
        /*static async void ASRAudio()
        {
            string path = "C:\\Users\\Rudy\\Desktop\\2.pcm";  //测试文件路径,自己修改
            byte[] data = File.ReadAllBytes(path);
            try
            {
                ASRApi iat = new ApiBuilder()
                    .WithAppSettings(new AppSettings()
                    {
                        ApiKey = "c22c66acb313bc224d4797bf6a33c38c",
                        ApiSecret = "b0b8bc2094055fbc160eb0bb79cd22ce",
                        AppID = "5eeb6389"
                    })
                    .UseError((sender, e) =>
                    {
                        Console.WriteLine("错误：" + e.Message);
                    })
                    .UseMessage((sender, e) =>
                    {
                        Console.WriteLine("实时结果：" + e);
                    })
                    .BuildASR();

                //计算识别时间
                Stopwatch sw = new Stopwatch();
                sw.Start();

                ResultModel<string> result = await iat.ConvertAudio(data);
                if (result.Code == ResultCode.Success)
                {
                    Forma = result.Data;
                    Console.WriteLine("\n识别结果：" + result.Data);
                }
                else
                {
                    Console.WriteLine("\n识别错误：" + result.Message);
                }

                sw.Stop();
                Console.WriteLine($"总共花费{Math.Round(sw.Elapsed.TotalSeconds, 2)}秒。");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/
        CommClass cc = new CommClass();

        public static string Forma { get; set; }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormExpressOrder_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Corder search = new Corder();
            search.setSender(textBox11.Text, textBox12.Text, textBox13.Text, textBox14.Text, textBox15.Text, textBox16.Text);
            search.setReceiver(textBox21.Text, textBox22.Text, textBox23.Text, textBox24.Text, textBox25.Text, textBox26.Text);
            search.setShipper(listBox1.Text);
            string str = search.orderTracesSubByJson();
            JObject result = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(str);
            var tam = result["PrintTemplate"];
            FormOrderDisplay frm = new FormOrderDisplay(tam.ToString());
            this.Close();
            frm.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string value = "pcm";
            String filePath = "C:\\Users\\Rudy\\Desktop\\new3.pcm";
            // 设置APPID/AK/SK
            String APP_ID = "20458531";
            String API_KEY = "LikGTcl4Edo6H1H9hBunZ0ti";
            String SECRET_KEY = "tx6EOF8pDdPxCeT1HERBmqxim38TjVgE";
            var client = new Asr(APP_ID, API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            client.Timeout = 200000; // 若语音较长，建议设置更大的超时时间. ms
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] buffur = new byte[fs.Length];
            try
            {
                fs.Read(buffur, 0, (int)fs.Length);

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            finally
            {
                if (fs != null)
                {
                    //关闭资源  
                    fs.Close();
                }
            }
            var result = client.Recognize(buffur, value, 16000);
            Convert.ToString(result);
            JToken resultStr = null;
            result.TryGetValue("result", out resultStr);
            Console.WriteLine("aToken===>" + resultStr);
            string s= Convert.ToString(resultStr);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '[':
                        break;
                    case ']':
                       break;
                    case ' ':
                        break;
                    case '，':
                        break;
                    case '。':
                        break;
                    case ',':
                        break;
                    case '“':
                        break;
                    case '”':
                        break;
                    case '"':
                        break;
                    default:
                        sb.Append(c); break;
                }
            }
            s = sb.ToString();
            voiceResult.Text = s;
            //返回姓名
            int IndexofA1 = s.IndexOf('名');
            int IndexofA2 = s.IndexOf('电');
            textBox11.Text = s.Substring(IndexofA1 + 1, IndexofA2 - IndexofA1 - 1);
            //返回电话
            int IndexofB = s.IndexOf('话');
            int IndexofC = s.IndexOf('地');
            textBox12.Text= s.Substring(IndexofB + 1, IndexofC - IndexofB - 1);
            //返回省
            int IndexofD = s.IndexOf('址');
            int IndexofE = s.IndexOf('省');
            textBox13.Text = s.Substring(IndexofD + 1, IndexofE - IndexofD);
            //返回市
            int IndexofF = s.IndexOf('省');
            int IndexofG = s.IndexOf('市');
            textBox14.Text = s.Substring(IndexofF + 1, IndexofG - IndexofF);
            //返回区
            int IndexofH = s.IndexOf('市');
            int IndexofI = s.IndexOf('区');
            textBox15.Text = s.Substring(IndexofH + 1, IndexofI - IndexofH);
            //返回详细地址
            int IndexofJ = s.IndexOf('区');
            textBox16.Text =s.Substring(IndexofJ+1);

        }

        private void voiceResult1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = "pcm";
            String filePath = "C:\\Users\\Rudy\\Desktop\\new4.pcm";
            // 设置APPID/AK/SK
            String APP_ID = "20458531";
            String API_KEY = "LikGTcl4Edo6H1H9hBunZ0ti";
            String SECRET_KEY = "tx6EOF8pDdPxCeT1HERBmqxim38TjVgE";
            var client = new Asr(APP_ID, API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            client.Timeout = 200000; // 若语音较长，建议设置更大的超时时间. ms
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] buffur = new byte[fs.Length];
            try
            {
                fs.Read(buffur, 0, (int)fs.Length);

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            finally
            {
                if (fs != null)
                {
                    //关闭资源  
                    fs.Close();
                }
            }
            var result = client.Recognize(buffur, value, 16000);
            Convert.ToString(result);
            JToken resultStr = null;
            result.TryGetValue("result", out resultStr);
            Console.WriteLine("aToken===>" + resultStr);
            string s = Convert.ToString(resultStr);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '[':
                        break;
                    case ']':
                        break;
                    case ' ':
                        break;
                    case '，':
                        break;
                    case '。':
                        break;
                    case ',':
                        break;
                    case '“':
                        break;
                    case '”':
                        break;
                    case '"':
                        break;
                    default:
                        sb.Append(c); break;
                }
            }
            s = sb.ToString();
            voiceResult1.Text = s;
            //返回姓名
            int IndexofA1 = s.IndexOf('名');
            int IndexofA2 = s.IndexOf('电');
            textBox21.Text = s.Substring(IndexofA1 + 1, IndexofA2 - IndexofA1-1);
            //返回电话
            int IndexofB = s.IndexOf('话');
            int IndexofC = s.IndexOf('地');
            textBox22.Text = s.Substring(IndexofB + 1, IndexofC - IndexofB - 1);
            //返回省
            int IndexofD = s.IndexOf('址');
            int IndexofE = s.IndexOf('省');
            textBox23.Text = s.Substring(IndexofD + 1, IndexofE - IndexofD);
            //返回市
            int IndexofF = s.IndexOf('省');
            int IndexofG = s.IndexOf('市');
            textBox24.Text = s.Substring(IndexofF + 1, IndexofG - IndexofF);
            //返回区
            int IndexofH = s.IndexOf('市');
            int IndexofI = s.IndexOf('区');
            textBox25.Text = s.Substring(IndexofH + 1, IndexofI - IndexofH);
            //返回详细地址
            int IndexofJ = s.IndexOf('区');
            textBox26.Text = s.Substring(IndexofJ + 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string value = "pcm";
            String filePath = "C:\\Users\\Rudy\\Desktop\\new5.pcm";
            // 设置APPID/AK/SK
            String APP_ID = "20458531";
            String API_KEY = "LikGTcl4Edo6H1H9hBunZ0ti";
            String SECRET_KEY = "tx6EOF8pDdPxCeT1HERBmqxim38TjVgE";
            var client = new Asr(APP_ID, API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            client.Timeout = 200000; // 若语音较长，建议设置更大的超时时间. ms
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] buffur = new byte[fs.Length];
            try
            {
                fs.Read(buffur, 0, (int)fs.Length);

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            finally
            {
                if (fs != null)
                {
                    //关闭资源  
                    fs.Close();
                }
            }
            var result = client.Recognize(buffur, value, 16000);
            Convert.ToString(result);
            JToken resultStr = null;
            result.TryGetValue("result", out resultStr);
            Console.WriteLine("aToken===>" + resultStr);
            string s = Convert.ToString(resultStr);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '[':
                        break;
                    case ']':
                        break;
                    case ' ':
                        break;
                    case '，':
                        break;
                    case '。':
                        break;
                    case ',':
                        break;
                    case '“':
                        break;
                    case '”':
                        break;
                    case '"':
                        break;
                    default:
                        sb.Append(c); break;
                }
            }
            s = sb.ToString();
            voiceResult2.Text = s;
            //返回物流公司
            int IndexofA1 = s.IndexOf('名');
            int IndexofA2 = s.IndexOf('电');
            //返回物品信息
            int IndexofB = s.IndexOf('息');
            int IndexofC = s.IndexOf('数');
            textBox31.Text = s.Substring(IndexofB + 1, IndexofC - IndexofB - 1);
            //返回数量
            int IndexofD = s.IndexOf('量');
            int IndexofE = s.IndexOf('体');
            textBox32.Text = s.Substring(IndexofD + 1, IndexofE - IndexofD-1);
            //返回体积
            int IndexofF = s.IndexOf('积');
            int IndexofG = s.IndexOf('重');
            textBox33.Text = s.Substring(IndexofF + 1, IndexofG - IndexofF-1);
            //返回重量
            int IndexofH = s.IndexOf('重');
            textBox34.Text = s.Substring(IndexofH+2);
        }
    }
    /* string s = voiceResult.Text;
string ss;
int IndexofA = s.IndexOf('美'); //字符串的话总以第一位为指定位置
int IndexofB = s.IndexOf('夏');
ss = s.Substring(IndexofA + 1, IndexofB - IndexofA - 1);
textBox11.Text = ss;
}
/* var client = new Baidu.Aip.Speech.Asr("20458531", "LikGTcl4Edo6H1H9hBunZ0ti", "tx6EOF8pDdPxCeT1HERBmqxim38TjVgE");
client.Timeout = 60000;  // 修改超时时间
var data = File.ReadAllBytes("C:\\Users\\Rudy\\Desktop\\2.pcm"); 
// 可选参数
var options = new Dictionary<string, object>
{
 {"dev_pid", 1536}  //语音模型1536代表普通话，其他请查看官方文档
};
client.Timeout = 1200000; // 若语音较长，建议设置更大的超时时间. ms
//string result = client.Recognize(data, "wav", 16000, options);
string result = client.Recognize(data, "pcm", 160000, options).ToString();
label10.Text=result;*/
}
