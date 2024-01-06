using System.Collections.Generic;
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

        private float _currentSpawnTime;
        private CoroutineHandle _coroutine;

        [Inject]
        public void Construct(StaticDataService staticDataService,
            ICircleFactory circleFactory)
        {
            _staticDataService = staticDataService;
            _circleFactory = circleFactory;
        }

        public void Initialize()
        {
            _circleSpawnerConfig = _staticDataService.GetCircleSpawnerConfig();
            _circleConfigSO = _staticDataService.GetCircleConfig();

            _currentSpawnTime = _circleSpawnerConfig.spawnInterval;
        }

        public void Spawn()
        {
            int spawnCount = Random.Range(_circleSpawnerConfig.minSpawnCount, _circleSpawnerConfig.maxSpawnCount);
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnSingleCircle();
            }
            
            _currentSpawnTime = Mathf.Clamp(
                _currentSpawnTime - _circleSpawnerConfig.spawnIntervalDecrease,
                _circleSpawnerConfig.minSpawnInterval,
                _currentSpawnTime);
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

        [ContextMenu(nameof(StartSpawning))]
        public void StartSpawning()
        {
            _coroutine = Timing.RunCoroutine(SpawnCoroutine());
        }

        private IEnumerator<float> SpawnCoroutine()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(_currentSpawnTime);
                Spawn();
            }
        }

        [ContextMenu(nameof(StopSpawning))]
        public void StopSpawning()
        {
            Timing.KillCoroutines(_coroutine);
        }

        [ContextMenu(nameof(Reset))]
        public void Reset()
        {
            StopSpawning();
            _currentSpawnTime = _circleSpawnerConfig.spawnInterval;
        }
    }
}