using SetTheGame.Model;
using SetTheGame.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UCEndGameScoreDisplayer : Grid
    {
        private ResourcesManager Resources_fr = ResourcesManager.Instance;
        public UCEndGameScoreDisplayer(List<Player> results, GameTypes type, Partie partie)
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                BackToMenuButton.BackgroundColor = Xamarin.Forms.Color.White;
                BackToMenuButton.TextColor = Xamarin.Forms.Color.Black;
            }
            Xamarin.Forms.Color c = Xamarin.Forms.Color.Gray;
            if (MainGrid.BackgroundColor == Xamarin.Forms.Color.White)
            {
                c = Xamarin.Forms.Color.Black;
            }
            if (MainGrid.BackgroundColor == Xamarin.Forms.Color.Black)
            {
                c = Xamarin.Forms.Color.White;
            }
            thanks.TextColor = c;
            int i = 1;
            foreach (Player pl in results)
            {
                Label toShow = new Label
                {
                    TextColor = c,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = pl.Name + Resources_fr.Got + pl.Points + Resources_fr.Points + Resources_fr.In + SecondsToMinutes(pl.Time)
                };
                ScoreStack.Children.Add(toShow);
                i++;
            }
        }

        private async void BackToMenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        private string SecondsToMinutes(int seconds)
        {
            string toRet = "";
            string afterMessage = Resources_fr.Minutes;
            int mins = (seconds / 60);
            if (mins > 0)
            {
                toRet += mins.ToString();
                toRet += ":";
            }
            else
            {
                afterMessage = Resources_fr.Seconds;
            }
            int secs = seconds % 60;
            string setsS = "";
            if (secs <= 9)
            {
                setsS += "0";
            }
            setsS += secs.ToString();
            toRet += setsS;
            toRet += afterMessage;
            return toRet;
        }
    }
}