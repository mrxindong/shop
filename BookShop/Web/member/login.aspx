<%@ Page Title="" Language="C#" MasterPageFile="~/member/member.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BookShop.Web.member.login" %>
<%@ Register src="../UsControls/UsLogin.ascx" tagname="UsLogin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UsLogin ID="UsLogin1" runat="server" />
</asp:Content>
