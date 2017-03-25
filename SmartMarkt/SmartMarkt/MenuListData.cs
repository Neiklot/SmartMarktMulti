using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SmartMarkt
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Title = "Principal",
                IconSource = "leads.png",
                TargetType = typeof(MainPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Productos",
                IconSource = "usuarios.png",
                TargetType = typeof(ProductsPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Accounts",
                IconSource = "accounts.png",
                TargetType = typeof(FichaProducto)
            });

            this.Add(new MenuItem()
            {
                Title = "Opportunities",
                IconSource = "opportunities.png",
                TargetType = null
            });
        }
    }

}
