namespace BigReactorSimulator.Views.Tiles
{
    public class UnchangableTileViewModel : TileViewModel
    {
        public UnchangableTileViewModel()
        {
            base.CanDragChangeTile = false;
            base.MouseOverHighlight = false;
        }

        public override void OnClick()
        {

        }
    }
}
