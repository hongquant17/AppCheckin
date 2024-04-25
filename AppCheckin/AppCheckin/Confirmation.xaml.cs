using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCheckin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Confirmation : ContentPage
    {
        private bool flag = true;
        private bool checkin; // checkin or register
        public Confirmation(bool checkin)
        {
            InitializeComponent();
            this.checkin = checkin;
            if (checkin)
            {
                alreadyCheckText.IsVisible = true;
                alreadyRegText.IsVisible = false;
            }
            else
            {
                alreadyCheckText.IsVisible = false;
                alreadyRegText.IsVisible = true;
            }
        }

        async void CheckinButton_Clicked(object sender, EventArgs e)
        {
            if (flag)
            {
                await Navigation.PushAsync(new CheckinPage());
            }
        }

        async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }
}