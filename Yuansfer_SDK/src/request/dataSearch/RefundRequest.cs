using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response.dataSearch;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

/**
 *  Refund request 
 **/ 
namespace Yuansfer_SDK.src.request.dataSearch
{
    public class RefundRequest : YuanpayRequest<RefundResponse>
    {
        public string refundAmount { get; set; } //Currency amount
        public string currency { get; set; } //Currency type, ex: "USD","CNY"
        public string settleCurrency { get; set; } //Settlement currency type, ex: "USD","CNY"
        public string transactionNo { get; set; } //Transaction number
        public string reference { get; set; } //Transaction reference
        public string refundReference { get; set; } //Refund transaction reference

        protected override void dataValidate()
        {
            //Amount validation
            ParamValidator.amountValidate("refundAmount", refundAmount);

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

            //TransactionNo and Reference validation
            if(string.IsNullOrEmpty(transactionNo) && string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("transaction and reference cannot be null at the same time");
            }
            if (!string.IsNullOrEmpty(transactionNo) && !string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("transaction and reference cannot exist at the same time");
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.REFUND;
            return url;
        }

        public override RefundResponse convertResponse(string ret)
        {
            RefundResponse response = new RefundResponse();
            JObject json = JObject.Parse(ret);
            if (json.GetValue("result") != null)
            {
                string resultJson = json.GetValue("result").ToString();
                RefundBody result = JsonConvert.DeserializeObject<RefundBody>(resultJson);
                response.result = result;
            }
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();
            return response;
        }
    }
}
