using Farmiot.ViewModels;
using Farmiot.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Farmiot
{
    public partial class App : Application
    {
        public static MainViewModel MainViewModel { get; private set; }
        public App()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
