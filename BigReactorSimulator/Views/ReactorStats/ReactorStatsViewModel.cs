using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.ReactorStats
{
    public class ReactorStatsViewModel : BaseViewModel
    {
        private float _heat;
        /// <summary>
        /// Measured in celcius
        /// </summary>
        public float Heat
        {
            get => _heat;
            set => RaisePropertyChanged(ref _heat, value);
        }

        private float _rfOutput;
        /// <summary>
        /// Measured in RF/t. power output per tick
        /// </summary>
        public float RFOutput
        {
            get => _rfOutput;
            set => RaisePropertyChanged(ref _rfOutput, value);
        }

        private float _fuelUsage;
        /// <summary>
        /// Measures in mb/t. The waste output per second
        /// </summary>
        public float FuelUsage
        {
            get => _fuelUsage;
            set => RaisePropertyChanged(ref _fuelUsage, value);
        }

        private float _reactivity;
        /// <summary>
        /// Measured in percentage. the radioactivity i guess lol
        /// </summary>
        public float Reactivity
        {
            get => _reactivity;
            set => RaisePropertyChanged(ref _reactivity, value);
        }

        public ReactorStatsViewModel()
        {
            Heat = 0.0F;
            RFOutput = 0.0F;
            FuelUsage = 0.0F;
            Reactivity = 0.0F;
        }
    }
}
