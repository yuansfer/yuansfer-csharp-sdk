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
    public class UpdateRecurringTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RecurringUpdateRequest request = new RecurringUpdateRequest();

        [TestMethod]
        public void Test1()
        {
            request.status = "";
            request.paymentCount = 1;
            RecurringUpdateResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }

    }
}
