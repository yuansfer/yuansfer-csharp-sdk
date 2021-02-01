using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.online;
using Yuansfer_SDK.src.response.online;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.online
{
    [TestClass]
    public class RecurringPayTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RecurringPayRequest request = new RecurringPayRequest();

        [TestMethod]
        public void Test1()
        {
            request.amount = "1.11";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.autoDebitNo = "390616003388862110";
            request.reference = "testAuth2021010801";
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";

            RecurringPayResponse response = client.execute(request);
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
