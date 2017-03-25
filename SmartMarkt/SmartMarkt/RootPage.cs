
using System;
using Xamarin.Forms;

namespace SmartMarkt
{
    public class RootPage : Xamarin.Forms.MasterDetailPage
    {
        public RootPage(ILoginManager ilm,SmartMarktDatabase database)
        {
            var menuPage = new MenuPage();

            menuPage.Menu.ItemTapped += (sender, e) => NavigateTo(e.Item as MenuItem,ilm,database);

            Master = menuPage;
            Detail = new NavigationPage(new MainPage());
        }

        async void NavigateTo(MenuItem menu, ILoginManager ilm,SmartMarktDatabase database)
        {
            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);
            await Detail.Navigation.PushAsync(displayPage);
            IsPresented = false;
        
        }
    }
}