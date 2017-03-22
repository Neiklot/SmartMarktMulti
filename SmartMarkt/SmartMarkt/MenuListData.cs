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
                Title = "Contracts",
                IconSource = "contacts.png",
                TargetType = "A"
            });

            this.Add(new MenuItem()
            {
                Title = "Leads",
                IconSource = "leads.png",
                TargetType = "B"
            });

            this.Add(new MenuItem()
            {
                Title = "Accounts",
                IconSource = "accounts.png",
                TargetType = "C"
            });

            this.Add(new MenuItem()
            {
                Title = "Opportunities",
                IconSource = "opportunities.png",
                TargetType = "D"
            });
        }
    }

}
