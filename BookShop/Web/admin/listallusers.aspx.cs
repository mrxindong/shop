using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

namespace BookShop.Web.admin
{
    public partial class listallusers : LoginedPage
    {
        UserManager userManager = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvUsers_DataBound(object sender, EventArgs e)
        {
            if (gvUsers.EditIndex != -1)
            {
                //当前用户要编辑某一行了

                //得到当前要编辑的这一行用户角色的id
                string id = ((HiddenField)gvUsers.Rows[gvUsers.EditIndex].Cells[6].FindControl("hfRoleId")).Value;
                DropDownList ddl= (DropDownList)gvUsers.Rows[gvUsers.EditIndex].Cells[6].FindControl("ddlRoleInfo");
                ddl.SelectedValue = id;

            }
        }

        protected void odsUser_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
         
            //得到将要更新的用户
            Model.User updateUser = (Model.User)e.InputParameters[0];
            Model.User dbUser = userManager.GetModel(updateUser.Id);

            //对界面上没有的列和 
            updateUser.LoginPwd = dbUser.LoginPwd;
            updateUser.UserState = dbUser.UserState;

            //无法传回的属性进行赋值
            DropDownList ddl = (DropDownList)gvUsers.Rows[gvUsers.EditIndex].Cells[6].FindControl("ddlRoleInfo");
            updateUser.RoleInfo.RoleId = Convert.ToInt32(ddl.SelectedValue);


            

        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "repwd")
            {
                //重置密码
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                Model.User updateUser = userManager.GetModel(id);
                updateUser.LoginPwd = Common.CommonCode.Md5Compte("123");
                userManager.Update(updateUser);
                Common.CommonCode.ShowMessage(Page, "密码更新成功!");
            }

        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //当一行绑定完成后触发的一个事
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb =  (LinkButton)e.Row.Cells[8].FindControl("LinkButton1");
                lb.Attributes.Add("onclick", "return RepwdConfirm()");
            }
            
        }
    }
}
