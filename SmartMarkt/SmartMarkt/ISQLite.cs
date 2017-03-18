using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMarkt
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
