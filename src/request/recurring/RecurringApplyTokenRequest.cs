using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.recurring;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

/**
 *  Recurring Payment Apply-Token request
 **/ 
namespace Yuansfer_SDK.src.request.recurring
{
    public class RecurringApplyTokenRequest : YuanpayRequest<RecurringApplyTokenResponse>
    {
        public string autoDebitNo { get; set; } //The auto-debit record ID
        public string grantType { get; set; } //Grant type

        protected override void dataValidate()
        {
            //AutoDebitNo validation
            if (string.IsNullOrEmpty(autoDebitNo))
            {
                throw new YuanpayException("autoDebitNo is missing");
            }

            //GrantType validation
            if (string.IsNullOrEmpty(grantType))
            {
                throw new YuanpayException("grantType is missing");
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.RECURRING_APPLY_TOKEN;
            return url;
        }

        public override RecurringApplyTokenResponse convertResponse(string ret)
        {
            RecurringApplyTokenResponse response = new RecurringApplyTokenResponse();
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
