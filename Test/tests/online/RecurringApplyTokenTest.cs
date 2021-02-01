using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.online;
using Yuansfer_SDK.src.response.online;
using Newtonsoft.Json.Linq;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.enums;

namespace Yuansfer_SDK.tests.online
{
    [TestClass]
    public class RecurringApplyTokenTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RecurringApplyTokenRequest request = new RecurringApplyTokenRequest();

        [TestMethod]
        public void Test1()
        {
            request.autoDebitNo = "390685905827682866";
            request.grantType = "AUTHORIZATION_CODE";
            RecurringApplyTokenResponse response = client.execute(request);
            Assert.AreEqual("000100", response.retCode);
        }

    }
}
