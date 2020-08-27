using SetTheGame.Model;
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
    public partial class CardPreview : ContentPage
    {
        public CardPreview()
        {
            IOColor loader = IOColor.Instance;
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            MainGrid.Children.Add(new UCCard(new Card(Shapes.Diamond, Fills.Empty, loader.Color1, 1)), 0, 1);
            MainGrid.Children.Add(new UCCard(new Card(Shapes.Wave, Fills.Hatched, loader.Color2, 2)), 1, 1);
            MainGrid.Children.Add(new UCCard(new Card(Shapes.Oval, Fills.Filled, loader.Color3, 3)), 2, 1);
        }
    }
}