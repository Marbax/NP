using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWAPILib
{
    public class Character
    {
        /// <summary>
        /// birth_year string -- The birth year of the person, using the in-universe standard of BBY or ABY - Before the Battle of Yavin or After the Battle of Yavin. The Battle of Yavin is a battle that occurs at the end of Star Wars episode IV: A New Hope.
        /// </summary>
        public string BirthYear { get; set; }

        /// <summary>
        /// eye_color string -- The eye color of this person. Will be "unknown" if not known or "n/a" if the person does not have an eye.
        /// </summary>
        public string EyeColor { get; set; }

        /// <summary>
        /// films array -- An array of film resource URLs that this person has been in.
        /// </summary>
        public List<Film> Films { get; set; }

        /// <summary>
        /// gender string -- The gender of this person. Either "Male", "Female" or "unknown", "n/a" if the person does not have a gender.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// hair_color string -- The hair color of this person. Will be "unknown" if not known or "n/a" if the person does not have hair.
        /// </summary>
        public string HairColor { get; set; }

        /// <summary>
        /// height string -- The height of the person in centimeters.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// homeworld string -- The URL of a planet resource, a planet that this person was born on or inhabits.
        /// </summary>
        public Planet Homeworld { get; set; }

        /// <summary>
        /// mass string -- The mass of the person in kilograms.
        /// </summary>
        public string Mass { get; set; }

        /// <summary>
        /// name string -- The name of this person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// skin_color string -- The skin color of this person.
        /// </summary>
        public string SkinColor { get; set; }

        /// <summary>
        /// created string -- the ISO 8601 date format of the time that this resource was created.
        /// </summary>
        //public string Created { get; set; }

        /// <summary>
        /// edited string -- the ISO 8601 date format of the time that this resource was edited.
        /// </summary>
        //public string Edited { get; set; }

        /// <summary>
        /// species array -- An array of species resource URLs that this person belongs to.
        /// </summary>
        public List<Specie> Species { get; set; }

        /// <summary>
        /// starships array -- An array of starship resource URLs that this person has piloted.
        /// </summary>
        public List<Starship> Starships { get; set; }

        /// <summary>
        /// url string -- the hypermedia URL of this resource.
        /// </summary>
        //public string Url { get; set; }

        /// <summary>
        /// vehicles array -- An array of vehicle resource URLs that this person has piloted.
        /// </summary>
        //public List<Vehicle> Vehicles { get; set; }

        public override string ToString()
        {
            StringBuilder sbShips = new StringBuilder();
            if (Starships.Count > 0)
                sbShips.Append("{\n").Append(Starships.Select(f => f.ToString()).Aggregate((f, s) => f + " ,\n " + s)).Append("\n}");
            else
                sbShips.Append("no ships");

            StringBuilder sbSpecies = new StringBuilder();
            if (Species.Count > 0)
                sbSpecies.Append("{\n").Append(Species.Select(f => f.ToString()).Aggregate((f, s) => f + " ,\n " + s)).Append("\n}");
            else
                sbSpecies.Append("no species");


            StringBuilder sb = new StringBuilder(BirthYear);
            sb.Append(" , ").Append(EyeColor).Append(" , ").Append($"[\n{Films?.Select(f => f?.ToString()).Aggregate((f, s) => f + " ,\n " + s)}\n] , ");
            sb.Append(Gender).Append(" , ").Append(HairColor).Append(" , ").Append(Height).Append(" , {").Append(Homeworld.ToString()).Append("} , ");
            sb.Append(Mass).Append(" , ").Append(Name).Append(" , ").Append(SkinColor).Append($" , [\n{sbShips.ToString()}\n]");
            sb.Append($" , [\n{sbSpecies.ToString()}\n]");

            return sb.ToString();
        }
    }

}
