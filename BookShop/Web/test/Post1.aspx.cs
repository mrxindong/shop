using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.test
{
    public partial class Post1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["aaaa"] = "aaaa";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("post2.aspx?key=" + Server.UrlEncode("世界,你好!"));
        }
    }
}
