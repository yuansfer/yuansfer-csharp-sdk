using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.dataSearch;
using Yuansfer_SDK.src.exception;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.dataSearch
{
    public class TranQueryRequest : YuanpayRequest<TranQueryResponse>
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
            string url = urlPrefix + RequestConstants.TRAN_QUERY;
            return url;
        }

        public override TranQueryResponse convertResponse(string ret)
        {
            TranQueryResponse response = new TranQueryResponse();
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
