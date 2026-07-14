using System;
using System.Collections.Generic;
using System.Text;

/*================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description: Represents the data collected
    from the plant subsystem.The purpose
    of this class is to define a set of properties
    for the plant subsystem 
=================================================*/
namespace Farmiot.Models
{
    /// <summary>
    /// Represents the data collected from the plant Subsystem.
    /// The purpose of this class is to define a set of properties
    /// for the plant Subsystem 
    /// </summary>
    public class Plant
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string MoistureLevel { get; set; }
        public int WaterLevel { get; set; }
        public bool FanState { get; set; }  // True == On 
        public bool LightState { get; set; }
    }
}
