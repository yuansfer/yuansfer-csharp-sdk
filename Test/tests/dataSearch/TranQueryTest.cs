using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.dataSearch;
using Yuansfer_SDK.src.response.dataSearch;
using Newtonsoft.Json.Linq;
using System;

namespace Yuansfer_SDK.tests.dataSearch
{
    [TestClass]
    public class TranQueryTest
    {
        
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        TranQueryRequest request = new TranQueryRequest();

        [TestMethod]
        public void Test1()
        {
            request.transactionNo = "297553657363308323";

            TranQueryResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
