using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Farmiot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FleetManagerChoicePage : ContentPage
    {
        
        public FleetManagerChoicePage()
        {
            InitializeComponent();
            BindingContext = App.MainViewModel;
        }       
    }
}