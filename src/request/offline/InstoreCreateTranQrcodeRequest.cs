﻿using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.offline;
using Yuansfer_SDK.src.enums;
using Yuansfer_SDK.src.exception;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.offline
{
    public class InstoreCreateTranQrcodeRequest : YuanpayRequest<InstoreCreateTranQrcodeResponse>
    {
        public string amount { get; set; } //Transaction amount
        public string currency { get; set; } //Currency type, ex:"USD","CNY"
        public string settleCurrency { get; set; } //SettleCurrency type, ex:"USD","CNY"
        public string vendor { get; set; } //Transaction amount
        public string reference { get; set; } //Transaction amount
        public string ipnUrl { get; set; } //Transaction amount
        public string needQrcode { get; set; } //Whether to generate qr code, default true, ex:"true","false",
        public int? timeout { get; set; } //Timeout in minutes

        protected override void dataValidate()
        {
            //Amount validation
            ParamValidator.amountValidate("amount", amount);

            //Reference validation
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
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.INSTORE_TRAN_QRCODE;
            return url;
        }

        public override InstoreCreateTranQrcodeResponse convertResponse(string ret)
        {
            InstoreCreateTranQrcodeResponse response = new InstoreCreateTranQrcodeResponse();
            JObject json = JObject.Parse(ret);
            if (json.GetValue("ret_code") != null)
            {
                response.retCode = json.GetValue("ret_code").ToString();
            }
            if (json.GetValue("ret_msg") != null)
            {
                response.retMsg = json.GetValue("ret_msg").ToString();
            }
            if (json.GetValue("result") != null)
            {
                response.result =JObject.Parse(json.GetValue("result").ToString());
            }
            return response;
        }
    }
}
