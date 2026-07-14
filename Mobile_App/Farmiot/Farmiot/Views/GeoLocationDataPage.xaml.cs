using Farmiot.Repos;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;


namespace Farmiot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeoLocationDataPage : ContentPage
    {
        public ReadingDataRepo readRepo = new ReadingDataRepo();
        public GeoLocationDataPage()
        {
            InitializeComponent();
            BindingContext = App.MainViewModel;
            App.MainViewModel.sys = "GeoLocation";
            App.MainViewModel.readRepo.ReadDataFromCloud();

           
            map.MoveToRegion(MapSpan.FromCenterAndRadius(App.MainViewModel.Positions.FirstOrDefault(), Distance.FromMeters(250)));
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        private void PitchButton_Clicked(object sender, System.EventArgs e)
        {
            App.MainViewModel.GraphToGet = "Pitch";
        }

        private void RollButton_Clicked(object sender, System.EventArgs e)
        {
            App.MainViewModel.GraphToGet = "Roll";
        }

        private void VibButton_Clicked(object sender, System.EventArgs e)
        {
            App.MainViewModel.GraphToGet = "Vibration";
        }
    }
}