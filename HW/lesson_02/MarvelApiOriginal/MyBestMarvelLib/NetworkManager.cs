using System.Net;

namespace MyBestMarvelLib
{
    public class NetworkManager
    {
        public string GetJson(string url) => new WebClient().DownloadString(url);
    }
}
