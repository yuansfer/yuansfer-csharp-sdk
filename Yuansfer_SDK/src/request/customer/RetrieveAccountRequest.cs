using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;
using Yuansfer_SDK.src.response.customer;

namespace Yuansfer_SDK.src.request.customer
{
    public class RetrieveAccountRequest : YuanpayRequest<RetrieveAccountResponse>
    {
        public string customerCode { get; set; } //Customer code
        public string timestamp { get; set; }
        public string customerNo { get; set; }

        //Data validation
        protected override void dataValidate()
        {
            if (string.IsNullOrEmpty(timestamp))
            {
                throw new YuanpayException("timestamp is missing");
            }

            if (string.IsNullOrEmpty(customerCode)
                && string.IsNullOrEmpty(customerNo))
            {
                throw new YuanpayException("customerCode and customerNo missing");
            }

            if (!string.IsNullOrEmpty(customerCode)
                    && !string.IsNullOrEmpty(customerNo))
            {
                throw new YuanpayException("customerCode and customerNo cannot exist at the same time");
            }


        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.CUSTOMER_RETRIEVE_ACCOUNT;
            return url;
        }

        //Handle response data
        public override RetrieveAccountResponse convertResponse(string ret)
        {
            RetrieveAccountResponse response = new RetrieveAccountResponse();
            JObject json = JObject.Parse(ret);
            if (json.GetValue("customer") != null)
            {
                response.result = JObject.Parse(json.GetValue("customer").ToString());
            }
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();
            return response;
        }
    }
}
