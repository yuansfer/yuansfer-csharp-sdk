using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Yuansfer_SDK.src.response.auth
{
    [DataContract]
    public class AuthUnfreezeResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
