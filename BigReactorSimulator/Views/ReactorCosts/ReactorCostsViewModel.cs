using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;
using BigReactorSimulator.BigReactor;
using BigReactorSimulator.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.ReactorCosts
{
    public class ReactorCostsViewModel : BaseViewModel
    {
        public ObservableCollection<CostableItemViewModel> Items { get; }
        public readonly Dictionary<TileType, CostableItemViewModel> ItemTypes;

        public ReactorCostsViewModel()
        {
            Items = new ObservableCollection<CostableItemViewModel>(new List<CostableItemViewModel>(8));
            ItemTypes = new Dictionary<TileType, CostableItemViewModel>();
        }

        private CostableItemViewModel CreateCostable(TileType type, int amount)
        {
            return new CostableItemViewModel(type, amount);
        }

        private void AddCostableItem(CostableItemViewModel item)
        {
            if (ItemTypes.TryGetValue(item.ItemType, out CostableItemViewModel costable))
            {
                costable.TotalItems += item.TotalItems;
            }
            else
            {
                ItemTypes.Add(item.ItemType, item);
                Items.Add(item);
            }
        }

        public void AddSingleCostable(TileType type, int amount)
        {
            AddCostableItem(CreateCostable(type, amount));
        }

        public void ClearItems()
        {
            Items.Clear();
            ItemTypes.Clear();
        }

        public CostableItemViewModel GetCostable(TileType type)
        {
            if (ItemTypes.TryGetValue(type, out CostableItemViewModel cost))
                return cost;
            return null;
        }

        public void AddCasingReactor(int lengthTotal, int widthTotal, int heightTotal, int otherBlocks, int controlRods)
        {
            AddSingleCostable(
                TileType.BlockReactorCase, 
                BasicCalculator.CalculateCasingReactor(lengthTotal, widthTotal, heightTotal, otherBlocks, controlRods));
        }

        public void AddCostableHeight(TileType tile, int internalHeight)
        {
            AddSingleCostable(tile, internalHeight);
        }

        public void AddFuelRods(int surfaceTiles, int internalHeight)
        {
            AddCostableHeight(TileType.BlockReactorFuelRod, surfaceTiles * internalHeight);
        }

        public void AddControlRods(int surfaceTiles, int internalHeight)
        {
            AddCostableHeight(TileType.BlockReactorControlRod, surfaceTiles * internalHeight);
        }


    }
}
