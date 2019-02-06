using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private HttpWebRequest request;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Loaddata(Properties.Resources.data);
            Loaddata(Properties.Resources.data1);
        }

        private void Loaddata(byte[] data)
        {
            request = WebRequest.CreateHttp("https://wintermute-151001.appspot.com/game/run_action");
            request.Method = "POST";
            request.Accept = "application/json, text/plain,";
            request.ContentType = "application / json; charset = UTF - 8";
            //request.Headers.Add("Origin", "https://apps-141184676316522.apps.fbsbx.com");
            //request.Referer = "https://apps-141184676316522.apps.fbsbx.com/instant-bundle/1174389249249108/1978159075594772/index.html?psev=1&gcgs=1&source=fbinstant-141184676316522&IsMobileWeb=0";
            //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";
            request.Headers.Add("x-wintermute-session", "djE6YWhOemZuZHBiblJsY20xMWRHVXRNVFV4TURBeGNsRUxFZ1pRYkdGNVpYSWlHV1YyWlhKM2FXNW5MekUwTVRNME1EUXhORGczTWpRMk1ETU1DeElOVUd4aGVXVnlVMlZ6YzJsdmJpSVpaWFpsY25kcGJtY3ZNVFF4TXpRd05ERTBPRGN5TkRZd013dy9iZDFmZDcyZS1iMWNkLTRjYjYtOGVkNi0wYWNhNWIxZTUzMjE=");
            //request.Headers.Add(HttpRequestHeader.Accept, "application/json, text/plain, */*");
            //Text = request.Headers.AllKeys[0];
            //request.Headers.Add("x-wintermute-session", "djE6YWhOemZuZHBiblJsY20xMWRHVXRNVFV4TURBeGNsRUxFZ1pRYkdGNVpYSWlHV1YyWlhKM2FXNW5MekUwTVRNME1EUXhORGczTWpRMk1ETU1DeElOVUd4aGVXVnlVMlZ6YzJsdmJpSVpaWFpsY25kcGJtY3ZNVFF4TXpRd05ERTBPRGN5TkRZd013dy8zNTQ0NDkxNy0zMmQ0LTQ4OTctYWZmNC03MmRiMTY3YmYzN2I=");
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    richTextBox1.Text = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
