using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Recurring Payment Revoke Authorization response 
 **/ 
namespace Yuansfer_SDK.src.response.recurring
{
    [DataContract]
    public class RecurringRevokeResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
