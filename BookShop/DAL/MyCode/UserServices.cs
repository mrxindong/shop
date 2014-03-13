using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace BookShop.DAL
{
    /// <summary>
    /// 数据访问类UsersServices。
    /// </summary>
    public partial class UserServices
    {


        /// <summary>
        /// 根据loginId获得一条记录,如果不存在,则返回null
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public BookShop.Model.User GetModel(string loginId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,LoginId,LoginPwd,Name,Address,Phone,Mail,UserRoleId,UserStateId from Users ");
            strSql.Append(" where LoginId=@LoginId ");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginId",SqlDbType.NVarChar,50)};
            parameters[0].Value = loginId;

            BookShop.Model.User model = new BookShop.Model.User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                model.LoginPwd = ds.Tables[0].Rows[0]["LoginPwd"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Mail = ds.Tables[0].Rows[0]["Mail"].ToString();
                if (ds.Tables[0].Rows[0]["UserRoleId"].ToString() != "")
                {
                    int UserRoleId = int.Parse(ds.Tables[0].Rows[0]["UserRoleId"].ToString());
                    model.RoleInfo = roleinfoServices.GetModel(UserRoleId);
                }
                if (ds.Tables[0].Rows[0]["UserStateId"].ToString() != "")
                {
                    int UserStateId = int.Parse(ds.Tables[0].Rows[0]["UserStateId"].ToString());
                    model.UserState = userStateServices.GetModel(UserStateId);
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
