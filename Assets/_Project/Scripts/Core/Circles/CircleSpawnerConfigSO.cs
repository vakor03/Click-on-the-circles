using UnityEngine;

namespace _Project.Scripts.Core.Circles
{
    [CreateAssetMenu(menuName = "Configs/CircleSpawnerConfig", fileName = "CircleSpawnerConfigSO", order = 0)]
    public class CircleSpawnerConfigSO : ScriptableObject
    {
        public float spawnInterval;
        public float spawnIntervalDecrease;
        public float minSpawnInterval;
        public int minSpawnCount;
        public int maxSpawnCount;
    }
}