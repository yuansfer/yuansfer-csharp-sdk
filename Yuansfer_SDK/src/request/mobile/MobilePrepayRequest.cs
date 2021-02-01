using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.mobile;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

/**
 *  Mobile Prepay request 
 **/ 
namespace Yuansfer_SDK.src.request.mobile
{
    public class MobilePrepayRequest : YuanpayRequest<MobilePrepayResponse>
    {
        public string reference { get; set; } //Transaction reference number
        public string amount { get; set; } //Currency amount
        public string currency { get; set; } //Currency type, ex:"USD","CNY"
        public string settleCurrency { get; set; } //SettleCurrency type, ex:"USD","CNY"
        public string vendor { get; set; } //Vendor name, ex:"alipay","wechatpay"
        public string terminal { get; set; } //Terminal, ex:"MINIPROGRAM","APP"
        public string ipnUrl { get; set; } //Async callback url
        public string openid { get; set; } //Wechat openid
        public string description { get; set; } //Transaction description
        public string note { get; set; } //Transaction note
        public int? timeout { get; set; } //Timeout in minutes

        protected override void dataValidate()
        {
            //Amount validation
            ParamValidator.amountValidate("amount", amount);

            //Reference number validation
            if (string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("reference is missing");
            }

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
            if (string.IsNullOrEmpty(settleCurrency))
            {
                throw new YuanpayException("settleCurrency is missing");
            }
            bool settleCurrencyFlag = SettleCurrencyEnums.containValidate(settleCurrency);
            if (!settleCurrencyFlag)
            {
                throw new YuanpayException("data error: settleCurrency");
            }

            //Vendor validation
            if (string.IsNullOrEmpty(vendor))
            {
                throw new YuanpayException("vendor is missing");
            }
            bool vendorFlag = VendorEnums.containValidate(vendor);
            if (!vendorFlag)
            {
                throw new YuanpayException("data error: vendor");
            }

            //Terminal validation
            if (string.IsNullOrEmpty(terminal))
            {
                throw new YuanpayException("terminal is missing");
            }
            bool terminalFlag = TerminalEnums.containValidate(terminal);
            if (!terminalFlag)
            {
                throw new YuanpayException("data error: terminal");
            }
            if(VendorEnums.ALIPAY.Value.Equals(vendor) && !TerminalEnums.APP.Value.Equals(terminal))
            {
                throw new YuanpayException("data error: terminal");
            }

            //Openid validation
            if (VendorEnums.WECHATPAY.Value.Equals(vendor))
            {
                if (TerminalEnums.MINIPROGRAM.Value.Equals(terminal) && string.IsNullOrEmpty(openid))
                {
                    throw new YuanpayException("openid is missing");
                }
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.MOBILE_PREPAY;
            return url;
        }

        public override MobilePrepayResponse convertResponse(string ret)
        {
            MobilePrepayResponse response = new MobilePrepayResponse();
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
