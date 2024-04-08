using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppCheckin
{
    public interface ICameraService
    {
        Task<byte[]> TakePictureAsync();
        void StartCameraPreview(object holder);
        void StopCameraPreview();
    }
}
