using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

/**
 *  RefundBody Response
 **/ 
namespace Yuansfer_SDK.src.response.dataSearch
{
    [DataContract]
    public class RefundResponse : YuanpayResponse
    {
        [DataMember]
        public RefundBody result { get; set; }
    }
}
