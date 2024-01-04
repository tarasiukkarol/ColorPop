using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ColorPop
{
    internal class ColorPopAssembler : ColorPopInterface
    {
        public ColorPopAssembler(float[] chosenColor, int bytesPerPixel,
            int startIndex, int endIndex)
            : base(chosenColor, bytesPerPixel, startIndex, endIndex)
        { }

        [DllImport(@"C:\Users\karol\Desktop\ColorPop\x64\Debug\JAAsm.dll")]
        private static extern void ColorPop(
            float[] pixels, float[] chosenColor,
            float[] rgbRates, int startIndex, int endIndex);

        public override void ExecuteEffect(float[] allPixels)
        {
            ColorPop(allPixels, _chosenColor,
                _rgbRates, _startIndex, _endIndex);
        }
    }
}