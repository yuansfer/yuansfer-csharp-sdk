using System;
using System.Collections.Generic;
using System.Text;

namespace Yuansfer_SDK.src.enums
{
    public class GrantTypeEnums
    {
        public static readonly GrantTypeEnums AUTHORIZATION_CODE = new GrantTypeEnums("AUTHORIZATION_CODE"); //GrantType: Authorization Code
        public static readonly GrantTypeEnums REFRESH_TOKEN = new GrantTypeEnums("REFRESH_TOKEN"); //GrantType: Refresh Token
        

        public static IEnumerable<GrantTypeEnums> Values
        {
            get
            {
                yield return AUTHORIZATION_CODE;
                yield return REFRESH_TOKEN;
            }
        }

        //Get and private set method for GrantTypeEnums value;
        public string Value { get; private set; }

        GrantTypeEnums(string value) =>
            (Value) = (value);

        //Validation method to determine if input is valid
        public static bool containValidate(string value)
        {
            bool flag = false;
            foreach (GrantTypeEnums en in GrantTypeEnums.Values)
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
