using Zenject;

namespace _Project.Scripts
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindTimerService();
        }

        private void BindTimerService()
        {
            Container.BindInterfacesAndSelfTo<TimerService>().AsSingle();
        }
    }
}