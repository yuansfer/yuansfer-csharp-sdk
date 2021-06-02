using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.dataSearch;
using Yuansfer_SDK.src.response.dataSearch;
using Newtonsoft.Json.Linq;
using System;

namespace Yuansfer_SDK.tests.dataSearch
{
    [TestClass]
    public class RefundTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RefundRequest request = new RefundRequest();

        [TestMethod]
        public void Test1()
        {
            request.refundAmount = "93.15";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.transactionNo = "297553656994938424";

            RefundResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
