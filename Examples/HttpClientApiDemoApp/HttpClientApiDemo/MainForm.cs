using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using xkcdComicLib;

namespace HttpClientApiDemo
{
    public partial class MainForm : Form
    {
        private int _maxNum = 0;
        private int _curNum = 0;


        public MainForm()
        {
            InitializeComponent();
            APIHelper.InitializeClient();
        }


        private async Task LoadComic(int comicNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(comicNumber);

            if (comicNumber == 0)
                _maxNum = comicNumber;
            _curNum = comicNumber;

            var uriImgSource = new Uri(comic.Img, UriKind.Absolute);

            pbComicImg.ImageLocation = uriImgSource.ToString();// = new BitmapImage(uriImgSource);
        }
    }
}
