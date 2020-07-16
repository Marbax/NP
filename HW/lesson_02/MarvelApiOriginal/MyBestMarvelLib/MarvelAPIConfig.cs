using System;
using System.Security.Cryptography;
using System.Text;

namespace MyBestMarvelLib
{
    public static class MarvelAPIConfig
    {
        public static string PublicKey => "8c144a46061b7084f6fed384e7acbe19";
        private static string _privateKey => "64788cc98a8cc76215142964ecb31f5aa1b80ffe";
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
