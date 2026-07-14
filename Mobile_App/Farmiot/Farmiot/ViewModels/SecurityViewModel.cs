using Farmiot.Models;
using System;
using System.Collections.Generic;
using System.Text;

/*==================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description:This viewmodel is responsible for
    converting the data from the security object
    from the model in a way that the objects are
    easily managed and presented. 
===================================================*/
namespace Farmiot.ViewModels
{
    /// <summary>
    /// This viewmodel is responsible for converting
    /// the data from the security object from the model in a way
    /// that the objects are easily managed and presented.
    /// </summary>
    public class SecurityViewModel : ViewModel
    {
        private Security security;

        /// <summary>
        /// Initializes a new instance of the security viewmodel class.
        /// </summary>
        /// <param name="security"
        public SecurityViewModel(Security security)
        {
            this.security = security;
        }

        /// <summary>
        /// Gets and sets the noise level of the security object
        /// </summary>
        /// <returns> noise level value as an integer </returns>
        public int NoiseLevel
        {
            get
            {
                return security.NoiseLevel;
            }
            set
            {
                security.NoiseLevel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the luminosity level of the security object
        /// </summary>
        /// <returns> luminosity level value as an integer </returns>
        public int LuminosityLevel
        {
            get 
            { 
                return security.LuminosityLevel; 
            }
            set 
            { 
                security.LuminosityLevel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the motion state of the security object
        /// </summary>
        /// <returns> noise level value as a boolean </returns>
        public string MotionState
        {
            get
            {
                return security.MotionState;
            }
            set
            {
                
                if(value == "False")
                {
                    value = "Off";
                }
                else
                {
                    value = "On";
                }
                security.MotionState = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the door lock state of the security object
        /// </summary>
        /// <returns> door lock state value as a boolean </returns>
        public bool DoorLockState
        {
            get
            {
                return security.DoorLockState;
            }
            set
            {
                security.DoorLockState = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and sets the buzzer state of the security object
        /// </summary>
        /// <returns> buzzzer state value as a boolean </returns>
        public bool BuzzerState
        {
            get
            {
                return security.BuzzerState;
            }
            set
            {
                security.BuzzerState = value;
                OnPropertyChanged();
            }

        }

        /// <summary>
        /// Gets and sets the door state of the security object
        /// </summary>
        /// <returns> door state value as a boolean </returns>
        public string DoorState
        {
            get
            {
                return security.DoorState;
            }
            set
            {
                if (value == "False")
                {
                    value = "Unlocked";
                }
                else
                {
                    value = "Locked";
                }
                security.DoorState = value;
                OnPropertyChanged();
            }
        }

    }
}
