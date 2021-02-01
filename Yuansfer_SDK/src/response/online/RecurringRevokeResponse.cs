using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Recurring Payment Revoke Authorization response 
 **/ 
namespace Yuansfer_SDK.src.response.online
{
    [Serializable]
    public class RecurringRevokeResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
