using System;
using System.Security.Cryptography;
using System.Text;

namespace LVR
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte[] key = { -114, -89, -101, -50, -61, -43, 69, -105, -17, -31, -122, 120, 10, -125, 92, 7, 84, 0, 98, 58, 17, 72, 29, 61, 23, -35, -110, -23, 5, -37, -74, 21 }; //Production KEY
            byte[] unsignedKey = (byte[])(Array)key;

            var startTime = ((long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds - 300000) / 1000;
            var endTime = ((long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds + 1800000) / 1000;

            var data = "st=" + startTime + "~exp=" + endTime + "~acl=*";
            var hmac = HmacSHA256(unsignedKey, Encoding.UTF8.GetBytes(data));

            Console.WriteLine("__lvr_mobile_api_token__: " + data + "~hmac=" + hmac);
            Console.Read();
        }

        private static string HmacSHA256(byte[] key, byte[] data)
        {
            var hash = new HMACSHA256(key);
            return BitConverter.ToString(hash.ComputeHash(data)).Replace("-", "").ToLower();
        }
    }
}
