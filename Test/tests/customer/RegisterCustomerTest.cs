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
    public class RegisterCustomerTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RegisterCustomerRequest request = new RegisterCustomerRequest();

        [TestMethod]
        public void Test1()
        {
            request.city = "NY";
            request.timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm ttZ");
            //request.company = "Yuansfer";
            //request.country = "United State";
            //request.countryCode = "US";
            //request.customerCode = "04131111sdascxzc111";
            request.dateOfBirth = "1988-01-01";
            request.email = "shawn@YuansferTest.com";
            request.firstName = "Shawn";
            request.lastName = "Zheng";
            //request.mobileNumber = "111111111";
            //request.phone = "111111111";
            request.state = "NY";
            request.street = "11 Flushing Ave";
            request.street2 = "FL2";
            request.zip = "11111";

            RegisterCustomerResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
