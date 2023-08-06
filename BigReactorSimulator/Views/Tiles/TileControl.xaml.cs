using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Tiles
{
    /// <summary>
    /// Interaction logic for ChangableTileControl.xaml
    /// </summary>
    public partial class TileControl : UserControl, BaseView<TileViewModel>
    {
        private static Thickness BORDER_VISIBLE = new Thickness(1, 1, 1, 1);
        private static Thickness BORDER_HIDDEN = new Thickness(0, 0, 0, 0);
        private static Thickness BORDER_INWARDS = new Thickness(0, 0, 0, 0);
        private static Thickness BORDER_OUTWARDS = new Thickness(-1, -1, -1, -1);

        public TileViewModel Model
        {
            get => base.DataContext as TileViewModel;
            set => base.DataContext = value;
        }

        private bool HasClicked;

        public TileControl()
        {
            InitializeComponent();
            HasClicked = false;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Model.CanDragChangeTile)
            {
                if (HasClicked)
                    return;

                if (Mouse.LeftButton == MouseButtonState.Pressed || Mouse.RightButton == MouseButtonState.Pressed)
                {
                    HasClicked = true;
                    Model.OnClick();
                }
            }

            if (Model.MouseOverHighlight)
            {
                TileBorder.BorderThickness = BORDER_VISIBLE;
                //TileIcon.Margin = BORDER_OUTWARDS;
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Model.CanDragChangeTile)
            {
                HasClicked = false;
            }

            if (Model.MouseOverHighlight)
            {
                TileBorder.BorderThickness = BORDER_HIDDEN;
                //TileIcon.Margin = BORDER_INWARDS;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Model.CanDragChangeTile)
            {
                if (HasClicked)
                    return;

                HasClicked = true;
                Model.OnClick();
            }
            else
            {
                HasClicked = true;
                Model.OnClick();
            }
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Model.CanDragChangeTile)
            {
                HasClicked = false;
            }
        }
    }
}
