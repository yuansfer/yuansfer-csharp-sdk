using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.response.customer;
using Yuansfer_SDK.src.exception;
using Yuansfer_SDK.src.enums;
using Newtonsoft.Json.Linq;

namespace Yuansfer_SDK.src.request.customer
{
    public class CustomerRegisterRequest : YuanpayRequest<CustomerRegisterResponse>
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
        public string profileType { get; set; }

        //Data validation
        protected override void dataValidate()
        {
            if (string.IsNullOrEmpty(timestamp))
            {
                throw new YuanpayException("timestamp is missing");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new YuanpayException("email is missing");
            }

            if (string.IsNullOrEmpty(firstName))
            {
                throw new YuanpayException("firstName is missing");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new YuanpayException("lastName is missing");
            }

            if (string.IsNullOrEmpty(countryCode))
            {
                throw new YuanpayException("countryCode is missing");
            }

        }

        //Get Api url
        protected override string getAPIUrl(string env)
        {
            string urlPrefix = getUrlPrefix(env);
            string url = urlPrefix + RequestConstants.CUSTOMER_REGISTER_CUSTOMER;
            return url;
        }

        //Handle response data
        public override CustomerRegisterResponse convertResponse(string ret)
        {
            CustomerRegisterResponse response = new CustomerRegisterResponse();
            JObject json = JObject.Parse(ret);
            if (json.GetValue("customer") != null)
            {
                response.result = JObject.Parse(json.GetValue("customer").ToString());
            }
            response.retCode = json.GetValue("ret_code").ToString();
            response.retMsg = json.GetValue("ret_msg").ToString();
            return response;
        }
    }
}
