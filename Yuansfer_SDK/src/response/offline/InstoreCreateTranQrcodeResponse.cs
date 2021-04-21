using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.offline
{
    [DataContract]
    public class InstoreCreateTranQrcodeResponse : YuanpayResponse
    {
        //public string transactionNo { get; set; } //Order transaction number
        //public string reference { get; set; } //Order transaction reference number
        //public string amount { get; set; } //USD amount
        //public int? timeout { get; set; } //Order transaction timeout time
        //public string deepLink { get; set; } //Payment link
        //public string qrcodeUrl { get; set; } //QR code url
        [DataMember]
        public JObject result { get; set; }
    }
}
