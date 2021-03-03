using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            request.amount = "1.11";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.vendor = "wechatpay";
            request.reference = DateTime.Now.ToString();
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
            request.needQrcode = "true";
            request.timeout = 120;

            InstoreCreateTranQrcodeResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
