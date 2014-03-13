using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

namespace BookShop.Web
{
    public partial class payreturn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string out_trade_no = Request.QueryString["out_trade_no"];
            string returncode = Request.QueryString["returncode"];
            string total_fee =Request.QueryString["total_fee"];
            string sign = Request.QueryString["sign"];

            //先验证签名是否正确
            //订单号、返回码、支付金额、商户密钥为新字符串的MD5值。
            string mySign = Common.CommonCode.Md5Compte(out_trade_no + returncode + total_fee + Common.CommonCode.GetAppSettings("paykey")).ToLower();

            //检测我们算的签名和支付宝返回的签名是否相同.
            //因为只有相同,才能保证数据没有伪造.
            if (sign != mySign)
            {
                //出错,最好导向订单列表,让用户可以进行重新支会.由于现在还没有做这个页面,先导向购物车了.
                Response.Redirect("showmsg.aspx?msg=" + Server.UrlEncode("伪造的网址,请与管理员联系!") + "&return=cart.aspx");
                                return;
            }
            OrdersManager ordersManager = new OrdersManager();
            Model.Orders oneOrder = ordersManager.GetModel(out_trade_no);
            if (oneOrder == null)
            {
                Response.Redirect("showmsg.aspx?msg=" + Server.UrlEncode("定单不存在!") + "&return=cart.aspx");
                return;
            }
            //判断支付金额是否正确
            if (returncode == "ok")
            {
                if (oneOrder.State == 0)
                {
                    oneOrder.State = 1;
                    ordersManager.Update(oneOrder);
                    Response.Redirect("showmsg.aspx?msg=" + Server.UrlEncode("支付成功!") + "&return=cart.aspx");
                }
            }


                

        }
    }
}
