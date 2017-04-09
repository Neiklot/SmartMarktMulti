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
        private SmartMarktDatabase database;

        public FichaProducto (Product product)
		{
			InitializeComponent ();

            database = new SmartMarktDatabase();
            if (product == null) {
                product = new Product();
            }

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
                BarCodeEntry.IsEnabled = !BarCodeEntry.IsEnabled;
                NameEntry.IsEnabled = !NameEntry.IsEnabled;
                PriceEntry.IsEnabled = !PriceEntry.IsEnabled;
                CategoryEntry.IsEnabled = !CategoryEntry.IsEnabled;
                FamilyEntry.IsEnabled = !FamilyEntry.IsEnabled;
                ValorEnergeticoEntry.IsEnabled = !ValorEnergeticoEntry.IsEnabled;
                GrasasSaturadasEntry.IsEnabled = !GrasasSaturadasEntry.IsEnabled;
                GrasasMonoinsaturadasEntry.IsEnabled = !GrasasMonoinsaturadasEntry.IsEnabled;
                GrasasPolisaturadasEntry.IsEnabled = !GrasasPolisaturadasEntry.IsEnabled;
                HidratosDeCarbonoEntry.IsEnabled = !HidratosDeCarbonoEntry.IsEnabled;
                HidratosDeCarbonoAzucaresEntry.IsEnabled = !HidratosDeCarbonoAzucaresEntry.IsEnabled;
                FibraEntry.IsEnabled = !FibraEntry.IsEnabled;
                ProteinasEntry.IsEnabled = !ProteinasEntry.IsEnabled;
                SalEntry.IsEnabled = !SalEntry.IsEnabled;


                if (NameEntry.IsEnabled)
                {
                    editButton.ButtonIcon = "Guardar";
                } else {

                    database.AddProduct(NameEntry.Text, Convert.ToDouble(PriceEntry.Text), Convert.ToInt64(BarCodeEntry.Text));

                    editButton.ButtonIcon = "Editar";
                }
            };

            layoutButton.Children.Add(editButton);
        }

    }
}
