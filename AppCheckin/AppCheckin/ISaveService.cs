using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppCheckin
{
    public interface ISaveService
    {
        void SaveFile(string fileName, byte[] data);
    }
}
