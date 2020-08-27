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
    public partial class GameModeMenu : ContentPage
    {
        ResourcesManager ResourcesManager = ResourcesManager.Instance;
        private Entry nameEntry1 = new Entry();
        private Entry nameEntry2 = new Entry();
        private Entry nameEntry3 = new Entry();
        private Entry nameEntry4 = new Entry();

        public GameModeMenu()
        { 
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            else
            {
                NextButton.TextColor = Xamarin.Forms.Color.Black;
            }

            slider.Maximum = 4;
            slider.Minimum = 1;
            nbLabel.Text = slider.Value.ToString() + " " + ResourcesManager.Player.ToLower();

            modeSwitch.Toggled += OnToggled_Time;
            if (modeSwitch.IsToggled)
            {
                timeGrid.Children.Remove(timeslider);
                timeGrid.Children.Remove(timeLabel);
            }
            else
            {
                timeGrid.Children.Add(timeslider, 0, 0);
                timeGrid.Children.Add(timeLabel, 1, 0);
            }

            timeslider.Maximum = 15;
            timeslider.Minimum = 2;
            SetTimeLabelText();

            labeleasy.Text = ResourcesManager.Easy;
            labelexpert.Text = ResourcesManager.Hard;
            labelScore.Text = "Score";
            labelTemps.Text = ResourcesManager.Time;
            labelset.Text = "Set";
            labelhyperset.Text = "Hyperset";

            nameEntry1.Placeholder = ResourcesManager.Player + " 1";
            nameEntry2.Placeholder = ResourcesManager.Player + " 2";
            nameEntry3.Placeholder = ResourcesManager.Player + " 3";
            nameEntry4.Placeholder = ResourcesManager.Player + " 4"; 

            if (MyPage.BackgroundColor == Xamarin.Forms.Color.Black)
            {
                nameEntry1.BackgroundColor = Xamarin.Forms.Color.LightGray;
                nameEntry2.BackgroundColor = Xamarin.Forms.Color.LightGray;
                nameEntry3.BackgroundColor = Xamarin.Forms.Color.LightGray;
                nameEntry4.BackgroundColor = Xamarin.Forms.Color.LightGray;
            }

            MainGrid.Children.Add(nameEntry1, 1, 7);
        }
        private void TimeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            timeslider.Value = Math.Round(e.NewValue);
            SetTimeLabelText();
        }

        private void SetTimeLabelText()
        {
            timeLabel.Text = timeslider.Value + " mins";
            /*switch (timeslider.Value)
            {
                case 1:
                    timeLabel.Text = "2 mins";
                    break;
                case 2:
                    timeLabel.Text = "5 mins";
                    break;
                case 3:
                    timeLabel.Text = "10 mins";
                    break;
            }*/
        }
        private int GetTimeToPlay()
        {
            return ((int)timeslider.Value) * 60;
            /*switch (timeslider.Value)
            {
                case 1:
                    return 2*60;
                case 2:
                    return 5 * 60;
                case 3:
                    return 10 * 60;
                default:
                    return -1;
            }*/
        }
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            slider.Value = Math.Round(e.NewValue);
            nbLabel.Text = slider.Value.ToString() + " " + ResourcesManager.Player.ToLower() + (slider.Value != 1 ? "s" : "");
            if (slider.Value > 1)
            {
                SecondGrid.Children.Remove(myImageButton);
                SecondGrid.Children.Remove(modeSwitch);
                SecondGrid.Children.Remove(labelScore);
                SecondGrid.Children.Remove(labelTemps);
                DiffGrid.Children.Remove(labeleasy);
                DiffGrid.Children.Remove(labelexpert);
                DiffGrid.Children.Remove(diffSwitch);
                MainGrid.Children.Add(nameEntry2, 1, 8);
                timeGrid.Children.Remove(timeslider);
                timeGrid.Children.Remove(timeLabel);
            }
            else
            {
                MainGrid.Children.Remove(nameEntry2);
            }
            if (slider.Value >= 3)
            {
                MainGrid.Children.Add(nameEntry3, 1, 9);
            }
            else
            {
                MainGrid.Children.Remove(nameEntry3);
            }
            if (slider.Value == 4)
            {
                MainGrid.Children.Add(nameEntry4, 1, 10);
            }
            else
            {
                MainGrid.Children.Remove(nameEntry4);
            }

            if (slider.Value == 1)
            {
                SecondGrid.Children.Add(myImageButton, 3, 0);
                SecondGrid.Children.Add(labelScore, 0, 0);
                SecondGrid.Children.Add(modeSwitch, 1, 0);
                SecondGrid.Children.Add(labelTemps, 2, 0);
                DiffGrid.Children.Add(labeleasy, 0, 0);
                DiffGrid.Children.Add(diffSwitch, 1, 0);
                DiffGrid.Children.Add(labelexpert, 2, 0);
                MainGrid.Children.Remove(nameEntry2);
                MainGrid.Children.Remove(nameEntry3);
                MainGrid.Children.Remove(nameEntry4);
                if (modeSwitch.IsToggled)
                {
                    timeGrid.Children.Remove(timeslider);
                    timeGrid.Children.Remove(timeLabel);
                }
                else
                {
                    timeGrid.Children.Add(timeslider, 0, 0);
                    timeGrid.Children.Add(timeLabel, 1, 0);
                }
            }
            gameSwitch.OnColor = Xamarin.Forms.Color.LightGray;
            modeSwitch.OnColor = Xamarin.Forms.Color.LightGray;
            diffSwitch.OnColor = Xamarin.Forms.Color.LightGray;
        }
        private void OnToggled_Time(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                timeGrid.Children.Remove(timeslider);
                timeGrid.Children.Remove(timeLabel);
            }
            else
            {
                timeGrid.Children.Add(timeslider, 0, 0);
                timeGrid.Children.Add(timeLabel, 1, 0);
            }
        }
        private GameTypes GetSelected()
        {
            if (modeSwitch.IsToggled) return GameTypes.Score;
            else return GameTypes.Time;
        }

        private GameModes GetGameModeSelected()
        {
            if (gameSwitch.IsToggled) return GameModes.Hyperset;
            else return GameModes.Set;
        }

        private Partie GetPartieSelected()
        {
            if (slider.Value == 1) return Partie.Solo;
            else return Partie.MultiLocal;
        }

        private Difficulties GetDifficultiesSelected()
        {
            if (diffSwitch.IsToggled)return Difficulties.Expert;
            else return Difficulties.Begginer;

        }
        private string getSingleUserName()
        {
            return String.IsNullOrEmpty(nameEntry1.Text) ? "Joueur 1" : nameEntry1.Text;
        }

        private List<string> getUsersNames()
        {
            List<string> list = new List<string>();

            switch (((int)slider.Value))
            {
                case 4:
                    list.Add(String.IsNullOrEmpty(nameEntry4.Text) ? "Joueur 4" : nameEntry4.Text);
                    goto case 3;
                case 3:
                    list.Add(String.IsNullOrEmpty(nameEntry3.Text) ? "Joueur 3" : nameEntry3.Text);
                    goto default;
                default:
                    list.Add(String.IsNullOrEmpty(nameEntry2.Text) ? "Joueur 2" : nameEntry2.Text);
                    list.Add(String.IsNullOrEmpty(nameEntry1.Text) ? "Joueur 1" : nameEntry1.Text);
                    break;
            }

            return list;
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            IOTutorial tut = IOTutorial.Instance;
            if (GetPartieSelected() == Partie.Solo)
            {
                if (!(tut.IsTutorialDone(GetGameModeSelected())))
                {
                    Device.BeginInvokeOnMainThread(async () => { await GetAnswer(); });
                }
                else
                {
                    await Navigation.PushAsync(new MainPage(GetPartieSelected(), GetGameModeSelected(), GetDifficultiesSelected(), GetSelected(), getSingleUserName(), GetTimeToPlay()));
                }
            }
            else
            {
                await Navigation.PushAsync(new MainPage((int)slider.Value, GetPartieSelected(), GetGameModeSelected(), getUsersNames()));
            }
            
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert(ResourcesManager.GamemodeHelpButtonTitle, ResourcesManager.GamemodeHelpButtonText, ResourcesManager.CloseRules);
        }

        private async Task GetAnswer()
        {
            bool tuto = await DisplayAlert(ResourcesManager.Tutorial, ResourcesManager.WantATutorial, ResourcesManager.Yes, ResourcesManager.No);
            if (tuto)
            {
                await Navigation.PushAsync(new TutorialPage(GetGameModeSelected()));
            }
            else
            {
                IOTutorial.Instance.TutorialDone(GetGameModeSelected());
                await Navigation.PushAsync(new MainPage(GetPartieSelected(), GetGameModeSelected(), GetDifficultiesSelected(), GetSelected(), getSingleUserName(), GetTimeToPlay()));
            }
        }
    }
}