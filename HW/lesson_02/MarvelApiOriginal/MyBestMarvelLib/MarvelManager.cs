using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBestMarvelLib
{
    public class MarvelManager
    {
        private readonly long _ts;
        private readonly string _publicKey;
        private readonly string _hash;
        private readonly string _baseUrl;
        private readonly NetworkManager _networkManager;

        public MarvelManager()
        {
            _ts = MarvelAPIConfig.TimeStamp;
            _publicKey = MarvelAPIConfig.PublicKey;
            _hash = MarvelAPIConfig.Hash;
            _baseUrl = MarvelAPIConfig.BaseURL;
            _networkManager = new NetworkManager();
        }

        public IEnumerable<Character> GetCharacters(int offset = 0, int limit = 20)
        {
            string url = $"{_baseUrl}characters?offset={offset}&limit={limit}&ts={_ts}&apikey={_publicKey}&hash={_hash}";
            string result = _networkManager.GetJson(url);
            Task.Factory.StartNew(() => SaveJsonToFile(result, $"characters_{offset}_{limit}_{DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss")}"));
            IList<Character> characters = new List<Character>();
            JObject jsonCharacters = JObject.Parse(result);
            IList<JToken> results = jsonCharacters["data"]["results"].Children().ToList();
            Parallel.ForEach(results, (data) =>
            {
                Character character = new Character
                {
                    Name = $"{data["name"]}",
                    Thumbnail = $"{data["thumbnail"]["path"]}.{data["thumbnail"]["extension"]}",
                    Description = $"{data["description"]}"
                };
                characters.Add(character);
            });
            return characters;
        }

        private static void SaveJsonToFile(string jsonContent, string fName)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter($"{fName.Trim()}.json"))
            {
                sw.Write(jsonContent);
            }
        }
    }
}
