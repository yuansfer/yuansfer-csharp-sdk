using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response.customer;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.customer
{
    public class UpdateAccountRequest : YuanpayRequest<UpdateAccountResponse>
    {
        public string timestamp { get; set; }
        public string city { get; set; } //City
        public string company { get; set; } //Company Name
        public string country { get; set; } //Country name
        public string countryCode { get; set; } //Country code
        public string customerCode { get; set; } //Customer code
        public string dateOfBirth { get; set; } //Date of birth
        public string email { get; set; } //Email Address
        public string lang { get; set; } //Customer language
        public string firstName { get; set; } //First name
        public string lastName { get; set; } //Last name
        public string mobileNumber { get; set; } //Mobile phone number
        public string phone { get; set; } //Phone number
        public string state { get; set; } //State
        public string street { get; set; } //Address
        public string street2 { get; set; } //
        public string zip { get; set; } //Zipcode
        public string customerNo { get; set; }

        //Data validation
        protected override void dataValidate()
        {
            if (string.IsNullOrEmpty(customerNo))
            {
                throw new YuanpayException("customerNo is missing");
            }
            if (string.IsNullOrEmpty(timestamp))
            {
                throw new YuanpayException("timestamp is missing");
            }
        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.CUSTOMER_UPDATE_ACCOUNT;
            return url;
        }

        //Handle response data
        public override UpdateAccountResponse convertResponse(string ret)
        {
            UpdateAccountResponse response = new UpdateAccountResponse();
            JObject json = JObject.Parse(ret);
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
