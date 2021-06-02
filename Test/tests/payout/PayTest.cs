using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.payout;
using Yuansfer_SDK.src.response.payout;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.payout
{
    [TestClass]
    public class PayoutPayTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        PayoutPayRequest request = new PayoutPayRequest();

        [TestMethod]
        public void Test1()
        {
            request.amount = "1.00";
            request.currency = "USD";
            //request.ipnUrl = "https://yuansferdev.com/callback";
            request.accountToken = "2010305228244863855835";
            request.customerNo = "2000305228244862935303";
            request.invoiceId = DateTime.Now.ToString();
            request.subject = "Payouts";
            request.description = "test description";
            request.note = "test note";

            PayoutPayResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
