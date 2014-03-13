using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.test
{
    public partial class aaaa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Common.CommonCode.ShowMessage(Page, "Hello,World!");
            Common.CommonCode.WriteScript(Page, "window.location='/default.aspx'");
           // Response.Redirect("/default.aspx");
        }
    }
}
