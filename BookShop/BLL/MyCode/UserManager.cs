using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using BookShop.Model;
using BookShop.DAL;




namespace BookShop.BLL
{
    /// <summary>
    /// 业务逻辑类UsersManager 的摘要说明。
    /// </summary>
    public partial class UserManager
    {
        /// <summary>
        /// 添加一个用户,如果添加成功,则返回true,currUser中存放添加到数据库中的用户实体 msg消息  
        /// </summary>
        /// <param name="addUser">待添加的用户</param>
        /// <param name="currUser">返回添加成功的用户</param>
        /// <param name="msg">消息 </param>
        /// <returns></returns>
        public bool Add(User addUser,out int id,out string msg)
        {
            id = 0;
            msg = "";

            //判断当前loginid在数据库中是否存在?
            if (CheckExistByLoginid(addUser.LoginId))
            {
                //loginid存在,要报错,不要再添加了
                msg = "用户名已经存在!";
                return false;
            }
            else
            {
                //loginid不存在,可以添加该数据
                try
                {
                    id = dal.Add(addUser);

                    msg = "添加成功!";
                    return true;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    return false;
                }

            }

        }

        /// <summary>
        /// 根据loginid检测用户是否存在,如果存在则返回true,如果不存在,则返回false
        /// </summary>
        /// <param name="loginid"></param>
        /// <returns></returns>
        public bool CheckExistByLoginid(string loginid)
        {
            User oneUser = dal.GetModel(loginid);
            if (oneUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 传一个用户名和一个密码,判断登录是否成功.密码是经过md5加密的.,  isAdmin=false,表示前台登录,true表示后台登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <param name="msg">成功或失败的消息</param>
        /// <param name="loginUser">当前登录成功的用户实体</param>
        /// <returns></returns>
        public bool UserLogin(string loginId,string userPwd,out string msg,out User loginUser,bool isAdmin)
        {
            loginUser = dal.GetModel(loginId);
            if (loginUser != null)
            {
                //找到了当前用户
                if (loginUser.LoginPwd == userPwd && loginUser.UserState.Name == "正常")
                {

                    if (isAdmin == true)
                    {
                        if (loginUser.RoleInfo.RoleId > 1)
                        {
                            msg = string.Format("{0}登录成功", loginUser.Name);
                            return true;
                        }
                        else
                        {
                            msg = string.Format("{0}-没有权限登录后台", loginUser.Name);
                            return false;
                        }

                    }
                    else
                    {
                        //用户登录成功
                        msg = string.Format("{0}登录成功", loginUser.Name);
                        return true;
                    }
                }
                else
                {
                    //用户密码错误或用户被禁用
                    if (loginUser.LoginPwd != userPwd)
                    {
                        msg = "密码错误!";
                    }
                    else
                    {
                        msg = "用户状态不正常!";
                    }
                    return false;

                }
            }
            else
            {
                //没有找到该用户名
                msg = "该用户不存在!";
                return false;

            }


        }
        /// <summary>
        /// 前台登录-老方法
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="userPwd"></param>
        /// <param name="msg"></param>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public bool UserLogin(string loginId, string userPwd, out string msg, out User loginUser)
        {
            return this.UserLogin(loginId, userPwd, out msg, out loginUser, false);


        }


        public Model.User GetModel(string loginId)
        {
            return dal.GetModel(loginId);
        }
    }
}
