using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;

/**
 *  Yuansfer payment config 
 **/
namespace Yuansfer_SDK.src.config
{
    [Serializable]
    public class YuanpayConfig
    {
        public string env { get; set; } // Environment type
        public int? merGroupSwitch { get; set; } = 0; // 0-> Turn off Service Provider, 1-> Turn on Service Provider
        public string merGroupNo { get; set; } // Service Provider No
        public string merchantNo { get; set; } // Merchant No
        public string storeNo { get; set; } // Store No
        public string storeAdminNo { get; set; } //Store Admin No
        public string token { get; set; } //Token 

        //Add account related info to param
        public SortedDictionary<string,string> basicParamSetting(SortedDictionary<string,string> param)
        {
            //Add key value pair infos to param
            if(merGroupSwitch == 1)
            {
                param.Add("merGroupNo", merGroupNo);
            }

            param.Add("merchantNo", merchantNo);
            param.Add("storeNo", storeNo);

            if (!string.IsNullOrEmpty(storeAdminNo))
            {
                param.Add("storeAdminNo", storeAdminNo);
            }

            return param;
        }

        //Validation method 
        public void basicValidate()
        {
            //Validate Environment type
            if (string.IsNullOrEmpty(env))
            {
                throw new YuanpayException("env is missing");
            }
            else
            {
                bool flag = false;
                foreach(EnvironmentEnums en in EnvironmentEnums.Values)
                {
                    if (en.Value.Equals(env))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    throw new YuanpayException("data error: env");
                }
            }

            //Validate provider service status
            if(merGroupSwitch == null)
            {
                throw new YuanpayException("merGroupSwitch is missing");
            }
            if(merGroupSwitch != 1 && merGroupSwitch != 0)
            {
                throw new YuanpayException("data error: merGroupSwitch");
            }
            if(merGroupSwitch == 1)
            {
                if (string.IsNullOrEmpty(merGroupNo))
                {
                    throw new YuanpayException("merGroupNo is missing");
                }
            }
            if (string.IsNullOrEmpty(merchantNo))
            {
                throw new YuanpayException("merchantNo is missing");
            }
            if (string.IsNullOrEmpty(storeNo))
            {
                throw new YuanpayException("storeNo is missing");
            }
        }
    }
}
