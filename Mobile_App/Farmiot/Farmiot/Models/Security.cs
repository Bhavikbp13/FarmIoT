using System;
using System.Collections.Generic;
using System.Text;

/*================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description: Represents the data collected
    from the security subsystem.The purpose
    of this class is to define a set of properties
    for the security subsystem 
=================================================*/
namespace Farmiot.Models
{
    /// <summary>
    /// Represents the data collected from the security Subsystem.
    /// The purpose of this class is to define a set of properties
    /// for the security Subsystem 
    /// </summary>
    public class Security
    {
        public int NoiseLevel { get; set; }
        public int LuminosityLevel { get; set; }
        public string MotionState { get; set; }
        public bool DoorLockState { get; set; }
        public bool BuzzerState { get; set; }
        public string DoorState { get; set; }
    }
}
