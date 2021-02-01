using System;
using System.Collections.Generic;
using System.Text;

/**
 *  Currency Enum 
 *  @Author Shawn
**/
namespace Yuansfer_SDK.src.enums
{
    public class CurrencyEnums
    {
        public static readonly CurrencyEnums USD = new CurrencyEnums("USD"); //Currency: American Dollar
        public static readonly CurrencyEnums CNY = new CurrencyEnums("CNY"); //Currency: Chinese RMB

        public static IEnumerable<CurrencyEnums> Values
        {
            get
            {
                yield return USD;
                yield return CNY;
            }
        }

        //Get and private set method for CurrencyEnums value;
        public string Value { get; private set; }

        CurrencyEnums(string value) =>
            (Value) = (value);

        //Validation method to determine if input is valid
        public static bool containValidate(string value)
        {
            bool flag = false;
            foreach (CurrencyEnums en in CurrencyEnums.Values)
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
