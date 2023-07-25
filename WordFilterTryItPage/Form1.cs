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
using System.Web;
using System.IO;

namespace WordFilterTryItPage
{
    public partial class Form1 : Form
    {
        string hostURL = "http://webstrar16.fulton.asu.edu/page7";

        public Form1()
        {
            InitializeComponent();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie cookie = FileWebRequest.Cookies["myCookie"];
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = @hostURL + "/Service1.svc/filter/" + textBox1.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                label10.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                label10.Text = "invalid input :(";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //label11 should be input zip code
            //label12 should be heuristic
            //get max temperature
            string url = @hostURL + "/Service1.svc/zip/" + textBox2.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                label11.Text = textBox1.Text + ":";
                label12.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                label11.Text = textBox2.Text + ":";
                label12.Text = "invalid input";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //get max temperature
            string url = @hostURL + "/Service1.svc/zipEMXT/" + textBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                label41.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                label41.Text = "invalid input";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //get min temperature
            string url = @hostURL + "/Service1.svc/zipEMNT/" + textBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                label39.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                label39.Text = "invalid input";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //get wind gust
            string url = @hostURL + "/Service1.svc/zipWSFG/" + textBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                label37.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                label37.Text = "invalid input";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //get precipitation
            string url = @hostURL + "/Service1.svc/zipEMXP/" + textBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                label35.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                label35.Text = "invalid input";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //get snowfall
            string url = @hostURL + "/Service1.svc/zipEMSN/" + textBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                label33.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                label33.Text = "invalid input";
            }
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }
    }
}
