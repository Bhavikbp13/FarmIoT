using Farmiot.Models;
using System;
using System.Collections.Generic;
using System.Text;

/*==================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description:This viewmodel is responsible for
    converting the data from the plant object
    from the model in a way that the objects are
    easily managed and presented. 
===================================================*/
namespace Farmiot.ViewModels
{
    /// <summary>
    /// This viewmodel is responsible for converting
    /// the data from the plant object from the model in a way
    /// that the objects are easily managed and presented.
    /// </summary>
    public class PlantViewModel : ViewModel
    {
        private Plant plant { get; }

        /// <summary>
        /// Initializes a new instance of the plant viewmodel class.
        /// </summary>
        /// <param name="plant"
        public PlantViewModel(Plant plant)
        {
            this.plant = plant;
        }

        /// <summary>
        /// Gets and sets the Temperature of the plant object
        /// </summary>
        /// <returns> Temperature value as a double </returns>
        public double Temperature
        {
            get
            {
                return plant.Temperature;
            }
            set
            {
                plant.Temperature = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the humidity of the plant object
        /// </summary>
        /// <returns> humidity value as a double </returns>
        public double Humidity
        {
            get
            {
                return plant.Humidity;
            }
            set
            {
                plant.Humidity = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the moisture of the plant object
        /// </summary>
        /// <returns> moisture value as a string </returns>
        public string Moisture
        {
            get
            {
                return plant.MoistureLevel;
            }
            set
            {
                plant.MoistureLevel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the water level of the plant object
        /// </summary>
        /// <returns> water level value as an integer </returns>
        public int Water
        {
            get
            {
                return plant.WaterLevel;
            }
            set
            {
                plant.WaterLevel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the fan state of the plant object
        /// </summary>
        /// <returns> fan state value as a boolean </returns>
        public bool FanState
        {
            get
            {
                return plant.FanState;
            }
            set
            {
                plant.FanState = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the lights of the plant object
        /// </summary>
        /// <returns> lights value as a boolean </returns>
        public bool Light
        {
            get
            {
                return plant.LightState;
            }
            set
            {
                plant.LightState = value;
                OnPropertyChanged();
            }
        }


    }
}
