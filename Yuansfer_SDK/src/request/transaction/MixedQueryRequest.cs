using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.transaction;
using Yuansfer_SDK.src.exception;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.transaction
{
    public class MixedQueryRequest : YuanpayRequest<MixedQueryResponse>
    {
        public string recordNo { get; set; } //Mixed QRCode Record Number

        protected override void dataValidate()
        {
            //TransactionNo and Reference validation
            if (string.IsNullOrEmpty(recordNo))
            {
                throw new YuanpayException("record number cannot be null");
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.MIXED_QUERY;
            return url;
        }

        public override MixedQueryResponse convertResponse(string ret)
        {
            MixedQueryResponse response = new MixedQueryResponse();
            JObject json = JObject.Parse(ret);
            if (json.GetValue("result") != null)
            {
                response.result = JObject.Parse(json.GetValue("result").ToString());
            }
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();
            return response;
        }
    }
}
