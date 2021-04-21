using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

/**
 *  Transaction refund info class 
 **/
namespace Yuansfer_SDK.src.response.dataSearch
{
    [DataContract]
    public class RefundInfoBody
    {
        [DataMember]
        public string refundTransactionId { get; set; } //Refund transaction id
        [DataMember]
        public string refundAmount { get; set; } //Refund USD amount
        [DataMember]
        public string refundRmbAmount { get; set; } //Refund RMB amount
        [DataMember]
        public string currency { get; set; } //Refund currency type
        [DataMember]
        public string settleCurrency { get; set; } //Settle currency type
    }
}
