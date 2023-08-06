using System.Collections.Generic;
using BigReactorSimulator.Tiles;
using BigReactorSimulator.Views.Tiles;

namespace BigReactorSimulator.BigReactor
{
    public static class LayoutCalculator
    {
        public class TileCountPair
        {
            public TileType Tile;
            public int Count;

            public TileCountPair(TileType type, int count)
            {
                Tile = type;
                Count = count;
            }

            public override int GetHashCode()
            {
                return Tile.GetHashCode() + (Count << 15);
            }

            public override bool Equals(object obj)
            {
                if (obj is TileCountPair tile)
                    return tile.Count == this.Count && tile.Tile == this.Tile;
                return false;
            }
        }

        private static Dictionary<TileType, TileCountPair> Tiles;

        static LayoutCalculator()
        {
            Tiles = new Dictionary<TileType, TileCountPair>(256);
        }

        public static List<TileCountPair> CalculateSurfaceTiles(Dictionary<int, TileViewModel> tiles, int internalLength, int internalWidth)
        {
            for (int y = 1; y <= internalLength; y++)
            {
                for (int x = 1; x <= internalWidth; x++)
                {
                    int hash = TilePosition.Hash(x, y);
                    TileViewModel tile = tiles[hash];

                    if (Tiles.TryGetValue(tile.CurrentType, out TileCountPair pair))
                    {
                        pair.Count++;
                    }
                    else
                    {
                        Tiles.Add(tile.CurrentType, new TileCountPair(tile.CurrentType, 1));
                    }
                }
            }

            List<TileCountPair> values = new List<TileCountPair>(Tiles.Values);
            Tiles.Clear();
            return values;
        }
    }
}
