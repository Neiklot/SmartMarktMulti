using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SmartMarkt
{
    public partial class App : Application, ILoginManager
    {
        static ILoginManager loginManager;
        public static App Current;
        SmartMarktDatabase database = new SmartMarktDatabase();
        public App()
        {
            Current = this;

            InitializeComponent();

            var isLoggedIn = Properties.ContainsKey("IsLoggedIn") ? (bool)Properties["IsLoggedIn"] : false;

            // we remember if they're logged in, and only display the login page if they're not
            if (isLoggedIn)
                MainPage = new SmartMarkt.RootPage(this,database);
            else
                MainPage = new LoginModalPage(this, database);
        }

        public void ShowMainPage()
        {
            MainPage =  new RootPage(this, database);
        }

        public void Logout()
        {
            Properties["IsLoggedIn"] = false; // only gets set to 'true' on the LoginPage
            MainPage = new LoginModalPage(this, database);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
