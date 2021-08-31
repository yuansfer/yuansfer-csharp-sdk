using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response.payout;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.payout
{
    public class PayoutBalanceRequest : YuanpayRequest<PayoutBalanceResponse>
    {
        public string timestamp { get; set; }
        public string currency { get; set; }
        //Data validation
        protected override void dataValidate()
        {
            //Reference validation
            if (string.IsNullOrEmpty(timestamp))
            {
                throw new YuanpayException("timestamp is missing");
            }

            //Currency validation
            if (string.IsNullOrEmpty(currency))
            {
                throw new YuanpayException("currency is missing");
            }
        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.PAYOUT_BALANCE;
            return url;
        }

        //Handle response data
        public override PayoutBalanceResponse convertResponse(string ret)
        {
            PayoutBalanceResponse response = new PayoutBalanceResponse();
            JObject json = JObject.Parse(ret);
            if (json.GetValue("balance") != null)
            {
                response.result = JObject.Parse(json.GetValue("balance").ToString());
            }
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();
            return response;
        }
    }
}
