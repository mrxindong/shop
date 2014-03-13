<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminmaster.Master" AutoEventWireup="true" CodeBehind="ListOfBooks_BookDetail.aspx.cs" Inherits="BookShop.Web.admin.ListOfBooks_BookDetail" ValidateRequest="false" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    
    <script type="text/javascript">

        function showImg(value) {

            //alert(value.substr(value.indexOf("."), 4));
            var obj = window.document.getElementById("imgUpload");

        

            obj.src = value
        }
    
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
        GridLines="None" Height="50px" Width="98%">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <RowStyle BackColor="#EFF3FB" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <Fields>
            <asp:BoundField DataField="Title" HeaderText="书名" SortExpression="Title" /> 
            <asp:TemplateField HeaderText="封面">
                <EditItemTemplate>
                    <img id="imgUpload" src='<%#Eval("isbn","/images/bookcovers/{0}.jpg") %>' />
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="showImg(this.value)" />
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("Id") %>' />
                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Bind("ISBN") %>' />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("isbn") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl='<%# Eval("isbn", "/images/bookcovers/{0}.jpg") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Author" HeaderText="作者" SortExpression="Author" />
            <asp:TemplateField HeaderText="出版日期" SortExpression="PublishDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PublishDate","{0:yyyy-MM-dd}") %>'  onclick="WdatePicker()"></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PublishDate") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("PublishDate","{0:yyyy-MM-dd}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单价" SortExpression="UnitPrice">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("UnitPrice","{0:0.00}") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" 
                        Text='<%# Bind("UnitPrice", "{0:0.00}") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" 
                        Text='<%# Bind("UnitPrice", "{0:0.00}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TOC" SortExpression="TOC">
                <EditItemTemplate>
                    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Text='<%#Bind("TOC") %>'>
                    </CKEditor:CKEditorControl>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("TOC") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("TOC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="BookShop.Model.Book" SelectMethod="GetModel" 
        TypeName="BookShop.BLL.BookManager" UpdateMethod="Update" 
        onupdating="ObjectDataSource1_Updating" 
        onupdated="ObjectDataSource1_Updated">
        <SelectParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
