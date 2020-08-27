using SetTheGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace SetTheGame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage(Partie partie, GameModes gamemode, Difficulties difficulty, GameTypes type, string username, int timeToPlay) : this()

        {
            MainGrid.Children.Add(new UCGameManager(partie, gamemode, difficulty, type, username, timeToPlay), 0, 0);
        }

        public MainPage(int nbjoueurs, Partie partie, GameModes gamemode, List<string> usernames) : this()
        {
            if (partie.Equals(Partie.Solo))
            {
                throw new Exception("Wrong operation - Playing set in a solo mode do not requires a nb of player");
            }
            MainGrid.Children.Add(new UCGameManager(nbjoueurs ,partie, gamemode, usernames), 0, 0);
        }

        private MainPage()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }
    }
}