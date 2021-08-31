using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.response.offline
{
    [DataContract]
    public class InstoreAddResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
