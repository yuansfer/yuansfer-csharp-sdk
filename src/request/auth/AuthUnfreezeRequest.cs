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
    public class AuthUnfreezeRequest : YuanpayRequest<AuthUnfreezeResponse>
    {
        public string authInfoNo { get; set; }
        public string outAuthInfoNo { get; set; }
        public string outAuthDetailNo { get; set; }
        public string unfreezeAmount { get; set; }
        public string authIpnUrl { get; set; }
        public string currency { get; set; }
        public string settleCurrency { get; set; }

        protected override void dataValidate()
        {
            if (string.IsNullOrEmpty(outAuthInfoNo)
                && string.IsNullOrEmpty(authInfoNo))
            {
                throw new YuanpayException("outAuthInfoNo and authInfoNo missing");
            }

            if (!string.IsNullOrEmpty(outAuthDetailNo)
                    && !string.IsNullOrEmpty(authInfoNo))
            {
                throw new YuanpayException("outAuthInfoNo and authInfoNo cannot exist at the same time");
            }


            if (string.IsNullOrEmpty(outAuthDetailNo))
            {
                throw new YuanpayException("outAuthDetailNo missing");
            }

            if (string.IsNullOrEmpty(currency))
            {
                throw new YuanpayException("currency missing");
            }
            if (string.IsNullOrEmpty(settleCurrency))
            {
                throw new YuanpayException("settleCurrency missing");
            }

            ParamValidator.amountValidate("unfreezeAmount", unfreezeAmount);
        }

        protected override string getAPIUrl(string env)
        {
            //Get API url from methods
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.AUTH_UNFREEZE;
            return url;

        }

        public override AuthUnfreezeResponse convertResponse(string ret)
        {
            //Initialize response
            AuthUnfreezeResponse response = new AuthUnfreezeResponse();

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
