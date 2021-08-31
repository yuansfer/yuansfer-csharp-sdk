using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.transaction;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

/**
 *  Payment Cancel request 
 **/ 
namespace Yuansfer_SDK.src.request.transaction
{
    public class MixedCancelRequest : YuanpayRequest<MixedCancelResponse>
    {
        public string recordNo { get; set; } //recordNo of the transaction

        protected override void dataValidate()
        {
            //TransactionNo and Reference validation
            if (string.IsNullOrEmpty(recordNo) )
            {
                throw new YuanpayException("recordNo cannot be null");
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.MIXED_CANCEL;
            return url;
        }

        public override MixedCancelResponse convertResponse(string ret)
        {
            MixedCancelResponse response = new MixedCancelResponse();
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
