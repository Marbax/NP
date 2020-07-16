using SWAPILib;
using System.Windows.Forms;

namespace SWAPI_App
{
    public partial class FilmControl : UserControl
    {
        public FilmControl(Film film)
        {
            InitializeComponent();
            mlTitle.Text = film.Title;
            mlEpisode.Text = film.EpisodeId.ToString();
            mlReleaseDate.Text = film.ReleaseDate.ToShortDateString();
            mlDirector.Text = film.Director;
            rtbOpeningCrawl.Text = film.OpeningCrawl;
            if (string.IsNullOrEmpty(rtbOpeningCrawl.Text))
                rtbOpeningCrawl.Dispose();
        }
    }
}
