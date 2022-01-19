using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;
using Car_Rental_Project.Droid;
[assembly: Dependency(typeof(SQLiteAndroid))]

namespace Car_Rental_Project.Droid
{
    public class SQLiteAndroid:DB_Connection
    {
        public SQLiteConnection GetConnection()
        {
            var DB_Name = "My_DB.sql";
            var Path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var Full_Path = System.IO.Path.Combine(Path, DB_Name);
            var Conn = new SQLiteConnection(Full_Path);
            return Conn;
        }
    }
}