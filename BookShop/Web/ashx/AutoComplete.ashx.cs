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
    public class AutoComplete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string key = context.Request["term"];
            List<Model.Book> searchBooks = new BLL.BookManager().GetBooksByKey(key);
            List<string> booksTitle = new List<string>();

            for (int i = 0; i < searchBooks.Count; i++)
            {
                booksTitle.Add(searchBooks[i].Title);
                if (i >= 9)
                    break;
            }

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(js.Serialize(booksTitle));


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
