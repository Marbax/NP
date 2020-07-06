using System.Drawing;
using System.IO;
using System.Net;

namespace WinFormMarvel.Utils
{
    internal class ImageUtil
    {
        public static Image ImageFromUrl(string url)
        {
            byte[] imageBytes = new WebClient().DownloadData(url);
            Image img = null;
            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
                img = Image.FromStream(stream);
            }
            return img;
        }
    }
}
