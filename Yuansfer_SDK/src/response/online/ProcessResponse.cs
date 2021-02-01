using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.online
{
   
    public class ProcessResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}