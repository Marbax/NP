using System;
using System.Linq;
using System.Text;

namespace SWAPILib
{
    public class Film
    {
        /// <summary>
        /// title string -- The title of this film
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// episode_id integer -- The episode number of this film.
        /// </summary>
        public int EpisodeId { get; set; }

        /// <summary>
        /// opening_crawl string -- The opening paragraphs at the beginning of this film.
        /// </summary>
        public string OpeningCrawl { get; set; }

        /// <summary>
        /// director string -- The name of the director of this film.
        /// </summary>
        public string Director { get; set; }

        /// <summary>
        /// release_date date -- The ISO 8601 date format of film release at original creator country.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Title);
            sb.Append(" , ").Append(EpisodeId).Append(" , ");
            sb.Append(OpeningCrawl).Append(" , ").Append(Director).Append(" , ").Append(ReleaseDate);

            return sb.ToString();
        }
    }

}
