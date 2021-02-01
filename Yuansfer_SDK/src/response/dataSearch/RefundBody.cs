using System;
using System.Collections.Generic;
using System.Text;

/**
 *  RefundBody Class
 **/ 
namespace Yuansfer_SDK.src.response.dataSearch
{
    public class RefundBody
    {
        public string amount { get; set; } //Order USD amount
        public string rmbAmount { get; set; } //Order RMB amount
        public string refundAmount { get; set; } //Order refund USD amount
        public string refundRmbAmount { get; set; } //Order refund USD amount
        public string currency { get; set; } //Order currency type
        public string settleCurrency { get; set; } //Order settle currency amount, currenly only support USD
        public string exchangeRate { get; set; } //Order currency exchange rate
        public string status { get; set; } //Order status
        public string reference { get; set; } //Order reference number
        public string refundTransactionId { get; set; } //Order refund transaction id
        public string oldTransactionId { get; set; } //Old transaction id
    }
}
