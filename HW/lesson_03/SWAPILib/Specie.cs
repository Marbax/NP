using System.Linq;
using System.Text;

namespace SWAPILib
{
    public class Specie
    {
        /// <summary>
        /// name string -- The name of this species.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// classification string -- The classification of this species, such as "mammal" or "reptile".
        /// </summary>
        public string Classification { get; set; }

        /// <summary>
        /// designation string -- The designation of this species, such as "sentient".
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// average_lifespan string -- The average lifespan of this species in years.
        /// </summary>
        public string AverageLifespan { get; set; }

        /// <summary>
        /// language string -- The language commonly spoken by this species.
        /// </summary>
        public string Language { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Name);
            sb.Append(" , ").Append(Classification).Append(" , ").Append(Designation).Append(" , ").Append(AverageLifespan);
            sb.Append(" , ").Append(Language);

            return sb.ToString();
        }
    }

}
