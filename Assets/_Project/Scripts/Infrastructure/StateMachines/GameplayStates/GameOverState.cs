using _Project.Scripts.Core;
using _Project.Scripts.Core.Circles;
using _Project.Scripts.Core.Windows;

namespace _Project.Scripts.Infrastructure.StateMachines.GameplayStates
{
    public class GameOverState : IState
    {
        private IWindowController _windowController;

        public GameOverState(IWindowController windowController)
        {
            _windowController = windowController;
        }

        public void Enter()
        {
            _windowController.Show<GameOverWindow>();
        }

        public void Exit()
        {
            _windowController.Hide<GameOverWindow>();
        }
    }
}  