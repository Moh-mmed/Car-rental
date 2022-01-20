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
    public partial class HomePage : ContentPage
    {
        public HomePage()
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
            var data = (from car in ConnectionClass.Conn.Table<Rent>() select car);
            RENT_LIST_ITEMS.ItemsSource = data;
        }

        private void RENT_LIST_ITEMS_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Show_List();
        }
    }
}