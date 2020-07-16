using SWAPILib;
using System.Windows.Forms;

namespace SWAPI_App
{
    public partial class SpecieControl : UserControl
    {
        public SpecieControl(Specie specie)
        {
            InitializeComponent();

            mlName.Text = specie.Name;
            mlClassification.Text = specie.Classification;
            mlDesignation.Text = specie.Designation;
            mlAverageLifespan.Text = specie.AverageLifespan;
            mlLanguage.Text = specie.Language;
        }
    }
}
