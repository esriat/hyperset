using SetTheGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Board : Grid
    {
        private Game mainPage;
        private Dictionary<int, Card> checkedCards = new Dictionary<int, Card>();
        private SortedDictionary<int, UCCard> showed = new SortedDictionary<int, UCCard>();
        private int nbCards = 0;
        private List<int> emptyIds = new List<int>();

        private int nbColumns = 3;
        private int nbLignes = 0;

        public GameModes gamemode { get; set; }
        
        public Board(Game mainPage, Deck init)
        {
            InitializeComponent();
            Dictionary<int, Card> onBoard = new Dictionary<int, Card>();
            nbCards = 12;
            this.mainPage = mainPage;
            int ind = 0;
            
            foreach(Card c in init.Cards)
            {
                onBoard.Add(ind, c);
                ind++;
            }
            nbCards = init.Size();
            int col = 0;
            int lig = 0;
            int shInd = 0;
            foreach(KeyValuePair<int, Card> kvp in onBoard)
            {
                UCCard toAdd = new UCCard(this, kvp.Value, kvp.Key);
                MainGrid.Children.Add(toAdd, col, lig);
                showed.Add(shInd, toAdd);
                col++;
                shInd++;
                if(col >= nbColumns)
                {
                    col = 0;
                    lig++;
                    nbLignes++;
                }
            }
        }

        public void SolutionAnswer(Deck toUpdate)
        {
            List<int> emptyIds = new List<int>();
            foreach (KeyValuePair<int, Card> kvp in checkedCards)
            {
                showed[kvp.Key].RightAnswerHighlight();
            }
            if (toUpdate.Size() > 0)
            {
                foreach (KeyValuePair<int, Card> kvp in this.checkedCards)
                {
                    MainGrid.Children.Remove(showed[kvp.Key]);
                    showed.Remove(kvp.Key);
                    emptyIds.Add(kvp.Key);
                    emptyIds.Sort();
                }

                for (int i = 0; i < toUpdate.Size(); i++)
                {
                    Card c = toUpdate.Cards[i];
                    int id = emptyIds[i];
                    List<int> coordinates = IdToCoord(id);
                    UCCard uc = new UCCard(this, c, id);
                    showed.Add(id, uc);
                    MainGrid.Children.Add(uc, coordinates[0], coordinates[1]);
                }
            }
            else
            {
                foreach (KeyValuePair<int, Card> kvp in this.checkedCards)
                {
                    MainGrid.Children.Remove(showed[kvp.Key]);
                    showed.Remove(kvp.Key);
                }
            }
            nbCards = mainPage.GetOnBoard().Size();
            checkedCards.Clear();
            if (gamemode == GameModes.Set)
            {
                ReOrganize();
            }
            emptyIds.Clear();
        }

        public void ReOrganize()
        {
            int current = 0;
            while(showed.Count -1 < showed.Last().Key)
            {
                if (!showed.ContainsKey(current))
                {
                    BoardFill(current, showed.Last());
                }
                current++;
            }
        }

        private void BoardFill(int toFill, KeyValuePair<int, UCCard> filler)
        {
            int key = filler.Key;
            UCCard val = filler.Value;
            List<int> coordinates = IdToCoord(toFill);

            val.id = toFill;
            MainGrid.Children.Remove(val);
            MainGrid.Children.Add(val, coordinates[0], coordinates[1]);
            showed.Remove(key);
            showed.Add(toFill, val);
        }

        public void SolutionAnswer()
        {
            foreach (KeyValuePair<int, Card> kvp in checkedCards)
            {
                showed[kvp.Key].Deselect();
            }
            checkedCards.Clear();
        }

        public void CardTapped(int id)
        {
            // Ajout d'un getTypeOfGame dans Game pour récupérer le type de jeu et controller la selection
            if  (mainPage.GetPartie() == Partie.Solo || (mainPage.GetPartie() == Partie.MultiLocal && ((MultiGame)mainPage).isPlaying))
            {
                if (checkedCards.ContainsKey(id))
                {
                    showed[id].Deselect();
                    checkedCards.Remove(id);
                }
                else
                {
                    showed[id].Select();
                    checkedCards.Add(id, showed[id].card);
                    if (checkedCards.Count() == mainPage.NumberOfCardsInAnswer())
                    {
                        Deck answer = new Deck()
                        {
                            Cards = checkedCards.Values.ToList()
                        };
                        mainPage.Answer(answer);
                    }
                }
            }
        }

        private List<int> IdToCoord(int id)
        {
            List<int> coords = new List<int>();
            int left = id % nbColumns;
            int top = id / nbColumns;
            coords.Add(left);
            coords.Add(top);
            return coords;
        }

        private int CoordToId(int left, int top)
        {
            return 3*top + left;
        }

        public void AddOneCard(Card toAdd)
        {
            //Penalité
            //Pas d'ajout si un set en jeu
            List<int> coords = IdToCoord(nbCards);
            if (coords[0] == nbLignes)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition());
            }
            UCCard uc = new UCCard(this, toAdd, nbCards);
            MainGrid.Children.Add(uc, coords[0], coords[1]);
            showed.Add(nbCards, uc);
            nbCards++;
            foreach(KeyValuePair<int, UCCard> kvp in showed)
            {
                kvp.Value.ReDraw();
            }
        }

        public void Cheat()
        {
            Deck answer = mainPage.GetAnswer();
            if (answer.Size() > 0)
            {
                foreach (KeyValuePair<int, UCCard> kvp in showed)
                {
                    kvp.Value.Deselect();
                    foreach (Card c in answer.Cards)
                    {
                        if (kvp.Value.card.Equals(c))
                        {
                            kvp.Value.Highlight();
                        }
                    }
                }
            }
        }
    }
}