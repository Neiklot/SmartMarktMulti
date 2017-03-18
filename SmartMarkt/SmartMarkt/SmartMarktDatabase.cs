using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SmartMarkt
{
   public class SmartMarktDatabase
    {
        private SQLiteConnection _connection;

        public SmartMarktDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return (from t in _connection.Table<User>()
                    select t).ToList();
        }

        public User GetUser(int id)
        {
            return _connection.Table<User>().FirstOrDefault(u => u.Id == id);
        }

        public void DeleteUset(int id)
        {
            _connection.Delete<User>(id);
        }

        public void AddUser(string name,string address)
        {
            var newUser = new User
            {
                Name = name,
                Address = address
            };

            _connection.Insert(newUser);
        }

    }
}
