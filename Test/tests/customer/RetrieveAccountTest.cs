using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.customer;
using Yuansfer_SDK.src.response.customer;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.customer
{
    [TestClass]
    public class PayTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RetrieveAccountRequest request = new RetrieveAccountRequest();

        [TestMethod]
        public void Test1()
        {
            request.customerCode = "testCode";
            request.timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm ttZ");

            RetrieveAccountResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
