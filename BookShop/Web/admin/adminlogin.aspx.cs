using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

namespace BookShop.Web.admin
{
    public partial class adminlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgb_Sure_Click(object sender, ImageClickEventArgs e)
        {
            UserManager userManager = new UserManager();
            if (!Page.IsValid)
                return;

            string adminUser = txtLoginId.Text.Trim();
            string adminPwd = txtLoginPwd.Text.Trim();
            Model.User loginUser;
            string msg;
            if (userManager.UserLogin(adminUser,Common.CommonCode.Md5Compte(adminPwd), out msg, out loginUser, true))
            {
                //说明登录成功,我要写Session
                Session["admin"] = loginUser;
                Response.Redirect("/showmsg.aspx?return=/admin/listallusers.aspx&msg=" + Server.UrlEncode("后台登录成功"));
                  
            }
            else
            {
                //说明登录失败
                Response.Redirect("/showmsg.aspx?return=/admin/adminlogin.aspx&msg=" + Server.UrlEncode(msg));

            }


        }

        protected void imgb_Cancel_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
