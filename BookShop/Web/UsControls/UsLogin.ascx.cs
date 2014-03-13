using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Web.Common;

namespace BookShop.Web.UsControls
{
    public partial class UsLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //检测用户Cookie是否存在.即用户是否选中了自动登录
            if (Request.Cookies["loginId"] != null &&
                Request.Cookies["pwd"] != null)
            {
                UserManager userManager = new UserManager();
                //cookie存在,说明用户选中了记住我
                string cLoginId = Request.Cookies["loginId"].Value;
                string cPwd = Request.Cookies["pwd"].Value;
                Model.User loginUser = userManager.GetModel(cLoginId);
                if (loginUser != null)
                {
                    
                    //用户可能为空:当用户登录成功并选中记住我后,管理员删除该用户就会造成有cookie但数据库中没该用户
                    string sysPwd = Encrypt(loginUser.LoginPwd, cPwd.Substring(0, 2));
                    if (sysPwd == cPwd &&
                        loginUser.UserState.Name == "正常")
                    {
                        //该用户可以进行自动登录 
                        Session["currUser"] = loginUser;
                    //    CommonCode.ShowMessage(Page, "登录成功!");
                        GoPage();
                        
                            
                        return;
                    }
          


                }

               // Response.Cookies["loginId"].Expires = DateTime.Now.AddYears(-1);
                Response.Cookies["pwd"].Expires = DateTime.Now.AddYears(-1);  //也没有删掉,只不过下次请求时,浏览器发现他过期了,不再给我们发送了而已.
                

            }
            else
            {
            }

            if (!Page.IsPostBack)
            {
                //检测要不要显示用户名
                if (Request.Cookies["loginId"] != null)
                {
                    txtLoginId.Text = Request.Cookies["loginId"].Value;
                }
            }
        }
        
        protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            UserManager userManager = new UserManager();
            string loginId = txtLoginId.Text.Trim();
            string pwd = Common.CommonCode.Md5Compte(txtLoginPwd.Text.Trim());
            string msg;
            Model.User loginuser;
            if (userManager.UserLogin(loginId, pwd, out  msg, out  loginuser))
            {
                //实现登录时,能够保留上一次用户成功的用户名
                HttpCookie cLoginId = new HttpCookie("loginId", loginuser.LoginId);
                cLoginId.Expires = DateTime.Now.AddYears(10);
                Response.Cookies.Add(cLoginId);
                
                
                //返回true表示登录成功!
                Session["currUser"] = loginuser;//登录成功 ,赋Session,所谓Session验证,就是看这个Session是否存在,存在则证明登录,否则则证明没有登录或超时
                if (cbAutoLogin.Checked)
                {
                    //用户选中了自动登录
                    //我把要把用户信息写入用户磁盘(即写持久cookie)
                    string encrypt = this.Encrypt(loginuser.LoginPwd);
                  //  HttpCookie cLoginId = new HttpCookie("loginId",loginuser.LoginId);
                    HttpCookie cPwd = new HttpCookie("pwd", encrypt);
                    //设置过期时间
                   // cLoginId.Expires = DateTime.Now.AddYears(10);
                    cPwd.Expires = DateTime.Now.AddYears(10);
                    //写入Cookie
                    //Response.Cookies.Add(cLoginId);
                    Response.Cookies.Add(cPwd);



                }
                GoPage();
 
            }
            else
            {
                //表示登录失败!
                Response.Redirect("~/ShowMsg.aspx?return=/member/login.aspx&msg="+
                    Server.UrlEncode("用户名或密码错误")+"&title="+Server.UrlEncode("继续登录"));
                
            }
        }

        protected void GoPage()
        {
            if (Request.QueryString["return"] != null)
            {
                //从另一个页面导过来的,登录成功后,再把用户导回去
                Response.Redirect(Request.QueryString["return"]);

            }
            else
            {
                //用户直接点登录链接过来的,登录成功后,把用户导到主页就可以了.
                Response.Redirect("/default.aspx");
            }
        }

        protected void btnRegister_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/member/register.aspx");
            

        }

        /// <summary>
        /// 对将要写入Cookie的密码进行加密处理
        /// </summary>
        /// <param name="txt"></param>
        protected string Encrypt(string txt,string key)
        {
            Random r = new Random();
            //A:65    Z:90
            string salt;
            if (key == null || key == "")
            {
                salt = ((char)r.Next(65, 91)).ToString() + ((char)r.Next(65, 91)).ToString();
            }
            else
            {
                salt = key;
            }
            string result = salt + CommonCode.Md5Compte(salt + CommonCode.Md5Compte(txt));
            return result;
        }

        protected string Encrypt(string txt)
        {
            return Encrypt(txt, null);
        }
    }
}