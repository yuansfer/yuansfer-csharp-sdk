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
    public class AuthVoucherCreateRequest : YuanpayRequest<AuthVoucherCreateResponse>
    {
        public string outAuthInfoNo { get; set; }
        public string outAuthDetailNo { get; set; }
        public string amount { get; set; }
        public string vendor { get; set; }
        public string currency { get; set; }
        public string settleCurrency { get; set; }

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
            ParamValidator.amountValidate("amount", amount);
        }

        protected override string getAPIUrl(string env)
        {
            //Get API url from methods
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.AUTH_VOUCHER_CREATE;
            return url;

        }

        public override AuthVoucherCreateResponse convertResponse(string ret)
        {
            //Initialize response
            AuthVoucherCreateResponse response = new AuthVoucherCreateResponse();

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
