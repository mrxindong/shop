using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Web.Common;

namespace BookShop.Web.PayGate
{
    public class AlipayClass
    {
        string partner;

        public string Partner
        {
            get { return partner; }
            set { partner = value; }
        }
        string return_url;

        public string Return_url
        {
            get { return return_url; }
            set { return_url = value; }
        }
        string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        string body;

        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        string out_trade_no;

        public string Out_trade_no
        {
            get { return out_trade_no; }
            set { out_trade_no = value; }
        }
        decimal total_fee;

        public decimal Total_fee
        {
            get { return total_fee; }
            set { total_fee = value; }
        }
        string seller_email;

        public string Seller_email
        {
            get { return seller_email; }
            set { seller_email = value; }
        }
        string sign;

        public string Sign
        {
            get { return sign; }
            set { sign = value; }
        }

    

        /// <summary>
        ///     //构造方法,初值化字段
        /// </summary>
        /// <param name="subject">商品名称</param>
        /// <param name="description">描述</param>
        /// <param name="orderNumber">定单号</param>
        /// <param name="totalMoney">需支付的金额</param>
        public AlipayClass(string subject,string description,string orderNumber,decimal totalMoney)
        {

            this.partner = CommonCode.GetAppSettings("partner");
            this.return_url = CommonCode.GetAppSettings("return_url");
            this.seller_email = CommonCode.GetAppSettings("seller_email");

            this.subject = subject;
            this.body = description;
            this.out_trade_no = orderNumber;
            this.total_fee = totalMoney;

        }

        /// <summary>
        /// 用于计算签名
        /// </summary>
        /// <returns></returns>
        public string GetSign()
        {
            string key = CommonCode.GetAppSettings("paykey");
            //为按顺序连接 总金额、 商户编号、订单号、商品名称、商户密钥的MD5值。(小写值)
            string str = this.total_fee.ToString("0.00")+this.partner+this.out_trade_no+this.subject+
                key;
            this.sign= CommonCode.Md5Compte(str).ToLower();
            return this.sign;
        }

        public string GetPayUrl()
        {

//            partner：商户编号    1
//return_url：回调商户地址（通过商户网站的哪个页面来通知支付成功！）1
//subject：商品名称
//body：商品描述
//out_trade_no：订单号！！！(由商户网站生成，支付宝不确保正确性，只负责转发。)
//total_fee：总金额
//seller_email：卖家邮箱1
//sign：数字签名。为按顺序连接 总金额、 商户编号、订单号、商品名称、商户密钥的MD5值。(小

//写值)
//支付时,请将上述参数以get形式传给接入地址.
            string payUrl = CommonCode.GetAppSettings("payurl");
            string url = string.Format(payUrl + "?partner={0}&return_url={1}&subject={2}&body={3}&out_trade_no={4}"+
                "&total_fee={5}&seller_email={6}&sign={7}",
                this.partner,HttpUtility.UrlEncode(this.return_url),
                HttpUtility.UrlEncode(this.subject),HttpUtility.UrlEncode(this.body),
                this.out_trade_no,this.total_fee.ToString("0.00"),this.seller_email,GetSign());
            return url;
        }


    }
}
