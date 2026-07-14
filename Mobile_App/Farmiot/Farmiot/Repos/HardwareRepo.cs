using Farmiot.Models;
using System.Collections.Generic;

/*================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description:This class implements data access
    by encapsulating the objects.
    The objective of this class is to seperate the
    data acess logic from the model 
=================================================*/
namespace Farmiot.Repos
{
    /// <summary>
    /// This class implements data access by encapsulating the objects.
    /// The objective of this class is to seperate the data acess logic
    /// from the model 
    /// </summary>
    public class HardwareRepo
    {
        /// <summary>
        /// Creates a list that contains the geo location object.
        /// The stored object contains dummy data 
        /// </summary>
        /// <returns> list with a geo object </returns>
        public static IEnumerable<GeoLocation> LoadGeoLocationTestData()
        {
            List<GeoLocation> list = new List<GeoLocation>
            {
                new GeoLocation()
                {
                    Latitude = 45.455560652802795,
                    Longtitude = -73.88976231214512,                    
                    PitchAngle = 50,
                    RollAngle = 20,
                    Vibration = 200,                   
                    BuzzerState = false 
                }
            };
            return list;
            
        }

        /// <summary>
        /// Creates a list that contains the security object.
        /// The stored object contains dummy data  
        /// </summary>
        /// <returns> list with a geo object </returns>
        public static IEnumerable<Security> LoadSecurityTestData()
        {
            List<Security> list = new List<Security>
            {
                new Security()
                {
                    NoiseLevel = 93,
                    LuminosityLevel = 24,
                    MotionState = "Off",
                    DoorLockState = false,
                    BuzzerState = false,
                    DoorState = "Unlocked"

                }
            };
            return list;
        }

        /// <summary>
        /// Creates a list that contains the plant object.
        /// The stored object contains dummy data  
        /// </summary>
        /// <returns> list with a geo object </returns>
        public static IEnumerable<Plant> LoadPlantTestData()
        {
            List<Plant> list = new List<Plant>
            {
                new Plant()
                {
                    Temperature = 20.89,
                    Humidity = 45.52, 
                    MoistureLevel = "wet",
                    WaterLevel = 400,
                    FanState = false,
                    LightState = false,
                }
            };
            return list;
        }
    }
}
