using System;
using System.IO;
using SmartMarkt.Android;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]

namespace SmartMarkt.Android
{
    class SQLite_Android: ISQLite
    {
        public SQLite_Android()
        {
        }

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "SmartMarkt.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
    }
}