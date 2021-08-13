using System;
using System.Collections.Generic;
using System.Text;

/**
 *  MD5 Utils 
 **/
namespace Yuansfer_SDK.src.utils
{
    
    public class MD5Utils
    {
        /**
         *  Encrpted with MD5 Algorithm 
         * 
         *  @param hashStr
         *  @return strCrypt
         **/
        public static string cryptHash(string hashStr)
        {
            string strCrypt = hashStr;
            if (strCrypt.Length > 0)
            {
                strCrypt = hash(strCrypt);
            }

            return strCrypt;
        }

        /**
         *  MD5 algorithm implementation
         *  
         *  @param str
         *  @return computed string
         **/ 
        public static string hash(string str)
        {
            try
            {
                using (var md5Hash = System.Security.Cryptography.MD5.Create())
                {
                    // Byte array representation of source string
                    var sourceBytes = Encoding.UTF8.GetBytes(str);

                    // Generate hash value(Byte Array) for input data
                    var hashBytes = md5Hash.ComputeHash(sourceBytes);

                    // Convert hash byte array to string
                    var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                    return hash.ToLower();
                }

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
         
    }
}
