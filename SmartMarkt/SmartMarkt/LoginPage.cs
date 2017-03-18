using SQLite;
using System;
using System.Collections;
using Xamarin.Forms;

namespace SmartMarkt
{

    public class LoginPage : ContentPage
    {
        Entry username, password;
      

        public LoginPage(ILoginManager ilm,SmartMarktDatabase database)
        {
       
            var button = new Button { Text = "Login" };
            button.Clicked += (sender, e) =>
            {
                if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(password.Text))
                {
                    DisplayAlert("Validation Error", "Username and Password are required", "Re-try");
                }
                else
                {

                    // REMEMBER LOGIN STATUS!
                    App.Current.Properties["IsLoggedIn"] = true;
                    ilm.ShowMainPage();
                }
            };
            var create = new Button { Text = "View Accounts" };
            create.Clicked += (sender, e) =>
            {
                //MessagingCenter.Send<ContentPage>(this, "Create");
                ilm.ShowUsersPage(ilm, database);
            };

            username = new Entry { Text = "" };
            password = new Entry { Text = "" };
            Content = new StackLayout
            {
                Padding = new Thickness(10, 40, 10, 10),
                Children = {
                    new Label { Text = "Login", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) },
                    new Label { Text = "Username" },
                    username,
                    new Label { Text = "Password" },
                    password,
                    button, create
                }
            };
        }
        public void chekLogin(String username, String password)
        {

        }

        //private void LoadList()
        //{
        //    String dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "SmartMark.sqlite");
        //    using (var connection = new SQLiteConnection("Data Source=" + dbPath)) ;
        //    using (var query = new SQLiteCommand("SELECT * FROM EntryTypes", connection))
        //    {
        //        connection.Open();

        //    }
        //}

       
    }
}
