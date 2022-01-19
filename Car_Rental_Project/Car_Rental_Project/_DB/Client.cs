using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Car_Rental_Project._DB
{
    class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string LicenseID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
