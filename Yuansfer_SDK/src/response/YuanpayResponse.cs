using System;
using System.Collections.Generic;
using System.Text;

namespace Yuansfer_SDK.src.response
{
    [Serializable]
    public abstract class YuanpayResponse
    {
        public const string SUCCESS_MSG = "success";
	    public const string SUCCESS_CODE = "1";
	    public const string FAIL_CODE = "-1";
	    public const string UNKNOW = "0";

        public string retCode { get; set; }
        public string retMsg { get; set; }
    }
}
