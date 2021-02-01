using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.online;
using Yuansfer_SDK.src.response.online;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.online
{
    [TestClass]
    public class RecurringConsultTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RecurringConsultRequest request = new RecurringConsultRequest();

        [TestMethod]
        public void Test1()
        {
            request.note = "Test for note";
            request.terminal = "ONLINE";
            request.autoReference = "testShawnAuth2021010801";
            request.autoIpnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
            request.autoRedirectUrl = "http://zk-tys.yunkeguan.com/ttest/test2?status={status}";
            request.customerBelongsTo = "GCASH";
            RecurringConsultResponse response = client.execute(request);
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
