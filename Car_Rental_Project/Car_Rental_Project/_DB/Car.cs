using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Car_Rental_Project._DB
{
    class Car
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Fuel { get; set; }
        public double Mileage { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
