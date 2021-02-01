using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Transaction List response 
 **/ 
namespace Yuansfer_SDK.src.response.dataSearch
{
    [Serializable]
    public class TransListResponse : YuanpayResponse
    {
        //public JArray transactions { get; set; } //Transaction list
        //public int? size { get; set; } //Size of transaction
        public JObject result { get; set; }
    }
}
