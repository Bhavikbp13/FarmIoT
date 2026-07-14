using Farmiot.Models;
using Farmiot.Repos;
using Farmiot.Views;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

/*==================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description: Contains all the navigation and the
    logic of other view model in one view model.
    Seperate the UI logic from the business logic
===================================================*/
namespace Farmiot.ViewModels
{
    /// <summary>
    /// Contains all the navigation and the logic of other
    /// view model in one view model. Seperate the UI logic from the
    /// business logic
    /// </summary>
    public class MainViewModel : ViewModel
    {
        private List<double> noiseArray;
        private List<double> lumiArray;
        private List<double> pitchArray;
        private List<double> rollArray;
        private List<double> vibArray;
        private List<double> tempArray;
        private List<double> humiArray;
        private List<double> waterArray;

       
        public ReadingDataRepo readRepo;
        public ObservableCollection<GeoLocationViewModel> GeoLocations { get; private set; }
        public ObservableCollection<SecurityViewModel> Securities { get; private set; }
        public ObservableCollection<PlantViewModel> Plants { get; private set; }
        public Position Position { get; set; }
        public double ThresholdValue { get; set; }
        private LineChart lineChart1;
        public List<Position> Positions { get; private set; } = new List<Position>();

        public string GraphToGet { get; set; }


        public string sys;

        private GeoLocationViewModel _geoLocationData;
        private SecurityViewModel _securityData;
        private PlantViewModel _plantData;

        public ICommand NavigateToGeoLocationCommand { get; private set; }
        public ICommand NavigateToSecurityCommand { get; private set; }
        public ICommand NavigateToDataPagesCommand { get; private set; }

        public ICommand LogOutCommand { get; private set; }

        public ICommand GraphCommand { get; private set; }
        public ICommand ControlBuzzerCommand { get; private set; }
        public ICommand ControlLightCommand { get; private set; }
        public ICommand ControlFanCommand { get; private set; }
        public ICommand ControlDoorCommand { get; private set; }    
        public ICommand SetThresholdCommand { get; private set; }
        public ICommand NavigateToTechPageCommand { get; private set; }

        public LineChart Chart
        {
            get
            {
                return lineChart1;
            }
            set
            {
                lineChart1 = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Gets and sets the geo location viewmodel 
        /// </summary>
        /// <returns> geo location viewmodel as a geo viewmodel object</returns>
        public GeoLocationViewModel GeoLocationData
        {
            get
            {
                return _geoLocationData;
            }
            set
            {
                _geoLocationData = value;
            }
        }

        /// <summary>
        /// Gets and sets the security viewmodel 
        /// </summary>
        /// <returns> security viewmodel as a security viewmodel object</returns>
        public SecurityViewModel SecurityData
        {
            get
            {
                return _securityData;
            }
            set
            {
                _securityData = value;
            }
        }

        /// <summary>
        /// Gets and sets the plant viewmodel 
        /// </summary>
        /// <returns> plant viewmodel as a plant viewmodel object</returns>
        public PlantViewModel PlantData
        {
            get
            {
                return _plantData;
            }
            set
            {
                _plantData = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the main viewmodel class.
        /// Initializes all the navigation commands for UI.
        /// Queries data from repo into an observable collection list used for the UI.
        /// </summary>
        public MainViewModel()
        {
            readRepo = new ReadingDataRepo();
            var geoLocationResults = HardwareRepo.LoadGeoLocationTestData().Select(gl => new GeoLocationViewModel(gl));
            GeoLocations = new ObservableCollection<GeoLocationViewModel>(geoLocationResults);

            //BHAVIK make test data in the repo and do the linq query for that 
            var securityResults = HardwareRepo.LoadSecurityTestData().Select(s => new SecurityViewModel(s));
            Securities = new ObservableCollection<SecurityViewModel>(securityResults);

            //MANSI make test data in the repo and do the linq query for that
            var plantResults = HardwareRepo.LoadPlantTestData().Select(p => new PlantViewModel(p));
            Plants = new ObservableCollection<PlantViewModel>(plantResults);

            NavigateToGeoLocationCommand = new Command(NavigateToGeoLocationPage);
            NavigateToSecurityCommand = new Command(NavigateToSecurityPage);           
            NavigateToDataPagesCommand = new Command(NavigateToDataPages);
            LogOutCommand = new Command(Logout);
            GraphCommand = new Command(ShowGraph);
            ControlBuzzerCommand = new Command(ControlBuzzer);
            ControlDoorCommand = new Command(ControlDoor);
            ControlFanCommand = new Command(ControlFan);
            ControlLightCommand = new Command(ControlLight);

            SetThresholdCommand = new Command(SetThreshold);
            NavigateToTechPageCommand = new Command(NavigateToTechViewPage);


            noiseArray = new List<double>();
            lumiArray = new List<double>();
            pitchArray = new List<double>();
            rollArray = new List<double>();
            vibArray = new List<double>();
            tempArray = new List<double>();
            humiArray = new List<double>();
            waterArray = new List<double>();
        }
        /// <summary>
        /// Sets the threshold based on a value passed by user. Updates desired properties
        /// </summary>
        private void SetThreshold()
        {
            //checks what page is the graph on and depends on what graph is showing then
            //thats the value of thershold it will bind too
            if(GraphToGet == "Noise")
            {
                ReadingDataRepo.ReportConnectivity("noise_threshold", "", true, ThresholdValue);
            }
            if (GraphToGet == "Vibration")
            {
                ReadingDataRepo.ReportConnectivity("vib_threshold", "", true, ThresholdValue);
            }
            if(GraphToGet == "Lumi")
            {
                ReadingDataRepo.ReportConnectivity("lumi_threshold", "", true, ThresholdValue);
            }
            if(GraphToGet == "Temperature")
            {
                ReadingDataRepo.ReportConnectivity("temp_threshold", "", true, ThresholdValue);
            }
            
        }      
        
        /// <summary>
        /// creates a new line chart for the data to be displayed 
        /// </summary>
        /// <param name="list">data retrieve from azure</param>
        public void GetLineChart(List<double> list)
        {
            List<ChartEntry> chartList = new List<ChartEntry>();
            

            foreach (double item in list)
            {
                ChartEntry ce = new ChartEntry((float)item);
                ce.Label = item.ToString();
                ce.ValueLabel = item.ToString();
                chartList.Add(ce);
            }
            LineChart lineChart = new LineChart();
            lineChart.LabelColor = SkiaSharp.SKColor.Parse("#FF0000");
            lineChart.Entries = chartList;
            lineChart.ValueLabelOrientation = Orientation.Horizontal;
            lineChart.LabelOrientation = Orientation.Horizontal;
            lineChart.LabelTextSize = 25;


            Chart = lineChart;
        }
        /// <summary>
        /// Updates desired properties in azure to control the buzzer
        /// </summary>
        private void ControlBuzzer()
        {
            string state;
            try
            {
                if (GeoLocationData != null && GeoLocationData.BuzzerState)
                {
                    state = "on";
                }
                else if(SecurityData != null && SecurityData.BuzzerState)
                {
                    state = "on";
                }
                else
                {
                    state = "off";
                }
                ReadingDataRepo.ReportConnectivity("buzzer",state,false,0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Updates desired properties in azure to control the light
        /// </summary>
        private void ControlLight()
        {
            string state;
            try
            {
                if (PlantData.Light)
                    state = "on";
                else
                    state = "off";
                ReadingDataRepo.ReportConnectivity("light",state,false,0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Updates desired properties in azure to control the door
        /// </summary>
        private void ControlDoor()
        {
            string state;
            try
            {
                if (SecurityData.DoorLockState)
                    state = "lock";
                else
                    state = "unlock";
                ReadingDataRepo.ReportConnectivity("door_locked",state,false,0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Updates desired properties in azure to control the fan
        /// </summary>
        private void ControlFan()
        {
            string state;
            try
            {
                if (PlantData.FanState)
                    state = "on";
                else
                    state = "off";
                ReadingDataRepo.ReportConnectivity("fan",state,false,0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        
        /// <summary>
        /// Navigates to the graph view
        /// </summary>
        private void ShowGraph()
        {
            App.MainViewModel.Navigation.PushAsync(new LineGraph());
        }

        /// <summary>
        /// Logs out the user from any page
        /// </summary>
        private async void Logout()
        {
            await App.MainViewModel.Navigation.PushAsync(new LoginPage());
        }

        /// <summary>
        /// Navigates to the FleetManagerChoicePage view
        /// <remarks>
        /// Due to no user autentication the technicien is able to navigate
        /// to this view
        /// </remarks>
        /// </summary>
        private async void NavigateToDataPages()
        {
            //depending on who is authenticate then they will see their own views
            if (LoginViewModel.UserType.Equals(UserTypes.FleetManager)) 
                await Navigation.PushAsync(new FleetManagerChoicePage());
            if (LoginViewModel.UserType.Equals(UserTypes.FarmTechnician))
            {
                
                await Navigation.PushAsync(new TechChoicePage());
                
            }
                
        }
        private async void NavigateToTechViewPage()
        {
            PlantData = Plants[0];
            await Navigation.PushAsync(new TechnicianDataPage());
        }

        /// <summary>
        /// Navigates to the GeoLocationPage view
        /// </summary>
        private async void NavigateToGeoLocationPage()
        {
            GeoLocationData = new GeoLocationViewModel(new GeoLocation());
            //await readRepo.ReadDataFromCloud();
            Position = new Position(GeoLocationData.Latitude, GeoLocationData.Longtitude);
            Positions.Clear();
            Positions.Add(Position);
            await Navigation.PushAsync(new GeoLocationDataPage());
            
        }
        /// <summary>
        /// This function sets the properties with data that gets from Azure.
        /// Once this is done this will populate an list to display on a graph
        /// The list will accumlate 10 values and will start display data and once 
        /// it reaches 10 values it will delete the last value and add a new value 
        /// </summary>
        public void RefreshView()
        {
            if(sys == "GeoLocation")
            {
                GeoLocationData.Latitude = Convert.ToDouble(readRepo.list[1]);
                GeoLocationData.Longtitude = Convert.ToDouble(readRepo.list[3]);
                GeoLocationData.PitchAngle = Convert.ToDouble(readRepo.list[5]);
                GeoLocationData.RollAngle = Convert.ToDouble(readRepo.list[7]);
                GeoLocationData.Vibration = Convert.ToDouble(readRepo.list[9]);
               
                if (pitchArray.Count == 10)
                {
                    
                    pitchArray.RemoveAt(0);
                    pitchArray.Add(GeoLocationData.PitchAngle);
                    if (GraphToGet == "Pitch")
                    {
                        GetLineChart(pitchArray);
                        
                    }

                }
                else if (pitchArray.Count < 10)
                {
                    pitchArray.Add(GeoLocationData.PitchAngle);
                }

                if (rollArray.Count == 10)
                {
                    rollArray.RemoveAt(0);
                    rollArray.Add(GeoLocationData.RollAngle);
                    if (GraphToGet == "Roll")
                    {
                        GetLineChart(rollArray);
                    }

                }
                else if (rollArray.Count < 10)
                {
                    rollArray.Add(GeoLocationData.RollAngle);
                }

                if (vibArray.Count == 10)
                {
                    vibArray.RemoveAt(0);
                    vibArray.Add(GeoLocationData.Vibration);
                    if (GraphToGet == "Vibration")
                    {
                        GetLineChart(vibArray);
                       
                    }

                }
                else if (vibArray.Count < 10)
                {
                    vibArray.Add(GeoLocationData.Vibration);
                }
            }
            else if(sys == "Security")
            {
                SecurityData.NoiseLevel = Convert.ToInt32(readRepo.list[11]);
                SecurityData.LuminosityLevel = Convert.ToInt32(readRepo.list[13]);
                SecurityData.MotionState = Convert.ToString(readRepo.list[15]);
                SecurityData.DoorState = Convert.ToString(readRepo.list[17]);
                if(noiseArray.Count == 10)
                {
                    noiseArray.RemoveAt(0);
                    noiseArray.Add(SecurityData.NoiseLevel);
                    if(GraphToGet == "Noise")
                    {
                        GetLineChart(noiseArray);
                    }
                    
                }
                else if(noiseArray.Count < 10)
                {
                    noiseArray.Add(SecurityData.NoiseLevel);
                }

                if (lumiArray.Count == 10)
                {
                    lumiArray.RemoveAt(0);
                    lumiArray.Add(SecurityData.LuminosityLevel);
                    if (GraphToGet == "Lumi")
                    {
                        GetLineChart(lumiArray);
                    }
                    
                }
                else if (lumiArray.Count < 10)
                {
                    lumiArray.Add(SecurityData.LuminosityLevel);
                }

            }
            else if (sys == "Plant")
            {
                PlantData.Temperature = Convert.ToDouble(readRepo.list[19]);
                PlantData.Humidity = Convert.ToDouble(readRepo.list[21]);
                PlantData.Moisture = Convert.ToString(readRepo.list[23]);
                PlantData.Water = Convert.ToInt32(readRepo.list[25]);

                if (tempArray.Count == 10)
                {
                    tempArray.RemoveAt(0);
                    tempArray.Add(PlantData.Temperature);
                    if (GraphToGet == "Temperature")
                    {
                        GetLineChart(tempArray);
                    }

                }
                else if (tempArray.Count < 10)
                {
                    tempArray.Add(PlantData.Temperature);
                }

                if (humiArray.Count == 10)
                {
                    humiArray.RemoveAt(0);
                    humiArray.Add(PlantData.Humidity);
                    if (GraphToGet == "Humidity")
                    {
                        GetLineChart(humiArray);
                    }

                }
                else if (humiArray.Count < 10)
                {
                    humiArray.Add(PlantData.Humidity);
                }

                if (waterArray.Count == 10)
                {
                    waterArray.RemoveAt(0);
                    waterArray.Add(PlantData.Water);
                    if (GraphToGet == "Water")
                    {
                        GetLineChart(waterArray);
                    }

                }
                else if (waterArray.Count < 10)
                {
                    waterArray.Add(PlantData.Water);
                }
            }
            
            
        }

        /// <summary>
        /// Navigates to the SecurityPage view
        /// </summary>
        private void NavigateToSecurityPage()
        {
            SecurityData = new SecurityViewModel(new Security());
            
            Navigation.PushAsync(new SecurityDataPage());
        }
    }
}
