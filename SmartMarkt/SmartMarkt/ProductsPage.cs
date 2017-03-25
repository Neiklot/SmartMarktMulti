using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SmartMarkt
{
    public class ProductsPage : CarouselPage
    {
        private SmartMarktDatabase _database;
        private ListView _ProductList;
        private ListView _busquedaList;

        public ProductsPage()
        {
            SmartMarktDatabase database = new SmartMarktDatabase();
            _database = database;
            Title = "Productos";
            var Products = _database.GetProducts();

            _ProductList = new ListView();
            _ProductList.ItemsSource = Products;
            _ProductList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _ProductList.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            _ProductList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Address");
            _ProductList.ItemTemplate.SetBinding(TextCell.DetailProperty, "BarCode");

            var aceptar = new Button
            {
                Text = "Aceptar"
            };

            var buscar = new Button
            {
                Text = "Buscar"
            };

            var addEntry = new Entry();
            var addBarcode = new Entry();
            var buscarEntry = new Entry();

            aceptar.Clicked += (sender, e) =>
            {
                var Product = addEntry.Text;
                var address = addEntry.Text;
                var newBarCode = 0;
                var barCodeAdd = Int32.TryParse(addBarcode.Text, out newBarCode); ;

                _database.AddProduct(Product, address, newBarCode);
                addEntry.Text= "";
                Refresh();
                returnToList();
            };

            buscar.Clicked += async (sender, e) =>
           {
               var scanner = DependencyService.Get<IQrCodeScanningService>();
               var result = await scanner.ScanAsync();
               if (result != null)
               {
                   buscarEntry.Text = result;
               }
           };

                buscarEntry.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                var newText = e.NewTextValue;
                int barCode=0;
                Int32.TryParse(newText, out barCode);
                _ProductList.ItemsSource = _database.GetProduct(newText, barCode);
            };
                var ProductsListContentPage = new ContentPage
            {
                Padding = new Thickness(20),
                Content = new StackLayout
                {
                    Children = { buscarEntry,buscar, _ProductList },
                }
            };


            var ProductEntryContentPage = new ContentPage
            {
                Padding = new Thickness(20),
                Content = new StackLayout
                {
                    Children = { addEntry, addBarcode, aceptar }
                }
            };

            Children.Add(ProductsListContentPage);
            Children.Add(ProductEntryContentPage);
         
            SelectedItem = Children.ElementAt<ContentPage>(0);


            _ProductList.ItemTapped += (sender, e) => {
                Type TargetType = typeof(FichaProducto);
                NavigationTo(new FichaProducto((Product)e.Item));
            };


        }

        public void Refresh()
        {
            _ProductList.ItemsSource = _database.GetProducts();
        }
        public void returnToList() {
              SelectedItem = Children.ElementAt<ContentPage>(0);
        }

        public async void  NavigationTo(ContentPage page)
        {
            try
            {
                await ((RootPage)App.Current.MainPage).Detail.Navigation.PushAsync(page);
            }
            catch (Exception e) {
                Console.Write(e.ToString());
            }
           
        }

    }
}
