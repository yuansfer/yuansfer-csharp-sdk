
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
            //config.merchantNo = "201170";
            //config.storeNo = "301315";
            //config.token = "247dba927a664c7e8b1a8c165cda219e";
            //config.merchantNo = "200793";
            //config.storeNo = "301068";
            //config.token = "4c44c0ebb2597c572c225a4b65442ee7";
            config.merchantNo = "202333 ";
            config.storeNo = "301854";
            config.token = "17cfc0170ef1c017b4a929d233d6e65e";

            return config;
        }
    }
}
