using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.dataSearch;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

/**
 *  Payment Cancel request 
 **/ 
namespace Yuansfer_SDK.src.request.dataSearch
{
    public class CancelRequest : YuanpayRequest<CancelResponse>
    {
        public string transactionNo { get; set; } //Invoice number of transaction
        public string reference { get; set; } //Invoice number of transaction

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
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.REVERSE;
            return url;
        }

        public override CancelResponse convertResponse(string ret)
        {
            CancelResponse response = new CancelResponse();
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
