using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.online
{
    [DataContract]
    public class UpdateRecurringResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
