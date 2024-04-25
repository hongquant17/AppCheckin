using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCheckin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckinPage : ContentPage
	{
        bool PermissionsGranted;
        private int frameCounter = 0; 

		public CheckinPage ()
		{
			InitializeComponent ();
            cameraView.CameraOptions.AutoRotateImage = true;
        }

        void OnCaptureClicked(object sender, EventArgs e)
        {
            cameraView.Shutter();
            captureButton.Text = "Snap Picture";
        }

        void CameraView_OnAvailable(object sender, bool e)
        {
            if (e)
            {

            }
            

            captureButton.IsEnabled = e;
        }

        private async void MainPage_Appearing(object sender, EventArgs e)
        {
            PermissionsGranted = await VerifyPermissions();
            if (PermissionsGranted == false)
                return;

            else
            {
                //App.Current.MainPage
             }
        }

        private async Task<bool> VerifyPermissions() {
            try {
                PermissionStatus status = PermissionStatus.Unknown;

                status = await Permissions.CheckStatusAsync<Permissions.Camera>();

                if (status != PermissionStatus.Granted) {
                    await DisplayAlert("Camera Permission Required", "This app will proccess frames taken live from the device's camera", "OK");
                    status = await Permissions.RequestAsync<Permissions.Camera>(); 

                    if (status != PermissionStatus.Granted) {
                        return false;
                    }
                }

                return true;
            } catch(Exception ex) {
                await DisplayAlert("Error", ex.ToString(), "OK");
                return false;
            }

        }

        void CameraView_MediaCapture(object sender, MediaCapturedEventArgs e)
        {
            // previewPicture.IsVisible = true;
            previewPicture.Rotation = e.Rotation;
            previewPicture.Source = e.Image;
            cameraView.IsVisible = false;
            alignFaceText.IsVisible = false;
            captureButton.IsVisible = false;

            Console.WriteLine("____________________");
            Console.WriteLine(previewPicture.Height);
            Console.WriteLine(previewPicture.Width);
            Console.WriteLine(DeviceDisplay.MainDisplayInfo.Density);
            Console.WriteLine(DeviceDisplay.MainDisplayInfo.Height);
            Console.WriteLine(DeviceDisplay.MainDisplayInfo.Width);
            Console.WriteLine("____________________");


            if (captureButton.Text == "Live Capture")
            {
                captureButton.Text = "Stop";
                cameraView.FrameReceived += Camera_FrameReceived;
            }
            else
            {
                captureButton.Text = "Live Capture";
                cameraView.FrameReceived -= Camera_FrameReceived;
            }
        }

        private void Camera_FrameReceived(Leadtools.Camera.Xamarin.FrameHandlerEventArgs e)
        {
            frameCounter++;
            Device.BeginInvokeOnMainThread(() =>
            {
                alignFaceText.Text = $"Frames Processed: {frameCounter}";
            });
        }
    }
}