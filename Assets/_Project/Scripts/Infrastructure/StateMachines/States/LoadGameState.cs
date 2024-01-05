using _Project.Scripts.Core.Score;
using _Project.Scripts.Core.Timer;
using _Project.Scripts.Infrastructure.AssetProviders;
using _Project.Scripts.Infrastructure.SceneLoader;

namespace _Project.Scripts.Infrastructure.StateMachines.States
{
    public class LoadGameState : IState
    {
        private ITimer _timer;
        private IScoreCounter _scoreCounter;
        private ISceneLoader _sceneLoader;
        private StaticDataService _staticDataService;
        private GameStateMachine _gameStateMachine;

        public LoadGameState(ITimer timer,
            StaticDataService staticDataService, 
            GameStateMachine gameStateMachine, 
            ISceneLoader sceneLoader)
        {
            _timer = timer;
            _staticDataService = staticDataService;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _timer.Initialize(_staticDataService.GetTimerConfig().MaxTimer);

            _sceneLoader.Load(AssetPath.GAME_SCENE_NAME);
            _gameStateMachine.Enter<GameState>();
        }

        public void Exit()
        {
        }
    }
}