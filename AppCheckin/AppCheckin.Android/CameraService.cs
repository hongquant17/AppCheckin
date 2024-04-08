using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppCheckin.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(CameraService))]

namespace AppCheckin.Droid
{
    [Obsolete]
    public  class CameraService : Java.Lang.Object, ICameraService, ISurfaceHolderCallback
    {
        
        Android.Hardware.Camera camera;
        ISurfaceHolder holder;

        public void StartCameraPreview(object holder)
        {
            if (holder is ISurfaceHolder surfaceHolder)
            {
                this.holder = surfaceHolder;
            }

            camera = Android.Hardware.Camera.Open((int)CameraFacing.Front);
            camera.SetDisplayOrientation(90);
            camera.SetPreviewDisplay(this.holder);
            camera.StartPreview();
        }

        public void StopCameraPreview()
        {
            if (camera != null)
            {
                camera.StopPreview();
                camera.Release();
                camera = null;
            }
        }

        public void SurfaceChanged(ISurfaceHolder holder, Format format, int width, int height)
        {
            // Not needed
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            // Not needed
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            // Not needed
        }

        public async Task<byte[]> TakePictureAsync()
        {
            // Not needed for camera preview
            return null;
        }
    }
}