using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class SoloGameSet : Grid, Game
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public AbstractSoloGameManager manager { get; private set; }
        private Board board;

        private Label infoLabel = new Label();
        private Label scoreLabel = new Label();
        private Label timerLabel = new Label();

        private Button cheatButton;
        private Button askButton = new Button();

        private UCGameManager mainPage;

        private int SecondsElapsed { get; set; }
        private int counter;
        private int totalTime;
        private GameTypes type;
        private GameModes mode;
        private bool isEasy = false;
        private bool isOkay = true;
        private int left = 0;
        private ProgressBar progressBar;

        public SoloGameSet(UCGameManager mainPage, GameModes gamemode, Difficulties difficulty, GameTypes type, string username, int timeToPlay) : this(mainPage, gamemode, type, username, timeToPlay)
        {
            //Easy construct
            if(difficulty == Difficulties.Begginer)
            {
                cheatButton = new Button();
                cheatButton.Text = Resources_fr.CheatButtonText;
                cheatButton.Clicked += new EventHandler(cheatButton_Clicked);
                cheatButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
                cheatButton.CornerRadius = 10;

                if (Device.RuntimePlatform == Device.iOS)
                {
                    
                    cheatButton.TextColor = Xamarin.Forms.Color.Black;
                }

                isEasy = true;
                board.gamemode = gamemode;
                manager.EnableBegginerMode();
                
                ButtonsGrid.Children.Add(cheatButton, left, 0);
            }
        }

        public SoloGameSet(UCGameManager mainPage, GameModes gamemode, GameTypes type, string username, int timeToPlay)
        {
            //Hard construct
            InitializeComponent();
            counter = timeToPlay;
            totalTime = timeToPlay ;
            this.mainPage = mainPage;
            this.type = type;
            this.mode = gamemode;
            if (type == GameTypes.Time)
            {
                progressBar = new ProgressBar { Progress = 0.5f, ProgressColor = Xamarin.Forms.Color.Orange };
                MainGrid.Children.Add(progressBar, 0, 0);
                SetProgressBar(counter, totalTime);
            }

            if (gamemode == GameModes.Set)
            {
                manager = new SetSoloGameManager();
                askButton.Clicked += new EventHandler(askButton_Clicked);
                ButtonsGrid.Children.Add(askButton, left, 0);
                left++;
                
                askButton.Text = Resources_fr.AskButtonText; 
            }
            else
            {
                manager = new HypersetSoloGameManager();
            }
            manager.StartGame();
            if(type == GameTypes.Score)
            {
                counter = 0;
            }
            else
            {
                manager.player.Time = counter;
            }
            if (MainGrid.BackgroundColor == Xamarin.Forms.Color.WhiteSmoke)
            {
                timerLabel.TextColor = Xamarin.Forms.Color.Black;
                scoreLabel.TextColor = Xamarin.Forms.Color.Black;
                infoLabel.TextColor = Xamarin.Forms.Color.Black;
            }
            else
            {
                timerLabel.TextColor = Xamarin.Forms.Color.White;
                scoreLabel.TextColor = Xamarin.Forms.Color.White;
                infoLabel.TextColor = Xamarin.Forms.Color.White;
            }
            if (Device.RuntimePlatform == Device.iOS)
            {
                askButton.TextColor = Xamarin.Forms.Color.Black;
            }
            askButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            askButton.CornerRadius = 10;

            SetScore();
            scoreLabel.HorizontalTextAlignment = TextAlignment.Center;
            timerLabel.HorizontalTextAlignment = TextAlignment.Center;
            if (type == GameTypes.Score)
            {
                SetTimerLabel();
                LabelsGrid.Children.Add(timerLabel, 1, 0);
            }
            
            manager.SetPlayerName(username);
            board = new Board(this, manager.GetOnBoard());
            MainGrid.Children.Add(board, 0, 2);
            LabelsGrid.Children.Add(scoreLabel, 0, 0);
            
            infoLabel.HorizontalTextAlignment = TextAlignment.Center;
            SetNbSets();
            MainGrid.Children.Add(infoLabel, 0, 3);

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if(type == GameTypes.Time)
                {
                    if (SecondsElapsed < counter - 1)
                    {
                        counter--;
                        SetProgressBar(counter, totalTime);
                        return true;
                    }
                    else
                    {
                        EndGame();
                        return false;
                    }
                }
                else
                {
                    counter++;
                    SetTimerLabel();
                    return isOkay;
                }
            });
        }

        private void SetTimerLabel()
        {
            if(type == GameTypes.Time)
            {
                timerLabel.Text = Resources_fr.RemainingTimeText + SecondsToMinutes(counter);
            }
            else
            {
                timerLabel.Text = Resources_fr.TimeFromBeginning + SecondsToMinutes(counter);
            }
        }
        private async void SetProgressBar(int counter, int totalTime)
        {
            await progressBar.ProgressTo(counter / (float)totalTime, 1000, Easing.Linear);
        }

        public void SetNbSets()
        {
            if (mode == GameModes.Set)
            {
                infoLabel.Text = Resources_fr.NumberOfSetsAvailableText + GetNbSets().ToString();
            }
        }

        public void SetScore()
        {
            scoreLabel.Text = Resources_fr.ScoreLabelText + manager.GetPlayerScore();
        }

        public void Answer(Deck answer)
        {
            try
            {
                bool isCorrect = manager.TryAnswer(answer);
                if (isCorrect)
                {
                    Debug.WriteLine("Right solution");
                    Deck toUpdate = manager.GetUpdated();
                    board.SolutionAnswer(toUpdate);
                    if(type == GameTypes.Time)
                    {
                        if (manager.HasToEnd())
                        {
                            manager.RemakeDeck();
                        }
                    }
                    else
                    {
                        if (manager.HasToEnd())
                        {
                            EndGame();
                        }
                    }
                    SetNbSets();
                    SetScore();
                    SetAskButtonText(true);
                }
                else
                {
                    Debug.WriteLine("Wrong solution");
                    SetScore();
                    board.SolutionAnswer();
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void EndGame()
        {
            if(type == GameTypes.Score)
            {
                Debug.WriteLine("Counter : " + counter);
                manager.player.Time = counter;
            }
            List<Player> p = manager.EndGame();
            mainPage.ShowScores(p);
            isOkay = false;
        }

        public int GetNbSets()
        {
            return manager.NumberOfAnswers();
        }

        public int GetPoints()
        {
            return ((SetSoloGameManager)manager).GetPlayerScore();
        }

        public Deck GetAnswer()
        {
            Deck hyperset = Stub.Stub.GetTestHyperSet();
            Inspector insp = new HypersetInspector();
            Debug.WriteLine("Correct hyperset ? : " + insp.IsCorrect(hyperset));
            return manager.GetAnswer();
        }

        private void askButton_Clicked(object sender, EventArgs e)
        {
            /*if(mode == GameModes.Set)
            {

            }*/
            try
            {
                if (type == GameTypes.Time)
                {
                    if (manager.HasToEnd())
                    {
                        manager.RemakeDeck();
                    }
                }
                bool ok = manager.GetOneCard();
                if (ok)
                {
                    SetScore();
                    SetAskButtonText(false);
                }
                else
                {
                    Deck toUpdate = manager.GetUpdated();
                    board.AddOneCard(toUpdate.Cards[0]);
                    SetNbSets();
                }
            }
            catch
            {
                askButton.Text = Resources_fr.NoMoreCardsText;
            }
        }

        private void cheatButton_Clicked(object senter, EventArgs e)
        {
            board.Cheat();
            SetScore();
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

        private string SecondsToMinutes(int seconds)
        {
            string toRet = "";
            int mins = (seconds/60);
            if(mins > 0)
            {
                toRet += mins.ToString();
                toRet += ":";
            }
            int secs = seconds % 60;
            string setsS = "";
            if(secs <= 9)
            {
                setsS += "0";
            }
            setsS += secs.ToString();
            toRet += setsS;
            return toRet;
        }

        public bool HasToEnd()
        {
            return manager.HasToEnd();
        }

        public Deck GetOnBoard()
        {
            return manager.GetOnBoard();
        }

        public int NumberOfCardsInAnswer()
        {
            return manager.NumberOfCardsInAnswer;
        }

        public Partie GetPartie()
        {
            return Partie.Solo;
        }
    }
}