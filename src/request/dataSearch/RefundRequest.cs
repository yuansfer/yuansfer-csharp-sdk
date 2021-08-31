using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response.transaction;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

/**
 *  Refund request 
 **/ 
namespace Yuansfer_SDK.src.request.transaction
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

            //Settlement Currency validation
            if (string.IsNullOrEmpty(settleCurrency))
            {
                throw new YuanpayException("settleCurrency is missing");
            }

            //TransactionNo and Reference validation
            if(string.IsNullOrEmpty(transactionNo) && string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("transaction number and reference cannot be null at the same time");
            }
            if (!string.IsNullOrEmpty(transactionNo) && !string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("transaction number and reference cannot exist at the same time");
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
                response.result = JObject.Parse(json.GetValue("result").ToString());
            }
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();
            return response;
        }
    }
}
