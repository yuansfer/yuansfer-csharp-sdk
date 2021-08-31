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
using System.Threading.Tasks;
using Yuansfer_SDK.src.models;
using Newtonsoft.Json;

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
        private HttpClient client = new System.Net.Http.HttpClient();

        //Execute method to make request
        public T execute<T>(YuanpayRequest<T> request) where T : YuanpayResponse
        {
            try
            {

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

                T t;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    responseBody = responseContent.ReadAsStringAsync().Result;
                    t = request.convertResponse(responseBody);
                }
                else
                {
                    HttpObject httpObject = new HttpObject();
                    httpObject.HttpStatusCode = response.StatusCode;
                    httpObject.HttpContent = response.Content;
                    t = request.convertResponse(JsonConvert.SerializeObject(httpObject));
                }

                return t;
            }
            catch (Exception e)
            {
                throw new YuanpayException(e.Message);
            }
            finally
            {
                
            }
        }
    }
}
