using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartMarkt
{
	public partial class MainPage : ContentPage
	{
        Entry productName, productDescription;
        public MainPage(ILoginManager ilm)
		{
            InitializeComponent();
            var logout = new Button
            {
                Text = "Logout!",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var newProduct = new Button
            {
                Text = "Agregar Producto",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            logout.Clicked += (sender, e) =>
            {
                ilm.Logout();
            };

            var listView = new ListView();
            listView.ItemsSource = new List<string>(new string[] {
            "mono",
                  "monodroid",
                  "monotouch",
                  "monorail",
                  "monodevelop",
                  "monotone",
                  "monopoly",
                  "monomodal"});


            productName = new Entry { Text = "" };
            productDescription = new Entry { Text = "" };


            this.Content = new StackLayout
            {
                Padding = new Thickness(10, 40, 10, 10),
                Children =
                {
                    logout,
                    new Label { Text = "Nombre del producto", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) },
                    productName,
                    new Label { Text = "Descripción del producto", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) },
                    productDescription,
                    newProduct,
                    listView
                }
            };
        }
	}
}
