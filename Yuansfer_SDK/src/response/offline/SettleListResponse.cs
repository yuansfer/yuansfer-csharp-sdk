using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Yuansfer_SDK.src.response.offline
{
    [DataContract]
    public class SettleListResponse : YuanpayResponse
    {
        [DataMember]
        public JArray settlements { get; set; } //Settlements List
        public int? size { get; set; } //Settlement List size
    }
}
