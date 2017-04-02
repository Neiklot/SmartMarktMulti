using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SmartMarkt
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public long barCode { get; set; }
        public Double price { get; set; }
        public int idCategorie { get; set; }
        public int idFamily { get; set; }

        public Double valorEnergetico { get; set; }
        public Double grasasSaturadas { get; set; }
        public Double grasasMonoinsaturadas { get; set; }
        public Double grasasPolisaturadas { get; set; }
        public Double hidratosDeCarbono { get; set; }
        public Double hidratosDeCarbonoAzucares { get; set; }
        public Double fibra { get; set; }
        public Double proteinas { get; set; }
        public Double sal { get; set; }
    }
}
