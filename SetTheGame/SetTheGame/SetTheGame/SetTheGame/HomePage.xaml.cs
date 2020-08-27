using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections;
using System.Globalization;
using System.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SetTheGame.Resources;
using SetTheGame.Model;

namespace SetTheGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        ResourcesManager Resources_fr;
        public HomePage()
        {
            InitializeComponent();
            Resources_fr = ResourcesManager.Instance;
            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            if (Device.RuntimePlatform == Device.iOS)
            {
                ReplaySetTutorialButton.TextColor = Xamarin.Forms.Color.Black;
                ReplayHypersetTutorialButton.TextColor = Xamarin.Forms.Color.Black;
                playButton.TextColor = Xamarin.Forms.Color.Black;
                optionsButton.TextColor = Xamarin.Forms.Color.Black;
                scoresButton.TextColor = Xamarin.Forms.Color.Black;
            }
            IOTutorial tut = IOTutorial.Instance;

            SetTexts();
        }

        public async void StartGame(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GameModeMenu());
        }
        public async void OpenOptions(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OptionPage());
        }
        
        public async void ShowScores(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LeaderboardDisplayer());
        }

        private async void ReplaySetTutorialButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TutorialPage(GameModes.Set));
        }

        private async void ReplayHypersetTutorialButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TutorialPage(GameModes.Hyperset));
        }

        protected override void OnAppearing()
        {
            SetTexts();
            base.OnAppearing();
        }

        private void SetTexts()
        {
            ReplaySetTutorialButton.Text = Resources_fr.SetTutorial;
            ReplayHypersetTutorialButton.Text = Resources_fr.HypersetTutorial;
            playButton.Text = Resources_fr.Play;
            scoresButton.Text = Resources_fr.ShowScores;
        }
    }
}