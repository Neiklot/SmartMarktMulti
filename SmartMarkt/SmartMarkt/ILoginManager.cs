using System;

namespace SmartMarkt
{
    public interface ILoginManager
    {
        void ShowMainPage();
        void Logout();
        void ShowUserEntryPage(ILoginManager ilm, SmartMarktDatabase database);
        void ShowUsersPage(ILoginManager ilm, SmartMarktDatabase database);
    }
}
