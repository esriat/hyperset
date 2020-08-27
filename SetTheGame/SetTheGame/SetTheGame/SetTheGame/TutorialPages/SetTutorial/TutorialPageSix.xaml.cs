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
    public partial class TutorialPageSix : Grid
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        private TutorialPage tutorialPage;
        public TutorialPageSix(TutorialPage tutorialPage)
        {
            InitializeComponent();
            this.tutorialPage = tutorialPage;
            if (Device.RuntimePlatform == Device.iOS)
            {
                startGameButton.TextColor = Color.Black;
            }
            startGameButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            startGameButton.Margin = 5;
            startGameButton.CornerRadius = 10;
            MainGrid.Children.Add(Stylizer.GetStyledLabel(SetTheGame.Resources.Resources_fr.TutorialPageSixPartOne, MainGrid.BackgroundColor), 0, 1);
            startGameButton.Text = SetTheGame.Resources.Resources_fr.StartGame;
        }

        private async void startGameButton_Clicked(object sender, EventArgs e)
        {
            await tutorialPage.StartGame();
        }
    }
}