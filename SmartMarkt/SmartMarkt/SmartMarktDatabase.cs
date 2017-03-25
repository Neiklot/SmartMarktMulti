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
            _connection.CreateTable<Product>();
        }

        public IEnumerable<Product> GetProducts()
        {
            return (from t in _connection.Table<Product>()
                    select t).ToList();
        }

        public IEnumerable<Product> GetProduct(string name)
        {
            //return _connection.Table<Product>().FirstOrDefault(u => u.Name == name);
            //return _connection.Table<Product>().Where(p => p.Name == name);
            return _connection.Query<Product>(
                "SELECT * FROM Product WHERE name like '%"+ name + "%'").AsEnumerable();
        }

        public void DeleteUset(int id)
        {
            _connection.Delete<Product>(id);
        }

        public void AddProduct(string name,string address)
        {
            var newProduct = new Product
            {
                Name = name,
                Address = address
            };

            _connection.Insert(newProduct);
        }

    }
}
