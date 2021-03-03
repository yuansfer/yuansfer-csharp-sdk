using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yuansfer_SDK.src.client;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.enums;
using Yuansfer_SDK.src.request.online;
using Yuansfer_SDK.src.response.online;

namespace Yuansfer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            YuanpayConfig config = new YuanpayConfig();
            config.env = EnvironmentEnums.SANDBOX.Value;
            //config.merchantNo = "200043";
            //config.storeNo = "302262";
            //config.token = "78a8904244ace51316af21dd0bad338e";
            //config.merchantNo = "202333";
            //config.storeNo = "301854";
            //config.token = "17cfc0170ef1c017b4a929d233d6e65e";
            config.merchantNo = "202333";
            config.storeNo = "301854";
            config.token = "17cfc0170ef1c017b4a929d233d6e65e";

            YuanpayClient client = new YuanpayV3Client(config);

            OnlineSecurepayRequest request = new OnlineSecurepayRequest();

            Random random = new System.Random();
            request.amount = "0.01";
            request.currency = "USD";
            request.settleCurrency = "USD";
            request.vendor = "venmo";
            request.terminal = "YIP";
            request.reference = random.Next().ToString();
            request.ipnUrl = "https://yuansferdev.com/callback";
            request.description = "9245bd5e21d63e45833b1c4bdb7e7c83";
            request.note = "9245bd5e21d63e45833b1c4bdb7e7c83";

            OnlineSecurepayResponse response = client.execute(request);
            ViewBag.res = response.result;
            ViewBag.request = request;
            var m = new Yuansfer_SDK.src.response.online.OnlineSecurepayResponse();
            return View(m);
        }
    }
}