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
		public CheckinPage ()
		{
			InitializeComponent ();
    
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

        void CameraView_MediaCapture(object sender, MediaCapturedEventArgs e)
        {
            previewPicture.IsVisible = true;
            previewPicture.Rotation = e.Rotation;
            previewPicture.Source = e.Image;
            cameraView.IsVisible = false;
            alignFaceText.IsVisible = false;
            captureButton.IsVisible = false;

            //byte[] imageBytes = await ConvertImageSourceToBytes(e.Image);

            //var fileName = Path.Combine(FileSystem.CacheDirectory, "captured_image.jpg");
            //File.WriteAllBytes(fileName, imageBytes);

            //Console.WriteLine("Image saved successfully to: " + fileName);
            Console.WriteLine("____________________");
            Console.WriteLine(previewPicture.Height);
            Console.WriteLine(previewPicture.Width);
            Console.WriteLine(DeviceDisplay.MainDisplayInfo.Density);
            Console.WriteLine(DeviceDisplay.MainDisplayInfo.Height);
            Console.WriteLine(DeviceDisplay.MainDisplayInfo.Width);
            Console.WriteLine("____________________");
        }

    }
}