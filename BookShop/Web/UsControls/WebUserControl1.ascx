<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="BookShop.Web.UsControls.WebUserControl1" %>
<%@ Register src="UsLogin.ascx" tagname="UsLogin" tagprefix="uc1" %>
<asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>


<asp:Button ID="Button1" runat="server" Text="Button" />
<uc1:UsLogin ID="UsLogin1" runat="server" />
