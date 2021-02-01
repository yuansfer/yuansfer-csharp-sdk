using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.offline
{
    [Serializable]
    public class ThirdpartAcquireCreateResponse : YuanpayResponse
    {
        public JObject result { get; set; } 
    }
}
