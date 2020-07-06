using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json.Linq;
using MyBestMarvelLib;

namespace MarvelApi
{
    class Program
    {
     
        static void Main(string[] args)
        {

            MarvelManager marvelManager = new MarvelManager();
            var characters = marvelManager.GetCharacters();
            foreach (var character in characters)
            {
                Console.WriteLine($"{character.Name}\n{character.Thumbnail}\n\n");
            }

            




            //Console.WriteLine(result);
            //File.WriteAllText("charac.json", result);
        }
    }
}
