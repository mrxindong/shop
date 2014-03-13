<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BookShop.Web.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Css/book_list.css" rel="stylesheet" type="text/css" />
    <link href="/Css/index.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">


<center>

<div class="top">
	<div class="m_c" style="width: 736px; height: 27px">
	<span class="l">
      <a href="http://www.beifabook.com" target="_blank">北发图书网主网站</a> |&nbsp;
      <a href="http://www.bjbb.com" target="_blank">北京图书大厦</a>&nbsp; |
      <a href="http://www.wfjsd.com/" target="_blank"><font color="#00A0E9">王府井书店</font></a>&nbsp;|
      <a href="http://www.zgcbb.com/" target="_blank">中关村图书大厦</a>&nbsp; |
      <a href="http://www.yycbook.com/" target="_blank">亚运村图书大厦</a>&nbsp; |
      <a href="http://www.hs-book.com" target="_blank">花市书店</a>&nbsp; |
	  <a href="http://www.xz-book.com/index.shtml" target="_blank">小庄新华书店</a> |
	  <a href="http://www.cw-book.com/index.shtml" target="_blank">翠微新华书店</a> |   
	  <a href="http://www.gj-book.com/index.shtml" target="_blank">高教书店</a></span></div></div>


	<div style="WIDTH: 750px;"><img src="images/集团网站1.jpg" width="780" height="93" /></div>
<div id="tabsI" style="width: 750px; height: 32px">
                                <ul>
                                        <!-- CSS Tabs -->
<li><a href="/default.aspx"><span>首页</span></a></li>
<li><a href="/booklist.aspx"><span>图书列表</span></a></li>
<li><a href="/cart.aspx"><span>我的购物车</span></a></li>
<li><a href="/membership/login.aspx"><span>登录</span></a></li>
<li><a href="/membership/register.aspx"><span>注册</span></a></li>
<li><a href="/rss.aspx"><span>最新图书订阅</span></a></li>


                                </ul>
  </div>


<div class="main_booklist">


  <dl>
        <dt class="ipt1">请选择排序方式：
          <input class="anniu" id="ctl00_cphContent_btnDate" type="submit" value="出版日期" name="ctl00$cphContent$btnDate" />
          |
          <input class="anniu" id="ctl00_cphContent_btnPrice" type="submit" value="价格" name="ctl00$cphContent$btnPrice" />
         </dt>
        <dt>
        
        
            <ul class="title_ul1">
                <li class="title_booklist0">书名</li>  
       
                <li class="title_booklist2">出版社</li>  
                <li class="title_booklist3">出版日期</li>
                <li class="title_booklist4">价格</li>   
            </ul>
            
            <asp:Repeater ID="Repeater1" runat="server">
           <ItemTemplate>
            
            <ul class="title_ul2">
                <li class="title_booklist0" ><a href='<%#Eval("Id","book.aspx?id={0}") %>'><%#Eval("Title") %></a></li>  
            
                <li class="title_booklist2"><%#Eval("Publisher.Name")%></li>  
                <li class="title_booklist3"><%#Eval("PublishDate","{0:yyyy-MM-dd}") %></li>
                <li class="title_booklist4"><%#Eval("UnitPrice","{0:0.00}") %>元</li>   
            </ul>   
            
            </ItemTemplate>
            
            <AlternatingItemTemplate>
            <ul class="title_ul3">
                <li class="title_booklist0" ><a href='<%#Eval("Id","book.aspx?id={0}") %>'><%#Eval("Title") %></a></li>  
               
                <li class="title_booklist2"><%#Eval("Publisher.Name")%></li>  
                <li class="title_booklist3"><%#Eval("PublishDate","{0:yyyy-MM-dd}") %></li>
                <li class="title_booklist4"><%#Eval("UnitPrice","{0:0.00}") %>元</li>     
            </ul>
            
            </AlternatingItemTemplate>         
            
            
                        </asp:Repeater>
                   
            
   
         
        </dt>
        <dt class="ipt2">第 1 页 共 285 页</span>
        <input class="anniu" id="ctl00_cphContent_btnPrev" disabled="disabled" type="submit" value="上一页" name="ctl00$cphContent$btnPrev" />
        <input class="anniu" id="ctl00_cphContent_btnNext" type="submit" value="下一页" name="ctl00$cphContent$btnNext" />
        </dt>
    </dl>

</div>

<div id="footer">
  <table border="0" width="100%" class="categories1">
    <tr>
      <td align="center">　
        <ul>
            <li><a href='#'>关于我们王府井书店<a href="#">书店营业时间：9：30-21：00 </a> </li>
          <li> <a href="#"; target=_blank; ><img src="images/logo123x40.jpg" width="123" height="40" border="0"></a> <a href="#"; target=_blank; ><img border="0" src="Images/kaixin.jpg"></a> </li>
          <li>&nbsp;<span lang="zh-cn"><a title="京ICP备08001692号" href="http://www.miibeian.gov.cn">京ICP备08987373号</a></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
        </ul></td>
    </tr>
  </table>
</div>
    </form>
</body>
</html>
