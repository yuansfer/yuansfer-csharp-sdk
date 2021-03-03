using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Yuansfer_SDK.src.client;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.enums;
using Yuansfer_SDK.src.request.online;
using Yuansfer_SDK.src.response.online;

namespace test.Controllers
{
    public class RequestParam
    {
        public string paymentMethodNonce { get; set; }
        public string transactionNo { get; set; }
    }
    public class HomeapiController : ApiController
    {

        [HttpPost]
        [ActionName("process")]
        public ProcessResponse Process([FromBody]RequestParam requestParam)
        {
            YuanpayConfig config = new YuanpayConfig();
            config.env = EnvironmentEnums.SANDBOX.Value;
            config.merchantNo = "202333";
            config.storeNo = "301854";
            config.token = "17cfc0170ef1c017b4a929d233d6e65e";

            YuanpayClient client = new YuanpayV3Client(config);
            ProcessRequest request = new ProcessRequest();

            request.paymentMethod = "paypal_account";
            request.paymentMethodNonce = requestParam.paymentMethodNonce;
            request.transactionNo = requestParam.transactionNo;

            ProcessResponse response = client.execute(request);

            return response;
        }
    }
}