using SWAPILib;
using System;
using System.Windows.Forms;

namespace SWAPI_App
{
    public partial class StarshipControl : UserControl
    {
        public StarshipControl(Starship starship)
        {
            InitializeComponent();

            mlName.Text = starship.Name;
            mlModel.Text = starship.Model;
            mlStarshipClass.Text = starship.StarshipClass;
            mlManufacturer.Text = starship.Manufacturer;
            mlHyperDriveRating.Text = starship.HyperDriveRating;
            mlMaxAtmoSpeed.Text = starship.MaxAtmospheringSpeed;
        }

        private void StarshipControl_Load(object sender, EventArgs e)
        {

        }
    }
}
