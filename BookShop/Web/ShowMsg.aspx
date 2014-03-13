<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowMsg.aspx.cs" Inherits="BookShop.Web.ShowMsg" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
    
    <script type="text/javascript">
        function TimeCount() {
            var timeCount = parseInt(document.getElementById("spTime").innerText);
            timeCount--;
            document.getElementById("spTime").innerText = timeCount;
            if (timeCount <= 0) {
                //如果时间减到了0,我就转向
                window.location = document.getElementById("hpLink").href;
            }
            else {
                //还没有减到0,设置1秒后继续减1秒
                setTimeout(TimeCount, 1000);
                //setInterval(
            }

        }


        window.onload = function() {
         setTimeout(TimeCount, 1000);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>  
      <table width="490" height="325" border="0" align="center" cellpadding="0" cellspacing="0" background="Images/showinfo.png">
      <tr>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="50">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="40">&nbsp;</td>
          </tr>
          <tr>
            <td width="50">&nbsp;</td>
            <td style="text-align: center">
                <asp:Label ID="lbmsg" runat="server" ForeColor="#CC0000" Width="98%"></asp:Label>
              </td>
            <td width="40">&nbsp;</td>
          </tr>
          <tr>
            <td width="50">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="40">&nbsp;</td>
          </tr>
          <tr>
            <td width="50" class="style1">&nbsp;</td>
            <td style="text-align: center">
                <asp:HyperLink ID="hpLink" runat="server" NavigateUrl="~/booklist.aspx">返   回</asp:HyperLink>
                                </td>
            <td width="40">&nbsp;</td>
          </tr>
          <tr>
            <td width="50" class="style1">&nbsp;</td>
            <td style="text-align: center">
                &nbsp;</td>
            <td width="40">&nbsp;</td>
          </tr>
          <tr>
            <td width="50" class="style1">&nbsp;</td>
            <td style="text-align: center">
                <span id="spTime">5</span> 秒后自动转向</td>
            <td width="40">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>
