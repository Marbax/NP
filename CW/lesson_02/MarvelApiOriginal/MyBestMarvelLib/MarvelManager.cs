using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestMarvelLib
{
    public class MarvelManager
    {
        private readonly long ts;
        private readonly string publicKey;
        private readonly string hash;
        private readonly string baseUrl;
        private NetworkManager networkManager;
        public MarvelManager()
        {
            ts = MarvelAPIConfig.TimeStamp;
            publicKey = MarvelAPIConfig.PublicKey;
            hash = MarvelAPIConfig.Hash;
            baseUrl = MarvelAPIConfig.BaseURL;
            networkManager = new NetworkManager();
        }
        public IEnumerable<Character> GetCharacters()
        {
            string url = $"{baseUrl}characters?offset=1000&ts={ts}&apikey={publicKey}&hash={hash}";
            string result = networkManager.GetJson(url);
            IList<Character> characters = new List<Character>();
            JObject jsonCharacters = JObject.Parse(result);
            IList<JToken> results = jsonCharacters["data"]["results"].Children().ToList();
            foreach (var data in results)
            {
                Character character = new Character
                {
                    Name = $"{data["name"]}",
                    Thumbnail = $"{data["thumbnail"]["path"]}.{data["thumbnail"]["extension"]}"
                };
                characters.Add(character);
            }
            return characters;
        }
    }
}
