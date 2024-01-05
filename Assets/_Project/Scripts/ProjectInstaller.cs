using _Project.Scripts.Core.Score;
using _Project.Scripts.Core.Timer;
using Zenject;

namespace _Project.Scripts
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindTimerService();
            BindScoreCounterService();
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