using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Withdrawal List response 
 **/ 
namespace Yuansfer_SDK.src.response.dataSearch
{
    [Serializable]
    public class WithdrawalListResponse : YuanpayResponse
    {
        //public JArray withdrawals { get; set; } //Withdrawals list
        //public int? size { get; set; } //Data size
        public JObject result { get; set; } 
    }
}
