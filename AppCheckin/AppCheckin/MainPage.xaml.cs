using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCheckin
{
    public partial class MainPage : ContentPage
    {
        private bool alreadyCheck = false;
        private bool alreadyRegister = false;

        public MainPage()
        {
            InitializeComponent();
        }

        async void CheckinButton_Clicked(object sender, EventArgs e)
        {
            if (!alreadyCheck)
            {
                await Navigation.PushAsync(new CheckinPage());
            }
            else
            {
                await Navigation.PushAsync(new Confirmation(true)); //true: chuan bi diem danh
            }
        }

        async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if (!alreadyRegister)
            {
                await Navigation.PushAsync(new Register());
            }
            else
            {
                await Navigation.PushAsync(new Confirmation(false)); // false: chuan bi lay mau
            }
        }
        
    }
}
