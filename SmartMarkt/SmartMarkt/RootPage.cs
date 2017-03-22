
using System;
using Xamarin.Forms;

namespace SmartMarkt
{
    public class RootPage : Xamarin.Forms.MasterDetailPage
    {
        public RootPage(ILoginManager ilm)
        {
            var menuPage = new MenuPage();

            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

            Master = menuPage;
            Detail = new NavigationPage(new MainPage(ilm));
        }

        void NavigateTo(MenuItem menu)
        {
            //Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            //Detail = new NavigationPage(displayPage);

            //IsPresented = false;
        }
    }
}