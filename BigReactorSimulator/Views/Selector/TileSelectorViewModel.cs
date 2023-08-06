using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup.Localizer;
using BigReactorSimulator.Tiles;
using BigReactorSimulator.Utilities;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Selector
{
    public class TileSelectorViewModel : BaseViewModel
    {
        private static Thickness THICKNESS_CRYOTHEUM = new Thickness(0, 0, 0, 0);
        private static Thickness THICKNESS_ENDER = new Thickness(65, 0, 0, 0);
        private static Thickness THICKNESS_DIAMOND = new Thickness(130, 0, 0, 0);
        private static Thickness THICKNESS_GRAPHITE = new Thickness(195, 0, 0, 0);
        private static Thickness THICKNESS_REDSTONE = new Thickness(0, 65, 0, 0);
        private static Thickness THICKNESS_CONTROLROD = new Thickness(65, 65, 0, 0);
        private static Thickness THICKNESS_GOLD = new Thickness(130, 65, 0, 0);
        private static Thickness THICKNESS_AIR = new Thickness(195, 65, 0, 0);

        private TileType _selectedType;
        public TileType SelectedType
        {
            get => _selectedType;
            set => RaisePropertyChanged(ref _selectedType, value, UpdateSelector);
        }

        // binding wont work for some reason...
        // unless im doing it wrong but im not.... wpf is broken lul
        private Action<Thickness> SetSelectorThickness;
        private Action<string> SetSelectedNamePreview;

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = MathsHelper.Clamp(value, 0, 7);
                UpdateSelectedIndex(_selectedIndex);
            }
        }

        public TileSelectorViewModel(Action<Thickness> setSelectorThickness, Action<string> setPreviewName)
        {
            this.SetSelectorThickness = setSelectorThickness;
            this.SetSelectedNamePreview = setPreviewName;
        }

        private void UpdateSelectedIndex(int index)
        {
            switch (index)
            {
                case 0:
                    SelectedType = TileType.LiquidCryotheum;
                    break;
                case 1:
                    SelectedType = TileType.LiquidEnder;
                    break;
                case 2:
                    SelectedType = TileType.BlockConductorDiamond;
                    break;
                case 3:
                    SelectedType = TileType.BlockConductorGraphite;
                    break;
                case 4:
                    SelectedType = TileType.LiquidRedstone;
                    break;
                case 5:
                    SelectedType = TileType.BlockReactorControlRod;
                    break;
                case 6:
                    SelectedType = TileType.BlockConductorGold;
                    break;
                case 7:
                    SelectedType = TileType.BlockConductorAir;
                    break;
                default:
                    break;
            }
        }

        public void UpdateSelector(TileType newType)
        {
            SetSelectedNamePreview(newType.GetReadableName());
            switch (newType)
            {
                case TileType.BlockReactorControlRod:
                    SetSelectorThickness(THICKNESS_CONTROLROD);
                    break;
                case TileType.BlockConductorDiamond:
                    SetSelectorThickness(THICKNESS_DIAMOND);
                    break;
                case TileType.BlockConductorGold:
                    SetSelectorThickness(THICKNESS_GOLD);
                    break;
                case TileType.BlockConductorGraphite:
                    SetSelectorThickness(THICKNESS_GRAPHITE);
                    break;
                case TileType.BlockConductorAir:
                    SetSelectorThickness(THICKNESS_AIR);
                    break;
                case TileType.LiquidCryotheum:
                    SetSelectorThickness(THICKNESS_CRYOTHEUM);
                    break;
                case TileType.LiquidEnder:
                    SetSelectorThickness(THICKNESS_ENDER);
                    break;
                case TileType.LiquidRedstone:
                    SetSelectorThickness(THICKNESS_REDSTONE);
                    break;
            }
        }
    }
}
