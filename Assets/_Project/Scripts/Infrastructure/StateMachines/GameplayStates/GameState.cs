using _Project.Scripts.Configs;
using _Project.Scripts.Core.Circles;
using _Project.Scripts.Core.Score;
using _Project.Scripts.Core.Timer;
using _Project.Scripts.Infrastructure.AssetProviders;

namespace _Project.Scripts.Infrastructure.StateMachines.GameplayStates
{
    public class GameState : IState
    {
        private ITimer _timer;
        private GameplayStateMachine _gameplayStateMachine;
        private StaticDataService _staticDataService;
        private CircleSpawner _circleSpawner;
        private CirclesHolder _circlesHolder;
        private IScoreCounter _scoreCounter;
        private CircleConfigSO _circleConfigSO;

        public GameState(ITimer timer, 
            GameplayStateMachine gameplayStateMachine, 
            StaticDataService staticDataService, 
            CircleSpawner circleSpawner, 
            CirclesHolder circlesHolder, 
            IScoreCounter scoreCounter)
        {
            _timer = timer;
            _gameplayStateMachine = gameplayStateMachine;
            _staticDataService = staticDataService;
            _circleSpawner = circleSpawner;
            _circlesHolder = circlesHolder;
            _scoreCounter = scoreCounter;
        }

        public void Enter()
        {
            _circleConfigSO = _staticDataService.GetCircleConfig();
            
            _timer.Initialize(_staticDataService.GetTimerConfig().MaxTimer);
            _timer.OnTimerFinished += HandleTimerFinished;
            _circlesHolder.OnCircleClicked+= HandleCircleClicked;
            _scoreCounter.Reset();
            
            _timer.StartTimer();
            _circleSpawner.StartSpawning();
        }

        private void HandleCircleClicked(Circle circle)
        {
            _scoreCounter.AddScore(_circleConfigSO.scorePerCircle);
            _timer.RemoveTime(_circleConfigSO.timeToRemoveOnCircleClick);
        }

        private void HandleTimerFinished()
        {
           _gameplayStateMachine.Enter<GameOverState>(); 
        }

        public void Exit()
        {
            _timer.OnTimerFinished -= HandleTimerFinished;
            _circlesHolder.OnCircleClicked -= HandleCircleClicked;

            _timer.Reset();
            _circleSpawner.Reset();
            _circlesHolder.DestroyAllCircles();
        }
    }
}