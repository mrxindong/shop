using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;

namespace BookShop.Web.Common
{
    public static class CommonCode
    {
        public static void ShowMessage(System.Web.UI.Page page, string txt)
        {
            txt = txt.Replace("'", "").Replace("\r", "").Replace("\n", "");
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), Guid.NewGuid().ToString(),
                "alert('" + txt + "');", true);
        }

        public static void WriteScript(System.Web.UI.Page page, string txt)
        {
            
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), Guid.NewGuid().ToString(),
                txt+";", true);
        }


        public static string Md5Compte(string txt)
        {
            string str = "";
            MD5 md5 = MD5.Create();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(txt);
            byte[] results= md5.ComputeHash(bytes);

            for (int i = 0; i < results.Length; i++)
            {
                str = str + results[i].ToString("X2");
            }

            return str;


        }
        /// <summary>
        /// 检测用户是否登录,登录返回 true,否则的话返回false
        /// </summary>
        /// <returns></returns>
        public static bool CheckLogin()
        {
            if (HttpContext.Current.Session["currUser"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static string GetAppSettings(string key)
        {
            if (System.Configuration.ConfigurationManager.AppSettings[key] != null)
            {
                return System.Configuration.ConfigurationManager.AppSettings[key];
            }
            else
            {
                return "";
            }
        }
    }
}
