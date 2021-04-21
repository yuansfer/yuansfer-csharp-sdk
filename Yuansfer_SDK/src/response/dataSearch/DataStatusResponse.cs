using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

/**
 *  Settlement Status of date response
 **/
namespace Yuansfer_SDK.src.response.dataSearch
{
    [DataContract]
    public class DataStatusResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
