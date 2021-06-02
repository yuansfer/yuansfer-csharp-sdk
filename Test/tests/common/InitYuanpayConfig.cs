
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
            
            config.merchantNo = "202333 ";
            config.storeNo = "301854";
            config.token = "17cfc0170ef1c017b4a929d233d6e65e";

            return config;
        }
    }
}
