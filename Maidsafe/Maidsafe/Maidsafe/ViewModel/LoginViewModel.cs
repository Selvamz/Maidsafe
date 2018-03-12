using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Maidsafe
{
    /// <summary>
    /// ViewModel for login page
    /// </summary>
    public class LoginViewModel
    {
        private const string AppName = "Maidsafe";

        private INavigation navigation;
        private List<Faculty> facultyMembers;
        private ISettings appSettings;

        public LoginViewModel()
        {
        }

        public LoginViewModel(INavigation nav)
        {
            this.navigation = nav;
            GenerateFacultyMembers();
            LoginCommand = new Command(ValidateAndLogin);
            FindAccountInfo();
        }

        /// <summary>
        /// Generate 3 faculty members by default to login
        /// </summary>
        private void GenerateFacultyMembers()
        {
            facultyMembers = new List<Faculty>
            {
                new Faculty() { Name = "Faculty 1", UserName = "fac1", Password = "password1" },
                new Faculty() { Name = "Faculty 2", UserName = "fac2", Password = "password2" },
                new Faculty() { Name = "Faculty 3", UserName = "fac3", Password = "password3" }
            };
        }

        public Command LoginCommand { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        private void ValidateAndLogin()
        {
            if (string.IsNullOrEmpty(Username))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Enter the username", "OK");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Enter the password", "OK");
                return;
            }

            var faculty = facultyMembers.Find(f => f.UserName == this.Username);
            if(faculty == null)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Invalid username", "OK");
                return;
            }

            if(faculty.Password != this.Password)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Invalid password", "OK");
                return;
            }

            StoreAccountInfo(faculty);
            this.navigation.PushAsync(new StudentList());
        }

        private void StoreAccountInfo(Faculty faculty)
        {
            appSettings.AddOrUpdateValue("Username", faculty.UserName);
            appSettings.AddOrUpdateValue("Password", faculty.Password);
        }
        
        private void FindAccountInfo()
        {
            if (appSettings == null)
                appSettings = CrossSettings.Current;
            var uname = appSettings.GetValueOrDefault("Username", string.Empty);
            if (!string.IsNullOrEmpty(uname))
            {
                Username = uname;
                Password = appSettings.GetValueOrDefault("Password", string.Empty);
            }
        }
    }
}
