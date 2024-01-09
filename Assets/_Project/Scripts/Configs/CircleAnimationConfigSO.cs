using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/CircleAnimationConfig", fileName = "CircleAnimationConfigSO", order = 0)]
    public class CircleAnimationConfigSO : ScriptableObject
    {
        public float startScale;
        public float growDuration;
        
        public float popDuration;   
        public float popScale;
    }
}