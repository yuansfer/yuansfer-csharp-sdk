using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.offline;
using Yuansfer_SDK.src.response.offline;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.offline
{
    [TestClass]
    public class InstoreCreateTranQrcodeTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        InstoreCreateTranQrcodeRequest request = new InstoreCreateTranQrcodeRequest();

        [TestMethod]
        public void Test1()
        {
            request.amount = "1.11";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.vendor = "wechatpay";
            request.reference = "297553630266977as474";
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";

            InstoreCreateTranQrcodeResponse response = client.execute(request);
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
