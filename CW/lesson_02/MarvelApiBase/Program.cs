using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApi
{
    class Program
    {
        static void Main(string[] args)
        {

            string bUrl = "http://gateway.marvel.com/v1/public/";

            string charUrl = $"{bUrl}characters?";


            Console.WriteLine(SimpleReq(charUrl));
            //File.WriteAllText("charUrl", charUrl);
            Console.ReadLine();
        }

        static string SimpleReq(string url)
        {
            string pubKey = "8c144a46061b17084f6fed384e7acbe19";
            string privKey = "64788cc98a81cc76215142964ecb31f5aa1b80ffe";
            long ts = DateTimeOffset.UtcNow.Second;
            string hash = md5(ts, privKey, pubKey);

            try
            {
                WebClient client = new WebClient();
                string finalUrl = $"ts={ts}&apikey={pubKey}&hash={hash}";
                //string finalUrl = $"limit=50&offset=50&ts={ts}&apikey={pubKey}&hash={hash}";
                return client.DownloadString(url);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        static string md5(long ts, string privkey, string pubKey)
        {
            string hash = $"{ts}{privkey}{pubKey}";
            MD5 cryptor = MD5.Create();
            byte[] bytes = cryptor.ComputeHash(Encoding.Default.GetBytes(hash));

            string md5 = BitConverter.ToString(bytes).ToLower().Replace("-", "");
            Console.WriteLine(md5);

            return md5;
        }


    }



}
