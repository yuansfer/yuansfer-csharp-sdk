using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.offline
{
    [Serializable]
    public class SettleListResponse : YuanpayResponse
    {
        public JArray settlements { get; set; } //Settlements List
        public int? size { get; set; } //Settlement List size
    }
}
