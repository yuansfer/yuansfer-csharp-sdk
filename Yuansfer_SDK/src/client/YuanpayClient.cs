using System;
using System.Collections.Generic;
using System.Text;

using Yuansfer_SDK.src.request;
using Yuansfer_SDK.src.response;

/**
 *  Yuanpay Client interface
 **/ 
namespace Yuansfer_SDK.src.client
{
    public interface YuanpayClient
    {
        T execute<T>(YuanpayRequest<T> request) where T : YuanpayResponse;
    }
}
