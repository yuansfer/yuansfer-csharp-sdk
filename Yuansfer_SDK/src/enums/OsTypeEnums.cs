using System;
using System.Collections.Generic;
using System.Text;

/**
 * True and False Enums 
 **/
namespace Yuansfer_SDK.src.enums
{
    public class OsTypeEnums
    {
        public static readonly OsTypeEnums IOS = new OsTypeEnums("IOS");
        public static readonly OsTypeEnums ANDROID = new OsTypeEnums("ANDROID"); 

        public static IEnumerable<OsTypeEnums> Values
        {
            get
            {
                yield return IOS;
                yield return ANDROID;
            }
        }

        //Get and private set method for OsTypeEnums value;
        public string Value { get; private set; }

        OsTypeEnums(string value) =>
            (Value) = (value);

        //Validation method to determine if input is valid
        public static bool containValidate(string value)
        {
            bool flag = false;
            foreach (OsTypeEnums en in OsTypeEnums.Values)
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
