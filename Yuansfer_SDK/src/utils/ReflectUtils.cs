using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Yuansfer_SDK.src.exception;

namespace Yuansfer_SDK.src.utils
{
    [Serializable]
    public class ReflectUtils
    {
        /**
         *  Convert object type to map type
         **/ 
         public static SortedDictionary<string,string> Obj2map<T>(T t, List<string> ignores)
        {
            try
            {
                SortedDictionary<string, string> map = new SortedDictionary<string, string>();

                Type test1 = t.GetType();
                //Iterate over the class and store all object value into map

                FieldInfo[] fields = t.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                PropertyInfo[] properties = t.GetType().GetProperties();
                foreach(PropertyInfo property in properties)
                {
                    object obj = property.GetValue(t);
                    if(obj != null)
                    {
                        if( ignores != null && !ignores.Contains(property.Name))
                        {
                            map.Add(property.Name, obj.ToString());
                        }
                    }
                }
                
                return map;
            } catch (Exception e)
            {
                throw new YuanpayException(e.Message);
            }
        }
    }
}
