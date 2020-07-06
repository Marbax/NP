using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinFormMarvel.Utils
{
    class ImageUtil
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
