using Newtonsoft.Json.Linq;

using Yuansfer_SDK.src.response.auth;
using Yuansfer_SDK.src.exception;

/**
 *  Auth Capture Request
 **/ 
namespace Yuansfer_SDK.src.request.auth
{
    public class AuthDetailQueryRequest : YuanpayRequest<AuthDetailQueryResponse>
    {
        public string authInfoNo { get; set; }
        public string outAuthInfoNo { get; set; }
        public string authDetailNo { get; set; }
        public string outAuthDetailNo { get; set; }

        protected override void dataValidate()
        {
            //Validate if infos are missing
            if (string.IsNullOrEmpty(outAuthInfoNo)
                && string.IsNullOrEmpty(authInfoNo))
            {
                throw new YuanpayException("outAuthInfoNo and authInfoNo missing");
            }

            if (!string.IsNullOrEmpty(outAuthDetailNo)
                    && !string.IsNullOrEmpty(authInfoNo))
            {
                throw new YuanpayException("outAuthInfoNo and authInfoNo cannot exist at the same time");
            }

            if (string.IsNullOrEmpty(outAuthDetailNo)
                    && string.IsNullOrEmpty(authDetailNo))
            {
                throw new YuanpayException("outAuthDetailNo and authDetailNo missing");
            }

            if (!string.IsNullOrEmpty(outAuthDetailNo)
                    && !string.IsNullOrEmpty(authDetailNo))
            {
                throw new YuanpayException("outAuthDetailNo and authDetailNo cannot exist at the same time");
            }
        }

        protected override string getAPIUrl(string env)
        {
            //Get API url from methods
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.AUTH_DETAIL_QUERY;
            return url;

        }

        public override AuthDetailQueryResponse convertResponse(string ret)
        {
            //Initialize response
            AuthDetailQueryResponse response = new AuthDetailQueryResponse();

            //Create json object
            JObject json = JObject.Parse(ret);
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();

            if (json.GetValue("result") != null)
            {
                response.result = JObject.Parse(json.GetValue("result").ToString());
            }
            return response;
        }
    }
}
