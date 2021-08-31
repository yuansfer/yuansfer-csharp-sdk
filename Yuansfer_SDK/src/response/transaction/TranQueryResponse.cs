using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

/**
 *  Transaction Query response 
 **/
namespace Yuansfer_SDK.src.response.transaction
{
    [DataContract]
    public class TranQueryResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
