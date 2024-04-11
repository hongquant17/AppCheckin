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
	public partial class CheckinPage : ContentPage
	{
		public CheckinPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();


        }

        private  void OnCaptureClicked(object sender, EventArgs e)
        {
            
        }
    }
}