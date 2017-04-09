using System;
using Xamarin.Forms;

namespace SmartMarkt
{
    public class ProductEntryPage : ContentPage
    {
        private SmartMarktDatabase _database;

        public ProductEntryPage(ILoginManager ilm, SmartMarktDatabase database)
        {
            _database = database;
            Title = "Enter a Product";

            var entry = new Entry();
            var button = new Button
            {
                Text = "Add"
            };

            //button.Clicked += (sender, e) =>
            //{
            //    var Product = entry.Text;
            //    var address = entry.Text;

            //    _database.AddProduct(Product, address,0);
            //};

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = new Thickness(20),
                Children = { entry, button },
            };
        }
    }
}
