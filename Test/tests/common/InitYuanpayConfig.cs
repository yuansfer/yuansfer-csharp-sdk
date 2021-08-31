
using Yuansfer_SDK.src.client;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.enums;

namespace Yuansfer_SDK.tests.common
{
    public class InitYuanpayConfig
    {
        public static YuanpayConfig initMerchantConfig()
        {
            YuanpayConfig config = new YuanpayConfig();
            config.env = EnvironmentEnums.SANDBOX.Value;

            //UP Sandbox
            //config.merchantNo = "200043";
            //config.storeNo = "302747";
            //config.token = "50a1632fe462e44b18b2809a0cebe851";

            //Sandbox Test
            //config.merchantNo = "202333";
            //config.storeNo = "301854";
            //config.token = "17cfc0170ef1c017b4a929d233d6e65e";

            config.merchantNo = "200043";
            config.storeNo = "300014";
            config.token = "5cbfb079f15b150122261c8537086d77a";

            //config.merchantNo = "203018";
            //config.storeNo = "302680";
            //config.token = "0f4401e8d097d9c4dba30108d5288ff1";

            //Ihealth sandbox 
            //config.merchantNo = "200043";
            //config.storeNo = "302531";
            //config.token = "b3c20eed66d97de694f1224dd5479f26";

            //OLR Sandbox
            //config.storeNo = "302551";
            //config.merchantNo = "200043";
            //config.token = "d7df8b180cf7309f6bf2ab210f63952b";

            //Product Test
            //config.merchantNo = "200043";
            //config.storeNo = "302252";
            //config.token = "0df0d2e6ceee95bef2e40780bec91003";

            //Product CigarBus
            //config.merchantNo = "200793";
            //config.storeNo = "301068";
            //config.token = "4c44c0ebb2597c572c225a4b65442ee7";

            //Iheath
            //config.merchantNo = "201170";
            //config.storeNo = "301315";
            //config.token = "247dba927a664c7e8b1a8c165cda219e";

            //Melodi
            //config.merchantNo = "202187";
            //config.storeNo = "302329";
            //config.token = "e97ad3e7eb8adb79cb698471bb84a842";

            //YunTuan
            //config.merchantNo = "202223";
            //config.storeNo = "302366";
            //config.token = "560d29ba1609e213d452127bd7b30a78";

            return config;
        }
    }
}
