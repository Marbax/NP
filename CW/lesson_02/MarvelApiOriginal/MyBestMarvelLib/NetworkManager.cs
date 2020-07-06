using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyBestMarvelLib
{
    public class NetworkManager
    {
        public string GetJson(string url) => new WebClient().DownloadString(url);
        
    }
}
