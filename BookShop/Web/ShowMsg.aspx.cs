using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class ShowMsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //调用这个页面时传两个参数
            //msg=就是给用户展示的信息
            //return=当用户点返时跳转到的页面
            //title=用户点击的字

            if (Request.QueryString["msg"] != null)
            {
                lbmsg.Text = Request.QueryString["msg"];
            }

            if (Request.QueryString["return"] != null)
            {
                hpLink.NavigateUrl = Request.QueryString["return"];
            }
            else
            {
                hpLink.NavigateUrl = "/default.aspx";
            }

            if (Request.QueryString["title"] != null)
            {
                hpLink.Text = Request.QueryString["title"];
            }

        }
    }
}
