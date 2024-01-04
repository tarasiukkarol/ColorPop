using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPop
{
    static class MechanismFactory
    {
        public static ColorPopInterface Create(ColorPopMechanismType mechanismType, float[] chosenColor, int bytesPerPixel, int startIndex, int endIndex)
        {
            switch (mechanismType)
            {
                case ColorPopMechanismType.Assembly:
                    return new ColorPopAssembler(chosenColor, bytesPerPixel, startIndex, endIndex);
                case ColorPopMechanismType.Cpp:
                    return new ColorPopCpp(chosenColor, bytesPerPixel, startIndex, endIndex);
                default:
                    return null;
            }
        }
    }
}
