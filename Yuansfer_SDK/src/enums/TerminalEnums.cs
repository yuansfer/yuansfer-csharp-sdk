using System;
using System.Collections.Generic;
using System.Text;

/**
 * Termial Enums
 **/
namespace Yuansfer_SDK.src.enums
{
    public class TerminalEnums
    {
        public static readonly TerminalEnums ONLINE = new TerminalEnums("ONLINE"); //Terminal: Online
        public static readonly TerminalEnums WAP = new TerminalEnums("WAP"); //Terminal: Wap
        public static readonly TerminalEnums APP = new TerminalEnums("APP"); //Terminal: Mobile App
        public static readonly TerminalEnums MINIPROGRAM = new TerminalEnums("MINIPROGRAM"); //Terminal: MiniProgram from Wechat

        public static IEnumerable<TerminalEnums> Values
        {
            get
            {
                yield return ONLINE;
                yield return WAP;
                yield return APP;
                yield return MINIPROGRAM;
            }
        }

        //Get and private set method for TerminalEnums value;
        public string Value { get; private set; }

        TerminalEnums(string value) =>
            (Value) = (value);

        //Validation method to determine if input is valid
        public static bool containValidate(string value)
        {
            bool flag = false;
            foreach (TerminalEnums en in TerminalEnums.Values)
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
