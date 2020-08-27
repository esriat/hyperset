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
    public partial class HypersetTutorialPageOne : Grid
    {
        private TutorialPage tutorialPage;
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public HypersetTutorialPageOne(TutorialPage tutorialPage)
        {
            this.tutorialPage = tutorialPage;
            InitializeComponent();
            NextPageButton.Text = Resources_fr.Next;
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageOnePartOne, MainGrid.BackgroundColor), 0, 1);
            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageOnePartTwo, MainGrid.BackgroundColor), 0, 4);

            IOColor colors = IOColor.Instance;
            CardsGrid.Children.Add(new UCCard(new Card(Shapes.Diamond, Fills.Hatched, colors.Color1, 3)), 0, 0);
            CardsGrid.Children.Add(new UCCard(new Card(Shapes.Wave, Fills.Filled, colors.Color2, 1)), 1, 0);
            CardsGrid.Children.Add(new UCCard(new Card(Shapes.Oval, Fills.Empty, colors.Color3, 2)), 2, 0);
        }

        private void CenterButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.NextPage();
        }
    }
}