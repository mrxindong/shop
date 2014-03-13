using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;



namespace BookShop.Web.member
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibtnReg_Click(object sender, ImageClickEventArgs e)
        {
            //1 判断Page.IsValid是否为true
            //2 验证码是否正确
            //3 直接调用业务逻辑层的添加方法就行了

            if (!Page.IsValid || !CheckVCode())
                return;

            
            UserManager userManager = new UserManager();

            Model.User addUser = new BookShop.Model.User();
            int id=0;
            string msg;
            addUser.LoginId = txtLoginId.Text.Trim();
            addUser.LoginPwd =Common.CommonCode.Md5Compte(txtPwd.Text.Trim());
            addUser.Mail = txtEmail.Text.Trim();
            addUser.Name = txtUserName.Text.Trim();
            addUser.Phone = txtMobile.Text.Trim();
            addUser.Address = txtAddress.Text.Trim();
            addUser.RoleInfo.RoleId = 1;
            addUser.UserState.Id = 1;
            if (userManager.Add(addUser, out id, out msg))
            {
                //添加成功!
                addUser=userManager.GetModel(id);
                Session["currUser"] = addUser;
                string url = "/ShowMsg.aspx?return=/default.aspx&msg=" + Server.UrlEncode("注册成功!") + "&title=" + Server.UrlEncode("点击跳转");

                Response.Redirect(url);                

            }
            else
            {
                 //添加失败
                Common.CommonCode.ShowMessage(Page, msg);
            }


    



        }

        /// <summary>
        /// 检测验证码是否正确,如果正确返回true,否则返回false
        /// </summary>
        /// <returns></returns>
        protected bool CheckVCode()
        {
            if (Session["vCode"] != null)
            {
                string vCode = Session["vCode"].ToString();
                string userCode = txtVCode.Text.Trim();
                //一般情况下,验证码不区分大小写
                if (vCode.Equals(userCode, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    Common.CommonCode.ShowMessage(Page, "验证码输入有误!");
                    //Page.ClientScript.RegisterStartupScript(this.GetType(),"a","alert('验证码输入有误!1');",true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "b", "alert('验证码输入有误!2');", true);
                    return false;
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "a", "alert('验证码超时,请点击刷新后重新提交!');", true);
                return false;
            }
        }
    }
}
