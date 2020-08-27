using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SetTheGame.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame.TutorialPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HypersetTutorialPageFive : Grid
    {
        private TutorialPage tutorialPage;
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public HypersetTutorialPageFive(TutorialPage tutorialPage)
        {
            InitializeComponent();
            this.tutorialPage = tutorialPage; if (Device.RuntimePlatform == Device.iOS)
            {
                startGameButton.TextColor = Color.Black;
            }
            MainGrid.Children.Add(Stylizer.GetStyledLabel(SetTheGame.Resources.Resources_fr.HypersetTutorialPageFive, MainGrid.BackgroundColor), 0, 1);
            startGameButton.Text = SetTheGame.Resources.Resources_fr.StartGame;
        }

        private async void startGameButton_Clicked(object sender, EventArgs e)
        {
            await tutorialPage.StartGame();
        }
    }
}