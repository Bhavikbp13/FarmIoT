using Farmiot.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Farmiot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurityDataPage : ContentPage
    {
        public ReadingDataRepo repo = new ReadingDataRepo();
        public SecurityDataPage()
        {
            InitializeComponent();
            BindingContext = App.MainViewModel;
            App.MainViewModel.sys = "Security";
            App.MainViewModel.readRepo.ReadDataFromCloud();
        }

        private void NoiseButton_Clicked(object sender, EventArgs e)
        {
            App.MainViewModel.GraphToGet = "Noise";
        }

        private void LumiButton_Clicked(object sender, EventArgs e)
        {
            App.MainViewModel.GraphToGet = "Lumi";
        }
    }
}