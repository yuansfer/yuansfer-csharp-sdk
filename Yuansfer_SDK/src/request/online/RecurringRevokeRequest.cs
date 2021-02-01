using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.online;
using Yuansfer_SDK.src.exception;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.online
{
    public class RecurringRevokeRequest : YuanpayRequest<RecurringRevokeResponse>
    {
        public string autoDebitNo { get; set; } //Recurring payment record id

        protected override void dataValidate()
        {
            //AutoDebitNo validation
            if (string.IsNullOrEmpty(autoDebitNo))
            {
                throw new YuanpayException("autoDebitNo is missing");
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.RECURRING_REVOKE;
            return url;
        }

        public override RecurringRevokeResponse convertResponse(string ret)
        {
            RecurringRevokeResponse response = new RecurringRevokeResponse();
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
