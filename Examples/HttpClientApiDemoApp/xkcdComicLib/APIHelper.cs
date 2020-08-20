using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace xkcdComicLib
{
    public static class APIHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri("http://xkcd.com/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }
    }

    public static class ComicProcessor
    {
        public static int MaxComicNumber { get; set; }

        public static async Task<XKCDComicModel> LoadComic(int comicNumber = 0)
        {
            string url = "";

            if (comicNumber > 0)
                url = $"https://xkcd.com/{comicNumber}/info.0.json";
            else
                url = $"https://xkcd.com/info.0.json";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    XKCDComicModel comic = await response.Content.ReadAsAsync<XKCDComicModel>();

                    if (comicNumber == 0)
                        MaxComicNumber = comic.Num;

                    return comic;
                }
                else
                    throw new System.Exception(response.ReasonPhrase + ":" + response.StatusCode);
            }
        }
    }

    public class XKCDComicModel
    {
        public string Title { get; set; }
        public int Num { get; set; }
        public string Alt { get; set; }
        public string Img { get; set; }
    }
}
