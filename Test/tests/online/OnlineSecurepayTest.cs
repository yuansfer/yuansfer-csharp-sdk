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
            request.amount = "0.1";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.vendor = "alipay";
            request.terminal = "ONLINE";
            request.reference = DateTime.Now.ToString();
            request.ipnUrl = "http://zk-tys.yunkeguan.com/ttest/test";
            request.callbackUrl = "http://zk-tys.yunkeguan.com/ttest/test";
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
