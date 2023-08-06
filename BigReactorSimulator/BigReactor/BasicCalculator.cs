using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigReactorSimulator.BigReactor
{
    public static class BasicCalculator
    {
        public static int CalculateCasingReactor(int lengthTotal, int widthTotal, int heightTotal, int otherBlocks, int controlRods)
        {
            int cornerCount = heightTotal;
            int doubleCorner = cornerCount * 2;
            int internalWidth = widthTotal - 2;
            int internalLength = lengthTotal - 2;

            int widthCasings = heightTotal * widthTotal;
            int lengthCasings = (heightTotal * lengthTotal) - doubleCorner;
            int bottomCasing = internalLength * internalWidth;
            int topCasing = bottomCasing - controlRods;
            return ((widthCasings + lengthCasings) * 2) + (bottomCasing + topCasing) - otherBlocks;
        }
    }
}
