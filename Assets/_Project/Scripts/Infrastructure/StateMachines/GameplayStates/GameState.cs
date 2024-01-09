using _Project.Scripts.Configs;
using _Project.Scripts.Core.Circles;
using _Project.Scripts.Core.Score;
using _Project.Scripts.Core.Timer;
using _Project.Scripts.Infrastructure.AssetProviders;
using UnityEngine;

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
        
        private IInputService _inputService;
        private CircleRayhitDetector _circleRayhitDetector;
        private AudioManager _audioManager;

        public GameState(ITimer timer, 
            GameplayStateMachine gameplayStateMachine, 
            StaticDataService staticDataService, 
            CircleSpawner circleSpawner, 
            CirclesHolder circlesHolder, 
            IScoreCounter scoreCounter, 
            IInputService inputService, 
            CircleRayhitDetector circleRayhitDetector, 
            AudioManager audioManager)
        {
            _timer = timer;
            _gameplayStateMachine = gameplayStateMachine;
            _staticDataService = staticDataService;
            _circleSpawner = circleSpawner;
            _circlesHolder = circlesHolder;
            _scoreCounter = scoreCounter;
            _inputService = inputService;
            _circleRayhitDetector = circleRayhitDetector;
            _audioManager = audioManager;
        }

        public void Enter()
        {
            _circleConfigSO = _staticDataService.GetCircleConfig();
            
            _timer.Initialize(_staticDataService.GetTimerConfig().MaxTimer);
            _inputService.OnClick += HandleClick;
            _timer.OnTimerFinished += HandleTimerFinished;
            _circlesHolder.OnCircleClicked+= HandleCircleClicked;
            _scoreCounter.Reset();
            
            _timer.StartTimer();
            _circleSpawner.StartSpawning();
        }

        public void Exit()
        {
            _timer.OnTimerFinished -= HandleTimerFinished;
            _circlesHolder.OnCircleClicked -= HandleCircleClicked;
            _inputService.OnClick -= HandleClick;

            _timer.Reset();
            _circleSpawner.Reset();
            _circlesHolder.DestroyAllCircles();
        }

        private void HandleClick(Vector2 obj)
        {
            var circle = _circleRayhitDetector.RayHit(obj);
            if (circle != null)
            {
                _audioManager.PlayPopSound();
                circle.RunCircleClickedBehaviour();
            }
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
    }
}