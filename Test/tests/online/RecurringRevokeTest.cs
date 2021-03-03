using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.online;
using Yuansfer_SDK.src.response.online;
using Newtonsoft.Json.Linq;
using System;

namespace Yuansfer_SDK.tests.online
{
    [TestClass]
    public class RecurringRevokeTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RecurringRevokeRequest request = new RecurringRevokeRequest();

        [TestMethod]
        public void Test1()
        {
            request.autoDebitNo = "390616003388862110";

            RecurringRevokeResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
