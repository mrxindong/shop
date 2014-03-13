<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeView.aspx.cs" Inherits="BookShop.Web.test.TreeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">

a:link{ color:#0042d1; text-decoration:none}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
            <asp:TreeView ID="tvCategory" runat="server" ImageSet="WindowsHelp" 
        DataSourceID="XmlDataSource1">
                <ParentNodeStyle Font-Bold="False" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                    HorizontalPadding="0px" VerticalPadding="0px" />
                <DataBindings>
                    <asp:TreeNodeBinding DataMember="node" NavigateUrlField="url" 
                        TextField="name" />
                </DataBindings>
                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                    HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="1px" />
            </asp:TreeView>
        <br />
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/XMLFile1.xml" 
        XPath="/root/node"></asp:XmlDataSource>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
