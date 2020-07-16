using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SWAPILib;

namespace SWAPI_App
{
    public partial class CharacterControl : UserControl
    {
        public CharacterControl(Character character)
        {
            InitializeComponent();

            mlName.Text = character.Name;
            mlGender.Text = character.Gender;
            mlBirthYear.Text = character.BirthYear;
            mlHeight.Text = character.Height;
            mlMass.Text = character.Mass;
            mlHairColor.Text = character.HairColor;
            mlEyeColor.Text = character.EyeColor;
            mlSkinColor.Text = character.SkinColor;

            mlHomeName.Text = character.Homeworld.Name;
            mlHomeDiameter.Text = character.Homeworld.Diameter;
            mlHomeClimate.Text = character.Homeworld.Climate;
            mlHomePopulation.Text = character.Homeworld.Population;
            mlHomeTerrain.Text = character.Homeworld.Terrain;

            foreach (var spec in character.Species)
                flpSpecies.Controls.Add(new SpecieControl(spec));

            foreach (var ship in character.Starships)
                flpStarships.Controls.Add(new StarshipControl(ship));

            foreach (var film in character.Films)
                flpFilms.Controls.Add(new FilmControl(film));
        }
    }
}
