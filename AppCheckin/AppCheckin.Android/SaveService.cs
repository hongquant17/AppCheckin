using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Provider;
using AppCheckin.Droid.Services;
using Xamarin.Forms;
using Environment = Android.OS.Environment;

[assembly: Dependency(typeof(SaveService))]
namespace AppCheckin.Droid.Services
{
    public class SaveService : ISaveService
    {
        void ISaveService.SaveFile(string fileName, byte[] data)
        {
            string picPath = Path.Combine(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures).AbsolutePath);

            Directory.CreateDirectory(picPath);

            string filePath = Path.Combine(picPath, fileName);

            File.WriteAllBytes(filePath, data);
        }
    }
}
