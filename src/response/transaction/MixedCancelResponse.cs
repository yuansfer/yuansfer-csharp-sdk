using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

/**
 *  Mixed Qrc Transaction Cancel response 
 **/
namespace Yuansfer_SDK.src.response.transaction
{
    [DataContract]
    public class MixedCancelResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
