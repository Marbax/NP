using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SWAPILib;

/// <summary>
/// 
/// Сайт: https://swapi.dev/
/// Реализовать графическое приложение для фанатов "Звездных войн" :).
/// Реализовать просмотр характеристик всех персонажей.
/// 
/// Будет плюсом, если будет реализовать механизм пагинации, то есть,
/// чтобы можно было при нажатии на номер страницы просматривать определенное кол-во персонажей.
/// 
/// </summary>
namespace SWAPI_App
{
    public partial class MainForm : MaterialForm
    {
        private SWAPIManager _swapiManager;
        private object _locker = new object();

        public MainForm()
        {
            InitializeComponent();
            MaterialSkinManager skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.DARK;
            SkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            _swapiManager = new SWAPIManager();

            nudOffset.Maximum = int.MaxValue;
        }

        private async void mrBtnLoad_Click(object sender, EventArgs e)
        {
            mrBtnLoad.Enabled = false;
            await Task.Factory.StartNew(() => ClearCharacters());
            _ = Task.Factory.StartNew(() => LoadCharacters((int)nudOffset.Value, (int)nudCount.Value, mCBSaveJson.Checked));
        }

        private void ClearCharacters()
        {
            if (flPanel.Controls.Count > 0)
                lock (_locker)
                    flPanel.Invoke((MethodInvoker)delegate { flPanel.Controls.Clear(); });
        }

        private void LoadCharacters(int offset, int count, bool saveRawJson = false)
        {
            var chars = _swapiManager.GetCharacters(offset, offset + count, saveRawJson);

            Parallel.ForEach(chars, (ch) =>
            {
                CharacterControl chCon = new CharacterControl(ch);
                flPanel.Invoke((MethodInvoker)delegate { flPanel.Controls.Add(chCon); });
            });

            mrBtnLoad.Invoke((MethodInvoker)delegate { mrBtnLoad.Enabled = true; });
        }
    }
}
