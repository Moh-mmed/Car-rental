using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Car_Rental_Project._DB
{
    class Rent
    {
        public string CAR { get; set; }
        public string TENANT_NAME { get; set; }
        public double DEPOSIT { get; set; }
        public string PRICE { get; set; }
        public string IMGURL { get; set; }
        public string RENT_DATE { get; set; }
    }
}
