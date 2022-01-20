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
    public partial class CarPage : ContentPage
    {
        private int Selected_Item_PK = -1;
        public CarPage()
        {
            InitializeComponent();
        }

        private void Add_Button_Clicked(object sender, EventArgs e)
        {
            Car Car_Rec = new Car();
            Car_Rec.Brand = CarBrand.Text.Trim();
            Car_Rec.Model = CarModel.Text.Trim();
            Car_Rec.Fuel = CarFuel.Text.Trim();
            Car_Rec.Mileage = double.Parse(CarMileage.Text.Trim());
            Car_Rec.Price = double.Parse(CarPrice.Text.Trim());
            Car_Rec.ImageURL = CarImage.SelectedItem.ToString() + ".jpg".Trim();

            ConnectionClass.Conn.Insert(Car_Rec);
            Show_List();

            CarBrand.Text = "";
            CarModel.Text = "";
            CarFuel.Text = "";
            CarMileage.Text = "";
            CarPrice.Text = "";
        }

        private void CARS_LIST_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var car_tabbed = e.Item as Car;
            Selected_Item_PK = car_tabbed.ID;
            CarBrand.Text = car_tabbed.Brand;
            CarModel.Text = car_tabbed.Model;
            CarFuel.Text = car_tabbed.Fuel;
            CarMileage.Text = car_tabbed.Mileage.ToString();
            CarPrice.Text = car_tabbed.Price.ToString();

           // string imgurl = car_tabbed.ImageURL;
            //int index = imgurl.IndexOf(".jpg");
            //CarImage.SelectedIndex = imgurl.Substring(0, index);
            //CarImage.Text = car_tabbed.ImageURL.ToString();
        }
        private void Update_Button_Clicked(object sender, EventArgs e)
        {
            if (Selected_Item_PK > -1)
            {
                Car Car_Rec = new Car();

                Car_Rec.Brand = CarBrand.Text.Trim();
                Car_Rec.Model = CarModel.Text.Trim();
                Car_Rec.Fuel = CarFuel.Text.Trim();
                Car_Rec.Mileage = double.Parse(CarMileage.Text.Trim());
                Car_Rec.Price = double.Parse(CarPrice.Text.Trim());
                Car_Rec.ImageURL = CarImage.SelectedItem.ToString() + ".jpg".Trim();

                ConnectionClass.Conn.Update(Car_Rec);
                Selected_Item_PK = -1;
                Show_List();

                CarBrand.Text = "";
                CarModel.Text = "";
                CarFuel.Text = "";
                CarMileage.Text = "";
                CarPrice.Text = "";
            }
        }

        private void Delete_Button_Clicked(object sender, EventArgs e)
        {
            if (Selected_Item_PK > -1)
            {
                ConnectionClass.Conn.Delete<Car>(Selected_Item_PK);
                Selected_Item_PK = -1;
                Show_List();

                CarBrand.Text = "";
                CarModel.Text = "";
                CarFuel.Text = "";
                CarMileage.Text = "";
                CarPrice.Text = "";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Show_List();
        }
        private void Show_List()
        {
            show_btn.IsVisible = false;
            var data = (from car in ConnectionClass.Conn.Table<Car>() select car);
            CARS_LIST.ItemsSource = data;
            CARS_LIST.IsVisible = true;
        }

    }
}