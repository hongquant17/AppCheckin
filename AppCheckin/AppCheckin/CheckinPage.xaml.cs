using System;
using Xamarin.CommunityToolkit.UI.Views;
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

        void CameraView_MediaCaptured(object sender, MediaCapturedEventArgs e)
        {

            previewPicture.IsVisible = true;
            previewPicture.Rotation = e.Rotation;
            previewPicture.Source = e.Image;
            cameraView.IsVisible = false;
            alignFaceText.IsVisible = false;
            captureButton.IsVisible = false;
            
            //Console.WriteLine("+++++++++++++++");
            //Console.WriteLine(previewPicture.Height);
            //Console.WriteLine(previewPicture.Width);

        }

    }
}