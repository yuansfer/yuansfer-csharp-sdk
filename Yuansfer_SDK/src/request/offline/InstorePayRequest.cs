using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.offline;
using Yuansfer_SDK.src.enums;
using Yuansfer_SDK.src.exception;
using Newtonsoft.Json.Linq;

/**
 *  In Store payment request 
 **/ 
namespace Yuansfer_SDK.src.request.offline
{
    public class InstorePayRequest : YuanpayRequest<InstorePayResponse>
    {
        public string transactionNo { get; set; } //Invoice number of transaction
        public string reference { get; set; } //Invoice number of transaction
        public string paymentBarcode { get; set; } //The payment barcode from the customer.
        public string vendor { get; set; } //Vendor, ex:"alipay","wechatpay"

        protected override void dataValidate()
        {
            //TransactionNo and Reference validation
            if (string.IsNullOrEmpty(transactionNo) && string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("transaction and reference cannot be null at the same time");
            }
            if (!string.IsNullOrEmpty(transactionNo) && !string.IsNullOrEmpty(reference))
            {
                throw new YuanpayException("transaction and reference cannot exist at the same time");
            }

            //PaymentBarcode validation
            if (string.IsNullOrEmpty(paymentBarcode))
            {
                throw new YuanpayException("paymentBarcode is missing");
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
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.INSTORE_PAY;
            return url;
        }

        public override InstorePayResponse convertResponse(string ret)
        {
            InstorePayResponse response = new InstorePayResponse();
            JObject json = JObject.Parse(ret);
            if (json.GetValue("transaction") != null)
            {
                response.transaction = JObject.Parse(json.GetValue("transaction").ToString());
            }
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();
            return response;
        }
    }
}
