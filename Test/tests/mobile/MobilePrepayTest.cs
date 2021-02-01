using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.mobile;
using Yuansfer_SDK.src.response.mobile;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.mobile
{
    [TestClass]
    public class MobilePrepayTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        MobilePrepayRequest request = new MobilePrepayRequest();

        [TestMethod]
        public void Test1()
        {
            request.amount = "0.11";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.vendor = "venmo";
            request.terminal = "ONLINE";
            request.reference = "297553630266972227470";
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
            request.description = "Test for description";
            request.note = "Test for note";

            MobilePrepayResponse response = client.execute(request);
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
