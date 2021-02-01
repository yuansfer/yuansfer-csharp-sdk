using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.dataSearch;
using Yuansfer_SDK.src.response.dataSearch;

namespace Test.tests.dataSearch
{
    [TestClass]
    public class CancelTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        CancelRequest request = new CancelRequest();

        [TestMethod]
        public void Test1()
        {
            request.reference = "297553630266977469";

            CancelResponse response = client.execute(request);
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
