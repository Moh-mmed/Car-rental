using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Car_Rental_Project._DB;

namespace Car_Rental_Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RentPage : ContentPage
    {
        private string TENANT_NAME_RENT;
        private string CAR_RENT;
        private string PRICE_RENT;
        private string IMG_RENT;
        public RentPage()
        {
            InitializeComponent();
        }

        private void LoadDataWrapper_Button_Clicked(object sender, EventArgs e)
        {
            Show_List();
            LoadDataWrapper.IsVisible = false;
            DataWrapper.IsVisible = true;
        }
        private void Show_List()
        {
            var CarData = (from car in ConnectionClass.Conn.Table<Car>() select car);
            var ClientData = (from car in ConnectionClass.Conn.Table<Client>() select car);
            CARS_LIST_ITEMS.ItemsSource = CarData;
            CLIENTS_LIST_ITEMS.ItemsSource = ClientData;
        }

        private void CLIENTS_LIST_ITEMS_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clientItem = e.Item as Client;
            TENANT_NAME_RENT = $"{clientItem.FName} {clientItem.LName}";
        }

        private void CARS_LIST_ITEMS_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var carItem = e.Item as Car;
            CAR_RENT = $"{carItem.Brand}, {carItem.Model}, {carItem.Fuel}, {carItem.Mileage} KM";
            PRICE_RENT = $"${carItem.Price}/DAY";
            IMG_RENT = carItem.ImageURL;
        }

        private async void Rent_Button_Clicked(object sender, EventArgs e)
        {
            Rent RENT_Rec = new Rent();
            RENT_Rec.TENANT_NAME = TENANT_NAME_RENT;
            RENT_Rec.CAR = CAR_RENT;
            RENT_Rec.DEPOSIT = double.Parse(DEPOSIT.Text.Trim());
            RENT_Rec.PRICE = PRICE_RENT;
            RENT_Rec.IMGURL = IMG_RENT;
            DateTime dateTime = DateTime.UtcNow.Date;
            RENT_Rec.RENT_DATE = dateTime.ToString("dd/MM/yyyy");

            if (ConnectionClass.Conn.Insert(RENT_Rec) >= 1) {
                await DisplayAlert("Note", "The operation has been made successfuly!", "OK");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Show_List();
        }
    }
}