using System;
using System.Windows.Media;
using BigReactorSimulator.Resources;
using BigReactorSimulator.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Tiles
{
    public abstract class TileViewModel : BaseViewModel
    {
        private TileType _currentType;
        public TileType CurrentType
        {
            get => _currentType;
            set
            {
                TileType previous = _currentType;
                RaisePropertyChanged(ref _currentType, value, ChangeTileTexture);
                OnTileChanged?.Invoke(previous, value);
            }
        }

        private ImageSource _icon;
        public ImageSource Icon
        {
            get => _icon;
            set => RaisePropertyChanged(ref _icon, value);
        }

        public Action<TileType, TileType> OnTileChanged { get; set; }

        /// <summary>
        /// States if the <see cref="OnClick"/> function will be called if you're holding left click down
        /// while moving your mouse over different tiles. This should be <see langword="true"/> for 
        /// reactor tiles, but <see langword="false"/> for the tile selectors
        /// </summary>
        public bool CanDragChangeTile { get; set; }

        /// <summary>
        /// Whether to "highlight" the control when the mouse is over and "unhighlight" when the mouse leaves
        /// </summary>
        public bool MouseOverHighlight { get; set; }

        public TileViewModel()
        {
            CanDragChangeTile = false;
            MouseOverHighlight = true;
        }

        private void ChangeTileTexture(TileType type)
        {
            try
            {
                Icon = TextureHelper.GetTileTexture(type);
            }
            catch { }
        }

        public abstract void OnClick();
    }
}
