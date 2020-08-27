using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SetTheGame.Model;
using SetTheGame.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame.TutorialPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HypersetTutorialPageThree : Grid
    {
        private TutorialPage tutorialPage;
        private bool AnsweredQuestionOne = false;
        private ResourcesManager Resources_fr = ResourcesManager.Instance;

        private Card GhostCard;
        private Card c0;
        private Card c1;
        private Card c2;
        private Card c3;
        private bool isHypersetCorrect;
        private Label lab;

        public HypersetTutorialPageThree(TutorialPage tutorialPage)
        {
            InitializeComponent();
            this.tutorialPage = tutorialPage;
            IOColor colors = IOColor.Instance;
            lab = Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialHypersetQuestion, MainGrid.BackgroundColor);
            PreviousPageButton.Text = Resources_fr.Previous;

            Random rand = new Random();
            int nb = rand.Next(0, 10);
            switch (nb)
            {
                case 0:
                    c0 = new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 2);
                    c1 = new Card(Shapes.Diamond, Fills.Filled, colors.Color1, 3);
                    c2 = new Card(Shapes.Wave, Fills.Empty, colors.Color2, 2);
                    c3 = new Card(Shapes.Diamond, Fills.Empty, colors.Color3, 3);
                    GhostCard = new Card(Shapes.Oval, Fills.Empty, colors.Color1, 1);
                    isHypersetCorrect = true;
                    break;
                case 1:
                    c0 = new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 1);
                    c1 = new Card(Shapes.Oval, Fills.Filled, colors.Color2, 2);
                    c2 = new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 2);
                    c3 = new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 1);
                    GhostCard = new Card(Shapes.Wave, Fills.Empty, colors.Color3, 3);
                    isHypersetCorrect = true;
                    break;
                case 2:
                    c0 = new Card(Shapes.Wave, Fills.Filled, colors.Color2, 2);
                    c1 = new Card(Shapes.Wave, Fills.Empty, colors.Color1, 3);
                    c2 = new Card(Shapes.Oval, Fills.Empty, colors.Color1, 3);
                    c3 = new Card(Shapes.Oval, Fills.Hatched, colors.Color3, 1);
                    GhostCard = new Card(Shapes.Diamond, Fills.Empty, colors.Color1, 3);
                    isHypersetCorrect = true;
                    break;
                case 3:
                    c0 = new Card(Shapes.Diamond, Fills.Filled, colors.Color3, 3);
                    c1 = new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 3);
                    c2 = new Card(Shapes.Wave, Fills.Filled, colors.Color2, 1);
                    c3 = new Card(Shapes.Diamond, Fills.Empty, colors.Color1, 1);
                    GhostCard = new Card(Shapes.Oval, Fills.Filled, colors.Color1, 2);
                    isHypersetCorrect = true;
                    break;
                case 4:
                    c0 = new Card(Shapes.Oval, Fills.Hatched, colors.Color1, 1);
                    c1 = new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 3);
                    c2 = new Card(Shapes.Wave, Fills.Filled, colors.Color1, 2);
                    c3 = new Card(Shapes.Oval, Fills.Filled, colors.Color1, 3);
                    GhostCard = new Card(Shapes.Diamond, Fills.Empty, colors.Color1, 3); ;
                    isHypersetCorrect = true;
                    break;
                case 5:
                    c0 = new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 1);
                    c1 = new Card(Shapes.Diamond, Fills.Empty, colors.Color2, 2);
                    c2 = new Card(Shapes.Oval, Fills.Filled, colors.Color1, 1);
                    c3 = new Card(Shapes.Diamond, Fills.Filled, colors.Color2, 2);
                    isHypersetCorrect = false;
                    break;
                case 6:
                    c0 = new Card(Shapes.Wave, Fills.Empty, colors.Color3, 2);
                    c1 = new Card(Shapes.Oval, Fills.Filled, colors.Color2, 2);
                    c2 = new Card(Shapes.Wave, Fills.Hatched, colors.Color2, 1);
                    c3 = new Card(Shapes.Wave, Fills.Filled, colors.Color1, 1);
                    isHypersetCorrect = false;
                    break;
                case 7:
                    c0 = new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 3);
                    c1 = new Card(Shapes.Diamond, Fills.Filled, colors.Color3, 1);
                    c2 = new Card(Shapes.Oval, Fills.Empty, colors.Color2, 2);
                    c3 = new Card(Shapes.Oval, Fills.Filled, colors.Color2, 2);
                    isHypersetCorrect = false;
                    break;
                case 8:
                    c0 = new Card(Shapes.Wave, Fills.Filled, colors.Color3, 2);
                    c1 = new Card(Shapes.Wave, Fills.Empty, colors.Color1, 1);
                    c2 = new Card(Shapes.Oval, Fills.Hatched, colors.Color3, 3);
                    c3 = new Card(Shapes.Oval, Fills.Filled, colors.Color1, 3);
                    isHypersetCorrect = false;
                    break;
                case 9:
                    c0 = new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 2);
                    c1 = new Card(Shapes.Oval, Fills.Filled, colors.Color2, 2);
                    c2 = new Card(Shapes.Diamond, Fills.Filled, colors.Color1, 3);
                    c3 = new Card(Shapes.Wave, Fills.Hatched, colors.Color1, 3);
                    isHypersetCorrect = false;
                    break;
            }

            Deck deck = new Deck()
            {
                Cards = new List<Card>
                {
                    c0,
                    c1,
                    c2,
                    c3
                }
            };

            QuestionCardsGrid.Children.Add(new UCCard(deck.Cards[0]), 0, 0);
            QuestionCardsGrid.Children.Add(new UCCard(deck.Cards[1]), 1, 0);
            QuestionCardsGrid.Children.Add(new UCCard(deck.Cards[2]), 2, 0);
            QuestionCardsGrid.Children.Add(new UCCard(deck.Cards[3]), 3, 0);

            MainGrid.Children.Add(lab, 0, 2);
            YesButtonOne.Text = Resources_fr.Yes;
            NoButtonOne.Text = Resources_fr.No;
        }

        private void YesButtonOne_Clicked(object sender, EventArgs e)
        {
            if ((!AnsweredQuestionOne))
            {
                AnsweredQuestionOne = true;
                if (isHypersetCorrect)
                {
                    RightAnswer();
                }
                else
                {
                    WrongAnswer();
                }
            }
        }

        private void NoButtonOne_Clicked(object sender, EventArgs e)
        {
            if ((!AnsweredQuestionOne))
            {
                AnsweredQuestionOne = true;
                if (isHypersetCorrect)
                {
                    WrongAnswer();
                }
                else
                {
                    RightAnswer();
                }
            }
        }

        private void RightAnswer()
        {
            if (isHypersetCorrect)
            {
                AddButtons();
                MainGrid.Children.Add(new RightAnswerDisplayer(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartOneCorrectRight, MainGrid.BackgroundColor), new List<Card>()
                {
                    c0, c1, c2, c3, GhostCard
                }, Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartTwoRight, MainGrid.BackgroundColor)), 0, 4);
                //MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartOneCorrectRight, MainGrid.BackgroundColor), 0, 4);
                //ShowHypersetAnswer();
            }
            else
            {
                Correction();
                MainGrid.Children.Add(new WrongAnswerDisplayer(new List<Card>()
                {
                    c0, c1, c2, c3
                }, Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartOneIncorrectRight, MainGrid.BackgroundColor)), 0, 1, 0, 5);
                //MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartOneIncorrectRight, MainGrid.BackgroundColor), 0, 3);
            }
        }

        private void WrongAnswer()
        {
            if (isHypersetCorrect)
            {
                AddButtons();
                MainGrid.Children.Add(new RightAnswerDisplayer(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartOneCorrectRight, MainGrid.BackgroundColor), new List<Card>()
                {
                    c0, c1, c2, c3, GhostCard
                }, Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartOneCorrectWrong, MainGrid.BackgroundColor)), 0, 4);
                //MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartOneCorrectWrong, MainGrid.BackgroundColor), 0, 4);
                //ShowHypersetAnswer();
            }
            else
            {
                Correction();
                MainGrid.Children.Add(new WrongAnswerDisplayer(new List<Card>()
                {
                    c0, c1, c2, c3
                }, Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartOneIncorrectWrong, MainGrid.BackgroundColor)), 0, 1, 0, 5);
                //MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageThreePartOneIncorrectWrong, MainGrid.BackgroundColor), 0, 3);
            }
        }

        private void Correction()
        {
            MainGrid.Children.Remove(ButtonsGrid);
            MainGrid.Children.Remove(lab);
            MainGrid.Children.Remove(QuestionCardsGrid);
            AddButtons();
        }

        private void ReloadButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.ReloadPage();
        }

        private void PreviousPageButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.PreviousPage();
        }
        
        private void NextPageButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.NextPage();
        }

        private void AddButtons()
        {
            Button b = new Button();
            b.Text = Resources_fr.Next;
            b.BackgroundColor = Xamarin.Forms.Color.Aqua;
            b.TextColor = Xamarin.Forms.Color.Black;
            b.CornerRadius = 10;    
            b.Clicked += NextPageButton_Clicked;
            ButtonsGridTwo.Children.Add(b, 2, 0);

            Button b2 = new Button();
            b2.BackgroundColor = Xamarin.Forms.Color.Aqua;
            b2.TextColor = Xamarin.Forms.Color.Black;
            b2.CornerRadius = 10;
            b2.Text = Resources_fr.Retry;
            b2.Clicked += ReloadButton_Clicked;
            ButtonsGridTwo.Children.Add(b2, 1, 0);
        }
    }
}