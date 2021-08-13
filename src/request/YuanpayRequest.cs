using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.utils;
using Yuansfer_SDK.src.enums;

/**
 *  Request Class
 **/
namespace Yuansfer_SDK.src.request
{
    public abstract class YuanpayRequest<T> where T:YuanpayResponse
    {
        protected YuanpayConfig config;

        /*
         * Initialize config
         */
        public RequestBody initRequestBody(YuanpayConfig config)
        {
            //Initlize config
            this.config = config;

            dataValidate();

            //Basic setting
            string url = getAPIUrl(config.env);
            SortedDictionary<string,string> param = convertToRequestParam();

            //Return request body
            RequestBody requestBody = new RequestBody();
            requestBody.url = url;
            requestBody.param = param;
            return requestBody;
        }

        /*
        * Method used to retrieve url prefix base on environment
        */
        protected string getUrlPrefix(string env)
        {
            string urlPrefix = "";

            //Determine if env is sandbox or product
            if (EnvironmentEnums.SANDBOX.Value.Equals(env))
            {
                urlPrefix = RequestConstants.SANDBOX_PREFIX;
            }else if (EnvironmentEnums.PRODUCT.Value.Equals(env))
            {
                urlPrefix = RequestConstants.PRODUCT_PREFIX;
            } else
            {
                throw new YuanpayException("env error");
            }

            return urlPrefix;
        }

        /*
        *  Convert object to request params
        */
        protected SortedDictionary<string,string> convertToRequestParam()
        {
            if (config == null)
            {
                throw new YuanpayException("missing config information.");
            }

            //Ignore param list
            List<string> ignores = new List<string>();
            ignores.Add("config");

            //Compute map
            SortedDictionary<string, string> map = ReflectUtils.Obj2map(this, ignores);
            map = config.basicParamSetting(map);

            if (string.IsNullOrEmpty(config.token))
            {
                throw new YuanpayException("missing token");
            }

            //Encrpt params along with token
            string str = MapUrlUtils.getUrlParamsByMap(map);
            str = str + "&" + MD5Utils.cryptHash((config.token + "").Trim());
            string verifySign = MD5Utils.cryptHash(str);
            map.Add("verifySign", verifySign);

            return map;

        }

        //Request validation
        protected abstract void dataValidate();

        //Get request url
        protected abstract string getAPIUrl(string env);

        //Convert response
        public abstract T convertResponse(string ret);
    }
}
