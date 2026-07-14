using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;


/*==================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description: This class is responsible for
    notifying change to all class that inherite this
    class. 
===================================================*/
namespace Farmiot.ViewModels
{
    /// <summary>
    /// The view model is going to be inherited by
    /// <see cref="MainViewModel"/>
    /// <see cref="GeoLocationViewModel"/>
    /// <see cref="PlantViewModel"/>
    /// <see cref="SecurityViewModel"/>
    /// Inherites InotifyPropretyChange interface
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        /// <summary>
        /// Updates the proprety and notifies when it changes
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
