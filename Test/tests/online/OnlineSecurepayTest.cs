using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.online;
using Yuansfer_SDK.src.response.online;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.online
{
    [TestClass]
    public class OnlineSecurepayTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        JArray goods = new JArray();
        JObject item = new JObject();

        OnlineSecurepayRequest request = new OnlineSecurepayRequest();

        [TestMethod]
        public void Test1()
        {
            request.amount = "0.01";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.vendor = "unionpay";
            request.terminal = "ONLINE";
            request.reference = DateTime.Now.ToString();
            request.ipnUrl = "https://datatuned.com/api/api_pay_yuansfer";
            request.callbackUrl = "https://auth.datatuned.com/index.php?client=dev&pg=yuansfer_response&transactionId={transactionId}&status={status}&amount={amount}&time={time}&reference={reference}&note={note}&cl=dev";
            request.description = "dev";
            request.note = "486363856";
            request.timeout = "120";

            OnlineSecurepayResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
