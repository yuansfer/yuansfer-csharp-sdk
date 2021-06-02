using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.dataSearch;
using Yuansfer_SDK.src.response.dataSearch;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.dataSearch
{
    [TestClass]
    public class ReverseTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        ReverseRequest request = new ReverseRequest();

        [TestMethod]
        public void Test1()
        {
            request.reference = "297553630266977469";

            ReverseResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
