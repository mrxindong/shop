using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session["currUser"] == null)
            {
                //说明没有登录
                //string url = string.Format("/ShowMsg.aspx?return={0}&msg={1}",
                //    Server.UrlEncode("/member/login.aspx?return=/default1.aspx"),
                //    Server.UrlEncode("请先登录,再访问此页面")
                //    );
                string url = "/member/login.aspx?return="+Request.Url.ToString();
                Response.Redirect(url);
            }


            if (Session["currUser"] != null)
            {
                Label1.Text = "你好," + ((Model.User)Session["currUser"]).Name;
            }
            else
            {
                Label1.Text = "你没有登录!";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Cookies["pwd"].Expires = DateTime.Now.AddYears(-10);
            Session.Abandon();
            Response.Redirect("/showmsg.aspx?return=/default.aspx&msg="+Server.UrlEncode("你已退出!"));



        }
    }
}
