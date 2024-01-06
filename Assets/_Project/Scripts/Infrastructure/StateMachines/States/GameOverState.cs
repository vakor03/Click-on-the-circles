namespace _Project.Scripts.Infrastructure.StateMachines.States
{
    public class GameOverState : IState
    {
        private GameOverStateObserver _gameOverStateObserver;

        public GameOverState(GameOverStateObserver gameOverStateObserver)
        {
            _gameOverStateObserver = gameOverStateObserver;
        }

        public void Enter()
        {
            _gameOverStateObserver.SetGameOver(true);
        }

        public void Exit()
        {
        }
    }
}