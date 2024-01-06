using Zenject;

namespace _Project.Scripts.Core.Circles
{
    public class GameplayInstaller : MonoInstaller
    {
        public CircleSpawner circleSpawner;
        public override void InstallBindings()
        {
            BindCircleSpawner();
        }

        private void BindCircleSpawner()
        {
            Container.BindInterfacesAndSelfTo<CircleSpawner>()
                .FromInstance(circleSpawner)
                .AsSingle();
        }
    }
}