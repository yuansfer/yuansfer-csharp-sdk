using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.mobile
{
    [Serializable]
    public class MobilePrepayResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
