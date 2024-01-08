using _Project.Scripts.Core;
using _Project.Scripts.Core.Circles;
using _Project.Scripts.Core.Windows;
using _Project.Scripts.Infrastructure.StateMachines;
using _Project.Scripts.Infrastructure.StateMachines.GameplayStates;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Bootstraps
{
    public class GameplayBootstrapper : MonoBehaviour
    {
        public GameOverWindow gameOverWindow;
        
        private GameplayStateMachine _gameplayStateMachine;
        private StatesFactory _statesFactory;
        private IWindowController _windowController;

        [Inject]
        private void Construct(GameplayStateMachine gameplayStateMachine, 
            StatesFactory statesFactory,
            IWindowController windowController)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _statesFactory = statesFactory;
            _windowController = windowController;
        }

        private void Start()
        {
            InitializeServices();
            
            _gameplayStateMachine.RegisterState(_statesFactory.Create<GameState>());
            _gameplayStateMachine.RegisterState(_statesFactory.Create<GameOverState>());

            _gameplayStateMachine.Enter<GameState>();
        }
        
        private void InitializeServices()
        {
            _windowController.Add<GameOverWindow>(gameOverWindow);
        }
    }
}