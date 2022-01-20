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
    public partial class ClientPage : ContentPage
    {
        private int Selected_Item_PK = -1;
        public ClientPage()
        {
            InitializeComponent();
        }
 
        private void Add_Button_Clicked(object sender, EventArgs e)
        {
            Client CL_Rec = new Client();
            CL_Rec.FName = F_NAME.Text.Trim();
            CL_Rec.LName = L_NAME.Text.Trim();
            CL_Rec.LicenseID = LICENSE.Text.Trim();
            CL_Rec.Phone = PHONE.Text.Trim();
            CL_Rec.Address = ADDRESS.Text.Trim();
            CL_Rec.Gender = male_gender.IsChecked == true ? "male" : "female";

            ConnectionClass.Conn.Insert(CL_Rec);
            Show_List();

            F_NAME.Text = "";
            L_NAME.Text = "";
            LICENSE.Text = "";
            PHONE.Text = "";
            ADDRESS.Text = "";
        }

        private void Update_Button_Clicked(object sender, EventArgs e)
        {
            if (Selected_Item_PK > -1)
            {
                Client CL_Rec = new Client();
                CL_Rec.ID = Selected_Item_PK;
                CL_Rec.FName = F_NAME.Text.Trim();
                CL_Rec.LName = L_NAME.Text.Trim();
                CL_Rec.LicenseID = LICENSE.Text.Trim();
                CL_Rec.Phone = PHONE.Text.Trim();
                CL_Rec.Address = ADDRESS.Text.Trim();
                CL_Rec.Gender = male_gender.IsChecked == true ? "male" : "female";
                ConnectionClass.Conn.Update(CL_Rec);
                Selected_Item_PK = -1;
                Show_List();

                F_NAME.Text = "";
                L_NAME.Text = "";
                LICENSE.Text = "";
                PHONE.Text = "";
                ADDRESS.Text = "";
                male_gender.IsChecked = true;
                female_gender.IsChecked = false;
            }
        }

        private void CLIENTS_LIST_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var client_tabbed = e.Item as Client;
            Selected_Item_PK = client_tabbed.ID;
            F_NAME.Text = client_tabbed.FName;
            L_NAME.Text = client_tabbed.LName;
            LICENSE.Text = client_tabbed.LicenseID;
            PHONE.Text = client_tabbed.Phone;
            ADDRESS.Text = client_tabbed.Address;
            // Gender select app
            if (client_tabbed.Gender == "male") {
                male_gender.IsChecked = true;
                female_gender.IsChecked = false;
            }
            else
            {
                male_gender.IsChecked = false;
                female_gender.IsChecked = true;
            }

        }

        private void Delete_Button_Clicked(object sender, EventArgs e)
        {
            if (Selected_Item_PK > -1)
            {
                ConnectionClass.Conn.Delete<Client>(Selected_Item_PK);
                Selected_Item_PK = -1;
                Show_List();

                F_NAME.Text = "";
                L_NAME.Text = "";
                LICENSE.Text = "";
                PHONE.Text = "";
                ADDRESS.Text = "";
                male_gender.IsChecked = true;
                female_gender.IsChecked = false;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Show_List();
            show_btn.IsVisible = false;
            CLIENTS_LIST.IsVisible = true;
        }
        private void Show_List()
        {

            var data = (from client in ConnectionClass.Conn.Table<Client>() select client);
            CLIENTS_LIST.ItemsSource = data;
        }
    }
}