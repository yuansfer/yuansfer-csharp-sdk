using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using System.Text;

/**
 *  RefundBody Response
 **/ 
namespace Yuansfer_SDK.src.response.transaction
{
    [DataContract]
    public class RefundResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
