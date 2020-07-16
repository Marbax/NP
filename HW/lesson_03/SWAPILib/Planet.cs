using System.Linq;
using System.Text;

namespace SWAPILib
{
    public class Planet
    {
        /// <summary>
        /// name string -- The name of this planet.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// diameter string -- The diameter of this planet in kilometers.
        /// </summary>
        public string Diameter { get; set; }

        /// <summary>
        /// climate string -- The climate of this planet. Comma separated if diverse.
        /// </summary>
        public string Climate { get; set; }

        /// <summary>
        /// population string -- The average population of sentient beings inhabiting this planet.
        /// </summary>
        public string Population { get; set; }

        /// <summary>
        /// terrain string -- The terrain of this planet. Comma separated if diverse.
        /// </summary>
        public string Terrain { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Name);
            sb.Append(" , ").Append(Diameter).Append(" , ").Append(Climate).Append(" , ").Append(Population);
            sb.Append(" , ").Append(Terrain);

            return sb.ToString();
        }
    }

}
