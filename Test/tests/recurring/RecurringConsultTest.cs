using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Yuansfer_SDK.src.client;
using Yuansfer_SDK.tests.common;
using Yuansfer_SDK.src.request.recurring;
using Yuansfer_SDK.src.response.recurring;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.tests.recurring
{
    [TestClass]
    public class RecurringConsultTest
    {
        YuanpayClient client = new YuanpayV3Client(InitYuanpayConfig.initMerchantConfig());

        RecurringConsultRequest request = new RecurringConsultRequest();

        [TestMethod]
        public void Test1()
        {   

            request.terminal = "ONLINE";
            request.autoReference = "5000319895";
            request.vendor = "alipay_hk";
            request.autoRedirectUrl = "https://primedownline.com/ajax_call.php?pg=yuansfer_authorize_callback&client=ihl&rcn=10&ORDNUM=500039895&seq=1&session=105316122";
            RecurringConsultResponse response = client.execute(request);
            Console.Write(JObject.FromObject(response));
            Assert.AreEqual("000100", response.retCode);
        }
    }
}
