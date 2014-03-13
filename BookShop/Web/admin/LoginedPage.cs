using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.admin
{
    public class LoginedPage :System.Web.UI.Page
    {

        public LoginedPage()
        {
            this.Load += CheckLogin;
        }

        public void CheckLogin(object sender,EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("/showmsg.aspx?return=/admin/adminlogin.aspx&msg=" + Server.UrlEncode("请先登录,再访问该页面!"));

            }
        }
    }
}
