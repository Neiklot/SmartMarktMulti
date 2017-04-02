using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMarkt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : CarouselPage
    {
        private SmartMarktDatabase _database;
        private ListView _busquedaList;

        public ProductsPage()
        {
            InitializeComponent();

            SmartMarktDatabase database = new SmartMarktDatabase();
            _database = database;
            Title = "Productos";
            var Products = _database.GetProducts();
            productsList = this.FindByName<ListView>("productsList");
            //_ProductList = new ListView();
            productsList.ItemsSource = Products;
            //productsList.ItemTemplate = new DataTemplate(typeof(TextCell));
            //productsList.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            //productsList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Address");
            //productsList.ItemTemplate.SetBinding(TextCell.DetailProperty, "BarCode");


            var aceptar = new Button
            {
                Text = "Aceptar"
            };

            var buscar = this.FindByName<Button>("buscar");
            var buscarEntry = this.FindByName<Entry>("buscarEntry");
            var addEntry = new Entry();
            var addBarcode = new Entry();

            aceptar.Clicked += (sender, e) =>
            {
                var Product = addEntry.Text;
                var address = addEntry.Text;
                long newBarCode = 0;
                var barCodeAdd = long.TryParse(addBarcode.Text, out newBarCode); ;

                _database.AddProduct(Product, address, newBarCode);
                addEntry.Text = "";
                Refresh();
                returnToList();
            };

            buscar.Clicked += async (sender, e) =>
            {
                Console.Write("Boton");
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
                long barCode = 0;
                long.TryParse(newText, out barCode);
                productsList.ItemsSource = _database.GetProduct(newText, barCode);
            };
      


            var ProductEntryContentPage = new ContentPage
            {
                Padding = new Thickness(20),
                Content = new StackLayout
                {
                    Children = { addEntry, addBarcode, aceptar }
                }
            };


            Children.Add(ProductEntryContentPage);

            SelectedItem = Children.ElementAt<ContentPage>(0);


            productsList.ItemTapped += (sender, e) => {
                Type TargetType = typeof(FichaProducto);
                NavigationTo(new FichaProducto((Product)e.Item));
            };


        }

        public void Refresh()
        {
            productsList.ItemsSource = _database.GetProducts();
        }
        public void returnToList()
        {
            SelectedItem = Children.ElementAt<ContentPage>(0);
        }

        public async void NavigationTo(ContentPage page)
        {
            try
            {
                await ((RootPage)App.Current.MainPage).Detail.Navigation.PushAsync(page);
            }
            catch (Exception e)
            {
                //Console.Write(e.ToString());
            }

        }

    }
}
