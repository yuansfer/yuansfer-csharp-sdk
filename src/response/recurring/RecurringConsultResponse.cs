using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Recurring Payment Authorization response 
 **/ 
namespace Yuansfer_SDK.src.response.recurring
{
    [DataContract]
    public class RecurringConsultResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
