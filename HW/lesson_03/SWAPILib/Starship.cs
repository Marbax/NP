using System.Linq;
using System.Text;

namespace SWAPILib
{
    public class Starship
    {
        /// <summary>
        /// name string -- The name of this starship. The common name, such as "Death Star".
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// model string -- The model or official name of this starship. Such as "T-65 X-wing" or "DS-1 Orbital Battle Station".
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// starship_class string -- The class of this starship, such as "Starfighter" or "Deep Space Mobile Battlestation"
        /// </summary>
        public string StarshipClass { get; set; }

        /// <summary>
        /// manufacturer string -- The manufacturer of this starship. Comma separated if more than one.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// max_atmosphering_speed string -- The maximum speed of this starship in the atmosphere. "N/A" if this starship is incapable of atmospheric flight.
        /// </summary>
        public string MaxAtmospheringSpeed { get; set; }

        /// <summary>
        /// hyperdrive_rating string -- The class of this starships hyperdrive.
        /// </summary>
        public string HyperDriveRating { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Name);
            sb.Append(" , ").Append(Model).Append(" , ").Append(StarshipClass).Append(" , ").Append(Manufacturer);
            sb.Append(" , ").Append(MaxAtmospheringSpeed).Append(" , ").Append(HyperDriveRating);

            return sb.ToString();
        }
    }

}
