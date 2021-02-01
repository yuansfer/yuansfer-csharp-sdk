using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.dataSearch;
using Yuansfer_SDK.src.response.dataSearch;
using Newtonsoft.Json.Linq;

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
            request.refundAmount = "1.11";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.reference = "297553630266977470";

            RefundResponse response = client.execute(request);
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
