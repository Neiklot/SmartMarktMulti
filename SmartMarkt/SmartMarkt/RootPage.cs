
using System;
using Xamarin.Forms;

namespace SmartMarkt
{
    public class RootPage : Xamarin.Forms.MasterDetailPage
    {
        public RootPage(ILoginManager ilm,SmartMarktDatabase database)
        {
            var menuPage = new MenuPage();

            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem,ilm,database);

            Master = menuPage;
            Detail = new NavigationPage(new MainPage());
        }

        void NavigateTo(MenuItem menu, ILoginManager ilm,SmartMarktDatabase database)
        {
            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);
            Detail = new NavigationPage(displayPage);
            IsPresented = false;
        
        }
    }
}