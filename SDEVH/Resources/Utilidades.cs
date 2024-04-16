using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SDEVH.Resources
{
    public class Utilidades
    {
        /*Metodo para encriptar valores y datos*/
        public static string ToBase64Encode(string plainText)
        {
            try
            {
                if (string.IsNullOrEmpty(plainText))
                    return "";

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                return Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception ex)
            {
                return plainText;
            }
        }

        /*Metodo para desincriptar valores y datos*/
        public static string Base64Decode(string base64EncodedData)
        {
            try
            {
                if (string.IsNullOrEmpty(base64EncodedData))
                {
                    return "";
                }

                string pattern = @"^[a-zA-Z0-9\+/]*={0,2}$";

                bool isValid = Regex.IsMatch(base64EncodedData, pattern);

                if (isValid)
                {
                    byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);

                    return Encoding.UTF8.GetString(base64EncodedBytes);
                }

                return base64EncodedData;
            }
            catch (Exception e)
            {
                return base64EncodedData;
            }
        }





    }
}
