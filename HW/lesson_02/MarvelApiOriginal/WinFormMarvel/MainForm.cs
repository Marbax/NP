using MyBestMarvelLib;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormMarvel.Utils;

/// <summary>
/// Реализовать приложение для просмотра персонажей Marvel. (marvel.com)
/// Приложение должно работать без зависания интерфейса пользователя.
/// </summary>
namespace WinFormMarvel
{
    public partial class MainForm : Form
    {
        private readonly MarvelManager _marvelManager;
        private readonly object _locker = new object();

        public MainForm()
        {
            InitializeComponent();
            _marvelManager = new MarvelManager();
            nudOffset.Maximum = int.MaxValue;
            try
            {
                Icon = Properties.Resources.marvel;
            }
            catch (Exception)
            {
                //there were some problems to add ico to form through gui
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            await Task.Factory.StartNew(() => ClearCharacters());
            _ = Task.Factory.StartNew(() => LoadCharacters((int)nudOffset.Value, (int)nudLimit.Value));
        }

        private void ClearCharacters()
        {
            if (flpCharacters.Controls.Count > 0)
                lock (_locker)
                    flpCharacters.Invoke((MethodInvoker)delegate { flpCharacters.Controls.Clear(); });
        }

        private void LoadCharacters(int offset = 0, int limit = 20)
        {
            var characters = _marvelManager.GetCharacters(offset, limit);
            Parallel.ForEach(characters, (character) =>
            {
                Label lblName = new Label
                {
                    Text = character.Name,
                    Width = 200
                };

                PictureBox pbThumbnail = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 200,
                    Height = 200,
                    Top = 1,
                    Image = ImageUtil.ImageFromUrl(character.Thumbnail)
                };
                Panel pnlCard = new Panel
                {
                    Width = 300,
                    Height = 300
                };
                ToolTip ttDescription = new ToolTip();
                ttDescription.IsBalloon = true;
                ttDescription.ToolTipTitle = "Description:";
                if (!string.IsNullOrEmpty(character.Description))
                    ttDescription.SetToolTip(pbThumbnail, character.Description);
                else
                    ttDescription.SetToolTip(pbThumbnail, "Character has no description :C ");

                if (!character.Thumbnail.Contains("image_not_available"))
                    pbThumbnail.Click += (object sender, EventArgs e) => { System.Diagnostics.Process.Start(character.Thumbnail); };

                pnlCard.Controls.Add(lblName);
                pnlCard.Controls.Add(pbThumbnail);
                flpCharacters.Invoke((MethodInvoker)delegate { flpCharacters.Controls.Add(pnlCard); });
            });
            btnLoad.Invoke((MethodInvoker)delegate { btnLoad.Enabled = true; });
        }

    }
}
