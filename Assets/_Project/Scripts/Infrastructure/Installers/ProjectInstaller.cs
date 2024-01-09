using _Project.Scripts.Core.Circles;
using _Project.Scripts.Core.Score;
using _Project.Scripts.Core.Timer;
using _Project.Scripts.Infrastructure.AssetProviders;
using _Project.Scripts.Infrastructure.StateMachines;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
            
            BindStaticDataService();

            BindTimerService();
            
            BindScoreCounterService();

            BindAssetProvider();

            BindStatesFactory();
            
            BindGameStateMachine();

            BindAudioManager();

            BindInputService();
        }

        private void BindAudioManager()
        {
            Container.BindInterfacesAndSelfTo<AudioManager>().AsSingle();
        }

        private void BindInputService()
        {
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }

        private void BindAssetProvider()
        {
            Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
        }

        private void BindStaticDataService()
        {
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader.SceneLoader>().AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<GlobalStateMachine>().AsSingle();
        }

        private void BindStatesFactory()
        {
            Container.Bind<StatesFactory>().AsSingle();
        }

        private void BindScoreCounterService()
        {
            Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle();
        }

        private void BindTimerService()
        {
            Container.BindInterfacesAndSelfTo<TimerService>().AsSingle();
        }
    }
}