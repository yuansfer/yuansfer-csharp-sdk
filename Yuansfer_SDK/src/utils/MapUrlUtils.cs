using System;
using System.Collections.Generic;
using System.Text;

/**
 *  Conversion between map and url param 
 **/ 
namespace Yuansfer_SDK.src.utils
{
    [Serializable]
    public class MapUrlUtils
    {
        /**
         *  Convert map to url
         *  
         *  @param map
         *  @return computed url
         **/ 
         public static string getUrlParamsByMap(SortedDictionary<string,string> map)
        {
            if(map == null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();

            //Traversal over the map and append them into string
            foreach(KeyValuePair<string,string> entry in map)
            {
                sb.Append(entry.Key).Append("=").Append(entry.Value);
                sb.Append("&");
            }

            string res = sb.ToString();

            //Remove ending & character
            if (res.EndsWith("&"))
            {
                res = res.Substring(0, res.Length - 1);
            }

            return res;
        }
    }
}
