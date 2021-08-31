using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using Yuansfer_SDK.src.exception;

/**
 * Parameter Data Validation
 **/ 
namespace Yuansfer_SDK.src.request
{
    public class ParamValidator
    {
        // Method to validate number
        public static void numberValidate(string name,string value)
        {
            try
            {
                //Regex pattern for numbers
                string reg = "^[0-9]*[1-9][0-9]*$";

                Regex regex = new Regex(reg);
                Match match = regex.Match(value);

                if (!match.Success)
                {
                    throw new SystemException("data error: " + name);
                }
            } catch (Exception e)
            {
                throw new YuanpayException(e.Message);
            }
        }

        //Method to validate date
        public static void dateValidate(string name,string value)
        {
            try
            {
                //Regex pattern for date
                string reg = "^\\d{4}\\d{2}\\d{2}$";

                Regex regex = new Regex(reg);
                Match match = regex.Match(value);

                if (!match.Success)
                {
                    throw new SystemException("data error: " + name);
                }
            } catch (Exception e)
            {
                throw new YuanpayException(e.Message);
            }
        }

        //Method to validate currency
        public static void amountValidate(string name, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new YuanpayException(name + " missing");
            }
            else
            {
                try
                {
                    //Regex pattern for currency
                    string reg = @"(?=.*?\d)^\$?(([1-9]\d{0,2}(,\d{3})*)|\d+)?(\.\d{1,2})?$";

                    Regex regex = new Regex(reg);
                    Match match = regex.Match(value);

                    if (!match.Success)
                    {
                        throw new SystemException("data error: " + name);
                    }
                }
                catch (Exception e)
                {
                    throw new YuanpayException(e.Message);
                }
            }
        }
    }
}
