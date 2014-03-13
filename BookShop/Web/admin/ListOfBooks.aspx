<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminmaster.Master" AutoEventWireup="true" CodeBehind="ListOfBooks.aspx.cs" Inherits="BookShop.Web.admin.ListOfBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
        GridLines="None">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="书名" SortExpression="Title" />
            <asp:BoundField DataField="Author" HeaderText="作者" SortExpression="Author" />
            <asp:TemplateField HeaderText="分类">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Category.Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="id" 
                DataNavigateUrlFormatString="ListOfBooks_BookDetail.aspx?id={0}" 
                HeaderText="详细" Text="详细" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetModelList" TypeName="BookShop.BLL.BookManager">
        <SelectParameters>
            <asp:Parameter Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
