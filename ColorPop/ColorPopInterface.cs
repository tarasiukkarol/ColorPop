using System;
using System.Collections.Generic;
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

        public ColorPopInterface(int bytesPerPixel, int startIndex, int endIndex)
        {
            _startIndex = startIndex;
            _endIndex = endIndex;
            _bytesPerPixel = bytesPerPixel;
        }

        public abstract void ExecuteEffect(float[] allPixels);
    }
}
