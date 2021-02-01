using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Settlement Status of date response
 **/ 
namespace Yuansfer_SDK.src.response.dataSearch
{
    [Serializable]
    public class DataStatusResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
