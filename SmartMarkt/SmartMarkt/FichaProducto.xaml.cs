using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMarkt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FichaProducto : ContentPage
	{
        public FichaProducto (Product product)
		{
			InitializeComponent ();
            Title = "Editar productos";
            var layoutButton = this.FindByName<StackLayout>("layoutButton");
            var editButton = new ActionButton();
            editButton.ButtonColor = Color.FromHex("#E91E63");
            editButton.ButtonIcon = "Editar";

            Entry barCodeEntry = this.FindByName<Entry>("BarCodeEntry");
            barCodeEntry.IsEnabled = false;

            Entry nameEntry = this.FindByName<Entry>("NameEntry");
            nameEntry.IsEnabled = false;

            Label name = new Label();


            name.Text = product.name;
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


            editButton.OnTouchesBegan += (sender, e) =>
            {
                 barCodeEntry.IsEnabled = !barCodeEntry.IsEnabled;
                 nameEntry.IsEnabled = !nameEntry.IsEnabled;
                if (barCodeEntry.IsEnabled)
                {
                    editButton.ButtonIcon = "Guardar";
                }
                else {
                    editButton.ButtonIcon = "Editar";
                }
            };

            layoutButton.Children.Add(editButton);
        }

    }
}
