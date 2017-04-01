using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMarkt
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
     
        public LoginPage(ILoginManager ilm, SmartMarktDatabase database)
        {
            InitializeComponent();
           
        var button = this.FindByName<Button>("button");
            button.Clicked += async (sender, e) =>
            {
                if (String.IsNullOrEmpty(username.Text) || String.IsNullOrEmpty(password.Text))
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

            username = this.FindByName<Entry>("username");
            password = this.FindByName<Entry>("password");
                  
        }
        public async Task<string> GetLoginValidation(string Productname, string password)
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
    }
}
