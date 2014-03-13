using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CheckUser : IHttpHandler
    {

        /// <summary>
        /// 通过post方式传一个loginid过来.  如果用户存在,则返回no  如果不存在则返回yes
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
           // System.Threading.Thread.Sleep(5000);
            context.Response.ContentType = "text/plain";
            if (context.Request.Form["loginid"] != null)
            {
                string loginid = context.Request.Form["loginid"];
                if (new BLL.UserManager().CheckExistByLoginid(loginid))
                {
                    //存在
                    context.Response.Write("no");
                }
                else
                {
                    //不存在
                    context.Response.Write("yes");
                }
            }
            else
            {
                context.Response.Write("no");
            }

            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
