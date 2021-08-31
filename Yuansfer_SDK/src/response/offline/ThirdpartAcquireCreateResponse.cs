using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.offline
{
    [DataContract]
    public class ThirdPartyAcquireCreateResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; } 
    }
}
