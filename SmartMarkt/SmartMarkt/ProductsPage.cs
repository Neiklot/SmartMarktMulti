﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SmartMarkt
{
    public class ProductsPage : CarouselPage
    {
        private SmartMarktDatabase _database;
        private ListView _ProductList;
        private ListView _busquedaList;

        public ProductsPage()
        {

            SmartMarktDatabase database = new SmartMarktDatabase();
            _database = database;
            Title = "Productos";
            var Products = _database.GetProducts();

            _ProductList = new ListView();
            _ProductList.ItemsSource = Products;
            _ProductList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _ProductList.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            _ProductList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Address");

            _busquedaList = new ListView();
            _ProductList.ItemsSource = Products;
            _busquedaList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _busquedaList.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            _busquedaList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Address");

            var aceptar = new Button
            {
                Text = "Aceptar"
            };

            var buscar = new Button
            {
                Text = "Buscar"
            };

            var addEntry = new Entry();
            var buscarEntry = new Entry();

            aceptar.Clicked += (sender, e) =>
            {
                var Product = addEntry.Text;
                var address = addEntry.Text;

                _database.AddProduct(Product, address);
                addEntry.Text= "";
                Refresh();
                returnToList();
            };
            buscar.Clicked += (sender, e) =>
            {
                var Product = buscarEntry.Text;
                _busquedaList.ItemsSource = _database.GetProduct(Product);
             };

            var ProductsListContentPage = new ContentPage
            {
                Padding = new Thickness(20),
                Content = new StackLayout
                {
                    Children = { _ProductList },
                }
            };


            var ProductEntryContentPage = new ContentPage
            {
                Padding = new Thickness(20),
                Content = new StackLayout
                {
                    Children = { addEntry, aceptar }
                }
            };

            var buscarContentPage = new ContentPage
            {
                Padding = new Thickness(20),
                Content = new StackLayout
                {
                    Children = { buscarEntry, buscar, _busquedaList }
                }
            };
      
            Children.Add(ProductsListContentPage);
            Children.Add(buscarContentPage);
            Children.Add(ProductEntryContentPage);
         
            SelectedItem = Children.ElementAt<ContentPage>(0);



        }

        public void Refresh()
        {
            _ProductList.ItemsSource = _database.GetProducts();
        }
        public void returnToList() {
            SelectedItem = Children.ElementAt<ContentPage>(0);
        }
    }
}
