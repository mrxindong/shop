﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class RSS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Repeater1.DataSource=  new BLL.BookManager().GetBooksByPageNumber(10, 1, 0, "UnitPrice desc");
            Repeater1.DataBind();

            

        }
    }
}
