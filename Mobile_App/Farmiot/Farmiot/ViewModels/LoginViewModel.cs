using Farmiot.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

/*==================================================
    Name: FarmAIot & Team #7
    Class: 420-6A6-AB sec.00002
    Application Development III
    Description: Contains al the logic in authenticating 
    the user and allowing them access based on their role.
    
===================================================*/
namespace Farmiot.ViewModels
{
    /// <summary>
    /// The type of user that is logged in to allow them certain access 
    /// </summary>
    public enum UserTypes
    {
        FleetManager,
        FarmTechnician,
    }
    /// <summary>
    /// Contains al the logic in authenticating 
    /// the user and allowing them access based on their role.
    /// </summary>
    public class LoginViewModel : ViewModel
    {
        private string _username;
        private string _password;
        public ICommand Tech { get; private set; }
        public ICommand Fleet{ get; private set; }

        public const string FLEET_USERNAME_TO_CHECK = "Fleet";
        public const string FLEET_PASSWORD_TO_CHECK = "fleetPassword123";
        public const string TECH_USERNAME_TO_CHECK = "Tech";
        public const string TECH_PASSWORD_TO_CHECK = "techPassword123";
        public ICommand LoginCommand { get; }
        public static Enum UserType { get; set; }

        /// <summary>
        /// Initializes a new instance for the Login View Model
        /// sets the commands
        /// </summary>
        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            Tech = new Command(TechLogin);
            Fleet = new Command(FleetLogin);
        }

        private void TechLogin(object obj)
        {
            Username = "Tech";
        }

        private void FleetLogin(object obj)
        {
            Username = "Fleet";
        }

        /// <summary>
        /// Gets and sets the username of the login object
        /// </summary>
        /// <returns> Username value as a string </returns>
        public string Username 
        { 
            get
            {
                return _username;
            }
            set
            {
                if (Username == value)
                    return;
                _username = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets and sets the password of the login object
        /// </summary>
        /// <returns> Password value as a string </returns>
        public string Password 
        {
            get
            {
                return _password;
            }
            set
            {
                if (Password == value)
                    return;
                _password = value;
                OnPropertyChanged();
            }
        }  
        
        /// <summary>
        /// Checks if the user login in entered the correct information. Grants access to the user
        /// </summary>
        /// <returns>
        /// True if login successful
        /// False if login unsuccessful
        /// </returns>
        private bool IsValid()
        {
         
            //authenticates the fleet user
            if(Password == FLEET_PASSWORD_TO_CHECK && Username == FLEET_USERNAME_TO_CHECK)
            {
                UserType = UserTypes.FleetManager;
                SuccessfulLogin();
                return true;
            }
            //authenticates the technician user
            else if (Password == TECH_PASSWORD_TO_CHECK && Username == TECH_USERNAME_TO_CHECK)
            {
                UserType = UserTypes.FarmTechnician;
                SuccessfulLogin();
                return true;
            }
            else
            {
                InvalidLogin();
                return false;
            }
            
        }
        /// <summary>
        /// Displays an error message to the user to notify them that their loging credentials
        /// are in correct. Does not allow user access
        /// </summary>
        private void InvalidLogin()
        {
            var resutls = Application.Current.MainPage.DisplayAlert("Error", "Invalid Login, try again", "ok");
            if (resutls.IsCanceled)
                return;
        }
        /// <summary>
        /// Allows users access upon successful login 
        /// </summary>
        private async void Login()
        {
            if (IsValid())
            {
                await App.MainViewModel.Navigation.PushAsync(new ContainersListPage());
            }
        }
        /// <summary>
        /// display a successful login message to the user as well as their role
        /// </summary>
        private void SuccessfulLogin()
        {
            var resutls = Application.Current.MainPage.DisplayAlert("Successful Login", $"You Logged in as {UserType}", "Okay");
            if (!resutls.IsCanceled)
                return;
        }
    }
}
