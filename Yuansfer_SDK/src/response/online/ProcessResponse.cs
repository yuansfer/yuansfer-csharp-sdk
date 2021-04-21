using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.online
{
    [DataContract]
    public class ProcessResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}