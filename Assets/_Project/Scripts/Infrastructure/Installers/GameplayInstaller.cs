using _Project.Scripts.Core.Circles;
using _Project.Scripts.Core.Windows;
using _Project.Scripts.Infrastructure.StateMachines;
using Zenject;

namespace _Project.Scripts.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public CircleSpawner circleSpawner;

        public override void InstallBindings()
        {
            BindStatesFactory();

            BindCirclesHolder();

            BindCircleSpawner();

            BindCircleFactory();

            BindWindowController();

            BindCircleRayhitDetector();

            BindGameplayStateMachine();
        }

        private void BindCircleRayhitDetector()
        {
            Container.Bind<CircleRayhitDetector>().AsSingle();
        }

        private void BindCircleFactory()
        {
            Container.BindInterfacesAndSelfTo<CircleFactory>().AsSingle();
        }

        private void BindCirclesHolder()
        {
            Container.Bind<CirclesHolder>().AsSingle();
        }

        private void BindWindowController()
        {
            Container.BindInterfacesAndSelfTo<WindowController>().AsSingle();
        }

        private void BindGameplayStateMachine()
        {
            Container.Bind<GameplayStateMachine>().AsSingle();
        }

        private void BindStatesFactory()
        {
            Container.Bind<StatesFactory>().AsSingle();
        }

        private void BindCircleSpawner()
        {
            Container.BindInterfacesAndSelfTo<CircleSpawner>()
                .FromInstance(circleSpawner)
                .AsSingle();
        }
    }
}