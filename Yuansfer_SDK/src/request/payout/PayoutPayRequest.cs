using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response.payout;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.payout
{
    public class PayoutPayRequest : YuanpayRequest<PayoutPayResponse>
    {
        public string amount { get; set; } //Currency amount
        public string currency { get; set; } //Currency type, ex: "USD","CNY"
        public string customerNo { get; set; } //Payout customer number
        public string accountToken { get; set; } //Payout account token
        public string description { get; set; } //Payout description
        public string invoiceId { get; set; }//The Invoice Number of the transaction in the merchant's system.
        public string ipnUrl { get; set; } //Asynchronous callback address
        public string note { get; set; } //Payout note
        public string subject { get; set; } //The subject line for the email the gets sent out when a payment is completed.

        //Data validation
        protected override void dataValidate()
        {
            //Amount validation
            ParamValidator.amountValidate("amount", amount);

            //Reference validation
            if (string.IsNullOrEmpty(customerNo))
            {
                throw new YuanpayException("customerNo is missing");
            }

            if (string.IsNullOrEmpty(accountToken))
            {
                throw new YuanpayException("accountToken is missing");
            }

            //Currency validation
            if (string.IsNullOrEmpty(currency))
            {
                throw new YuanpayException("currency is missing");
            }

            if (!string.IsNullOrEmpty(invoiceId))
            {
                throw new YuanpayException("invoiceId is missing");
            }

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
        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.PAYOUT_PAY;
            return url;
        }

        //Handle response data
        public override PayoutPayResponse convertResponse(string ret)
        {
            PayoutPayResponse response = new PayoutPayResponse();
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
