using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ColorPop
{
    internal class ColorPopCpp : ColorPopInterface
    {
        public ColorPopCpp(float[] chosenColor, int bytesPerPixel,
            int startIndex, int endIndex)
            : base(chosenColor, bytesPerPixel, startIndex, endIndex)
        { }

        [DllImport(@"C:\Users\karol\Desktop\ColorPop\x64\Debug\Cpp.dll", EntryPoint = "ColorPopCpp")]
        private static extern void ColorPopCppAlgorithm(float[] pixels, int size, float[] chosenColor, float[] rgbRates, int bytesPerPixel, int startIndex, int endIndex);

        public override void ExecuteEffect(float[] allPixels)
        {
            ColorPopCppAlgorithm(allPixels, allPixels.Length, _chosenColor, _rgbRates, _bytesPerPixel, _startIndex, _endIndex);
        }
    }
}
