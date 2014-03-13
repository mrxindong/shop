<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aaaa.aspx.cs" Inherits="BookShop.Web.test.aaaa" %>

<%@ Register src="../UsControls/UsLogin.ascx" tagname="UsLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
         var r = new RegExp("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
        
        
       // var r = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
        alert(r.test("aa@aaaa.com"));
    
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    
    </div>
    </form>
    <p>
        <input id="Button2" type="button" value="button" /></p>
</body>
</html>
