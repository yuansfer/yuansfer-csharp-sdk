using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Transaction refund info class 
 **/ 
namespace Yuansfer_SDK.src.response.dataSearch
{
    public class RefundInfoBody
    {
        public string refundTransactionId { get; set; } //Refund transaction id
        public string refundAmount { get; set; } //Refund USD amount
        public string refundRmbAmount { get; set; } //Refund RMB amount
        public string currency { get; set; } //Refund currency type
        public string settleCurrency { get; set; } //Settle currency type
    }
}
