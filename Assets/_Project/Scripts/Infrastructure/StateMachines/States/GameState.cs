using _Project.Scripts.Core.Score;
using _Project.Scripts.Core.Timer;
using _Project.Scripts.Infrastructure.AssetProviders;

namespace _Project.Scripts.Infrastructure.StateMachines.States
{
    public class GameState : IState
    {
        private ITimer _timer;
        private IScoreCounter _scoreCounter;
        private readonly StaticDataService _staticDataService;

        public GameState(ITimer timer, 
            IScoreCounter scoreCounter, 
            StaticDataService staticDataService)
        {
            _timer = timer;
            _scoreCounter = scoreCounter;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _timer.Reset();
            _scoreCounter.Reset();

            _timer.Initialize(_staticDataService.GetTimerConfig().MaxTimer);
        }

        public void Exit()
        {
        }
    }
}