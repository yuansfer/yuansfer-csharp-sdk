using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.dataSearch;
using Yuansfer_SDK.src.exception;
using Newtonsoft.Json.Linq;

/**
 *  Settlement status of given date request 
 **/ 
namespace Yuansfer_SDK.src.request.dataSearch
{
    public class DataStatusRequest : YuanpayRequest<DataStatusResponse>
    {
        public string paymentDate { get; set; } //Date of settlement status

        protected override void dataValidate()
        {
            //Date validation
            ParamValidator.dateValidate("paymentDate", paymentDate);
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.DATA_STATUS;
            return url;
        }

        public override DataStatusResponse convertResponse(string ret)
        {
            DataStatusResponse response = new DataStatusResponse();
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
