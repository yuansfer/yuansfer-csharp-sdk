using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.payout;
using Yuansfer_SDK.src.response.payout;
using Newtonsoft.Json.Linq;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.enums;

namespace Yuansfer_SDK.tests.payout
{
    [TestClass]
    public class CreateAccountTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        PayoutCreateAccountRequest request = new PayoutCreateAccountRequest();

        [TestMethod]
        public void Test1()
        {
            request.city = "NY";
            request.company = "";
            request.country = "United State";
            request.countryCode = "US";
            request.customerCode = "04131111111";
            request.dateOfBirth = "01/01/1900";
            request.email = "shawn@test.com";
            request.firstName = "Shawn";
            request.lastName = "Zheng";
            request.mobileNumber = "111111111";
            request.phone = "111111111";
            request.state = "NY";
            request.street = "11 Flushing Ave";
            request.street2 = "FL2";
            request.zip = "11111";
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
            request.callbackUrl = "http://zk-tys.yunkeguan.com/ttest/test";

            PayoutCreateAccountResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
