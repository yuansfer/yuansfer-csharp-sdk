using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

/**
 *  Recurring Payment Authorization response 
 **/ 
namespace Yuansfer_SDK.src.response.online
{
    [Serializable]
    public class RecurringConsultResponse : YuanpayResponse
    {
        public JObject result { get; set; }
    }
}
