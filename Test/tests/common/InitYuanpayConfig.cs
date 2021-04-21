
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.enums;

namespace Yuansfer_SDK.tests.common
{
    public class InitYuanpayConfig
    {
        public static YuanpayConfig initMerchantConfig()
        {
            YuanpayConfig config = new YuanpayConfig();
            config.env = EnvironmentEnums.PRODUCT.Value;
            //config.merchantNo = "200043";
            //config.storeNo = "300014";
            //config.token = "5cbfb079f15b150122261c8537086d77a";
            //config.merchantNo = "202333";
            //config.storeNo = "301854";
            //config.token = "17cfc0170ef1c017b4a929d233d6e65e";
            //config.merchantNo = "202333";
            //config.storeNo = "301854";
            //config.token = "17cfc0170ef1c017b4a929d233d6e65e";
            //config.merchantNo = "200043";
            //config.storeNo = "302252";
            //config.token = "0df0d2e6ceee95bef2e40780bec91003";
            //config.merchantNo = "200043";
            //config.storeNo = "302420";
            //config.token = "0d3943e7b60fbe52c2bc12972fe87f6d";
            config.token = "54b276d77c41fc2a069e66f4d750e7bb";
            config.merchantNo = "200043";
            config.storeNo = "302352";



            return config;
        }
    }
}
