<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminmaster.Master" AutoEventWireup="true" CodeBehind="listallusers.aspx.cs" Inherits="BookShop.Web.admin.listallusers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
<script type="text/javascript">
    function RepwdConfirm() {
        return confirm("你确定要重置密码吗?");
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="odsUser" ForeColor="#333333" 
        GridLines="None" ondatabound="gvUsers_DataBound" 
        onrowcommand="gvUsers_RowCommand" onrowdatabound="gvUsers_RowDataBound">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                ReadOnly="True" />
            <asp:BoundField DataField="LoginId" HeaderText="登录名" SortExpression="LoginId" 
                ReadOnly="True" />
            <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
            <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
            <asp:BoundField DataField="Phone" HeaderText="电话" SortExpression="Phone" />
            <asp:BoundField DataField="Mail" HeaderText="电子邮件" SortExpression="Mail" />
            <asp:TemplateField HeaderText="角色">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("RoleInfo.RoleName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlRoleInfo" runat="server" DataSourceID="odsRoleInfo" 
                        DataTextField="RoleName" DataValueField="RoleId">
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfRoleId" runat="server" 
                        Value='<%# Eval("RoleInfo.RoleId") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton CommandName="repwd" ID="LinkButton1" runat="server" CausesValidation="false" 
                         Text="密码" CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="odsUser" runat="server" 
        DataObjectTypeName="BookShop.Model.User" DeleteMethod="Delete" 
        SelectMethod="GetModelList" TypeName="BookShop.BLL.UserManager" 
        UpdateMethod="Update" onupdating="odsUser_Updating">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsRoleInfo" runat="server" 
        SelectMethod="GetModelList" TypeName="BookShop.BLL.RoleInfoManager">
        <SelectParameters>
            <asp:Parameter Name="strWhere" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
