using System;
using System.Security.Cryptography;
using System.Text;

namespace MyBestMarvelLib
{
    public static class MarvelAPIConfig
    {
        public static string PublicKey => "your_key_from_https://developer.marvel.com/account";
        private static string _privateKey => "your_key_from_https://developer.marvel.com/account";
        public static long TimeStamp => DateTimeOffset.UtcNow.Second;
        public static string Hash => Md5(TimeStamp, _privateKey, PublicKey);

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
