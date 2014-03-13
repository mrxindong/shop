using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class cart : System.Web.UI.Page
    {
        BLL.CartManager cartManager = new BookShop.BLL.CartManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            //检测用户是否登录
            if (!Common.CommonCode.CheckLogin())
            {
                Response.Redirect("/member/login.aspx?return=" + Request.Url.ToString());

            }



            if (!Page.IsPostBack)
            {
                Master.FindControl("divTree").Visible = false;
                this.AddCart();
                this.Bind();
            }

        }

        protected void AddCart()
        {
            if (Request.QueryString["id"] != null)
            {

                int bookId = 0;

                //判断传过来的id转数字是否成功,成功则继续添加
                if (int.TryParse(Request.QueryString["id"],out bookId))
                {
                //要向购物车添加图书了
                   Model.Cart add = new BookShop.Model.Cart();
                  add.User.Id = ((Model.User)Session["currUser"]).Id;
                  add.Book.Id = bookId;
                  add.Count = 1;
                  cartManager.Add(add);

    
                }
                

                

            }
        }


        protected void Bind()
        {
        
            int userId = ((Model.User)Session["currUser"]).Id;
            List<Model.Cart> allCarts = cartManager.GetModelList("UserId="+userId.ToString());
            rptCart.DataSource = allCarts;
            rptCart.DataBind();
        }

    }
}
