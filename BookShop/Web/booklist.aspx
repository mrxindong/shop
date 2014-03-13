<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="booklist.aspx.cs" Inherits="BookShop.Web.booklist"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/page_bottom_new.css" rel="stylesheet" type="text/css" />
    <STYLE type=text/css>
*{padding:0;margin:0}
image{border:0;}
div{color:#000000;
     font-size:12px;}
	 
td{color:#000000;
     font-size:12px;}
	 
.topdiv{position:absolute;
        left:700px;
		top:100px;
		width:190px;}
.top-input{border:0;
           background:#FFFFFF;
		   width:175px;
		   height:20px;
		   padding-top:2px;}
.middle-bg{background:url(Images/index-bg.jpg) 0px 0px no-repeat;
           width:1024px;}
.middle-left{width:180px;}
.middle-left1{width:150px;border-left:1 #7AB271 solid;border-right:1 #7AB271 solid;padding:10px 5px 10px 5px;}  		   
.bottom {width:80px;color:#000000;line-height:30px;font-size:12px;text-align:center; text-decoration:none;}
.bottom :hover{width:80px;color:#000000;line-height:30px;font-size:12px;text-align:center; text-decoration:none;}
.bcopyright{color:#666666;font-size:12px; text-align:center;}



</STYLE>

<STYLE type=text/css>
	.ctl00_tvStoreClass_0 { text-decoration:none; }
</STYLE>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">


<DIV class=contentstyle>
            <DIV id=divOrder>
            <DIV style="MARGIN: 20px 0px; TEXT-ALIGN: left">排序方式： 
                <asp:Button class="anniu" 
                    style="border: 1px solid seagreen; FONT-WEIGHT: normal; FONT-SIZE: 12px; WIDTH: 57px; COLOR: black; BACKGROUND-COLOR: #c0ffc0" 
                    Text="价格↑" runat="server" id="btnPrice" Height="28px" onclick="btnPrice_Click" 
                     /> 
            | <input class="anniu"  style="BORDER-RIGHT: seagreen 1px solid; BORDER-TOP: seagreen 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 12px; BORDER-LEFT: seagreen 1px solid; WIDTH: 57px; COLOR: black; BORDER-BOTTOM: seagreen 1px solid; HEIGHT: 16px; BACKGROUND-COLOR: #c0ffc0" type="submit" value="出版日期" name="btnOrderDate" ></DIV></DIV></DIV>
    <asp:DataList ID="dstBooks" runat="server" EnableViewState="False">
        <ItemTemplate>        
            <TABLE>
                    <TBODY>
                    <TR>
                      <TD rowSpan=2><A 
                        href='<%#Eval("Id","/book.aspx?id={0}") %>' ><IMG 
                        style="CURSOR: hand" height=121 
                        alt='<%#Eval("title") %>' hspace=4 
                        src='<%#Eval("ISBN","/images/bookcovers/{0}.jpg") %>' width=95></A> 
</TD>
                      <TD style="FONT-SIZE: small; COLOR: red" width=650><A 
                        class=booktitle id=link_prd_name 
                        href='<%#Eval("Id","/book.aspx?id={0}") %>' target=_blank 
                        name=link_prd_name><%#Eval("Title") %>  </A> </TD></TR>
                    <TR>
                      <TD align=left><SPAN 
                        style="FONT-SIZE: 12px; LINE-HEIGHT: 20px"><%#Eval("Author") %></SPAN><BR><BR><SPAN 
                        style="FONT-SIZE: 12px; LINE-HEIGHT: 20px"><%#this.CutString(Eval("ContentDescription").ToString()) %></SPAN> 
                      </TD></TR>
                    <TR>
                      <TD align=right colSpan=2><SPAN 
                        style="FONT-WEIGHT: bold; FONT-SIZE: 13px; LINE-HEIGHT: 20px"><%#Eval("UnitPrice","{0:C}") %></SPAN> </TD></TR></TBODY></TABLE>
        </ItemTemplate>
        <SeparatorTemplate>
        <hr />
        </SeparatorTemplate>
    </asp:DataList>
    <br />
     <DIV class=contentstyle 
            style="MARGIN: 20px 0px; TEXT-ALIGN: left">第  
         <asp:Label ID="lbPageNumber" runat="server" Text="0"></asp:Label>
&nbsp;页 共 
         <asp:Label ID="lbPageCount" runat="server" Text="0"></asp:Label>
&nbsp;页> <asp:Button class="anniu" 
             style="BORDER-RIGHT: seagreen 1px solid; BORDER-TOP: seagreen 1px solid; FONT-WEIGHT: normal; FONT-SIZE: 12px; BORDER-LEFT: seagreen 1px solid; WIDTH: 57px; COLOR: black; BORDER-BOTTOM: seagreen 1px solid; HEIGHT: 16px; BACKGROUND-COLOR: #c0ffc0" 
             Text="上一页" runat="server" ID="btnPre" onclick="btnPre_Click" /> 
<asp:Button class="anniu"  
             style="border: 1px solid seagreen; FONT-WEIGHT: normal; FONT-SIZE: 12px; WIDTH: 57px; COLOR: black; BACKGROUND-COLOR: #c0ffc0"   
             Text="下一页" runat="server" ID="btnNext" onclick="btnNext_Click"  /> 
            &nbsp;&nbsp;
         <asp:TextBox ID="txtGoPage" runat="server" Width="52px"></asp:TextBox>
         <asp:Button ID="Button1" runat="server" CssClass="anniu" 
             onclick="Button1_Click" Text="跳转" />
&nbsp;&nbsp;
         <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
            </DIV>
</asp:Content>
