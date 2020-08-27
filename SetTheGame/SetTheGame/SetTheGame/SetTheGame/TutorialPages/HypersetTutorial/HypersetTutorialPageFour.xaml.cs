using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SetTheGame.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame.TutorialPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HypersetTutorialPageFour : Grid
    {
        private TutorialPage tutorialPage;
        private Button leavePageButton = new Button();
        private bool shown = false;
        private TutorialBoard tut;
        private Label congratsLabel;
        private bool isGameInProgress = true;
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public HypersetTutorialPageFour(TutorialPage tutorialPage)
        {
            InitializeComponent();
            this.tutorialPage = tutorialPage;
            congratsLabel = Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageFourPartTwo, MainGrid.BackgroundColor);
            if (Device.RuntimePlatform == Device.iOS)
            {
                leavePageButton.TextColor = Color.Black;
                leavePagePreviousButton.TextColor = Color.Black;
                CenterButton.TextColor = Color.Black;
            }

            leavePageButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            leavePageButton.CornerRadius = 10;
            leavePagePreviousButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            leavePagePreviousButton.CornerRadius = 10;
            CenterButton.BackgroundColor = Xamarin.Forms.Color.Aqua;
            CenterButton.CornerRadius = 10;


            leavePageButton.Text = Resources_fr.Next;
            leavePageButton.Clicked += leavePageButton_Clicked;
            CenterButton.Text = Resources_fr.CheatButtonText;
            leavePagePreviousButton.Text = Resources_fr.Previous;

            MainGrid.Children.Add(Stylizer.GetStyledLabel(Resources_fr.HypersetTutorialPageFourPartOne, MainGrid.BackgroundColor), 0, 0);
            tut = new TutorialBoard(this);
            MainGrid.Children.Add(tut, 0, 1);
        }

        public void RightAnswer()
        {
            if (!shown)
            {
                ButtonsGrid.Children.Add(leavePageButton, 2, 0);
                shown = true;
            }
            CenterButton.Text = Resources_fr.Retry;
            isGameInProgress = false;
            MainGrid.Children.Add(congratsLabel, 0, 2);
        }

        private void leavePageButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.NextPage();
        }

        private void CenterButton_Clicked(object sender, EventArgs e)
        {
            if (isGameInProgress)
            {
                tut.GetAndShowAnswer();
            }
            else
            {
                MainGrid.Children.Remove(congratsLabel);
                MainGrid.Children.Remove(tut);
                tut = new TutorialBoard(this);
                MainGrid.Children.Add(tut, 0, 1);
                isGameInProgress = true;
                CenterButton.Text = Resources_fr.CheatButtonText;
            }
        }

        private void leavePagePreviousButton_Clicked(object sender, EventArgs e)
        {
            tutorialPage.PreviousPage();
        }
    }
}