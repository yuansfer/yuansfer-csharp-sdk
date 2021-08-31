using System;
using System.Collections.Generic;
using System.Text;

namespace Yuansfer_SDK.src.enums
{
    public class EnvironmentEnums
    {
        public static readonly EnvironmentEnums SANDBOX = new EnvironmentEnums("sandbox"); //Environment: Sandbox
        public static readonly EnvironmentEnums PRODUCT = new EnvironmentEnums("product"); //Environment: Production

        public static IEnumerable<EnvironmentEnums> Values
        {
            get
            {
                yield return SANDBOX;
                yield return PRODUCT;
            }
        }

        //Get and private set method for EnvironmentEnums value;
        public string Value { get; private set; }

        EnvironmentEnums(string value) =>
            (Value) = (value);

        //Validation method to determine if input is valid
        public static bool containValidate(string value)
        {
            bool flag = false;
            foreach (VendorEnums en in VendorEnums.Values)
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
