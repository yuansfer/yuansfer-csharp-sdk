using System;
using System.Collections.Generic;
using System.Text;

/**
 *  RefundBody Response
 **/ 
namespace Yuansfer_SDK.src.response.dataSearch
{
    [Serializable]
    public class RefundResponse : YuanpayResponse
    {
        public RefundBody result { get; set; }
    }
}
