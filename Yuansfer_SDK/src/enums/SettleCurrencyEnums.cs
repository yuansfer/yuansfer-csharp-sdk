using System;
using System.Collections.Generic;
using System.Text;

/**
 *  Currency Enum 
 *  @Author Shawn
**/
namespace Yuansfer_SDK.src.enums
{
    public class SettleCurrencyEnums
    {
        public static readonly SettleCurrencyEnums USD = new SettleCurrencyEnums("USD"); //Settlement Currency: American Dollar
        public static readonly SettleCurrencyEnums CNY = new SettleCurrencyEnums("CNY"); //Settlement Currency: Chinese RMB

        public static IEnumerable<SettleCurrencyEnums> Values
        {
            get
            {
                yield return USD;
                yield return CNY;
            }
        }

        //Get and private set method for SettleCurrencyEnums value;
        public string Value { get; private set; }

        SettleCurrencyEnums(string value) =>
            (Value) = (value);

        //Validation method to determine if input is valid
        public static bool containValidate(string value)
        {
            bool flag = false;
            foreach (SettleCurrencyEnums en in SettleCurrencyEnums.Values)
            {
                if (en.Value.Equals(value))
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

    }
}
