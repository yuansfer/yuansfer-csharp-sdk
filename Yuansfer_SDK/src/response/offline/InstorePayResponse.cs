using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.offline
{
    [DataContract]
    public class InstorePayResponse : YuanpayResponse
    {
        [DataMember]
        public JObject transaction { get; set; }
    }
}
