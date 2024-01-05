using _Project.Scripts.Score;
using _Project.Scripts.Timer;
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
            Container.BindInterfacesAndSelfTo<ScoreCounterService>().AsSingle();
        }

        private void BindTimerService()
        {
            Container.BindInterfacesAndSelfTo<TimerService>().AsSingle();
        }
    }
}