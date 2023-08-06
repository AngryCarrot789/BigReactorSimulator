using System.Windows;
using System.Windows.Input;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.Main
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window, BaseView<MainViewModel>
    {
        public MainViewModel Model
        {
            get => this.DataContext as MainViewModel;
            set => this.DataContext = value;
        }

        public MainView()
        {
            InitializeComponent();
            Model = new MainViewModel
            {
                Reactor = ReactorControl.Model,
                Selector = SelectorControl.Model
            };
        }

        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Model.Selector.SelectedIndex++;
            }
            else if (e.Delta < 0)
            {
                Model.Selector.SelectedIndex--;
            }
            base.OnPreviewMouseWheel(e);
        }
    }
}
