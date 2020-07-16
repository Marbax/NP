using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAPILib
{
    /// <summary>
    /// species - aren't work correctly ,droids liads , humans aren't
    /// there mb same thing with another inner lists
    /// </summary>
    public class SWAPIManager
    {
        private readonly string _baseUrl = "https://swapi.dev/api/";
        private readonly NetworkManager _networkManager;

        public SWAPIManager()
        {
            _networkManager = new NetworkManager();
        }

        public IEnumerable<Character> GetCharacters(int startId, int endId, bool saveRaw = false)
        {
            string url = $"{_baseUrl}people/";
            List<string> urls = new List<string>();
            for (int i = startId; i <= endId; i++)
                urls.Add($"{url}{i}/");

            IList<Character> characters = new List<Character>();
            Parallel.ForEach(urls, (data) =>
            {
                try
                {
                    characters.Add(GetCharacter(data, saveRaw));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex + "\n\n");
                }
            });

            return characters;
        }
        public Character GetCharacter(string url, bool saveRaw = false)
        {
            string result = _networkManager.GetJson(url);

            if (saveRaw)
                Task.Factory.StartNew(() => SaveJsonToFile(result, $"character_{url.Substring(21).Replace('/', '_')}_{DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss")}"));

            JObject jsonCharacter = JObject.Parse(result);
            JToken data = jsonCharacter.SelectToken("");

            Character character = new Character
            {
                BirthYear = $"{data["birth_year"]}",
                EyeColor = $"{data["eye_color"]}",
                Films = GetFilms(saveRaw, data["films"].Children().ToList().Select(i => i.ToString()).ToArray()).ToList(),
                Gender = $"{data["gender"]}",
                HairColor = $"{data["hair_color"]}",
                Height = $"{data["height"]}",
                Homeworld = GetPlanet($"{data["homeworld"]}", saveRaw),
                Mass = $"{data["mass"]}",
                Name = $"{data["name"]}",
                SkinColor = $"{data["skin_color"]}",
                Starships = GetStarships(saveRaw, data["starships"].Children().ToList().Select(i => i.ToString()).ToArray()).ToList(),
                Species = GetSpecies(saveRaw, data["species"].Children().ToList().Select(i => i.ToString()).ToArray()).ToList()
            };

            return character;
        }

        public IEnumerable<Character> GetCharacters(string searchFor = "none", bool saveRaw = false)
        {
            string url;

            if (!string.IsNullOrEmpty(searchFor) && searchFor != "none")
                url = $"{_baseUrl}people/?search={searchFor}";
            else
                url = $"{_baseUrl}people/";

            string result = _networkManager.GetJson(url);

            if (saveRaw)
                Task.Factory.StartNew(() => SaveJsonToFile(result, $"characters_{DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss")}"));

            IList<Character> characters = new List<Character>();

            JObject jsonCharacters = JObject.Parse(result);
            IList<JToken> results = jsonCharacters["results"].Children().ToList();
            Parallel.ForEach(results, (data) =>
            {
                Character character = new Character
                {
                    BirthYear = $"{data["birth_year"]}",
                    EyeColor = $"{data["eye_color"]}",
                    Films = GetFilms(saveRaw, data["films"].Children().ToList().Select(i => i.ToString()).ToArray()).ToList(),
                    Gender = $"{data["gender"]}",
                    HairColor = $"{data["hair_color"]}",
                    Height = $"{data["height"]}",
                    Homeworld = GetPlanet($"{data["homeworld"]}", saveRaw),
                    Mass = $"{data["mass"]}",
                    Name = $"{data["name"]}",
                    SkinColor = $"{data["skin_color"]}",
                    Starships = GetStarships(saveRaw, data["starships"].Children().ToList().Select(i => i.ToString()).ToArray()).ToList(),
                    Species = GetSpecies(saveRaw, data["species"].Children().ToList().Select(i => i.ToString()).ToArray()).ToList()
                };
                characters.Add(character);
            });

            return characters;
        }

        public IEnumerable<Film> GetFilms(bool saveRaw = false, params string[] url)
        {
            IList<Film> films = new List<Film>();

            Parallel.ForEach(url, (data) =>
            {
                films.Add(GetFilm(data, saveRaw));
            });

            return films;
        }
        public Film GetFilm(string url, bool saveRaw = false)
        {
            string result = _networkManager.GetJson(url);

            if (saveRaw)
                Task.Factory.StartNew(() => SaveJsonToFile(result, $"films_{url.Substring(21).Replace('/', '_')}_{DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss")}"));

            JObject jsonFilms = JObject.Parse(result);
            JToken data = jsonFilms.SelectToken("");

            Film fm = new Film
            {
                Title = $"{data["title"]}",
                EpisodeId = (int)data["episode_id"],
                Director = $"{data["director"]}",
                ReleaseDate = (DateTime)data["release_date"]
            };

            return fm;
        }

        public IEnumerable<Starship> GetStarships(bool saveRaw = false, params string[] url)
        {
            IList<Starship> starships = new List<Starship>();

            Parallel.ForEach(url, (data) =>
            {
                try
                {
                    starships.Add(GetStarship(data, saveRaw));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex + "\n\n");
                }
            });

            return starships;
        }
        public Starship GetStarship(string url, bool saveRaw = false)
        {
            string result = _networkManager.GetJson(url);

            if (saveRaw)
                Task.Factory.StartNew(() => SaveJsonToFile(result, $"films_{url.Substring(21).Replace('/', '_')}_{DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss")}"));

            JObject jsonStarship = JObject.Parse(result);
            JToken data = jsonStarship.SelectToken("");

            Starship starship = new Starship
            {
                Name = $"{data["name"]}",
                Model = $"{data["model"]}",
                StarshipClass = $"{data["starship_class"]}",
                Manufacturer = $"{data["manufacturer"]}",
                MaxAtmospheringSpeed = $"{data["max_atmosphering_speed"]}",
                HyperDriveRating = $"{data["hyperdrive_rating"]}"
            };

            return starship;
        }

        public Planet GetPlanet(string url, bool saveRaw = false)
        {
            string result = _networkManager.GetJson(url);

            if (saveRaw)
                Task.Factory.StartNew(() => SaveJsonToFile(result, $"films_{url.Substring(21).Replace('/', '_')}_{DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss")}"));

            JObject jsonPlanet = JObject.Parse(result);
            JToken data = jsonPlanet.SelectToken("");

            Planet planet = new Planet
            {
                Name = $"{data["name"]}",
                Diameter = $"{data["diameter"]}",
                Climate = $"{data["climate"]}",
                Population = $"{data["population"]}",
                Terrain = $"{data["terrain"]}"
            };

            return planet;
        }

        public IEnumerable<Specie> GetSpecies(bool saveRaw = false, params string[] url)
        {
            IList<Specie> species = new List<Specie>();

            Parallel.ForEach(url, (data) =>
            {
                try
                {
                    species.Add(GetSpecie(data, saveRaw));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex + "\n\n");
                }
            });

            return species;
        }
        public Specie GetSpecie(string url, bool saveRaw = false)
        {
            string result = _networkManager.GetJson(url);

            if (saveRaw)
                Task.Factory.StartNew(() => SaveJsonToFile(result, $"films_{url.Substring(21).Replace('/', '_')}_{DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss")}"));

            JObject jsonSpecie = JObject.Parse(result);
            JToken data = jsonSpecie.SelectToken("");

            Specie specie = new Specie
            {
                Name = $"{data["name"]}",
                Classification = $"{data["classification"]}",
                Designation = $"{data["designation"]}",
                AverageLifespan = $"{data["average_lifespan"]}",
                Language = $"{data["language"]}"
            };

            return specie;
        }

        private static void SaveJsonToFile(string jsonContent, string fName)
        {
            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter($"{fName.Trim()}.json"))
                {
                    sw.Write(jsonContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

}
