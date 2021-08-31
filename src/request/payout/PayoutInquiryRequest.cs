using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response.payout;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.payout
{
    public class PayoutInquiryRequest : YuanpayRequest<PayoutInquiryResponse>
    {
        public string invoiceId { get; set; } 

        //Data validation
        protected override void dataValidate()
        {

            //Reference validation
            if (string.IsNullOrEmpty(invoiceId))
            {
                throw new YuanpayException("invoiceId is missing");
            }

        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.PAYOUT_INQUIRY;
            return url;
        }

        //Handle response data
        public override PayoutInquiryResponse convertResponse(string ret)
        {
            PayoutInquiryResponse response = new PayoutInquiryResponse();
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
