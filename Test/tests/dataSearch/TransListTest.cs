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
    public class TransListTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        TransListRequest request = new TransListRequest();

        [TestMethod]
        public void Test1()
        {
            
            request.endDate = DateTime.Now.ToString("yyyyMMdd");
            request.startDate = DateTime.Now.AddDays(-14).ToString("yyyyMMdd");

            TransListResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
