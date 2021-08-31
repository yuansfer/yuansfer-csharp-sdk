﻿using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

/**
 *  Payout create account response 
 **/ 
namespace Yuansfer_SDK.src.response.payout
{
    [DataContract]
    public class PayoutCreatePayeeResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
