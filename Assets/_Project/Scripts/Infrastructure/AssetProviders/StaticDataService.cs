using _Project.Scripts.Configs;
using _Project.Scripts.Core.Circles;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.AssetProviders
{
    public class StaticDataService : IInitializable
    {
        private IAssetProvider _assetProvider;
        private TimerConfigSO _timerConfig;
        private CircleConfigSO _circleConfig;
        private CircleAnimationConfigSO _circleAnimationConfig;
        private CircleSpawnerConfigSO _circleSpawnerConfig;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void Initialize()
        {
            LoadTimerConfig();
            LoadCircleConfig();
            LoadCircleAnimationConfig();
            LoadCircleSpawnerConfig();
        }

        public TimerConfigSO GetTimerConfig()
        {
            return _timerConfig;
        }
        
        public CircleConfigSO GetCircleConfig()
        {
            return _circleConfig;
        }
        
        public CircleAnimationConfigSO GetCircleAnimationConfig()
        {
            return _circleAnimationConfig;
        }
        
        public CircleSpawnerConfigSO GetCircleSpawnerConfig()
        {
            return _circleSpawnerConfig;
        }

        private void LoadTimerConfig()
        {
            _timerConfig = _assetProvider.Load<TimerConfigSO>(AssetPath.TIMER_CONFIG);
        }
        
        private void LoadCircleConfig()
        {
            _circleConfig = _assetProvider.Load<CircleConfigSO>(AssetPath.CIRCLE_CONFIG);
        }
        
        private void LoadCircleAnimationConfig()
        {
            _circleAnimationConfig = _assetProvider.Load<CircleAnimationConfigSO>(AssetPath.CIRCLE_ANIMATION_CONFIG);
        }
        
        private void LoadCircleSpawnerConfig()
        {
            _circleSpawnerConfig = _assetProvider.Load<CircleSpawnerConfigSO>(AssetPath.CIRCLE_SPAWNER_CONFIG);
        }
    }
}