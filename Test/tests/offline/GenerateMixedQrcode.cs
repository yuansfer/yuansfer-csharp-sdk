using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.offline;
using Yuansfer_SDK.src.response.offline;
using Newtonsoft.Json.Linq;
using System;
using Yuansfer_SDK.request.offline;

namespace Yuansfer_SDK.tests.offline
{
    [TestClass]
    public class GenerateMixedQrcodeTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        GenerateMixedQrcodeRequest request = new GenerateMixedQrcodeRequest();

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

            request.saleAmount = "66.66";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.needQrcode = "true";
            request.reference = new Random().Next(0, 1000000000).ToString();
            request.note = "This is note";
            request.description = "This is description";
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/testt";
            request.tax = "0.01";
            request.tip = "0.01";
            request.needTip = "false";

            GenerateMixedQrcodeResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
