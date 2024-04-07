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
        private bool alreadyCheck = true;

        public MainPage()
        {
            InitializeComponent();
        }

        async void CheckinButton_Clicked(object sender, EventArgs e)
        {
            if (alreadyCheck)
            {
                await Navigation.PushAsync(new CheckinOption());
            }
            else
            {
                await Navigation.PushAsync(new Confirmation());
            }
        }

        async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
        
    }
}
