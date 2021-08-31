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
    public class PayoutCreateAccountTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        PayoutCreatePayeeRequest request = new PayoutCreatePayeeRequest();

        [TestMethod]
        public void Test1()
        {
            request.accountType = "PAYPAL";
            request.accountTag = "1873701-2021083-1204401000";
            request.clientIp = "108.54.147.204";
            request.customerNo = "2000300192493982427803";
            request.accountCountry = "US";
            request.accountCurrency = "USD";
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
            request.callbackUrl = "http://zk-tys.yunkeguan.com/ttest/test";
            request.timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

            PayoutCreatePayeeResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
