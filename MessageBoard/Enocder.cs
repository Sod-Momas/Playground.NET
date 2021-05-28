using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace MessageBoard
{
    /// <summary>
    /// 编码工具类
    /// </summary>
    public class Encoder
    {
        /// <summary>
        /// 计算md5摘要信息
        /// </summary>
        /// <param name="input">原文内容</param>
        /// <returns>原文的md5摘要信息</returns>
        public static string MD5Hash(string input)
        {
            using (MD5 sha256Hash = MD5.Create())
            {
                return GetHash(sha256Hash, input);
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}