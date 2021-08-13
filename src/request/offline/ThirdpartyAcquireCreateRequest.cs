using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.offline;
using Yuansfer_SDK.src.enums;
using Yuansfer_SDK.src.exception;
using Newtonsoft.Json.Linq;

/**
 *  Third party create acquire transaction request 
 **/ 
namespace Yuansfer_SDK.src.request.offline
{
    public class ThirdPartyAcquireCreateRequest : YuanpayRequest<ThirdPartyAcquireCreateResponse>
    {
        public string amount { get; set; } //Transaction amount
        public string currency { get; set; } //Currency type, ex:"USD","CNY"
        public string settleCurrency { get; set; } //SettleCurrency type, ex:"USD","CNY"
        public string reference { get; set; } //Transaction reference number

        protected override void dataValidate()
        {
            //Amount validation
            ParamValidator.amountValidate("amount", amount);

            //Currency validation
            if (string.IsNullOrEmpty(currency))
            {
                throw new YuanpayException("currency is missing");
            }

            //Settlement Currency validation
            if (string.IsNullOrEmpty(settleCurrency))
            {
                throw new YuanpayException("settleCurrency is missing");
            }

            //Reference validation
            if (string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("reference is missing");
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.THIRDPART_ACQUIRE_CREATE;
            return url;
        }

        public override ThirdPartyAcquireCreateResponse convertResponse(string ret)
        {
            ThirdPartyAcquireCreateResponse response = new ThirdPartyAcquireCreateResponse();
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
