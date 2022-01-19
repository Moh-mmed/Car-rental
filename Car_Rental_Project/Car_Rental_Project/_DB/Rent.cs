using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Car_Rental_Project._DB
{
    class Rent
    {
        [PrimaryKey]
        public int CAR_ID { get; set; }
        public string TENANT_NAME { get; set; }
        public double DEPOSIT { get; set; }
        public DateTime RENT_DATE { get; set; }
    }
}
