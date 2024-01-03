using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPop
{
    public abstract class ColorPopInterface
    {
        protected float[] _rgbRates = { 0.299f, 0.587f, 0.114f, 0.0f };
        protected int _startIndex;
        protected int _endIndex;
        protected int _bytesPerPixel;
        protected float[] _chosenColor;
        public ColorPopInterface(float[] chosenColor, int bytesPerPixel, int startIndex, int endIndex)
        {
            _chosenColor = chosenColor;
            _startIndex = startIndex;
            _endIndex = endIndex;
            _bytesPerPixel = bytesPerPixel;
        }

        public abstract void ExecuteEffect(float[] allPixels);
    }
}
