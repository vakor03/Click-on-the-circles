using _Project.Scripts.Configs;
using _Project.Scripts.Infrastructure.AssetProviders;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Circles
{
    public class AudioManager : IInitializable
    {
        private AudioManagerConfigSO _audioManagerConfigSO;
        private StaticDataService _staticDataService;
        
        public AudioManager(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            _audioManagerConfigSO = _staticDataService.GetAudioManagerConfig();
        }

        public void PlayPopSound()
        {
            AudioSource.PlayClipAtPoint(_audioManagerConfigSO.popSound, Camera.main.transform.position, _audioManagerConfigSO.popSoundVolume);
        }
    }
}