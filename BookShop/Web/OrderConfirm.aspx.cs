using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.Web.Common;
using BookShop.BLL;

namespace BookShop.Web
{
    public partial class OrderConfirm : System.Web.UI.Page
    {
        protected Model.User currUser;
        protected decimal totalMoney = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            //此页面必须登录才能访问
            if (!CommonCode.CheckLogin())
            {
                Response.Redirect("/member/login.aspx?return="+Request.Url.ToString());
            }
            currUser = (Model.User)Session["currUser"];

            if (!Page.IsPostBack)
            {
                Master.FindControl("divTree").Visible = false;
                this.Bind();

            }
            if (Request.Form["btnGoPay"] != null)
            {
                //说明用户点击了去结算按钮
                //下面我们就开始生成订单
                //调用完存储过程
                //要支付
                this.CreateOrder();
            }




        }

        protected void CreateOrder()
        {
            //调用存储过程需要的参数
           // 订单号-
           //userid-
          //收货地址-
          //返回一个总金额
            
            
            
            //先验证数据
            if (!Validate())
                return;
            //收集用户地址的信息

            currUser.Name = Request.Form["txtName"].Trim();
            currUser.Phone = Request.Form["txtPhone"].Trim();
            currUser.Address = Request.Form["txtAddress"].Trim();
            string postCode = Request.Form["txtPostCode"].Trim();
            string address = string.Format("姓名:{0} 电话:{1} 地址:{2} 邮编:{3}",
                currUser.Name, currUser.Phone, currUser.Address, postCode);
            int userId = currUser.Id;
            
            string orderNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff") + userId.ToString();
            OrdersManager orderManager = new OrdersManager();
            
            //生成订单
            totalMoney= orderManager.CreateOrder(orderNumber, userId, address);
            //用户选择支付宝支付
            if (Request.Form["zfPay"] == "zfb")
            {
                PayGate.AlipayClass alipay = new BookShop.Web.PayGate.AlipayClass("图书", "我的书店购买的书",
                    orderNumber, totalMoney);
                string url = alipay.GetPayUrl();
                Response.Redirect(url);


            }
            //用户选择网银在线支付
            else if (Request.Form["zfPay"]=="wyzx")

            {

            }


           // Response.Redirect("showmsg.aspx?return=/booklist.aspx&msg=" + Server.UrlEncode("生成订单成功,得到的总金额为" + totalMoney.ToString("0.00")));







        }

     new    protected bool Validate()
        {
            if (Request.Form["txtName"].Trim().Length == 0 ||
                Request.Form["txtAddress"].Trim().Length == 0 ||
                Request.Form["txtPhone"].Trim().Length == 0 ||
                Request.Form["txtPostCode"].Trim().Length == 0)
            {
                Response.Redirect("showmsg.aspx?return=" + Request.Url.ToString() + "&msg=" + Server.UrlEncode("填写的地址资料不完整!"));
                return false;
            }
            else
            {
                return true;
            }

            
        }

        protected void Bind()
        {
            CartManager cartManager = new CartManager();
            int userId = ((Model.User)Session["currUser"]).Id;
            List<Model.Cart> allCarts = cartManager.GetModelList("UserId=" + userId.ToString());

            //购物车中没有图书
            if (allCarts.Count == 0)
            {
                Response.Redirect("showmsg.aspx?return=/booklist.aspx&msg=" + Server.UrlEncode("购物车为空,请先购物!"));
            }

            rptCart.DataSource = allCarts;
            rptCart.DataBind();
            
            totalMoney = 0;
            foreach (var oneCart in allCarts)
            {
                totalMoney += oneCart.Book.UnitPrice * oneCart.Count;
            }
        }
    }
}
