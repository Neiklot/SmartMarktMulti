using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartMarkt
{
    public class UsersPage : ContentPage
    {
        private SmartMarktDatabase _database;
        private ListView _userList;

        public UsersPage(ILoginManager ilm,SmartMarktDatabase database)
        {
            _database = database;
            Title = "Users";
            var users = _database.GetUsers();

            _userList = new ListView();
            _userList.ItemsSource = users;
            _userList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _userList.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            _userList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Address");

            var button = new Button
            {
                Text = "Add",
                Command = new Command(() => ilm.ShowUserEntryPage(ilm,database))
            };

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = new Thickness(20),
                Children = { _userList, button },
            };
  
        }

        public void Refresh()
        {
            _userList.ItemsSource = _database.GetUsers();
        }
    }
}
