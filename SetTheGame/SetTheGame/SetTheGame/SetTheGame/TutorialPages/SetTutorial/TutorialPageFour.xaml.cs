using SetTheGame.Model;
using SetTheGame.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame.TutorialPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialPageFour : Grid
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        private TutorialPage tutorialPage;
        private IOColor colors = IOColor.Instance;

        private Button but1;
        private Button but2;
        private Button nextPage = new Button();
        private Button previousPage = new Button();
        public TutorialPageFour(TutorialPage tutorialPage)
        {
            InitializeComponent();
            this.tutorialPage = tutorialPage;

            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            else
            {
                FirstButton.TextColor = Xamarin.Forms.Color.Black;
                SecondButton.TextColor = Xamarin.Forms.Color.Black;
                nextPage.TextColor = Xamarin.Forms.Color.Black;
                previousPage.TextColor = Xamarin.Forms.Color.Black;
            }

            FirstButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            FirstButton.Margin = 5;
            FirstButton.CornerRadius = 10;
            SecondButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            SecondButton.Margin = 5;
            SecondButton.CornerRadius = 10;
            nextPage.BackgroundColor = Xamarin.Forms.Color.Aqua;
            nextPage.Margin = 5;
            nextPage.CornerRadius = 10;
            previousPage.BackgroundColor = Xamarin.Forms.Color.Aqua;
            previousPage.Margin = 5;
            previousPage.CornerRadius = 10;

            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageFourPartOne, MainGrid.BackgroundColor), 0, 0);
            CardsGridOne.Children.Add(new UCCard(new Card(Shapes.Oval, Fills.Filled, colors.Color1, 2)), 0, 0);
            CardsGridOne.Children.Add(new UCCard(new Card(Shapes.Diamond, Fills.Hatched, colors.Color3, 2)), 1, 0);
            CardsGridOne.Children.Add(new UCCard(new Card(Shapes.Wave, Fills.Filled, colors.Color2, 2)), 2, 0);
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageFourMultipleParts, MainGrid.BackgroundColor), 0, 2);
            FirstButton.Text = Resources_fr.Yes;
            FirstButton.Clicked += yesButtonOneClicked;
            SecondButton.Text = Resources_fr.No;
            SecondButton.Clicked += noButtonOneClicked;
            nextPage.Text = Resources_fr.Next;
            previousPage.Text = Resources_fr.Previous;
        }

        private void ShowSecondPart()
        {
            Grid SecondExGrid = new Grid();
            for(int i = 0; i < 3; i++)
            {
                SecondExGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = GridLength.Star
                });
            }
            MainGrid.Children.Add(SecondExGrid, 0, 5);
            SecondExGrid.Children.Add(new UCCard(new Card(Shapes.Oval, Fills.Hatched, colors.Color2, 1)), 0, 0);
            SecondExGrid.Children.Add(new UCCard(new Card(Shapes.Wave, Fills.Hatched, colors.Color3, 3)), 1, 0);
            SecondExGrid.Children.Add(new UCCard(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 2)), 2, 0);
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageFourMultipleParts, MainGrid.BackgroundColor), 0, 6);

            but1 = new Button();
            but2 = new Button();
            if (Device.RuntimePlatform == Device.iOS)
            {
                but1.TextColor = Xamarin.Forms.Color.Black;
                but2.TextColor = Xamarin.Forms.Color.Black;
            }
            but1.BackgroundColor = Xamarin.Forms.Color.Aqua;
            but1.Margin = 5;
            but1.CornerRadius = 10;
            but2.BackgroundColor = Xamarin.Forms.Color.Aqua;
            but2.Margin = 5;
            but2.CornerRadius = 10;
            but1.Text = Resources_fr.Yes;
            but2.Text = Resources_fr.No;
            but1.Clicked += yesButtonTwoClicked;
            but2.Clicked += noButtonTwoClicked;
            Grid ButGrid = new Grid();
            MainGrid.Children.Add(ButGrid, 0, 7);
            ButGrid.Children.Add(but1, 0, 0);
            ButGrid.Children.Add(but2, 1, 0);
        }

        private void leavePageButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.NextPage();
        }

        private void yesButtonOneClicked(object sender, EventArgs e)
        {
            // Wrong answer
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageFourPartTwoWrong, MainGrid.BackgroundColor), 0, 4);
            RemoveFirstListeners();
            ShowSecondPart();
        }

        private void noButtonOneClicked(object sender, EventArgs e)
        {
            // Right answer
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageFourPartTwoRight, MainGrid.BackgroundColor), 0, 4);
            RemoveFirstListeners();
            ShowSecondPart();
        }

        private void yesButtonTwoClicked(object sender, EventArgs e)
        {
            // Right answer
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageFourPartThreeRight, MainGrid.BackgroundColor), 0, 8);
            RemoveSecondListeners();
        }

        private void noButtonTwoClicked(object sender, EventArgs e)
        {
            // Wrong answer
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageFourPartThreeWrong, MainGrid.BackgroundColor), 0, 8);
            RemoveSecondListeners();
        }

        private void RemoveFirstListeners()
        {
            FirstButton.Clicked -= yesButtonOneClicked;
            SecondButton.Clicked -= noButtonOneClicked;
        }

        private void RemoveSecondListeners()
        {
            but1.Clicked -= yesButtonTwoClicked;
            but2.Clicked -= noButtonTwoClicked;
            NavigationButtonsGrid.Children.Add(nextPage, 1, 0); 
            NavigationButtonsGrid.Children.Add(previousPage, 0, 0); 
            nextPage.Clicked += NextPage;
            previousPage.Clicked += PreviousPage;
        }

        private void NextPage(object sender, EventArgs e)
        {
            tutorialPage.NextPage();
        }

        private void PreviousPage(object sender, EventArgs e)
        {
            tutorialPage.PreviousPage();
        }
    }
}