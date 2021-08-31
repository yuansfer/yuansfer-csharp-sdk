using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.mobile;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

/**
 *  Express Pay request 
 **/ 
namespace Yuansfer_SDK.src.request.mobile
{
    public class ExpressPayRequest : YuanpayRequest<MobileExpressPayResponse>
    {
        public string reference { get; set; } //Transaction reference number
        public string amount { get; set; } //Currency amount
        public string currency { get; set; } //Currency type, ex:"USD","CNY"
        public string settleCurrency { get; set; } //SettleCurrency type, ex:"USD","CNY"
        public string cardNumber { get; set; }
        public string cardExpYear { get; set; }
        public string cardExpMonth { get; set; }
        public string cardCvv { get; set; }
        public string clientIp { get; set; }

        protected override void dataValidate()
        {
            //Validation
            if (string.IsNullOrEmpty(cardNumber))
            {
                throw new YuanpayException("cardNumber missing");
            }
            if (string.IsNullOrEmpty(cardExpYear))
            {
                throw new YuanpayException("cardExpYear missing");
            }
            if (string.IsNullOrEmpty(cardExpMonth))
            {
                throw new YuanpayException("cardExpMonth missing");
            }
            if (string.IsNullOrEmpty(cardCvv))
            {
                throw new YuanpayException("cardCvv missing");
            }

            ParamValidator.numberValidate("cardNumber", cardNumber);
            ParamValidator.numberValidate("cardExpYear", cardExpYear);
            ParamValidator.numberValidate("cardExpMonth", cardExpMonth);
            ParamValidator.numberValidate("cardCvv", cardCvv);

            ParamValidator.amountValidate("amount", amount);

            if (string.IsNullOrEmpty(currency))
            {
                throw new YuanpayException("currency missing.");
            }
            if (string.IsNullOrEmpty(settleCurrency))
            {
                throw new YuanpayException("settleCurrency missing");
            }
            if (string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("reference missing");
            }
            if (string.IsNullOrEmpty(clientIp))
            {
                throw new YuanpayException("clientIp missing");
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.EXPRESS_PAY;
            return url;
        }

        public override MobileExpressPayResponse convertResponse(string ret)
        {
            MobileExpressPayResponse response = new MobileExpressPayResponse();
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
