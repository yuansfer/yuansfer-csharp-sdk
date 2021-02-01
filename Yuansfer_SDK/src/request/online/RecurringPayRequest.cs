using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.online;
using Yuansfer_SDK.src.enums;
using Yuansfer_SDK.src.exception;
using Newtonsoft.Json.Linq;

/**
 *  Recurring Payment Deduction request 
 **/ 
namespace Yuansfer_SDK.src.request.online
{
    public class RecurringPayRequest : YuanpayRequest<RecurringPayResponse>
    {
        public string autoDebitNo { get; set; } //Recurring payment record id
        public string amount { get; set; } //Price amount
        public string currency { get; set; } //Currency type
        public string settleCurrency { get; set; } //Settle Currency type
        public string reference { get; set; } //Transaction reference number
        public string ipnUrl { get; set; } //Asynchronous callback address

        protected override void dataValidate()
        {
            //AutoDebitNo validation
            if (string.IsNullOrEmpty(autoDebitNo))
            {
                throw new YuanpayException("autoDebitNo is missing");
            }

            //Amount validation
            ParamValidator.amountValidate("amount",amount);

            //Currency validation
            if (string.IsNullOrEmpty(currency))
            {
                throw new YuanpayException("currency is missing");
            }
            bool currencyFlag = CurrencyEnums.containValidate(currency);
            if (!currencyFlag)
            {
                throw new YuanpayException("data error: currency");
            }

            //Settlement Currency validation
            if (string.IsNullOrEmpty(settleCurrency))
            {
                throw new YuanpayException("currency is missing");
            }
            bool settleCurrencyFlag = SettleCurrencyEnums.containValidate(settleCurrency);
            if (!settleCurrencyFlag)
            {
                throw new YuanpayException("data error: settleCurrency");
            }

            //Reference validation
            if (string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("reference is missing");
            }

            //IpnUrl validation
            if (string.IsNullOrEmpty(ipnUrl))
            {
                throw new YuanpayException("ipnUrl is missing");
            }

        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.RECURRING_PAY;
            return url;
        }

        public override RecurringPayResponse convertResponse(string ret)
        {
            RecurringPayResponse response = new RecurringPayResponse();
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
