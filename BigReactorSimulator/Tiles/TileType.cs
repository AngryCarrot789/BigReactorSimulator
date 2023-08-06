using System.Collections.Generic;

namespace BigReactorSimulator.Tiles
{
    public enum TileType
    {
        // The "normally editable" ones have a value bigger than 100
        // faster than checking for equality when tiles change

        // Case textures
        BlockReactorCase = 0,
        BlockReactorCaseCorner = 1,
        BlockReactorCaseHorizontal = 2,
        BlockReactorCaseVertical = 3,
        BlockReactorControlRod = 101,
        BlockReactorFuelRod =  5,

        // Conductors
        BlockConductorDiamond = 102,
        BlockConductorGold = 103,
        BlockConductorGraphite = 104,
        BlockConductorAir = 105,

        // Liquids
        LiquidCryotheum = 106,
        LiquidEnder = 107,
        LiquidRedstone = 108
    }

    public static class TileTypeHelper
    {
        private static Dictionary<TileType, string> TypeFileNames;
        private static Dictionary<TileType, string> TypeDisplayNames;

        static TileTypeHelper()
        {
            TypeFileNames = new Dictionary<TileType, string>();

            // Reactor
            TypeFileNames.Add(TileType.BlockReactorCase, "CaseConnectedCorner.png");
            TypeFileNames.Add(TileType.BlockReactorCaseCorner, "CaseConnectedCorner.png");
            TypeFileNames.Add(TileType.BlockReactorCaseHorizontal, "CaseConnectedHorizontal.png");
            TypeFileNames.Add(TileType.BlockReactorCaseVertical, "CaseConnectedVertical.png");
            TypeFileNames.Add(TileType.BlockReactorControlRod, "CaseControlRod.png");
            TypeFileNames.Add(TileType.BlockReactorFuelRod, "CaseFuelRod.png");
            // Conductors
            TypeFileNames.Add(TileType.BlockConductorDiamond, "BlockDiamond.png");
            TypeFileNames.Add(TileType.BlockConductorGold, "BlockGold.png");
            TypeFileNames.Add(TileType.BlockConductorGraphite, "BlockGraphite.png");
            TypeFileNames.Add(TileType.BlockConductorAir, "BlockAir.png");
            // Liquids
            TypeFileNames.Add(TileType.LiquidCryotheum, "LiquidCryotheum.png");
            TypeFileNames.Add(TileType.LiquidEnder, "LiquidEnder.png");
            TypeFileNames.Add(TileType.LiquidRedstone, "LiquidRedstone.png");

            TypeDisplayNames = new Dictionary<TileType, string>();

            // Reactor
            TypeDisplayNames.Add(TileType.BlockReactorCase, "Reactor Casing");
            TypeDisplayNames.Add(TileType.BlockReactorCaseCorner, "Connected Case (Corner)");
            TypeDisplayNames.Add(TileType.BlockReactorCaseHorizontal, "Connected Case (Horizontal)");
            TypeDisplayNames.Add(TileType.BlockReactorCaseVertical, "Connected Case (Vertical)");
            TypeDisplayNames.Add(TileType.BlockReactorControlRod, "Control Rod");
            TypeDisplayNames.Add(TileType.BlockReactorFuelRod, "Fuel Rod");
            // Conductors
            TypeDisplayNames.Add(TileType.BlockConductorDiamond, "Block of Diamond");
            TypeDisplayNames.Add(TileType.BlockConductorGold, "Block of Gold");
            TypeDisplayNames.Add(TileType.BlockConductorGraphite, "Block of Graphite");
            TypeDisplayNames.Add(TileType.BlockConductorAir, "Air");
            // Liquids
            TypeDisplayNames.Add(TileType.LiquidCryotheum, "Liquid Cryotheum");
            TypeDisplayNames.Add(TileType.LiquidEnder, "Liquid Ender");
            TypeDisplayNames.Add(TileType.LiquidRedstone, "Destabilized Redstone");
        }

        public static string GetFileName(this TileType type)
        {
            return TypeFileNames[type];
        }

        public static string GetReadableName(this TileType type)
        {
            return TypeDisplayNames[type];
        }
    }
}
