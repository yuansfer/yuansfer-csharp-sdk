using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Transaction reverse response 
 **/ 
namespace Yuansfer_SDK.src.response.dataSearch
{
    [Serializable]
    public class CancelResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
