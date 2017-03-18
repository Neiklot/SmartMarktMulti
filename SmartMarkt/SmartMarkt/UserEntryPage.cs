using System;
using Xamarin.Forms;

namespace SmartMarkt
{
    public class UserEntryPage : ContentPage
    {
        private UsersPage _parent;
        private SmartMarktDatabase _database;

        public UserEntryPage(ILoginManager ilm, SmartMarktDatabase database)
        {
            _database = database;
            Title = "Enter a User";

            var entry = new Entry();
            var button = new Button
            {
                Text = "Add"
            };

            button.Clicked += (sender, e) =>
            {
                var user = entry.Text;
                var address = entry.Text;

                _database.AddUser(user, address);
                ilm.ShowUsersPage(ilm, database);
            };

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = new Thickness(20),
                Children = { entry, button },
            };
        }
    }
}
