using Farmiot.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Farmiot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContainersListPage : ContentPage
    {
        
        public ContainersListPage()
        {
            InitializeComponent();
            BindingContext = App.MainViewModel;

        }
    
    }
}