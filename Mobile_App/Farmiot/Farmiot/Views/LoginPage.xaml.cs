using Farmiot.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Farmiot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            
            InitializeComponent();
            BindingContext = new LoginViewModel();
            App.MainViewModel.Navigation = Navigation;
        }
      
    }
}