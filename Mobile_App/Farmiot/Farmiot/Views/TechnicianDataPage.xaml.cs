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
    public partial class TechnicianDataPage : ContentPage
    {
        public ReadingDataRepo pr = new ReadingDataRepo();
        public TechnicianDataPage()
        {
            InitializeComponent();
            BindingContext = App.MainViewModel;
            App.MainViewModel.sys = "Plant";
            App.MainViewModel.readRepo.ReadDataFromCloud();
        }

        private void TempButton_Clicked(object sender, EventArgs e)
        {
            App.MainViewModel.GraphToGet = "Temperature";
        }

        private void HumiButton_Clicked(object sender, EventArgs e)
        {
            App.MainViewModel.GraphToGet = "Humidity";
        }

        private void WaterButton_Clicked(object sender, EventArgs e)
        {
            App.MainViewModel.GraphToGet = "Water";
        }
    }
}