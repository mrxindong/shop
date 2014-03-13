<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="BookShop.Web.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script src="js/jquery-1.4.2.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function() {
        $(".m_r").css("width", "710px");
        $(".m_r").css("float", "none");
        Calculate();
    });


    function changeBar(operator, bookId,pk) {
        // alert(operator + "   " + bookId);
        //alert(pk);
        
        
       //得到用户改变书相对应的网页上的书的数量
        var bookCount = $("#txtCount" + bookId).val();
        //alert(bookCount);

        if (operator == "+") {
            //用户点的+号
            if (bookCount >= 999) {
                alert("购买数量不能超过999");
            }
            else {
                bookCount++;
                //$("#txtCount" + bookId).val(bookCount);                
            }
        }
        else {
            //用户点的-号
            if (bookCount <= 1) {
                alert("购买数量不能小于1,如不购买请删除此项");
            }
            else {
                bookCount--;
             //   $("#txtCount" + bookId).val(bookCount);                   
            }
        }

        //调用一般处理程序,把数量更新到数据库
        $.post("/ashx/CartProcess.ashx", { "action": "change", "id": pk, "count": bookCount }, function(data) {
            if (data.length >= 2 && data.substr(0, 2) == "no") {
                //更新图书时出错!
                alert("更新出错,错误原因:"+data.substr(2, data.length - 2));
            }
            else {
                //更新图书成功
                $("#txtCount" + bookId).val(data);
                Calculate();
            }

        }
        , "text");

    }


    //当用户直接修改图书数量时,光标离开时的事件.
    function changeTextOnBlur(pk, txtTextBox) {
        var bookCount = $(txtTextBox).val();
        var reg = /^\d{1,3}$/;
        if (reg.test(bookCount)) {
            //确实是1-3位数字,我们还要考试到范围
            if (bookCount >= 1 && bookCount <= 999) {
                //把用户修改的数量更新到数据库   为了复用,这里可以写一个方法
                //调用一般处理程序,把数量更新到数据库
                $.post("/ashx/CartProcess.ashx", { "action": "change", "id": pk, "count": bookCount }, function(data) {
                    if (data.length >= 2 && data.substr(0, 2) == "no") {
                        //更新图书时出错!
                        alert("更新出错,错误原因:" + data.substr(2, data.length - 2));
                    }
                    else {
                        //更新图书成功
                        $("#txtCount" + bookId).val(data);
                    }

                }
        , "text");
               
            }
            else {
                alert("输入的图书数量必须在1-999之间!");
                //还原数据
                $(txtTextBox).val(focusBookCount);
                
            }
        }
        else {
            //输入的图书数量有误
            alert("输入的图书数量必须为数字!");
            //还原数据
            $(txtTextBox).val(focusBookCount);
        }

        Calculate();

    }

    var focusBookCount = 0;
    //当数量文本框获得焦点时,我们先把初始数据保存起来.如果用户修改的数量不合法,则用这里保存的数据恢复
    function changeTxtOnFocus(txtTextBox) {
        focusBookCount = $(txtTextBox).val();
    }

    function removeProductOnShoppingCart(bookId, control) {

        if (confirm("你确定要删除吗?")) {

            $.post("/ashx/CartProcess.ashx", { "action": "delete", "bookid": bookId }, function(data) {
                if (data.length >= 2 && data.substr(0, 2) == "no") {
                    //删除图书时出错!
                    alert("更新出错,错误原因:" + data.substr(2, data.length - 2));
                }
                else {
                    //删除成功,把界面上的这一行也移除掉
                    $(control).parent().parent().remove();
                    Calculate();

                }

            }, "text");
        }
    }


    function Calculate() {
        var totalMoney = 0;
        $(".align_Center:gt(0)").each(function() {
            var unitPrice = $(this).find(".price").text();
            var count = $(this).find("input").val();
            totalMoney = totalMoney+ (unitPrice*count);

        });

        $("#totalMoney").text(totalMoney);
        
        
    }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0"  width="98%">
        <tr>
            <td colspan="2">
                <img height="27" 
                    src="images/shop-cart-header-blue.gif" width="206" /><img alt="" 
                    src="Images/png-0170.png" /><asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/myorder.aspx">我的订单</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" width="98%">
          
                <table  cellpadding='0' cellspacing='0' width='100%' >
 <tr class='align_Center Thead'>
    <td width='7%' style='height:30px'>图片</td>
    <td>图书名称</td>
    <td width='14%'>单价</td>
    <td width='11%'>购买数量</td>
    <td width='7%'>删除图书</td>
 </tr>

<asp:Repeater ID="rptCart" runat="server">
  <ItemTemplate>
         
<!--一行数据的开始 -->
<tr class='align_Center'>
   <td style='padding:5px 0 5px 0;'> <a href='<%#Eval("Book.Id","/book.aspx?id={0}") %>'><img src='<%#Eval("Book.ISBN","/images/bookcovers/{0}.jpg") %>' width="40" height="50" border="0" /></a></td>
   <td class='align_Left'><%#Eval("Book.Title") %></td>
   <td>
<span class='price'><%#Eval("Book.UnitPrice","{0:0.00}") %></span>
</td>
   <td><a href='#none' title='减一' onclick="changeBar('-','<%#Eval("Book.Id") %>',<%#Eval("Id") %>)" style='margin-right:2px;' ><img src="Images/bag_close.gif" width="9" height="9" border='none' style='display:inline' /></a>
     <input type='text' id='<%#Eval("Book.Id","txtCount{0}") %>' name='<%#Eval("Book.Id","txtCount{0}") %>' maxlength='3' style='width:30px' onKeyDown='if(event.keyCode == 13) event.returnValue = false' value='<%#Eval("Count") %>' onfocus='changeTxtOnFocus(this);' onblur="changeTextOnBlur(<%#Eval("Id")%>,this);" />
     <a href='#none' title='加一' onclick="changeBar('+','<%#Eval("Book.Id") %>',<%#Eval("Id") %>)" style='margin-left:2px;' ><img src='/images/bag_open.gif' width="9" height="9" border='none' style='display:inline' /></a>   </td>
   <td>
   <a href='#none' id='btn_del_1000357315' onclick="removeProductOnShoppingCart(<%#Eval("Book.Id")%>,this)" >
       删除</a></td>
</tr>
<!--一行数据的结束 -->
</ItemTemplate>            

</asp:Repeater>

 




 <tr>
    <td class='align_Right Tfoot' colspan='5' style='height:30px'>&nbsp;</td>
 </tr>
</table>
</td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;&nbsp;&nbsp; 商品金额总计：<span ID="totalMoney" class="price"
                   >0</span>元</td>
            <td>
                &nbsp;
               <a href="booklist.aspx"> <img alt="" src="Images/gobuy.jpg" width="103" height="36" border="0" /> </a><a href="OrderConfirm.aspx"><img src="images/balance.gif" 
                     border="0" /></a>
              
            </td>
        </tr>
    </table>
    </div>


</asp:Content>
