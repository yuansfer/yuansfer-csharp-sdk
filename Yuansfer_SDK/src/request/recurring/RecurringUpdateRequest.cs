using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yuansfer_SDK.src.response.recurring;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.recurring
{
    public class RecurringUpdateRequest : YuanpayRequest<RecurringUpdateResponse>
    {
        public int paymentCount { get; set; } 
        public string status { get; set; } 

        //Data validation
        protected override void dataValidate()
        {
            //Validation
            if (string.IsNullOrEmpty(paymentCount.ToString()))
            {
                throw new YuanpayException("paymentCount is missing");
            }

            if (paymentCount <= 0)
            {
                throw new YuanpayException("paymentCount must be greater than 0");
            }

            if (string.IsNullOrEmpty(status))
            {
                throw new YuanpayException("paymentMethod is missing");
            }

        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.RECURRING_UPDATE;
            return url;
        }

        //Handle response data
        public override RecurringUpdateResponse convertResponse(string ret)
        {
            RecurringUpdateResponse response = new RecurringUpdateResponse();
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