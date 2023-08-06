using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BigReactorSimulator.Tiles;

namespace BigReactorSimulator.Resources
{
    public static class TextureHelper
    {
        private static Dictionary<TileType, ImageSource> Textures;

        public static string GetPathInBlocks(string directoryInBlocks)
        {
            string blocksDirectory = ResourceLocator.GetInResource(Path.Combine("Textures", "Blocks"));
            return Path.Combine(blocksDirectory, directoryInBlocks);
        }

        public static string GetPathInLiquid(string pathInLiquid)
        {
            string liquidDirectory = ResourceLocator.GetInResource(Path.Combine("Textures", "Liquids"));
            return Path.Combine(liquidDirectory, pathInLiquid);
        }

        public static string GetPathInIcons(string pathInIcons)
        {
            string iconsDirectory = ResourceLocator.GetInResource(Path.Combine("Textures", "GuiIcons"));
            return Path.Combine(iconsDirectory, pathInIcons);
        }

        public static string GetConductor(TileType type)
        {
            return Path.Combine(GetPathInBlocks("Conductors"), type.GetFileName());
        }

        public static string GetReactor(TileType type)
        {
            return Path.Combine(GetPathInBlocks("Reactor"), type.GetFileName());
        }

        public static string GetLiquid(TileType type)
        {
            return GetPathInLiquid(type.GetFileName());
        }

        public static void LoadTextures()
        {
            Textures = new Dictionary<TileType, ImageSource>(11);

            // Reactor
            Textures.Add(TileType.BlockReactorCase,             new BitmapImage(new Uri(GetReactor(TileType.BlockReactorCase))));
            Textures.Add(TileType.BlockReactorCaseCorner,       new BitmapImage(new Uri(GetReactor(TileType.BlockReactorCaseCorner))));
            Textures.Add(TileType.BlockReactorCaseHorizontal,   new BitmapImage(new Uri(GetReactor(TileType.BlockReactorCaseHorizontal))));
            Textures.Add(TileType.BlockReactorCaseVertical,     new BitmapImage(new Uri(GetReactor(TileType.BlockReactorCaseVertical))));
            Textures.Add(TileType.BlockReactorControlRod,       new BitmapImage(new Uri(GetReactor(TileType.BlockReactorControlRod))));
            Textures.Add(TileType.BlockReactorFuelRod,          new BitmapImage(new Uri(GetReactor(TileType.BlockReactorFuelRod))));
            // Conductors
            Textures.Add(TileType.BlockConductorDiamond,        new BitmapImage(new Uri(GetConductor(TileType.BlockConductorDiamond))));
            Textures.Add(TileType.BlockConductorGold,           new BitmapImage(new Uri(GetConductor(TileType.BlockConductorGold))));
            Textures.Add(TileType.BlockConductorGraphite,       new BitmapImage(new Uri(GetConductor(TileType.BlockConductorGraphite))));
            Textures.Add(TileType.BlockConductorAir,            null); //new BitmapImage(new Uri(GetConductor(TileType.BlockConductorAir))));
            // Liquids
            Textures.Add(TileType.LiquidCryotheum,              new BitmapImage(new Uri(GetLiquid(TileType.LiquidCryotheum))));
            Textures.Add(TileType.LiquidEnder,                  new BitmapImage(new Uri(GetLiquid(TileType.LiquidEnder))));
            Textures.Add(TileType.LiquidRedstone,               new BitmapImage(new Uri(GetLiquid(TileType.LiquidRedstone))));
        }

        public static ImageSource GetTileTexture(TileType type)
        {
            return Textures[type];
        }
    }
}
