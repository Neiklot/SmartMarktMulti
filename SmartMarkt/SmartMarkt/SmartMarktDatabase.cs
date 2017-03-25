using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
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
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SmartMarkt.txt");
        }

        public IEnumerable<Product> GetProducts()
        {
            return (from t in _connection.Table<Product>()
                    select t).ToList();
        }

        public IEnumerable<Product> GetProduct(string name,int barCode)
        {
            //return _connection.Table<Product>().FirstOrDefault(u => u.Name == name);
            //return _connection.Table<Product>().Where(p => p.Name == name);
            return _connection.Query<Product>(
                "SELECT * FROM Product WHERE name like '%"+ name + "%' or BarCode="+ barCode).AsEnumerable();
        }

        public void DeleteUset(int id)
        {
            _connection.Delete<Product>(id);
        }

        public void AddProduct(string name,string address,int barCode)
        {
            var newProduct = new Product
            {
                Name = name,
                Address = address,
                BarCode=barCode
            };

            _connection.Insert(newProduct);
        }

    }
}
