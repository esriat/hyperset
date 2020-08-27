using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SetTheGame.Resources;
using SetTheGame.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame.TutorialPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialPageOne : Grid
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        private TutorialPage tutorialPage;
        public TutorialPageOne(TutorialPage tutorialPage)
        {
            InitializeComponent();
            this.tutorialPage = tutorialPage;

            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            else
            {
                leavePageButton.TextColor = Xamarin.Forms.Color.Black;
            }
            leavePageButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            leavePageButton.Margin = 5;
            leavePageButton.CornerRadius = 10;
            leavePageButton.Text = Resources_fr.Next;
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageOnePartOne, MainGrid.BackgroundColor), 0, 1);
            IOColor colors = IOColor.Instance;
            CardsGrid.Children.Add(new UCCard(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 3)), 0, 0) ;
            CardsGrid.Children.Add(new UCCard(new Card(Shapes.Wave, Fills.Filled, colors.Color2, 1)), 1, 0);
            CardsGrid.Children.Add(new UCCard(new Card(Shapes.Oval, Fills.Empty, colors.Color3, 2)), 2, 0);
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.TutorialPageOnePartTwo, MainGrid.BackgroundColor), 0, 4);
        }

        private void leavePageButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.NextPage();
        }
    }
}