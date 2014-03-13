using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using BookShop.BLL;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CartProcess : IHttpHandler, IRequiresSessionState
    {

        /// <summary>
        /// 失败就返回no+错误原因
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {

            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            HttpSessionState Session = context.Session;
            context.Response.ContentType = "text/plain";
            //调用本一般处理程序时,必须传一个action参数
            //action=change 表示要改变购物车中书的数量
            //action=delete 表示要删除购物车中的书
            if (Request.Form["action"] == null)
            {
                Response.Write("no没有action参数");
                return;

            }
            string action = Request.Form["action"];
            CartManager cartManager = new CartManager();


            //表示更改购物车中书的数量
            //必须两个参数过来
            //第一个:   id  购物车表的主键
            //第二个:  count 要更新的数量
            if (action == "change")
            {
         
                int cartId, count;
                //检测是否登录
                if (!Common.CommonCode.CheckLogin())
                {
                    Response.Write("no你没有登录,请选登录再修改");
                    return;
                }

                if (Request.Form["id"] == null)
                {
                    //没有传过来cartid
                    Response.Write("no-cartId参数丢失.");
                    return;

                }
                if (!int.TryParse(Request.Form["id"], out cartId))
                {
                    //id不能转换成数字
                    Response.Write("no cartid有误!");
                    return;
                }
                //检测当前用户要修改的这本书是不是属于该用户
                Model.Cart updateCart = cartManager.GetModel(cartId);
                if (updateCart == null)
                {
                    Response.Write("no更新出错,错误代码:873");
                    return;
                }

                if (updateCart.User.Id != ((Model.User)Session["currUser"]).Id)
                {
                    //说明该用户修改的图书不是自己购物车的,一般情况下不会出现这种情况
                    //用户有可能在攻击网站,写log请录相关信息
                    Response.Write("no伪造数据,你的信息已被记录:873");
                    return;
                }
                if (Request.Form["count"] == null)
                {
                    Response.Write("no-count参数丢失.");
                    return;
                }
                if (!int.TryParse(Request.Form["count"], out count))
                {
                    Response.Write("no-count参数有误.");
                    return;
                }
                if (count<1 || count>999)
                {
                    Response.Write("no购买数量超出范围!.");
                    return;

                }
                //开始更新数量
                cartManager.Update(cartId, count);
                Response.Write(count.ToString());

                    



            }
                //表示要删除数据
                //需要参数:  bookid
            else if (action == "delete")
            {
                int userId, bookId;

                //检测是否登录
                if (!Common.CommonCode.CheckLogin())
                {
                    Response.Write("no你没有登录,请选登录再修改");
                    return;
                }

                if (Request.Form["bookid"] == null)
                {
                    //没有传过来bookId
                    Response.Write("no-bookId参数丢失.");
                    return;

                }
                if (!int.TryParse(Request.Form["bookid"], out bookId))
                {
                    //id不能转换成数字
                    Response.Write("no bookId有误!");
                    return;
                }
                userId = ((Model.User)Session["currUser"]).Id;
                try
                {
                    cartManager.Delete(userId, bookId);
                    Response.Write("删除成功");
                    return;
                }
                catch(Exception ex)
                {
                    Response.Write("no删除失败!"+ex.Message);
                    return;
                }
                



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
