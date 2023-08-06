using System.Windows.Media;
using BigReactorSimulator.Resources;
using BigReactorSimulator.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.ReactorCosts
{
    public class CostableItemViewModel : BaseViewModel
    {
        private int _totalItems;
        public int TotalItems
        {
            get => _totalItems;
            set => RaisePropertyChanged(ref _totalItems, value);
        }

        private TileType _itemType;
        public TileType ItemType
        {
            get => _itemType;
            set => RaisePropertyChanged(ref _itemType, value, ChangeTileTexture);
        }

        private ImageSource _icon;
        public ImageSource Icon
        {
            get => _icon;
            set => RaisePropertyChanged(ref _icon, value);
        }

        private string _itemName;
        public string ItemName
        {
            get => _itemName;
            set => RaisePropertyChanged(ref _itemName, value);
        }

        private void ChangeTileTexture(TileType type)
        {
            try
            {
                Icon = TextureHelper.GetTileTexture(type);
                ItemName = type.GetReadableName();
            }
            catch { }
        }

        public CostableItemViewModel() { }

        public CostableItemViewModel(TileType itemType, int amount)
        {
            this.ItemType = itemType;
            this.TotalItems = amount;
        }

        public override int GetHashCode()
        {
            return ItemType.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is CostableItemViewModel cost)
            {
                return cost.ItemType == this.ItemType;
            }
            return false;
        }
    }
}
