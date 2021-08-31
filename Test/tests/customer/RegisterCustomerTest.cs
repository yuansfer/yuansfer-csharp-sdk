using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.customer;
using Yuansfer_SDK.src.response.customer;
using Newtonsoft.Json.Linq;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.enums;

namespace Yuansfer_SDK.tests.customer
{
    [TestClass]
    public class CustomerRegisterTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        CustomerRegisterRequest request = new CustomerRegisterRequest();

        [TestMethod]
        public void Test1()
        {
            request.city = "NY";
            request.timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            request.company = "Yuansfer";
            request.countryCode = "US";
            request.customerCode = "Yuansfer082520210318119";
            request.dateOfBirth = "1988-01-01";
            request.email = "Yuansfer082520210318119@gmail.com";
            request.firstName = "Test";
            request.lastName = "Test";
            request.mobileNumber = "111111111";
            request.phone = "111111111";
            request.state = "NY";
            request.street = "11 Flushing Ave";
            request.street2 = "FL2";
            request.zip = "11111";
            request.profileType = "INDIVIDUAL";

            CustomerRegisterResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
