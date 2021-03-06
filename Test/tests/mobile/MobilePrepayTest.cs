﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.mobile;
using Yuansfer_SDK.src.response.mobile;
using Newtonsoft.Json.Linq;
using System;

namespace Yuansfer_SDK.tests.mobile
{
    [TestClass]
    public class MobilePrepayTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        MobilePrepayRequest request = new MobilePrepayRequest();

        [TestMethod]
        public void Test1()
        {
            request.amount = "0.11";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.vendor = "alipay";
            request.terminal = "APP";
            request.reference = DateTime.Now.ToString();
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
            request.description = "Test for description";
            request.note = "Test for note";

            MobilePrepayResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
