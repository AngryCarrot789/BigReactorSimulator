using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigReactorSimulator.Tiles
{
    public class TilePosition
    {
        public int X;
        public int Y;

        public TilePosition(int x, int y)
        {
            Set(x, y);
        }

        public void Set(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void OffsetBy(int x, int y)
        {
            X += x;
            Y += y;
        }

        public int DistanceX(int otherX)
        {
            if (X == otherX)
                return 0;

            return (otherX > X) ? (otherX - X) : (X - otherX);
        }

        public int DistanceY(int otherY)
        {
            if (Y == otherY)
                return 0;

            return (otherY > Y) ? (otherY - Y) : (X - otherY);
        }

        public override int GetHashCode()
        {
            return Hash(X, Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is TilePosition tilePosition)
                return tilePosition.X == this.X && tilePosition.Y == this.Y;
            return false;
        }

        public static int Hash(int x, int y)
        {
            return x + (y << 15);
        }
    }
}
