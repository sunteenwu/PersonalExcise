using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunteenSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            Response.Write("Request of client");
            System.IO.Stream inputstream = Request.InputStream;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(Request.InputStream))
            {
                string body = reader.ReadToEnd();
                Response.Write(body);
            }
            if (Request.QueryString["cacheable"] != null)
            {
                Response.Write("get request,the server time now is:");
                Response.Write(DateTime.Now);
                Response.Write("request cache" + Response.Expires + "minites");
            }
            if (Request.Cookies.Count > 0)
            {
                Response.Write("Cookies:");
                foreach (var cookie in Request.Cookies.AllKeys)
                {
                    Response.Write(cookie + ":" + Request.Cookies[cookie].Value);
                }
            }
            if (Request.QueryString["setCookies"] != null)
            {
                HttpCookie myCookie1 = new HttpCookie("LastVisit");
                DateTime now = DateTime.Now;
                myCookie1.Value = now.ToString();
                myCookie1.Expires = now.AddMinutes(3);
                Response.Cookies.Add(myCookie1);
                HttpCookie myCookie2 = new HttpCookie("SID");
                myCookie2.Value = "21d4d96e407aad42";
                myCookie2.HttpOnly = true;
                Response.Cookies.Add(myCookie2);
            }
            if (Request.QueryString["extraData"] != null)
            {
                int streamLength = Int32.Parse(Request.QueryString["extraData"]);
                for (int i = 0; i < streamLength; i++)
                {
                    Response.Write("@");
                }
            }

        }
    }
}