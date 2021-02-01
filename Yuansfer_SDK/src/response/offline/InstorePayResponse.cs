using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.offline
{
    [Serializable]
    public class InstorePayResponse : YuanpayResponse
    {
        public JObject transaction { get; set; }
    }
}
