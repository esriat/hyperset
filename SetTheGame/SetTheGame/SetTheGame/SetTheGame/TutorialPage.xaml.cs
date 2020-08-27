using SetTheGame.TutorialPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SetTheGame.Model;
using SetTheGame.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialPage : ContentPage
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        private int nbEpreuve = 0;
        private View shown;
        private GameModes gamemode;
        public TutorialPage(GameModes gamemode)
        {
            InitializeComponent();
            this.gamemode = gamemode;
            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            if(gamemode == GameModes.Set)
            {
                shown = new TutorialPageOne(this);
            }
            else
            {
                shown = new HypersetTutorialPageOne(this);
            }
            MainGrid.Children.Add(shown, 0, 0);
        }
        
        public void NextPage()
        {
            nbEpreuve++;
            ShowPage();
        }

        public void PreviousPage()
        {
            nbEpreuve--;
            ShowPage();
        }

        public void ReloadPage()
        {
            ShowPage();
        }

        private void ShowPage()
        {
            MainGrid.Children.Remove(shown);
            if(gamemode == GameModes.Set)
            {
                switch (nbEpreuve)
                {
                    case 0: shown = new TutorialPageOne(this);  break;
                    case 1: shown = new TutorialPageTwo(this); break;
                    case 2: shown = new TutorialPageThree(this); break;
                    case 3: shown = new TutorialPageFour(this); break;
                    case 4: shown = new TutorialPageFive(this); break;
                    case 5: shown = new TutorialPageSix(this); break;
                    default: nbEpreuve = 0; ShowPage(); break;
                }
            }
            else
            {
                switch (nbEpreuve)
                {
                    case 0: shown = new HypersetTutorialPageOne(this); break;
                    case 1: shown = new HypersetTutorialPageTwo(this); break;
                    case 2: shown = new HypersetTutorialPageThree(this); break;
                    case 3: shown = new HypersetTutorialPageFour(this); break;
                    case 4: shown = new HypersetTutorialPageFive(this); break;
                    default: nbEpreuve = 0; ShowPage(); break;
                }
            }

            MainGrid.Children.Add(shown, 0, 0);
        }

        public async Task StartGame()
        {
            IOTutorial tuto = IOTutorial.Instance;
            tuto.TutorialDone(gamemode);
            await Navigation.PushAsync(new MainPage(Partie.Solo, gamemode, Difficulties.Begginer, GameTypes.Score, Resources_fr.Player + " 1", 0));
        }
    }
}