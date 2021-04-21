using System;
using System.Collections.Generic;
using System.Text;

namespace Yuansfer_SDK.src.exception
{
    
    public class YuanpayException : SystemException
    {
        public YuanpayException(string msg) : base(msg)
        {
        }
    }
}
