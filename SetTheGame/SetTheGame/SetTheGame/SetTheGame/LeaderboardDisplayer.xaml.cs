using SetTheGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetTheGame.Resources;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderboardDisplayer : ContentPage
    {
        //private StackLayout ScoresShown;
        private LeaderboardsManager lb;
        private List<Label> labels = new List<Label>();
        private List<Label> headerLabels = new List<Label>();
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public LeaderboardDisplayer()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            //ScoresShown = scoresList;
            lb = new LeaderboardsManager();
            ShowScores(GameModes.Set);
            modeSwitch.Toggled += modeSwitch_Toggled;
            labelset.Text = "SET";
            labelhyperset.Text = "HYPERSET";
        }

        private void modeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                ShowScores(GameModes.Hyperset);
            }
            else
            {
                ShowScores(GameModes.Set);
            }
        }

        private async void myImageButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert(Resources_fr.ChoseLeaderboard, Resources_fr.LeaderboardAlertText, Resources_fr.CloseRules);
        }

        private void ShowScores(GameModes mode)
        {
            while(labels.Count > 0)
            {
                ScoresShown.Children.Remove(labels[0]);
                labels.RemoveAt(0);
            }
            if (lb.GetLeaderboard(mode).Players.Count == 0)
            {
                for (int i = 0; i < headerLabels.Count; i++)
                {
                    LeaderboardHeaderGrid.Children.Remove(headerLabels[i]);
                }
                while(LeaderboardHeaderGrid.ColumnDefinitions.Count > 1)
                {
                    LeaderboardHeaderGrid.ColumnDefinitions.RemoveAt(0);
                }
                headerLabels = new List<Label>();
                Label l = Stylizer.GetStyledLabel(Resources_fr.NoScore, MyPage.BackgroundColor);
                headerLabels.Add(l);
                LeaderboardHeaderGrid.Children.Add(l, 0, 0);
            }
            else
            {
                SetLeaderboardHeaderLabels();
                for (int i = 0; i < lb.GetLeaderboard(mode).Players.Count; i++)
                {
                    Player pl = lb.GetLeaderboard(mode).Players[i];
                    Label l1 = Stylizer.GetStyledLabel(pl.Name, MyPage.BackgroundColor);
                    Label l2 = Stylizer.GetStyledLabel(pl.Points.ToString(), MyPage.BackgroundColor);
                    Label l3 = Stylizer.GetStyledLabel(SecondsToMinutes(pl.Time), MyPage.BackgroundColor);
                    Label l4 = Stylizer.GetStyledLabel(String.Format("{0:0.00}", pl.ScorePerMinute()), MyPage.BackgroundColor);
                    labels.Add(l1);
                    labels.Add(l2);
                    labels.Add(l3);
                    labels.Add(l4);
                    ScoresShown.Children.Add(l1, 0, i);
                    ScoresShown.Children.Add(l2, 1, i);
                    ScoresShown.Children.Add(l3, 2, i);
                    ScoresShown.Children.Add(l4, 3, i);
                }
            }
        }

        private void SetLeaderboardHeaderLabels()
        {
            foreach(Label lab in headerLabels)
            {
                LeaderboardHeaderGrid.Children.Remove(lab);
            }
            headerLabels = new List<Label>();
            while (LeaderboardHeaderGrid.ColumnDefinitions.Count < 4)
            {
                LeaderboardHeaderGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = GridLength.Star
                });
            }
            Label l0 = Stylizer.GetStyledLabel(Resources_fr.Username, MyPage.BackgroundColor);
            headerLabels.Add(l0);
            LeaderboardHeaderGrid.Children.Add(l0, 0, 0);
            Label l1 = Stylizer.GetStyledLabel(Resources_fr.Score, MyPage.BackgroundColor);
            headerLabels.Add(l1);
            LeaderboardHeaderGrid.Children.Add(l1, 1, 0);
            Label l2 = Stylizer.GetStyledLabel(Resources_fr.Time, MyPage.BackgroundColor);
            headerLabels.Add(l2);
            LeaderboardHeaderGrid.Children.Add(l2, 2, 0);
            Label l3 = Stylizer.GetStyledLabel(Resources_fr.ScorePerMinute, MyPage.BackgroundColor);
            headerLabels.Add(l3);
            LeaderboardHeaderGrid.Children.Add(l3, 3, 0);
        }

        private string SecondsToMinutes(int seconds)
        {
            string toRet = "";
            int mins = (seconds / 60);
            if (mins > 0)
            {
                toRet += mins.ToString();
                toRet += ":";
            }
            int secs = seconds % 60;
            string setsS = "";
            if (secs <= 9)
            {
                setsS += "0";
            }
            setsS += secs.ToString();
            toRet += setsS;
            return toRet;
        }
    }
}