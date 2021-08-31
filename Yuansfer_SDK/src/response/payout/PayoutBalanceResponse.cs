using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

/**
 *  Payout get balance response 
 **/ 
namespace Yuansfer_SDK.src.response.payout
{
    [DataContract]
    public class PayoutBalanceResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
