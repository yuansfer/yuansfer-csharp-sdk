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

        PayoutCreateAccountRequest request = new PayoutCreateAccountRequest();

        [TestMethod]
        public void Test1()
        {
            request.accountType = "CARD";
            request.accountTag = "001";
            request.clientIp = "111,111,111,111";
            request.customerNo = "TestNumber";
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
            request.callbackUrl = "http://zk-tys.yunkeguan.com/ttest/test";

            PayoutCreateAccountResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
