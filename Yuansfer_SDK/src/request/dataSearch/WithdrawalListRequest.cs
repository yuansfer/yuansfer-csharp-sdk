using System;
using System.Collections.Generic;
using System.Text;
using Yuansfer_SDK.src.response.dataSearch;
using Yuansfer_SDK.src.exception;
using Newtonsoft.Json.Linq;
using System.Globalization;

/**
 *  Withdrawal List Request 
 **/
namespace Yuansfer_SDK.src.request.dataSearch
{
    public class WithdrawalListRequest : YuanpayRequest<WithdrawalListResponse>
    {
        public string startDate { get; set; } //Startdate of transaction
        public string endDate { get; set; } //Enddate of transaction

        protected override void dataValidate()
        {
            //Date validation
            if (string.IsNullOrEmpty(startDate))
            {
                throw new YuanpayException("startDate is missing");
            }
            if (string.IsNullOrEmpty(endDate))
            {
                throw new YuanpayException("endDate is missing");
            }

            try
            {
                ParamValidator.dateValidate("startDate", startDate);
                ParamValidator.dateValidate("endDate", endDate);

                DateTime start = DateTime.ParseExact(startDate,
                                  "yyyyMMdd",
                                   CultureInfo.InvariantCulture);
                DateTime end = DateTime.ParseExact(endDate,
                                  "yyyyMMdd",
                                   CultureInfo.InvariantCulture);
                if (end < start)
                {
                    throw new SystemException("endDate should be later than startDate");
                }
                if (start.AddDays(15) <= end)
                {
                    throw new SystemException("endDate cannot be 15 days greater than startDate");
                }
            }
            catch (Exception e)
            {
                throw new YuanpayException(e.Message);
            }
        }

        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.WITHDRAWAL_LIST;
            return url;
        }

        public override WithdrawalListResponse convertResponse(string ret)
        {
            WithdrawalListResponse response = new WithdrawalListResponse();
            JObject json = JObject.Parse(ret);
            //if (json.GetValue("withdrawals") != null)
            //{
            //    response.withdrawals = JArray.Parse(json.GetValue("withdrawals").ToString());
            //}
            //if (json.GetValue("size") != null)
            //{
            //    response.size = int.Parse(json.GetValue("transactions").ToString());
            //}
            if (json.GetValue("result") != null)
            {
                response.result = JObject.Parse(json.GetValue("result").ToString());
            }
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();
            return response;
        }
    }
}
