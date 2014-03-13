using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BookShop.Web.Common;

namespace BookShop.Web
{
    public partial class booklist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Bind(1);
            }


            

            //演示使用非服务器控件提交时  btnorderDate不是服务器控件,要是服务
            //器端控件,我就写事件了.一个页面上有多个sumit按钮时,点击哪个控件提交
            //哪一个控件的Request.Form[控件name属性]会不为 null,其他的sumit按钮都为null
            if (Request.Form["btnOrderDate"] != null)
            {
                this.BindOrderByDate();  //html标签触发排序          
            }

        }


        protected void BindOrderByDate()
        {
            ViewState["order"] = "PublishDate desc";
            this.Bind(1);

        }


        protected void Bind(int currentPageNumber)
        {
            BLL.BookManager bookManager = new BookShop.BLL.BookManager();

            int categoryId = 0;//存当前用户浏览的书的分类,0为所有分类
            int pageCount = 0;//存总页数
            string orderby = "id"; //存排序依据

            if (Request.QueryString["categoryid"] != null)
            {
                if (!int.TryParse(Request.QueryString["categoryid"], out categoryId))
                {
                    //如果转换失败,赋为0
                    categoryId = 0;
                }
            }

            if (ViewState["order"] != null)
            {
                orderby = ViewState["order"].ToString();
            }


            //求当前分类下的总页数
            pageCount = bookManager.GetPageCount(10,categoryId);

            //在绑定之前,进行数据页数的检查
            if (currentPageNumber < 1)
            {
                currentPageNumber = 1;
            }
            if (currentPageNumber > pageCount)
            {
                currentPageNumber = pageCount;
            }

          

            btnPre.Enabled = btnNext.Enabled = true;
            if (currentPageNumber == 1)
            {
                btnPre.Enabled = false;
            }
            if (currentPageNumber == pageCount)
            {
                btnNext.Enabled = false;
            }


            List<Model.Book> allbooks = bookManager.GetBooksByPageNumber(10, currentPageNumber, categoryId,orderby);
            dstBooks.DataSource = allbooks;
            dstBooks.DataBind();
            lbPageCount.Text = pageCount.ToString();//显示总页数
            lbPageNumber.Text = currentPageNumber.ToString();//显示当前页
            txtGoPage.Text = currentPageNumber.ToString();



        }


        protected string CutString(string txt)
        {
            int len = 150;
            if (txt.Length > len)
            {
                return txt.Substring(0, len - 2) + "...";
            }
            else
            {
                return txt;
            }

        }

        protected void btnPre_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(lbPageNumber.Text);
            this.Bind(--currentPage);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(lbPageNumber.Text);
            this.Bind(++currentPage);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int goPageNumber=0;
            Regex r = new Regex(@"^\d+$");
            if (r.IsMatch(txtGoPage.Text))
            {
                goPageNumber = Convert.ToInt32(txtGoPage.Text);
                this.Bind(goPageNumber);
            }
            else
            {
                txtGoPage.Text = lbPageNumber.Text;
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            if (btnPrice.Text == "价格↑")
            {
                //要按价格的升序进行排序了
                btnPrice.Text = "价格↓";
                //按升序排序的代码
                ViewState["order"] = "UnitPrice";
                this.Bind(1);
                

            }
            else
            {
                //要按价格的降序排序
                btnPrice.Text = "价格↑";
                ViewState["order"] = "UnitPrice desc";
                this.Bind(1);
            }
        }




    }
}
