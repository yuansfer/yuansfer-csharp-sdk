﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.offline;
using Yuansfer_SDK.src.response.offline;
using Newtonsoft.Json.Linq;
using System;

namespace Yuansfer_SDK.tests.offline
{
    [TestClass]
    public class InstoreCreateTranQrcodeTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        InstoreCreateTranQrcodeRequest request = new InstoreCreateTranQrcodeRequest();

        [TestMethod]
        public void Test1()
        {
            //PayPal
            /*{
                "amount": "2",
                "currency": "USD",
                "ipnUrl": "https://yuansferdev.com/callback",
                "merchantNo": "200043",
                "reference": "474ef05badfbaf7f7c6565f87a4e8d1e",
                "settleCurrency": "USD",
                "storeNo": "300014",
                "vendor": "paypal",
                "verifySign": "86c13cc31a890d581f0445037a38784a"
              }*/

            request.amount = "0.01";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.vendor = "paypal";
            request.needQrcode = "true";
            request.reference = new Random().Next(0, 1000000000).ToString();

            InstoreCreateTranQrcodeResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
