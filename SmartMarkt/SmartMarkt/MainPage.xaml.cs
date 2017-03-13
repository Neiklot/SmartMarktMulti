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
            logout.Clicked += (sender, e) =>
            {
                ilm.Logout();
            };
            this.Content = new StackLayout
            {
                Children =
                {
                    logout
                }
            };
        }
	}
}
