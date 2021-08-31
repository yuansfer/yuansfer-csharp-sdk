using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace Yuansfer_SDK.src.response.offline
{
    [DataContract]
    public class GenerateMixedQrcodeResponse : YuanpayResponse
    {
        [DataMember]
        public JObject result { get; set; }
    }
}
