using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.payout;
using Yuansfer_SDK.src.response.payout;
using Newtonsoft.Json.Linq;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.enums;

namespace Yuansfer_SDK.tests.payout
{
    [TestClass]
    public class PayoutInquiryTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        PayoutInquiryRequest request = new PayoutInquiryRequest();

        [TestMethod]
        public void Test1()
        {
            request.invoiceId = "testInvoice";

            PayoutInquiryResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
