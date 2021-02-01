using System;
using System.Collections.Generic;
using System.Text;

/**
 *  MD5 Utils 
 **/
namespace Yuansfer_SDK.src.utils
{
    [Serializable]
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
                using(System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    //Convert string into hash bytes array
                    byte[] inputBytes = Encoding.ASCII.GetBytes(str);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    //Convert bytes array into string
                    StringBuilder sb = new StringBuilder();
                    for(int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("x2"));
                    }
                    return sb.ToString();

                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
         
    }
}
