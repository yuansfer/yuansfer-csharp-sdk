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
            request.amount = "0.10";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.vendor = "paypal";
            request.terminal = "APP";
            request.reference = DateTime.Now.ToString();
            request.ipnUrl = "https://helphalf.net/test/ipn";
            request.callbackUrl = "https://helphalf.net/test?status={status}&transactionNo={transactionNo}&amount={amount}";
            request.description = "9245bd5e21d63e45833b1c4bdb7e7c83";
            request.note = "9245bd5e21d63e45833b1c4bdb7e7c83";
            item.Add("goods_name", "balance");
            item.Add("quantity", "1");
            goods.Add(item);
            request.goodsInfo = goods.ToString();

            OnlineSecurepayResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
