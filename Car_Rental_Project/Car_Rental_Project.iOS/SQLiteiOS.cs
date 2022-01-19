using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using SQLite;
using Car_Rental_Project.iOS;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLiteiOS))]


namespace Car_Rental_Project.iOS
{
    public class SQLiteiOS:DB_Connection
    {
        public SQLiteConnection GetConnection()
        {
            var DB_Name = "My_DB.sql";
            var Path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var Full_Path = System.IO.Path.Combine(Path, DB_Name);
            var Conn = new SQLiteConnection(Full_Path);
            return Conn;
        }
    }
}