using _Project.Scripts.Core.Score;
using _Project.Scripts.Core.Timer;
using _Project.Scripts.Infrastructure.AssetProviders;
using _Project.Scripts.Infrastructure.SceneLoader;
using _Project.Scripts.Infrastructure.StateMachines;
using Zenject;

namespace _Project.Scripts
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();

            BindTimerService();
            BindScoreCounterService();

            BindStaticDataService();
            BindAssetProvider();

            BindGameOverStateObserver();

            BindStatesFactory();
            BindGameStateMachine();
        }

        private void BindGameOverStateObserver()
        {
            Container.BindInterfacesAndSelfTo<GameOverStateObserver>().AsSingle();
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
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<GameStateMachine>().AsSingle();
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