<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RSS.aspx.cs" Inherits="BookShop.Web.RSS" ContentType="text/xml" %>

<rss version="2.0">
<channel>
<title>我的网上书店</title>
<description>卖盗版书的打2折</description>
<link>http://www.bookshop.com/rss.aspx</link>
<language>zh-cn</language>
<docs></docs>
<generator>www.bookshop.com</generator>

    <asp:Repeater ID="Repeater1" runat="server">
     <ItemTemplate>
     
     
    <item>
        <title><![CDATA[<%#Eval("Title") %>]]></title>
        <link><![CDATA[<%#Eval("id","http://localhost:1804/book.aspx?id={0}") %>]]></link>
        <pubDate><![CDATA[<%#Eval("publishdate","{0:yyyy-MM-dd}")%>]]></pubDate>
        <author><![CDATA[<%#Eval("Author") %>]]></author>
        <description><![CDATA[<%#Eval("ContentDescription") %>]]></description>
    </item>
    
    
    
    </ItemTemplate>
    </asp:Repeater>
</channel>
</rss>



