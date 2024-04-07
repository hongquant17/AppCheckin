using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCheckin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckinOption : ContentPage
    {
        public CheckinOption()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowCameraStream();
        }

        private async void ShowCameraStream()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera available.", "OK");
                return;
            }

            var mediaOptions = new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            };

            var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);

            if (file == null)
                return;

            resultImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        async void CaptureButton_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
            }
        }

    }
}