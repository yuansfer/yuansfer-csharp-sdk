using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Online Securepay response 
 **/ 
namespace Yuansfer_SDK.src.response.online
{
    [Serializable]
    public class OnlineSecurepayResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
