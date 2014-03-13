using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

namespace BookShop.Web.admin
{
    public partial class ListOfBooks_BookDetail : System.Web.UI.Page
    {
        BookManager bookManager = new BookManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            Model.Book updateBook = (Model.Book)e.InputParameters[0];
            Model.Book dbBook = bookManager.GetModel(updateBook.Id);
            //更新界面上没有显示的内容
            updateBook.Publisher = dbBook.Publisher;
            updateBook.ISBN = dbBook.ISBN;
            updateBook.WordsCount = dbBook.WordsCount;
            updateBook.ContentDescription = dbBook.ContentDescription;
            updateBook.AurhorDescription = dbBook.AurhorDescription;
            updateBook.EditorComment = dbBook.EditorComment;
            updateBook.Category = dbBook.Category;
            updateBook.Clicks = dbBook.Clicks;


        }

        protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                //业务逻辑层没有出错     判断传上来的文件名是否是.jpg的格式 
                FileUpload fup = ((FileUpload)(DetailsView1.Rows[0].FindControl("FileUpload1")));
                HiddenField hdIsbn = ((HiddenField)(DetailsView1.Rows[0].FindControl("HiddenField2")));
                if (fup.PostedFile.ContentLength > 100)
                {
                    
                    fup.PostedFile.SaveAs(Server.MapPath("~/images/bookcovers/"+hdIsbn.Value+".jpg"));

                }

            }
        }
    }
}
