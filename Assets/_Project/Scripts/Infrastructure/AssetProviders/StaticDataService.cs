using _Project.Scripts.Infrastructure.Configs;
using Zenject;

namespace _Project.Scripts.Infrastructure.AssetProviders
{
    public class StaticDataService : IInitializable
    {
        private IAssetProvider _assetProvider;
        private TimerConfigSO _timerConfig;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void Initialize()
        {
            LoadTimerConfig();
        }

        public TimerConfigSO GetTimerConfig()
        {
            return _timerConfig;
        }

        private void LoadTimerConfig()
        {
            _timerConfig = _assetProvider.Load<TimerConfigSO>(AssetPath.TIMER_CONFIG);
        }
    }
}