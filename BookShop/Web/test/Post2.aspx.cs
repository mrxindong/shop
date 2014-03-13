using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.test
{
    public partial class Post2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            //  Label1.Text = Request.Form["TextBox1"];

            //有上一个页面
            //if (Page.PreviousPage != null)
            //{  
            //     //是不是由上一个页面跨页面提交过来的.
            //    if (Page.PreviousPage.IsCrossPagePostBack)
            //    {
            //        Label1.Text= ((TextBox)Page.PreviousPage.FindControl("TextBox1")).Text;
            //    }
            //}

            Label1.Text = Request.QueryString["key"];
        }
    }
}
