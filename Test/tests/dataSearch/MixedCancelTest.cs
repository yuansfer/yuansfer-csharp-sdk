using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.transaction;
using Yuansfer_SDK.src.response.transaction;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.transaction
{
    [TestClass]
    public class MixedCancelTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        MixedCancelRequest request = new MixedCancelRequest();

        [TestMethod]
        public void Test1()
        {
            request.recordNo = "409492177171988128";

            MixedCancelResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
