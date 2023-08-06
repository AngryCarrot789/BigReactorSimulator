using System.Windows.Input;
using BigReactorSimulator.Tiles;

namespace BigReactorSimulator.Views.Tiles
{
    public class ChangableTileViewModel : TileViewModel
    {
        public ChangableTileViewModel()
        {
            base.CanDragChangeTile = true;
        }

        public override void OnClick()
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.CurrentType = TileSelector.GetSelectedTile();
            }
            else if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                this.CurrentType = TileType.BlockConductorAir;
            }
            else if (Mouse.MiddleButton == MouseButtonState.Pressed)
            {
                TileSelector.SetSelectedTile(this.CurrentType);
            }
        }
    }
}
