using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.auth
{
    [Serializable]
    public class AuthFreezeResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
