using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Recurring Payment Deduction response 
 **/ 
namespace Yuansfer_SDK.src.response.online
{
    [DataContract]
    public class RecurringPayResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
