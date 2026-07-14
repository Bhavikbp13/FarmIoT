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
    public partial class LineGraph : ContentPage
    {
        public LineGraph()
        {
            InitializeComponent();
            BindingContext = App.MainViewModel;
        }
    }
}