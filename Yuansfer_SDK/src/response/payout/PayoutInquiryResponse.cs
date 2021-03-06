﻿using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

/**
 *  Payout send payment response 
 **/ 
namespace Yuansfer_SDK.src.response.payout
{
    [DataContract]
    public class PayoutInquiryResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
