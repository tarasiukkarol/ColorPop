using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPop
{
    static class MechanismFactory
    {
        public static ColorPopInterface Create(ColorPopMechanismType mechanismType, int bytesPerPixel, int startIndex, int endIndex)
        {
            switch (mechanismType)
            {
                case ColorPopMechanismType.Assembly:
                    //return new SepiaAssembly(bytesPerPixel, startIndex, endIndex);
                case ColorPopMechanismType.Cpp:
                    return new ColorPopCpp(bytesPerPixel, startIndex, endIndex);
                default:
                    return null;
            }
        }
    }
}
