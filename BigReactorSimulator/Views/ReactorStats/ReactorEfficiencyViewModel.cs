using BigReactorSimulator.Utilities;
using REghZyFramework.Utilities;

namespace BigReactorSimulator.Views.ReactorStats
{
    public class ReactorEfficiencyViewModel : BaseViewModel
    {
        private float _ingotWastePerMinute;
        public float IngotWastePerMinute
        {
            get => _ingotWastePerMinute;
            set => RaisePropertyChanged(ref _ingotWastePerMinute, value);
        }

        private float _rfPerMbWaste;
        public float RFPerMBWaste
        {
            get => _rfPerMbWaste;
            set => RaisePropertyChanged(ref _rfPerMbWaste, value);
        }

        private float _rfPerBlock;
        public float RFPerBlock
        {
            get => _rfPerBlock;
            set => RaisePropertyChanged(ref _rfPerBlock, value);
        }

        private float _rfPerMbWastePerBlock;
        public float RFPerMBWastePerBlock
        {
            get => _rfPerMbWastePerBlock;
            set => RaisePropertyChanged(ref _rfPerMbWastePerBlock, value);
        }

        public ReactorEfficiencyViewModel()
        {
            IngotWastePerMinute = 0.0F;
            RFPerMBWaste = 0.0F;
            RFPerBlock = 0.0F;
            RFPerMBWastePerBlock = 0.0F;
        }

        public void CalculateWastePerMinute(float mbWastePerTick)
        {
            IngotWastePerMinute = mbWastePerTick * MinecraftUtils.TicksPerSecond * 60;
        }

        public void CalculateRFPerWaste(float rfPerTick, float mbWastePerTick)
        {
            RFPerMBWaste = rfPerTick / mbWastePerTick;
        }

        public void CalculateFromStats(ReactorStatsViewModel stats)
        {
            CalculateWastePerMinute(stats.FuelUsage);
            CalculateRFPerWaste(stats.RFOutput, stats.FuelUsage);
        }
    }
}
