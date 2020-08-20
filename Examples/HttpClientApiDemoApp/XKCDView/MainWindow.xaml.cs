using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using xkcdComicLib;

namespace XKCDView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _maxNum = 0;
        private int _curNum = 0;
        Random rnd = new Random();


        public MainWindow()
        {
            InitializeComponent();
            APIHelper.InitializeClient();
        }

        private void Button_Prev_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Random_Click(object sender, RoutedEventArgs e)
        {
            await LoadComic(rnd.Next(_maxNum));
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private async Task LoadComic(int comicNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(comicNumber);

            if (comicNumber == 0)
                _maxNum = comicNumber;
            _curNum = comicNumber;

            var uriImgSource = new Uri(comic.Img, UriKind.Absolute);

            imgComic.Source = new BitmapImage(uriImgSource);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadComic();
        }
    }
}
