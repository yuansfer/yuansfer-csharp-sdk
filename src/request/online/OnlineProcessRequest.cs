using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yuansfer_SDK.src.response.online;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.online
{
    public class OnlineProcessRequest : YuanpayRequest<OnlineProcessResponse>
    {
        public string paymentMethodNonce { get; set; } 
        public string paymentMethod { get; set; } 
        public string transactionNo { get; set; } 
        public string deviceData { get; set; }


        //Data validation
        protected override void dataValidate()
        {
            //paymentMethodNonce validation
            if (string.IsNullOrEmpty(paymentMethodNonce))
            {
                throw new YuanpayException("paymentMethodNonce is missing");
            }

            //paymentMethod validation
            if (string.IsNullOrEmpty(paymentMethod))
            {
                throw new YuanpayException("paymentMethod is missing");
            }

            //transactionNo validation
            if (string.IsNullOrEmpty(transactionNo))
            {
                throw new YuanpayException("transactionNo is missing");
            }
        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.ONLINE_PROCESS;
            return url;
        }

        //Handle response data
        public override OnlineProcessResponse convertResponse(string ret)
        {
            OnlineProcessResponse response = new OnlineProcessResponse();
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