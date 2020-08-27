using SetTheGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UCGameManager : Grid
    {
        private View shown;
        private readonly GameTypes type;
        readonly Partie partie;
        public UCGameManager(Partie partie, GameModes mode, Difficulties difficulty, GameTypes type, string username, int timeToPlay)
        {
            InitializeComponent();
            this.type = type;
            shown = new SoloGameSet(this, mode, difficulty, type, username, timeToPlay);
            MainGrid.Children.Add(shown, 0, 0);
            this.partie = partie;
        }
        public UCGameManager(int nbplayer,Partie partie, GameModes mode, List<string> usernames)
        {
            InitializeComponent();
            shown = new MultiGame(this, mode, nbplayer, usernames);
            MainGrid.Children.Add(shown, 0, 0);
            this.partie = partie;
        }

        public void ShowScores(List<Player> results)
        {
            MainGrid.Children.Remove(shown);
            shown = new UCEndGameScoreDisplayer(results, type, partie);
            MainGrid.Children.Add(shown, 0, 0);
        }
    }
}