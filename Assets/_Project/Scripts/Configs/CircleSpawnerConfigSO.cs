using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/CircleSpawnerConfig", fileName = "CircleSpawnerConfigSO", order = 0)]
    public class CircleSpawnerConfigSO : ScriptableObject
    {
        [Header("Spawn intervals")]
        public float spawnInterval;
        public float spawnIntervalDecrease;
        public float minSpawnInterval;
        public float startSpawnInterval;
        [Header("Spawn count")]
        public int minSpawnCount;
        public int maxSpawnCount;
        public int maxSpawnTotal;
    }
}