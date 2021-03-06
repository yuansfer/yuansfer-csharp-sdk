﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

/**
 *  Transaction reverse response 
 **/
namespace Yuansfer_SDK.src.response.dataSearch
{
    [DataContract]
    public class ReverseResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
