using System.Windows;
using System.Windows.Controls;
using BigReactorSimulator.Tiles;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Selector
{
    /// <summary>
    /// Interaction logic for TileSelectorControl.xaml
    /// </summary>
    public partial class TileSelectorControl : UserControl, BaseView<TileSelectorViewModel>
    {
        public TileSelectorViewModel Model
        {
            get => this.DataContext as TileSelectorViewModel;
            set => this.DataContext = value;
        }

        public TileSelectorControl()
        {
            InitializeComponent();
            Model = new TileSelectorViewModel(SetSelectorThickness, SetSelectedTileName);
            TileSelector.Initialise(Model);
            Model.SelectedType = TileType.BlockReactorControlRod;
        }

        private void SetSelectorThickness(Thickness thickness)
        {
            this.SelectorRectangle.Margin = thickness;
        }

        private void SetSelectedTileName(string name)
        {
            this.SelectedTileNamePreview.Text = name;
        }
    }
}
