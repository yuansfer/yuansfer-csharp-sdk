using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Transaction Query response 
 **/ 
namespace Yuansfer_SDK.src.response.dataSearch
{
    [Serializable]
    public class TranQueryResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
