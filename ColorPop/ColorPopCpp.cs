using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ColorPop
{
    internal class ColorPopCpp : ColorPopInterface
    {
        public ColorPopCpp(int bytesPerPixel,
            int startIndex, int endIndex)
            : base(bytesPerPixel, startIndex, endIndex)
        { }

        [DllImport(@"C:\Users\karol\Desktop\ColorPop\x64\Debug\Cpp.dll", EntryPoint = "ColorPopCpp")]
        private static extern void ColorPopCppAlgorithm(float[] pixels, int size, float[] rgbRates, int bytesPerPixel, int startIndex, int endIndex);

        public override void ExecuteEffect(float[] allPixels)
        {
            ColorPopCppAlgorithm(allPixels, allPixels.Length, _rgbRates, _bytesPerPixel, _startIndex, _endIndex);
        }
    }
}
