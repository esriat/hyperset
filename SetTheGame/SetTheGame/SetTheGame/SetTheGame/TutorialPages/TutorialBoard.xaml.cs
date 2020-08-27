using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SetTheGame.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame.TutorialPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialBoard : Grid
    {
        private SortedDictionary<int, UCCard> Cards = new SortedDictionary<int, UCCard>();
        private List<Card> CardsList = new List<Card>();
        private Dictionary<int, Card> CheckedCards = new Dictionary<int, Card>();
        private TutorialPageFive tutorialPage;
        private HypersetTutorialPageFour hypersetPage;
        private bool isAnswerShown = false;
        private GameModes gamemode;
        private Inspector Inspector;
        private int nbCardsInAnswer;

        public TutorialBoard(TutorialPageFive tutorialPage) : this()
        {
            this.tutorialPage = tutorialPage;
            nbCardsInAnswer = 3;
            Inspector = new SetInspector();
            gamemode = GameModes.Set;
        }

        public TutorialBoard(HypersetTutorialPageFour hypersetTutorialPage) : this()
        {
            this.hypersetPage = hypersetTutorialPage;
            nbCardsInAnswer = 4;
            Inspector = new HypersetInspector();
            gamemode = GameModes.Hyperset;
        }

        private TutorialBoard()
        {
            InitializeComponent();
            SetCards();
        }

        public void CardTapped(int id)
        {
            if (CheckedCards.ContainsKey(id))
            {
                CheckedCards.Remove(id);
                Cards[id].Deselect();
            }
            else
            {
                CheckedCards.Add(id, CardsList[id]);
                Cards[id].Select();
                if(CheckedCards.Count() == nbCardsInAnswer)
                {
                    if (Inspector.IsCorrect(new Deck
                    {
                        Cards = CheckedCards.Values.ToList()
                    }))
                    {
                        if(gamemode == GameModes.Set)
                        {
                            tutorialPage.RightAnswer();
                        }
                        else
                        {
                            hypersetPage.RightAnswer();
                        }
                        foreach(int i in CheckedCards.Keys.ToList())
                        {
                            Cards[i].RightAnswerHighlight();
                        }
                        foreach(KeyValuePair<int, UCCard> kvp in Cards)
                        {
                            kvp.Value.DisableClick();
                        }
                    }
                    else
                    {
                        foreach (KeyValuePair<int, Card> kvp in CheckedCards)
                        {
                            Cards[kvp.Key].Deselect();
                            CheckedCards = new Dictionary<int, Card>();
                        }
                    }
                }
            }
        }

        private void SetCards()
        {
            IOColor colors = IOColor.Instance;
            int rand = new Random().Next(0, 16);
            switch (rand)
            {
                case 0:
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color3, 2));
                    break;

                case 1:
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color2, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color3, 3));
                    break;
                    
                case 2:
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 2));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 1));
                    break;

                case 3:
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 2));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color2, 2));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 3));
                    break;

                case 4:
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color2, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color2, 3));
                    break;

                case 5:
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 3));
                    break;

                case 6:
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color1, 2));
                    break;

                case 7:
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color1, 2));
                    break;

                case 8:
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color2, 2));
                    break;

                case 9:
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 3));
                    break;

                case 10:
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color2, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color2, 1));
                    break;

                case 11:
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color3, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color1, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 1));
                    break;

                case 12:
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color2, 1));
                    break;

                case 13:
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color1, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Filled, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 3));
                    break;

                case 14:
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color1, 2));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Empty, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 2));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color2, 1));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Empty, colors.Color1, 3));
                    break;

                case 15:
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 2));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color1, 2));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Wave, Fills.Filled, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Empty, colors.Color2, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 3));
                    CardsList.Add(new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 3));
                    CardsList.Add(new Card(Shapes.Oval, Fills.Filled, colors.Color3, 3));
                    break;
            } //Fin switch

            Shuffle();
            for (int i = 0; i < CardsList.Count; i++)
            {
                Cards.Add(i, new UCCard(CardsList[i]));
                Cards[i].SetTutorialCard(this, i);
            }
            foreach(KeyValuePair<int, UCCard> kvp in Cards)
            {
                MainGrid.Children.Add(kvp.Value, kvp.Key / 3, kvp.Key % 3);
            }
        }

        public void GetAndShowAnswer()
        {
            if (!isAnswerShown)
            {
                Deck answer = Inspector.GetAnswer(new Deck 
                { 
                    Cards = new List<Card>
                    {
                        CardsList[0],
                        CardsList[1],
                        CardsList[2],
                        CardsList[3],
                        CardsList[4],
                        CardsList[5],
                        CardsList[6],
                        CardsList[7],
                        CardsList[8]
                    }
                });
                answer.Cards.ForEach((card) =>
                {
                    foreach(KeyValuePair<int, UCCard> kvp in Cards)
                    {
                        if (card.Equals(kvp.Value.card))
                        {
                            kvp.Value.Highlight();
                        }
                    }
                });
                CheckedCards = new Dictionary<int, Card>();
                isAnswerShown = true;
            }
        }

        private void Shuffle()
        {
            Random rng = new Random();
            int n = CardsList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = CardsList[k];
                CardsList[k] = CardsList[n];
                CardsList[n] = value;
            }
        }
    }
}