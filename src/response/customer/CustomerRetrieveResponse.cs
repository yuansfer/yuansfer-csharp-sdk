using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

/**
 *  Customer retrieve response 
 **/ 
namespace Yuansfer_SDK.src.response.customer
{
    [DataContract]
    public class CustomerRetrieveResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }

    }
}
