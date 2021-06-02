using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.recurring;
using Yuansfer_SDK.src.response.recurring;
using Newtonsoft.Json.Linq;
using System;

namespace Yuansfer_SDK.tests.recurring
{
    [TestClass]
    public class RecurringPayTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RecurringPayRequest request = new RecurringPayRequest();

        [TestMethod]
        public void Test1()
        {
            request.amount = "130";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.autoDebitNo = "409682114813361926";
            request.reference = "12345678dsadsaads9";
            
            request.ipnUrl = "https://primedownline.com/ajax_call.php?pg=yuansfer_amo_pay_callback&client=dev&rcn=10&ORDNUM=500000057&seq=1";

            RecurringPayResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
