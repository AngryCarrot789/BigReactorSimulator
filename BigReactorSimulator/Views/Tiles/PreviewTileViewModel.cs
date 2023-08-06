using BigReactorSimulator.Tiles;

namespace BigReactorSimulator.Views.Tiles
{
    public class PreviewTileViewModel : TileViewModel
    {
        public PreviewTileViewModel()
        {
            base.CanDragChangeTile = true;
        }

        public override void OnClick()
        {
            TileSelector.SetSelectedTile(CurrentType);
        }
    }
}
