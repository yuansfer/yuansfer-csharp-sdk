using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Recurring Payment Apply-Token response 
 **/ 
namespace Yuansfer_SDK.src.response.online
{
    [Serializable]
    public class RecurringApplyTokenResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
