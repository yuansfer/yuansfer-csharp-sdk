using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.transaction;
using Yuansfer_SDK.src.response.transaction;
using Newtonsoft.Json.Linq;
using System;

namespace Yuansfer_SDK.tests.transaction
{
    [TestClass]
    public class MixedQueryTest
    {
        
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        MixedQueryRequest request = new MixedQueryRequest();

        [TestMethod]
        public void Test1()
        {
            request.recordNo = "409439052428477189";
            MixedQueryResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
