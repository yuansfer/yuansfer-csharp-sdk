using System;
using System.Collections.Generic;
using System.Text;

namespace Yuansfer_SDK.src.request
{
    public class RequestBody
    {
        public string url { get; set; }
        public SortedDictionary<string, string> param { get; set; }
    }
}
