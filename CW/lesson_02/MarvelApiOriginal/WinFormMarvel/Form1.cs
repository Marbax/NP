using MyBestMarvelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormMarvel.Utils;

namespace WinFormMarvel
{
    public partial class Form1 : Form
    {
        MarvelManager marvelManager;
        public Form1()
        {
            InitializeComponent();
            marvelManager = new MarvelManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var characters = marvelManager.GetCharacters();
            foreach (var character in characters)
            {
                Label lblName = new Label
                {
                    Text = character.Name         
                };

                PictureBox pbThumbnail = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 200,
                    Height = 200,
                    Image = ImageUtil.ImageFromUrl(character.Thumbnail)
                };
                Panel pnlCard = new Panel
                {
                    Width = 300,
                    Height = 300
                };
                pnlCard.Controls.Add(lblName);
                pnlCard.Controls.Add(pbThumbnail);
                flpCharacters.Controls.Add(pnlCard);
            

            }
        }
    }
}
