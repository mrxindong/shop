using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["pwd"].Expires = DateTime.Now.AddYears(-1);
            Response.Redirect("showmsg.aspx?return=" + Request.QueryString["return"] + "&msg=" + Server.UrlEncode("退出成功!"));
        }
    }
}
