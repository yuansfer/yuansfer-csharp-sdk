using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response.payout;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.payout
{
    public class PayoutRetrievePayeeRequest : YuanpayRequest<PayoutRetrievePayeeResponse>
    {
        public string accountType { get; set; } //User account type, possible value: "CARD", "PAYPAL", "BANK_ACCOUNT", "PREPAID_CARD", "ALIPAY"
        public string customerNo { get; set; } //
        public string accountTag { get; set; }
        public string timestamp { get; set; }

        //Data validation
        protected override void dataValidate()
        {
            if (string.IsNullOrEmpty(accountType))
            {
                throw new YuanpayException("accountType is missing");
            }

            if (string.IsNullOrEmpty(customerNo))
            {
                throw new YuanpayException("customerNo is missing");
            }

            if (string.IsNullOrEmpty(accountTag))
            {
                throw new YuanpayException("accountTag is missing");
            }



        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.PAYOUT_RETRIEVE;
            return url;
        }

        //Handle response data
        public override PayoutRetrievePayeeResponse convertResponse(string ret)
        {
            PayoutRetrievePayeeResponse response = new PayoutRetrievePayeeResponse();
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
