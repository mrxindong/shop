using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BookShop.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currUser"] != null)
            {
                Label1.Text = "���," + ((Model.User)Session["currUser"]).Name;
            }
            else
            {
                Label1.Text = "��û�е�¼!";
            }
        }
    }
}