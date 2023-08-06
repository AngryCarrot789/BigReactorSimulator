using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigReactorSimulator.Utilities;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views
{
    public class NewReactorViewModel : BaseViewModel
    {
        private int _length;
        public int Length
        {
            get => _length;
            set => RaisePropertyChanged(ref _length, MathsHelper.Clamp(value, 0, 64));
        }

        private int _width;
        public int Width
        {
            get => _width;
            set => RaisePropertyChanged(ref _width, MathsHelper.Clamp(value, 0, 64));
        }

        private int _height;
        public int Height
        {
            get => _height;
            set => RaisePropertyChanged(ref _height, MathsHelper.Clamp(value, 0, 64));
        }

        public Command CreateReactorCommand { get; }
        public Command CancelCreateCommand { get; }

        private Action CreateReactorCallback;

        public NewReactorViewModel(Action createReactorCallback)
        {
            this.CreateReactorCallback = createReactorCallback;
            CreateReactorCommand = new Command(CreateReactor);

            CancelCreateCommand = new Command(WindowManager.HideNewReactor);
        }

        public void CreateReactor()
        {
            CreateReactorCallback();
            WindowManager.HideNewReactor();
        }
    }
}
