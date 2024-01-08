using System.Collections.Generic;
using _Project.Scripts.Configs;
using _Project.Scripts.Infrastructure.AssetProviders;
using MEC;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Circles
{
    public interface ICircleSpawner
    {
    }

    // TODO: Gameplay installer
    // TODO: Gameplay state machine
    // TODO: max spawn count

    public class CircleSpawner : MonoBehaviour, ICircleSpawner, IInitializable
    {
        [SerializeField] private Transform spawnArea;

        private StaticDataService _staticDataService;
        private CircleSpawnerConfigSO _circleSpawnerConfig;
        private CircleConfigSO _circleConfigSO;
        private ICircleFactory _circleFactory;
        private CirclesHolder _circlesHolder;

        private float _currentSpawnTime;
        private CoroutineHandle _coroutine;

        [Inject]
        public void Construct(StaticDataService staticDataService,
            ICircleFactory circleFactory,
            CirclesHolder circlesHolder)
        {
            _staticDataService = staticDataService;
            _circleFactory = circleFactory;
            _circlesHolder = circlesHolder;
        }

        public void Initialize()
        {
            _circleSpawnerConfig = _staticDataService.GetCircleSpawnerConfig();
            _circleConfigSO = _staticDataService.GetCircleConfig();

            _currentSpawnTime = _circleSpawnerConfig.spawnInterval;
        }

        public void Spawn()
        {
            var spawnCount = CalculateSpawnCount();

            for (int i = 0; i < spawnCount; i++)
            {
                SpawnSingleCircle();
            }

            _currentSpawnTime = Mathf.Clamp(
                _currentSpawnTime - _circleSpawnerConfig.spawnIntervalDecrease,
                _circleSpawnerConfig.minSpawnInterval,
                _currentSpawnTime);
        }

        private int CalculateSpawnCount()
        {
            int spawnCount = Random.Range(_circleSpawnerConfig.minSpawnCount, _circleSpawnerConfig.maxSpawnCount);
            spawnCount = Mathf.Clamp(_circlesHolder.CirclesCount + spawnCount, 0, _circleSpawnerConfig.maxSpawnTotal)
                         - _circlesHolder.CirclesCount;
            return spawnCount;
        }

        private void SpawnSingleCircle()
        {
            float size = Random.Range(_circleConfigSO.minSize, _circleConfigSO.maxSize);
            Color color = _circleConfigSO.allCircleColors[Random.Range(0, _circleConfigSO.allCircleColors.Length)];
            float lifetime = Random.Range(_circleConfigSO.minLifetime, _circleConfigSO.maxLifetime);
            var position = GetRandomPosition(size);

            _circleFactory.Create(position, size, lifetime, color);
        }

        private Vector2 GetRandomPosition(float size)
        {
            float halfWidth = spawnArea.localScale.x / 2 - size / 2;
            float halfHeight = spawnArea.localScale.y / 2 - size / 2;

            float randomX = Random.Range(-halfWidth, halfWidth);
            float randomY = Random.Range(-halfHeight, halfHeight);

            Vector2 randomPosition = new Vector2(randomX, randomY) + (Vector2)spawnArea.position;

            return randomPosition;
        }

        public void StartSpawning()
        {
            _coroutine = Timing.RunCoroutine(SpawnCoroutine());
        }

        public void Reset()
        {
            StopSpawning();
            _currentSpawnTime = _circleSpawnerConfig.spawnInterval;
        }

        private void StopSpawning()
        {
            Timing.KillCoroutines(_coroutine);
        }

        private IEnumerator<float> SpawnCoroutine()
        {
            yield return Timing.WaitForSeconds(_circleSpawnerConfig.startSpawnInterval);
            
            while (true)
            {
                Spawn();
                yield return Timing.WaitForSeconds(_currentSpawnTime);
            }
        }
    }
}