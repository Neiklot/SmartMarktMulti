using SQLite;
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
        private readonly SQLite.SQLiteConnection sqlConnection;

        public SmartMarktDatabase()
        {
            const string filename = "SmartMarkt.db3";
            var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            sqlConnection = new SQLite.SQLiteConnection(path);
            sqlConnection.CreateTable<Product>();
            //string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SmartMarkt.txt");
        }

        public IEnumerable<Product> GetProducts()
        {
            return (from t in sqlConnection.Table<Product>()
                    select t).ToList();
        }

        public IEnumerable<Product> GetProduct(string name, long barCode)
        {
            //return _connection.Table<Product>().FirstOrDefault(u => u.Name == name);
            //return _connection.Table<Product>().Where(p => p.Name == name);
            var sql = "SELECT * FROM Product WHERE name like '%" + name + "%' ";
            if (barCode != 0)
            {
                sql += " or BarCode = " + barCode;
            }


            return sqlConnection.Query<Product>(sql).AsEnumerable();
        }

        public void DeleteUser(int id)
        {
            sqlConnection.Delete<Product>(id);
        }

        public void AddProduct(string name, Double price, long barCode)
        {
            var newProduct = new Product
            {
                name = name,
                barCode = barCode,
                price = price
            };

            sqlConnection.Insert(newProduct);
        }

    }
}
