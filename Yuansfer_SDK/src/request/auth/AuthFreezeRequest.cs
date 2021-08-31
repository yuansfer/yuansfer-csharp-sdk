using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

using Yuansfer_SDK.src.response.auth;
using Yuansfer_SDK.src.exception;

/**
 *  Auth Capture Request
 **/ 
namespace Yuansfer_SDK.src.request.auth
{
    public class AuthFreezeRequest : YuanpayRequest<AuthFreezeResponse>
    {

        public string amount { get; set; }
        public string vendor { get; set; }
        public string outAuthInfoNo { get; set; }
        public string outAuthDetailNo { get; set; }
        public string currency { get; set; }
        public string settleCurrency { get; set; }
        public string authIpnUrl { get; set; }
        public string note { get; set; }
        public string paymentBarcode { get; set; }

        protected override void dataValidate()
        {
            //Validate if infos are missing
            if (string.IsNullOrEmpty(outAuthInfoNo))
            {
                throw new YuanpayException("outAuthInfoNo missing");
            }
            if (string.IsNullOrEmpty(outAuthDetailNo))
            {
                throw new YuanpayException("outAuthDetailNo missing");
            }
            if (string.IsNullOrEmpty(vendor))
            {
                throw new YuanpayException("vendor missing");
            }
            //币种校验
            if (string.IsNullOrEmpty(currency))
            {
                throw new YuanpayException("currency missing.");
            }
            if (string.IsNullOrEmpty(settleCurrency))
            {
                throw new YuanpayException("settleCurrency missing");
            }
            ParamValidator.amountValidate("amount", amount);
        }

        protected override string getAPIUrl(string env)
        {
            //Get API url from methods
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.AUTH_FREEAE;
            return url;

        }

        public override AuthFreezeResponse convertResponse(string ret)
        {
            //Initialize response
            AuthFreezeResponse response = new AuthFreezeResponse();

            //Create json object
            JObject json = JObject.Parse(ret);
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();

            if (json.GetValue("result") != null)
            {
                response.result = JObject.Parse(json.GetValue("result").ToString());
            }
            return response;
        }
    }
}
