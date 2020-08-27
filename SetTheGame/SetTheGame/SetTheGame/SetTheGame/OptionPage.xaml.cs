using SetTheGame.Model;
using SetTheGame.Themes;
using SetTheGame.Resources;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SetTheGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionPage : ContentPage
    {
        private IOColor colors = IOColor.Instance;
        private ResourcesManager ResourcesManager;
        private bool isInitialized = false;
        private Grid SelectedSquare;
        private Grid UnderSelectedSquare;
        private int SelectedIndex;
        private bool isWhiteBackgound = false;
        public OptionPage()
        {
            InitializeComponent();
            ResourcesManager = ResourcesManager.Instance;
            if (!(ResourcesManager.isFrench))
            {
                LanguageSwitch.IsToggled = true;
            }
            title.Text = "OPTIONS";
            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            else
            {
                DefaultColorButton.TextColor = Xamarin.Forms.Color.Black;
                ColorblindColorButton.TextColor = Xamarin.Forms.Color.Black;
                PreviewColorButton.TextColor = Xamarin.Forms.Color.Black;
            }
            
            if (optionPage.BackgroundColor == Xamarin.Forms.Color.Black)
            {
                isWhiteBackgound = false;
                themeButton.Source = "LuneJaune.png";
            }
            else
            {
                isWhiteBackgound = true;
                themeButton.Source = "Sun.png";
            }
            SetTexts();

            SquareClicked(1);
            UnderSquareOne.BackgroundColor = Xamarin.Forms.Color.FromRgb(colors.Color1.Red, colors.Color1.Green, colors.Color1.Blue);
            SquareTwo.BackgroundColor = Xamarin.Forms.Color.FromRgb(colors.Color2.Red, colors.Color2.Green, colors.Color2.Blue);
            SquareThree.BackgroundColor = Xamarin.Forms.Color.FromRgb(colors.Color3.Red, colors.Color3.Green, colors.Color3.Blue);

            SquareOne.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    Debug.WriteLine("Square tapped : Color 1");
                    SquareClicked(1);
                }),
                NumberOfTapsRequired = 1
            });

            SquareTwo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    Debug.WriteLine("Square tapped : Color 2");
                    SquareClicked(2);
                }),
                NumberOfTapsRequired = 1
            });

            SquareThree.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    Debug.WriteLine("Square tapped : Color 3");
                    SquareClicked(3);
                }),
                NumberOfTapsRequired = 1
            });

            RedSlider.ValueChanged += (sender, args) =>
            {
                SliderValueChanged(1);
            };

            GreenSlider.ValueChanged += (sender, args) =>
            {
                SliderValueChanged(2);
            };

            BlueSlider.ValueChanged += (sender, args) =>
            {
                SliderValueChanged(3);
            };
            isInitialized = true;
        }
        private void ThemeSwitcher_Clicked(object sender, EventArgs e)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            themeLayout.Children.Remove(themeButton);
            themeButton = new ImageButton();
            themeButton.Clicked += ThemeSwitcher_Clicked;
            themeButton.BackgroundColor = Xamarin.Forms.Color.Transparent;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                switch (isWhiteBackgound)
                {
                    case false:
                        mergedDictionaries.Add(new LightTheme());
                        IOOption.SaveOption("Light");
                        themeButton.Source = "Sun.png";
                        break;
                    case true:
                        mergedDictionaries.Add(new DarkTheme());
                        IOOption.SaveOption("Dark");
                        themeButton.Source = "LuneJaune.png";
                        break;
                }
            }
            isWhiteBackgound = !isWhiteBackgound;
            themeLayout.Children.Add(themeButton);
        }


        private void SquareClicked(int squareNumber)
        {
            if (isInitialized)
            {
                SelectedSquare.BackgroundColor = Xamarin.Forms.Color.FromRgb(((int)RedSlider.Value), ((int)GreenSlider.Value), ((int)BlueSlider.Value));
                colors.SaveColors();
            }
            Model.Color color;
            switch (squareNumber)
            {
                case 1: color = colors.Color1; SelectedSquare = SquareOne; UnderSelectedSquare = UnderSquareOne; SelectedIndex = 1; break;
                case 2: color = colors.Color2; SelectedSquare = SquareTwo; UnderSelectedSquare = UnderSquareTwo; SelectedIndex = 2; break;
                default: color = colors.Color3; SelectedSquare = SquareThree; UnderSelectedSquare = UnderSquareThree; SelectedIndex = 3; break;
            }
            SelectedSquare.BackgroundColor = Xamarin.Forms.Color.White;
            UnderSelectedSquare.BackgroundColor = Xamarin.Forms.Color.FromRgb(color.Red, color.Green, color.Blue);
            RedSlider.Value = color.Red;
            GreenSlider.Value = color.Green;
            BlueSlider.Value = color.Blue;
        }

        private void SliderValueChanged(int sliderNumber)
        {
            Model.Color color;
            switch (SelectedIndex)
            {
                case 1: color = colors.Color1; break;
                case 2: color = colors.Color2; break;
                default: color = colors.Color3; break;
            }
            switch (sliderNumber)
            {
                case 1: color.Red = ((int)RedSlider.Value); break;
                case 2: color.Green = ((int)GreenSlider.Value); break;
                default: color.Blue = ((int)BlueSlider.Value); break;
            }
            UnderSelectedSquare.BackgroundColor = Xamarin.Forms.Color.FromRgb(color.Red, color.Green, color.Blue);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TutorialPage(GameModes.Set));
        }

        private void ButtonColor_Clicked(object sender, EventArgs e)
        {
            colors.GetDefaultColors();
            SquareClicked(2);
            SquareClicked(3);
            SquareClicked(1);
        }

        private void ColorblindButton_Clicked(object sender, EventArgs e)
        {
            colors.GetColorblindColors();
            SquareClicked(2);
            SquareClicked(3);
            SquareClicked(1);
        }

        protected override void OnDisappearing()
        {
            colors.SaveColors();
            base.OnDisappearing();
        }

        private async void PreviewColorButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CardPreview());
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (LanguageSwitch.IsToggled)
            {
                ResourcesManager.isFrench = false;
            }
            else
            {
                ResourcesManager.isFrench = true;
            }
            SetTexts();
        }

        private void SetTexts()
        {
            if (ResourcesManager.isFrench)
            {
                DefaultColorButton.Text = "Couleurs par défaut";
                ColorblindColorButton.Text = "Mode Daltonien";
                PreviewColorButton.Text = "Prévisualisation des couleurs";
            }
            else
            {
                DefaultColorButton.Text = "Default colours";
                ColorblindColorButton.Text = "Colorblind mode";
                PreviewColorButton.Text = "Colours preview";
            }
        }

        protected override bool OnBackButtonPressed()
        {
            ResourcesManager.Save();
            return base.OnBackButtonPressed();
        }
    }
}