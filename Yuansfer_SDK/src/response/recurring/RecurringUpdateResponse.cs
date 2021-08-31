using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.recurring
{
    [DataContract]
    public class RecurringUpdateResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
