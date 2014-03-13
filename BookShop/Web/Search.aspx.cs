using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string key1 = Request.Form["ctl00$txtSearch"];
            if (Page.PreviousPage != null)
            {
                if (Page.PreviousPage.IsCrossPagePostBack)
                {
                    string key = ((TextBox)Page.PreviousPage.Controls[0].FindControl("txtSearch")).Text;
                    List<Model.Book> searchBooks = new BLL.BookManager().GetBooksByKey(key);
                    Repeater1.DataSource = searchBooks;
                    Repeater1.DataBind();
                    
                }
            }
        }
    }
}
