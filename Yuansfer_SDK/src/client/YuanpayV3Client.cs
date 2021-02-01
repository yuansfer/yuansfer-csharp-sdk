using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;

using Newtonsoft.Json.Linq;
using Yuansfer_SDK.src.config;
using Yuansfer_SDK.src.request;
using Yuansfer_SDK.src.response;
using Yuansfer_SDK.src.exception;

/**
 *  Yuanpay Client implementation
 **/
namespace Yuansfer_SDK.src.client
{
    public class YuanpayV3Client : YuanpayClient
    {
        private YuanpayConfig yuanpayConfig;

        //Initlaize client config
        public YuanpayV3Client(YuanpayConfig yuanpayConfig)
        {
            this.yuanpayConfig = yuanpayConfig;
        }

        //Initialize Http request
        public static HttpClient getDefaultClient()
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(30);
            return client;
        }

        //Execute method to make request
        public T execute<T>(YuanpayRequest<T> request) where T : YuanpayResponse
        {
            try
            {
                HttpClient client = getDefaultClient();
                

                //Bind config
                if(yuanpayConfig == null)
                {
                    throw new YuanpayException("missing config information");
                }
                else
                {
                    //Basic auth validation
                    yuanpayConfig.basicValidate();
                }

                RequestBody requestBody = request.initRequestBody(yuanpayConfig);
                string url = requestBody.url;
                SortedDictionary<string, string> param = requestBody.param;
                
                //Param data validation
                JObject jsonParams = null;
                if (param.Count != 0)
                {
                    jsonParams = JObject.FromObject(param);
                }
                else
                {
                    jsonParams = new JObject();
                }

                string transJson = jsonParams.ToString();

                //Set header for http request
                var stringContent = new StringContent(transJson, Encoding.UTF8, "application/json");

                //Make post http request
                var response =client.PostAsync(url, stringContent).Result;
                string responseBody = null;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    responseBody = responseContent.ReadAsStringAsync().Result;
                }

                
                if (string.IsNullOrEmpty(responseBody))
                {
                    throw new YuanpayException("fail to connect");
                }

                T t = request.convertResponse(responseBody);
                return t;
            } catch (Exception e)
            {
                throw new YuanpayException(e.Message);
            } finally
            {
                
            }
        }
    }
}
