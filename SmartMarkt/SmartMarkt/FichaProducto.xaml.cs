using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMarkt
{
	public partial class FichaProducto : ContentPage
	{
		public FichaProducto (Product product)
		{
			InitializeComponent ();


            Label name = new Label();
            name.Text = product.Name;
            var cerrar = new Button { Text = "Cerrar" };
            cerrar.Clicked += async (sender, e) =>
            {
                try
                {
                    await ((RootPage)App.Current.MainPage).Detail.Navigation.PopAsync();
                }
                catch (Exception ex) {
                    Console.Write(ex.ToString());
                }
            };

                Content =new StackLayout
            {
                Children = {
                    name,cerrar
                }
            };
		}
	}
}
