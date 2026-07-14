using System;
using System.Collections.Generic;
using System.Text;

/*================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description: Represents the data collected
    from the geo Location subsystem.The purpose
    of this class is to define a set of properties
    for the geo Location subsystem 
=================================================*/
namespace Farmiot.Models
{
    /// <summary>
    /// Represents the data collected from the Geo Location Subsystem.
    /// The purpose of this class is to define a set of properties
    /// for the Geo Location Subsystem 
    /// </summary>
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        
        public double PitchAngle { get; set; }
        public double RollAngle { get; set; }
        public double Vibration { get; set; }       
        public bool BuzzerState { get; set;}
    }
}
