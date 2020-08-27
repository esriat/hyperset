using SetTheGame.Model;
using SetTheGame.Themes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                MainPage = new NavigationPage(new HomePage())
                {
                    BarBackgroundColor = Xamarin.Forms.Color.Black,
                    BarTextColor = Xamarin.Forms.Color.White,
                };
            }
            if (Device.RuntimePlatform == Device.Android)
            {
                MainPage = new NavigationPage(new HomePage());
            }

            string theme = IOOption.LoadOption();
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                switch (theme)
                {
                    case "Dark":
                    case "Default":
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case "Light":
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
