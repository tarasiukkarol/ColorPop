using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ColorPop
{
    public static class PixelsArray
    {
        public static BitmapSource BmpBGRArrayToImage(this float[] pixels, int width, int height, PixelFormat pixelFormat)
        {
            byte[] byteArray = pixels.ToByteArray();
            return byteArray.BmpBGRArrayToImage(width, height, pixelFormat);
        }

        public static byte[] ToByteArray(this float[] floatArray)
        {
            var newByteArray = new byte[floatArray.Length];
            for (int i = 0; i < newByteArray.Length; i++)
            {
                newByteArray[i] = (byte)floatArray[i];
            }
            return newByteArray;
        }
    }
}
