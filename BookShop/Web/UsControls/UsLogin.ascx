﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsLogin.ascx.cs" Inherits="BookShop.Web.UsControls.UsLogin" %>
<table width="60%" height="22" border="0" align="center" cellpadding="0" cellspacing="0" runat="server" id="tblfirst">
<tr>
  <td width="10"><img src="/Images/az-tan-top-left-round-corner.gif" width="10" height="28" /></td>
  <td bgcolor="#DDDDCC"><span style="font-family: '黑体';font-size: 16px;color: #660000;">登录网上书店</span></td>
  <td width="10"><img src="/Images/az-tan-top-right-round-corner.gif" width="10" height="28" /></td>
</tr>
</table>
<table width="60%" height="22" border="0" align="center" cellpadding="0" cellspacing="0" runat="server" id="tblsecend">
<tr>
  <td bgcolor="#DDDDCC" style="width: 2px">&nbsp;</td>
  <td><div align="center">
      <table height="61" cellpadding="0" cellspacing="0">
        <tr>
          <td height="33" colspan="6">
              <p style="font-size:14px;font-weight: bold;color: #FF9900; text-align: center;">已注册用户请从这里登录</p></td>
        </tr>
        <tr>
          <td width="24%" height="26" rowspan="2" align="right" valign="top"><strong>用户名：</strong></td>
          <td valign="top" width="37%">
              &nbsp;<asp:TextBox ID="txtLoginId" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginId"
      ErrorMessage="*"></asp:RequiredFieldValidator></td>                  
        </tr>
      </table>
    <table height="61" cellpadding="0" cellspacing="0">
        <tr>
          <td height="1" colspan="2"></td>
        </tr>
        <tr>
          <td width="24%" height="26" rowspan="3" align="right" valign="top"><strong>密　码：</strong></td>
          <td valign="top" width="37%">
              &nbsp;<asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password" 
                  Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginPwd"
      ErrorMessage="*"></asp:RequiredFieldValidator></td>                  
        </tr>
        
        <tr>
          <td valign="top" width="37%">
              <asp:CheckBox ID="cbAutoLogin" runat="server" Text="记住我" />
            </td>                  
        </tr>
        
      </table>
      <div>
    <asp:ImageButton runat="server" ID="imgbtnLogin" ImageUrl="/Images/az-login-gold-3d.gif" OnClick="btnLogin_Click" />
    <asp:ImageButton runat="server" ID="imgbtnRegister" 
              ImageUrl="/Images/az-newuser-gold-3d.gif" OnClick="btnRegister_Click"  
              CausesValidation="false" Height="22px"/>
  &nbsp;
  </div>
      <div >
        <div align="center">
            &nbsp;</div>
      </div>
    </td>
  <td width="2" bgcolor="#DDDDCC">&nbsp;</td>
</tr>
</table>
<table width="60%" height="3" border="0" align="center" cellpadding="0" cellspacing="0"  runat="server" id="tblthird">
<tr align="center">
  <td height="3" bgcolor="#DDDDCC">
      &nbsp;
      </td>
      </tr>
</table>


