using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.UsControls
{
    public partial class UsUserState : System.Web.UI.UserControl
    {
        protected string toUrl;
        protected string showText;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbMsg.Visible= false;
            if (Common.CommonCode.CheckLogin())
            {
                lbMsg.Visible = true;
                lbMsg.Text = "你好," + ((Model.User)Session["currUser"]).Name;
                showText = "退出";
                toUrl = "/logout.aspx?return="+Request.Url.ToString();
    
         
            }
            else
            {
                //没有登录
                showText = "登录";
                toUrl = ResolveUrl("~/member/login.aspx");
         
            }
        }

        protected void lbtn_Click(object sender, EventArgs e)
        {
            //if (lbtn.Text == "退出")
            //{
            //    Response.Cookies["pwd"].Expires = DateTime.Now.AddYears(-1);
            //    Session.Abandon();
            //    Response.Redirect(Request.Url.ToString());

            //}
            //else
            //{
            //    Response.Redirect("/member/login.aspx?return="+Request.Url.ToString());
            //}
        }
    }
}