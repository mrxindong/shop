using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;

namespace BookShop.Web.test
{
    public partial class TreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclare= xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclare);
            XmlElement root= xmlDoc.CreateElement("root");
            xmlDoc.AppendChild(root);

            BLL.CategoryManager categoryManager = new BookShop.BLL.CategoryManager();
            List<Model.Category> allcates = categoryManager.GetModelList("");
            for (int i = 0; i < allcates.Count; i++)
            {
                XmlElement node = xmlDoc.CreateElement("node");
                node.SetAttribute("name", allcates[i].Name);
                node.SetAttribute("url", "/booklist.aspx?categoryid="+allcates[i].Id.ToString());
                root.AppendChild(node);

            }


            xmlDoc.Save(Server.MapPath("~/XMLFile1.xml"));

        }
    }
}
