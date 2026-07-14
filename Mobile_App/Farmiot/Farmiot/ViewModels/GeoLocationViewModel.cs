using Farmiot.Models;

/*==================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description:This viewmodel is responsible for
    converting the data from the geo location object
    from the model in a way that the objects are
    easily managed and presented. 
===================================================*/
namespace Farmiot.ViewModels
{
    
    /// <summary>
    /// This viewmodel is responsible for converting
    /// the data from the geo location object from the model in a way
    /// that the objects are easily managed and presented.
    /// </summary>
    public class GeoLocationViewModel : ViewModel
    {
        private GeoLocation geoLocation;
        /// <summary>
        /// Initializes a new instance of the geoLocation viewmodel class.
        /// </summary>
        /// <param name="geoLocation"
        public GeoLocationViewModel(GeoLocation geoLocation)
        {

            this.geoLocation = geoLocation;
            
        }

        /// <summary>
        /// Gets and sets the latitude of the geo location object
        /// </summary>
        /// <returns> latitude value as a double </returns>
        public double Latitude
        {
            get
            {
                return geoLocation.Latitude;
            }
            set
            {
                if (Latitude == value)
                    return;
                geoLocation.Latitude = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the longtitude of the geo location object
        /// </summary>
        /// /// <returns> longtitude value as a double </returns>
        public double Longtitude
        {
            get
            {
                return geoLocation.Longtitude;
            }
            set
            {
                if (Longtitude == value)
                    return;
                geoLocation.Longtitude = value;
                OnPropertyChanged();
            }
        }
     
        /// <summary>
        /// Gets and sets the pitch angle of the geo location object
        /// </summary>
        /// <returns> pitch angle value as an integer </returns>
        public double PitchAngle
        {
            get
            {
                return geoLocation.PitchAngle;
            }
            set
            {
                if (PitchAngle == value)
                    return;
                geoLocation.PitchAngle = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the roll Angle of the geo location object
        /// </summary>
        /// <returns> roll angle value as an integer </returns>
        public double RollAngle
        {
            get
            {
                return geoLocation.RollAngle;
            }
            set
            {
                if (RollAngle == value)
                    return;
                geoLocation.RollAngle = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the vibration of the geo location object
        /// </summary>
        /// <returns> vibration value as an integer </returns>
        public double Vibration
        {
            get
            {
                return geoLocation.Vibration;
            }
            set
            {
                if (Vibration == value)
                    return;
                geoLocation.Vibration = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the buzzer state of the geo location object
        /// </summary>
        /// <returns> buzzer state as a boolean </returns>
        public bool BuzzerState
        {
            get
            {
                return geoLocation.BuzzerState;
            }
            set
            {
                if (BuzzerState == value)
                    return;
                geoLocation.BuzzerState = value;
                OnPropertyChanged();
            }
        }
       

    }
}
