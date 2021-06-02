using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.recurring;
using Yuansfer_SDK.src.response.recurring;
using Newtonsoft.Json.Linq;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.enums;
using System;

namespace Yuansfer_SDK.tests.recurring
{
    [TestClass]
    public class RecurringApplyTokenTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RecurringApplyTokenRequest request = new RecurringApplyTokenRequest();

        [TestMethod]
        public void Test1()
        {
            request.autoDebitNo = "409682114813361926";
            request.grantType = "AUTHORIZATION_CODE";
            RecurringApplyTokenResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }

    }
}
