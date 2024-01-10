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
            float[] rgbRates, float[] array, int startIndex, int endIndex);

        public override void ExecuteEffect(float[] allPixels)
        {
            float[] array = { 50.0f, 50.0f, 50.0f, 50.0f };
            ColorPop(allPixels, _chosenColor,
                _rgbRates, array, _startIndex, _endIndex);
        }
    }
}