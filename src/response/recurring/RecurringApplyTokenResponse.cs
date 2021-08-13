using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

/**
 *  Recurring Payment Apply-Token response 
 **/
namespace Yuansfer_SDK.src.response.recurring
{
    [DataContract]
    public class RecurringApplyTokenResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
