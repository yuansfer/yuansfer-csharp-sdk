using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

/**
 *  Customer create account response 
 **/ 
namespace Yuansfer_SDK.src.response.customer
{
    [DataContract]
    public class RetrieveAccountResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }

    }
}
