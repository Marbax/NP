using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyBestMarvelLib
{
    public static class MarvelAPIConfig
    {
        public static string PublicKey => "";
        private static string PrivateKey => "";
        public static long TimeStamp => DateTimeOffset.UtcNow.Second;
        public static string Hash => Md5(TimeStamp, PrivateKey, PublicKey);

        public static string BaseURL => "http://gateway.marvel.com/v1/public/";

        private static string Md5(long ts, string privateKey, string publicKey)
        {
            string stringToHash = $"{ts}{privateKey}{publicKey}";
            MD5 cryptor = MD5.Create();
            byte[] bytes = cryptor.ComputeHash(Encoding.Default.GetBytes(stringToHash));
            string result = BitConverter.ToString(bytes).ToLower().Replace("-", "");
            return result;
        }



    }
}
