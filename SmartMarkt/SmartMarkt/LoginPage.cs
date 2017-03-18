using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartMarkt
{

    public class LoginPage : ContentPage
    {
        Entry username, password;
      

        public LoginPage(ILoginManager ilm,SmartMarktDatabase database)
        {
       
            var button = new Button { Text = "Login" };
            button.Clicked += async (sender, e) =>
            {
                if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(password.Text))
                {
                    DisplayAlert("Validation Error", "Username and Password are required", "Re-try");
                }
                else
                {
                   string validated= await GetLoginValidation(username.Text, password.Text);
                    // REMEMBER LOGIN STATUS!
                    if (validated.Equals("OK"))
                    {
                        App.Current.Properties["IsLoggedIn"] = true;
                        ilm.ShowMainPage();
                    }
                    else {
                        DisplayAlert("Validation Error", "Username or Password wrong", "Re-try");
                    }
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
        public async Task<string> GetLoginValidation(string username,string password)
        {

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("username", username));
            postData.Add(new KeyValuePair<string, string>("password", password));

            var content = new System.Net.Http.FormUrlEncodedContent(postData);

            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var address = $"http://192.168.1.105:8080/SmartMarkt/login"; 

            var response = await client.PostAsync(address, content);

            var validationCode = response.Content.ReadAsStringAsync().Result;

            //var rootobject = JsonConvert.DeserializeObject<Rootobject>(airportJson);

            return validationCode;

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
