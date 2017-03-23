using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartMarkt
{

    public class LoginPage : ContentPage
    {
        Entry Productname, password;
      

        public LoginPage(ILoginManager ilm,SmartMarktDatabase database)
        {
       
            var button = new Button { Text = "Login" };
            button.Clicked += async (sender, e) =>
            {
                if (String.IsNullOrEmpty(Productname.Text) || String.IsNullOrEmpty(password.Text))
                {
                    DisplayAlert("Validation Error", "Productname and Password are required", "Re-try");
                }
                else
                {
               //    string validated= await GetLoginValidation(Productname.Text, password.Text);
                    // REMEMBER LOGIN STATUS!
                  //  if (validated.Equals("OK"))
                  //  {
                        App.Current.Properties["IsLoggedIn"] = true;
                        ilm.ShowMainPage();
                  //  }
                 //   else {
                     //   DisplayAlert("Validation Error", "Productname or Password wrong", "Re-try");
                  //  }
                }
            };
      
            Productname = new Entry { Text = "" };
            password = new Entry { Text = "" };
            Content = new StackLayout
            {
                Padding = new Thickness(10, 40, 10, 10),
                Children = {
                    new Label { Text = "Login", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) },
                    new Label { Text = "Productname" },
                    Productname,
                    new Label { Text = "Password" },
                    password,
                    button
                }
            };
        }
        public async Task<string> GetLoginValidation(string Productname,string password)
        {

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("Productname", Productname));
            postData.Add(new KeyValuePair<string, string>("password", password));

           
            var httpContent = new StringContent("{\"Productname\":\"a\",\"password\":\"b\"}", System.Text.Encoding.UTF8, "application/json");

            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
          
            // var response = await client.PostAsync("http://192.168.1.105:8080/SmartMarkt/login", httpContent);
            var response = await client.GetAsync("http://192.168.1.105:8080/SmartMarkt/");

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
