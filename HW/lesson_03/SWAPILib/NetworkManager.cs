namespace SWAPILib
{
    public class NetworkManager
    {
        public string GetJson(string url) => new System.Net.WebClient().DownloadString(url);
    }
}
