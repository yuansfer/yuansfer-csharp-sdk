using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.auth
{
    [DataContract]
    public class AuthDetailQueryResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
