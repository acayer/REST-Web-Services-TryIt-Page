using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;

namespace WebformTryIt
{
    public partial class _Default : Page
    {
        string hostURL = "http://localhost:57809";//http://webstrar16.fulton.asu.edu/page7
        //60815
        //57809
        //56071
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["myCookie"];
            if(cookie != null)
            {
                TextBox1.Text = cookie["input"];
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //cookie code
            HttpCookie cookie = new HttpCookie("myCookie");
            cookie["inputs"] = TextBox1.Text;
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);

            //invoke service
            string url = @hostURL + "/Service1.svc/filter/" + TextBox1.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                Label1.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                Label1.Text = "invalid input :(";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //get min temperature
            string url = @hostURL + "/Service1.svc/zipEMNT/" + TextBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                Label4.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                Label4.Text = "invalid input";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //get max temperature
            string url = @hostURL + "/Service1.svc/zipEMXT/" + TextBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                Label3.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                Label3.Text = "invalid input";
            }
        }

        //air quality
        protected void Button2_Click(object sender, EventArgs e)
        {
            string url = @hostURL + "/Service1.svc/zip/" + TextBox2.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                Label8.Text = TextBox2.Text + ":";
                Label2.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                Label8.Text = TextBox2.Text + ":";
                Label2.Text = "invalid input";
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //get precipitation
            string url = @hostURL + "/Service1.svc/zipEMXP/" + TextBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                Label6.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                Label6.Text = "invalid input";
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //get snowfall
            string url = @hostURL + "/Service1.svc/zipEMSN/" + TextBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                Label7.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                Label7.Text = "invalid input";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //get wind gust
            string url = @hostURL + "/Service1.svc/zipWSFG/" + TextBox3.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                Label5.Text = responsereader;
            }
            catch (WebException webExcp)
            {
                Label5.Text = "invalid input";
            }
        }
    }
}