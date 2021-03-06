﻿using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response.online;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.online
{
    public class OnlineSecurepayRequest : YuanpayRequest<OnlineSecurepayResponse>
    {
        public string amount { get; set; } //Currency amount
        public string reference { get; set; } //Merchant payment reference number
        public string currency { get; set; } //Currency type, ex: "USD","CNY"
        public string settleCurrency { get; set; } //Settlement currency type, ex: "USD","CNY"
        public string vendor { get; set; } //Vendor
        public string terminal { get; set; } //Terminial type: Online, WAP,etc..
        public string osType { get; set; } //Operating system type, only required when termial is WAP or APP
        public string description { get; set; } //Order description, will be displayed on cashier page
        public string note { get; set; } //Note
        public string timeout { get; set; } //Timeout 
        public string ipnUrl { get; set; } //Asynchronous callback address
        public string callbackUrl { get; set; } //Synchronous callback address
        public string goodsInfo { get; set; } //Product Info, required JSON format

        //Credit card info
        public string creditType { get; set; }
        public int? paymentCount { get; set; }
        public int? frequency { get; set; }

        //For Braintree 3DS2 only
        public string customerNo { get; set; }

        //Data validation
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

            //Settlement Currency validation
            if (string.IsNullOrEmpty(settleCurrency))
            {
                throw new YuanpayException("currency is missing");
            }

            //Vendor validation
            if (string.IsNullOrEmpty(vendor))
            {
                throw new YuanpayException("vendor is missing");
            }

            //Terminal validation
            if (string.IsNullOrEmpty(terminal))
            {
                throw new YuanpayException("terminal is missing");
            }

            //Description and note validation
            if (!string.IsNullOrEmpty(description))
            {
                if (description.Length > 100)
                {
                    throw new YuanpayException("description is too long");
                }
            }

            if (!string.IsNullOrEmpty(note))
            {
                if (note.Length > 100)
                {
                    throw new YuanpayException("note is too long");
                }
            }

            //Goods Info validation
            if (!string.IsNullOrEmpty(goodsInfo))
            {
                var token = JToken.Parse(goodsInfo);
                bool jsonFlag = token is JArray;
                if (!jsonFlag)
                {
                    throw new YuanpayException("goodsInfo should be json array format");
                }
            }
        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.ONLINE_SECUREPAY;
            return url;
        }

        //Handle response data
        public override OnlineSecurepayResponse convertResponse(string ret)
        {
            OnlineSecurepayResponse response = new OnlineSecurepayResponse();
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
