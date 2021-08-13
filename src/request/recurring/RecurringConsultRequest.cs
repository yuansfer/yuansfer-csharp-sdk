using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.recurring;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

/**
 *  Recurring Payment Authorization request
 **/ 
namespace Yuansfer_SDK.src.request.recurring
{
    public class RecurringConsultRequest : YuanpayRequest<RecurringConsultResponse>
    {
        public string osType { get; set; } //Operating system, ex:"IOS","ANDROID"
        public string osVersion { get; set; } //Opeating system version
        public string autoIpnUrl { get; set; } //Asynchronous callback address
        public string autoRedirectUrl { get; set; } //Synchronize the callback address
        public string autoReference { get; set; } //Recurring payment reference number
        public string terminal { get; set; } //Terminal, ex:"ONLINE","WAP"
        public string vendor { get; set; } //

        protected override void dataValidate()
        {
            //Terminal 
            if (string.IsNullOrEmpty(terminal))
            {
                throw new YuanpayException("terminal is missing");
            }

            //AutoRedirectUrl validation
            if (string.IsNullOrEmpty(autoRedirectUrl))
            {
                throw new YuanpayException("autoRedirectUrl is missing");
            }

            //AutoReference validation
            if (string.IsNullOrEmpty(autoReference))
            {
                throw new YuanpayException("autoReference is missing");
            }

            //CustomerBelongsTo validation
            if (string.IsNullOrEmpty(vendor))
            {
                throw new YuanpayException("vendor is missing");
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.RECURRING_CONSULT;
            return url;
        }

        public override RecurringConsultResponse convertResponse(string ret)
        {
            RecurringConsultResponse response = new RecurringConsultResponse();
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
