using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Car_Rental_Project._DB;
namespace Car_Rental_Project
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            ConnectionClass.Conn = DependencyService.Get<DB_Connection>().GetConnection();
            ConnectionClass.Conn.CreateTable<Car>();
            ConnectionClass.Conn.CreateTable<Client>();
            ConnectionClass.Conn.CreateTable<Rent>();
        }
    }
}
