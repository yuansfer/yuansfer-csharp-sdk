using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Online Securepay response 
 **/ 
namespace Yuansfer_SDK.src.response.online
{
    [DataContract]
    public class OnlineSecurepayResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
