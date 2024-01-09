using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/AudioManagerConfig", fileName = "AudioManagerConfigSO", order = 0)]
    public class AudioManagerConfigSO : ScriptableObject
    {
        public AudioClip popSound;
        public float popSoundVolume;
    }
}