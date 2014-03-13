using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace BookShop.Web.Common
{
    public class wmCode : IHttpHandler
    {

        #region IHttpHandler 成员

        public bool IsReusable
        {
            get { return false; }
        }

     
          private const string WATERMARK_URL = "~/Images/watermark.jpg";        //水印图片
        private const string DEFAULTIMAGE_URL = "~/Images/default.jpg";  


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
        
       
            //用户请求图片的物理路径
           string filePath = context.Request.PhysicalPath;
           Image Cover;
            bool isMy=false;
           if (context.Request.UrlReferrer != null)
           {

               string urlReffer = context.Request.UrlReferrer.ToString();
               isMy = (urlReffer.IndexOf("localhost:1555") >= 0);
           }

            if (File.Exists(filePath) && isMy)
           {
               //加载文件
               Cover = Image.FromFile(filePath);
               //加载水印图片
               Image watermark = Image.FromFile(context.Request.MapPath(WATERMARK_URL));
               //实例化画布
               Graphics g = Graphics.FromImage(Cover);
               //在image上绘制水印
               g.DrawImage(watermark, new Rectangle(Cover.Width - watermark.Width, Cover.Height - watermark.Height, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel);
               //释放画布
               g.Dispose();
               //释放水印图片
               watermark.Dispose();
           }
           else
           {
               //加载默认图片
               Cover = Image.FromFile(context.Request.MapPath(DEFAULTIMAGE_URL));
           }
           //设置输出格式
           context.Response.ContentType = "image/jpeg";
           //将图片存入输出流
           Cover.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
           Cover.Dispose();
           context.Response.End();
        }

        #endregion
    }
}
