using _Project.Scripts.Core.Circles;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/CircleConfig", fileName = "CircleConfigSO", order = 0)]
    public class CircleConfigSO : ScriptableObject
    {
        public Circle circlePrefab;
        public Color[] allCircleColors;
        public float minSize;
        public float maxSize;
        public float minLifetime;
        public float maxLifetime;
        public int scorePerCircle;
        public float timeToRemoveOnCircleClick;
    }
}