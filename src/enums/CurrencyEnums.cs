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
        public static readonly CurrencyEnums GBP = new CurrencyEnums("GBP"); //Currency: 
        public static readonly CurrencyEnums KRW = new CurrencyEnums("KRW"); //Currency: 
        public static readonly CurrencyEnums PHP = new CurrencyEnums("PHP"); //Currency: 
        public static readonly CurrencyEnums JPY = new CurrencyEnums("JPY"); //Currency: 
        public static readonly CurrencyEnums THB = new CurrencyEnums("THB"); //Currency: 
        public static readonly CurrencyEnums PKR = new CurrencyEnums("PKR"); //Currency: 
        public static readonly CurrencyEnums MYR = new CurrencyEnums("MYR"); //Currency: 
        public static readonly CurrencyEnums HKD = new CurrencyEnums("HKD"); //Currency: 
        public static readonly CurrencyEnums IDR = new CurrencyEnums("IDR"); //Currency: 

        public static IEnumerable<CurrencyEnums> Values
        {
            get
            {
                yield return USD;
                yield return CNY;
                yield return GBP;
                yield return KRW;
                yield return PHP;
                yield return JPY;
                yield return THB;
                yield return PKR;
                yield return MYR;
                yield return HKD;
                yield return IDR;
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
