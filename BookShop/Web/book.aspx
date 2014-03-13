<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="BookShop.Web.book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <asp:DetailsView ID="dvBook" runat="server" AutoGenerateRows="False" 
    CellPadding="4" DataSourceID="odsBook" ForeColor="#333333" GridLines="None" 
    Height="50px" Width="98%">
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
    <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" HorizontalAlign="Center" 
        Width="50px" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <Fields>
        <asp:BoundField DataField="Title" HeaderText="书名" SortExpression="Title" />
        <asp:ImageField DataAlternateTextField="Title" 
            DataAlternateTextFormatString="你正在看的是:{0}" DataImageUrlField="ISBN" 
            DataImageUrlFormatString="~/images/bookcovers/{0}.jpg" HeaderText="封面">
        </asp:ImageField>
        <asp:BoundField DataField="Author" HeaderText="作者" SortExpression="Author" />
        <asp:BoundField DataField="PublishDate" HeaderText="出版日期" 
            SortExpression="PublishDate" />
        <asp:TemplateField HeaderText="单价" SortExpression="UnitPrice">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("UnitPrice","{0:0.00}") %>'></asp:Label>元
               <a href='<%#Eval("Id","/cart.aspx?id={0}") %>'> <img src="Images/sale.gif" border="0" /></a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="ContentDescription" HeaderText="内容简介" 
            SortExpression="ContentDescription" />
        <asp:BoundField DataField="TOC" HeaderText="目录" HtmlEncode="False" 
            SortExpression="TOC" />
    </Fields>
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:DetailsView>
<asp:ObjectDataSource ID="odsBook" runat="server" SelectMethod="GetModel" 
    TypeName="BookShop.BLL.BookManager">
    <SelectParameters>
        <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>
