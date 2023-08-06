using System.Collections.Generic;
using System.Diagnostics;
using BigReactorSimulator.BigReactor;
using BigReactorSimulator.Tiles;
using BigReactorSimulator.Views.Reactor;
using BigReactorSimulator.Views.ReactorCosts;
using BigReactorSimulator.Views.ReactorStats;
using BigReactorSimulator.Views.Selector;
using BigReactorSimulator.Views.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Main
{
    public class MainViewModel : BaseViewModel
    {
        public BigReactorViewModel Reactor { get; set; }

        public TileSelectorViewModel Selector { get; set; }

        public NewReactorViewModel NewReactor { get; set; }

        public ReactorStatsViewModel ReactorStats { get; }

        public ReactorEfficiencyViewModel ReactorEfficiency { get; }

        public ReactorCostsViewModel ReactorCosts { get; }

        public Command ShowNewWindowCommand { get; }

        public Command FillReactorCommand { get; }

        public int InternalWidth;
        public int InternalLength;
        public int InternalHeight;
        public bool IsReactorBuilt;

        public MainViewModel()
        {
            // these will only ever bind to the view once hense why they're just getters
            // properties are always settable in the constructor though ;)
            ReactorStats = new ReactorStatsViewModel();
            ReactorEfficiency = new ReactorEfficiencyViewModel();
            ReactorCosts = new ReactorCostsViewModel();

            ReactorStats.Heat = 10000;
            ShowNewWindowCommand = new Command(WindowManager.ShowNewReactor);

            FillReactorCommand = new Command(FillReactorWithSelectedTile);
        }

        // Called once all of the view models are loaded and not null
        public void ComponentsLoaded()
        {
            Reactor.OnTileChangedEvent += Reactor_OnTileChangedEvent;
        }

        private void Reactor_OnTileChangedEvent(TileType oldTile, TileType newTile)
        {
            if (IsReactorBuilt)
            {
                RecalculateLayout();
            }
        }

        public void CreateReactorFromView()
        {
            IsReactorBuilt = false;
            InternalWidth = NewReactor.Width;
            InternalLength = NewReactor.Length;
            InternalHeight = NewReactor.Height;

            int interiorX = InternalWidth;
            int interiorY = InternalLength;
            int totalX = interiorX + 2;
            int totalY = interiorY + 2;
            int totalHeight = InternalHeight + 2;

            Reactor.ClearColumn();
            Reactor.ClearRows();
            Reactor.ClearTiles();
            Reactor.SurfaceTiles.Clear();

            AddCasingTop(totalX);

            for(int y = 1; y <= interiorY; y++)
            {
                AddBordersAndTypeColumn(TileType.BlockConductorAir, totalX, y);
            }

            AddCasingBottom(totalX, totalY);

            IsReactorBuilt = true;
            RecalculateLayout();
        }

        public void FillReactorWithSelectedTile()
        {
            int interiorX = InternalWidth;
            int interiorY = InternalLength;

            TileType selected = TileSelector.GetSelectedTile();

            for (int y = 1; y <= interiorY; y++)
            {
                for (int x = 1; x <= interiorX; x++)
                {
                    Reactor.SetTile(selected, x, y);
                }
            }
        }

        public void RecalculateLayout()
        {
            List<LayoutCalculator.TileCountPair> tiles = 
                LayoutCalculator.CalculateSurfaceTiles(Reactor.SurfaceTiles, InternalLength, InternalWidth);

            int interiorX = InternalWidth;
            int interiorY = InternalLength;
            int totalX = interiorX + 2;
            int totalY = interiorY + 2;
            int totalHeight = InternalHeight + 2;

            int controlRodCount = 0;
            ReactorCosts.ClearItems();

            foreach(LayoutCalculator.TileCountPair surfacePair in tiles)
            {
                if (surfacePair.Tile == TileType.BlockReactorControlRod)
                {
                    controlRodCount = surfacePair.Count;
                    ReactorCosts.AddSingleCostable(surfacePair.Tile, surfacePair.Count);
                    ReactorCosts.AddCostableHeight(TileType.BlockReactorFuelRod, InternalHeight * surfacePair.Count);
                }
                else
                {
                    ReactorCosts.AddCostableHeight(surfacePair.Tile, InternalHeight * surfacePair.Count);
                }
            }
            ReactorCosts.AddCasingReactor(totalY, totalX, totalHeight, 3, controlRodCount);
        }

        private void AddCasingTop(int totalX)
        {
            for(int x = 0, totalXn1 = totalX - 1; x < totalX; x++)
            {
                if (x == 0 || x == totalXn1)
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseCorner, x, 0);
                }
                else
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseHorizontal, x, 0);
                }
            }
        }

        private void AddBordersAndTypeColumn(TileType type, int totalX, int currentY)
        {
            for (int x = 0, totalXn1 = totalX - 1; x < totalX; x++)
            {
                if (x == 0 || x == totalXn1)
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseVertical, x, currentY);
                }
                else
                {
                    Reactor.SetTile(type, x, currentY);
                }
            }
        }

        private void AddCasingBottom(int totalX, int totalY)
        {
            totalY = totalY - 1;
            for (int x = 0, totalXn1 = totalX - 1; x < totalX; x++)
            {
                if (x == 0 || x == totalXn1)
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseCorner, x, totalY);
                }
                else
                {
                    Reactor.SetUneditableTile(TileType.BlockReactorCaseHorizontal, x, totalY);
                }
            }
        }
    }
}
