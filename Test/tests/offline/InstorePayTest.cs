using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.offline;
using Yuansfer_SDK.src.response.offline;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.offline
{
    [TestClass]
    public class InstorePayTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        InstorePayRequest request = new InstorePayRequest();

        [TestMethod]
        public void Test1()
        {
            request.transactionNo = "297553665731335321";
            request.paymentBarcode = "791014426698";
            request.vendor = "paypal";

            InstorePayResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
