using BigReactorSimulator.Views.Selector;

namespace BigReactorSimulator.Tiles
{
    public static class TileSelector
    {
        private static TileSelectorViewModel Selector;

        public static void Initialise(TileSelectorViewModel selector)
        {
            Selector = selector;
        }

        public static void SetSelectedTile(TileType type)
        {
            Selector.SelectedType = type;
        }

        public static TileType GetSelectedTile()
        {
            return Selector.SelectedType;
        }
    }
}
