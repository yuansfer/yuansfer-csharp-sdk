using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.customer;
using Yuansfer_SDK.src.response.customer;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.customer
{
    [TestClass]
    public class UpdateAccountTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        CustomerUpdateRequest request = new CustomerUpdateRequest();

        [TestMethod]
        public void Test1()
        {
            request.customerNo= "2000300192493982427803";
            request.timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ttZ");
            request.zip = "00000";
            request.city = "Brooklyn";
            request.countryCode = "CN";

            CustomerUpdateResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
