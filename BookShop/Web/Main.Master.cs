using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL.CategoryManager categoryManager = new BookShop.BLL.CategoryManager();
                //获得图书的所有分类
                List<Model.Category> allcates= categoryManager.GetModelList("");
                TreeNode tn = new TreeNode("全部图书");
                tn.NavigateUrl = "~/booklist.aspx";
                tvCategory.Nodes.Add(tn);
                for (int i = 0; i < allcates.Count; i++)
                {
                     tn = new TreeNode(allcates[i].Name);
                    tn.NavigateUrl = "~/booklist.aspx?categoryid=" + allcates[i].Id.ToString();
                    tvCategory.Nodes.Add(tn);
                    
                }

                
            }
        }
    }
}
