using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/**
 * JSON data type utils
 **/ 
namespace Yuansfer_SDK.src.utils
{
    public class JSONUtils
    {
        /**
         *  Method to determine if String is in Json format
         *  
         *  @param str
         *  @return bool value
         **/ 
        public static bool isStringJsonFormat(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            str = str.Trim();
            try
            {
                JObject obj = JObject.Parse(str);
                return true;

            } catch (JsonReaderException e)
            {
                return false;
            } catch (Exception e)
            {
                return false;
            }
        }

        /**
         *  Method to determine if String is in Json Array format
         *  
         *  @param str
         *  @return bool value
         **/ 
         public static bool isStringJsonArrFormat(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            str = str.Trim();
            try
            {
                JArray obj = JArray.Parse(str);
                return true;
            } catch (JsonReaderException e)
            {
                return false;
            } catch (Exception e)
            {
                return false;
            }
        }
    }
}
