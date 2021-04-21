using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Yuansfer_SDK.src.response
{
    [DataContract]
    public abstract class YuanpayResponse
    {
        public const string SUCCESS_MSG = "success";
	    public const string SUCCESS_CODE = "1";
	    public const string FAIL_CODE = "-1";
	    public const string UNKNOW = "0";

        [DataMember]
        public string retCode { get; set; }
        [DataMember]
        public string retMsg { get; set; }
    }
}
