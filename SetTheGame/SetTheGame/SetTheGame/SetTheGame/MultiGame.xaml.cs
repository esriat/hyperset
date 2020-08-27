using SetTheGame.Model;
using SetTheGame.Model.Managers;
using SetTheGame.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiGame : Grid, Game
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public AbstractMultiGameManager manager;
        private UCGameManager mainPage;
        private Board board;
        private Button askButton;
        private Label scoreLabel = new Label();
        private int nbplayer;
        private List<Button> playersButton = new List<Button>();
        public bool isPlaying = false;
        private int counter;
        private Guid currentPlayer;
        private Dictionary<Guid,Player> players = new Dictionary<Guid, Player>();
        private int SecondsElapsed { get; set; }
        private List<string> usernames;
        private int gameTime = 0;
        private bool isOkay = true;
        public MultiGame(UCGameManager mainPage, GameModes gamemode, int nbplayer, List<string> usernames)
        {
            InitializeComponent();
            this.usernames = usernames;
            scoreLabel.Text = "";
            scoreLabel.VerticalTextAlignment = TextAlignment.Start;
            if (MainGrid.BackgroundColor == Xamarin.Forms.Color.WhiteSmoke)
            {
                scoreLabel.TextColor = Xamarin.Forms.Color.Black;
            }
            else
            {
                scoreLabel.TextColor = Xamarin.Forms.Color.White;
            }
            this.nbplayer = nbplayer;
            for (int i = 0; i < nbplayer; i++)
            {
                Button b = new Button();
                b.Text = usernames[i];
                b.FontSize = 20;
                b.TextColor = Xamarin.Forms.Color.Black;
                b.Clicked += makeTurn;
                b.BackgroundColor = Xamarin.Forms.Color.Aqua;
                b.Margin = 5;
                b.CornerRadius = 10;
                playersButton.Add(b);
                players.Add(b.Id, new Player());
                scoreLabel.Text += usernames[i] + ": 0\r\n";
                if(nbplayer == 2 && i == 0)
                {
                    b.Rotation = 180;
                }
                else if(nbplayer == 3 && (i == 0 || i == 2))
                {
                    b.Rotation = 180;
                }
                else if(i == 0 || i == 3)
                {
                    b.Rotation = 180;
                }
            }
            // Il va falloir qu'on donne d'une manière ou d'une autre le nom de tous les joueurs.
            // En attendant, je met leur nom à Ano pour qu'on puisse avoir un nom dans le leaderboard
            foreach(KeyValuePair<Guid, Player> kvp in players)
            {
                kvp.Value.Name = "Anonymous";
            }
            List<Player> playersList = players.Values.ToList();
            int k = 0;
            playersList.ForEach(p => { p.Name = usernames[k];k++;});
            if (gamemode == GameModes.Set)
            {
                manager = new SetMultiGameManager(playersList);
                askButton = new Button();
                askButton.Text = Resources_fr.AskButtonText;
                askButton.Clicked += askButton_Clicked;
                downGrid.Children.Add(askButton, 1, 0);
                askButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
                askButton.Margin = 5;
                askButton.CornerRadius = 10;
                if (Device.RuntimePlatform == Device.iOS)
                {
                    askButton.TextColor = Xamarin.Forms.Color.Black;
                }
            }
            else if (gamemode == GameModes.Hyperset)
            {
                manager = new HypersetMultiGameManager(playersList);
            }
            this.mainPage = mainPage;            
            manager.StartGame();
            board = new Board(this, manager.GetOnBoard());
            MainGrid.Children.Add(board, 0, 1);
            upGrid.Children.Add(scoreLabel, 1, 0);

            switch (nbplayer)
            {
                case 1:
                    throw new Exception("Wrong operation - multiplayer can't have only one player");
                case 2:
                    upGrid.Children.Add(playersButton[0], 0, 0);
                    downGrid.Children.Add(playersButton[1], 2, 0);
                    break;
                case 3:
                    upGrid.Children.Add(playersButton[0], 0, 0);
                    downGrid.Children.Add(playersButton[1], 2, 0);
                    upGrid.Children.Add(playersButton[2], 2, 0);
                    break;
                case 4:
                    upGrid.Children.Add(playersButton[0], 0, 0);
                    downGrid.Children.Add(playersButton[1], 2, 0);
                    downGrid.Children.Add(playersButton[2], 0, 0);
                    upGrid.Children.Add(playersButton[3], 2, 0);
                    break;
            }

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                gameTime++;
                return isOkay;
            });
        }

        public void Answer(Deck answer)
        {
            try
            {
                bool isCorrect = manager.TryAnswer(answer, players[currentPlayer]);
                if (isCorrect)
                {
                    Debug.WriteLine("Right solution");
                    Deck toUpdate = manager.GetUpdated();
                    SetScore(currentPlayer);
                    if (manager.HasToEnd())
                    {
                        EndGame();
                    }
                    board.SolutionAnswer(toUpdate);
                    SetAskButtonText(true);
                }
                else
                {
                    Debug.WriteLine("Wrong solution");
                    SetScore(currentPlayer);
                    board.SolutionAnswer();
                }
                counter = 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        public void EndGame()
        {
            manager.SetPlayerTimes(gameTime);
            isOkay = false;
            mainPage.ShowScores(manager.EndGame());
        }

        public Deck GetAnswer()
        {
            return manager.GetAnswer();
        }

        public Deck GetOnBoard()
        {
            return manager.GetOnBoard();
        }

        public bool HasToEnd()
        {
            return manager.HasToEnd();
        }

        public int NumberOfCardsInAnswer()
        {
            return manager.NumberOfCardsInAnswer;
        }
        private void SetAskButtonText(bool b)
        {
            if (b)
            {
                askButton.Text = Resources_fr.AskButtonText;
            }
            else
            {
                askButton.Text = Resources_fr.AlreadyASet;
            }
        }

        private void askButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool ok = manager.GetOneCard();
                if (!ok)
                {
                    Deck toUpdate = manager.GetUpdated();
                    board.AddOneCard(toUpdate.Cards[0]);
                }
                else
                {
                    SetAskButtonText(false);
                }
            }
            catch
            {
                askButton.Text = Resources_fr.NoMoreCardsText;
            }
        }

        private void makeTurn(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                Button b = (Button)sender;
                currentPlayer = b.Id;
                playersButton.ForEach(b2 => { b2.BackgroundColor = Xamarin.Forms.Color.Red; });
                b.BackgroundColor = Xamarin.Forms.Color.LightGreen;
                PlayerTurn();
            }
        }

        private void SetScore(Guid currentPlayer)
        {
            scoreLabel.Text = "";
            for (int i=0; i < nbplayer; i++)
            {
                scoreLabel.Text += usernames[i] + ": "+ players[playersButton[i].Id].Points + "\r\n";
            }
        }

        public Partie GetPartie()
        {
            return Partie.MultiLocal;
        }

        public void PlayerTurn()
        {
            counter = 5;
            isPlaying = true;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (SecondsElapsed < counter - 1)
                {
                    counter--;
                    return true;
                }
                else
                {
                    EndTurn();
                    return false;
                }
            });
        }

        public void EndTurn()
        {
            board.SolutionAnswer();
            isPlaying = false;
            playersButton.ForEach(b => { b.BackgroundColor = Xamarin.Forms.Color.Aqua; });
        }

    }
}