<%@ Page Title="" Language="C#" MasterPageFile="~/member/member.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="BookShop.Web.member.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<style>
.Focus
{
	border:solid 1px #f00;
   background-color:#fcc;
}
</style>

<script type="text/javascript">

    $(function() {
        //页面加载后执行
        $("input").focus(function() {
            $(this).addClass("Focus");
        }).blur(function() {
            $(this).removeClass("Focus");

        });


        //光标离开时,检测用户名是否存在
        $("#<%=txtLoginId.ClientID %>").blur(function() {
            //当光标离开时
            CheckUser();



        });

        $("#imgRequest").ajaxStart(function() {
            $(this).show();
        });
        $("#imgRequest").ajaxStop(function() {
            $("#imgRequest").hide();
        });


        CheckUser();

    });

    var IsRight = true;
    function CheckUser() {
        var loginId = $("#<%=txtLoginId.ClientID %>").val();
        if (loginId != "") {
            $.post("/ashx/CheckUser.ashx", { "loginid": loginId },
                function(data) {
                    if (data == "yes") {
                        //说明不存在,可以注册
                        $("#imgUser").attr("src", "/images/dui.ico").show();
                        IsRight = true;
                    }
                    else {
                        $("#imgUser").attr("src", "/images/cha.ico").show();
                        IsRight = false;
                    }

                }

                , "text");
        }
    }

    function ChangeVCode(img) {
        img.src = "/ashx/ValidateCode.ashx?"+new Date();
    }

    function ClientValidate(sender, args) {
        args.IsValid = IsRight;

    }

    function btnClick() {
        var loginId = $("#<%=txtLoginId.ClientID %>").val();
        if (loginId != "") {
            $.post("/ashx/CheckUser.ashx", { "loginid": loginId },
                function(data) {
                    if (data == "yes") {
                        //说明不存在,可以注册
                        $("#imgUser").attr("src", "/images/dui.ico").show();
                        IsRight = true;
                        Page_ClientValidate(null);
                        if (Page_IsValid) {

                            __doPostBack('ctl00$ContentPlaceHolder1$ibtnReg', '')
                        }
                    }
                    else {
                        $("#imgUser").attr("src", "/images/cha.ico").show();
                        IsRight = false;
                        alert("不能注册!");
                    }

                }

                , "text");
        }
    
    
        
    }
    

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="font-size:small">
  <table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td style="width: 10px"><img src="../Images/az-tan-top-left-round-corner.gif" width="10" height="28" /></td>
    <td bgcolor="#DDDDCC"><span class="STYLE1">注册新用户</span></td>
    <td width="10"><img src="../Images/az-tan-top-right-round-corner.gif" width="10" height="28" /></td>
  </tr>
</table>


<table width="80%" height="22" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
    <td><div align="center">
      <table height="61" cellpadding="0" cellspacing="0" style="height: 332px">
        <tr>
          <td height="33" colspan="6"><p class="STYLE2" style="text-align: center">注册新帐户方便又容易<asp:CustomValidator 
                  ID="CustomValidator1" runat="server" ClientValidationFunction="ClientValidate" 
                  ControlToValidate="txtLoginId" Display="None" ErrorMessage="用户名已存在!"></asp:CustomValidator></p></td>
        </tr>
        <tr>
          <td width="24%" align="center" valign="top" style="height: 26px">用户名</td>
          <td valign="top" width="37%" align="left" style="height: 26px">
              <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="txtLoginId" Display="Dynamic" ErrorMessage="用户名不能为空!">*</asp:RequiredFieldValidator>
                                            <img id="imgUser" src="" style="display:none;width:15px;height:15px"/></td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">真实姓名：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="真实姓名不能为空!">*</asp:RequiredFieldValidator>
                                            </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">密码：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="txtPwd" Display="Dynamic" ErrorMessage="密码不能为空!">*</asp:RequiredFieldValidator>
                                            </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">确认密码：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="txtPwd2" runat="server"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" 
                  runat="server" ControlToCompare="txtPwd2" ControlToValidate="txtPwd" 
                  ErrorMessage="两次密码必须相同!">*</asp:CompareValidator>
                                            </td>          
        </tr>
         <tr>
          <td width="24%" height="26" align="center" valign="top">Email：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                  ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email不能为空!">*</asp:RequiredFieldValidator>
                                            </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">地址：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                  ControlToValidate="txtLoginId" Display="Dynamic" ErrorMessage="地址不能为空!">*</asp:RequiredFieldValidator>
                                            </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">手机：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                  ControlToValidate="txtLoginId" Display="Dynamic" ErrorMessage="手机不能为空!">*</asp:RequiredFieldValidator>
                                            </td>          
        </tr>
        <tr>
          <td width="24%" height="26" align="center" valign="top">
              验证码：</td>
          <td valign="top" width="37%" align="left">
              <asp:TextBox ID="txtVCode" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                  ControlToValidate="txtLoginId" Display="Dynamic" ErrorMessage="验证码不能为空!">*</asp:RequiredFieldValidator>
              <br />
              <img src="../ashx/ValidateCode.ashx" onclick="ChangeVCode(this)" />
              </td>          
        </tr>
        <tr>
          <td colspan="2" align="left" style="text-align: center">
              <img id="imgRequest" src="../Images/22.gif" style="display:none;width:15px;height:15px" /> <asp:ImageButton ID="ibtnReg" runat="server" 
                  ImageUrl="~/Images/az-finish.gif" onclick="ibtnReg_Click" />
            &nbsp; <input type="button" value="提交" onclick="btnClick()" /></td>           
        </tr>
        <tr>
          <td colspan="2" align="center">
              <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                  ShowMessageBox="True" ShowSummary="False" />
              <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </td>           
        </tr>
      </table>
      <div class="STYLE5">---------------------------------------------------------</div>
    </div>	
    </td>
    <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
  </tr>
</table>

<table width="80%" height="3" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="3" bgcolor="#DDDDCC"><img src="../Images/touming.gif" width="27" height="9" /></td>
  </tr>
</table>
</div>
</asp:Content>
