using System;
using System.Collections.Generic;
using System.Text;

/**
 * True and False Enums 
 **/
namespace Yuansfer_SDK.src.enums
{
    public class TrueFalseEnums
    {
        public static readonly TrueFalseEnums TRUE = new TrueFalseEnums("true");
        public static readonly TrueFalseEnums FALSE = new TrueFalseEnums("false"); 

        public static IEnumerable<TrueFalseEnums> Values
        {
            get
            {
                yield return TRUE;
                yield return FALSE;
            }
        }

        //Get and private set method for TrueFalseEnums value;
        public string Value { get; private set; }

        TrueFalseEnums(string value) =>
            (Value) = (value);

        //Validation method to determine if input is valid
        public static bool containValidate(string value)
        {
            bool flag = false;
            foreach (TrueFalseEnums en in TrueFalseEnums.Values)
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
